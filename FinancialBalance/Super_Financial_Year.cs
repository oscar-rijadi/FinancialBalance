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
    public partial class Super_Financial_Year : Form
    {
        bool Filling;

        //Guards the recalculation chain while values are being loaded or defaulted, so a stored
        //row is not immediately overwritten by figures worked out from scratch.
        bool Calculating;

        //The Super filter shows "name - fund" but the table stores a code, so the codes run
        //alongside the items.  A null entry is the "All" row.
        List<string> FilterSuperCodes = new List<string>();

        //TblSuperFinancialYear has no key.  Financial_Year and Super_Code together identify a
        //row - one per super account per year - so those two are what an update matches on.
        bool RowSelected;
        string OrgFinYear;
        string OrgSuperCode;

        public Super_Financial_Year()
        {
            InitializeComponent();
        }

        private void Super_Financial_Year_Load(object sender, EventArgs e)
        {
            Filling = true;
            Calculating = true;
            Clear_Grid();
            Fill_Financial_Year(CmbFilterFinYear, false);
            Fill_Filter_Super();
            Fill_Financial_Year(CmbFinYear, true);
            Fill_Super_Code();
            Mdl1.Fill_Curr(CmbCurrency);
            Set_Default_Currency();
            Calculating = false;
            Filling = false;

            Clear_Entry();
            Get_Data();
        }

        //---- the menu -------------------------------------------------------------

        private void MnPropertySale_Click(object sender, EventArgs e)
        {
            Property_Sale Property_Sale = new Property_Sale();
            Property_Sale.Show();
            this.Close();
        }

        private void MnPropertyPurchase_Click(object sender, EventArgs e)
        {
            Property_Purchase Property_Purchase = new Property_Purchase();
            Property_Purchase.Show();
            this.Close();
        }

        private void MnPropertySetup_Click(object sender, EventArgs e)
        {
            Setup_Property Setup_Property = new Setup_Property();
            Setup_Property.Show();
            this.Close();
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

        private void MnETFStocksPurchase_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Purchase ETF_Stocks_Purchase = new ETF_Stocks_Purchase();
            ETF_Stocks_Purchase.Show();
            this.Close();
        }

        private void MnETFStocksSale_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Sale ETF_Stocks_Sale = new ETF_Stocks_Sale();
            ETF_Stocks_Sale.Show();
            this.Close();
        }

        private void MnETFStocksDistribution_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Distribution ETF_Stocks_Distribution = new ETF_Stocks_Distribution();
            ETF_Stocks_Distribution.Show();
            this.Close();
        }

        private void MnETFStocksCostBase_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Cost_Base_Adjustment ETF_Stocks_Cost_Base_Adjustment = new ETF_Stocks_Cost_Base_Adjustment();
            ETF_Stocks_Cost_Base_Adjustment.Show();
            this.Close();
        }

        private void MnETFStocksFYRecon_Click(object sender, EventArgs e)
        {
            ETF_Stocks_FY_Reconciliation ETF_Stocks_FY_Reconciliation = new ETF_Stocks_FY_Reconciliation();
            ETF_Stocks_FY_Reconciliation.Show();
            this.Close();
        }

        //---- filling the dropdowns ------------------------------------------------

        //Most recently closed year first.  The filter carries an All entry; the entry row does
        //not, because a stored row always belongs to one year.
        private void Fill_Financial_Year(ComboBox parCombo, bool parEntry)
        {
            parCombo.Items.Clear();
            if (!parEntry)
            {
                parCombo.Items.Add("All");
            }

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                parCombo.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            if (parCombo.Items.Count > 0)
            {
                parCombo.SelectedIndex = 0;
            }
        }

        //Reads as "name - fund", which is how a super account is recognised; the code behind it
        //is what the table stores.
        private string Super_Caption(string parName, string parFund)
        {
            return parName + " - " + parFund;
        }

        private void Fill_Filter_Super()
        {
            CmbFilterSuper.Items.Clear();
            FilterSuperCodes.Clear();
            CmbFilterSuper.Items.Add("All");
            FilterSuperCodes.Add(null);

            Mdl1.Ssql = "select [Super_Code], [Name], [Super_Fund_Name] from TblSuper order by [Super_Code]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFilterSuper.Items.Add(Super_Caption(Read_Text(reader["Name"]), Read_Text(reader["Super_Fund_Name"])));
                FilterSuperCodes.Add(Read_Text(reader["Super_Code"]));
            }
            reader.Close();
            CmbFilterSuper.Text = "All";
        }

        private void Fill_Super_Code()
        {
            CmbSuperCode.Items.Clear();
            Mdl1.Ssql = "select [Super_Code] from TblSuper order by [Super_Code]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbSuperCode.Items.Add(Read_Text(reader["Super_Code"]));
            }
            reader.Close();
            if (CmbSuperCode.Items.Count > 0)
            {
                CmbSuperCode.SelectedIndex = 0;
            }
        }

        //Fill_Curr defaults to IDR for the accounting pages; super balances default to AUD
        private void Set_Default_Currency()
        {
            if (CmbCurrency.Items.Contains("AUD"))
            {
                CmbCurrency.Text = "AUD";
            }
        }

        private void Show_Super_Description()
        {
            string TmpCode = CmbSuperCode.Text.Trim();
            if (TmpCode == "")
            {
                LblSuperDesc.Text = "";
                return;
            }
            string TmpText = "-";
            Mdl1.Ssql = "select [Name], [Super_Fund_Name] from TblSuper where [Super_Code] = '" + TmpCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpText = Super_Caption(Read_Text(reader["Name"]), Read_Text(reader["Super_Fund_Name"]));
            }
            reader.Close();
            LblSuperDesc.Text = TmpText;
        }

        //---- formatting -----------------------------------------------------------

        //AUD and USD carry a dollar sign; any other currency stays bare, and a negative reads
        //-$12.34 rather than $-12.34.
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

        private string Num(double parValue)
        {
            return Math.Round(parValue, 2).ToString("0.00", CultureInfo.InvariantCulture);
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

        private void Colour_Label(Label parLabel, double parValue)
        {
            if (parValue < 0)
            {
                parLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (parValue > 0)
            {
                parLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                parLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        //---- the table ------------------------------------------------------------

        //Admin Fee, Insurance Premium and the two Goverment Tax figures are stored but not shown
        //here - they are the workings behind Investment Profit/Loss rather than results.
        private void Clear_Grid()
        {
            gvSFY.Rows.Clear();
            gvSFY.Columns.Clear();
            gvSFY.ColumnCount = 14;
            string[] names = new string[] {
                "Financial Year", "Super Code", "Currency", "Opening Balance", "Contribution",
                "Transfer In", "Investment Returns", "Percentage Investment Returns",
                "Investment Profit/Loss", "Percentage Investment Profit/Loss",
                "Total Surplus/Minus", "Percentage Total Surplus/Minus", "Transfer Out",
                "Ending Balance" };
            int[] weights = new int[] { 9, 7, 6, 9, 8, 8, 9, 11, 10, 12, 9, 12, 8, 9 };
            for (int i = 0; i < 14; i++)
            {
                gvSFY.Columns[i].Name = names[i];
                gvSFY.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign =
                    (i <= 2 ? DataGridViewContentAlignment.MiddleCenter : DataGridViewContentAlignment.MiddleRight);
                gvSFY.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvSFY.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private string Filter_Super_Code()
        {
            int idx = CmbFilterSuper.SelectedIndex;
            if (idx < 0 || idx >= FilterSuperCodes.Count)
            {
                return null;
            }
            return FilterSuperCodes[idx];
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private string Select_Rows()
        {
            string TmpYear = CmbFilterFinYear.Text.Trim();
            string TmpCode = Filter_Super_Code();
            return "select [Financial_Year], [Super_Code], [Currency], [Opening_Balance], [Contribution],"
                 + " [Transfer_In], [Investment_Returns], [Percentage_Investment_Returns], [Admin_Fee],"
                 + " [Insurance_Premium], [Goverment_Tax], [Goverment_Tax_Benefit],"
                 + " [Investment_Profit_Or_Loss], [Percentage_Investment_Profit_Or_Loss],"
                 + " [Total_Surplus_Or_Minus], [Percentage_Total_Surplus_Or_Minus], [Transfer_Out],"
                 + " [Ending_Balance]"
                 + " from TblSuperFinancialYear where 1 = 1"
                 + (TmpYear == "" || TmpYear == "All" ? "" : " and [Financial_Year] = '" + TmpYear + "'")
                 + (TmpCode == null ? "" : " and [Super_Code] = '" + TmpCode + "'")
                 + " order by [Financial_Year], [Super_Code]";
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();
                RowSelected = false;

                Mdl1.Ssql = Select_Rows();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string TmpCurr = Read_Text(reader["Currency"]);
                    double TmpInvPL = Read_Double(reader["Investment_Profit_Or_Loss"]);
                    double TmpPctInvPL = Read_Double(reader["Percentage_Investment_Profit_Or_Loss"]);
                    double TmpTotal = Read_Double(reader["Total_Surplus_Or_Minus"]);
                    double TmpPctTotal = Read_Double(reader["Percentage_Total_Surplus_Or_Minus"]);

                    gvSFY.Rows.Add(new string[] {
                        Read_Text(reader["Financial_Year"]),
                        Read_Text(reader["Super_Code"]),
                        (TmpCurr == "" ? "-" : TmpCurr),
                        Money(Read_Double(reader["Opening_Balance"]), TmpCurr),
                        Money(Read_Double(reader["Contribution"]), TmpCurr),
                        Money(Read_Double(reader["Transfer_In"]), TmpCurr),
                        Money(Read_Double(reader["Investment_Returns"]), TmpCurr),
                        Percent(Read_Double(reader["Percentage_Investment_Returns"])),
                        Money(TmpInvPL, TmpCurr),
                        Percent(TmpPctInvPL),
                        Money(TmpTotal, TmpCurr),
                        Percent(TmpPctTotal),
                        Money(Read_Double(reader["Transfer_Out"]), TmpCurr),
                        Money(Read_Double(reader["Ending_Balance"]), TmpCurr) });

                    DataGridViewRow Row = gvSFY.Rows[gvSFY.Rows.Count - 1];
                    Colour_Cell(Row.Cells[8], TmpInvPL);
                    Colour_Cell(Row.Cells[9], TmpPctInvPL);
                    Colour_Cell(Row.Cells[10], TmpTotal);
                    Colour_Cell(Row.Cells[11], TmpPctTotal);
                }
                reader.Close();

                gvSFY.ClearSelection();
                Filling = false;
                LblNote.Text = gvSFY.Rows.Count.ToString() + " row(s)";
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void gvSFY_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //SelectionChanged fires while CurrentRow can still be pointing at the row being left
            DataGridViewRow Row = null;
            if (gvSFY.SelectedRows.Count > 0)
            {
                Row = gvSFY.SelectedRows[0];
            }
            else
            {
                Row = gvSFY.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            int Ord = Row.Index;
            Mdl1.Ssql = Select_Rows();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            bool Found = false;
            while (reader.Read())
            {
                if (i == Ord)
                {
                    Filling = true;
                    Calculating = true;

                    OrgFinYear = Read_Text(reader["Financial_Year"]);
                    OrgSuperCode = Read_Text(reader["Super_Code"]);

                    if (CmbFinYear.Items.Contains(OrgFinYear)) { CmbFinYear.Text = OrgFinYear; }
                    if (CmbSuperCode.Items.Contains(OrgSuperCode)) { CmbSuperCode.Text = OrgSuperCode; }
                    string TmpCurr = Read_Text(reader["Currency"]);
                    if (CmbCurrency.Items.Contains(TmpCurr)) { CmbCurrency.Text = TmpCurr; }

                    txtOpeningBalance.Text = Num(Read_Double(reader["Opening_Balance"]));
                    txtContribution.Text = Num(Read_Double(reader["Contribution"]));
                    txtTransferIn.Text = Num(Read_Double(reader["Transfer_In"]));
                    txtInvestmentReturns.Text = Num(Read_Double(reader["Investment_Returns"]));
                    txtAdminFee.Text = Num(Read_Double(reader["Admin_Fee"]));
                    txtInsurancePremium.Text = Num(Read_Double(reader["Insurance_Premium"]));
                    txtGovermentTax.Text = Num(Read_Double(reader["Goverment_Tax"]));
                    txtGovermentTaxBenefit.Text = Num(Read_Double(reader["Goverment_Tax_Benefit"]));
                    //the stored figures are shown as they are, not recomputed - they may have
                    //been overridden deliberately when the row was entered
                    txtInvestmentProfitOrLoss.Text = Num(Read_Double(reader["Investment_Profit_Or_Loss"]));
                    txtTotalSurplusOrMinus.Text = Num(Read_Double(reader["Total_Surplus_Or_Minus"]));
                    txtTransferOut.Text = Num(Read_Double(reader["Transfer_Out"]));
                    txtEndingBalance.Text = Num(Read_Double(reader["Ending_Balance"]));

                    Set_Percent(LblPctInvReturns, Read_Double(reader["Percentage_Investment_Returns"]), false);
                    Set_Percent(LblPctInvProfitOrLoss, Read_Double(reader["Percentage_Investment_Profit_Or_Loss"]), true);
                    Set_Percent(LblPctTotalSurplusOrMinus, Read_Double(reader["Percentage_Total_Surplus_Or_Minus"]), true);

                    Calculating = false;
                    Filling = false;
                    Found = true;
                    break;
                }
                i++;
            }
            reader.Close();
            if (!Found)
            {
                return;
            }

            Show_Super_Description();
            RowSelected = true;
        }

        //---- the entry area -------------------------------------------------------

        private void Clear_Entry()
        {
            Filling = true;
            Calculating = true;
            RowSelected = false;
            if (CmbFinYear.Items.Count > 0) { CmbFinYear.SelectedIndex = 0; }
            if (CmbSuperCode.Items.Count > 0) { CmbSuperCode.SelectedIndex = 0; }
            Set_Default_Currency();
            foreach (TextBox box in new TextBox[] { txtOpeningBalance, txtContribution, txtTransferIn,
                                                    txtInvestmentReturns, txtAdminFee, txtInsurancePremium,
                                                    txtGovermentTax, txtGovermentTaxBenefit,
                                                    txtInvestmentProfitOrLoss, txtTotalSurplusOrMinus,
                                                    txtTransferOut, txtEndingBalance })
            {
                box.Text = "0.00";
            }
            Calculating = false;
            Filling = false;

            Show_Super_Description();
            Refresh_Opening_Balance();
        }

        private void Entry_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Super_Description();
            //the opening balance follows the year and the account, but not the currency
            if (ReferenceEquals(sender, CmbFinYear) || ReferenceEquals(sender, CmbSuperCode))
            {
                Refresh_Opening_Balance();
            }
        }

        //---- the opening balance ---------------------------------------------------
        //
        //A year opens on whatever the same account closed the previous year at, so that figure is
        //offered rather than typed again. Changing either the year or the account re-reads it,
        //which does overwrite anything typed into the box - the dropdowns describe which row is
        //being entered, so a figure carried over from the previous selection would be wrong.
        //
        //While a stored row is being loaded Filling is set, so this never runs then: an opening
        //balance saved months ago is shown as saved, not replaced by today's lookup.

        //The preceding year is the one whose End_Date falls latest before this year starts - the
        //same rule ETF_Stocks_FY_Reconciliation uses for a portfolio's opening investment. A year
        //with no row of its own gives 0 rather than reaching further back, since a gap means the
        //balance in between is unknown, not zero.
        private double Previous_Ending_Balance(string parYear, string parCode)
        {
            if (parYear == null || parCode == null
                || parYear.Trim() == "" || parCode.Trim() == "")
            {
                return 0;
            }

            string TmpStart = "";
            Mdl1.Ssql = "select [Start_Date] from TblFinancialYear where [Name] = '" + parYear.Trim() + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpStart = Read_Text(reader["Start_Date"]);
            }
            reader.Close();
            if (TmpStart == "") { return 0; }

            string TmpPrevYear = "";
            Mdl1.Ssql = "select top 1 [Name] from TblFinancialYear where [End_Date] < '" + TmpStart + "'"
                      + " order by [End_Date] Desc";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpPrevYear = Read_Text(reader["Name"]);
            }
            reader.Close();
            if (TmpPrevYear == "") { return 0; }

            double Result = 0;
            Mdl1.Ssql = "select [Ending_Balance] from TblSuperFinancialYear"
                      + " where [Financial_Year] = '" + TmpPrevYear + "'"
                      + " and [Super_Code] = '" + parCode.Trim() + "'";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Result = Read_Double(reader["Ending_Balance"]);
            }
            reader.Close();
            return Result;
        }

        private void Refresh_Opening_Balance()
        {
            try
            {
                Set_Box(txtOpeningBalance,
                    Previous_Ending_Balance(CmbFinYear.Text.Trim(), CmbSuperCode.Text.Trim()));
                //the opening balance is the base every percentage measures against, so the rest
                //of the entry area is restated with it
                Recalc_All();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        private double Box(TextBox parBox)
        {
            double TmpValue;
            double.TryParse(parBox.Text.Trim(), out TmpValue);
            return TmpValue;
        }

        private void Set_Box(TextBox parBox, double parValue)
        {
            Calculating = true;
            parBox.Text = Num(parValue);
            Calculating = false;
        }

        private void Set_Percent(Label parLabel, double parValue, bool parColour)
        {
            parLabel.Text = Percent(parValue);
            if (parColour)
            {
                Colour_Label(parLabel, parValue);
            }
        }

        //Every percentage on this page is measured against the same base: what went into the
        //year, being the opening balance plus what was put in and transferred in.
        private double Base_Amount()
        {
            return Box(txtOpeningBalance) + Box(txtContribution) + Box(txtTransferIn);
        }

        private double Percent_Of_Base(double parValue)
        {
            double TmpBase = Base_Amount();
            if (TmpBase > 0)
            {
                return Math.Round(parValue / TmpBase * 100, 2);
            }
            return 0;
        }

        //---- the recalculation chain ----------------------------------------------
        //
        //Each derived box is given a default worked out from the ones it depends on, and the
        //user may then type over it.  A change upstream recomputes it again, which is what makes
        //the chain worth having: correcting the opening balance fixes everything below it.

        private void Recalc_PctInvReturns()
        {
            Set_Percent(LblPctInvReturns, Percent_Of_Base(Box(txtInvestmentReturns)), false);
        }

        private void Recalc_InvProfitOrLoss()
        {
            Set_Box(txtInvestmentProfitOrLoss,
                Math.Round(Box(txtInvestmentReturns) - Box(txtAdminFee) - Box(txtInsurancePremium)
                           - Box(txtGovermentTax) + Box(txtGovermentTaxBenefit), 2));
            Recalc_From_InvProfitOrLoss();
        }

        private void Recalc_From_InvProfitOrLoss()
        {
            Set_Percent(LblPctInvProfitOrLoss, Percent_Of_Base(Box(txtInvestmentProfitOrLoss)), true);
            Set_Box(txtTotalSurplusOrMinus,
                Math.Round(Box(txtContribution) + Box(txtInvestmentProfitOrLoss), 2));
            Recalc_From_TotalSurplus();
            Recalc_EndingBalance();
        }

        private void Recalc_From_TotalSurplus()
        {
            Set_Percent(LblPctTotalSurplusOrMinus, Percent_Of_Base(Box(txtTotalSurplusOrMinus)), true);
        }

        private void Recalc_EndingBalance()
        {
            Set_Box(txtEndingBalance,
                Math.Round(Box(txtOpeningBalance) + Box(txtContribution) + Box(txtTransferIn)
                           + Box(txtInvestmentProfitOrLoss) - Box(txtTransferOut), 2));
        }

        private void Recalc_All()
        {
            Recalc_PctInvReturns();
            Recalc_InvProfitOrLoss();
        }

        //---- what each box sets off ------------------------------------------------

        private void txtOpeningBalance_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_All();
        }

        private void txtContribution_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_All();
        }

        private void txtTransferIn_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_All();
        }

        private void txtInvestmentReturns_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_PctInvReturns();
            Recalc_InvProfitOrLoss();
        }

        private void txtAdminFee_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_InvProfitOrLoss();
        }

        private void txtInsurancePremium_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_InvProfitOrLoss();
        }

        private void txtGovermentTax_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_InvProfitOrLoss();
        }

        private void txtGovermentTaxBenefit_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_InvProfitOrLoss();
        }

        //nothing but the ending balance depends on what was transferred out - it leaves the
        //account rather than being part of what the fund had to work with
        private void txtTransferOut_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_EndingBalance();
        }

        //typed over by hand: everything downstream follows, but it is not recomputed itself
        private void txtInvestmentProfitOrLoss_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_From_InvProfitOrLoss();
        }

        private void txtTotalSurplusOrMinus_TextChanged(object sender, EventArgs e)
        {
            if (Filling || Calculating) { return; }
            Recalc_From_TotalSurplus();
        }

        private void txtEndingBalance_TextChanged(object sender, EventArgs e)
        {
            //nothing depends on the ending balance
        }

        //---- add, update, delete --------------------------------------------------

        private bool Valid_Amount(TextBox parBox, string parField, out double parValue)
        {
            parValue = 0;
            string TmpText = parBox.Text.Trim();
            if (TmpText == "")
            {
                MessageBox.Show(parField + " must be filled !", "Error Message");
                return false;
            }
            if (!double.TryParse(TmpText, out parValue))
            {
                MessageBox.Show(parField + " must be a number !", "Error Message");
                return false;
            }
            string TmpPlain = TmpText.Replace(",", "");
            int TmpDot = TmpPlain.IndexOf('.');
            if (TmpDot >= 0 && TmpPlain.Length - TmpDot - 1 > 2)
            {
                MessageBox.Show(parField + " cannot have more than 2 decimal places !", "Error Message");
                return false;
            }
            return true;
        }

        private bool Validate_Entry()
        {
            if (CmbFinYear.Text.Trim() == "")
            {
                MessageBox.Show("Financial Year must be selected ! Please set one up first in Financial Year Setup.", "Error Message");
                return false;
            }
            if (CmbSuperCode.Text.Trim() == "")
            {
                MessageBox.Show("Super Code must be selected ! Please set one up first in Super Setup.", "Error Message");
                return false;
            }
            if (CmbCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Currency must be selected !", "Error Message");
                return false;
            }

            double TmpValue;
            foreach (object[] pair in new object[][] {
                new object[] { txtOpeningBalance, "Opening Balance" },
                new object[] { txtContribution, "Contribution" },
                new object[] { txtTransferIn, "Transfer In" },
                new object[] { txtInvestmentReturns, "Investment Returns" },
                new object[] { txtAdminFee, "Admin Fee" },
                new object[] { txtInsurancePremium, "Insurance Premium" },
                new object[] { txtGovermentTax, "Goverment Tax" },
                new object[] { txtGovermentTaxBenefit, "Goverment Tax Benefit" },
                new object[] { txtInvestmentProfitOrLoss, "Investment Profit/Loss" },
                new object[] { txtTotalSurplusOrMinus, "Total Surplus/Minus" },
                new object[] { txtTransferOut, "Transfer Out" },
                new object[] { txtEndingBalance, "Ending Balance" } })
            {
                if (!Valid_Amount((TextBox)pair[0], (string)pair[1], out TmpValue))
                {
                    return false;
                }
            }
            return true;
        }

        //One row per super account per year, so that pair is what identifies it
        private bool Entry_Exists(string parYear, string parCode)
        {
            bool Found = false;
            Mdl1.Ssql = "select [Financial_Year] from TblSuperFinancialYear"
                      + " where [Financial_Year] = '" + parYear + "' and [Super_Code] = '" + parCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        private string Set_Clause()
        {
            return "[Currency] = '" + CmbCurrency.Text.Trim() + "', "
                 + "[Opening_Balance] = " + Num(Box(txtOpeningBalance)) + ", "
                 + "[Contribution] = " + Num(Box(txtContribution)) + ", "
                 + "[Transfer_In] = " + Num(Box(txtTransferIn)) + ", "
                 + "[Investment_Returns] = " + Num(Box(txtInvestmentReturns)) + ", "
                 + "[Percentage_Investment_Returns] = " + Num(Percent_Of_Base(Box(txtInvestmentReturns))) + ", "
                 + "[Admin_Fee] = " + Num(Box(txtAdminFee)) + ", "
                 + "[Insurance_Premium] = " + Num(Box(txtInsurancePremium)) + ", "
                 + "[Goverment_Tax] = " + Num(Box(txtGovermentTax)) + ", "
                 + "[Goverment_Tax_Benefit] = " + Num(Box(txtGovermentTaxBenefit)) + ", "
                 + "[Investment_Profit_Or_Loss] = " + Num(Box(txtInvestmentProfitOrLoss)) + ", "
                 + "[Percentage_Investment_Profit_Or_Loss] = " + Num(Percent_Of_Base(Box(txtInvestmentProfitOrLoss))) + ", "
                 + "[Total_Surplus_Or_Minus] = " + Num(Box(txtTotalSurplusOrMinus)) + ", "
                 + "[Percentage_Total_Surplus_Or_Minus] = " + Num(Percent_Of_Base(Box(txtTotalSurplusOrMinus))) + ", "
                 + "[Transfer_Out] = " + Num(Box(txtTransferOut)) + ", "
                 + "[Ending_Balance] = " + Num(Box(txtEndingBalance));
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate_Entry())
                {
                    return;
                }
                if (Entry_Exists(CmbFinYear.Text.Trim(), CmbSuperCode.Text.Trim()))
                {
                    MessageBox.Show("A record already exists for " + CmbSuperCode.Text.Trim()
                        + " in " + CmbFinYear.Text.Trim() + ". Select it from the list and update it instead.",
                        "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblSuperFinancialYear ([Financial_Year], [Super_Code], [Currency],"
                          + " [Opening_Balance], [Contribution], [Transfer_In], [Investment_Returns],"
                          + " [Percentage_Investment_Returns], [Admin_Fee], [Insurance_Premium],"
                          + " [Goverment_Tax], [Goverment_Tax_Benefit], [Investment_Profit_Or_Loss],"
                          + " [Percentage_Investment_Profit_Or_Loss], [Total_Surplus_Or_Minus],"
                          + " [Percentage_Total_Surplus_Or_Minus], [Transfer_Out], [Ending_Balance]) values ("
                          + "'" + CmbFinYear.Text.Trim() + "', "
                          + "'" + CmbSuperCode.Text.Trim() + "', "
                          + "'" + CmbCurrency.Text.Trim() + "', "
                          + Num(Box(txtOpeningBalance)) + ", "
                          + Num(Box(txtContribution)) + ", "
                          + Num(Box(txtTransferIn)) + ", "
                          + Num(Box(txtInvestmentReturns)) + ", "
                          + Num(Percent_Of_Base(Box(txtInvestmentReturns))) + ", "
                          + Num(Box(txtAdminFee)) + ", "
                          + Num(Box(txtInsurancePremium)) + ", "
                          + Num(Box(txtGovermentTax)) + ", "
                          + Num(Box(txtGovermentTaxBenefit)) + ", "
                          + Num(Box(txtInvestmentProfitOrLoss)) + ", "
                          + Num(Percent_Of_Base(Box(txtInvestmentProfitOrLoss))) + ", "
                          + Num(Box(txtTotalSurplusOrMinus)) + ", "
                          + Num(Percent_Of_Base(Box(txtTotalSurplusOrMinus))) + ", "
                          + Num(Box(txtTransferOut)) + ", "
                          + Num(Box(txtEndingBalance)) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + CmbSuperCode.Text.Trim()
                    + " in " + CmbFinYear.Text.Trim(), "Success");
                Get_Data();
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
                if (!RowSelected)
                {
                    MessageBox.Show("Please select a record from the list first !", "Error Message");
                    return;
                }
                if (!Validate_Entry())
                {
                    return;
                }
                //moving a row onto a year and account that already has one would make two
                if ((CmbFinYear.Text.Trim() != OrgFinYear || CmbSuperCode.Text.Trim() != OrgSuperCode)
                    && Entry_Exists(CmbFinYear.Text.Trim(), CmbSuperCode.Text.Trim()))
                {
                    MessageBox.Show("A record already exists for " + CmbSuperCode.Text.Trim()
                        + " in " + CmbFinYear.Text.Trim() + ".", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblSuperFinancialYear set "
                          + "[Financial_Year] = '" + CmbFinYear.Text.Trim() + "', "
                          + "[Super_Code] = '" + CmbSuperCode.Text.Trim() + "', "
                          + Set_Clause()
                          + " where [Financial_Year] = '" + OrgFinYear + "'"
                          + " and [Super_Code] = '" + OrgSuperCode + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + CmbSuperCode.Text.Trim()
                    + " in " + CmbFinYear.Text.Trim(), "Success");
                Get_Data();
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
                if (!RowSelected)
                {
                    MessageBox.Show("Please select a record from the list first !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblSuperFinancialYear"
                          + " where [Financial_Year] = '" + OrgFinYear + "'"
                          + " and [Super_Code] = '" + OrgSuperCode + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + OrgSuperCode + " in " + OrgFinYear, "Success");
                Get_Data();
                Clear_Entry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
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
