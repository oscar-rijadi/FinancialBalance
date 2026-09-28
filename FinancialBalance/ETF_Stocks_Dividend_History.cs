using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinancialBalance
{
    public partial class ETF_Stocks_Dividend_History : Form
    {
        bool Filling;

        //The Portfolio dropdown shows descriptions but filters on codes, so the codes are kept
        //in a list running parallel to the items - two portfolios sharing a description still
        //filter correctly.  A null entry is the "All" row.
        List<string> PortfolioCodes = new List<string>();

        public ETF_Stocks_Dividend_History()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Dividend_History_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Portfolio();
            Fill_Ticker();
            Fill_Financial_Year();
            Filling = false;

            Get_Data();
        }

        //Main Only narrows the list itself, so a non-main portfolio cannot be chosen while it
        //is ticked - otherwise the page would show an empty table with no explanation.
        private void Fill_Portfolio()
        {
            CmbPortfolio.Items.Clear();
            PortfolioCodes.Clear();

            CmbPortfolio.Items.Add("All");
            PortfolioCodes.Add(null);

            Mdl1.Ssql = "select Portfolio_Code, [Description] from TblETFStocksPortfolioCode"
                      + (chkMainOnly.Checked ? " where [Is_Main] = True" : "")
                      + " order by Portfolio_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = reader["Portfolio_Code"].ToString().Trim();
                string TmpDesc = reader["Description"].ToString().Trim();
                if (TmpDesc == "")
                {
                    TmpDesc = TmpCode;
                }
                CmbPortfolio.Items.Add(TmpDesc);
                PortfolioCodes.Add(TmpCode);
            }
            reader.Close();

            CmbPortfolio.Text = "All";
        }

        private void Fill_Ticker()
        {
            CmbTicker.Items.Clear();
            CmbTicker.Items.Add("All");

            Mdl1.Ssql = "select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbTicker.Items.Add(reader["Full_Ticker"].ToString().Trim());
            }
            reader.Close();

            CmbTicker.Text = "All";
        }

        //Most recently closed year first, which is the one usually being looked at
        private void Fill_Financial_Year()
        {
            CmbFinYear.Items.Clear();
            CmbFinYear.Items.Add("All");

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFinYear.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            CmbFinYear.Text = "All";
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void CmbTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void CmbFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void chkMainOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //the portfolio list itself changes, so rebuild it from the top
            Filling = true;
            Fill_Portfolio();
            Filling = false;
            Get_Data();
        }

        //---- filters -------------------------------------------------------------

        private string Selected_Portfolio_Code()
        {
            int idx = CmbPortfolio.SelectedIndex;
            if (idx < 0 || idx >= PortfolioCodes.Count)
            {
                return null;
            }
            return PortfolioCodes[idx];
        }

        private string Portfolio_Filter()
        {
            string TmpCode = Selected_Portfolio_Code();
            if (TmpCode != null)
            {
                return " and [Portfolio_Code] = '" + TmpCode + "'";
            }
            //"All" still respects Main Only, and a payment carrying no code at all belongs to
            //no main portfolio, so it drops out with the rest.
            if (chkMainOnly.Checked)
            {
                return " and [Portfolio_Code] In (select Portfolio_Code from TblETFStocksPortfolioCode where [Is_Main] = True)";
            }
            return "";
        }

        //The chosen year's two dates bracket Pay_Date.  Both are stored yyyyMMdd, so a plain
        //string comparison is the same as a date comparison.
        private bool Financial_Year_Range(out string parStart, out string parEnd)
        {
            parStart = "";
            parEnd = "";

            string TmpName = CmbFinYear.Text.Trim();
            if (TmpName == "" || TmpName == "All")
            {
                return false;
            }

            Mdl1.Ssql = "select [Start_Date], [End_Date] from TblFinancialYear where [Name] = '" + TmpName + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = false;
            if (reader.Read())
            {
                parStart = Read_Text(reader["Start_Date"]);
                parEnd = Read_Text(reader["End_Date"]);
                Found = (parStart != "" && parEnd != "");
            }
            reader.Close();
            return Found;
        }

        private string Year_Filter()
        {
            string TmpStart;
            string TmpEnd;
            if (!Financial_Year_Range(out TmpStart, out TmpEnd))
            {
                return "";
            }
            return " and Pay_Date >= '" + TmpStart + "' and Pay_Date <= '" + TmpEnd + "'";
        }

        private string Ticker_Filter()
        {
            string TmpTicker = CmbTicker.Text.Trim();
            if (TmpTicker == "" || TmpTicker == "All")
            {
                return "";
            }
            return " and Full_Ticker = '" + TmpTicker + "'";
        }

        private string Where_Clause()
        {
            return " where 1 = 1" + Portfolio_Filter() + Year_Filter() + Ticker_Filter();
        }

        //---- what has been put in -------------------------------------------------

        //Everything is measured as at one date: today when no financial year is chosen, and
        //otherwise the day the chosen year closes.
        private string Cutoff_Date()
        {
            string TmpStart;
            string TmpEnd;
            if (Financial_Year_Range(out TmpStart, out TmpEnd))
            {
                return TmpEnd;
            }
            return DateTime.Now.ToString("yyyyMMdd");
        }

        //One money column added up to the cut-off.  The currency comes back too, but only when
        //every contributing row agrees on it - Min and Max matching is the cheapest way to ask
        //that without a second trip to the database.
        //Grouped by currency and converted a group at a time, rather than summed across them.
        //Adding USD to AUD first would give a figure that is in neither - which is exactly what
        //this page used to do, and then decline to put a dollar sign on rather than fix.
        private double Sum_Money(string parTable, string parField, string parTickerClause,
                                 string parCodeClause, string parCutoff)
        {
            List<double> Amounts = new List<double>();
            List<string> Currs = new List<string>();

            Mdl1.Ssql = "select [Currency] as C, Sum(" + parField + ") as N"
                      + " from " + parTable
                      + " where 1 = 1" + parTickerClause + parCodeClause
                      + " and Trans_Date <= '" + parCutoff + "'"
                      + " group by [Currency]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Amounts.Add(Read_Double(reader["N"]));
                Currs.Add(Read_Text(reader["C"]));
            }
            reader.Close();

            double Result = 0;
            for (int i = 0; i < Amounts.Count; i++)
            {
                Result += To_AUD(Amounts[i], Currs[i]);
            }
            return Result;
        }

        //Money actually put in and not yet taken back out: what was really paid, less what
        //selling returned.  Real_Total_Cost_Base is 0 on a reinvested purchase, so units that
        //arrived as a DRIP add no cost - which is the point of using that field rather than
        //Total_Cost_Base.  Proceeds can exceed cost, so this can legitimately go negative.
        private double Net_Cost(string parTickerClause, string parCodeClause, string parCutoff)
        {
            double Bought = Sum_Money("TblETFStocksPurchase", "[Real_Total_Cost_Base]",
                                      parTickerClause, parCodeClause, parCutoff);
            double Sold = Sum_Money("TblETFStocksSale", "[Selling_Total_Amount]",
                                    parTickerClause, parCodeClause, parCutoff);

            //both sides are in AUD by now, so the two can simply be taken away from each other
            return Math.Round(Bought - Sold, 2);
        }

        //---- formatting ----------------------------------------------------------

        //Every figure on this page is in AUD, whatever currency it was recorded in, so every
        //figure takes the sign. A negative reads -$12.34 rather than $-12.34.
        private string Money(double parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        //---- into Australian Dollar -------------------------------------------------
        //
        //The same conversion [ETF/Stock Portfolio Summary] makes, for the same reasons.
        //TblCurrRate holds IDR per one unit, so a figure reaches AUD by way of the rupiah:
        //
        //    AUD = amount x rate(currency) / rate(AUD)
        //
        //One month's rate is used for every figure on the page - today's - rather than the rate
        //of the day each payment landed. A yield is a ratio of two figures that have to be in
        //the same currency to divide, and converting each at its own historical rate would make
        //a yield that is partly a currency movement. The cost is the same as on the summary
        //page: what the exchange rate did since is not in these numbers.
        private const string PageCurr = "AUD";

        private Dictionary<string, double> RateCache = new Dictionary<string, double>();
        private Dictionary<string, bool> RateKnown = new Dictionary<string, bool>();
        private List<string> NoRate = new List<string>();
        private string RateMonth = "";

        //Every rate a refresh could want, read before a single row of data is. The page converts
        //inside its read loops, and opening a second reader on the shared connection while the
        //first is still live is the one thing this connection will not stand.
        private void Begin_Rates()
        {
            RateCache.Clear();
            RateKnown.Clear();
            NoRate.Clear();
            RateMonth = DateTime.Now.ToString("yyyyMM");

            List<string> Codes = new List<string>();
            Codes.Add(PageCurr);
            Mdl1.Ssql = "select Curr_Code from TblCurrCode order by Curr_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = Read_Text(reader["Curr_Code"]).ToUpper();
                if (TmpCode != "" && !Codes.Contains(TmpCode))
                {
                    Codes.Add(TmpCode);
                }
            }
            reader.Close();

            for (int i = 0; i < Codes.Count; i++)
            {
                Load_Rate(Codes[i]);
            }
        }

        //One currency's rate, and whether TblCurrRate holds anything for it at all. GetCurrRate
        //answers 1 for a currency it has never heard of, which would leave a figure unconverted
        //while looking exactly like one that needed no converting; asking the table directly is
        //what tells those two apart. Whether it is *said* waits until a figure actually needs it,
        //so a currency set up but never used raises nothing.
        private void Load_Rate(string parCurr)
        {
            if (RateCache.ContainsKey(parCurr))
            {
                return;
            }
            if (parCurr == "IDR")
            {
                //the pivot itself - one rupiah to the rupiah, and never a row to read
                RateCache[parCurr] = 1;
                RateKnown[parCurr] = true;
                return;
            }

            bool Known = Has_Rate(parCurr);
            double TmpRate = (Known ? Mdl1.GetCurrRate(parCurr, RateMonth) : 1);
            RateCache[parCurr] = (TmpRate <= 0 ? 1 : TmpRate);
            RateKnown[parCurr] = Known;
        }

        private bool Has_Rate(string parCurr)
        {
            bool Found = false;
            Mdl1.Ssql = "select top 1 Curr_Date from TblCurrRate where Curr_Code = '" + parCurr + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Found = reader.Read();
            reader.Close();
            return Found;
        }

        //Nothing here reads the database: it is called from inside the read loops, and every
        //rate it can answer with was loaded before those loops opened.
        private double Rate_Of(string parCurr)
        {
            string strCurr = (parCurr == null ? "" : parCurr.Trim().ToUpper());
            if (strCurr == "")
            {
                strCurr = PageCurr;
            }

            if (RateCache.ContainsKey(strCurr))
            {
                if (!RateKnown[strCurr] && !NoRate.Contains(strCurr))
                {
                    NoRate.Add(strCurr);
                }
                return RateCache[strCurr];
            }

            //a currency on a row but not in Currency Setup, so there can be no rate for it either
            if (!NoRate.Contains(strCurr))
            {
                NoRate.Add(strCurr);
            }
            return 1;
        }

        private double To_AUD(double parAmount, string parCurr)
        {
            string strCurr = (parCurr == null ? "" : parCurr.Trim().ToUpper());
            //nothing said is taken as already being in AUD
            if (strCurr == "" || strCurr == PageCurr)
            {
                return parAmount;
            }
            return parAmount * Rate_Of(strCurr) / Rate_Of(PageCurr);
        }

        private string Rate_Note()
        {
            if (NoRate.Count == 0)
            {
                return "";
            }
            return "   -   no currency rate on record for "
                 + String.Join(", ", NoRate.ToArray())
                 + ", shown unconverted";
        }

        private void Show_Page_Currency()
        {
            LblCurrency.Text = "All amounts are in Australian Dollar (" + PageCurr + "), at "
                             + DateTime.Now.ToString("MMM yyyy", new CultureInfo("en-AU")) + " rates";
        }

        private string Format_Date(string parYyyyMMdd)
        {
            DateTime TmpDate;
            if (parYyyyMMdd != null && DateTime.TryParseExact(parYyyyMMdd.Trim(), "yyyyMMdd",
                    new CultureInfo("en-AU"), DateTimeStyles.None, out TmpDate))
            {
                return TmpDate.ToString("dd-MMM-yyyy", new CultureInfo("en-AU"));
            }
            return (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
        }

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

        //---- grids ---------------------------------------------------------------

        private void Build_Grid(DataGridView parGrid, string[] parNames, int[] parWeights, int parFirstMoneyCol)
        {
            parGrid.Rows.Clear();
            parGrid.Columns.Clear();
            parGrid.ColumnCount = parNames.Length;
            for (int i = 0; i < parNames.Length; i++)
            {
                parGrid.Columns[i].Name = parNames[i];
                parGrid.Columns[i].FillWeight = parWeights[i];
                DataGridViewContentAlignment TmpAlign;
                if (i >= parFirstMoneyCol)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleRight;
                }
                else if (i == 0)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                parGrid.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                parGrid.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Clear_Summary_Grid()
        {
            Build_Grid(gvSummary,
                new string[] { "Full Ticker", "Portfolio Code", "Currency", "Investment", "Total", "Yield", "Total Reinvested", "Total Not Reinvested" },
                new int[] { 14, 11, 8, 14, 14, 10, 14, 15 }, 3);
        }

        private void Clear_Detail_Grid()
        {
            Build_Grid(gvDetail,
                new string[] { "Pay Date", "Portfolio Code", "Currency", "Amount", "Amount Reinvested", "Amount Not Reinvested" },
                new int[] { 18, 14, 10, 19, 19, 20 }, 3);
        }

        private void Get_Data()
        {
            try
            {
                Begin_Rates();

                bool AllTickers = (CmbTicker.Text.Trim() == "" || CmbTicker.Text.Trim() == "All");

                gvSummary.Visible = AllTickers;
                gvDetail.Visible = !AllTickers;

                if (AllTickers)
                {
                    Get_Summary();
                }
                else
                {
                    Get_Detail();
                }

                Show_Note();
                Show_Page_Currency();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //One row per portfolio and ticker that has ever been bought.  The purchases decide what
        //is listed, not the payments: a holding that has paid nothing still belongs on the page,
        //showing what is tied up in it against a nil return.  Grouping is by portfolio and
        //ticker alone - the currency is the one the holding was bought in, read from the
        //purchases rather than grouped on, so a payment recorded against the wrong currency
        //cannot split one holding into two rows.
        private class Holding
        {
            public string Ticker;
            public string Code;
            public string Currency;     //the earliest purchase's, which is what the money is in
            public double Bought;       //Real_Total_Cost_Base, so DRIP units add no cost
            public double Sold;         //Selling_Total_Amount
            public double PaidAll;
            public double PaidYes;
            public double PaidNo;

            //What is still tied up: what was really paid, less what selling has already
            //returned.  Proceeds can exceed cost, so this can legitimately go negative.
            public double Investment
            {
                get { return Math.Round(Bought - Sold, 2); }
            }
        }

        //Portfolio_Code can be empty, and an empty code is a group of its own rather than a
        //missing one, so the two parts are joined on a character no code can contain.
        private string Holding_Key(string parCode, string parTicker)
        {
            return parCode + "\u0001" + parTicker;
        }

        //Everything is counted up to the close of the chosen financial year rather than within
        //it, so each figure reads as where that holding stood on that date.  "All" means no
        //cut-off at all - every row ever recorded.
        private string Upto_Filter(string parField)
        {
            string TmpStart;
            string TmpEnd;
            if (!Financial_Year_Range(out TmpStart, out TmpEnd))
            {
                return "";
            }
            return " and " + parField + " <= '" + TmpEnd + "'";
        }

        //The rows themselves, and what was paid for them.  Read row by row rather than grouped
        //so the currency can be the earliest purchase's - Access's First() follows storage
        //order, which is not the same thing.
        private List<Holding> Load_Holdings()
        {
            Dictionary<string, Holding> TmpIndex = new Dictionary<string, Holding>();
            List<Holding> TmpOrder = new List<Holding>();

            Mdl1.Ssql = "select [Portfolio_Code], Full_Ticker, [Currency], [Real_Total_Cost_Base]"
                      + " from TblETFStocksPurchase"
                      + " where 1 = 1" + Portfolio_Filter() + Ticker_Filter() + Upto_Filter("Trans_Date")
                      + " order by Full_Ticker, [Portfolio_Code], Trans_Date";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = Read_Text(reader["Portfolio_Code"]);
                string TmpTicker = Read_Text(reader["Full_Ticker"]);
                string TmpKey = Holding_Key(TmpCode, TmpTicker);

                Holding TmpHolding;
                if (!TmpIndex.TryGetValue(TmpKey, out TmpHolding))
                {
                    TmpHolding = new Holding();
                    TmpHolding.Ticker = TmpTicker;
                    TmpHolding.Code = TmpCode;
                    //first row of the group, and the read is ordered by date within it, so this
                    //is the currency the holding was opened in
                    TmpHolding.Currency = Read_Text(reader["Currency"]);
                    TmpIndex.Add(TmpKey, TmpHolding);
                    TmpOrder.Add(TmpHolding);
                }
                //out of the currency this lot was bought in, before it joins the group - lots of
                //one holding can differ, and the group carries only the first one's code
                TmpHolding.Bought += To_AUD(Read_Double(reader["Real_Total_Cost_Base"]),
                                            Read_Text(reader["Currency"]));
            }
            reader.Close();

            Add_Sales(TmpIndex);
            Add_Payments(TmpIndex);
            return TmpOrder;
        }

        //What selling has returned, across the same selection.  A sale whose purchase is not in
        //the selection has nothing to sit against, and is passed over rather than made a row of
        //its own - there would be no cost, and the yield would read as though it were free.
        private void Add_Sales(Dictionary<string, Holding> parIndex)
        {
            //grouped by currency as well, so each group is converted out of what it is actually in
            Mdl1.Ssql = "select [Portfolio_Code], Full_Ticker, [Currency], Sum([Selling_Total_Amount]) as N"
                      + " from TblETFStocksSale"
                      + " where 1 = 1" + Portfolio_Filter() + Ticker_Filter() + Upto_Filter("Trans_Date")
                      + " group by [Portfolio_Code], Full_Ticker, [Currency]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Holding TmpHolding;
                if (Find_Holding(parIndex, reader, out TmpHolding))
                {
                    TmpHolding.Sold += To_AUD(Read_Double(reader["N"]), Read_Text(reader["Currency"]));
                }
            }
            reader.Close();
        }

        //What each holding has paid, split by whether it was taken as cash or put straight back
        //in.  A payment against a ticker never bought in this selection is passed over for the
        //same reason a stray sale is.
        private void Add_Payments(Dictionary<string, Holding> parIndex)
        {
            //grouped by currency as well, so each group is converted out of what it is actually in
            Mdl1.Ssql = "select [Portfolio_Code], Full_Ticker, [Currency],"
                      + " Sum([Total_Amount]) as TotAll,"
                      + " Sum(IIf([Is_Reinvested] = True, [Total_Amount], 0)) as TotYes,"
                      + " Sum(IIf([Is_Reinvested] = True, 0, [Total_Amount])) as TotNo"
                      + " from TblETFStocksDistributionDividend"
                      + " where 1 = 1" + Portfolio_Filter() + Ticker_Filter() + Upto_Filter("Pay_Date")
                      + " group by [Portfolio_Code], Full_Ticker, [Currency]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Holding TmpHolding;
                if (Find_Holding(parIndex, reader, out TmpHolding))
                {
                    string TmpCurr = Read_Text(reader["Currency"]);
                    TmpHolding.PaidAll += To_AUD(Read_Double(reader["TotAll"]), TmpCurr);
                    TmpHolding.PaidYes += To_AUD(Read_Double(reader["TotYes"]), TmpCurr);
                    TmpHolding.PaidNo += To_AUD(Read_Double(reader["TotNo"]), TmpCurr);
                }
            }
            reader.Close();
        }

        //The portfolio and ticker on the row in hand, looked up among the holdings the
        //purchases produced.
        private bool Find_Holding(Dictionary<string, Holding> parIndex, OleDbDataReader parReader,
                                     out Holding parHolding)
        {
            string TmpKey = Holding_Key(Read_Text(parReader["Portfolio_Code"]),
                                        Read_Text(parReader["Full_Ticker"]));
            return parIndex.TryGetValue(TmpKey, out parHolding);
        }

        //What the payments came to against what is tied up in the holding.  Nothing invested
        //gives no denominator, and the yield is reported as zero rather than left undefined.
        private double Yield_Of(double parInvestment, double parPaid)
        {
            if (parInvestment > 0)
            {
                return parPaid / parInvestment * 100;
            }
            return 0;
        }

        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00") + " %";
        }

        private void Get_Summary()
        {
            Clear_Summary_Grid();

            List<Holding> TmpHoldings = Load_Holdings();

            double GrandInv = 0;
            double GrandAll = 0;
            double GrandYes = 0;
            double GrandNo = 0;

            foreach (Holding TmpHolding in TmpHoldings)
            {
                double TmpInvestment = TmpHolding.Investment;

                //the Currency column still says what the holding was opened in - what the figures
                //beside it were converted out of, rather than what they are in
                gvSummary.Rows.Add(new string[] {
                    TmpHolding.Ticker,
                    TmpHolding.Code,
                    (TmpHolding.Currency == "" ? "-" : TmpHolding.Currency),
                    Money(TmpInvestment),
                    Money(TmpHolding.PaidAll),
                    Percent(Yield_Of(TmpInvestment, TmpHolding.PaidAll)),
                    Money(TmpHolding.PaidYes),
                    Money(TmpHolding.PaidNo) });

                GrandInv += TmpInvestment;
                GrandAll += TmpHolding.PaidAll;
                GrandYes += TmpHolding.PaidYes;
                GrandNo += TmpHolding.PaidNo;
            }

            Show_Summary_Totals(GrandInv, GrandAll, GrandYes, GrandNo);

            gvSummary.ClearSelection();
        }

        //Every payment for the chosen ticker.  A payment is either reinvested or it is not, so
        //its amount lands in one of the two columns and the other reads zero.
        private void Get_Detail()
        {
            Clear_Detail_Grid();

            Mdl1.Ssql = "select Pay_Date, [Portfolio_Code], [Currency], [Total_Amount], [Is_Reinvested]"
                      + " from TblETFStocksDistributionDividend"
                      + Where_Clause()
                      + " order by Pay_Date Desc, [Portfolio_Code]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            double GrandAll = 0;
            double GrandYes = 0;
            double GrandNo = 0;
            while (reader.Read())
            {
                string TmpCurr = Read_Text(reader["Currency"]);
                //out of the currency the payment was recorded in, before it is shown or added up
                double TmpAmount = To_AUD(Read_Double(reader["Total_Amount"]), TmpCurr);
                bool TmpReinvested = (Read_Text(reader["Is_Reinvested"]) == "True");

                gvDetail.Rows.Add(new string[] {
                    Format_Date(Read_Text(reader["Pay_Date"])),
                    Read_Text(reader["Portfolio_Code"]),
                    (TmpCurr == "" ? "-" : TmpCurr),
                    Money(TmpAmount),
                    Money(TmpReinvested ? TmpAmount : 0),
                    Money(TmpReinvested ? 0 : TmpAmount) });

                GrandAll += TmpAmount;
                if (TmpReinvested)
                {
                    GrandYes += TmpAmount;
                }
                else
                {
                    GrandNo += TmpAmount;
                }
            }
            reader.Close();

            Show_Detail_Totals(GrandAll, GrandYes, GrandNo);

            gvDetail.ClearSelection();
        }

        //The figures under whichever table is showing.  There are five fixed slots, filled
        //from the top, so both views sit flush without gaps and the two sets can never appear
        //at once.  A slot given a null caption is put away, which keeps the helper usable if
        //a view ever needs fewer than five.
        //
        //Every figure in them is in AUD by the time it gets here, so every one takes the sign.
        private void Set_Slot(int parSlot, string parCaption, string parValue)
        {
            Label[] Caps = new Label[] { LblAgg1Cap, LblAgg2Cap, LblAgg3Cap, LblAgg4Cap, LblAgg5Cap };
            Label[] Vals = new Label[] { LblAgg1, LblAgg2, LblAgg3, LblAgg4, LblAgg5 };

            bool Used = (parCaption != null);
            Caps[parSlot].Visible = Used;
            Vals[parSlot].Visible = Used;
            if (Used)
            {
                Caps[parSlot].Text = parCaption;
                Vals[parSlot].Text = parValue;
            }
        }

        //Summary view: the columns above added straight down, so what is under the table and
        //what is in it can never disagree.  The yield comes from the two grand totals rather
        //than from averaging the per-row yields, which would weigh a small holding the same as
        //a large one.
        private void Show_Summary_Totals(double parInvestment, double parAll, double parYes,
                                         double parNo)
        {
            Set_Slot(0, "Grand Total Investment", Money(parInvestment));
            Set_Slot(1, "Grand Total", Money(parAll));
            Set_Slot(2, "Yield", Percent(Yield_Of(parInvestment, parAll)));
            Set_Slot(3, "Grand Total Reinvested", Money(parYes));
            Set_Slot(4, "Grand Total Not Reinvested", Money(parNo));
        }

        //Payment view: the same shape as the summary, but for the one ticker on screen.  The
        //portfolio side still comes from the dropdown and Main Only rather than any single
        //row, so the investment covers every portfolio the selection includes.
        private void Show_Detail_Totals(double parAll, double parYes, double parNo)
        {
            double TmpInvestment = Net_Cost(Ticker_Filter(), Portfolio_Filter(), Cutoff_Date());

            //both sides are AUD now, so the yield is a ratio of two figures in one currency - which
            //is the only way a yield means anything
            double TmpYield = 0;
            if (TmpInvestment > 0)
            {
                TmpYield = parAll / TmpInvestment * 100;
            }

            Set_Slot(0, "Total Investment", Money(TmpInvestment));
            Set_Slot(1, "Total Amount", Money(parAll));
            Set_Slot(2, "Yield", TmpYield.ToString("#,##0.00") + " %");
            Set_Slot(3, "Total Amount Reinvested", Money(parYes));
            Set_Slot(4, "Total Amount Not Reinvested", Money(parNo));
        }

        //Says which filters are narrowing what is on screen, so an empty table is explainable
        private void Show_Note()
        {
            List<string> Parts = new List<string>();

            if (chkMainOnly.Checked)
            {
                Parts.Add("main portfolios only");
            }
            string TmpYear = CmbFinYear.Text.Trim();
            if (TmpYear != "" && TmpYear != "All")
            {
                string TmpStart;
                string TmpEnd;
                if (Financial_Year_Range(out TmpStart, out TmpEnd))
                {
                    //the table counts everything up to the year closing, the payment list only
                    //what falls inside it, so the note has to say which of the two is on screen
                    string TmpWhen = (gvSummary.Visible
                                        ? "as at " + Format_Date(TmpEnd)
                                        : Format_Date(TmpStart) + " to " + Format_Date(TmpEnd));
                    Parts.Add("financial year " + TmpYear + "  (" + TmpWhen + ")");
                }
                else
                {
                    Parts.Add("financial year " + TmpYear + "  (no dates set up, so no date filter applied)");
                }
            }

            int TmpRows = (gvSummary.Visible ? gvSummary.Rows.Count : gvDetail.Rows.Count);
            string TmpText = TmpRows.ToString() + " row(s)";
            if (Parts.Count > 0)
            {
                TmpText = TmpText + "   -   " + String.Join(", ", Parts.ToArray());
            }
            LblNote.Text = TmpText + Rate_Note();
        }

        //---- Excel ---------------------------------------------------------------

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr parHwnd, out int parProcessId);

        //Whichever of the two tables is on screen.  The page swaps them rather than reusing one,
        //so the export has to ask which is showing instead of assuming.
        private DataGridView Active_Grid()
        {
            return (gvSummary.Visible ? gvSummary : gvDetail);
        }

        //The aggregate slots as they stand, skipping any that are put away.  The summary and
        //payment views fill different numbers of slots, so the count is not fixed.
        private void Active_Totals(out List<string> parCaps, out List<string> parVals)
        {
            parCaps = new List<string>();
            parVals = new List<string>();

            Label[] Caps = new Label[] { LblAgg1Cap, LblAgg2Cap, LblAgg3Cap, LblAgg4Cap, LblAgg5Cap };
            Label[] Vals = new Label[] { LblAgg1, LblAgg2, LblAgg3, LblAgg4, LblAgg5 };
            for (int i = 0; i < Caps.Length; i++)
            {
                if (!Caps[i].Visible)
                {
                    continue;
                }
                parCaps.Add(Caps[i].Text);
                parVals.Add(Vals[i].Text);
            }
        }

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

        //The form's own Name leads the file name, so an export says which page it came from
        //before anything else.  Taken from this.Name rather than typed out, so it cannot drift
        //from the form it belongs to.  parExtension carries the dot.
        private string Export_Name(string parExtension)
        {
            return Safe_Name(this.Name)
                 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                 + "_" + Safe_Name(CmbPortfolio.Text)
                 + "_" + (chkMainOnly.Checked ? "Yes" : "No")
                 + "_" + Safe_Name(CmbTicker.Text)
                 + "_" + Safe_Name(CmbFinYear.Text) + parExtension;
        }

        //The whole sheet as a rectangle of strings, laid out before anything is asked to write
        //it.  Both exports go through here, so the workbook and the Google Sheet are the same
        //sheet by construction rather than by two lots of layout code agreeing.
        //
        //parTicker and parYear are what the sheet says it is for.  They are passed in rather
        //than read off the dropdowns so a per-year tab is headed with its own year, whatever
        //the dropdowns say by the time it is written.
        private List<string[]> Build_Sheet(string parTicker, string parYear, out int parCols,
                                           out int parTotalsFrom, out int parTotalsTo,
                                           out int parHeadRow)
        {
            DataGridView grid = Active_Grid();
            List<string> Caps;
            List<string> Vals;
            Active_Totals(out Caps, out Vals);

            int Cols = grid.Columns.Count;
            if (Cols < 2)
            {
                Cols = 2;
            }

            List<string[]> Sheet = new List<string[]>();
            Sheet.Add(Line(Cols, "ETF/Stock Dividend History"));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Portfolio", CmbPortfolio.Text.Trim()));
            Sheet.Add(Line(Cols, "Main Only", (chkMainOnly.Checked ? "Yes" : "No")));
            Sheet.Add(Line(Cols, "Full Ticker", parTicker));
            Sheet.Add(Line(Cols, "Financial Year", parYear));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            if (LblNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Note", LblNote.Text.Trim()));
            }
            Sheet.Add(Line(Cols));

            //the aggregates sit above the table
            parTotalsFrom = Sheet.Count + 1;
            for (int i = 0; i < Caps.Count; i++)
            {
                Sheet.Add(Line(Cols, Caps[i], Vals[i]));
            }
            parTotalsTo = Sheet.Count;
            if (Caps.Count > 0)
            {
                Sheet.Add(Line(Cols));
            }

            parHeadRow = Sheet.Count + 1;
            string[] head = new string[Cols];
            for (int c = 0; c < grid.Columns.Count; c++)
            {
                head[c] = grid.Columns[c].Name;
            }
            Sheet.Add(head);

            for (int r = 0; r < grid.Rows.Count; r++)
            {
                string[] line = new string[Cols];
                for (int c = 0; c < grid.Columns.Count; c++)
                {
                    object v = grid.Rows[r].Cells[c].Value;
                    line[c] = (v == null ? "" : v.ToString());
                }
                Sheet.Add(line);
            }

            parCols = Cols;
            return Sheet;
        }

        //One laid-out sheet and the tab it belongs on.
        private class Tab
        {
            public string Name;
            public List<string[]> Rows;
            public int Cols;
            public int TotalsFrom;
            public int TotalsTo;
            public int HeadRow;
        }

        //Excel will not take a tab name longer than 31 characters, and refuses : \ / ? * [ ]
        //outright.  Names are made unique as well, since two that differ only in a rejected
        //character would otherwise collide and Excel would refuse the workbook.
        private string Tab_Name(string parWanted, List<string> parTaken)
        {
            string TmpName = (parWanted == null ? "" : parWanted.Trim());
            foreach (char Bad in new char[] { ':', '\\', '/', '?', '*', '[', ']' })
            {
                TmpName = TmpName.Replace(Bad, '-');
            }
            if (TmpName.Length > 31)
            {
                TmpName = TmpName.Substring(0, 31);
            }
            if (TmpName == "")
            {
                TmpName = "Sheet";
            }

            string TmpTry = TmpName;
            int TmpNext = 2;
            while (parTaken.Contains(TmpTry.ToUpper()))
            {
                string TmpSuffix = " (" + TmpNext.ToString() + ")";
                int TmpRoom = 31 - TmpSuffix.Length;
                TmpTry = (TmpName.Length > TmpRoom ? TmpName.Substring(0, TmpRoom) : TmpName) + TmpSuffix;
                TmpNext = TmpNext + 1;
            }
            parTaken.Add(TmpTry.ToUpper());
            return TmpTry;
        }

        private Tab One_Tab(string parName, string parTicker, string parYear)
        {
            Tab Made = new Tab();
            Made.Name = parName;
            Made.Rows = Build_Sheet(parTicker, parYear, out Made.Cols, out Made.TotalsFrom,
                                    out Made.TotalsTo, out Made.HeadRow);
            return Made;
        }

        //What goes into the workbook.  Whatever is on screen is always the first tab; when the
        //ticker and the year are both All, every financial year follows as a tab of its own.
        //
        //Each of those is produced by putting the page into that year and reading it back,
        //rather than by a second query written for the purpose - so a tab shows exactly what
        //the user would see having chosen that year, and there is no second copy of the logic
        //to drift.  The page is put back as it was found before this returns.
        private List<Tab> Build_Tabs(bool parPerYear)
        {
            List<Tab> Tabs = new List<Tab>();
            List<string> Taken = new List<string>();
            Tabs.Add(One_Tab(Tab_Name("Dividend History", Taken), CmbTicker.Text.Trim(),
                             CmbFinYear.Text.Trim()));

            if (!parPerYear)
            {
                return Tabs;
            }

            //Taken from the dropdown's own items, so a tab can only be built for a year the
            //page could actually have been put into.  All is left out: it is the first tab.
            List<string> Years = new List<string>();
            foreach (object Item in CmbFinYear.Items)
            {
                string Year = (Item == null ? "" : Item.ToString().Trim());
                if (Year != "" && Year != "All")
                {
                    Years.Add(Year);
                }
            }

            string TmpWas = CmbFinYear.Text;
            try
            {
                foreach (string Year in Years)
                {
                    //Filling keeps the dropdown's own handler out of it, so the page is
                    //refreshed once here rather than twice.
                    Filling = true;
                    CmbFinYear.Text = Year;
                    Filling = false;

                    //Assigning Text on a DropDownList does nothing at all when the value is not
                    //among its items, and it fails silently - which would leave a tab headed
                    //with one year sitting over another year's rows.  The years came from the
                    //items, so this cannot happen; it is checked because the cost of being
                    //wrong is a plausible-looking sheet of the wrong figures.
                    if (CmbFinYear.Text.Trim() != Year)
                    {
                        throw new Exception("The page could not be put into financial year "
                                            + Year + ".");
                    }

                    Get_Data();
                    Tabs.Add(One_Tab(Tab_Name(Year, Taken), CmbTicker.Text.Trim(), Year));
                }
            }
            finally
            {
                Filling = true;
                CmbFinYear.Text = TmpWas;
                Filling = false;
                Get_Data();
            }
            return Tabs;
        }

        private void Write_Workbook(List<Tab> parTabs, string parPath)
        {
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

                for (int i = 0; i < parTabs.Count; i++)
                {
                    Tab This = parTabs[i];
                    List<string[]> Sheet = This.Rows;
                    int Cols = This.Cols;
                    int TotalsFrom = This.TotalsFrom;
                    int TotalsTo = This.TotalsTo;
                    int HeadRow = This.HeadRow;

                    object[,] Data = new object[Sheet.Count, Cols];
                    for (int r = 0; r < Sheet.Count; r++)
                    {
                        for (int c = 0; c < Cols; c++)
                        {
                            Data[r, c] = Sheet[r][c];
                        }
                    }

                    //a new workbook opens with one sheet; the rest are added after it, in order
                    if (i == 0)
                    {
                        ws = (Excel.Worksheet)sheets[1];
                    }
                    else
                    {
                        ws = (Excel.Worksheet)sheets.Add(Type.Missing, sheets[sheets.Count],
                                                         Type.Missing, Type.Missing);
                    }
                    ws.Name = This.Name;

                    all = ws.Range[ws.Cells[1, 1], ws.Cells[Sheet.Count, Cols]];
                    //Written as text on purpose.  Left to itself Excel re-reads every value and
                    //throws away the formatting the screen is showing : "-$76.05" comes back as
                    //red "($76.05)", "4.10 %" turns into a fraction, and what is recognised as a
                    //number at all depends on the machine's locale.  The export is meant to be
                    //what the user is looking at, so the cells are kept exactly as displayed.
                    all.NumberFormat = "@";
                    all.Value2 = Data;

                    one = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                    one.Font.Bold = true;
                    one.Font.Size = 14;
                    Marshal.ReleaseComObject(one);
                    one = null;

                    if (TotalsTo >= TotalsFrom)
                    {
                        one = ws.Range[ws.Cells[TotalsFrom, 1], ws.Cells[TotalsTo, 2]];
                        one.Font.Bold = true;
                        Marshal.ReleaseComObject(one);
                        one = null;
                    }

                    one = ws.Range[ws.Cells[HeadRow, 1], ws.Cells[HeadRow, Cols]];
                    one.Font.Bold = true;
                    one.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                    Marshal.ReleaseComObject(one);
                    one = null;

                    cols = ws.Columns;
                    cols.AutoFit();

                    //every tab creates its own COM objects, and one left behind keeps an
                    //invisible EXCEL.EXE alive - so they are released here rather than only
                    //at the end
                    Marshal.ReleaseComObject(cols);
                    cols = null;
                    Marshal.ReleaseComObject(all);
                    all = null;
                    Marshal.ReleaseComObject(ws);
                    ws = null;
                }

                //the first tab is the one showing when it opens
                ws = (Excel.Worksheet)sheets[1];
                ws.Activate();

                wb.SaveAs(parPath, Excel.XlFileFormat.xlOpenXMLWorkbook);
                wb.Close(false);
                app.Quit();
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
            }
        }

        //---- the two export buttons -----------------------------------------------
        //
        //Both build the same sheet. Excel asks where to put it and stops there; Drive writes it
        //to a temporary file and sends that on. Busy state is handled here rather than in
        //Write_Workbook because the two buttons disable different things.

        private void Busy(bool parBusy)
        {
            Cursor.Current = (parBusy ? Cursors.WaitCursor : Cursors.Default);
            CmdExcel.Enabled = !parBusy;
            CmdDrive.Enabled = !parBusy;
            CmdBack.Enabled = !parBusy;
        }

        private bool Anything_To_Export()
        {
            if (Active_Grid().Rows.Count == 0)
            {
                MessageBox.Show("There is nothing on screen to export.", "Error Message");
                return false;
            }
            return true;
        }

        private void CmdExcel_Click(object sender, EventArgs e)
        {
            if (!Anything_To_Export())
            {
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Generate Excel";
            dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            dlg.FileName = Export_Name(".xlsx");
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //the workbook is what is on screen and nothing more - the per-year tabs are a
            //Google Drive thing, since that file is meant to stand on its own
            List<Tab> Tabs = Build_Tabs(false);
            Busy(true);
            try
            {
                Write_Workbook(Tabs, dlg.FileName);
                MessageBox.Show("Excel file generated :" + Environment.NewLine + dlg.FileName, "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate the Excel file : " + ex.Message, "Error Message");
            }
            finally
            {
                Busy(false);
            }
        }

        //Names the tabs in the success dialog, so it is obvious whether the per-year ones went
        //in without having to open the Sheet to find out.
        private string Tabs_Said(List<Tab> parTabs)
        {
            if (parTabs == null || parTabs.Count == 0)
            {
                return "";
            }
            if (parTabs.Count == 1)
            {
                return "One tab : " + parTabs[0].Name;
            }
            List<string> Names = new List<string>();
            foreach (Tab One in parTabs)
            {
                Names.Add(One.Name);
            }
            return parTabs.Count.ToString() + " tabs : " + string.Join(", ", Names.ToArray());
        }

        //With both dropdowns on All the Sheet carries the whole history and then each financial
        //year on a tab of its own.  Narrowed by either one it is that view alone: per-year tabs
        //of a single ticker would not be the page the user is looking at, and per-year tabs of
        //one chosen year would be that same year twice.
        private bool Per_Year_Tabs()
        {
            bool TmpAllTickers = (CmbTicker.Text.Trim() == "" || CmbTicker.Text.Trim() == "All");
            bool TmpAllYears = (CmbFinYear.Text.Trim() == "" || CmbFinYear.Text.Trim() == "All");
            return (TmpAllTickers && TmpAllYears);
        }

        //Builds the same workbook into a temporary file, signs in, uploads it as a Google Sheet
        //and throws the temporary file away. The user is never asked where to put it - that is
        //what the Excel button is for.
        private void CmdDrive_Click(object sender, EventArgs e)
        {
            if (!Anything_To_Export())
            {
                return;
            }
            if (!Google_Drive.Configured)
            {
                MessageBox.Show("Google Drive is not set up yet." + Environment.NewLine
                    + Environment.NewLine + Google_Drive.Setup_Hint(), "Error Message");
                return;
            }

            //The same file every time, so the link keeps working and whoever it is shared with
            //sees the latest figures rather than collecting a new file per export.  A different
            //file from the portfolio page's, since the two are different shapes.
            string TmpTitle = Google_Drive.Dividend_History_Sheet_Name();
            string TmpPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(),
                                                    Export_Name("") + ".xlsx");
            string TmpOldNote = LblNote.Text;

            List<Tab> Tabs = null;
            Busy(true);
            try
            {
                LblNote.Text = "Building the workbook ...";
                LblNote.Refresh();
                Tabs = Build_Tabs(Per_Year_Tabs());
                Write_Workbook(Tabs, TmpPath);

                LblNote.Text = "Waiting for you to sign in to Google in your browser ...";
                LblNote.Refresh();
                string TmpWhy;
                string TmpToken = Google_Drive.Sign_In(out TmpWhy);
                if (TmpToken == null)
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                LblNote.Text = "Uploading to Google Drive ...";
                LblNote.Refresh();
                string TmpLink;
                bool TmpReplaced;
                int TmpDuplicates;
                string TmpHow;
                if (!Google_Drive.Upload(TmpToken, TmpPath, TmpTitle, out TmpLink, out TmpReplaced,
                                         out TmpDuplicates, out TmpHow, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                //only one of a set of same-named Sheets is being kept up to date; saying so
                //beats letting the others quietly go stale
                string TmpWarning = "";
                if (TmpDuplicates > 1)
                {
                    TmpWarning = Environment.NewLine + Environment.NewLine
                               + TmpDuplicates.ToString() + " Sheets carry this name."
                               + Environment.NewLine
                               + "The most recently changed one was updated; the rest were left"
                               + " alone and will now be out of date.";
                }

                DialogResult Response = MessageBox.Show(
                    (TmpReplaced ? "Google Sheet updated :" : "Google Sheet created :")
                    + Environment.NewLine + TmpTitle
                    + Environment.NewLine + "(" + TmpHow + ")"
                    + Environment.NewLine + Environment.NewLine
                    + Tabs_Said(Tabs)
                    + TmpWarning
                    + Environment.NewLine + Environment.NewLine + TmpLink
                    + Environment.NewLine + Environment.NewLine + "Open it now ?",
                    "Success", MessageBoxButtons.YesNo);
                if (Response == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(TmpLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate to Google Drive : " + ex.Message, "Error Message");
            }
            finally
            {
                //the workbook was only ever a carrier for the upload
                try
                {
                    if (System.IO.File.Exists(TmpPath))
                    {
                        System.IO.File.Delete(TmpPath);
                    }
                }
                catch
                {
                    //a temp file left behind is not worth a second error on top of the first
                }
                LblNote.Text = TmpOldNote;
                Busy(false);
            }
        }

        //Quit does not always end the process; this is the backstop so exports cannot
        //pile up invisible copies of Excel.
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
