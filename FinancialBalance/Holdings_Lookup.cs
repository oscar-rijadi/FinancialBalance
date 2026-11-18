using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace FinancialBalance
{
    //Looks a set of tickers through to the companies they hold - shared by ETF/Stock Investment
    //Plan Top Holdings and ETF/Stock Portfolio Top Holdings, which differ only in where the
    //tickers and their shares come from.  Every ticker is asked of Yahoo Finance: a fund answers
    //with its own top holdings and each one's weight in it, and a share answers as a share.  A
    //company's share of the whole is then
    //
    //    share of the ticker x the company's weight in that ticker
    //
    //added up across every ticker that holds it - BHP through both VAS and A200 is one row.  A
    //share is the company itself, at the ticker's whole share.  The same weights carry an
    //amount in dollars, when the caller has one, through the same sum.
    //
    //Reads TblETFStocks for the setup of each ticker and writes nothing.  Every request runs on
    //the caller's thread, as the application's other network buttons do.
    public class Holdings_Lookup
    {
        public const int TopCount = 10;

        //One ticker to look through: its share of the whole, as a percentage, and optionally
        //what that share is worth.  An Amount of 0 just means the caller has no dollar figure.
        public class Input
        {
            public string FullTicker = "";
            public double Allocation;
            public double Amount;
        }

        public class Holding
        {
            public string Symbol = "";
            public string Name = "";
            public double Weight;   //a percentage of the fund, 11.19 for 11.19 %
            public bool NameOnly;   //the symbol names no exchange, so it is matched by name alone
            public string Path = "";    //the funds it was found inside, "VTI" or "VTI > XYZ"; blank when held directly
        }

        //One ticker's holdings as they stand partway through: what it was looked up through,
        //and its holdings, which funds inside it are later swapped for their own.
        private class Answer
        {
            public Input Item;
            public string ViaLabel = "";
            public List<Holding> Holdings = new List<Holding>();
        }

        //How many funds deep a holding is followed: DHHF > VTI is one level; a fund three deep
        //inside another is as far as anything real goes, and the cap keeps a loop finite.
        public const int MaxNesting = 3;

        public class Company
        {
            public string Symbol = "";
            public string Name = "";
            public double Allocation;   //a percentage of the whole
            public double Amount;       //the same share in dollars, when the inputs carried any
            public List<string> Via = new List<string>();   //"VAS.AX 11.19 %", one per ticker
        }

        public class Result
        {
            public List<Company> Companies = new List<Company>();   //every company, largest first
            public List<string> Failed = new List<string>();       //one reason per ticker left out
            public List<string> VanguardDates = new List<string>();
            public List<string> Nested = new List<string>();        //funds found inside funds and looked through
            public List<string> NestedFailed = new List<string>();  //funds inside funds left as they were
            public string NestedError = "";
            public int Answered;
            public int Through;
            public int Asked;

            public List<Company> Top()
            {
                return Companies.Take(TopCount).ToList();
            }

            //What the table rests on, in a sentence or three.  parOfWhat names the whole the
            //percentages are of - "the plan", "the portfolio".
            public string Describe(string parOfWhat)
            {
                List<Company> TmpTop = Top();
                double TopTotal = TmpTop.Sum(c => c.Allocation);
                string TmpNote = "Top " + TmpTop.Count.ToString() + " of " + Companies.Count.ToString()
                               + " companies, together " + TopTotal.ToString("#,##0.00") + " % of " + parOfWhat
                               + ", from " + Answered.ToString() + " of " + Asked.ToString() + " ticker(s)"
                               + (Through > 0 ? ", " + Through.ToString() + " of them through a look-through ticker" : "")
                               + ". Each fund counts only its top ten holdings.";
                if (VanguardDates.Count > 0)
                {
                    TmpNote = TmpNote + "  From Vanguard : " + String.Join(", ", VanguardDates.ToArray()) + ".";
                }
                if (Nested.Count > 0)
                {
                    TmpNote = TmpNote + "  Funds inside funds looked through : " + String.Join(", ", Nested.ToArray()) + ".";
                }
                if (NestedFailed.Count > 0)
                {
                    //Yahoo calls the odd foreign share a fund - 000660.KQ, SK Hynix, inside SPEM - and
                    //then has no holdings for it, so these are counted as they are
                    TmpNote = TmpNote + "  Counted as they are, called funds by Yahoo but with no holdings listed : "
                            + String.Join(", ", NestedFailed.ToArray()) + ".";
                }
                if (NestedError != "")
                {
                    TmpNote = TmpNote + "  " + NestedError;
                }
                if (Failed.Count > 0)
                {
                    TmpNote = TmpNote + "  Not looked through : " + String.Join("  ", Failed.ToArray());
                }
                return TmpNote;
            }
        }

        private string Read_Text(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return "";
            }
            return parValue.ToString().Trim();
        }

        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00") + " %";
        }

        //Looks every ticker through and returns the companies, largest first.  parProgress, when
        //given, is told what is being asked so the caller can say so on screen.  Returns null
        //with parError when Yahoo will not talk at all, since then nothing can be looked through.
        public Result Run(List<Input> parItems, Action<string> parProgress, out string parError)
        {
            parError = "";
            Action<string> Say = (parProgress ?? (s => { }));

            Dictionary<string, Setup_Row> Setup = Read_Setup(parItems);

            Say("Asking Yahoo Finance ...");
            CookieContainer Jar = new CookieContainer();
            string TmpError;
            string Crumb = Get_Yahoo_Crumb(Jar, out TmpError);
            if (Crumb == "")
            {
                parError = TmpError;
                return null;
            }

            //One company held through several funds is one row.  It is found by symbol first
            //and by name failing that, so the same company named by two sources - Yahoo's "TXN"
            //and Vanguard's "TXN", or a European share Vanguard gives no exchange for - still
            //lands on one row.
            Dictionary<string, Company> BySymbol = new Dictionary<string, Company>();
            Dictionary<string, Company> ByName = new Dictionary<string, Company>();
            Result Outcome = new Result();
            Outcome.Asked = parItems.Count;
            Vanguard_Funds = null;
            List<Answer> Answers = new List<Answer>();

            foreach (Input Item in parItems)
            {
                Setup_Row TmpSetup = Setup[Item.FullTicker.ToUpper()];

                //A look-through ticker set in ETF/Stock Setup stands in for this one: its
                //holdings are used, at this ticker's share.  JPEQ.AX holds JEPQ, and JEPQ's
                //holdings are what Yahoo can name.
                bool Via = (TmpSetup.LookThrough != "");
                string TmpSource = (Via ? TmpSetup.LookThrough : Item.FullTicker);
                bool IsAX = (TmpSetup.Suffix.ToUpper() == "AX" && TmpSetup.Ticker != "");

                Say("Asking Yahoo Finance about " + TmpSource + " ...");

                List<Holding> TmpHoldings;
                bool IsShare;
                bool Ok = Fetch_Top_Holdings(TmpSource, Jar, Crumb, out TmpHoldings, out IsShare, out TmpError);
                bool FundAsShare = false;

                //Yahoo's "this is a share" is taken on trust except for an ASX listing it is
                //asked about directly, where it is known to be wrong for some funds.  A
                //look-through ticker was chosen by hand, so whatever it is, it was meant.
                if (Ok && IsShare && !Via && IsAX && Is_ASX_Fund(TmpSetup.Ticker))
                {
                    Ok = false;
                    FundAsShare = true;
                    TmpError = "Yahoo Finance lists no holdings for " + Item.FullTicker
                             + " - it reports this fund as a share.";
                }

                //Where Yahoo has nothing to give for an ASX fund, Vanguard is asked whether it is
                //one of theirs - VVLU is.  Vanguard publishes every one of its Australian ETFs'
                //holdings itself, so for those it is the issuer's own figure.
                string ViaLabel = (Via ? TmpSource : "");
                if (!Ok && !Via && IsAX)
                {
                    Say("Asking Vanguard about " + Item.FullTicker + " ...");

                    string TmpAsOf;
                    string TmpVgError;
                    if (Fetch_Vanguard_Holdings(TmpSetup.Ticker, out TmpHoldings, out TmpAsOf, out TmpVgError))
                    {
                        Ok = true;
                        ViaLabel = "Vanguard";
                        Outcome.VanguardDates.Add(Item.FullTicker + (TmpAsOf == "" ? "" : " as at " + TmpAsOf));
                    }
                    else if (TmpVgError != "")
                    {
                        TmpError = TmpError + " " + TmpVgError;
                    }
                }

                if (!Ok)
                {
                    Outcome.Failed.Add(TmpError + (Via ? " (look-through for " + Item.FullTicker + ")" : "")
                                     + (FundAsShare ? " Set a Look-Through Ticker in ETF/Stock Setup if it"
                                                      + " invests through another fund." : ""));
                    continue;
                }
                Outcome.Answered++;
                if (Via)
                {
                    Outcome.Through++;
                }

                Answer TmpAnswer = new Answer();
                TmpAnswer.Item = Item;
                TmpAnswer.ViaLabel = ViaLabel;
                TmpAnswer.Holdings = TmpHoldings;
                Answers.Add(TmpAnswer);
            }

            //A fund of funds - DHHF holds VTI, A200, SPDW and SPEM - lists funds, not companies,
            //so every fund found among the holdings is swapped for its own top holdings.
            Expand_Nested_Funds(Answers, Jar, Crumb, Outcome, Say);

            foreach (Answer TmpAnswer in Answers)
            {
                foreach (Holding TmpHolding in TmpAnswer.Holdings)
                {
                    Company TmpCompany = Find_Company(TmpHolding, BySymbol, ByName);
                    if (TmpCompany == null)
                    {
                        TmpCompany = new Company();
                        TmpCompany.Symbol = TmpHolding.Symbol;
                        TmpCompany.Name = TmpHolding.Name;
                        Outcome.Companies.Add(TmpCompany);
                    }
                    Remember_Company(TmpCompany, TmpHolding, BySymbol, ByName);
                    TmpCompany.Allocation += TmpAnswer.Item.Allocation * TmpHolding.Weight / 100;
                    TmpCompany.Amount += TmpAnswer.Item.Amount * TmpHolding.Weight / 100;
                    //"DHHF.AX via VTI 2.71 %" - the weight is the company's share of the
                    //holding itself, whatever it was found inside on the way
                    string TmpRoute = TmpAnswer.ViaLabel;
                    if (TmpHolding.Path != "")
                    {
                        TmpRoute = (TmpRoute == "" ? TmpHolding.Path : TmpRoute + " > " + TmpHolding.Path);
                    }
                    TmpCompany.Via.Add(TmpAnswer.Item.FullTicker + (TmpRoute != "" ? " via " + TmpRoute : "")
                                     + " " + Percent(TmpHolding.Weight));
                }
            }

            Outcome.Companies = Outcome.Companies
                                       .OrderByDescending(c => c.Allocation)
                                       .ThenBy(c => c.Symbol)
                                       .ToList();
            return Outcome;
        }

        //---- Yahoo Finance ---------------------------------------------------------

        //WebClient keeps no cookies, and Yahoo's quoteSummary will not answer without the one
        //it hands out alongside a crumb - the same reason ETF/Stock Setup goes through
        //HttpWebRequest for its expense ratios.  A null jar is a request that carries none.
        private string Download(string parUrl, CookieContainer parJar)
        {
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(parUrl);
            Request.UserAgent = "Mozilla/5.0";
            Request.CookieContainer = parJar;
            using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
            using (StreamReader Reader = new StreamReader(Response.GetResponseStream()))
            {
                return Reader.ReadToEnd();
            }
        }

        //quoteSummary answers 401 to a bare request: it wants a crumb, and the crumb is only
        //handed to a caller holding the cookie fc.yahoo.com sets.  That page answers 404 and
        //sets the cookie anyway, so its failing is expected and not an error.  Returns the
        //crumb, or "" with the reason when there is none to be had.
        private string Get_Yahoo_Crumb(CookieContainer parJar, out string parError)
        {
            parError = "";

            try
            {
                Download("https://fc.yahoo.com/", parJar);
            }
            catch (WebException)
            {
                //the cookie comes back on the 404, which is all this request is for
            }

            try
            {
                string TmpCrumb = Download("https://query1.finance.yahoo.com/v1/test/getcrumb", parJar).Trim();
                if (TmpCrumb == "" || TmpCrumb.Contains("<") || TmpCrumb.Contains("{"))
                {
                    parError = "Yahoo Finance did not hand out a crumb, so it cannot be asked for holdings.";
                    return "";
                }
                return TmpCrumb;
            }
            catch (Exception ex)
            {
                parError = "Could not reach Yahoo Finance : " + ex.Message;
                return "";
            }
        }

        //JavaScriptSerializer hands objects back as dictionaries and arrays as object[], so
        //these walk the answer without a cast at every step.  Anything missing reads as null.
        private object Json_Get(object parNode, string parKey)
        {
            Dictionary<string, object> TmpDict = parNode as Dictionary<string, object>;
            if (TmpDict == null || !TmpDict.ContainsKey(parKey))
            {
                return null;
            }
            return TmpDict[parKey];
        }

        private string Json_Text(object parNode, string parKey)
        {
            object TmpValue = Json_Get(parNode, parKey);
            return (TmpValue == null ? "" : TmpValue.ToString().Trim());
        }

        private double Json_Number(object parValue)
        {
            if (parValue == null)
            {
                return 0;
            }
            try
            {
                return Convert.ToDouble(parValue, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //What ETF/Stock Setup holds about one ticker that decides how it is looked up
        private class Setup_Row
        {
            public string Ticker = "";          //bare code, A200 for A200.AX
            public string Suffix = "";
            public string LookThrough = "";     //blank: looked up as itself
        }

        //Read for every ticker being looked up before anything goes out, so no reader is open on
        //the shared connection while the network is being waited on.  A ticker missing
        //from ETF/Stock Setup simply gets an empty row and is looked up as itself.
        private Dictionary<string, Setup_Row> Read_Setup(List<Input> parItems)
        {
            Dictionary<string, Setup_Row> Result = new Dictionary<string, Setup_Row>();
            Mdl1.Ssql = "select Full_Ticker, Ticker, Exchange_Suffix, Look_Through_Ticker from TblETFStocks";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Setup_Row TmpRow = new Setup_Row();
                TmpRow.Ticker = Read_Text(reader["Ticker"]);
                TmpRow.Suffix = Read_Text(reader["Exchange_Suffix"]);
                TmpRow.LookThrough = Read_Text(reader["Look_Through_Ticker"]).ToUpper();
                Result[Read_Text(reader["Full_Ticker"]).ToUpper()] = TmpRow;
            }
            reader.Close();

            foreach (Input Item in parItems)
            {
                if (!Result.ContainsKey(Item.FullTicker.ToUpper()))
                {
                    Result[Item.FullTicker.ToUpper()] = new Setup_Row();
                }
            }
            return Result;
        }

        //Yahoo calls some ASX funds EQUITY - JPEQ and VVLU among them - which would pass a whole
        //fund off as a single company at its full allocation.  The ASX research API tells the
        //two apart the same way Get All Expense Ratio does: a fund always carries a net asset
        //value and a company never does.  Asked by the bare code, JPEQ rather than JPEQ.AX.
        //When the ASX cannot answer, Yahoo's word stands - there is nothing better to go on.
        private bool Is_ASX_Fund(string parCode)
        {
            try
            {
                string Json = Download("https://asx.api.markitdigital.com/asx-research/1.0/etfs/"
                                       + Uri.EscapeDataString(parCode) + "/key-statistics", null);
                return System.Text.RegularExpressions.Regex.IsMatch(Json, "\"nav\"\\s*:");
            }
            catch (Exception)
            {
                return false;
            }
        }

        //One ticker's top holdings.  A share is answered as itself at 100 %, which is what
        //owning it amounts to, and parIsShare says that is what happened.  Returns false, with
        //the reason, when there is nothing to use.
        private bool Fetch_Top_Holdings(string parTicker, CookieContainer parJar, string parCrumb,
                                        out List<Holding> parHoldings, out bool parIsShare,
                                        out string parError)
        {
            parHoldings = new List<Holding>();
            parIsShare = false;
            parError = "";

            try
            {
                string Json = Download("https://query1.finance.yahoo.com/v10/finance/quoteSummary/"
                                       + Uri.EscapeDataString(parTicker) + "?modules=quoteType,topHoldings"
                                       + "&crumb=" + Uri.EscapeDataString(parCrumb), parJar);

                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                Serializer.MaxJsonLength = int.MaxValue;
                object Root = Serializer.DeserializeObject(Json);
                object[] Results = Json_Get(Json_Get(Root, "quoteSummary"), "result") as object[];
                if (Results == null || Results.Length == 0)
                {
                    parError = "Yahoo Finance does not recognise the ticker " + parTicker + ".";
                    return false;
                }
                object Result = Results[0];

                object QuoteType = Json_Get(Result, "quoteType");
                if (Json_Text(QuoteType, "quoteType") == "EQUITY")
                {
                    Holding Self = new Holding();
                    Self.Symbol = parTicker;
                    Self.Name = Json_Text(QuoteType, "longName");
                    if (Self.Name == "")
                    {
                        Self.Name = Json_Text(QuoteType, "shortName");
                    }
                    Self.Weight = 100;
                    parHoldings.Add(Self);
                    parIsShare = true;
                    return true;
                }

                object[] Rows = Json_Get(Json_Get(Result, "topHoldings"), "holdings") as object[];
                if (Rows != null)
                {
                    foreach (object Row in Rows)
                    {
                        Holding TmpHolding = new Holding();
                        TmpHolding.Symbol = Json_Text(Row, "symbol");
                        TmpHolding.Name = Json_Text(Row, "holdingName");
                        //a fraction - 0.1119 for 11.19 %
                        TmpHolding.Weight = Json_Number(Json_Get(Json_Get(Row, "holdingPercent"), "raw")) * 100;
                        if ((TmpHolding.Symbol != "" || TmpHolding.Name != "") && TmpHolding.Weight > 0)
                        {
                            parHoldings.Add(TmpHolding);
                        }
                    }
                }

                if (parHoldings.Count == 0)
                {
                    parError = "Yahoo Finance lists no holdings for " + parTicker + ".";
                    return false;
                }
                return true;
            }
            catch (WebException ex)
            {
                HttpWebResponse Response = ex.Response as HttpWebResponse;
                if (Response != null && Response.StatusCode == HttpStatusCode.NotFound)
                {
                    parError = "Yahoo Finance does not recognise the ticker " + parTicker + ".";
                }
                else
                {
                    parError = "Could not reach Yahoo Finance : " + ex.Message;
                }
                return false;
            }
            catch (Exception ex)
            {
                parError = parTicker + " : " + ex.Message;
                return false;
            }
        }

        //---- funds inside funds ----------------------------------------------------

        //Which of these symbols Yahoo calls a fund.  One request answers for a whole batch - the
        //v7 quote endpoint takes a list - so finding the funds among sixty holdings costs one
        //request, not sixty.  Returns false with parError when Yahoo will not answer, in which
        //case nothing is taken to be a fund and the holdings stay as they are.
        private bool Find_Funds(List<string> parSymbols, CookieContainer parJar, string parCrumb,
                                HashSet<string> parFunds, out string parError)
        {
            parError = "";
            const int Batch = 50;

            try
            {
                for (int i = 0; i < parSymbols.Count; i += Batch)
                {
                    List<string> TmpChunk = parSymbols.Skip(i).Take(Batch).ToList();
                    string Json = Download("https://query1.finance.yahoo.com/v7/finance/quote?symbols="
                                           + String.Join(",", TmpChunk.Select(s => Uri.EscapeDataString(s)).ToArray())
                                           + "&fields=quoteType&crumb=" + Uri.EscapeDataString(parCrumb), parJar);
                    JavaScriptSerializer Serializer = new JavaScriptSerializer();
                    Serializer.MaxJsonLength = int.MaxValue;
                    object[] Rows = Json_Get(Json_Get(Serializer.DeserializeObject(Json), "quoteResponse"), "result") as object[];
                    if (Rows == null)
                    {
                        continue;
                    }
                    foreach (object Row in Rows)
                    {
                        //MUTUALFUND too: Yahoo files some unlisted feeder funds that way
                        string TmpType = Json_Text(Row, "quoteType").ToUpper();
                        if (TmpType == "ETF" || TmpType == "MUTUALFUND")
                        {
                            parFunds.Add(Json_Text(Row, "symbol").ToUpper());
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                parError = "Could not check the holdings for funds inside funds : " + ex.Message;
                return false;
            }
        }

        //Swaps every fund found among the holdings for that fund's own top holdings, each at
        //the parent's weight times its own - VTI is 40.43 % of DHHF and Apple 6.70 % of VTI, so
        //Apple is 2.71 % of DHHF.  Done level by level, MaxNesting deep at most, and a fund is
        //never opened inside itself.  A fund whose holdings cannot be had is left in as it was,
        //since a share of something unnamed is still better than dropping the money.
        private void Expand_Nested_Funds(List<Answer> parAnswers, CookieContainer parJar, string parCrumb,
                                         Result parOutcome, Action<string> parSay)
        {
            Dictionary<string, List<Holding>> Opened = new Dictionary<string, List<Holding>>();
            HashSet<string> Funds = new HashSet<string>();
            HashSet<string> Checked = new HashSet<string>();

            for (int Level = 0; Level < MaxNesting; Level++)
            {
                //every symbol not yet asked about - a holding named only by name, or one that is
                //the ticker itself standing in as a share, has nothing to ask
                List<string> ToCheck = new List<string>();
                foreach (Answer TmpAnswer in parAnswers)
                {
                    foreach (Holding TmpHolding in TmpAnswer.Holdings)
                    {
                        string TmpSymbol = TmpHolding.Symbol.ToUpper();
                        if (TmpHolding.NameOnly || TmpSymbol == "" || TmpSymbol == TmpAnswer.Item.FullTicker.ToUpper()
                            || Checked.Contains(TmpSymbol) || ToCheck.Contains(TmpSymbol))
                        {
                            continue;
                        }
                        ToCheck.Add(TmpSymbol);
                    }
                }
                if (ToCheck.Count == 0)
                {
                    return;
                }

                parSay("Checking " + ToCheck.Count.ToString() + " holding(s) for funds inside funds ...");
                string TmpError;
                if (!Find_Funds(ToCheck, parJar, parCrumb, Funds, out TmpError))
                {
                    parOutcome.NestedError = TmpError;
                    return;
                }
                foreach (string TmpSymbol in ToCheck)
                {
                    Checked.Add(TmpSymbol);
                }

                bool AnyOpened = false;
                foreach (Answer TmpAnswer in parAnswers)
                {
                    List<Holding> Expanded = new List<Holding>();
                    foreach (Holding TmpHolding in TmpAnswer.Holdings)
                    {
                        string TmpSymbol = TmpHolding.Symbol.ToUpper();
                        List<string> TmpPath = (TmpHolding.Path == "" ? new List<string>()
                                                : TmpHolding.Path.Split(new string[] { " > " }, StringSplitOptions.None).ToList());
                        bool IsFund = (!TmpHolding.NameOnly && Funds.Contains(TmpSymbol)
                                       && TmpSymbol != TmpAnswer.Item.FullTicker.ToUpper()
                                       && !TmpPath.Contains(TmpHolding.Symbol));

                        List<Holding> Inside = null;
                        if (IsFund)
                        {
                            if (!Opened.TryGetValue(TmpSymbol, out Inside))
                            {
                                parSay("Asking Yahoo Finance about " + TmpHolding.Symbol + ", a fund inside a fund ...");
                                bool IsShare;
                                string TmpFetchError;
                                if (!Fetch_Top_Holdings(TmpHolding.Symbol, parJar, parCrumb, out Inside, out IsShare, out TmpFetchError)
                                    || IsShare)
                                {
                                    Inside = null;
                                    if (!parOutcome.NestedFailed.Contains(TmpHolding.Symbol))
                                    {
                                        parOutcome.NestedFailed.Add(TmpHolding.Symbol);
                                    }
                                }
                                Opened[TmpSymbol] = Inside;
                            }
                        }

                        if (Inside == null)
                        {
                            Expanded.Add(TmpHolding);
                            continue;
                        }

                        if (!parOutcome.Nested.Contains(TmpHolding.Symbol))
                        {
                            parOutcome.Nested.Add(TmpHolding.Symbol);
                        }
                        AnyOpened = true;
                        string ChildPath = (TmpHolding.Path == "" ? TmpHolding.Symbol : TmpHolding.Path + " > " + TmpHolding.Symbol);
                        foreach (Holding TmpChild in Inside)
                        {
                            Holding Scaled = new Holding();
                            Scaled.Symbol = TmpChild.Symbol;
                            Scaled.Name = TmpChild.Name;
                            Scaled.NameOnly = TmpChild.NameOnly;
                            Scaled.Weight = TmpHolding.Weight * TmpChild.Weight / 100;
                            Scaled.Path = ChildPath;
                            Expanded.Add(Scaled);
                        }
                    }
                    TmpAnswer.Holdings = Expanded;
                }

                if (!AnyOpened)
                {
                    return;
                }
            }
        }

        //---- Vanguard --------------------------------------------------------------
        //
        //Vanguard Australia's own site carries the holdings of every one of its ETFs, read by
        //the fund's Vanguard id rather than its ASX code - VVLU is 8202, VAS 8205.  The list of
        //funds that maps one to the other is asked for once per click, and only when a ticker
        //actually needs it.  Like Yahoo's and the ASX's, these are the requests the site's own
        //pages make, not a published service, and can change without notice.

        const string VanguardBase = "https://www.vanguard.com.au/personal/api/";

        //ASX code -> Vanguard id.  null until asked for; empty when the list could not be had.
        Dictionary<string, string> Vanguard_Funds;
        string Vanguard_Funds_Error = "";

        private void Load_Vanguard_Funds()
        {
            if (Vanguard_Funds != null)
            {
                return;
            }
            Vanguard_Funds = new Dictionary<string, string>();
            Vanguard_Funds_Error = "";

            try
            {
                string Json = Download(VanguardBase + "products/personal/funds/etf", null);
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                Serializer.MaxJsonLength = int.MaxValue;
                object[] Rows = Json_Get(Serializer.DeserializeObject(Json), "data") as object[];
                if (Rows == null)
                {
                    Vanguard_Funds_Error = "Vanguard's list of ETFs came back empty.";
                    return;
                }
                foreach (object Row in Rows)
                {
                    if (Json_Text(Row, "productType").ToLower() != "etf")
                    {
                        continue;
                    }
                    string TmpCode = Json_Text(Json_Get(Row, "tradingSymbols"), "TICKER").ToUpper();
                    string TmpId = Json_Text(Row, "portId");
                    if (TmpCode != "" && TmpId != "")
                    {
                        Vanguard_Funds[TmpCode] = TmpId;
                    }
                }
            }
            catch (Exception ex)
            {
                Vanguard_Funds_Error = "Could not reach Vanguard : " + ex.Message;
            }
        }

        //The top ten holdings Vanguard publishes for one of its ETFs, asked by the bare ASX code.
        //Returns false with parError blank when the code is simply not a Vanguard fund, so the
        //caller can tell "not ours to ask" from "asked and failed".
        private bool Fetch_Vanguard_Holdings(string parCode, out List<Holding> parHoldings,
                                             out string parAsOf, out string parError)
        {
            parHoldings = new List<Holding>();
            parAsOf = "";
            parError = "";

            Load_Vanguard_Funds();
            string TmpId;
            if (!Vanguard_Funds.TryGetValue(parCode.ToUpper(), out TmpId))
            {
                //a list that could not be read is a failure worth naming; a code missing from a
                //list that was read just means some other issuer runs the fund
                parError = Vanguard_Funds_Error;
                return false;
            }

            try
            {
                string Json = Download(VanguardBase + "data/products/holdings/" + Uri.EscapeDataString(TmpId)
                                       + "?limit=" + TopCount.ToString(), null);
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                Serializer.MaxJsonLength = int.MaxValue;
                object[] Rows = Json_Get(Json_Get(Serializer.DeserializeObject(Json), "data"), "items") as object[];
                if (Rows != null)
                {
                    foreach (object Row in Rows)
                    {
                        Holding TmpHolding = new Holding();
                        string TmpTicker = Json_Text(Row, "ticker").ToUpper();
                        string TmpCountry = Json_Text(Row, "countryCode").ToUpper();
                        TmpHolding.Name = Json_Text(Row, "longName");
                        if (TmpHolding.Name == "")
                        {
                            TmpHolding.Name = Json_Text(Row, "name");
                        }
                        //already a percentage - 0.58 for 0.58 %
                        TmpHolding.Weight = Json_Number(Json_Get(Row, "marketValPercent"));

                        //Vanguard gives the bare exchange code.  An ASX or US one is written the
                        //way Yahoo writes it, so it meets the same company from a Yahoo fund by
                        //symbol; anything else names no exchange, and is matched by name alone.
                        if (TmpTicker != "" && TmpCountry == "AU")
                        {
                            TmpHolding.Symbol = TmpTicker + ".AX";
                        }
                        else if (TmpTicker != "" && TmpCountry == "US")
                        {
                            TmpHolding.Symbol = TmpTicker;
                        }
                        else
                        {
                            TmpHolding.Symbol = TmpTicker;
                            TmpHolding.NameOnly = true;
                        }

                        if (parAsOf == "")
                        {
                            DateTime TmpDate;
                            if (DateTime.TryParseExact(Json_Text(Row, "effectiveDate"), "yyyy-MM-dd",
                                                       CultureInfo.InvariantCulture, DateTimeStyles.None, out TmpDate))
                            {
                                parAsOf = TmpDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            }
                        }

                        if ((TmpHolding.Symbol != "" || TmpHolding.Name != "") && TmpHolding.Weight > 0)
                        {
                            parHoldings.Add(TmpHolding);
                        }
                    }
                }

                if (parHoldings.Count == 0)
                {
                    parError = "Vanguard lists no holdings for " + parCode + " either.";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                parError = "Could not reach Vanguard : " + ex.Message;
                return false;
            }
        }

        //---- one row per company ---------------------------------------------------

        //A name boiled down far enough that two sources' spellings of one company meet:
        //"Texas Instruments Inc" and "TEXAS INSTRUMENTS INC." both become TEXAS INSTRUMENTS.
        //Only the legal form is dropped - "Alphabet Inc Class A" and "Class C" stay apart.
        static readonly string[] LegalForms = new string[] { "INC", "INCORPORATED", "CORP", "CORPORATION",
            "CO", "COMPANY", "LTD", "LIMITED", "PLC", "AG", "SA", "NV", "SE", "ASA", "AB", "SPA", "LLC" };

        private string Name_Key(string parName)
        {
            StringBuilder Clean = new StringBuilder();
            foreach (char c in (parName ?? "").ToUpper())
            {
                Clean.Append(char.IsLetterOrDigit(c) ? c : ' ');
            }
            List<string> Words = Clean.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            while (Words.Count > 1 && LegalForms.Contains(Words[Words.Count - 1]))
            {
                Words.RemoveAt(Words.Count - 1);
            }
            return String.Join(" ", Words.ToArray());
        }

        private Company Find_Company(Holding parHolding, Dictionary<string, Company> parBySymbol,
                                     Dictionary<string, Company> parByName)
        {
            Company Found;
            if (!parHolding.NameOnly && parHolding.Symbol != ""
                && parBySymbol.TryGetValue(parHolding.Symbol.ToUpper(), out Found))
            {
                return Found;
            }
            string TmpName = Name_Key(parHolding.Name);
            if (TmpName != "" && parByName.TryGetValue(TmpName, out Found))
            {
                return Found;
            }
            return null;
        }

        //Both ways in are written down, so a later source can arrive by either
        private void Remember_Company(Company parCompany, Holding parHolding,
                                      Dictionary<string, Company> parBySymbol, Dictionary<string, Company> parByName)
        {
            if (!parHolding.NameOnly && parHolding.Symbol != "" && !parBySymbol.ContainsKey(parHolding.Symbol.ToUpper()))
            {
                parBySymbol[parHolding.Symbol.ToUpper()] = parCompany;
                //a symbol that pins the exchange is the better one to show
                parCompany.Symbol = parHolding.Symbol;
            }
            string TmpName = Name_Key(parHolding.Name);
            if (TmpName != "" && !parByName.ContainsKey(TmpName))
            {
                parByName[TmpName] = parCompany;
            }
            if (parCompany.Name == "")
            {
                parCompany.Name = parHolding.Name;
            }
        }

    }
}
