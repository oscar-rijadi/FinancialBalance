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

        const string Fields = "[Property_Id], [Purchase_Date], [Settlement_Date],"
                            + " [Purchase_Price], [Stamp_Duty],"
                            + " [Conveyancing_Cost], [Building_Pest_Inspection_Cost],"
                            + " [Buyers_Agent_Cost], [Settlement_Cost], [Other_Cost],"
                            + " [Down_Payment], [Initial_Loan], [Percentage_Ownership]";

        //the same columns again, qualified for the join that fetches the property's name
        const string Joined_Fields = "p.[Property_Id], p.[Purchase_Date],"
                            + " p.[Settlement_Date], p.[Purchase_Price],"
                            + " p.[Stamp_Duty], p.[Conveyancing_Cost],"
                            + " p.[Building_Pest_Inspection_Cost], p.[Buyers_Agent_Cost],"
                            + " p.[Settlement_Cost], p.[Other_Cost], p.[Down_Payment],"
                            + " p.[Initial_Loan], p.[Percentage_Ownership]";

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

        private void MnPropertySale_Click(object sender, EventArgs e)
        {
            Property_Sale Property_Sale = new Property_Sale();
            Property_Sale.Show();
            this.Close();
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
            foreach (ComboBox Day in new ComboBox[] { CmbPurchDD, CmbSettleDD })
            {
            Day.Items.Clear();
            Day.Items.Add("");
            for (int i = 1; i <= 31; i++)
            {
                Day.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
            }
            }
            foreach (ComboBox Month in new ComboBox[] { CmbPurchMM, CmbSettleMM })
            {
                Month.Items.Clear();
                Month.Items.Add("");
                for (int i = 1; i <= 12; i++)
                {
                    Month.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
                }
            }
            foreach (ComboBox Year in new ComboBox[] { CmbPurchYear, CmbSettleYear })
            {
                Year.Items.Clear();
                Year.Items.Add("");
                for (int i = DateTime.Now.Year; i >= 1950; i--)
                {
                    Year.Items.Add(i.ToString("0000", CultureInfo.InvariantCulture));
                }
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

        //A share of a property, not an amount - so two places and a per-cent sign rather
        //than a dollar one. The same shape as Percent() on the other pages that show one.
        private string Percent(double parValue)
        {
            return Math.Round(parValue, 2).ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
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
            gvPurchase.ColumnCount = 13;
            string[] names = new string[] { "Name", "Purchase Date", "Settlement Date",
                                            "Purchase Price", "Stamp Duty",
                                            "Conveyancing Cost", "B&P Inspection Cost", "BA Cost",
                                            "Settlement Cost", "Other Cost", "DP", "Initial Loan",
                                            "Percentage Ownership (%)" };
            int[] weights = new int[] { 11, 8, 8, 8, 7, 8, 8, 6, 7, 6, 6, 7, 8 };
            for (int i = 0; i < 13; i++)
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
                        Long_Date(Read_Text(reader["Settlement_Date"])),
                        Money(Read_Number(reader["Purchase_Price"])),
                        Money(Read_Number(reader["Stamp_Duty"])),
                        Money(Read_Number(reader["Conveyancing_Cost"])),
                        Money(Read_Number(reader["Building_Pest_Inspection_Cost"])),
                        Money(Read_Number(reader["Buyers_Agent_Cost"])),
                        Money(Read_Number(reader["Settlement_Cost"])),
                        Money(Read_Number(reader["Other_Cost"])),
                        Money(Read_Number(reader["Down_Payment"])),
                        Money(Read_Number(reader["Initial_Loan"])),
                        Percent(Read_Number(reader["Percentage_Ownership"])) });
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
                Set_Date(CmbPurchDD, CmbPurchMM, CmbPurchYear,
                         Read_Text(reader["Purchase_Date"]));
                Set_Date(CmbSettleDD, CmbSettleMM, CmbSettleYear,
                         Read_Text(reader["Settlement_Date"]));
                txtPurchasePrice.Text = Box(Read_Number(reader["Purchase_Price"]));
                txtStampDuty.Text = Box(Read_Number(reader["Stamp_Duty"]));
                txtConveyancing.Text = Box(Read_Number(reader["Conveyancing_Cost"]));
                txtInspection.Text = Box(Read_Number(reader["Building_Pest_Inspection_Cost"]));
                txtBuyersAgent.Text = Box(Read_Number(reader["Buyers_Agent_Cost"]));
                txtSettlement.Text = Box(Read_Number(reader["Settlement_Cost"]));
                txtOtherCost.Text = Box(Read_Number(reader["Other_Cost"]));
                txtDownPayment.Text = Box(Read_Number(reader["Down_Payment"]));
                txtInitialLoan.Text = Box(Read_Number(reader["Initial_Loan"]));
                txtPctOwnership.Text = Box(Read_Number(reader["Percentage_Ownership"]));
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
            CmbSettleDD.Text = "";
            CmbSettleMM.Text = "";
            CmbSettleYear.Text = "";
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
                                   txtInitialLoan, txtPctOwnership };
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Clear_Entry();
        }

        //---- the calendar -----------------------------------------------------------
        //
        //The same arrangement Daily Input has, and Property Setup: three dropdowns and a ".."
        //beside them that opens a MonthCalendar, which fills them in and hides again.

        //"F" for the first date, "S" for settlement; empty when the calendar is not up.
        //One calendar serves both, so which one asked for it is remembered while it is open.
        string CalFor = "";

        private void CmdPurchCal_Click(object sender, EventArgs e)
        {
            CalFor = "F";
            Open_Calendar(CmbPurchDD, CmbPurchMM, CmbPurchYear);
        }

        private void CmdSettleCal_Click(object sender, EventArgs e)
        {
            CalFor = "S";
            Open_Calendar(CmbSettleDD, CmbSettleMM, CmbSettleYear);
        }

        private void Open_Calendar(ComboBox parDD, ComboBox parMM, ComboBox parYear)
        {
            //Held to the same range the year dropdown carries. Assigning a value that is not in
            //a DropDownList does nothing at all, silently, so an unbounded calendar could appear
            //to work while leaving the date unchanged.
            monthCalendar1.MinDate = new DateTime(1950, 1, 1);
            monthCalendar1.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

            //Daily Input parses its three boxes straight into a date; here the date may not have
            //been filled in yet, and blank does not parse.
            DateTime TmpStart;
            string TmpText = parDD.Text.Trim() + parMM.Text.Trim() + parYear.Text.Trim();
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
            string TmpDD = e.Start.Day.ToString("00", CultureInfo.InvariantCulture);
            string TmpMM = e.Start.Month.ToString("00", CultureInfo.InvariantCulture);
            string TmpYear = e.Start.Year.ToString("0000", CultureInfo.InvariantCulture);
            if (CalFor == "S")
            {
                CmbSettleDD.Text = TmpDD;
                CmbSettleMM.Text = TmpMM;
                CmbSettleYear.Text = TmpYear;
            }
            else
            {
                CmbPurchDD.Text = TmpDD;
                CmbPurchMM.Text = TmpMM;
                CmbPurchYear.Text = TmpYear;
            }
            CalFor = "";
            monthCalendar1.Hide();
        }

        private void Set_Date(ComboBox parDD, ComboBox parMM, ComboBox parYear,
                              string parYyyyMMdd)
        {
            string TmpText = (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
            if (TmpText.Length != 8)
            {
                parDD.Text = "";
                parMM.Text = "";
                parYear.Text = "";
                return;
            }
            parYear.Text = TmpText.Substring(0, 4);
            parMM.Text = TmpText.Substring(4, 2);
            parDD.Text = TmpText.Substring(6, 2);
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

        private bool Read_Entry(out int parId, out string parDate, out string parSettle,
                                out string parWhy)
        {
            parId = 0;
            parDate = "";
            parSettle = "";
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

            //Settlement may not have happened yet, so an empty one is allowed - but a date with
            //only some of its parts filled in is not a date, and is refused rather than stored
            //as whatever those parts happen to concatenate to.
            string TmpSDD = CmbSettleDD.Text.Trim();
            string TmpSMM = CmbSettleMM.Text.Trim();
            string TmpSYear = CmbSettleYear.Text.Trim();
            if (TmpSDD != "" || TmpSMM != "" || TmpSYear != "")
            {
                if (TmpSDD == "" || TmpSMM == "" || TmpSYear == "")
                {
                    parWhy = "Settlement Date needs a day, a month and a year.";
                    return false;
                }
                if (!Mdl1.k_Date(TmpSDD + TmpSMM + TmpSYear))
                {
                    parWhy = "Settlement Date is not a real date.";
                    return false;
                }
                parSettle = TmpSYear + TmpSMM + TmpSDD;

                //a property cannot settle before it was bought
                if (string.CompareOrdinal(parSettle, parDate) < 0)
                {
                    parWhy = "Settlement Date is before Purchase Date.";
                    return false;
                }
            }

            //A share of a property, so anything outside 0 to 100 is not one. The shared numeric
            //filter already keeps a minus sign out of the box, so this is really the upper end -
            //but the lower one is checked too rather than relied on from somewhere else.
            double TmpPct = Amount(txtPctOwnership);
            if (TmpPct < 0 || TmpPct > 100)
            {
                parWhy = "Percentage Ownership must be between 0 and 100.";
                return false;
            }
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
                 + Num(Amount(txtInitialLoan)) + ", "
                 + Num(Amount(txtPctOwnership));
        }

        //---- add, update, delete ----------------------------------------------------

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int TmpId;
                string TmpDate;
                string TmpSettle;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpDate, out TmpSettle, out TmpWhy))
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
                          + TmpId.ToString(CultureInfo.InvariantCulture) + ", '" + TmpDate + "', '"
                          + TmpSettle + "', " + Values() + ")";
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
                string TmpSettle;
                string TmpWhy;
                if (!Read_Entry(out TmpId, out TmpDate, out TmpSettle, out TmpWhy))
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
                          + " [Settlement_Date] = '" + TmpSettle + "',"
                          + " [Purchase_Price] = " + Num(Amount(txtPurchasePrice)) + ","
                          + " [Stamp_Duty] = " + Num(Amount(txtStampDuty)) + ","
                          + " [Conveyancing_Cost] = " + Num(Amount(txtConveyancing)) + ","
                          + " [Building_Pest_Inspection_Cost] = " + Num(Amount(txtInspection)) + ","
                          + " [Buyers_Agent_Cost] = " + Num(Amount(txtBuyersAgent)) + ","
                          + " [Settlement_Cost] = " + Num(Amount(txtSettlement)) + ","
                          + " [Other_Cost] = " + Num(Amount(txtOtherCost)) + ","
                          + " [Down_Payment] = " + Num(Amount(txtDownPayment)) + ","
                          + " [Initial_Loan] = " + Num(Amount(txtInitialLoan)) + ","
                          + " [Percentage_Ownership] = " + Num(Amount(txtPctOwnership))
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
