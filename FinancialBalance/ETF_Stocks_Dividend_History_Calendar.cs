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
    //What the portfolio has actually been paid, month by month, over the last twelve months or
    //one financial year -
    //the backward-looking twin of ETF/Stock Forecast Dividend Calendar, laid out the same way
    //so the two can be read side by side.  Reads only; writes nothing.
    public partial class ETF_Stocks_Dividend_History_Calendar : Form
    {
        bool Filling;

        //Index-aligned with CmbPortfolio: entry 0 is "All" and carries no portfolio code.
        //Held as a list rather than looked up by description, because descriptions
        //are not unique in TblETFStocksPortfolioCode.
        List<string> FlagCodes = new List<string>();

        //the months on show, oldest first, each held as the first of that month
        List<DateTime> Months = new List<DateTime>();

        //Every figure is shown in AUD, the same as ETF/Stock Dividend History.  The rates are
        //read once per refresh, before any data reader opens on the shared connection.
        private const string PageCurr = "AUD";

        private Dictionary<string, double> RateCache = new Dictionary<string, double>();
        private Dictionary<string, bool> RateKnown = new Dictionary<string, bool>();
        private List<string> NoRate = new List<string>();
        private string RateMonth = "";

        public ETF_Stocks_Dividend_History_Calendar()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Dividend_History_Calendar_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Portfolio();
            Fill_Period();
            Filling = false;

            Get_Data();
        }

        const string LastTwelve = "Last 12 months";

        //"Last 12 months" first, as the default, then every financial year newest-closing
        //first - the same order ETF/Stock Dividend History lists them in
        private void Fill_Period()
        {
            CmbPeriod.Items.Clear();
            CmbPeriod.Items.Add(LastTwelve);

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpName = Read_Text(reader["Name"]);
                if (TmpName != "")
                {
                    CmbPeriod.Items.Add(TmpName);
                }
            }
            reader.Close();

            CmbPeriod.Text = LastTwelve;
        }

        private void CmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private bool Is_Last_Twelve()
        {
            return (CmbPeriod.Text.Trim() == "" || CmbPeriod.Text.Trim() == LastTwelve);
        }

        //"All" plus one entry per portfolio code, showing its description
        private void Fill_Portfolio()
        {
            CmbPortfolio.Items.Clear();
            FlagCodes.Clear();

            CmbPortfolio.Items.Add("All");
            FlagCodes.Add(null);

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
                FlagCodes.Add(TmpCode);
            }
            reader.Close();

            CmbPortfolio.Text = "All";
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        //With Main Only ticked, only payments whose portfolio is marked Is_Main count.  A
        //payment with no portfolio at all is excluded too, since it belongs to no main one.
        private string Main_Filter()
        {
            if (!chkMainOnly.Checked)
            {
                return "";
            }
            return " and [Portfolio_Code] In (select Portfolio_Code from TblETFStocksPortfolioCode where [Is_Main] = True)";
        }

        private void chkMainOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //the portfolio list itself changes, so rebuild from the top
            Filling = true;
            Fill_Portfolio();
            Filling = false;
            Get_Data();
        }

        //The window the calendar covers, as yyyyMMdd, and the date investment is measured at
        string PeriodFrom = "";
        string PeriodTo = "";
        string Cutoff = "";

        //Last 12 months ends with the month we are in, so a distribution already recorded this
        //month is on the page - the mirror of the forecast, which starts with this month.  A
        //financial year runs from its Start_Date to its End_Date exactly, one column per month
        //it touches - twelve for a normal year, more or fewer for one set up otherwise.
        private void Build_Months()
        {
            Months.Clear();

            DateTime TmpStart;
            DateTime TmpEnd;
            if (!Financial_Year_Range(out TmpStart, out TmpEnd))
            {
                DateTime TmpThis = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                TmpStart = TmpThis.AddMonths(-11);
                TmpEnd = TmpThis.AddMonths(1).AddDays(-1);
            }

            DateTime TmpMonth = new DateTime(TmpStart.Year, TmpStart.Month, 1);
            while (TmpMonth <= TmpEnd)
            {
                Months.Add(TmpMonth);
                TmpMonth = TmpMonth.AddMonths(1);
            }

            PeriodFrom = TmpStart.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            PeriodTo = TmpEnd.ToString("yyyyMMdd", CultureInfo.InvariantCulture);

            //Investment is what was tied up at the end of the window, or today if the window
            //has not closed yet - nothing bought after the year it is set against.
            Cutoff = (TmpEnd < DateTime.Today ? PeriodTo : DateTime.Today.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
        }

        //The chosen financial year's two dates, or false on Last 12 months.  A year whose
        //dates cannot be read is treated as Last 12 months rather than as an empty window.
        private bool Financial_Year_Range(out DateTime parStart, out DateTime parEnd)
        {
            parStart = DateTime.MinValue;
            parEnd = DateTime.MinValue;
            if (Is_Last_Twelve())
            {
                return false;
            }

            string TmpStart = "";
            string TmpEnd = "";
            Mdl1.Ssql = "select [Start_Date], [End_Date] from TblFinancialYear where [Name] = '"
                      + CmbPeriod.Text.Trim().Replace("'", "''") + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpStart = Read_Text(reader["Start_Date"]);
                TmpEnd = Read_Text(reader["End_Date"]);
            }
            reader.Close();

            return DateTime.TryParseExact(TmpStart, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parStart)
                && DateTime.TryParseExact(TmpEnd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parEnd)
                && parEnd >= parStart;
        }

        //How the window is named on screen: "Last 12 Months", or the financial year's name
        private string Period_Label()
        {
            return (Is_Last_Twelve() ? "Last 12 Months" : CmbPeriod.Text.Trim());
        }

        private string Money(double parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        private double Read_Double(object parValue)
        {
            double TmpValue;
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            if (double.TryParse(parValue.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out TmpValue))
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

        private bool Read_Bool(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return false;
            }
            bool TmpValue;
            if (bool.TryParse(parValue.ToString(), out TmpValue))
            {
                return TmpValue;
            }
            return false;
        }

        //---- currency ------------------------------------------------------------

        //Every rate a refresh could want, read before a single row of data is - the same
        //approach ETF/Stock Dividend History takes, for the same reason: the conversion happens
        //inside the read loop, and a second reader cannot open on the shared connection while
        //the first is still live.
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

        //GetCurrRate answers 1 for a currency it has never heard of, so whether TblCurrRate
        //holds anything for it is asked separately - that is what lets the page say a figure
        //went unconverted instead of passing it off as converted.
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

        //Nothing here reads the database: every rate it can answer with was loaded beforehand.
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

        //---- what has been put in -------------------------------------------------

        //One money column added up to the cut-off per ticker - today, or the close of a financial
        //year already over - grouped by currency as well and converted a group at a time:
        //adding USD to AUD first would give a figure that is in neither.  parSign is +1 to add
        //the column in and -1 to take it away.
        private void Add_Money(Dictionary<string, double> parInto, string parTable, string parField,
                               string parPortfolioAnd, int parSign)
        {
            Mdl1.Ssql = "select Full_Ticker, [Currency] as C, Sum(" + parField + ") as N"
                      + " from " + parTable
                      + " where Trans_Date <= '" + Cutoff + "'"
                      + parPortfolioAnd
                      + " group by Full_Ticker, [Currency]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //every rate was loaded before the read, so converting here opens no second reader
                string TmpTicker = Read_Text(reader["Full_Ticker"]);
                double TmpAmount = To_AUD(Read_Double(reader["N"]), Read_Text(reader["C"]));
                double TmpSoFar;
                parInto.TryGetValue(TmpTicker, out TmpSoFar);
                parInto[TmpTicker] = TmpSoFar + (parSign * TmpAmount);
            }
            reader.Close();
        }

        //Money actually put in and not yet taken back out, per ticker: what was really paid, less
        //what selling returned - the figure ETF/Stock Dividend History calls Investment.
        //Real_Total_Cost_Base is 0 on a reinvested purchase, so DRIP units add no cost.  Proceeds
        //can exceed cost, so a figure can legitimately go negative.  Added up over every ticker
        //it is the Grand Total Investment, so the column and the label cannot disagree.
        private Dictionary<string, double> Net_Cost_By_Ticker(string parPortfolioAnd)
        {
            Dictionary<string, double> Result = new Dictionary<string, double>();
            Add_Money(Result, "TblETFStocksPurchase", "[Real_Total_Cost_Base]", parPortfolioAnd, 1);
            Add_Money(Result, "TblETFStocksSale", "[Selling_Total_Amount]", parPortfolioAnd, -1);
            return Result;
        }

        //Nothing invested gives no denominator, and the yield is reported as zero rather than
        //left undefined - the same rule ETF/Stock Dividend History applies.
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
            return parValue.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
        }

        //---- the grid -------------------------------------------------------------

        private void Clear_Grid()
        {
            int N = Months.Count;
            gvHistory.Columns.Clear();
            gvHistory.Rows.Clear();
            gvHistory.ColumnCount = N + 3;

            gvHistory.Columns[0].Name = "Full Ticker";
            gvHistory.Columns[0].FillWeight = 90;
            gvHistory.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvHistory.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            for (int i = 0; i < N; i++)
            {
                gvHistory.Columns[i + 1].Name = Months[i].ToString("MMM yyyy", CultureInfo.InvariantCulture);
                gvHistory.Columns[i + 1].FillWeight = 65;
                gvHistory.Columns[i + 1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gvHistory.Columns[i + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            gvHistory.Columns[N + 1].Name = "Total";
            gvHistory.Columns[N + 1].FillWeight = 80;
            gvHistory.Columns[N + 1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvHistory.Columns[N + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //after Total, since it is Total measured against what the ticker has tied up
            gvHistory.Columns[N + 2].Name = "Yield";
            gvHistory.Columns[N + 2].FillWeight = 55;
            gvHistory.Columns[N + 2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvHistory.Columns[N + 2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        //One row per ticker that was paid anything inside the window, sold or not: a holding
        //sold since still paid what it paid, and leaving it out would understate the year.
        private void Get_Data()
        {
            try
            {
                Build_Months();
                int N = Months.Count;
                LblGrandCap.Text = "Grand Total Dividend (" + Period_Label() + ")";

                Begin_Rates();
                Clear_Grid();

                string TmpFlagCode = null;
                int idx = CmbPortfolio.SelectedIndex;
                if (idx > 0 && idx < FlagCodes.Count)
                {
                    TmpFlagCode = FlagCodes[idx];
                }

                string TmpPortfolioAnd = "";
                if (TmpFlagCode != null)
                {
                    TmpPortfolioAnd += " and [Portfolio_Code] = '" + TmpFlagCode + "'";
                }
                TmpPortfolioAnd += Main_Filter();
                LblNote.Text = "Distributions/dividends received"
                    + "  (" + Period_Label() + ")"
                    + (TmpFlagCode == null ? "" : "  (portfolio " + TmpFlagCode + ")")
                    + (chkMainOnly.Checked ? "  (main portfolios only)" : "");

                //Pay_Date is stored yyyyMMdd, so a plain text comparison brackets the window
                string TmpFrom = PeriodFrom;
                string TmpTo = PeriodTo;

                List<string> Tickers = new List<string>();
                Dictionary<string, double[]> Rows = new Dictionary<string, double[]>();
                double[] MonthTotals = new double[N];
                double GrandTotal = 0;
                double TotalReinvested = 0;
                double TotalNotReinvested = 0;
                int Payments = 0;

                Mdl1.Ssql = "select Full_Ticker, Pay_Date, [Currency], [Total_Amount], [Is_Reinvested]"
                          + " from TblETFStocksDistributionDividend"
                          + " where Pay_Date >= '" + TmpFrom + "' and Pay_Date <= '" + TmpTo + "'"
                          + TmpPortfolioAnd
                          + " order by Full_Ticker, Pay_Date";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string TmpDate = Read_Text(reader["Pay_Date"]);
                    if (TmpDate.Length < 6)
                    {
                        continue;
                    }
                    DateTime TmpMonth;
                    if (!DateTime.TryParseExact(TmpDate.Substring(0, 6), "yyyyMM",
                                                CultureInfo.InvariantCulture, DateTimeStyles.None, out TmpMonth))
                    {
                        continue;
                    }
                    int TmpIdx = ((TmpMonth.Year - Months[0].Year) * 12) + (TmpMonth.Month - Months[0].Month);
                    if (TmpIdx < 0 || TmpIdx >= N)
                    {
                        continue;
                    }

                    string TmpTicker = Read_Text(reader["Full_Ticker"]);
                    if (!Rows.ContainsKey(TmpTicker))
                    {
                        Rows[TmpTicker] = new double[N];
                        Tickers.Add(TmpTicker);
                    }

                    double TmpAmount = To_AUD(Read_Double(reader["Total_Amount"]), Read_Text(reader["Currency"]));
                    Rows[TmpTicker][TmpIdx] += TmpAmount;
                    MonthTotals[TmpIdx] += TmpAmount;
                    GrandTotal += TmpAmount;
                    if (Read_Bool(reader["Is_Reinvested"]))
                    {
                        TotalReinvested += TmpAmount;
                    }
                    else
                    {
                        TotalNotReinvested += TmpAmount;
                    }
                    Payments++;
                }
                reader.Close();

                //read only now, so no other reader is open on the connection.  It covers every
                //holding in the selection, paying or not, as it does on ETF/Stock Dividend History.
                Dictionary<string, double> NetCosts = Net_Cost_By_Ticker(TmpPortfolioAnd);
                double GrandInvestment = Math.Round(NetCosts.Values.Sum(), 2);

                for (int i = 0; i < Tickers.Count; i++)
                {
                    double[] TmpRow = Rows[Tickers[i]];
                    double TmpRowTotal = 0;
                    string[] row = new string[N + 3];
                    row[0] = Tickers[i];
                    for (int m = 0; m < N; m++)
                    {
                        row[m + 1] = (TmpRow[m] == 0 ? "" : Money(TmpRow[m]));
                        TmpRowTotal += TmpRow[m];
                    }
                    row[N + 1] = Money(TmpRowTotal);

                    //Nothing left invested - sold out, or sold for more than it cost - leaves no
                    //denominator.  "-" says so; "0.00 %" would read as though it paid nothing.
                    double TmpInvestment;
                    NetCosts.TryGetValue(Tickers[i], out TmpInvestment);
                    TmpInvestment = Math.Round(TmpInvestment, 2);
                    row[N + 2] = (TmpInvestment > 0 ? Percent(Yield_Of(TmpInvestment, TmpRowTotal)) : "-");
                    gvHistory.Rows.Add(row);
                }

                //A totals row inside the grid, as on the forecast page: one figure per month,
                //and only the grid knows where each month's column has ended up.
                if (Tickers.Count > 0)
                {
                    string[] totals = new string[N + 3];
                    totals[0] = "Total";
                    for (int m = 0; m < N; m++)
                    {
                        totals[m + 1] = Money(MonthTotals[m]);
                    }
                    totals[N + 1] = Money(GrandTotal);
                    //the yield of the whole, not an average of the rows - the same figure as
                    //the Yield label underneath
                    totals[N + 2] = Percent(Yield_Of(GrandInvestment, GrandTotal));
                    gvHistory.Rows.Add(totals);

                    DataGridViewRow TotalRow = gvHistory.Rows[gvHistory.Rows.Count - 1];
                    TotalRow.DefaultCellStyle.Font = new Font(gvHistory.Font, FontStyle.Bold);
                    TotalRow.DefaultCellStyle.BackColor = Color.FromArgb(232, 232, 232);
                    TotalRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 232, 232);
                    TotalRow.DefaultCellStyle.SelectionForeColor = Color.Black;
                }

                LblInv.Text = Money(GrandInvestment);
                LblGrand.Text = Money(GrandTotal);
                //the window's payments against what was tied up at its end - a yield on cost
                LblYield.Text = Percent(Yield_Of(GrandInvestment, GrandTotal));
                LblReinv.Text = Money(TotalReinvested);
                LblNotReinv.Text = Money(TotalNotReinvested);
                LblAverage.Text = Money(N > 0 ? GrandTotal / N : 0);

                Show_Basis(Tickers.Count, Payments);

                gvHistory.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Says what the figures are and what they were converted at, so an export read away
        //from the screen cannot be mistaken for something it is not.
        private void Show_Basis(int parTickers, int parPayments)
        {
            CultureInfo AU = new CultureInfo("en-AU");
            DateTime TmpFirst = DateTime.ParseExact(PeriodFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime TmpLastDay = DateTime.ParseExact(PeriodTo, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime TmpCutoff = DateTime.ParseExact(Cutoff, "yyyyMMdd", CultureInfo.InvariantCulture);
            string TmpText = "Recorded in ETF/Stock Distribution/Dividend, by Pay Date, from "
                + TmpFirst.ToString("dd-MMM-yyyy", AU) + " to " + TmpLastDay.ToString("dd-MMM-yyyy", AU)
                + " (" + Period_Label() + ")"
                + " - " + parPayments.ToString() + " payment(s) across " + parTickers.ToString()
                + " ticker(s).   Investment is as at " + TmpCutoff.ToString("dd-MMM-yyyy", AU)
                + ".   All amounts are in Australian Dollar (" + PageCurr + "), at "
                + DateTime.Now.ToString("MMM yyyy", AU) + " rates.";

            if (NoRate.Count > 0)
            {
                TmpText = TmpText + "   -   no currency rate on record for "
                        + String.Join(", ", NoRate.ToArray()) + ", shown unconverted.";
            }
            LblBasis.Text = TmpText;
        }

        //---- the exports ----------------------------------------------------------

        //The captions and figures under the grid, read back off the labels themselves so
        //the export says what the screen says rather than working any of it out again.
        private void Aggregates(out List<string> parCaptions, out List<string> parValues)
        {
            parCaptions = new List<string>();
            parValues = new List<string>();

            Label[] Caps = new Label[] { LblInvCap, LblGrandCap, LblYieldCap, LblReinvCap,
                                         LblNotReinvCap, LblAverageCap };
            Label[] Vals = new Label[] { LblInv, LblGrand, LblYield, LblReinv,
                                         LblNotReinv, LblAverage };
            for (int i = 0; i < Caps.Length; i++)
            {
                parCaptions.Add(Caps[i].Text.Trim());
                parValues.Add(Vals[i].Text.Trim());
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

        //The form's own Name leads the file name, so an export says which page it came from.
        //parExtension carries the dot.
        private string Export_Name(string parExtension)
        {
            return Safe_Name(this.Name)
                 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                 + "_" + Safe_Name(CmbPortfolio.Text)
                 + "_" + (chkMainOnly.Checked ? "Yes" : "No")
                 + "_" + Safe_Name(CmbPeriod.Text) + parExtension;
        }

        //The whole sheet as a rectangle of strings.  Both exports go through here, so the
        //workbook and the Google Sheet are the same sheet by construction.
        private List<string[]> Build_Sheet(out int parCols, out int parTotalsFrom,
                                           out int parTotalsTo, out int parHeadRow)
        {
            int Cols = gvHistory.Columns.Count;
            if (Cols < 2)
            {
                Cols = 2;
            }

            List<string[]> Sheet = new List<string[]>();
            Sheet.Add(Line(Cols, "ETF/Stock Dividend History Calendar"));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Portfolio", CmbPortfolio.Text.Trim()));
            Sheet.Add(Line(Cols, "Main Only", (chkMainOnly.Checked ? "Yes" : "No")));
            Sheet.Add(Line(Cols, "Period", CmbPeriod.Text.Trim()));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            if (LblNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Note", LblNote.Text.Trim()));
            }
            if (LblBasis.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Basis", LblBasis.Text.Trim()));
            }
            Sheet.Add(Line(Cols));

            //the aggregates sit above the table
            List<string> TmpCaps;
            List<string> TmpVals;
            Aggregates(out TmpCaps, out TmpVals);
            parTotalsFrom = Sheet.Count + 1;
            for (int i = 0; i < TmpCaps.Count; i++)
            {
                Sheet.Add(Line(Cols, TmpCaps[i], TmpVals[i]));
            }
            parTotalsTo = Sheet.Count;
            Sheet.Add(Line(Cols));

            parHeadRow = Sheet.Count + 1;
            string[] head = new string[Cols];
            for (int cc = 0; cc < gvHistory.Columns.Count; cc++)
            {
                head[cc] = gvHistory.Columns[cc].Name;
            }
            Sheet.Add(head);

            //the grid already carries its own totals row, so it comes across with the rest
            for (int r = 0; r < gvHistory.Rows.Count; r++)
            {
                string[] line = new string[Cols];
                for (int cc = 0; cc < gvHistory.Columns.Count; cc++)
                {
                    object v = gvHistory.Rows[r].Cells[cc].Value;
                    line[cc] = (v == null ? "" : v.ToString());
                }
                Sheet.Add(line);
            }

            parCols = Cols;
            return Sheet;
        }

        //---- Excel ---------------------------------------------------------------

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr parHwnd, out int parProcessId);

        //Takes where to write as a parameter so the Drive button can send it to a temporary
        //file instead of one the user chose.  Throws rather than reporting: the callers
        //differ in what they say afterwards.
        private void Write_Workbook(List<string[]> parSheet, int parCols, int parTotalsFrom,
                                    int parTotalsTo, int parHeadRow, string parPath)
        {
            object[,] Data = new object[parSheet.Count, parCols];
            for (int r = 0; r < parSheet.Count; r++)
            {
                for (int cc = 0; cc < parCols; cc++)
                {
                    Data[r, cc] = parSheet[r][cc];
                }
            }

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
                ws.Name = "Dividend History Calendar";

                all = ws.Range[ws.Cells[1, 1], ws.Cells[parSheet.Count, parCols]];
                //written as text on purpose, so the cells are kept exactly as displayed
                all.NumberFormat = "@";
                all.Value2 = Data;

                one = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                one.Font.Bold = true;
                one.Font.Size = 14;
                Marshal.ReleaseComObject(one);
                one = null;

                if (parTotalsTo >= parTotalsFrom)
                {
                    one = ws.Range[ws.Cells[parTotalsFrom, 1], ws.Cells[parTotalsTo, 2]];
                    one.Font.Bold = true;
                    Marshal.ReleaseComObject(one);
                    one = null;
                }

                one = ws.Range[ws.Cells[parHeadRow, 1], ws.Cells[parHeadRow, parCols]];
                one.Font.Bold = true;
                one.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                Marshal.ReleaseComObject(one);
                one = null;

                //the grid's own totals row is the last line of the sheet
                if (parSheet.Count > parHeadRow)
                {
                    one = ws.Range[ws.Cells[parSheet.Count, 1], ws.Cells[parSheet.Count, parCols]];
                    one.Font.Bold = true;
                    one.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                    Marshal.ReleaseComObject(one);
                    one = null;
                }

                cols = ws.Columns;
                cols.AutoFit();

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

        private void Busy(bool parBusy)
        {
            Cursor.Current = (parBusy ? Cursors.WaitCursor : Cursors.Default);
            CmdExcel.Enabled = !parBusy;
            CmdDrive.Enabled = !parBusy;
            CmdBack.Enabled = !parBusy;
        }

        private bool Anything_To_Export()
        {
            if (gvHistory.Rows.Count == 0)
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

            int TmpCols;
            int TmpFrom;
            int TmpTo;
            int TmpHead;
            List<string[]> TmpSheet = Build_Sheet(out TmpCols, out TmpFrom, out TmpTo, out TmpHead);

            Busy(true);
            try
            {
                Write_Workbook(TmpSheet, TmpCols, TmpFrom, TmpTo, TmpHead, dlg.FileName);
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

        //Builds the same workbook into a temporary file, signs in, uploads it as a Google
        //Sheet and throws the temporary file away.
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

            //One Sheet, reused : each run replaces the last, whichever period it shows - the
            //Period line at the top of the sheet says which - rather than leave a file per run.
            string TmpTitle = Google_Drive.Dividend_History_Calendar_Sheet_Name();
            string TmpPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(),
                                                    Export_Name("") + ".xlsx");
            string TmpOldNote = LblNote.Text;

            Busy(true);
            try
            {
                LblNote.Text = "Building the workbook ...";
                LblNote.Refresh();
                int TmpCols;
                int TmpFrom;
                int TmpTo;
                int TmpHead;
                List<string[]> TmpSheet = Build_Sheet(out TmpCols, out TmpFrom, out TmpTo,
                                                      out TmpHead);
                Write_Workbook(TmpSheet, TmpCols, TmpFrom, TmpTo, TmpHead, TmpPath);

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
