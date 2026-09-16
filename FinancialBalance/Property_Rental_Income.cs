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
    public partial class Property_Rental_Income : Form
    {
        //true while the grid or the dropdowns are being refilled, so the rows and items being
        //added do not fire the handlers and type themselves back into the boxes
        bool Filling;

        //The month whose row was picked out of the list, so Update and Delete know which record
        //they are working on - a record is identified by its property and its month together,
        //and the property comes from the dropdown. Empty until a row is picked.
        string OrgMonth = "";

        //index-aligned with CmbPropertyId: the name behind each id, so the label beside the
        //dropdown does not need a query every time the choice changes
        List<string> PropertyNames = new List<string>();

        //Currency is a reserved word in Access, so every column is bracketed rather than only
        //the ones that have to be - the same rule TblProperty is written under.
        const string Fields = "[Property_Id], [Rental_Month], [Currency],"
                            + " [Income], [Expense], [Profit_Loss]";

        public Property_Rental_Income()
        {
            InitializeComponent();
        }

        private void Property_Rental_Income_Load(object sender, EventArgs e)
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

        private void MnETFStocksTaxInterest_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Tax_Interest ETF_Stocks_Tax_Interest = new ETF_Stocks_Tax_Interest();
            ETF_Stocks_Tax_Interest.Show();
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

        private void MnSuperProcess_Click(object sender, EventArgs e)
        {
            Super_Financial_Year Super_Financial_Year = new Super_Financial_Year();
            Super_Financial_Year.Show();
            this.Close();
        }

        //---- the dropdowns ----------------------------------------------------------

        //The shared Mdl1.Fill_Month offers three years, which is no use for a property that has
        //been let for a decade, so the year list is opened up the way Property Purchase opens
        //up its own. Next year is offered too, since rent can be entered in advance.
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

            //opens on the month just gone, which is the one usually being entered
            DateTime TmpLast = DateTime.Now.AddMonths(-1);
            CmbMonth.Text = TmpLast.ToString("MM", CultureInfo.InvariantCulture);
            CmbYear.Text = TmpLast.ToString("yyyy", CultureInfo.InvariantCulture);
        }

        //No blank first item here, unlike the purchase and sale pages: this page is a list of
        //one property's months, so it always has a property selected and opens on the first.
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

        //A gain in green, a loss in red; breaking even is left alone
        private void Colour_Cell(DataGridViewCell parCell, double parValue)
        {
            System.Drawing.Color TmpColour = System.Drawing.Color.Black;
            if (parValue > 0)
            {
                TmpColour = System.Drawing.Color.Green;
            }
            else if (parValue < 0)
            {
                TmpColour = System.Drawing.Color.Red;
            }
            parCell.Style.ForeColor = TmpColour;
            parCell.Style.SelectionForeColor = TmpColour;
        }

        private void Colour_Control(Control parControl, double parValue)
        {
            if (parValue > 0)
            {
                parControl.ForeColor = System.Drawing.Color.Green;
            }
            else if (parValue < 0)
            {
                parControl.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                parControl.ForeColor = System.Drawing.Color.Black;
            }
        }

        //---- the list ---------------------------------------------------------------

        private void Clear_Grid()
        {
            gvRental.Rows.Clear();
            gvRental.Columns.Clear();
            gvRental.ColumnCount = 5;
            string[] names = new string[] { "Rental Month", "Currency", "Income", "Expense",
                                            "Profit/Loss" };
            int[] weights = new int[] { 16, 10, 24, 24, 26 };
            for (int i = 0; i < 5; i++)
            {
                gvRental.Columns[i].Name = names[i];
                gvRental.Columns[i].HeaderText = names[i];
                gvRental.Columns[i].FillWeight = weights[i];
                //the month and the currency centred, every amount right
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleRight;
                if (i <= 1)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                gvRental.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvRental.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
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

                //newest month first, which is the one usually being looked at. Rental_Month is
                //stored yyyyMM, so a plain string sort is the same as a date sort.
                Mdl1.Ssql = "select " + Fields + " from TblPropertyRentalIncome"
                          + " where [Property_Id] = " + TmpId.ToString(CultureInfo.InvariantCulture)
                          + " order by [Rental_Month] Desc";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double TmpProfit = Read_Number(reader["Profit_Loss"]);
                    gvRental.Rows.Add(new string[] {
                        Month_Text(Read_Text(reader["Rental_Month"])),
                        Read_Text(reader["Currency"]),
                        Money(Read_Number(reader["Income"])),
                        Money(Read_Number(reader["Expense"])),
                        Money(TmpProfit) });

                    DataGridViewRow TmpRow = gvRental.Rows[gvRental.Rows.Count - 1];
                    Colour_Cell(TmpRow.Cells[4], TmpProfit);
                    //the stored month is not a column, so it rides along on the row
                    TmpRow.Tag = Read_Text(reader["Rental_Month"]);

                    TmpTotal += TmpProfit;
                }
                reader.Close();

                gvRental.ClearSelection();
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

        //What the months listed come to. It is the Profit/Loss column added straight
        //down, so what is under the table and what is in it can never disagree - and it
        //follows the Property Id dropdown, since that is what decides the rows.
        private void Show_Total(double parTotal)
        {
            LblTotalProfitLoss.Text = Money(parTotal);
            Colour_Control(LblTotalProfitLoss, parTotal);
        }

        private void Show_Note()
        {
            LblNote.Text = gvRental.Rows.Count.ToString(CultureInfo.InvariantCulture) + " month(s)";
            LblNote.ForeColor = System.Drawing.Color.Black;
        }

        private void gvRental_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvRental.SelectedRows.Count > 0)
            {
                Row = gvRental.SelectedRows[0];
            }
            else
            {
                Row = gvRental.CurrentRow;
            }
            if (Row == null || Row.Tag == null)
            {
                return;
            }
            Load_Record(Row.Tag.ToString());
        }

        //Read back from the table rather than off the grid: the amounts are dressed with a
        //dollar sign there and the month is the wrong way round to take apart again.
        private void Load_Record(string parMonth)
        {
            try
            {
                int TmpId = Selected_Property();
                if (TmpId == 0)
                {
                    return;
                }

                Mdl1.Ssql = "select " + Fields + " from TblPropertyRentalIncome"
                          + " where [Property_Id] = " + TmpId.ToString(CultureInfo.InvariantCulture)
                          + " and [Rental_Month] = '" + parMonth + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    return;
                }

                Filling = true;
                OrgMonth = Read_Text(reader["Rental_Month"]);
                if (OrgMonth.Length == 6)
                {
                    CmbYear.Text = OrgMonth.Substring(0, 4);
                    CmbMonth.Text = OrgMonth.Substring(4, 2);
                }
                CmbCurrency.Text = Read_Text(reader["Currency"]);
                txtIncome.Text = Box(Read_Number(reader["Income"]));
                txtExpense.Text = Box(Read_Number(reader["Expense"]));
                //the stored figure, not the subtraction - it may have been typed over when
                //the record was entered, and re-deriving it here would quietly undo that
                txtProfitLoss.Text = Box(Read_Number(reader["Profit_Loss"]));
                Filling = false;
                reader.Close();

                Colour_Profit();
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

        //Mdl1.NumericKeyPress admits digits, a point and backspace, which is right for an
        //amount that cannot be negative. A loss can be, so the minus sign is let through
        //here as well - once, and only at the front, so "1-2" cannot be typed.
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
            //changing either side fills the profit in again, overwriting a typed one: the
            //figures it was worked out from have moved, so it is no longer the answer to
            //anything. Typing in the box afterwards is what makes an override stick.
            Fill_Profit();
        }

        //Typed into directly, so the figure is left exactly as entered - only the colour
        //follows it.
        private void ProfitLoss_Changed(object sender, EventArgs e)
        {
            Colour_Profit();
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

        //What will be stored: whatever the box holds. Usually that is the subtraction below,
        //put there as the other two are typed, but a figure entered by hand stands - a month
        //can have something in it that neither column accounts for.
        private double Profit()
        {
            return Amount(txtProfitLoss);
        }

        //Income less expense, written into the box for the user to accept or type over.
        private void Fill_Profit()
        {
            double TmpProfit = Math.Round(Amount(txtIncome) - Amount(txtExpense), 2);
            txtProfitLoss.Text = Box(TmpProfit);
        }

        private void Colour_Profit()
        {
            Colour_Control(txtProfitLoss, Amount(txtProfitLoss));
        }

        private string Num(double parValue)
        {
            return parValue.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void Clear_Entry()
        {
            Filling = true;
            OrgMonth = "";
            DateTime TmpLast = DateTime.Now.AddMonths(-1);
            CmbMonth.Text = TmpLast.ToString("MM", CultureInfo.InvariantCulture);
            CmbYear.Text = TmpLast.ToString("yyyy", CultureInfo.InvariantCulture);
            Default_Currency();
            txtIncome.Text = "";
            txtExpense.Text = "";
            txtProfitLoss.Text = "";
            //ClearSelection fires SelectionChanged, and the handler falls back to CurrentRow
            //when nothing is selected - so clearing outside the guard loads straight back the
            //record it was clearing, leaving OrgMonth set.
            gvRental.ClearSelection();
            Filling = false;

            Colour_Profit();
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
                parWhy = "Rental Month needs a month and a year.";
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

        private bool Exists(int parId, string parMonth)
        {
            Mdl1.Ssql = "select [Rental_Month] from TblPropertyRentalIncome"
                      + " where [Property_Id] = " + parId.ToString(CultureInfo.InvariantCulture)
                      + " and [Rental_Month] = '" + parMonth + "'";
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

                //one record per property per month, so a second is an update rather than a row
                if (Exists(TmpId, TmpMonth))
                {
                    MessageBox.Show("Property Id " + TmpId.ToString(CultureInfo.InvariantCulture)
                        + " already has a record for " + Month_Text(TmpMonth) + "."
                        + Environment.NewLine + "Pick it from the list and use Update.",
                        "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblPropertyRentalIncome (" + Fields + ") values ("
                          + TmpId.ToString(CultureInfo.InvariantCulture) + ", '"
                          + TmpMonth + "', '" + CmbCurrency.Text.Trim() + "', "
                          + Num(Amount(txtIncome)) + ", " + Num(Amount(txtExpense)) + ", "
                          + Num(Profit()) + ")";
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

                int TmpId;
                string TmpMonth;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpMonth, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }
                //moving the record onto a month that already has one would make two
                if (TmpMonth != OrgMonth && Exists(TmpId, TmpMonth))
                {
                    MessageBox.Show("Property Id " + TmpId.ToString(CultureInfo.InvariantCulture)
                        + " already has a record for " + Month_Text(TmpMonth) + ".", "Error Message");
                    return;
                }
                if (!Exists(TmpId, OrgMonth))
                {
                    MessageBox.Show("Data not found for " + Month_Text(OrgMonth), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblPropertyRentalIncome set"
                          + " [Rental_Month] = '" + TmpMonth + "',"
                          + " [Currency] = '" + CmbCurrency.Text.Trim() + "',"
                          + " [Income] = " + Num(Amount(txtIncome)) + ","
                          + " [Expense] = " + Num(Amount(txtExpense)) + ","
                          + " [Profit_Loss] = " + Num(Profit())
                          + " where [Property_Id] = " + TmpId.ToString(CultureInfo.InvariantCulture)
                          + " and [Rental_Month] = '" + OrgMonth + "'";
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

                int TmpId = Selected_Property();
                if (TmpId == 0)
                {
                    return;
                }
                if (MessageBox.Show("Delete the record for " + Month_Text(OrgMonth) + " ?",
                        "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblPropertyRentalIncome"
                          + " where [Property_Id] = " + TmpId.ToString(CultureInfo.InvariantCulture)
                          + " and [Rental_Month] = '" + OrgMonth + "'";
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
