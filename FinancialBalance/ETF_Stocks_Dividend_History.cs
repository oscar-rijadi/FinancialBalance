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

        //---- holdings ------------------------------------------------------------

        //Everything is valued as at one date: today when no financial year is chosen, and
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

        private double Sum_Units(string parTable, string parTicker, string parCode, string parCutoff)
        {
            double Result = 0;
            Mdl1.Ssql = "select Sum(Unit) as N from " + parTable
                      + " where Full_Ticker = '" + parTicker + "'"
                      + Code_Match(parCode)
                      + " and Trans_Date <= '" + parCutoff + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Result = Read_Double(reader["N"]);
            }
            reader.Close();
            return Result;
        }

        //Units still held: everything bought up to the cut-off, less everything sold.  A part
        //sale splits its purchase row into a closed part and an open one that together still
        //hold the original units, so the purchase side is deliberately not filtered on
        //Is_Sold - doing that would take the sold units off twice.
        private double Units_Held(string parTicker, string parCode, string parCutoff)
        {
            return Sum_Units("TblETFStocksPurchase", parTicker, parCode, parCutoff)
                 - Sum_Units("TblETFStocksSale", parTicker, parCode, parCutoff);
        }

        //The price the holding is valued at: the most recent one on or before the cut-off.
        //A ticker first priced after the cut-off has none, and rather than valuing it at zero
        //its earliest price on record is used instead.
        private bool Price_At(string parTicker, string parCutoff, out double parPrice, out string parCurrency)
        {
            parPrice = 0;
            parCurrency = "";

            for (int Pass = 0; Pass < 2; Pass++)
            {
                Mdl1.Ssql = "select top 1 [Price], [Currency] from TblETFStocksPrice"
                          + " where Full_Ticker = '" + parTicker + "'"
                          + (Pass == 0 ? " and Price_Date <= '" + parCutoff + "' order by Price_Date Desc"
                                       : " order by Price_Date Asc");
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                bool Found = false;
                if (reader.Read())
                {
                    parPrice = Read_Double(reader["Price"]);
                    parCurrency = Read_Text(reader["Currency"]);
                    Found = true;
                }
                reader.Close();
                if (Found)
                {
                    return true;
                }
            }
            return false;
        }

        //What the units still held were worth at the cut-off.  Returns false when the ticker
        //has never been priced, so the column can say so rather than show a confident zero.
        private bool Investment_At(string parTicker, string parCode, string parCutoff, out double parValue, out string parCurrency)
        {
            parValue = 0;
            double TmpPrice;
            if (!Price_At(parTicker, parCutoff, out TmpPrice, out parCurrency))
            {
                return false;
            }
            parValue = Math.Round(Units_Held(parTicker, parCode, parCutoff) * TmpPrice, 2);
            return true;
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
                new string[] { "Full Ticker", "Portfolio Code", "Currency", "Investment", "Total", "Total Reinvested", "Total Not Reinvested", "Yield" },
                new int[] { 14, 11, 8, 14, 14, 14, 15, 10 }, 3);
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

                double TmpInvestment;
                string TmpInvCurr;
                string strInvestment;
                if (Investment_At(TmpTicker, TmpCode, TmpCutoff, out TmpInvestment, out TmpInvCurr))
                {
                    strInvestment = Money(TmpInvestment, TmpInvCurr);
                }
                else
                {
                    //never priced, so there is nothing to measure the payments against
                    TmpInvestment = 0;
                    strInvestment = "-";
                }

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
                    Money(TmpYes, TmpCurr),
                    Money(TmpNo, TmpCurr),
                    TmpYield.ToString("#,##0.00") + " %" });

                GrandAll += TmpAll;
                GrandYes += TmpYes;
                GrandNo += TmpNo;
                if (!Currencies.Contains(TmpCurr))
                {
                    Currencies.Add(TmpCurr);
                }
            }
            reader.Close();

            Show_Totals("Grand Total", GrandAll, GrandYes, GrandNo, Currencies);

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

            Show_Totals("Total Amount", GrandAll, GrandYes, GrandNo, Currencies);

            gvDetail.ClearSelection();
        }

        //The three figures under whichever table is showing.  They are one set of labels with
        //the captions swapped, so the two views can never both be on screen at once.
        //
        //A dollar sign is only put on a total when every row that fed it shares one dollar
        //currency.  Adding AUD to USD does not produce an amount in either, so a mixed
        //selection is left bare rather than labelled with a currency it is not in.
        private void Show_Totals(string parPrefix, double parAll, double parYes, double parNo, List<string> parCurrencies)
        {
            LblTotCap.Text = parPrefix;
            LblReinvCap.Text = parPrefix + " Reinvested";
            LblNotReinvCap.Text = parPrefix + " Not Reinvested";

            string TmpCurr = "";
            if (parCurrencies.Count == 1)
            {
                TmpCurr = parCurrencies[0];
            }

            LblTot.Text = Money(parAll, TmpCurr);
            LblReinv.Text = Money(parYes, TmpCurr);
            LblNotReinv.Text = Money(parNo, TmpCurr);
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

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
