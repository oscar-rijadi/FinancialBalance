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
    public partial class Property_Purchase : Form
    {
        //true while the grid or the dropdowns are being refilled, so the rows and items being
        //added do not fire the handlers and type themselves back into the boxes
        bool Filling;

        //The property whose row was picked out of the list, so Update and Delete know which one
        //they are working on. Zero until a row is picked.
        int OrgId;

        //index-aligned with CmbPropertyId: the name behind each id, so the label beside the
        //dropdown does not need a query every time the choice changes
        List<string> PropertyNames = new List<string>();

        const string Fields = "[Property_Id], [Purchase_Date], [Purchase_Price], [Stamp_Duty],"
                            + " [Conveyancing_Cost], [Building_Pest_Inspection_Cost],"
                            + " [Buyers_Agent_Cost], [Settlement_Cost], [Other_Cost],"
                            + " [Down_Payment], [Initial_Loan]";

        //the same columns again, qualified for the join that fetches the property's name
        const string Joined_Fields = "p.[Property_Id], p.[Purchase_Date], p.[Purchase_Price],"
                            + " p.[Stamp_Duty], p.[Conveyancing_Cost],"
                            + " p.[Building_Pest_Inspection_Cost], p.[Buyers_Agent_Cost],"
                            + " p.[Settlement_Cost], p.[Other_Cost], p.[Down_Payment],"
                            + " p.[Initial_Loan]";

        public Property_Purchase()
        {
            InitializeComponent();
        }

        private void Property_Purchase_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Dates();
            Fill_Property();
            Filling = false;

            monthCalendar1.Hide();
            Get_Data();
            Clear_Entry();
        }

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

        private void MnPropertySetup_Click(object sender, EventArgs e)
        {
            Setup_Property Setup_Property = new Setup_Property();
            Setup_Property.Show();
            this.Close();
        }

        private void MnSuperProcess_Click(object sender, EventArgs e)
        {
            Super_Financial_Year Super_Financial_Year = new Super_Financial_Year();
            Super_Financial_Year.Show();
            this.Close();
        }

        //---- the dropdowns ----------------------------------------------------------

        //As on Property Setup: the shared Mdl1.Fill_Date offers three years, which is no use for
        //a property bought decades ago, so the year list is opened up. Day and month are the
        //same as everywhere else.
        private void Fill_Dates()
        {
            CmbPurchDD.Items.Clear();
            CmbPurchDD.Items.Add("");
            for (int i = 1; i <= 31; i++)
            {
                CmbPurchDD.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
            }
            CmbPurchMM.Items.Clear();
            CmbPurchMM.Items.Add("");
            for (int i = 1; i <= 12; i++)
            {
                CmbPurchMM.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
            }
            CmbPurchYear.Items.Clear();
            CmbPurchYear.Items.Add("");
            for (int i = DateTime.Now.Year; i >= 1950; i--)
            {
                CmbPurchYear.Items.Add(i.ToString("0000", CultureInfo.InvariantCulture));
            }
        }

        private void Fill_Property()
        {
            CmbPropertyId.Items.Clear();
            PropertyNames.Clear();
            CmbPropertyId.Items.Add("");
            PropertyNames.Add("");

            Mdl1.Ssql = "select [Property_Id], [Name] from TblProperty order by [Property_Id]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbPropertyId.Items.Add(Read_Text(reader["Property_Id"]));
                PropertyNames.Add(Read_Text(reader["Name"]));
            }
            reader.Close();
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

        //Every amount on this page is in dollars, so the sign is not conditional the way it is
        //on the multi-currency pages. FormatAmt already groups thousands and shows two places.
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
            gvPurchase.Rows.Clear();
            gvPurchase.Columns.Clear();
            gvPurchase.ColumnCount = 11;
            string[] names = new string[] { "Name", "Purchase Date", "Purchase Price", "Stamp Duty",
                                            "Conveyancing Cost", "B&P Inspection Cost", "BA Cost",
                                            "Settlement Cost", "Other Cost", "DP", "Initial Loan" };
            int[] weights = new int[] { 13, 10, 10, 8, 10, 10, 7, 9, 8, 8, 9 };
            for (int i = 0; i < 11; i++)
            {
                gvPurchase.Columns[i].Name = names[i];
                //A grid header is not a caption: it does not treat & as an accelerator marker,
                //so doubling it here would show the doubled one. The entry-area label beside the
                //matching box does need it doubled, and has it.
                gvPurchase.Columns[i].HeaderText = names[i];
                gvPurchase.Columns[i].FillWeight = weights[i];
                //the name reads left, the date centred, every amount right
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleRight;
                if (i == 0)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                }
                else if (i == 1)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                gvPurchase.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvPurchase.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                //the name lives on TblProperty, so the two are read together; a purchase whose
                //property has since been deleted still shows, with the id in place of a name
                Mdl1.Ssql = "select " + Joined_Fields + ", r.[Name] as Property_Name"
                          + " from TblPropertyPurchase as p left join TblProperty as r"
                          + " on p.[Property_Id] = r.[Property_Id]"
                          + " order by p.[Property_Id]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string TmpName = Read_Text(reader["Property_Name"]);
                    if (TmpName == "")
                    {
                        TmpName = "(" + Read_Text(reader["Property_Id"]) + ")";
                    }
                    gvPurchase.Rows.Add(new string[] {
                        TmpName,
                        Long_Date(Read_Text(reader["Purchase_Date"])),
                        Money(Read_Number(reader["Purchase_Price"])),
                        Money(Read_Number(reader["Stamp_Duty"])),
                        Money(Read_Number(reader["Conveyancing_Cost"])),
                        Money(Read_Number(reader["Building_Pest_Inspection_Cost"])),
                        Money(Read_Number(reader["Buyers_Agent_Cost"])),
                        Money(Read_Number(reader["Settlement_Cost"])),
                        Money(Read_Number(reader["Other_Cost"])),
                        Money(Read_Number(reader["Down_Payment"])),
                        Money(Read_Number(reader["Initial_Loan"])) });
                    //the id is not a column, so it rides along on the row
                    gvPurchase.Rows[gvPurchase.Rows.Count - 1].Tag = Read_Text(reader["Property_Id"]);
                }
                reader.Close();

                gvPurchase.ClearSelection();
                Filling = false;
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void gvPurchase_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvPurchase.SelectedRows.Count > 0)
            {
                Row = gvPurchase.SelectedRows[0];
            }
            else
            {
                Row = gvPurchase.CurrentRow;
            }
            if (Row == null || Row.Tag == null)
            {
                return;
            }
            int TmpId;
            if (!int.TryParse(Row.Tag.ToString(), out TmpId))
            {
                return;
            }
            Load_Record(TmpId);
        }

        //Read back from the table rather than off the grid: the amounts are dressed with a
        //dollar sign there and the date is the wrong way round to take apart again.
        private void Load_Record(int parId)
        {
            try
            {
                Mdl1.Ssql = "select " + Fields + " from TblPropertyPurchase"
                          + " where [Property_Id] = " + parId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    return;
                }

                Filling = true;
                OrgId = parId;
                //CmbPropertyId is a DropDownList, and assigning a value that is not among its
                //items does nothing at all, silently. That happens when the property behind a
                //purchase has since been deleted, so it is checked rather than assumed - the
                //box would otherwise be left showing the previous record while the rest of the
                //form showed this one.
                string TmpWanted = parId.ToString(CultureInfo.InvariantCulture);
                CmbPropertyId.Text = TmpWanted;
                bool TmpOrphan = (CmbPropertyId.Text != TmpWanted);
                Set_Date(Read_Text(reader["Purchase_Date"]));
                txtPurchasePrice.Text = Box(Read_Number(reader["Purchase_Price"]));
                txtStampDuty.Text = Box(Read_Number(reader["Stamp_Duty"]));
                txtConveyancing.Text = Box(Read_Number(reader["Conveyancing_Cost"]));
                txtInspection.Text = Box(Read_Number(reader["Building_Pest_Inspection_Cost"]));
                txtBuyersAgent.Text = Box(Read_Number(reader["Buyers_Agent_Cost"]));
                txtSettlement.Text = Box(Read_Number(reader["Settlement_Cost"]));
                txtOtherCost.Text = Box(Read_Number(reader["Other_Cost"]));
                txtDownPayment.Text = Box(Read_Number(reader["Down_Payment"]));
                txtInitialLoan.Text = Box(Read_Number(reader["Initial_Loan"]));
                Filling = false;
                reader.Close();

                Show_Property_Name();
                if (TmpOrphan)
                {
                    OrgId = 0;
                    LblNote.Text = "Property " + TmpWanted + " no longer exists, so this purchase"
                                 + " record cannot be changed here. Delete it from the list, or"
                                 + " add the property back first.";
                    LblNote.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    LblNote.Text = "";
                    LblNote.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //A box holds a bare figure - no sign, no grouping - since that is what may be typed
        //back into it.
        private string Box(double parValue)
        {
            return parValue.ToString("0.00", CultureInfo.InvariantCulture);
        }

        //---- the entry area ---------------------------------------------------------

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

        private void Clear_Entry()
        {
            Filling = true;
            OrgId = 0;
            CmbPropertyId.Text = "";
            CmbPurchDD.Text = "";
            CmbPurchMM.Text = "";
            CmbPurchYear.Text = "";
            foreach (TextBox Box in Money_Boxes())
            {
                Box.Text = "";
            }
            //ClearSelection fires SelectionChanged, and the handler falls back to
            //CurrentRow when nothing is selected - so clearing outside the guard
            //loads straight back the record it was clearing, leaving OrgId set.
            gvPurchase.ClearSelection();
            Filling = false;

            Show_Property_Name();
            LblNote.Text = "";
        }

        private TextBox[] Money_Boxes()
        {
            return new TextBox[] { txtPurchasePrice, txtStampDuty, txtConveyancing, txtInspection,
                                   txtBuyersAgent, txtSettlement, txtOtherCost, txtDownPayment,
                                   txtInitialLoan };
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Clear_Entry();
        }

        //---- the calendar -----------------------------------------------------------
        //
        //The same arrangement Daily Input has, and Property Setup: three dropdowns and a ".."
        //beside them that opens a MonthCalendar, which fills them in and hides again.

        private void CmdPurchCal_Click(object sender, EventArgs e)
        {
            //Held to the same range the year dropdown carries. Assigning a value that is not in
            //a DropDownList does nothing at all, silently, so an unbounded calendar could appear
            //to work while leaving the date unchanged.
            monthCalendar1.MinDate = new DateTime(1950, 1, 1);
            monthCalendar1.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

            //Daily Input parses its three boxes straight into a date; here the date may not have
            //been filled in yet, and blank does not parse.
            DateTime TmpStart;
            string TmpText = CmbPurchDD.Text.Trim() + CmbPurchMM.Text.Trim() + CmbPurchYear.Text.Trim();
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
            CmbPurchDD.Text = e.Start.Day.ToString("00", CultureInfo.InvariantCulture);
            CmbPurchMM.Text = e.Start.Month.ToString("00", CultureInfo.InvariantCulture);
            CmbPurchYear.Text = e.Start.Year.ToString("0000", CultureInfo.InvariantCulture);
            monthCalendar1.Hide();
        }

        private void Set_Date(string parYyyyMMdd)
        {
            string TmpText = (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
            if (TmpText.Length != 8)
            {
                CmbPurchDD.Text = "";
                CmbPurchMM.Text = "";
                CmbPurchYear.Text = "";
                return;
            }
            CmbPurchYear.Text = TmpText.Substring(0, 4);
            CmbPurchMM.Text = TmpText.Substring(4, 2);
            CmbPurchDD.Text = TmpText.Substring(6, 2);
        }

        //---- what may be saved ------------------------------------------------------

        private double Amount(TextBox parBox)
        {
            return Mdl1.checkNumeric(parBox.Text.Trim());
        }

        //Written with the invariant point, so a machine set to a comma decimal separator does
        //not send Access something it reads as a different number.
        private string Num(double parValue)
        {
            return Math.Round(parValue, 2).ToString("0.00", CultureInfo.InvariantCulture);
        }

        private bool Read_Entry(out int parId, out string parDate, out string parWhy)
        {
            parId = 0;
            parDate = "";
            parWhy = "";

            string TmpId = CmbPropertyId.Text.Trim();
            if (TmpId == "")
            {
                parWhy = "Please choose a Property Id.";
                return false;
            }
            if (!int.TryParse(TmpId, out parId))
            {
                parWhy = "Property Id must be a number.";
                return false;
            }

            string TmpDD = CmbPurchDD.Text.Trim();
            string TmpMM = CmbPurchMM.Text.Trim();
            string TmpYear = CmbPurchYear.Text.Trim();
            if (TmpDD == "" || TmpMM == "" || TmpYear == "")
            {
                parWhy = "Purchase Date needs a day, a month and a year.";
                return false;
            }
            if (!Mdl1.k_Date(TmpDD + TmpMM + TmpYear))
            {
                parWhy = "Purchase Date is not a real date.";
                return false;
            }
            parDate = TmpYear + TmpMM + TmpDD;
            return true;
        }

        private bool Exists(int parId)
        {
            Mdl1.Ssql = "select [Property_Id] from TblPropertyPurchase where [Property_Id] = "
                      + parId.ToString(CultureInfo.InvariantCulture);
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        private string Values()
        {
            return Num(Amount(txtPurchasePrice)) + ", "
                 + Num(Amount(txtStampDuty)) + ", "
                 + Num(Amount(txtConveyancing)) + ", "
                 + Num(Amount(txtInspection)) + ", "
                 + Num(Amount(txtBuyersAgent)) + ", "
                 + Num(Amount(txtSettlement)) + ", "
                 + Num(Amount(txtOtherCost)) + ", "
                 + Num(Amount(txtDownPayment)) + ", "
                 + Num(Amount(txtInitialLoan));
        }

        //---- add, update, delete ----------------------------------------------------

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int TmpId;
                string TmpDate;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpDate, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                //one purchase per property, so a second is an update rather than another row
                if (Exists(TmpId))
                {
                    MessageBox.Show("Property Id " + TmpId.ToString(CultureInfo.InvariantCulture)
                        + " already has a purchase record." + Environment.NewLine
                        + "Pick it from the list and use Update.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblPropertyPurchase (" + Fields + ") values ("
                          + TmpId.ToString(CultureInfo.InvariantCulture) + ", '" + TmpDate + "', "
                          + Values() + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Property Id : "
                    + TmpId.ToString(CultureInfo.InvariantCulture), "Success");
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
                    MessageBox.Show("Please select a purchase from the list first !", "Error Message");
                    return;
                }

                int TmpId;
                string TmpDate;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpDate, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }
                //moving the record onto a property that already has one would make two
                if (TmpId != OrgId && Exists(TmpId))
                {
                    MessageBox.Show("Property Id " + TmpId.ToString(CultureInfo.InvariantCulture)
                        + " already has a purchase record.", "Error Message");
                    return;
                }
                if (!Exists(OrgId))
                {
                    MessageBox.Show("Data not found for Property Id : "
                        + OrgId.ToString(CultureInfo.InvariantCulture), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblPropertyPurchase set"
                          + " [Property_Id] = " + TmpId.ToString(CultureInfo.InvariantCulture) + ","
                          + " [Purchase_Date] = '" + TmpDate + "',"
                          + " [Purchase_Price] = " + Num(Amount(txtPurchasePrice)) + ","
                          + " [Stamp_Duty] = " + Num(Amount(txtStampDuty)) + ","
                          + " [Conveyancing_Cost] = " + Num(Amount(txtConveyancing)) + ","
                          + " [Building_Pest_Inspection_Cost] = " + Num(Amount(txtInspection)) + ","
                          + " [Buyers_Agent_Cost] = " + Num(Amount(txtBuyersAgent)) + ","
                          + " [Settlement_Cost] = " + Num(Amount(txtSettlement)) + ","
                          + " [Other_Cost] = " + Num(Amount(txtOtherCost)) + ","
                          + " [Down_Payment] = " + Num(Amount(txtDownPayment)) + ","
                          + " [Initial_Loan] = " + Num(Amount(txtInitialLoan))
                          + " where [Property_Id] = " + OrgId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for Property Id : "
                    + TmpId.ToString(CultureInfo.InvariantCulture), "Success");
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
                    MessageBox.Show("Please select a purchase from the list first !", "Error Message");
                    return;
                }
                if (!Exists(OrgId))
                {
                    MessageBox.Show("Data not found for Property Id : "
                        + OrgId.ToString(CultureInfo.InvariantCulture), "Error Message");
                    return;
                }

                DialogResult Response = MessageBox.Show(
                    "Delete the purchase record for Property Id "
                    + OrgId.ToString(CultureInfo.InvariantCulture) + " ?",
                    "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblPropertyPurchase where [Property_Id] = "
                          + OrgId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Property Id : "
                    + OrgId.ToString(CultureInfo.InvariantCulture), "Success");
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
