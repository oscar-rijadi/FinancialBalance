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

        private string Code_Match(string parCode)
        {
            if (parCode == null || parCode == "")
            {
                return " and [Portfolio_Code] Is Null";
            }
            return " and [Portfolio_Code] = '" + parCode + "'";
        }

        //One money column added up to the cut-off.  The currency comes back too, but only when
        //every contributing row agrees on it - Min and Max matching is the cheapest way to ask
        //that without a second trip to the database.
        private double Sum_Money(string parTable, string parField, string parTickerClause,
                                 string parCodeClause, string parCutoff, out string parCurrency)
        {
            double Result = 0;
            parCurrency = "";

            Mdl1.Ssql = "select Sum(" + parField + ") as N, Min([Currency]) as C1, Max([Currency]) as C2"
                      + " from " + parTable
                      + " where 1 = 1" + parTickerClause + parCodeClause
                      + " and Trans_Date <= '" + parCutoff + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Result = Read_Double(reader["N"]);
                string TmpC1 = Read_Text(reader["C1"]);
                string TmpC2 = Read_Text(reader["C2"]);
                if (TmpC1 != "" && TmpC1 == TmpC2)
                {
                    parCurrency = TmpC1;
                }
            }
            reader.Close();
            return Result;
        }

        //Money actually put in and not yet taken back out: what was really paid, less what
        //selling returned.  Real_Total_Cost_Base is 0 on a reinvested purchase, so units that
        //arrived as a DRIP add no cost - which is the point of using that field rather than
        //Total_Cost_Base.  Proceeds can exceed cost, so this can legitimately go negative.
        private double Net_Cost(string parTickerClause, string parCodeClause, string parCutoff, out string parCurrency)
        {
            string TmpBuyCurr;
            string TmpSellCurr;

            double Bought = Sum_Money("TblETFStocksPurchase", "[Real_Total_Cost_Base]",
                                      parTickerClause, parCodeClause, parCutoff, out TmpBuyCurr);
            double Sold = Sum_Money("TblETFStocksSale", "[Selling_Total_Amount]",
                                    parTickerClause, parCodeClause, parCutoff, out TmpSellCurr);

            //a dollar sign is only earned when the two sides agree, or only one side exists
            parCurrency = "";
            if (TmpBuyCurr != "" && (TmpSellCurr == "" || TmpSellCurr == TmpBuyCurr))
            {
                parCurrency = TmpBuyCurr;
            }
            else if (TmpBuyCurr == "" && TmpSellCurr != "")
            {
                parCurrency = TmpSellCurr;
            }

            return Math.Round(Bought - Sold, 2);
        }

        //---- formatting ----------------------------------------------------------

        //AUD and USD are shown with a dollar sign; any other currency stays bare.
        //A negative reads -$12.34 rather than $-12.34.
        private bool Is_Dollar(string parCurr)
        {
            if (parCurr == null)
            {
                return false;
            }
            string TmpCurr = parCurr.Trim().ToUpper();
            return (TmpCurr == "AUD" || TmpCurr == "USD");
        }

        private string Money(double parValue, string parCurr)
        {
            if (!Is_Dollar(parCurr))
            {
                return Mdl1.FormatAmt(parValue);
            }
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //One row per ticker, portfolio and currency.  Currency joins the grouping because two
        //currencies under one ticker cannot be added together - without it the Total would be
        //a sum of unlike amounts and the Currency column would be whichever row came last.
        private void Get_Summary()
        {
            Clear_Summary_Grid();

            Mdl1.Ssql = "select Full_Ticker, [Portfolio_Code], [Currency],"
                      + " Sum([Total_Amount]) as TotAll,"
                      + " Sum(IIf([Is_Reinvested] = True, [Total_Amount], 0)) as TotYes,"
                      + " Sum(IIf([Is_Reinvested] = True, 0, [Total_Amount])) as TotNo"
                      + " from TblETFStocksDistributionDividend"
                      + Where_Clause()
                      + " group by Full_Ticker, [Portfolio_Code], [Currency]"
                      + " order by Full_Ticker, [Portfolio_Code], [Currency]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            double GrandAll = 0;
            double GrandYes = 0;
            double GrandNo = 0;
            List<string> Currencies = new List<string>();
            string TmpCutoff = Cutoff_Date();
            while (reader.Read())
            {
                string TmpCurr = Read_Text(reader["Currency"]);
                double TmpAll = Read_Double(reader["TotAll"]);
                double TmpYes = Read_Double(reader["TotYes"]);
                double TmpNo = Read_Double(reader["TotNo"]);
                string TmpTicker = Read_Text(reader["Full_Ticker"]);
                string TmpCode = Read_Text(reader["Portfolio_Code"]);

                string TmpInvCurr;
                double TmpInvestment = Net_Cost(" and Full_Ticker = '" + TmpTicker + "'",
                                                Code_Match(TmpCode), TmpCutoff, out TmpInvCurr);
                string strInvestment = Money(TmpInvestment, TmpInvCurr);

                //what the payments came to against what the holding is worth.  An unpriced or
                //empty holding gives no denominator, and the yield is reported as zero rather
                //than left undefined.
                double TmpYield = 0;
                if (TmpInvestment > 0)
                {
                    TmpYield = TmpAll / TmpInvestment * 100;
                }

                gvSummary.Rows.Add(new string[] {
                    TmpTicker,
                    TmpCode,
                    (TmpCurr == "" ? "-" : TmpCurr),
                    strInvestment,
                    Money(TmpAll, TmpCurr),
                    TmpYield.ToString("#,##0.00") + " %",
                    Money(TmpYes, TmpCurr),
                    Money(TmpNo, TmpCurr) });

                GrandAll += TmpAll;
                GrandYes += TmpYes;
                GrandNo += TmpNo;
                if (!Currencies.Contains(TmpCurr))
                {
                    Currencies.Add(TmpCurr);
                }
            }
            reader.Close();

            Show_Summary_Totals(GrandAll, GrandYes, GrandNo, Currencies);

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
            List<string> Currencies = new List<string>();
            while (reader.Read())
            {
                string TmpCurr = Read_Text(reader["Currency"]);
                double TmpAmount = Read_Double(reader["Total_Amount"]);
                bool TmpReinvested = (Read_Text(reader["Is_Reinvested"]) == "True");

                gvDetail.Rows.Add(new string[] {
                    Format_Date(Read_Text(reader["Pay_Date"])),
                    Read_Text(reader["Portfolio_Code"]),
                    (TmpCurr == "" ? "-" : TmpCurr),
                    Money(TmpAmount, TmpCurr),
                    Money((TmpReinvested ? TmpAmount : 0), TmpCurr),
                    Money((TmpReinvested ? 0 : TmpAmount), TmpCurr) });

                GrandAll += TmpAmount;
                if (TmpReinvested)
                {
                    GrandYes += TmpAmount;
                }
                else
                {
                    GrandNo += TmpAmount;
                }
                if (!Currencies.Contains(TmpCurr))
                {
                    Currencies.Add(TmpCurr);
                }
            }
            reader.Close();

            Show_Detail_Totals(GrandAll, GrandYes, GrandNo, Currencies);

            gvDetail.ClearSelection();
        }

        //The figures under whichever table is showing.  There are five fixed slots, filled
        //from the top, so both views sit flush without gaps and the two sets can never appear
        //at once.  A slot given a null caption is put away, which keeps the helper usable if
        //a view ever needs fewer than five.
        //
        //A dollar sign is only put on a total when every row that fed it shares one dollar
        //currency.  Adding AUD to USD does not produce an amount in either, so a mixed
        //selection is left bare rather than labelled with a currency it is not in.
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

        private string One_Currency(List<string> parCurrencies)
        {
            return (parCurrencies.Count == 1 ? parCurrencies[0] : "");
        }

        //Summary view: the whole selection's holding value, then the payments, the yield those
        //payments represent, and the reinvested split.
        private void Show_Summary_Totals(double parAll, double parYes, double parNo, List<string> parCurrencies)
        {
            string TmpCurr = One_Currency(parCurrencies);

            //the same two sums across whatever the Portfolio dropdown and Main Only select,
            //rather than one named portfolio, so no per-ticker walk is needed
            string TmpInvCurr;
            double TmpInvestment = Net_Cost("", Portfolio_Filter(), Cutoff_Date(), out TmpInvCurr);

            double TmpYield = 0;
            if (TmpInvestment > 0)
            {
                TmpYield = parAll / TmpInvestment * 100;
            }

            Set_Slot(0, "Grand Total Investment", Money(TmpInvestment, TmpInvCurr));
            Set_Slot(1, "Grand Total", Money(parAll, TmpCurr));
            Set_Slot(2, "Yield", TmpYield.ToString("#,##0.00") + " %");
            Set_Slot(3, "Grand Total Reinvested", Money(parYes, TmpCurr));
            Set_Slot(4, "Grand Total Not Reinvested", Money(parNo, TmpCurr));
        }

        //Payment view: the same shape as the summary, but for the one ticker on screen.  The
        //portfolio side still comes from the dropdown and Main Only rather than any single
        //row, so the investment covers every portfolio the selection includes.
        private void Show_Detail_Totals(double parAll, double parYes, double parNo, List<string> parCurrencies)
        {
            string TmpCurr = One_Currency(parCurrencies);

            string TmpInvCurr;
            double TmpInvestment = Net_Cost(Ticker_Filter(), Portfolio_Filter(), Cutoff_Date(), out TmpInvCurr);

            double TmpYield = 0;
            if (TmpInvestment > 0)
            {
                TmpYield = parAll / TmpInvestment * 100;
            }

            Set_Slot(0, "Total Investment", Money(TmpInvestment, TmpInvCurr));
            Set_Slot(1, "Total Amount", Money(parAll, TmpCurr));
            Set_Slot(2, "Yield", TmpYield.ToString("#,##0.00") + " %");
            Set_Slot(3, "Total Amount Reinvested", Money(parYes, TmpCurr));
            Set_Slot(4, "Total Amount Not Reinvested", Money(parNo, TmpCurr));
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
                    Parts.Add("financial year " + TmpYear + "  (" + Format_Date(TmpStart) + " to " + Format_Date(TmpEnd) + ")");
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
            LblNote.Text = TmpText;
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

        private void CmdExcel_Click(object sender, EventArgs e)
        {
            DataGridView grid = Active_Grid();
            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing on screen to export.", "Error Message");
                return;
            }

            //The form's own Name leads the file name, so an export says which page it
            //came from before anything else.  Taken from this.Name rather than typed out,
            //so it cannot drift from the form it belongs to.
            string TmpName = Safe_Name(this.Name)
                           + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                           + "_" + Safe_Name(CmbPortfolio.Text)
                           + "_" + (chkMainOnly.Checked ? "Yes" : "No")
                           + "_" + Safe_Name(CmbTicker.Text)
                           + "_" + Safe_Name(CmbFinYear.Text) + ".xlsx";

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Generate Excel";
            dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            dlg.FileName = TmpName;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //lay the whole sheet out first, so Excel is only asked to do one write
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
            Sheet.Add(Line(Cols, "Full Ticker", CmbTicker.Text.Trim()));
            Sheet.Add(Line(Cols, "Financial Year", CmbFinYear.Text.Trim()));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            if (LblNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Note", LblNote.Text.Trim()));
            }
            Sheet.Add(Line(Cols));

            //the aggregates sit above the table
            int TotalsFrom = Sheet.Count + 1;
            for (int i = 0; i < Caps.Count; i++)
            {
                Sheet.Add(Line(Cols, Caps[i], Vals[i]));
            }
            int TotalsTo = Sheet.Count;
            if (Caps.Count > 0)
            {
                Sheet.Add(Line(Cols));
            }

            int HeadRow = Sheet.Count + 1;
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

            object[,] Data = new object[Sheet.Count, Cols];
            for (int r = 0; r < Sheet.Count; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Data[r, c] = Sheet[r][c];
                }
            }

            Cursor.Current = Cursors.WaitCursor;
            CmdExcel.Enabled = false;

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
                ws.Name = "Dividend History";

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
                Cursor.Current = Cursors.Default;
                CmdExcel.Enabled = true;
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
