using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FinancialBalance
{
    public partial class ETF_Stocks_Tax_Interest : Form
    {
        //true while the grid or the dropdowns are being refilled, so the rows and items being
        //added do not fire the handlers and type themselves back into the boxes
        bool Filling;

        //The month whose row was picked out of the list, so Update and Delete know which record
        //they are working on. Empty until a row is picked.
        string OrgMonth = "";

        //Month and Currency are both reserved words in Access - an unbracketed one fails with a
        //bare "syntax error" that names nothing - so every column is bracketed rather than only
        //the ones that have to be.
        const string Fields = "[Month], [Currency], [Interest]";

        public ETF_Stocks_Tax_Interest()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Tax_Interest_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Months();
            Fill_Currency();
            Fill_Financial_Year();
            Filling = false;

            Get_Data();
            Clear_Entry();
        }

        //---- the menu ---------------------------------------------------------------

        private void MnDailyInput_Click(object sender, EventArgs e)
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

        private void MnPropertyRentalBankExpense_Click(object sender, EventArgs e)
        {
            Property_Rental_Bank_Expense Property_Rental_Bank_Expense = new Property_Rental_Bank_Expense();
            Property_Rental_Bank_Expense.Show();
            this.Close();
        }

        private void MnPropertyRentalExpense_Click(object sender, EventArgs e)
        {
            Property_Rental_Expense Property_Rental_Expense = new Property_Rental_Expense();
            Property_Rental_Expense.Show();
            this.Close();
        }

        private void MnPropertySetup_Click(object sender, EventArgs e)
        {
            Setup_Property Setup_Property = new Setup_Property();
            Setup_Property.Show();
            this.Close();
        }

        private void MnPropertyPurchase_Click(object sender, EventArgs e)
        {
            Property_Purchase Property_Purchase = new Property_Purchase();
            Property_Purchase.Show();
            this.Close();
        }

        private void MnPropertySale_Click(object sender, EventArgs e)
        {
            Property_Sale Property_Sale = new Property_Sale();
            Property_Sale.Show();
            this.Close();
        }

        private void MnPropertyRentalIncome_Click(object sender, EventArgs e)
        {
            Property_Rental_Income Property_Rental_Income = new Property_Rental_Income();
            Property_Rental_Income.Show();
            this.Close();
        }

        private void MnSuperProcess_Click(object sender, EventArgs e)
        {
            Super_Financial_Year Super_Financial_Year = new Super_Financial_Year();
            Super_Financial_Year.Show();
            this.Close();
        }

        //---- the dropdowns ----------------------------------------------------------

        //The shared Mdl1.Fill_Month offers three years, which is no use for interest going back
        //over the life of a loan, so the year list is opened up the way the other pages open up
        //theirs. Next year is offered too, since interest can be entered in advance.
        private void Fill_Months()
        {
            CmbMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                CmbMonth.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
            }

            CmbYear.Items.Clear();
            for (int i = DateTime.Now.Year + 1; i >= 1990; i--)
            {
                CmbYear.Items.Add(i.ToString("0000", CultureInfo.InvariantCulture));
            }

            Default_Month();
        }

        //opens on the month just gone, which is the one usually being entered
        private void Default_Month()
        {
            DateTime TmpLast = DateTime.Now.AddMonths(-1);
            CmbMonth.Text = TmpLast.ToString("MM", CultureInfo.InvariantCulture);
            CmbYear.Text = TmpLast.ToString("yyyy", CultureInfo.InvariantCulture);
        }

        //Every currency on file is offered. Interest deductible against Australian tax is paid
        //in dollars, so the list opens on AUD rather than on the shared Fill_Curr default.
        private void Fill_Currency()
        {
            Mdl1.Fill_Curr(CmbCurrency);
            Default_Currency();
        }

        //CmbCurrency is a DropDownList, so assigning a code that is not among its items does
        //nothing at all rather than failing - which is the wanted behaviour: a database with no
        //AUD set up simply keeps whatever Fill_Curr chose.
        private void Default_Currency()
        {
            CmbCurrency.Text = "AUD";
        }

        //Most recently closed year first, which is the one usually being looked at.
        private void Fill_Financial_Year()
        {
            CmbFinYear.Items.Clear();
            CmbFinYear.Items.Add("All");

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFinYear.Items.Add(Read_Text(reader["Name"]));
            }
            reader.Close();

            CmbFinYear.Text = "All";
        }

        private void CmbFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //a different year is a different list, so nothing from the old one is left
            //selected underneath it
            Get_Data();
            Clear_Entry();
        }

        //The chosen year's first and last month. The year's dates are stored yyyyMMdd and
        //a month here is yyyyMM, so the first six characters of each date are the months
        //that bracket it - an Australian year running 01-Jul-2025 to 30-Jun-2026 covers
        //202507 through 202606.
        private bool Financial_Year_Months(out string parFrom, out string parTo)
        {
            parFrom = "";
            parTo = "";

            string TmpName = CmbFinYear.Text.Trim();
            if (TmpName == "" || TmpName == "All")
            {
                return false;
            }

            Mdl1.Ssql = "select [Start_Date], [End_Date] from TblFinancialYear"
                      + " where [Name] = '" + TmpName + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = false;
            if (reader.Read())
            {
                string TmpStart = Read_Text(reader["Start_Date"]);
                string TmpEnd = Read_Text(reader["End_Date"]);
                if (TmpStart.Length >= 6 && TmpEnd.Length >= 6)
                {
                    parFrom = TmpStart.Substring(0, 6);
                    parTo = TmpEnd.Substring(0, 6);
                    Found = true;
                }
            }
            reader.Close();
            return Found;
        }

        //A year with no dates set up narrows nothing rather than hiding everything.
        private string Year_Filter()
        {
            string TmpFrom;
            string TmpTo;
            if (!Financial_Year_Months(out TmpFrom, out TmpTo))
            {
                return "";
            }
            return " where [Month] >= '" + TmpFrom + "' and [Month] <= '" + TmpTo + "'";
        }

        //---- reading what comes back ------------------------------------------------

        private string Read_Text(object parValue)
        {
            return (parValue == null || parValue == DBNull.Value ? "" : parValue.ToString().Trim());
        }

        private double Read_Number(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            double TmpValue;
            if (double.TryParse(parValue.ToString(), NumberStyles.Any,
                                CultureInfo.InvariantCulture, out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        //---- formatting -------------------------------------------------------------

        //One currency per row, and interest cannot be negative, so the sign is not conditional
        //the way it is on the multi-currency pages.
        private string Money(double parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        //yyyyMM as stored, read back as MMM-yyyy. Mdl1.toLongMonth gives the full month name;
        //a list of twelve rows a year reads better abbreviated.
        private string Month_Text(string parYyyyMM)
        {
            string TmpText = (parYyyyMM == null ? "" : parYyyyMM.Trim());
            if (TmpText.Length != 6)
            {
                return TmpText;
            }
            DateTime TmpDate;
            if (!DateTime.TryParseExact(TmpText, "yyyyMM", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out TmpDate))
            {
                return TmpText;
            }
            return TmpDate.ToString("MMM-yyyy", CultureInfo.InvariantCulture);
        }

        //---- the list ---------------------------------------------------------------

        private void Clear_Grid()
        {
            gvInterest.Rows.Clear();
            gvInterest.Columns.Clear();
            gvInterest.ColumnCount = 3;
            string[] names = new string[] { "Month", "Currency", "Interest" };
            int[] weights = new int[] { 25, 20, 55 };
            for (int i = 0; i < 3; i++)
            {
                gvInterest.Columns[i].Name = names[i];
                gvInterest.Columns[i].HeaderText = names[i];
                gvInterest.Columns[i].FillWeight = weights[i];
                //the month and the currency centred, the amount right
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleRight;
                if (i <= 1)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                gvInterest.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvInterest.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                //newest month first, which is the one usually being looked at. Month is stored
                //yyyyMM, so a plain string sort is the same as a date sort.
                double TmpTotal = 0;

                Mdl1.Ssql = "select " + Fields + " from TblETFStocksTaxDeductableInterest"
                          + Year_Filter()
                          + " order by [Month] Desc";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double TmpInterest = Read_Number(reader["Interest"]);
                    gvInterest.Rows.Add(new string[] {
                        Month_Text(Read_Text(reader["Month"])),
                        Read_Text(reader["Currency"]),
                        Money(TmpInterest) });

                    TmpTotal += TmpInterest;

                    //the stored month is not shown as it is stored, so it rides along on the row
                    gvInterest.Rows[gvInterest.Rows.Count - 1].Tag = Read_Text(reader["Month"]);
                }
                reader.Close();

                gvInterest.ClearSelection();
                Filling = false;

                LblTotalInterest.Text = Money(TmpTotal);

                //What the deduction is worth, rather than what was paid.  Interest that is
                //deductible comes off income before tax, so it is worth whatever that income
                //would have been taxed at - which is the share the bands in TblTaxAllocation
                //take between them, the same factor both tax calculators work from.
                bool TmpKnown;
                double TmpTaken = Taken(out TmpKnown);
                double TmpDeductable = Math.Round(TmpTotal * TmpTaken, 2);
                LblTaxDeductable.Text = (TmpKnown ? Money(TmpDeductable) : "-");

                //What the borrowing actually costs: what was paid, less what the deduction
                //gives back.  Without bands on file the deduction is unknown rather than
                //nothing, so the net is unknown too - saying it equals the interest would
                //read as "no relief", which is a different claim.
                LblRealInterest.Text = (TmpKnown ? Money(Math.Round(TmpTotal - TmpDeductable, 2)) : "-");

                Show_Note(TmpTaken, TmpKnown);
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //The share of income the bands in TblTaxAllocation take between them, as a fraction.
        //Each band covers its allocation of the income and is taxed at its own rate, so what
        //they take together does not depend on the amount - which is what lets one figure
        //stand for the lot.  parKnown is false when the table is empty, because nothing on
        //file is not the same as a rate of nothing.
        private double Taken(out bool parKnown)
        {
            double TmpTaken = 0;
            int TmpRows = 0;

            Mdl1.Ssql = "select [Tax_Rate], [Allocation] from TblTaxAllocation";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TmpTaken += (Read_Number(reader["Allocation"]) / 100)
                          * (Read_Number(reader["Tax_Rate"]) / 100);
                TmpRows++;
            }
            reader.Close();

            parKnown = (TmpRows > 0);
            return TmpTaken;
        }

        //Says which year is narrowing the list, so a short one is explainable, and what the
        //deduction is being valued at
        private void Show_Note(double parTaken, bool parKnown)
        {
            string TmpText = gvInterest.Rows.Count.ToString(CultureInfo.InvariantCulture) + " month(s)";
            string TmpYear = CmbFinYear.Text.Trim();
            if (TmpYear != "" && TmpYear != "All")
            {
                string TmpFrom;
                string TmpTo;
                if (Financial_Year_Months(out TmpFrom, out TmpTo))
                {
                    TmpText = TmpText + "   -   financial year " + TmpYear
                            + "  (" + Month_Text(TmpFrom) + " to " + Month_Text(TmpTo) + ")";
                }
                else
                {
                    TmpText = TmpText + "   -   financial year " + TmpYear
                            + "  (no dates set up, so no filter applied)";
                }
            }

            //what the second total is being valued at, and why it is blank when it is
            if (parKnown)
            {
                TmpText = TmpText + "   -   the deduction is worth "
                        + (parTaken * 100).ToString("#,##0.00", CultureInfo.InvariantCulture)
                        + " % of it, from Tax Allocation Setup";
            }
            else
            {
                TmpText = TmpText + "   -   Tax Allocation Setup holds no bands, so what the"
                        + " deduction is worth cannot be said";
            }

            LblNote.Text = TmpText;
            LblNote.ForeColor = System.Drawing.Color.Black;
        }

        private void gvInterest_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvInterest.SelectedRows.Count > 0)
            {
                Row = gvInterest.SelectedRows[0];
            }
            else
            {
                Row = gvInterest.CurrentRow;
            }
            if (Row == null || Row.Tag == null)
            {
                return;
            }
            Load_Record(Row.Tag.ToString());
        }

        //Read back from the table rather than off the grid: the amount is dressed with a dollar
        //sign there and the month is the wrong way round to take apart again.
        private void Load_Record(string parMonth)
        {
            try
            {
                Mdl1.Ssql = "select " + Fields + " from TblETFStocksTaxDeductableInterest"
                          + " where [Month] = '" + parMonth + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    return;
                }

                Filling = true;
                OrgMonth = Read_Text(reader["Month"]);
                if (OrgMonth.Length == 6)
                {
                    CmbYear.Text = OrgMonth.Substring(0, 4);
                    CmbMonth.Text = OrgMonth.Substring(4, 2);
                }
                CmbCurrency.Text = Read_Text(reader["Currency"]);
                txtInterest.Text = Box(Read_Number(reader["Interest"]));
                Filling = false;
                reader.Close();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the entry area ---------------------------------------------------------

        //A box holds a bare figure - no sign, no grouping - since that is what may be typed
        //back into it.
        private string Box(double parValue)
        {
            return parValue.ToString("0.00", CultureInfo.InvariantCulture);
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

        private double Amount(TextBox parBox)
        {
            string TmpText = parBox.Text.Trim().Replace("$", "").Replace(",", "");
            double TmpValue;
            if (!double.TryParse(TmpText, NumberStyles.Any, CultureInfo.InvariantCulture, out TmpValue))
            {
                return 0;
            }
            return Math.Round(TmpValue, 2);
        }

        private string Num(double parValue)
        {
            return parValue.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void Clear_Entry()
        {
            Filling = true;
            OrgMonth = "";
            Default_Month();
            Default_Currency();
            txtInterest.Text = "";
            //ClearSelection fires SelectionChanged, and the handler falls back to CurrentRow
            //when nothing is selected - so clearing outside the guard loads straight back the
            //record it was clearing, leaving OrgMonth set.
            gvInterest.ClearSelection();
            Filling = false;
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Clear_Entry();
        }

        //---- add, update, delete ----------------------------------------------------

        private bool Read_Entry(out string parMonth, out string parWhy)
        {
            parMonth = "";
            parWhy = "";

            string TmpMM = CmbMonth.Text.Trim();
            string TmpYear = CmbYear.Text.Trim();
            if (TmpMM == "" || TmpYear == "")
            {
                parWhy = "Month needs a month and a year.";
                return false;
            }
            parMonth = TmpYear + TmpMM;

            if (CmbCurrency.Text.Trim() == "")
            {
                parWhy = "Please choose a Currency.";
                return false;
            }
            return true;
        }

        private bool Exists(string parMonth)
        {
            Mdl1.Ssql = "select [Month] from TblETFStocksTaxDeductableInterest"
                      + " where [Month] = '" + parMonth + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = reader.Read();
            reader.Close();
            return Found;
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpMonth;
                string TmpWhy;
                if (!Read_Entry(out TmpMonth, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                //one figure per month, so a second is an update rather than another row
                if (Exists(TmpMonth))
                {
                    MessageBox.Show(Month_Text(TmpMonth) + " already has an interest record."
                        + Environment.NewLine + "Pick it from the list and use Update.",
                        "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksTaxDeductableInterest (" + Fields + ") values ('"
                          + TmpMonth + "', '" + CmbCurrency.Text.Trim() + "', "
                          + Num(Amount(txtInterest)) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + Month_Text(TmpMonth), "Success");
                Get_Data();
                Clear_Entry();
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
                if (OrgMonth == "")
                {
                    MessageBox.Show("Please select a month from the list first !", "Error Message");
                    return;
                }

                string TmpMonth;
                string TmpWhy;
                if (!Read_Entry(out TmpMonth, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }
                //moving the record onto a month that already has one would make two
                if (TmpMonth != OrgMonth && Exists(TmpMonth))
                {
                    MessageBox.Show(Month_Text(TmpMonth) + " already has an interest record.",
                        "Error Message");
                    return;
                }
                if (!Exists(OrgMonth))
                {
                    MessageBox.Show("Data not found for " + Month_Text(OrgMonth), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblETFStocksTaxDeductableInterest set"
                          + " [Month] = '" + TmpMonth + "',"
                          + " [Currency] = '" + CmbCurrency.Text.Trim() + "',"
                          + " [Interest] = " + Num(Amount(txtInterest))
                          + " where [Month] = '" + OrgMonth + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + Month_Text(TmpMonth), "Success");
                Get_Data();
                Clear_Entry();
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
                if (OrgMonth == "")
                {
                    MessageBox.Show("Please select a month from the list first !", "Error Message");
                    return;
                }
                if (MessageBox.Show("Delete the interest record for " + Month_Text(OrgMonth) + " ?",
                        "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksTaxDeductableInterest"
                          + " where [Month] = '" + OrgMonth + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + Month_Text(OrgMonth), "Success");
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
