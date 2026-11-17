using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinancialBalance
{
    //What an investment plan actually ends up owning once each fund is looked through.  Every
    //ticker in the plan is asked of Yahoo Finance: a fund answers with its own top holdings and
    //each one's weight in it, and a share answers as a share.  A company's allocation in the
    //plan is then
    //
    //    plan allocation of the ticker x the company's weight in that ticker
    //
    //added up across every ticker that holds it - BHP through both VAS and A200 is one row.
    //A share in the plan is the company itself, at the ticker's whole allocation.
    //
    //Read-only: nothing on this page writes to the database.
    public partial class ETF_Stocks_Investment_Plan_Top_Holdings : Form
    {
        bool Filling;

        const int TopCount = 10;

        private class Company
        {
            public string Symbol;
            public string Name;
            public double Allocation;
            public List<string> Via = new List<string>();   //"VAS.AX 11.19 %", one per ticker
        }

        private class Holding
        {
            public string Symbol;
            public string Name;
            public double Weight;   //a percentage of the fund, 11.19 for 11.19 %
        }

        public ETF_Stocks_Investment_Plan_Top_Holdings()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Investment_Plan_Top_Holdings_Load(object sender, EventArgs e)
        {
            Filling = true;
            Clear_Alloc_Grid();
            Clear_Top_Grid();
            Fill_Plan();
            Filling = false;

            Get_Data();
        }

        //---- helpers ---------------------------------------------------------------

        private double Read_Double(object parValue)
        {
            double TmpValue;
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            if (double.TryParse(parValue.ToString(), out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        private string Read_Text(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return "";
            }
            return parValue.ToString().Trim();
        }

        //An allocation is a percentage, so it is shown with the sign after it
        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00") + " %";
        }

        private string Quote(string parValue)
        {
            if (parValue == null)
            {
                return "";
            }
            return parValue.Replace("'", "''");
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr parHwnd, out int parProcessId);

        //---- the plan --------------------------------------------------------------

        private void Fill_Plan()
        {
            CmbPlan.Items.Clear();
            Mdl1.Ssql = "select [Name] from TblETFStocksInvestmentPlan order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbPlan.Items.Add(Read_Text(reader["Name"]));
            }
            reader.Close();
            if (CmbPlan.Items.Count > 0)
            {
                CmbPlan.SelectedIndex = 0;
            }
        }

        private void CmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        //The plan's allocations, read once and used by the table and by the look-through
        private List<KeyValuePair<string, double>> Read_Plan_Allocations(string parPlan)
        {
            List<KeyValuePair<string, double>> Rows = new List<KeyValuePair<string, double>>();
            if (parPlan == "")
            {
                return Rows;
            }
            Mdl1.Ssql = "select [Full_Ticker], [Allocation] from TblETFStocksInvestmentPlanAllocation"
                      + " where [Investment_Plan_Name] = '" + Quote(parPlan) + "'"
                      + " order by [Full_Ticker]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Rows.Add(new KeyValuePair<string, double>(
                    Read_Text(reader["Full_Ticker"]), Read_Double(reader["Allocation"])));
            }
            reader.Close();
            return Rows;
        }

        //---- the allocation table --------------------------------------------------

        private void Clear_Alloc_Grid()
        {
            gvAlloc.Rows.Clear();
            gvAlloc.Columns.Clear();
            gvAlloc.ColumnCount = 2;
            string[] names = new string[] { "Full Ticker", "Allocation" };
            int[] weights = new int[] { 60, 40 };
            for (int i = 0; i < 2; i++)
            {
                gvAlloc.Columns[i].Name = names[i];
                gvAlloc.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign =
                    (i == 0 ? DataGridViewContentAlignment.MiddleLeft : DataGridViewContentAlignment.MiddleRight);
                gvAlloc.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvAlloc.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Alloc_Grid();
                double TmpTotal = 0;

                foreach (KeyValuePair<string, double> Alloc in Read_Plan_Allocations(CmbPlan.Text.Trim()))
                {
                    TmpTotal = TmpTotal + Alloc.Value;
                    gvAlloc.Rows.Add(new string[] { Alloc.Key, Percent(Alloc.Value) });
                }

                gvAlloc.ClearSelection();
                Filling = false;

                TmpTotal = Math.Round(TmpTotal, 2);
                if (CmbPlan.Items.Count == 0)
                {
                    LblNote.Text = "No investment plans set up yet - add one in ETF/Stock Investment Plan Setup.";
                }
                else if (gvAlloc.Rows.Count == 0)
                {
                    LblNote.Text = "This investment plan has no allocations yet.";
                }
                else
                {
                    LblNote.Text = gvAlloc.Rows.Count.ToString() + " allocation(s), totalling "
                                 + Percent(TmpTotal);
                }

                //the holdings were looked up for whichever plan was showing then, so they go
                //rather than sit beside a plan they do not belong to
                Clear_Top_Grid();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the top holdings table ------------------------------------------------

        private void Clear_Top_Grid()
        {
            gvTop.Rows.Clear();
            gvTop.Columns.Clear();
            gvTop.ColumnCount = 5;
            string[] names = new string[] { "Rank", "Symbol", "Company", "Allocation", "Held Through" };
            int[] weights = new int[] { 8, 14, 30, 13, 55 };
            for (int i = 0; i < 5; i++)
            {
                gvTop.Columns[i].Name = names[i];
                gvTop.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                if (i == 0)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (i == 3)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleRight;
                }
                gvTop.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvTop.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
            LblTopNote.Text = "Click Get Top 10 Holding to look up the companies this plan holds, through"
                            + " each fund, on Yahoo Finance.";
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

        //Read for every ticker in the plan before anything goes out, so no reader is open on
        //the shared connection while the network is being waited on.  A plan ticker missing
        //from ETF/Stock Setup simply gets an empty row and is looked up as itself.
        private Dictionary<string, Setup_Row> Read_Setup(List<KeyValuePair<string, double>> parAllocs)
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

            foreach (KeyValuePair<string, double> Alloc in parAllocs)
            {
                if (!Result.ContainsKey(Alloc.Key.ToUpper()))
                {
                    Result[Alloc.Key.ToUpper()] = new Setup_Row();
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

        private void Busy(bool parBusy)
        {
            System.Windows.Forms.Cursor.Current = (parBusy ? Cursors.WaitCursor : Cursors.Default);
            CmdTop.Enabled = !parBusy;
            CmdExcel.Enabled = !parBusy;
            CmdBack.Enabled = !parBusy;
            CmbPlan.Enabled = !parBusy;
        }

        private void CmdTop_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, double>> Allocs = Read_Plan_Allocations(CmbPlan.Text.Trim());
            if (Allocs.Count == 0)
            {
                MessageBox.Show("This investment plan has no allocations to look through.", "Error Message");
                return;
            }

            Clear_Top_Grid();
            Busy(true);
            LblTopNote.Text = "Asking Yahoo Finance ...";
            LblTopNote.Refresh();

            try
            {
                Dictionary<string, Setup_Row> Setup = Read_Setup(Allocs);

                CookieContainer Jar = new CookieContainer();
                string TmpError;
                string Crumb = Get_Yahoo_Crumb(Jar, out TmpError);
                if (Crumb == "")
                {
                    LblTopNote.Text = TmpError;
                    MessageBox.Show(TmpError, "Error Message");
                    return;
                }

                //Keyed by symbol, so one company held through several funds is one row.  A
                //holding Yahoo gives no symbol for falls back on its name.
                Dictionary<string, Company> ByKey = new Dictionary<string, Company>();
                List<string> Failed = new List<string>();
                int Answered = 0;
                int Through = 0;

                foreach (KeyValuePair<string, double> Alloc in Allocs)
                {
                    Setup_Row TmpSetup = Setup[Alloc.Key.ToUpper()];

                    //A look-through ticker set in ETF/Stock Setup stands in for this one: its
                    //holdings are used, at this ticker's allocation.  JPEQ.AX holds JEPQ, and
                    //JEPQ's holdings are what Yahoo can name.
                    bool Via = (TmpSetup.LookThrough != "");
                    string TmpSource = (Via ? TmpSetup.LookThrough : Alloc.Key);

                    LblTopNote.Text = "Asking Yahoo Finance about " + TmpSource + " ...";
                    LblTopNote.Refresh();

                    List<Holding> TmpHoldings;
                    bool IsShare;
                    if (!Fetch_Top_Holdings(TmpSource, Jar, Crumb, out TmpHoldings, out IsShare, out TmpError))
                    {
                        Failed.Add(TmpError + (Via ? " (look-through for " + Alloc.Key + ")" : ""));
                        continue;
                    }

                    //Yahoo's "this is a share" is taken on trust except for an ASX listing it is
                    //asked about directly, where it is known to be wrong for some funds.  A
                    //look-through ticker was chosen by hand, so whatever it is, it was meant.
                    if (IsShare && !Via && TmpSetup.Suffix.ToUpper() == "AX" && TmpSetup.Ticker != ""
                        && Is_ASX_Fund(TmpSetup.Ticker))
                    {
                        Failed.Add("Yahoo Finance lists no holdings for " + Alloc.Key
                                 + " - it reports this fund as a share. Set a Look-Through Ticker in"
                                 + " ETF/Stock Setup if it invests through another fund.");
                        continue;
                    }
                    Answered++;
                    if (Via)
                    {
                        Through++;
                    }

                    foreach (Holding TmpHolding in TmpHoldings)
                    {
                        string TmpKey = (TmpHolding.Symbol != "" ? TmpHolding.Symbol : TmpHolding.Name).ToUpper();
                        Company TmpCompany;
                        if (!ByKey.TryGetValue(TmpKey, out TmpCompany))
                        {
                            TmpCompany = new Company();
                            TmpCompany.Symbol = TmpHolding.Symbol;
                            TmpCompany.Name = TmpHolding.Name;
                            ByKey.Add(TmpKey, TmpCompany);
                        }
                        TmpCompany.Allocation += Alloc.Value * TmpHolding.Weight / 100;
                        TmpCompany.Via.Add(Alloc.Key + (Via ? " via " + TmpSource : "")
                                         + " " + Percent(TmpHolding.Weight));
                    }
                }

                List<Company> Top = ByKey.Values
                                         .OrderByDescending(c => c.Allocation)
                                         .ThenBy(c => c.Symbol)
                                         .Take(TopCount)
                                         .ToList();
                double TopTotal = 0;
                for (int i = 0; i < Top.Count; i++)
                {
                    gvTop.Rows.Add(new string[] {
                        (i + 1).ToString(),
                        Top[i].Symbol,
                        Top[i].Name,
                        Percent(Top[i].Allocation),
                        String.Join(", ", Top[i].Via.ToArray()) });
                    TopTotal += Top[i].Allocation;
                }
                gvTop.ClearSelection();

                //Each fund reports only its own top ten, so a company that sits lower down in
                //some fund is missing that part of its weight - said rather than left implied.
                string TmpNote = "Top " + Top.Count.ToString() + " of " + ByKey.Count.ToString()
                               + " companies, together " + Percent(TopTotal) + " of the plan, from "
                               + Answered.ToString() + " of " + Allocs.Count.ToString()
                               + " ticker(s)"
                               + (Through > 0 ? ", " + Through.ToString() + " of them through a look-through ticker" : "")
                               + ". Each fund counts only the top holdings Yahoo Finance lists for it.";
                if (Failed.Count > 0)
                {
                    TmpNote = TmpNote + "  Not looked through : " + String.Join("  ", Failed.ToArray());
                }
                LblTopNote.Text = TmpNote;
            }
            catch (Exception ex)
            {
                LblTopNote.Text = "";
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                Busy(false);
            }
        }

        //---- the Excel export ------------------------------------------------------

        private string Safe_Name(string parText)
        {
            string s = (parText == null ? "" : parText.Trim());
            if (s == "")
            {
                s = "none";
            }
            char[] bad = Path.GetInvalidFileNameChars();
            for (int i = 0; i < bad.Length; i++)
            {
                s = s.Replace(bad[i].ToString(), "");
            }
            return s;
        }

        private string[] Line(int parCols, string parA, string parB)
        {
            string[] r = new string[parCols];
            for (int i = 0; i < parCols; i++)
            {
                r[i] = "";
            }
            r[0] = parA;
            if (parCols > 1)
            {
                r[1] = parB;
            }
            return r;
        }

        private string[] Line(int parCols, string parA)
        {
            return Line(parCols, parA, "");
        }

        private string[] Line(int parCols)
        {
            return Line(parCols, "", "");
        }

        private string Cell(DataGridView parGrid, int parRow, int parCol)
        {
            object v = parGrid.Rows[parRow].Cells[parCol].Value;
            return (v == null ? "" : v.ToString());
        }

        //One row of a grid as a sheet line, padded out to the sheet's width.  Row -1 is the
        //column headings.
        private string[] Grid_Row(DataGridView parGrid, int parRow, int parCols)
        {
            string[] r = Line(parCols);
            for (int c = 0; c < parGrid.Columns.Count && c < parCols; c++)
            {
                r[c] = (parRow < 0 ? parGrid.Columns[c].Name : Cell(parGrid, parRow, c));
            }
            return r;
        }

        //Both tables go into the one sheet: the top holdings are only meaningful beside the
        //allocations they were worked out from.
        private void CmdExcel_Click(object sender, EventArgs e)
        {
            if (gvTop.Rows.Count == 0)
            {
                MessageBox.Show("Click Get Top 10 Holding first - there is nothing to export yet.", "Error Message");
                return;
            }

            //The form's own Name leads the file name, so an export says which page it came from
            //before anything else. Taken from this.Name rather than typed out, so it cannot
            //drift from the form it belongs to.
            string TmpName = Safe_Name(this.Name)
                           + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                           + "_" + Safe_Name(CmbPlan.Text) + ".xlsx";

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Generate to Excel";
            dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            dlg.FileName = TmpName;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //lay the whole sheet out first, so Excel is only asked to do one write
            int Cols = 5;
            List<string[]> Sheet = new List<string[]>();
            Sheet.Add(Line(Cols, "ETF/Stock Investment Plan Top Holdings"));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Investment Plan", CmbPlan.Text.Trim()));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            if (LblNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Note", LblNote.Text.Trim()));
            }
            if (LblTopNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Basis", LblTopNote.Text.Trim()));
            }
            Sheet.Add(Line(Cols));

            List<int> Heads = new List<int>();
            Heads.Add(Sheet.Count + 1);
            Sheet.Add(Grid_Row(gvAlloc, -1, Cols));
            for (int r = 0; r < gvAlloc.Rows.Count; r++)
            {
                Sheet.Add(Grid_Row(gvAlloc, r, Cols));
            }
            Sheet.Add(Line(Cols));

            Heads.Add(Sheet.Count + 1);
            Sheet.Add(Grid_Row(gvTop, -1, Cols));
            for (int r = 0; r < gvTop.Rows.Count; r++)
            {
                Sheet.Add(Grid_Row(gvTop, r, Cols));
            }

            object[,] Data = new object[Sheet.Count, Cols];
            for (int r = 0; r < Sheet.Count; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Data[r, c] = Sheet[r][c];
                }
            }

            Busy(true);

            Excel.Application app = null;
            Excel.Workbooks books = null;
            Excel.Workbook wb = null;
            Excel.Sheets sheets = null;
            Excel.Worksheet ws = null;
            Excel.Range all = null;
            Excel.Range one = null;
            Excel.Range cols = null;
            int ExcelPid = 0;

            try
            {
                app = new Excel.Application();
                app.Visible = false;
                app.DisplayAlerts = false;
                GetWindowThreadProcessId(new IntPtr(app.Hwnd), out ExcelPid);

                books = app.Workbooks;
                wb = books.Add();
                sheets = wb.Worksheets;
                ws = (Excel.Worksheet)sheets[1];
                ws.Name = "Top Holdings";

                all = ws.Range[ws.Cells[1, 1], ws.Cells[Sheet.Count, Cols]];
                //Written as text on purpose, so "12.34 %" stays what the screen shows rather
                //than being re-read by Excel as a fraction.
                all.NumberFormat = "@";
                all.Value2 = Data;

                one = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                one.Font.Bold = true;
                one.Font.Size = 14;
                Marshal.ReleaseComObject(one);
                one = null;

                foreach (int HeadRow in Heads)
                {
                    one = ws.Range[ws.Cells[HeadRow, 1], ws.Cells[HeadRow, Cols]];
                    one.Font.Bold = true;
                    one.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                    Marshal.ReleaseComObject(one);
                    one = null;
                }

                cols = ws.Columns;
                cols.AutoFit();

                wb.SaveAs(dlg.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook);
                wb.Close(false);
                app.Quit();

                MessageBox.Show("Excel file generated :" + Environment.NewLine + dlg.FileName, "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate the Excel file : " + ex.Message, "Error Message");
            }
            finally
            {
                if (one != null) { Marshal.ReleaseComObject(one); }
                if (cols != null) { Marshal.ReleaseComObject(cols); }
                if (all != null) { Marshal.ReleaseComObject(all); }
                if (ws != null) { Marshal.ReleaseComObject(ws); }
                if (sheets != null) { Marshal.ReleaseComObject(sheets); }
                if (wb != null) { Marshal.ReleaseComObject(wb); }
                if (books != null) { Marshal.ReleaseComObject(books); }
                if (app != null) { Marshal.ReleaseComObject(app); }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Kill_Excel(ExcelPid);
                Busy(false);
            }
        }

        //Quit does not always end the process; this is the backstop so exports cannot pile up
        //invisible copies of Excel.
        private void Kill_Excel(int parPid)
        {
            if (parPid <= 0)
            {
                return;
            }
            try
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessById(parPid);
                if (!proc.HasExited)
                {
                    proc.Kill();
                }
                proc.Dispose();
            }
            catch (Exception)
            {
                //already gone, which is the outcome we wanted anyway
            }
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
