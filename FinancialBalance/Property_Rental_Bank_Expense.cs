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
    public partial class Property_Rental_Bank_Expense : Form
    {
        //true while the grid or the dropdowns are being refilled, so the rows and items being
        //added do not fire the handlers and type themselves back into the boxes
        bool Filling;

        //The Id of the row picked out of the list, so Update and Delete know which record they
        //are working on. The table carries its own AutoNumber key, which is what lets a
        //property hold more than one record for the same month: two rows can agree on every
        //other column and still be told apart. Zero until a row is picked.
        int OrgId;

        //index-aligned with CmbPropertyId: the name behind each id, so the label beside the
        //dropdown does not need a query every time the choice changes
        List<string> PropertyNames = new List<string>();

        //Month, Description and Currency are all reserved words in Access - an unbracketed one
        //fails with a bare "syntax error" that names nothing - so every column is bracketed
        //rather than only the ones that have to be.
        //Id is left out of this list: it is read back separately, and never written - the
        //database hands it out.
        const string Fields = "[Property_Id], [Month], [Description], [Currency],"
                            + " [Interest], [Bank_Fee], [Total_Expense]";

        public Property_Rental_Bank_Expense()
        {
            InitializeComponent();
        }

        private void Property_Rental_Bank_Expense_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Months();
            Fill_Property();
            Fill_Currency();
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

        private void MnETFStocksTaxInterest_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Tax_Interest ETF_Stocks_Tax_Interest = new ETF_Stocks_Tax_Interest();
            ETF_Stocks_Tax_Interest.Show();
            this.Close();
        }

        private void MnETFStocksFYRecon_Click(object sender, EventArgs e)
        {
            ETF_Stocks_FY_Reconciliation ETF_Stocks_FY_Reconciliation = new ETF_Stocks_FY_Reconciliation();
            ETF_Stocks_FY_Reconciliation.Show();
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

        //The shared Mdl1.Fill_Month offers three years, which is no use for a loan running over
        //a decade, so the year list is opened up the way the other property pages open up
        //theirs. Next year is offered too, since a charge can be entered in advance.
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

        //No blank first item, as on Property Rental Income: this page is a list of one
        //property's months, so it always has a property selected and opens on the first.
        private void Fill_Property()
        {
            CmbPropertyId.Items.Clear();
            PropertyNames.Clear();

            Mdl1.Ssql = "select [Property_Id], [Name] from TblProperty order by [Property_Id]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbPropertyId.Items.Add(Read_Text(reader["Property_Id"]));
                PropertyNames.Add(Read_Text(reader["Name"]));
            }
            reader.Close();

            if (CmbPropertyId.Items.Count > 0)
            {
                CmbPropertyId.SelectedIndex = 0;
            }
        }

        //Every currency on file is offered, but a property here is an Australian one, so the
        //list opens on AUD rather than on the shared Fill_Curr default of IDR.
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

        //The name beside the dropdown, so an id on its own never has to be recognised. Taken
        //from the list filled above rather than looked up again.
        private void Show_Property_Name()
        {
            int TmpAt = CmbPropertyId.SelectedIndex;
            LblPropertyName.Text = (TmpAt >= 0 && TmpAt < PropertyNames.Count
                                    ? PropertyNames[TmpAt] : "");
        }

        private void CmbPropertyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show_Property_Name();
            if (Filling)
            {
                return;
            }
            //a different property is a different list, so nothing from the old one is left
            //selected underneath it
            Get_Data();
            Clear_Entry();
        }

        private int Selected_Property()
        {
            int TmpId;
            if (!int.TryParse(CmbPropertyId.Text.Trim(), NumberStyles.Integer,
                              CultureInfo.InvariantCulture, out TmpId))
            {
                return 0;
            }
            return TmpId;
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

        //Every amount on this page is in one currency per row, and the page is an Australian
        //one, so the sign is not conditional the way it is on the multi-currency pages.
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
            gvExpense.Rows.Clear();
            gvExpense.Columns.Clear();
            gvExpense.ColumnCount = 6;
            string[] names = new string[] { "Month", "Description", "Currency", "Interest",
                                            "Bank Fee", "Total Expense" };
            int[] weights = new int[] { 11, 27, 8, 18, 18, 18 };
            for (int i = 0; i < 6; i++)
            {
                gvExpense.Columns[i].Name = names[i];
                gvExpense.Columns[i].HeaderText = names[i];
                gvExpense.Columns[i].FillWeight = weights[i];
                //the month and the currency centred, the description left, every amount right
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleRight;
                if (i == 0 || i == 2)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (i == 1)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                }
                gvExpense.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvExpense.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                double TmpTotal = 0;

                int TmpId = Selected_Property();
                if (TmpId == 0)
                {
                    Filling = false;
                    Show_Note();
                    Show_Total(TmpTotal);
                    return;
                }

                //newest month first, which is the one usually being looked at. Month is stored
                //yyyyMM, so a plain string sort is the same as a date sort.
                //newest month first, and within a month the order they were entered in - two
                //records for one month would otherwise come back in whatever order the
                //database felt like, and jump about as they were edited
                Mdl1.Ssql = "select [Id], " + Fields + " from TblPropertyRentalBankExpense"
                          + " where [Property_Id] = " + TmpId.ToString(CultureInfo.InvariantCulture)
                          + " order by [Month] Desc, [Id]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double TmpExpense = Read_Number(reader["Total_Expense"]);
                    gvExpense.Rows.Add(new string[] {
                        Month_Text(Read_Text(reader["Month"])),
                        Read_Text(reader["Description"]),
                        Read_Text(reader["Currency"]),
                        Money(Read_Number(reader["Interest"])),
                        Money(Read_Number(reader["Bank_Fee"])),
                        Money(TmpExpense) });

                    //the Id is not a column on screen, so it rides along on the row
                    gvExpense.Rows[gvExpense.Rows.Count - 1].Tag = Read_Text(reader["Id"]);

                    TmpTotal += TmpExpense;
                }
                reader.Close();

                gvExpense.ClearSelection();
                Filling = false;
                Show_Note();
                Show_Total(TmpTotal);
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //What the months listed come to. It is the Total Expense column added straight down, so
        //what is under the table and what is in it can never disagree - and it follows the
        //Property Id dropdown, since that is what decides the rows.
        private void Show_Total(double parTotal)
        {
            LblGrandTotal.Text = Money(parTotal);
        }

        private void Show_Note()
        {
            LblNote.Text = gvExpense.Rows.Count.ToString(CultureInfo.InvariantCulture) + " month(s)";
            LblNote.ForeColor = System.Drawing.Color.Black;
        }

        private void gvExpense_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvExpense.SelectedRows.Count > 0)
            {
                Row = gvExpense.SelectedRows[0];
            }
            else
            {
                Row = gvExpense.CurrentRow;
            }
            if (Row == null || Row.Tag == null)
            {
                return;
            }
            int TmpRowId;
            if (!int.TryParse(Row.Tag.ToString(), NumberStyles.Integer,
                              CultureInfo.InvariantCulture, out TmpRowId))
            {
                return;
            }
            Load_Record(TmpRowId);
        }

        //Read back from the table rather than off the grid: the amounts are dressed with a
        //dollar sign there and the month is the wrong way round to take apart again.
        private void Load_Record(int parRowId)
        {
            try
            {
                Mdl1.Ssql = "select [Id], " + Fields + " from TblPropertyRentalBankExpense"
                          + " where [Id] = " + parRowId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    return;
                }

                Filling = true;
                OrgId = parRowId;
                string TmpMonth = Read_Text(reader["Month"]);
                if (TmpMonth.Length == 6)
                {
                    CmbYear.Text = TmpMonth.Substring(0, 4);
                    CmbMonth.Text = TmpMonth.Substring(4, 2);
                }
                txtDescription.Text = Read_Text(reader["Description"]);
                CmbCurrency.Text = Read_Text(reader["Currency"]);
                txtInterest.Text = Box(Read_Number(reader["Interest"]));
                txtBankFee.Text = Box(Read_Number(reader["Bank_Fee"]));
                //the stored figure, not the addition - it may have been typed over when the
                //record was entered, and re-deriving it here would quietly undo that
                txtTotalExpense.Text = Box(Read_Number(reader["Total_Expense"]));
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

        //Mdl1.NumericKeyPress admits digits, a point and backspace, which is right for a charge
        //that cannot be negative. A total that has been typed over can be - a refunded month
        //reads as a credit - so the minus sign is let through here as well, once and only at
        //the front, so "1-2" cannot be typed.
        private void Signed_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox TmpBox = (TextBox)sender;
            if (e.KeyChar == '-')
            {
                bool TmpAtFront = (TmpBox.SelectionStart == 0);
                bool TmpHasOne = TmpBox.Text.Contains("-");
                //a selection that starts at 0 is about to replace whatever it covers, so an
                //existing sign inside it does not count against this one
                if (TmpAtFront && TmpBox.SelectionLength > 0)
                {
                    TmpHasOne = TmpBox.Text.Substring(TmpBox.SelectionLength).Contains("-");
                }
                e.Handled = !(TmpAtFront && !TmpHasOne);
                return;
            }
            Amount_KeyPress(sender, e);
        }

        private void Amount_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //changing either side fills the total in again, overwriting a typed one: the
            //figures it was worked out from have moved, so it is no longer the answer to
            //anything. Typing in the box afterwards is what makes an override stick.
            Fill_Total_Expense();
        }

        //Typed into directly, so the figure is left exactly as entered.
        private void TotalExpense_Changed(object sender, EventArgs e)
        {
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

        //What will be stored: whatever the box holds. Usually that is the addition below, put
        //there as the other two are typed, but a figure entered by hand stands - a month can
        //carry a charge that neither column accounts for.
        private double Total_Expense()
        {
            return Amount(txtTotalExpense);
        }

        //Interest plus bank fee, written into the box for the user to accept or type over.
        private void Fill_Total_Expense()
        {
            double TmpTotal = Math.Round(Amount(txtInterest) + Amount(txtBankFee), 2);
            txtTotalExpense.Text = Box(TmpTotal);
        }

        private string Num(double parValue)
        {
            return parValue.ToString("0.00", CultureInfo.InvariantCulture);
        }

        //Access takes a single quote as the end of a string, so one typed into the description
        //is doubled rather than left to break the statement.
        private string Quote(string parText)
        {
            return (parText == null ? "" : parText.Trim().Replace("'", "''"));
        }

        private void Clear_Entry()
        {
            Filling = true;
            OrgId = 0;
            Default_Month();
            txtDescription.Text = "";
            Default_Currency();
            txtInterest.Text = "";
            txtBankFee.Text = "";
            txtTotalExpense.Text = "";
            //ClearSelection fires SelectionChanged, and the handler falls back to CurrentRow
            //when nothing is selected - so clearing outside the guard loads straight back the
            //record it was clearing, leaving OrgId set.
            gvExpense.ClearSelection();
            Filling = false;
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Clear_Entry();
        }

        //---- add, update, delete ----------------------------------------------------

        private bool Read_Entry(out int parId, out string parMonth, out string parWhy)
        {
            parId = 0;
            parMonth = "";
            parWhy = "";

            parId = Selected_Property();
            if (parId == 0)
            {
                parWhy = "Please choose a Property Id.";
                return false;
            }

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

        //Whether the row picked out of the list is still there, which is all Update and
        //Delete need to know now that nothing else is refused.
        private bool Exists(int parRowId)
        {
            Mdl1.Ssql = "select [Id] from TblPropertyRentalBankExpense"
                      + " where [Id] = " + parRowId.ToString(CultureInfo.InvariantCulture);
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
                int TmpId;
                string TmpMonth;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpMonth, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                //a month can carry as many charges as the bank cared to make, so nothing is
                //refused here - the Id the database hands out keeps them apart
                Mdl1.Ssql = "Insert into TblPropertyRentalBankExpense (" + Fields + ") values ("
                          + TmpId.ToString(CultureInfo.InvariantCulture) + ", '"
                          + TmpMonth + "', '" + Quote(txtDescription.Text) + "', '"
                          + CmbCurrency.Text.Trim() + "', "
                          + Num(Amount(txtInterest)) + ", " + Num(Amount(txtBankFee)) + ", "
                          + Num(Total_Expense()) + ")";
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
                if (OrgId == 0)
                {
                    MessageBox.Show("Please select a record from the list first !", "Error Message");
                    return;
                }

                int TmpId;
                string TmpMonth;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpMonth, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }
                //nothing to refuse: the month may repeat, and the row being changed is
                //named by its Id rather than by what is in it
                if (!Exists(OrgId))
                {
                    MessageBox.Show("That record is no longer there.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblPropertyRentalBankExpense set"
                          + " [Month] = '" + TmpMonth + "',"
                          + " [Description] = '" + Quote(txtDescription.Text) + "',"
                          + " [Currency] = '" + CmbCurrency.Text.Trim() + "',"
                          + " [Interest] = " + Num(Amount(txtInterest)) + ","
                          + " [Bank_Fee] = " + Num(Amount(txtBankFee)) + ","
                          + " [Total_Expense] = " + Num(Total_Expense())
                          + " , [Property_Id] = " + TmpId.ToString(CultureInfo.InvariantCulture)
                          + " where [Id] = " + OrgId.ToString(CultureInfo.InvariantCulture);
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
                if (OrgId == 0)
                {
                    MessageBox.Show("Please select a record from the list first !", "Error Message");
                    return;
                }

                //the month is only in the question, not in the matching - two records for one
                //month would otherwise both go
                string TmpMonth = CmbYear.Text.Trim() + CmbMonth.Text.Trim();
                if (MessageBox.Show("Delete the selected record for " + Month_Text(TmpMonth) + " ?",
                        "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblPropertyRentalBankExpense"
                          + " where [Id] = " + OrgId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + Month_Text(TmpMonth), "Success");
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
