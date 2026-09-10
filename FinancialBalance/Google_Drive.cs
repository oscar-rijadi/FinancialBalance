using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

namespace FinancialBalance
{
    //Signing in to Google and putting a file on the user's Drive, using nothing but what the
    //framework already provides.  The alternative was the Google.Apis.* packages, which would
    //have brought a dozen or so DLLs to a program that ships as one exe, one config and one
    //mdb.  System.Web.Script.Serialization lives in System.Web.Extensions, a framework assembly
    //already on every machine that can run this, so it costs nothing to ship.
    //
    //The flow is the OAuth 2.0 authorization code grant for installed applications:
    //
    //  1. make a code verifier, and its SHA-256 as the challenge   (PKCE, required for desktop)
    //  2. listen on 127.0.0.1 on a port the OS picks
    //  3. open the system browser on Google's consent page
    //  4. Google redirects the browser back to that port carrying a one-time code
    //  5. swap the code and the verifier for an access token
    //
    //Nothing is written to disk and no refresh token is asked for, so every click signs in
    //again.  That is what was wanted, and it also means there is no stored credential to leak.
    //
    //The sign-in happens in the user's own browser rather than a window of ours on purpose:
    //Google rejects OAuth requests made from embedded browser controls, so an in-app dialog is
    //not an option however much it might suit the rest of the application.
    public static class Google_Drive
    {
        const string AuthEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        const string TokenEndpoint = "https://oauth2.googleapis.com/token";
        const string UploadEndpoint =
            "https://www.googleapis.com/upload/drive/v3/files?uploadType=multipart&fields=id,webViewLink";
        const string UpdateEndpoint =
            "https://www.googleapis.com/upload/drive/v3/files/{0}?uploadType=multipart&fields=id,webViewLink";
        const string FindEndpoint = "https://www.googleapis.com/drive/v3/files";

        //What the Sheet in Drive is called. One file, reused, so the link keeps working and
        //anyone it has been shared with sees the latest figures instead of collecting a new
        //file per export.
        const string DefaultSheetName = "Financial Balance ETFs or Stocks Investments";

        public static string Sheet_Name()
        {
            string TmpName = (ConfigurationManager.AppSettings["GoogleSheetName"] ?? "").Trim();
            return (TmpName == "" ? DefaultSheetName : TmpName);
        }

        //Only the files this application creates.  It cannot see anything else in the Drive,
        //which is the right level of access for something that only ever writes exports, and it
        //keeps clear of the scopes Google treats as restricted.
        const string Scope = "https://www.googleapis.com/auth/drive.file";

        const string SheetsMimeType = "application/vnd.google-apps.spreadsheet";
        const string XlsxMimeType =
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        //How long to wait for the user to finish in the browser before giving up on them
        const int SignInTimeoutSeconds = 180;

        public static string Client_Id()
        {
            return (ConfigurationManager.AppSettings["GoogleClientId"] ?? "").Trim();
        }

        public static string Client_Secret()
        {
            return (ConfigurationManager.AppSettings["GoogleClientSecret"] ?? "").Trim();
        }

        public static bool Configured
        {
            get { return Client_Id() != "" && Client_Secret() != ""; }
        }

        public static string Setup_Hint()
        {
            return "Put the OAuth client id and secret for a Google Cloud \"Desktop app\" client"
                 + Environment.NewLine
                 + "into FinancialBalance.exe.config, as GoogleClientId and GoogleClientSecret."
                 + Environment.NewLine + Environment.NewLine
                 + "See GOOGLE_DRIVE_EXPORT_PLAN.md for what to set up on the Google side.";
        }

        //---- PKCE ------------------------------------------------------------------

        //base64url: standard base64 with the two URL-unfriendly characters swapped and the
        //padding dropped, which is what the OAuth specifications ask for.
        internal static string Base64_Url(byte[] parBytes)
        {
            return Convert.ToBase64String(parBytes)
                          .Replace('+', '-')
                          .Replace('/', '_')
                          .TrimEnd('=');
        }

        internal static string New_Secret(int parBytes)
        {
            byte[] Buffer = new byte[parBytes];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(Buffer);
            }
            return Base64_Url(Buffer);
        }

        internal static string Challenge_For(string parVerifier)
        {
            using (SHA256 sha = SHA256.Create())
            {
                return Base64_Url(sha.ComputeHash(Encoding.ASCII.GetBytes(parVerifier)));
            }
        }

        //---- the consent URL --------------------------------------------------------

        //prompt=select_account consent is what makes Google ask every time rather than waving
        //through an account it already knows.  It cannot force a password prompt - if the
        //browser is still signed in, the user picks an account instead - because that is the
        //browser's session, not ours.
        internal static string Auth_Url(string parRedirect, string parChallenge, string parState)
        {
            return AuthEndpoint
                 + "?client_id=" + Uri.EscapeDataString(Client_Id())
                 + "&redirect_uri=" + Uri.EscapeDataString(parRedirect)
                 + "&response_type=code"
                 + "&scope=" + Uri.EscapeDataString(Scope)
                 + "&code_challenge=" + Uri.EscapeDataString(parChallenge)
                 + "&code_challenge_method=S256"
                 + "&state=" + Uri.EscapeDataString(parState)
                 + "&prompt=" + Uri.EscapeDataString("select_account consent")
                 + "&access_type=online";
        }

        internal static string Query_Value(string parQuery, string parName)
        {
            foreach (string Pair in parQuery.Split('&'))
            {
                int Eq = Pair.IndexOf('=');
                if (Eq > 0 && Pair.Substring(0, Eq) == parName)
                {
                    return Uri.UnescapeDataString(Pair.Substring(Eq + 1).Replace("+", " "));
                }
            }
            return "";
        }

        //---- the loopback listener ---------------------------------------------------

        //A raw socket rather than HttpListener.  HttpListener goes through HTTP.SYS, which wants
        //the URL prefix reserved with netsh or the process running as administrator; this
        //application has never needed either, and asking for them to receive one redirect would
        //be out of all proportion.  What comes back is a single GET, so it is read by hand.
        internal static string Read_Request_Line(NetworkStream parStream)
        {
            StringBuilder Line = new StringBuilder();
            byte[] One = new byte[1];
            while (Line.Length < 8192)
            {
                if (parStream.Read(One, 0, 1) == 0)
                {
                    break;
                }
                if (One[0] == '\n')
                {
                    break;
                }
                if (One[0] != '\r')
                {
                    Line.Append((char)One[0]);
                }
            }
            return Line.ToString();
        }

        internal static string Query_Of(string parRequestLine)
        {
            string[] Bits = parRequestLine.Split(' ');
            if (Bits.Length < 2)
            {
                return "";
            }
            int Mark = Bits[1].IndexOf('?');
            return (Mark < 0 ? "" : Bits[1].Substring(Mark + 1));
        }

        static void Answer(NetworkStream parStream, string parHeading, string parBody)
        {
            string Html = "<!doctype html><html><head><meta charset=\"utf-8\">"
                        + "<title>Financial Balance</title></head>"
                        + "<body style=\"font-family:Arial,sans-serif;margin:60px\">"
                        + "<h2>" + parHeading + "</h2><p>" + parBody + "</p></body></html>";
            byte[] Bytes = Encoding.UTF8.GetBytes(Html);
            byte[] Head = Encoding.ASCII.GetBytes(
                "HTTP/1.1 200 OK\r\nContent-Type: text/html; charset=utf-8\r\n"
                + "Content-Length: " + Bytes.Length + "\r\nConnection: close\r\n\r\n");
            parStream.Write(Head, 0, Head.Length);
            parStream.Write(Bytes, 0, Bytes.Length);
            parStream.Flush();
        }

        //---- signing in ---------------------------------------------------------------

        public static string Sign_In(out string parWhy)
        {
            parWhy = "";
            if (!Configured)
            {
                parWhy = "Google Drive is not set up yet." + Environment.NewLine
                       + Environment.NewLine + Setup_Hint();
                return null;
            }

            TcpListener Listener = null;
            try
            {
                //port 0 asks the operating system for a free one, so nothing has to be
                //configured and two copies of the program cannot collide
                Listener = new TcpListener(IPAddress.Loopback, 0);
                Listener.Start();
                int Port = ((IPEndPoint)Listener.LocalEndpoint).Port;
                string Redirect = "http://127.0.0.1:" + Port.ToString(CultureInfo.InvariantCulture);

                string Verifier = New_Secret(48);
                string State = New_Secret(16);
                string Url = Auth_Url(Redirect, Challenge_For(Verifier), State);

                try
                {
                    System.Diagnostics.Process.Start(Url);
                }
                catch (Exception ex)
                {
                    parWhy = "Could not open your browser to sign in to Google : " + ex.Message;
                    return null;
                }

                //wait for the browser to come back, but not for ever
                DateTime Deadline = DateTime.Now.AddSeconds(SignInTimeoutSeconds);
                while (!Listener.Pending())
                {
                    if (DateTime.Now > Deadline)
                    {
                        parWhy = "Sign in to Google was not completed, so nothing was uploaded.";
                        return null;
                    }
                    Thread.Sleep(150);
                }

                string Code = "";
                string Returned = "";
                string Error = "";
                using (TcpClient Client = Listener.AcceptTcpClient())
                using (NetworkStream Stream = Client.GetStream())
                {
                    string Query = Query_Of(Read_Request_Line(Stream));
                    Code = Query_Value(Query, "code");
                    Returned = Query_Value(Query, "state");
                    Error = Query_Value(Query, "error");

                    if (Error != "")
                    {
                        Answer(Stream, "Not signed in", "You can close this tab and go back to Financial Balance.");
                    }
                    else if (Code == "" || Returned != State)
                    {
                        Answer(Stream, "Something went wrong", "You can close this tab and go back to Financial Balance.");
                    }
                    else
                    {
                        Answer(Stream, "Signed in", "You can close this tab and go back to Financial Balance.");
                    }

                    //let the reply reach the browser before the socket goes away, or it shows a
                    //connection reset instead of the page
                    Stream.Flush();
                    try
                    {
                        Client.Client.Shutdown(SocketShutdown.Send);
                    }
                    catch
                    {
                        //the browser may already have gone; the code is what matters
                    }
                    Thread.Sleep(200);
                }

                if (Error != "")
                {
                    parWhy = "Google did not grant access : " + Error;
                    return null;
                }
                if (Code == "")
                {
                    parWhy = "Google did not send an authorisation code back.";
                    return null;
                }
                //a reply carrying the wrong state did not come from the request we made
                if (Returned != State)
                {
                    parWhy = "The reply from Google did not match the request. Nothing was uploaded.";
                    return null;
                }

                return Swap_Code_For_Token(Code, Verifier, Redirect, out parWhy);
            }
            catch (Exception ex)
            {
                parWhy = "Could not sign in to Google : " + ex.Message;
                return null;
            }
            finally
            {
                if (Listener != null)
                {
                    try
                    {
                        Listener.Stop();
                    }
                    catch
                    {
                    }
                }
            }
        }

        static string Swap_Code_For_Token(string parCode, string parVerifier, string parRedirect,
                                          out string parWhy)
        {
            parWhy = "";
            string Body = "code=" + Uri.EscapeDataString(parCode)
                        + "&client_id=" + Uri.EscapeDataString(Client_Id())
                        + "&client_secret=" + Uri.EscapeDataString(Client_Secret())
                        + "&code_verifier=" + Uri.EscapeDataString(parVerifier)
                        + "&redirect_uri=" + Uri.EscapeDataString(parRedirect)
                        + "&grant_type=authorization_code";

            string Reply;
            if (!Post(TokenEndpoint, "application/x-www-form-urlencoded",
                      Encoding.UTF8.GetBytes(Body), null, out Reply, out parWhy))
            {
                parWhy = "Google would not issue a token : " + parWhy;
                return null;
            }

            object Token = Field(Reply, "access_token");
            if (Token == null || Token.ToString().Trim() == "")
            {
                parWhy = "Google's reply carried no access token.";
                return null;
            }
            return Token.ToString();
        }

        //---- the upload ----------------------------------------------------------------

        //One multipart request: the metadata, then the workbook.  Naming the Google Sheets mime
        //type as the target is what makes Drive convert the upload into a real spreadsheet
        //instead of just storing the xlsx as a file.
        //The id of the Sheet this application already made under that name, or null.
        //
        //Worth knowing why this is safe to search by name: the drive.file scope only ever shows
        //this application its own files, so the query cannot pick up something of the user's
        //that happens to share the name. The flip side is that a Sheet they delete, or rename,
        //or that was made by a different OAuth client, will not be found - and a new one is
        //made instead, which is the right thing to do in each of those cases.
        internal static string Find_Existing(string parToken, string parName, out string parWhy)
        {
            parWhy = "";
            try
            {
                //a quote inside the name would otherwise end the literal
                string TmpQuery = "name = '" + parName.Replace("\\", "\\\\").Replace("'", "\\'") + "'"
                                + " and mimeType = '" + SheetsMimeType + "'"
                                + " and trashed = false";
                string Url = FindEndpoint
                           + "?q=" + Uri.EscapeDataString(TmpQuery)
                           + "&fields=" + Uri.EscapeDataString("files(id,name)")
                           + "&spaces=drive&pageSize=10";

                string Reply;
                if (!Get(Url, parToken, out Reply, out parWhy))
                {
                    return null;
                }

                JavaScriptSerializer Json = new JavaScriptSerializer();
                Dictionary<string, object> Map = Json.Deserialize<Dictionary<string, object>>(Reply);
                if (Map == null || !Map.ContainsKey("files"))
                {
                    return null;
                }
                object[] Files = Map["files"] as object[];
                if (Files == null || Files.Length == 0)
                {
                    return null;
                }
                //more than one would mean an earlier run made a duplicate; the first is taken
                //and the rest left alone rather than quietly deleting anything
                Dictionary<string, object> First = Files[0] as Dictionary<string, object>;
                if (First != null && First.ContainsKey("id"))
                {
                    return First["id"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                parWhy = ex.Message;
                return null;
            }
        }

        public static bool Upload(string parToken, string parPath, string parTitle,
                                  out string parLink, out bool parReplaced, out string parWhy)
        {
            parLink = "";
            parReplaced = false;
            parWhy = "";
            try
            {
                //if this application has made the file before, replace its contents so the id,
                //the link and anything shared off it all survive
                string TmpFound = Find_Existing(parToken, parTitle, out parWhy);
                parReplaced = (TmpFound != null);
                string Boundary = "FinancialBalance" + New_Secret(12).Replace("-", "").Replace("_", "");
                JavaScriptSerializer Json = new JavaScriptSerializer();
                Dictionary<string, object> Meta = new Dictionary<string, object>();
                Meta["name"] = parTitle;
                Meta["mimeType"] = SheetsMimeType;

                byte[] File_Bytes = File.ReadAllBytes(parPath);

                MemoryStream Body = new MemoryStream();
                Write_Ascii(Body, "--" + Boundary + "\r\n");
                Write_Ascii(Body, "Content-Type: application/json; charset=UTF-8\r\n\r\n");
                Write_Utf8(Body, Json.Serialize(Meta));
                Write_Ascii(Body, "\r\n--" + Boundary + "\r\n");
                Write_Ascii(Body, "Content-Type: " + XlsxMimeType + "\r\n\r\n");
                Body.Write(File_Bytes, 0, File_Bytes.Length);
                Write_Ascii(Body, "\r\n--" + Boundary + "--\r\n");

                string Url = (TmpFound == null
                    ? UploadEndpoint
                    : string.Format(CultureInfo.InvariantCulture, UpdateEndpoint,
                                    Uri.EscapeDataString(TmpFound)));
                //PATCH replaces the contents of the file that is already there; POST makes one
                string Verb = (TmpFound == null ? "POST" : "PATCH");

                string Reply;
                if (!Send(Verb, Url, "multipart/related; boundary=" + Boundary,
                          Body.ToArray(), parToken, out Reply, out parWhy))
                {
                    parWhy = "Google Drive would not take the file : " + parWhy;
                    return false;
                }

                object Link = Field(Reply, "webViewLink");
                object Id = Field(Reply, "id");
                if (Link != null && Link.ToString().Trim() != "")
                {
                    parLink = Link.ToString();
                }
                else if (Id != null)
                {
                    parLink = "https://docs.google.com/spreadsheets/d/" + Id.ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                parWhy = "Could not upload to Google Drive : " + ex.Message;
                return false;
            }
        }

        static void Write_Ascii(Stream parStream, string parText)
        {
            byte[] Bytes = Encoding.ASCII.GetBytes(parText);
            parStream.Write(Bytes, 0, Bytes.Length);
        }

        static void Write_Utf8(Stream parStream, string parText)
        {
            byte[] Bytes = Encoding.UTF8.GetBytes(parText);
            parStream.Write(Bytes, 0, Bytes.Length);
        }

        //---- talking to Google ----------------------------------------------------------

        static bool Post(string parUrl, string parContentType, byte[] parBody, string parToken,
                         out string parReply, out string parWhy)
        {
            return Send("POST", parUrl, parContentType, parBody, parToken, out parReply, out parWhy);
        }

        static bool Get(string parUrl, string parToken, out string parReply, out string parWhy)
        {
            return Send("GET", parUrl, null, null, parToken, out parReply, out parWhy);
        }

        static bool Send(string parVerb, string parUrl, string parContentType, byte[] parBody,
                         string parToken, out string parReply, out string parWhy)
        {
            parReply = "";
            parWhy = "";
            try
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(parUrl);
                Request.Method = parVerb;
                if (parContentType != null)
                {
                    Request.ContentType = parContentType;
                }
                Request.UserAgent = "FinancialBalance";
                Request.Timeout = 120000;
                if (parToken != null)
                {
                    Request.Headers["Authorization"] = "Bearer " + parToken;
                }
                if (parBody != null)
                {
                    Request.ContentLength = parBody.Length;
                    using (Stream Out = Request.GetRequestStream())
                    {
                        Out.Write(parBody, 0, parBody.Length);
                    }
                }
                using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
                using (StreamReader Reader = new StreamReader(Response.GetResponseStream()))
                {
                    parReply = Reader.ReadToEnd();
                }
                return true;
            }
            catch (WebException ex)
            {
                //Google puts the reason in the body of the failing response, and it is far more
                //use than "The remote server returned an error: (400) Bad Request"
                parWhy = ex.Message;
                if (ex.Response != null)
                {
                    try
                    {
                        using (StreamReader Reader = new StreamReader(ex.Response.GetResponseStream()))
                        {
                            string Detail = Reader.ReadToEnd();
                            string Said = Google_Said(Detail);
                            if (Said != "")
                            {
                                parWhy = Said;
                            }
                        }
                    }
                    catch
                    {
                        //keep the outer message
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                parWhy = ex.Message;
                return false;
            }
        }

        //---- reading the little JSON that comes back --------------------------------------

        static object Field(string parJson, string parName)
        {
            try
            {
                JavaScriptSerializer Json = new JavaScriptSerializer();
                Dictionary<string, object> Map =
                    Json.Deserialize<Dictionary<string, object>>(parJson);
                if (Map != null && Map.ContainsKey(parName))
                {
                    return Map[parName];
                }
            }
            catch
            {
                //an unreadable reply is handled by the caller finding nothing
            }
            return null;
        }

        //Errors come back in one of two shapes: {"error":"invalid_grant", ...} from the token
        //endpoint, {"error":{"message":"..."}} from Drive.
        internal static string Google_Said(string parJson)
        {
            try
            {
                JavaScriptSerializer Json = new JavaScriptSerializer();
                Dictionary<string, object> Map =
                    Json.Deserialize<Dictionary<string, object>>(parJson);
                if (Map == null || !Map.ContainsKey("error"))
                {
                    return "";
                }

                object Error = Map["error"];
                Dictionary<string, object> Inner = Error as Dictionary<string, object>;
                if (Inner != null)
                {
                    if (Inner.ContainsKey("message"))
                    {
                        return Inner["message"].ToString();
                    }
                    return "";
                }

                string Text = Error.ToString();
                if (Map.ContainsKey("error_description"))
                {
                    Text = Text + " - " + Map["error_description"].ToString();
                }
                return Text;
            }
            catch
            {
                return "";
            }
        }
    }
}
