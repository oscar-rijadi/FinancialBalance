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
    public partial class Property_Rental_Expense : Form
    {
        //true while the grid or the dropdowns are being refilled, so the rows and items being
        //added do not fire the handlers and type themselves back into the boxes
        bool Filling;

        //What identifies the row picked out of the list, so Update and Delete know which record
        //they are working on. This table has no id of its own, so a record is its property, its
        //type and the date it was paid together - see the note in the README. Empty until a row
        //is picked.
        string OrgType = "";
        string OrgDate = "";

        //index-aligned with CmbPropertyId: the name behind each id, so the label beside the
        //dropdown does not need a query every time the choice changes
        List<string> PropertyNames = new List<string>();

        //Type, Description and Currency are all reserved words in Access - an unbracketed one
        //fails with a bare "syntax error" that names nothing - so every column is bracketed
        //rather than only the ones that have to be.
        const string Fields = "[Property_Id], [Type], [Description], [Paid_Date],"
                            + " [Currency], [Expense]";

        public Property_Rental_Expense()
        {
            InitializeComponent();
        }

        private void Property_Rental_Expense_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Dates();
            Fill_Property();
            Fill_Type();
            Fill_Currency();
            Filling = false;

            monthCalendar1.Hide();
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

        private void MnPropertyRentalBankExpense_Click(object sender, EventArgs e)
        {
            Property_Rental_Bank_Expense Property_Rental_Bank_Expense = new Property_Rental_Bank_Expense();
            Property_Rental_Bank_Expense.Show();
            this.Close();
        }

        private void MnSuperProcess_Click(object sender, EventArgs e)
        {
            Super_Financial_Year Super_Financial_Year = new Super_Financial_Year();
            Super_Financial_Year.Show();
            this.Close();
        }

        //---- the dropdowns ----------------------------------------------------------

        //As on Property Purchase: the shared Mdl1.Fill_Date offers three years, which is no use
        //for a property held for decades, so the year list is opened up.
        private void Fill_Dates()
        {
            CmbPaidDD.Items.Clear();
            CmbPaidDD.Items.Add("");
            for (int i = 1; i <= 31; i++)
            {
                CmbPaidDD.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
            }

            CmbPaidMM.Items.Clear();
            CmbPaidMM.Items.Add("");
            for (int i = 1; i <= 12; i++)
            {
                CmbPaidMM.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
            }

            CmbPaidYear.Items.Clear();
            CmbPaidYear.Items.Add("");
            for (int i = DateTime.Now.Year; i >= 1950; i--)
            {
                CmbPaidYear.Items.Add(i.ToString("0000", CultureInfo.InvariantCulture));
            }
        }

        //No blank first item, as on the other rental pages: this page is a list of one
        //property's expenses, so it always has a property selected and opens on the first.
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

        //The kinds of expense come from their own setup page rather than being typed, so a type
        //cannot be spelled two ways across two records.
        private void Fill_Type()
        {
            CmbType.Items.Clear();
            CmbType.Items.Add("");

            Mdl1.Ssql = "select [Name] from TblPropertyRentalExpenseType order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbType.Items.Add(Read_Text(reader["Name"]));
            }
            reader.Close();

            CmbType.Text = "";
        }

        //Every currency on file is offered, but a property here is an Australian one, so the
        //list opens on AUD rather than on the shared Fill_Curr default of IDR.
        private void Fill_Currency()
        {
            Mdl1.Fill_Curr(CmbCurrency);
            Default_Currency();
        }

        //CmbCurrency is a DropDownList, so assigning a code that is not among its items does
        //nothing at all rather than failing - which is the wanted behaviour here.
        private void Default_Currency()
        {
            CmbCurrency.Text = "AUD";
        }

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

        //---- the calendar -----------------------------------------------------------
        //
        //The same arrangement Daily Input has, and the purchase and sale pages: three dropdowns
        //and a ".." beside them that opens a MonthCalendar, which fills them in and hides again.
        //Only one date here, so there is nothing to remember about which asked for it.

        private void CmdPaidCal_Click(object sender, EventArgs e)
        {
            //Held to the same range the year dropdown carries. Assigning a value that is not in
            //a DropDownList does nothing at all, silently, so an unbounded calendar could appear
            //to work while leaving the date unchanged.
            monthCalendar1.MinDate = new DateTime(1950, 1, 1);
            monthCalendar1.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

            //the date may not have been filled in yet, and blank does not parse
            DateTime TmpStart;
            string TmpText = CmbPaidDD.Text.Trim() + CmbPaidMM.Text.Trim() + CmbPaidYear.Text.Trim();
            if (TmpText.Length != 8
                || !DateTime.TryParseExact(TmpText, "ddMMyyyy", CultureInfo.InvariantCulture,
                                           DateTimeStyles.None, out TmpStart))
            {
                TmpStart = DateTime.Today;
            }
            if (TmpStart < monthCalendar1.MinDate) { TmpStart = monthCalendar1.MinDate; }
            if (TmpStart > monthCalendar1.MaxDate) { TmpStart = monthCalendar1.MaxDate; }

            monthCalendar1.SetDate(TmpStart);
            monthCalendar1.BringToFront();
            monthCalendar1.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            CmbPaidDD.Text = e.Start.Day.ToString("00", CultureInfo.InvariantCulture);
            CmbPaidMM.Text = e.Start.Month.ToString("00", CultureInfo.InvariantCulture);
            CmbPaidYear.Text = e.Start.Year.ToString("0000", CultureInfo.InvariantCulture);
            monthCalendar1.Hide();
        }

        private void Set_Date(string parYyyyMMdd)
        {
            string TmpText = (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
            if (TmpText.Length != 8)
            {
                CmbPaidDD.Text = "";
                CmbPaidMM.Text = "";
                CmbPaidYear.Text = "";
                return;
            }
            CmbPaidYear.Text = TmpText.Substring(0, 4);
            CmbPaidMM.Text = TmpText.Substring(4, 2);
            CmbPaidDD.Text = TmpText.Substring(6, 2);
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

        private string Money(double parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        private string Long_Date(string parYyyyMMdd)
        {
            string TmpText = (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
            if (TmpText.Length != 8)
            {
                return "";
            }
            DateTime TmpDate;
            if (!DateTime.TryParseExact(TmpText, "yyyyMMdd", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out TmpDate))
            {
                return "";
            }
            return TmpDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
        }

        //---- the list ---------------------------------------------------------------

        private void Clear_Grid()
        {
            gvExpense.Rows.Clear();
            gvExpense.Columns.Clear();
            gvExpense.ColumnCount = 5;
            string[] names = new string[] { "Paid Date", "Type", "Description", "Currency",
                                            "Expense" };
            int[] weights = new int[] { 12, 20, 38, 8, 22 };
            for (int i = 0; i < 5; i++)
            {
                gvExpense.Columns[i].Name = names[i];
                gvExpense.Columns[i].HeaderText = names[i];
                gvExpense.Columns[i].FillWeight = weights[i];
                //the date and the currency centred, the type and description left, the amount right
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                if (i == 0 || i == 3)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (i == 4)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleRight;
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
                    Show_Note(TmpTotal);
                    return;
                }

                //newest first, which is the one usually being looked at. Paid_Date is stored
                //yyyyMMdd, so a plain string sort is the same as a date sort.
                Mdl1.Ssql = "select " + Fields + " from TblPropertyRentalExpense"
                          + " where [Property_Id] = " + TmpId.ToString(CultureInfo.InvariantCulture)
                          + " order by [Paid_Date] Desc, [Type]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double TmpExpense = Read_Number(reader["Expense"]);
                    gvExpense.Rows.Add(new string[] {
                        Long_Date(Read_Text(reader["Paid_Date"])),
                        Read_Text(reader["Type"]),
                        Read_Text(reader["Description"]),
                        Read_Text(reader["Currency"]),
                        Money(TmpExpense) });

                    //what identifies the row is not shown as it is stored, so it rides along
                    gvExpense.Rows[gvExpense.Rows.Count - 1].Tag =
                        Read_Text(reader["Type"]) + "\u0001" + Read_Text(reader["Paid_Date"]);

                    TmpTotal += TmpExpense;
                }
                reader.Close();

                gvExpense.ClearSelection();
                Filling = false;
                Show_Note(TmpTotal);
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //How many are listed and what they come to, so the page answers the question the list is
        //usually opened for without a separate total beside it.
        private void Show_Note(double parTotal)
        {
            LblNote.Text = gvExpense.Rows.Count.ToString(CultureInfo.InvariantCulture)
                         + " expense(s)   -   total " + Money(parTotal);
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
            string[] TmpKey = Row.Tag.ToString().Split('\u0001');
            if (TmpKey.Length != 2)
            {
                return;
            }
            Load_Record(TmpKey[0], TmpKey[1]);
        }

        //Read back from the table rather than off the grid: the amount is dressed with a dollar
        //sign there and the date is the wrong way round to take apart again.
        private void Load_Record(string parType, string parDate)
        {
            try
            {
                int TmpId = Selected_Property();
                if (TmpId == 0)
                {
                    return;
                }

                Mdl1.Ssql = "select " + Fields + " from TblPropertyRentalExpense"
                          + Where_One(TmpId, parType, parDate);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    return;
                }

                Filling = true;
                OrgType = Read_Text(reader["Type"]);
                OrgDate = Read_Text(reader["Paid_Date"]);
                CmbType.Text = OrgType;
                txtDescription.Text = Read_Text(reader["Description"]);
                Set_Date(OrgDate);
                CmbCurrency.Text = Read_Text(reader["Currency"]);
                txtExpense.Text = Box(Read_Number(reader["Expense"]));
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

        //Access takes a single quote as the end of a string, so one typed into a description is
        //doubled rather than left to break the statement.
        private string Quote(string parText)
        {
            return (parText == null ? "" : parText.Trim().Replace("'", "''"));
        }

        private void Clear_Entry()
        {
            Filling = true;
            OrgType = "";
            OrgDate = "";
            CmbType.Text = "";
            txtDescription.Text = "";
            Set_Date("");
            Default_Currency();
            txtExpense.Text = "";
            monthCalendar1.Hide();
            //ClearSelection fires SelectionChanged, and the handler falls back to CurrentRow
            //when nothing is selected - so clearing outside the guard loads straight back the
            //record it was clearing, leaving the key set.
            gvExpense.ClearSelection();
            Filling = false;
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Clear_Entry();
        }

        //---- add, update, delete ----------------------------------------------------

        //A record is its property, its type and the date it was paid. The table carries no id
        //of its own, so that triple is what Update and Delete have to match on.
        private string Where_One(int parId, string parType, string parDate)
        {
            return " where [Property_Id] = " + parId.ToString(CultureInfo.InvariantCulture)
                 + " and [Type] = '" + Quote(parType) + "'"
                 + " and [Paid_Date] = '" + Quote(parDate) + "'";
        }

        private bool Read_Entry(out int parId, out string parType, out string parDate,
                                out string parWhy)
        {
            parId = 0;
            parType = "";
            parDate = "";
            parWhy = "";

            parId = Selected_Property();
            if (parId == 0)
            {
                parWhy = "Please choose a Property Id.";
                return false;
            }

            parType = CmbType.Text.Trim();
            if (parType == "")
            {
                parWhy = "Please choose a Type.";
                return false;
            }

            string TmpDD = CmbPaidDD.Text.Trim();
            string TmpMM = CmbPaidMM.Text.Trim();
            string TmpYear = CmbPaidYear.Text.Trim();
            if (TmpDD == "" || TmpMM == "" || TmpYear == "")
            {
                parWhy = "Paid Date needs a day, a month and a year.";
                return false;
            }
            if (!Mdl1.k_Date(TmpDD + TmpMM + TmpYear))
            {
                parWhy = "Paid Date is not a real date.";
                return false;
            }
            parDate = TmpYear + TmpMM + TmpDD;

            if (CmbCurrency.Text.Trim() == "")
            {
                parWhy = "Please choose a Currency.";
                return false;
            }
            return true;
        }

        private bool Exists(int parId, string parType, string parDate)
        {
            Mdl1.Ssql = "select [Type] from TblPropertyRentalExpense"
                      + Where_One(parId, parType, parDate);
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
                string TmpType;
                string TmpDate;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpType, out TmpDate, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                //the triple is what makes a record the record it is, so a second one of the same
                //type on the same day is an update rather than another row
                if (Exists(TmpId, TmpType, TmpDate))
                {
                    MessageBox.Show(TmpType + " on " + Long_Date(TmpDate)
                        + " is already recorded for this property." + Environment.NewLine
                        + "Pick it from the list and use Update.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblPropertyRentalExpense (" + Fields + ") values ("
                          + TmpId.ToString(CultureInfo.InvariantCulture) + ", '"
                          + Quote(TmpType) + "', '" + Quote(txtDescription.Text) + "', '"
                          + TmpDate + "', '" + CmbCurrency.Text.Trim() + "', "
                          + Num(Amount(txtExpense)) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + TmpType + " on "
                    + Long_Date(TmpDate), "Success");
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
                if (OrgType == "" || OrgDate == "")
                {
                    MessageBox.Show("Please select an expense from the list first !", "Error Message");
                    return;
                }

                int TmpId;
                string TmpType;
                string TmpDate;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpType, out TmpDate, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }
                //moving the record onto a type and date that already has one would make two
                bool TmpMoved = (TmpType != OrgType || TmpDate != OrgDate);
                if (TmpMoved && Exists(TmpId, TmpType, TmpDate))
                {
                    MessageBox.Show(TmpType + " on " + Long_Date(TmpDate)
                        + " is already recorded for this property.", "Error Message");
                    return;
                }
                if (!Exists(TmpId, OrgType, OrgDate))
                {
                    MessageBox.Show("Data not found for " + OrgType + " on "
                        + Long_Date(OrgDate), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblPropertyRentalExpense set"
                          + " [Type] = '" + Quote(TmpType) + "',"
                          + " [Description] = '" + Quote(txtDescription.Text) + "',"
                          + " [Paid_Date] = '" + TmpDate + "',"
                          + " [Currency] = '" + CmbCurrency.Text.Trim() + "',"
                          + " [Expense] = " + Num(Amount(txtExpense))
                          + Where_One(TmpId, OrgType, OrgDate);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + TmpType + " on "
                    + Long_Date(TmpDate), "Success");
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
                if (OrgType == "" || OrgDate == "")
                {
                    MessageBox.Show("Please select an expense from the list first !", "Error Message");
                    return;
                }

                int TmpId = Selected_Property();
                if (TmpId == 0)
                {
                    return;
                }
                if (MessageBox.Show("Delete " + OrgType + " on " + Long_Date(OrgDate) + " ?",
                        "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblPropertyRentalExpense"
                          + Where_One(TmpId, OrgType, OrgDate);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + OrgType + " on "
                    + Long_Date(OrgDate), "Success");
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
