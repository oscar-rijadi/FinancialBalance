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
    public partial class ETF_Stocks_FY_Reconciliation : Form
    {
        bool Filling;

        //The Portfolio dropdown shows descriptions but filters on codes, so the codes are kept
        //in a list running parallel to the items - two portfolios sharing a description still
        //filter correctly.  A null entry is the "All" row.
        List<string> PortfolioCodes = new List<string>();

        public ETF_Stocks_FY_Reconciliation()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_FY_Reconciliation_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Financial_Year();
            Fill_Portfolio();
            Fill_Entry_Lists();
            Filling = false;

            Clear_Grid();
            Get_Data();

            //the dropdowns were filled with events suppressed, so the description and the
            //defaults are resolved once here for whatever they landed on
            Show_Entry_Description();
            Apply_Defaults();
        }

        private void MnDaily_Click(object sender, EventArgs e)
        {
            Daily_Input Daily_Input = new Daily_Input();
            Daily_Input.Show();
            this.Close();
        }

        private void MnMonthlyClosing_Click(object sender, EventArgs e)
        {
            Monthly_Closing Monthly_Closing = new Monthly_Closing();
            Monthly_Closing.Show();
            this.Close();
        }

        private void MnETFStocksPrice_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Price ETF_Stocks_Price = new ETF_Stocks_Price();
            ETF_Stocks_Price.Show();
            this.Close();
        }

        private void MnETFStocksInvestment_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Investment ETF_Stocks_Investment = new ETF_Stocks_Investment();
            ETF_Stocks_Investment.Show();
            this.Close();
        }

        private void MnETFStocksTrans_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Transaction ETF_Stocks_Transaction = new ETF_Stocks_Transaction();
            ETF_Stocks_Transaction.Show();
            this.Close();
        }

        private void MnETFStocksDistribution_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Distribution ETF_Stocks_Distribution = new ETF_Stocks_Distribution();
            ETF_Stocks_Distribution.Show();
            this.Close();
        }

        //---- the filters ---------------------------------------------------------

        //Most recently closed year first, the one usually being reconciled
        private void Fill_Financial_Year()
        {
            CmbFinYear.Items.Clear();

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFinYear.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            if (CmbFinYear.Items.Count > 0)
            {
                CmbFinYear.SelectedIndex = 0;
            }
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

        private void CmbFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
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
            //"All" still respects Main Only, and a row carrying no code at all belongs to no
            //main portfolio, so it drops out with the rest.
            if (chkMainOnly.Checked)
            {
                return " and [Portfolio_Code] In (select Portfolio_Code from TblETFStocksPortfolioCode where [Is_Main] = True)";
            }
            return "";
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

        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00") + " %";
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

        //The stored figure in the plain form the entry boxes use, so loading a row back does
        //not round-trip through the display formatting
        private string Stored(object parValue)
        {
            return Math.Round(Read_Double(parValue), 2).ToString("0.00", CultureInfo.InvariantCulture);
        }

        //Losses in red, gains in green; zero is left alone
        private void Colour_Cell(DataGridViewCell parCell, double parValue)
        {
            if (parValue < 0)
            {
                parCell.Style.ForeColor = System.Drawing.Color.Red;
                parCell.Style.SelectionForeColor = System.Drawing.Color.Red;
            }
            else if (parValue > 0)
            {
                parCell.Style.ForeColor = System.Drawing.Color.Green;
                parCell.Style.SelectionForeColor = System.Drawing.Color.Green;
            }
        }

        //---- the table -----------------------------------------------------------

        private void Clear_Grid()
        {
            gvRecon.Rows.Clear();
            gvRecon.Columns.Clear();

            string[] names = new string[] {
                "Financial Year", "Portfolio Code", "Currency",
                "Previous Investment", "Ending Investment", "On Paper Ending Value",
                "On Paper Profit/Loss", "Percentage On Paper Profit/Loss",
                "Distribution/Dividend", "Distribution/Dividend Yield",
                "Distribution/Dividend Reinvested", "Distribution/Dividend Not Reinvested",
                "Capital Gains On Paper", "Real Capital Gains",
                "Real Profit/Loss", "Percentage Real Profit/Loss" };
            int[] weights = new int[] { 8, 7, 5, 9, 9, 10, 10, 11, 9, 10, 11, 12, 10, 9, 9, 10 };

            gvRecon.ColumnCount = names.Length;
            for (int i = 0; i < names.Length; i++)
            {
                gvRecon.Columns[i].Name = names[i];
                gvRecon.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign;
                if (i == 0)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                }
                else if (i <= 2)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleRight;
                }
                gvRecon.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvRecon.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                gvRecon.Rows.Clear();

                string TmpYear = CmbFinYear.Text.Trim();
                if (TmpYear != "")
                {
                    Mdl1.Ssql = "select [Financial_Year], [Portfolio_Code], [Currency], [Previous_Investment],"
                              + " [Investment], [Sold_Amount],"
                              + " [Ending_Investment], [On_Paper_Ending_Value], [On_Paper_Profit_Or_Loss],"
                              + " [Percentage_On_Paper_Profit_Or_Loss], [Total_DistributionDividend],"
                              + " [Total_DistributionDividend_Yield], [Total_DistributionDividend_Reinvested],"
                              + " [Total_DistributionDividend_Not_Reinvested], [Capital_Gains_On_Paper],"
                              + " [Real_Capital_Gains], [Investment_Loan_Interest], [Tax],"
                              + " [Real_Profit_Or_Loss], [Percentage_Real_Profit_Or_Loss]"
                              + " from TblETFStocksFinancialYear"
                              + " where [Financial_Year] = '" + TmpYear + "'"
                              + Portfolio_Filter()
                              + " order by [Portfolio_Code]";
                    OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string TmpCode = Read_Text(reader["Portfolio_Code"]);
                        //the row now carries its own currency, so nothing has to be inferred
                        string TmpCurr = Read_Text(reader["Currency"]);

                        double TmpOnPaperPL = Read_Double(reader["On_Paper_Profit_Or_Loss"]);
                        double TmpOnPaperPct = Read_Double(reader["Percentage_On_Paper_Profit_Or_Loss"]);
                        double TmpCapGainPaper = Read_Double(reader["Capital_Gains_On_Paper"]);
                        double TmpCapGainReal = Read_Double(reader["Real_Capital_Gains"]);
                        double TmpRealPL = Read_Double(reader["Real_Profit_Or_Loss"]);
                        double TmpRealPct = Read_Double(reader["Percentage_Real_Profit_Or_Loss"]);

                        gvRecon.Rows.Add(new string[] {
                            Read_Text(reader["Financial_Year"]),
                            TmpCode,
                            (TmpCurr == "" ? "-" : TmpCurr),
                            Money(Read_Double(reader["Previous_Investment"]), TmpCurr),
                            Money(Read_Double(reader["Ending_Investment"]), TmpCurr),
                            Money(Read_Double(reader["On_Paper_Ending_Value"]), TmpCurr),
                            Money(TmpOnPaperPL, TmpCurr),
                            Percent(TmpOnPaperPct),
                            Money(Read_Double(reader["Total_DistributionDividend"]), TmpCurr),
                            Percent(Read_Double(reader["Total_DistributionDividend_Yield"])),
                            Money(Read_Double(reader["Total_DistributionDividend_Reinvested"]), TmpCurr),
                            Money(Read_Double(reader["Total_DistributionDividend_Not_Reinvested"]), TmpCurr),
                            Money(TmpCapGainPaper, TmpCurr),
                            Money(TmpCapGainReal, TmpCurr),
                            Money(TmpRealPL, TmpCurr),
                            Percent(TmpRealPct) });

                        DataGridViewRow Row = gvRecon.Rows[gvRecon.Rows.Count - 1];
                        Row.Tag = new string[] {
                            Read_Text(reader["Financial_Year"]), TmpCode, TmpCurr,
                            Stored(reader["Previous_Investment"]), Stored(reader["Investment"]),
                            Stored(reader["Sold_Amount"]), Stored(reader["Ending_Investment"]),
                            Stored(reader["On_Paper_Ending_Value"]), Stored(reader["On_Paper_Profit_Or_Loss"]),
                            Stored(reader["Percentage_On_Paper_Profit_Or_Loss"]),
                            Stored(reader["Total_DistributionDividend"]),
                            Stored(reader["Total_DistributionDividend_Yield"]),
                            Stored(reader["Total_DistributionDividend_Reinvested"]),
                            Stored(reader["Total_DistributionDividend_Not_Reinvested"]),
                            Stored(reader["Capital_Gains_On_Paper"]), Stored(reader["Real_Capital_Gains"]),
                            Stored(reader["Investment_Loan_Interest"]), Stored(reader["Tax"]),
                            Stored(reader["Real_Profit_Or_Loss"]), Stored(reader["Percentage_Real_Profit_Or_Loss"]) };
                        Colour_Cell(Row.Cells[6], TmpOnPaperPL);
                        Colour_Cell(Row.Cells[7], TmpOnPaperPct);
                        Colour_Cell(Row.Cells[12], TmpCapGainPaper);
                        Colour_Cell(Row.Cells[13], TmpCapGainReal);
                        Colour_Cell(Row.Cells[14], TmpRealPL);
                        Colour_Cell(Row.Cells[15], TmpRealPct);
                    }
                    reader.Close();
                }

                gvRecon.ClearSelection();
                Filling = false;

                Show_Note();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Says what is narrowing the table, so an empty one is explainable
        private void Show_Note()
        {
            string TmpText = gvRecon.Rows.Count.ToString() + " row(s)";
            if (CmbFinYear.Items.Count == 0)
            {
                TmpText = "No financial year has been set up yet - see Financial Year Setup.";
            }
            else if (chkMainOnly.Checked)
            {
                TmpText = TmpText + "   -   main portfolios only";
            }
            LblNote.Text = TmpText;
        }

        //---- the entry section ---------------------------------------------------

        //Guards the recalculation chain while values are being loaded or defaulted, so a
        //stored row is not immediately overwritten by figures worked out from scratch.
        bool Calculating;

        private void Fill_Entry_Lists()
        {
            CmbEntryFinYear.Items.Clear();
            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbEntryFinYear.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            CmbEntryCode.Items.Clear();
            Mdl1.Ssql = "select Portfolio_Code from TblETFStocksPortfolioCode order by Portfolio_Code";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbEntryCode.Items.Add(reader["Portfolio_Code"].ToString().Trim());
            }
            reader.Close();

            CmbEntryCurrency.Items.Clear();
            Mdl1.Ssql = "select Curr_Code from TblCurrCode order by Curr_Code";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbEntryCurrency.Items.Add(reader["Curr_Code"].ToString().Trim());
            }
            reader.Close();

            if (CmbEntryFinYear.Items.Count > 0) { CmbEntryFinYear.SelectedIndex = 0; }
            if (CmbEntryCode.Items.Count > 0) { CmbEntryCode.SelectedIndex = 0; }
            if (CmbEntryCurrency.Items.Contains("AUD")) { CmbEntryCurrency.Text = "AUD"; }
            else if (CmbEntryCurrency.Items.Count > 0) { CmbEntryCurrency.SelectedIndex = 0; }
        }

        //The code is what gets stored, but it is only five characters; the description is
        //shown beside it so the right portfolio is obvious without opening the setup page.
        private void Show_Entry_Description()
        {
            string TmpCode = CmbEntryCode.Text.Trim();
            if (TmpCode == "")
            {
                LblEntryDesc.Text = "";
                return;
            }

            string TmpDesc = "";
            Mdl1.Ssql = "select [Description] from TblETFStocksPortfolioCode where Portfolio_Code = '" + TmpCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpDesc = Read_Text(reader["Description"]);
            }
            reader.Close();
            LblEntryDesc.Text = (TmpDesc == "" ? "-" : TmpDesc);
        }

        private void CmbEntryFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Apply_Defaults();
        }

        private void CmbEntryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Show_Entry_Description();
            Apply_Defaults();
        }

        private void CmbEntryCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nothing is derived from the currency; it is stored as chosen
        }

        //---- reading the numbers -------------------------------------------------

        private double Box(TextBox parBox)
        {
            double d;
            if (double.TryParse(parBox.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out d))
            {
                return d;
            }
            return 0;
        }

        private void Set_Box(TextBox parBox, double parValue)
        {
            parBox.Text = Math.Round(parValue, 2).ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TmpBox = sender as TextBox;

            //Mdl1.NumericKeyPress rejects a minus sign, but every figure here is a result that
            //can legitimately be negative - a loss, a capital loss, a negative percentage.
            if (e.KeyChar == '-')
            {
                if (TmpBox != null && TmpBox.SelectionStart == 0 && !TmpBox.Text.Contains("-"))
                {
                    return;
                }
                e.Handled = true;
                return;
            }

            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        //---- the derived figures -------------------------------------------------
        //
        //Each box below re-derives from the ones above it and every one stays editable, so a
        //typed figure stands until something it depends on changes again.  The chain runs one
        //way only - Ending Investment feeds the profit figures, never the reverse - so setting
        //a box from here cascades safely rather than looping.

        private void Recalc_Ending()
        {
            if (Calculating) { return; }
            Calculating = true;
            Set_Box(txtEndInv, Box(txtPrevInv) + Box(txtInvestment) - Box(txtSold));
            Calculating = false;
            Recalc_From_Ending();
        }

        private void Recalc_From_Ending()
        {
            Recalc_OnPaperPL();
            Recalc_DDYield();
            Recalc_RealPct();
        }

        private void Recalc_OnPaperPL()
        {
            if (Calculating) { return; }
            Calculating = true;
            Set_Box(txtOnPaperPL, Box(txtOnPaperVal) - Box(txtEndInv));
            Calculating = false;
            Recalc_OnPaperPct();
        }

        //A percentage needs something to divide by; without it the answer is reported as zero
        //rather than left undefined.
        private double Percent_Of_Ending(double parValue)
        {
            double TmpEnding = Box(txtEndInv);
            if (TmpEnding > 0)
            {
                return parValue / TmpEnding * 100;
            }
            return 0;
        }

        private void Recalc_OnPaperPct()
        {
            if (Calculating) { return; }
            Calculating = true;
            Set_Box(txtOnPaperPct, Percent_Of_Ending(Box(txtOnPaperPL)));
            Calculating = false;
        }

        private void Recalc_DDYield()
        {
            if (Calculating) { return; }
            Calculating = true;
            Set_Box(txtDDYield, Percent_Of_Ending(Box(txtDD)));
            Calculating = false;
        }

        private void Recalc_RealPL()
        {
            if (Calculating) { return; }
            Calculating = true;
            Set_Box(txtRealPL, Box(txtDD) + Box(txtCapGainReal) - Box(txtLoanInterest) - Box(txtTax));
            Calculating = false;
            Recalc_RealPct();
        }

        private void Recalc_RealPct()
        {
            if (Calculating) { return; }
            Calculating = true;
            Set_Box(txtRealPct, Percent_Of_Ending(Box(txtRealPL)));
            Calculating = false;
        }

        private void txtPrevInv_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_Ending();
        }

        private void txtInvestment_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_Ending();
        }

        private void txtSold_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_Ending();
        }

        private void txtEndInv_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_From_Ending();
        }

        private void txtOnPaperVal_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_OnPaperPL();
        }

        private void txtOnPaperPL_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_OnPaperPct();
        }

        private void txtDD_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_DDYield();
            Recalc_RealPL();
        }

        private void txtCapGainReal_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_RealPL();
        }

        private void txtLoanInterest_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_RealPL();
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_RealPL();
        }

        private void txtRealPL_TextChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }
            Recalc_RealPct();
        }

        //---- the defaults --------------------------------------------------------

        private bool Year_Range(string parName, out string parStart, out string parEnd)
        {
            parStart = "";
            parEnd = "";
            if (parName == null || parName.Trim() == "") { return false; }

            Mdl1.Ssql = "select [Start_Date], [End_Date] from TblFinancialYear where [Name] = '" + parName.Trim() + "'";
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

        private double Sum_Between(string parTable, string parField, string parDateField,
                                   string parCode, string parStart, string parEnd, string parExtra)
        {
            double Result = 0;
            Mdl1.Ssql = "select Sum(" + parField + ") as N from " + parTable
                      + " where [Portfolio_Code] = '" + parCode + "'"
                      + " and " + parDateField + " >= '" + parStart + "'"
                      + " and " + parDateField + " <= '" + parEnd + "'"
                      + parExtra;
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Result = Read_Double(reader["N"]);
            }
            reader.Close();
            return Result;
        }

        //Last year's closing position becomes this year's opening one.  The preceding year is
        //the one whose End_Date falls latest before this year starts.
        private double Previous_Ending(string parYear, string parCode, string parStart)
        {
            string TmpPrevYear = "";
            Mdl1.Ssql = "select top 1 [Name] from TblFinancialYear where [End_Date] < '" + parStart + "'"
                      + " order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpPrevYear = Read_Text(reader["Name"]);
            }
            reader.Close();
            if (TmpPrevYear == "") { return 0; }

            double Result = 0;
            Mdl1.Ssql = "select [Ending_Investment] from TblETFStocksFinancialYear"
                      + " where [Financial_Year] = '" + TmpPrevYear + "'"
                      + " and [Portfolio_Code] = '" + parCode + "'";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Result = Read_Double(reader["Ending_Investment"]);
            }
            reader.Close();
            return Result;
        }

        //The price to value a holding at, in order of preference: the latest one inside the
        //year, then the last one before it, then the first one after it.  A ticker with no
        //price at all anywhere is worth nothing here rather than being guessed at.
        private double Price_For_Year(string parTicker, string parStart, string parEnd)
        {
            string[] Clauses = new string[] {
                " and Price_Date >= '" + parStart + "' and Price_Date <= '" + parEnd + "' order by Price_Date Desc",
                " and Price_Date < '" + parStart + "' order by Price_Date Desc",
                " and Price_Date > '" + parEnd + "' order by Price_Date Asc" };

            for (int Pass = 0; Pass < Clauses.Length; Pass++)
            {
                Mdl1.Ssql = "select top 1 [Price] from TblETFStocksPrice"
                          + " where Full_Ticker = '" + parTicker + "'"
                          + Clauses[Pass];
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                bool Found = false;
                double TmpPrice = 0;
                if (reader.Read())
                {
                    TmpPrice = Read_Double(reader["Price"]);
                    Found = true;
                }
                reader.Close();
                if (Found)
                {
                    return TmpPrice;
                }
            }
            return 0;
        }

        //What the units still held were worth at the year end: every ticker still open in this
        //portfolio and bought on or before the year closed, valued at the price above.  Buying
        //after the year end cannot count towards that year, hence the cut-off on Trans_Date.
        private double On_Paper_Value(string parCode, string parStart, string parEnd)
        {
            List<string> Tickers = new List<string>();
            List<double> Units = new List<double>();

            Mdl1.Ssql = "select Full_Ticker, Sum(Unit) as N from TblETFStocksPurchase"
                      + " where [Portfolio_Code] = '" + parCode + "' and Is_Sold = False"
                      + " and Trans_Date <= '" + parEnd + "'"
                      + " group by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tickers.Add(Read_Text(reader["Full_Ticker"]));
                Units.Add(Read_Double(reader["N"]));
            }
            reader.Close();

            double Total = 0;
            for (int i = 0; i < Tickers.Count; i++)
            {
                if (Units[i] == 0) { continue; }
                Total += Math.Round(Units[i] * Price_For_Year(Tickers[i], parStart, parEnd), 2);
            }
            return Math.Round(Total, 2);
        }

        //Fills the entry area with what the rest of the database already knows about this year
        //and portfolio.  Every one of these stays editable afterwards.
        private void Apply_Defaults()
        {
            try
            {
                string TmpYear = CmbEntryFinYear.Text.Trim();
                string TmpCode = CmbEntryCode.Text.Trim();
                string TmpStart;
                string TmpEnd;

                Filling = true;
                if (TmpYear == "" || TmpCode == "" || !Year_Range(TmpYear, out TmpStart, out TmpEnd))
                {
                    Set_Box(txtPrevInv, 0); Set_Box(txtInvestment, 0); Set_Box(txtSold, 0);
                    Set_Box(txtOnPaperVal, 0); Set_Box(txtDD, 0); Set_Box(txtDDReinv, 0);
                    Set_Box(txtDDNotReinv, 0); Set_Box(txtCapGainPaper, 0); Set_Box(txtCapGainReal, 0);
                    Set_Box(txtLoanInterest, 0); Set_Box(txtTax, 0);
                }
                else
                {
                    Set_Box(txtPrevInv, Previous_Ending(TmpYear, TmpCode, TmpStart));
                    //Amount is always stored positive, with the direction in Investment_Type,
                    //so the two signs have to be summed apart and subtracted - adding the
                    //column outright would count a withdrawal as money going in.
                    Set_Box(txtInvestment,
                        Sum_Between("TblETFStocksPortfolioInvestment", "[Amount]", "Investment_Date",
                                    TmpCode, TmpStart, TmpEnd, " and [Investment_Type] = '+'")
                      - Sum_Between("TblETFStocksPortfolioInvestment", "[Amount]", "Investment_Date",
                                    TmpCode, TmpStart, TmpEnd, " and [Investment_Type] = '-'"));
                    Set_Box(txtSold, Sum_Between("TblETFStocksPurchase", "[Real_Total_Cost_Base]",
                                                 "Trans_Date", TmpCode, TmpStart, TmpEnd, " and Is_Sold = True"));
                    Set_Box(txtOnPaperVal, On_Paper_Value(TmpCode, TmpStart, TmpEnd));
                    Set_Box(txtDD, Sum_Between("TblETFStocksDistributionDividend", "[Total_Amount]",
                                               "Pay_Date", TmpCode, TmpStart, TmpEnd, ""));
                    Set_Box(txtDDReinv, Sum_Between("TblETFStocksDistributionDividend", "[Total_Amount]",
                                                    "Pay_Date", TmpCode, TmpStart, TmpEnd, " and [Is_Reinvested] = True"));
                    Set_Box(txtDDNotReinv, Sum_Between("TblETFStocksDistributionDividend", "[Total_Amount]",
                                                       "Pay_Date", TmpCode, TmpStart, TmpEnd, " and [Is_Reinvested] = False"));
                    Set_Box(txtCapGainPaper, Sum_Between("TblETFStocksSale", "[Profit_Or_Loss_On_Paper]",
                                                         "Trans_Date", TmpCode, TmpStart, TmpEnd, ""));
                    Set_Box(txtCapGainReal, Sum_Between("TblETFStocksSale", "[Real_Profit_Or_Loss]",
                                                        "Trans_Date", TmpCode, TmpStart, TmpEnd, ""));
                    Set_Box(txtLoanInterest, 0);
                    Set_Box(txtTax, 0);
                }
                Filling = false;

                //everything derived follows from the figures just placed
                Recalc_Ending();
                Recalc_RealPL();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- saving --------------------------------------------------------------

        //Financial_Year and Portfolio_Code together identify a reconciliation - one per
        //portfolio per year - so they are what Add checks against and Update and Delete match on.
        private bool Entry_Exists(string parYear, string parCode)
        {
            Mdl1.Ssql = "select [Financial_Year] from TblETFStocksFinancialYear"
                      + " where [Financial_Year] = '" + parYear + "' and [Portfolio_Code] = '" + parCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        private bool Validate_Entry(out string parYear, out string parCode)
        {
            parYear = CmbEntryFinYear.Text.Trim();
            parCode = CmbEntryCode.Text.Trim();

            if (parYear == "")
            {
                MessageBox.Show("Financial Year must be selected ! Please set one up first in Financial Year Setup.", "Error Message");
                return false;
            }
            if (parCode == "")
            {
                MessageBox.Show("Portfolio Code must be selected ! Please set one up first in ETF/Stock Portfolio Code Setup.", "Error Message");
                return false;
            }
            if (CmbEntryCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Currency must be selected !", "Error Message");
                return false;
            }
            return true;
        }

        private string Num(TextBox parBox)
        {
            return Math.Round(Box(parBox), 2).ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpYear;
                string TmpCode;
                if (!Validate_Entry(out TmpYear, out TmpCode)) { return; }

                if (Entry_Exists(TmpYear, TmpCode))
                {
                    MessageBox.Show(TmpCode + " already has a reconciliation for " + TmpYear
                        + ". Use Update to change it.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksFinancialYear ([Financial_Year], [Portfolio_Code], [Currency],"
                          + " [Previous_Investment], [Investment], [Sold_Amount], [Ending_Investment],"
                          + " [On_Paper_Ending_Value], [On_Paper_Profit_Or_Loss], [Percentage_On_Paper_Profit_Or_Loss],"
                          + " [Total_DistributionDividend], [Total_DistributionDividend_Yield],"
                          + " [Total_DistributionDividend_Reinvested], [Total_DistributionDividend_Not_Reinvested],"
                          + " [Capital_Gains_On_Paper], [Real_Capital_Gains], [Investment_Loan_Interest], [Tax],"
                          + " [Real_Profit_Or_Loss], [Percentage_Real_Profit_Or_Loss]) values ("
                          + "'" + TmpYear + "', '" + TmpCode + "', '" + CmbEntryCurrency.Text.Trim() + "', "
                          + Num(txtPrevInv) + ", " + Num(txtInvestment) + ", " + Num(txtSold) + ", "
                          + Num(txtEndInv) + ", " + Num(txtOnPaperVal) + ", " + Num(txtOnPaperPL) + ", "
                          + Num(txtOnPaperPct) + ", " + Num(txtDD) + ", " + Num(txtDDYield) + ", "
                          + Num(txtDDReinv) + ", " + Num(txtDDNotReinv) + ", " + Num(txtCapGainPaper) + ", "
                          + Num(txtCapGainReal) + ", " + Num(txtLoanInterest) + ", " + Num(txtTax) + ", "
                          + Num(txtRealPL) + ", " + Num(txtRealPct) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + TmpCode + " in " + TmpYear, "Success");
                Show_Saved(TmpYear);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpYear;
                string TmpCode;
                if (!Validate_Entry(out TmpYear, out TmpCode)) { return; }

                if (!Entry_Exists(TmpYear, TmpCode))
                {
                    MessageBox.Show("No reconciliation found for " + TmpCode + " in " + TmpYear
                        + ". Use Add to create one.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblETFStocksFinancialYear set "
                          + "[Currency] = '" + CmbEntryCurrency.Text.Trim() + "', "
                          + "[Previous_Investment] = " + Num(txtPrevInv) + ", "
                          + "[Investment] = " + Num(txtInvestment) + ", "
                          + "[Sold_Amount] = " + Num(txtSold) + ", "
                          + "[Ending_Investment] = " + Num(txtEndInv) + ", "
                          + "[On_Paper_Ending_Value] = " + Num(txtOnPaperVal) + ", "
                          + "[On_Paper_Profit_Or_Loss] = " + Num(txtOnPaperPL) + ", "
                          + "[Percentage_On_Paper_Profit_Or_Loss] = " + Num(txtOnPaperPct) + ", "
                          + "[Total_DistributionDividend] = " + Num(txtDD) + ", "
                          + "[Total_DistributionDividend_Yield] = " + Num(txtDDYield) + ", "
                          + "[Total_DistributionDividend_Reinvested] = " + Num(txtDDReinv) + ", "
                          + "[Total_DistributionDividend_Not_Reinvested] = " + Num(txtDDNotReinv) + ", "
                          + "[Capital_Gains_On_Paper] = " + Num(txtCapGainPaper) + ", "
                          + "[Real_Capital_Gains] = " + Num(txtCapGainReal) + ", "
                          + "[Investment_Loan_Interest] = " + Num(txtLoanInterest) + ", "
                          + "[Tax] = " + Num(txtTax) + ", "
                          + "[Real_Profit_Or_Loss] = " + Num(txtRealPL) + ", "
                          + "[Percentage_Real_Profit_Or_Loss] = " + Num(txtRealPct)
                          + " where [Financial_Year] = '" + TmpYear + "' and [Portfolio_Code] = '" + TmpCode + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + TmpCode + " in " + TmpYear, "Success");
                Show_Saved(TmpYear);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpYear;
                string TmpCode;
                if (!Validate_Entry(out TmpYear, out TmpCode)) { return; }

                if (!Entry_Exists(TmpYear, TmpCode))
                {
                    MessageBox.Show("No reconciliation found for " + TmpCode + " in " + TmpYear, "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksFinancialYear"
                          + " where [Financial_Year] = '" + TmpYear + "' and [Portfolio_Code] = '" + TmpCode + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + TmpCode + " in " + TmpYear, "Success");
                Show_Saved(TmpYear);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //A row just saved may not be under the year the table is showing; move the table to it
        //rather than leaving the user looking at an unchanged list.
        private void Show_Saved(string parYear)
        {
            Filling = true;
            if (CmbFinYear.Items.Contains(parYear))
            {
                CmbFinYear.Text = parYear;
            }
            Filling = false;
            Get_Data();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Filling = true;
            gvRecon.ClearSelection();
            Filling = false;
            Apply_Defaults();
        }

        //Clicking a row in the table loads that reconciliation as it was stored
        private void gvRecon_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling) { return; }

            DataGridViewRow Row = null;
            if (gvRecon.SelectedRows.Count > 0) { Row = gvRecon.SelectedRows[0]; }
            else { Row = gvRecon.CurrentRow; }
            if (Row == null || Row.Tag == null) { return; }

            string[] o = (string[])Row.Tag;

            Filling = true;
            if (CmbEntryFinYear.Items.Contains(o[0])) { CmbEntryFinYear.Text = o[0]; }
            if (CmbEntryCode.Items.Contains(o[1])) { CmbEntryCode.Text = o[1]; }
            if (o[2] != "" && !CmbEntryCurrency.Items.Contains(o[2])) { CmbEntryCurrency.Items.Add(o[2]); }
            if (o[2] != "") { CmbEntryCurrency.Text = o[2]; }
            txtPrevInv.Text = o[3];
            txtInvestment.Text = o[4];
            txtSold.Text = o[5];
            txtEndInv.Text = o[6];
            txtOnPaperVal.Text = o[7];
            txtOnPaperPL.Text = o[8];
            txtOnPaperPct.Text = o[9];
            txtDD.Text = o[10];
            txtDDYield.Text = o[11];
            txtDDReinv.Text = o[12];
            txtDDNotReinv.Text = o[13];
            txtCapGainPaper.Text = o[14];
            txtCapGainReal.Text = o[15];
            txtLoanInterest.Text = o[16];
            txtTax.Text = o[17];
            txtRealPL.Text = o[18];
            txtRealPct.Text = o[19];
            Filling = false;

            Show_Entry_Description();
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
