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
    public partial class Setup_Property : Form
    {
        //true while Get_Data is refilling the grid, so the rows it adds do not fire the
        //selection handler and type themselves back into the boxes
        bool Filling;

        //The id of the row picked out of the grid, so Update and Delete know which one they are
        //working on. Zero until a row is picked, which is what makes Update refuse before there
        //is anything to update.
        int OrgId;

        //Name, Address, State and Post_Code are all reserved or awkward enough in Access that
        //every column is bracketed rather than only the ones that have to be.
        const string Fields = "[Property_Id], [Name], [Address], [Suburb], [State], [Post_Code],"
                            + " [Purchase_Date], [Is_Sold], [Sold_Date]";

        public Setup_Property()
        {
            InitializeComponent();
        }

        private void Setup_Property_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Dates();
            Fill_State();
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

        private void MnSuperProcess_Click(object sender, EventArgs e)
        {
            Super_Financial_Year Super_Financial_Year = new Super_Financial_Year();
            Super_Financial_Year.Show();
            this.Close();
        }

        //---- the dropdowns ----------------------------------------------------------

        //The shared Mdl1.Fill_Date offers three years, which suits a transaction entered as it
        //happens but not a property bought decades ago. The day and month lists are the same as
        //everywhere else; only the year range is opened up.
        private void Fill_Dates()
        {
            foreach (ComboBox Day in new ComboBox[] { CmbPurchDD, CmbSoldDD })
            {
                Day.Items.Clear();
                Day.Items.Add("");
                for (int i = 1; i <= 31; i++)
                {
                    Day.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
                }
            }
            foreach (ComboBox Month in new ComboBox[] { CmbPurchMM, CmbSoldMM })
            {
                Month.Items.Clear();
                Month.Items.Add("");
                for (int i = 1; i <= 12; i++)
                {
                    Month.Items.Add(i.ToString("00", CultureInfo.InvariantCulture));
                }
            }
            foreach (ComboBox Year in new ComboBox[] { CmbPurchYear, CmbSoldYear })
            {
                Year.Items.Clear();
                Year.Items.Add("");
                for (int i = DateTime.Now.Year; i >= 1950; i--)
                {
                    Year.Items.Add(i.ToString("0000", CultureInfo.InvariantCulture));
                }
            }
        }

        private void Fill_State()
        {
            CmbState.Items.Clear();
            CmbState.Items.Add("");
            Mdl1.Ssql = "select [Name] from TblState order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbState.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();
        }

        //---- the list ---------------------------------------------------------------

        private void Clear_Grid()
        {
            gvProperty.Rows.Clear();
            gvProperty.Columns.Clear();
            gvProperty.ColumnCount = 6;
            string[] names = new string[] { "Property Id", "Name", "Full Address",
                                            "Purchase Date", "Is_Sold", "Sold Date" };
            int[] weights = new int[] { 9, 18, 39, 12, 8, 12 };
            for (int i = 0; i < 6; i++)
            {
                gvProperty.Columns[i].Name = names[i];
                gvProperty.Columns[i].FillWeight = weights[i];
                //the id and the two dates read centred, the flag too; the words read left
                DataGridViewContentAlignment TmpAlign =
                    (i == 1 || i == 2 ? DataGridViewContentAlignment.MiddleLeft
                                      : DataGridViewContentAlignment.MiddleCenter);
                gvProperty.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvProperty.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        //yyyyMMdd as it is stored, dd-MMM-yyyy as it is read. Anything that is not a date comes
        //back blank rather than as eight raw digits.
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

        private string Read_Text(object parValue)
        {
            return (parValue == null || parValue == DBNull.Value
                    ? "" : parValue.ToString().Trim());
        }

        private bool Read_Flag(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return false;
            }
            return Convert.ToBoolean(parValue);
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                Mdl1.Ssql = "select " + Fields + " from TblProperty order by [Property_Id]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //the address is four fields on screen and one column here
                    string TmpFull = string.Join(" ", new string[] {
                        Read_Text(reader["Address"]), Read_Text(reader["Suburb"]),
                        Read_Text(reader["State"]), Read_Text(reader["Post_Code"]) }
                        .Where(x => x != "").ToArray());

                    gvProperty.Rows.Add(new string[] {
                        Read_Text(reader["Property_Id"]),
                        Read_Text(reader["Name"]),
                        TmpFull,
                        Long_Date(Read_Text(reader["Purchase_Date"])),
                        (Read_Flag(reader["Is_Sold"]) ? "Yes" : "No"),
                        Long_Date(Read_Text(reader["Sold_Date"])) });
                }
                reader.Close();

                gvProperty.ClearSelection();
                Filling = false;
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Clicking a row loads it back into the entry area, so it can be changed or removed
        //without any of it being typed again.
        private void gvProperty_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvProperty.SelectedRows.Count > 0)
            {
                Row = gvProperty.SelectedRows[0];
            }
            else
            {
                Row = gvProperty.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            int TmpId;
            if (!int.TryParse(Row.Cells[0].Value.ToString().Trim(), out TmpId))
            {
                return;
            }
            Load_Record(TmpId);
        }

        //Read back from the table rather than off the grid: the grid shows the address as one
        //column and the dates the long way round, neither of which can be taken apart again.
        private void Load_Record(int parId)
        {
            try
            {
                Mdl1.Ssql = "select " + Fields + " from TblProperty where [Property_Id] = "
                          + parId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    return;
                }

                Filling = true;
                OrgId = parId;
                LblPropertyId.Text = parId.ToString(CultureInfo.InvariantCulture);
                Show_Id(true);
                txtName.Text = Read_Text(reader["Name"]);
                txtAddress.Text = Read_Text(reader["Address"]);
                txtSuburb.Text = Read_Text(reader["Suburb"]);
                CmbState.Text = Read_Text(reader["State"]);
                txtPostCode.Text = Read_Text(reader["Post_Code"]);
                Set_Date(CmbPurchDD, CmbPurchMM, CmbPurchYear, Read_Text(reader["Purchase_Date"]));
                chkIsSold.Checked = Read_Flag(reader["Is_Sold"]);
                Set_Date(CmbSoldDD, CmbSoldMM, CmbSoldYear, Read_Text(reader["Sold_Date"]));
                Filling = false;
                reader.Close();

                Show_Sold();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the entry area ---------------------------------------------------------

        //The id is the table's own, not something anyone types, so it is only worth showing once
        //there is a record it belongs to.
        private void Show_Id(bool parShow)
        {
            Lbl_PropertyId.Visible = parShow;
            LblPropertyId.Visible = parShow;
        }

        //A sold date on a property that is not sold would be a contradiction, so the boxes are
        //only live while the flag is ticked - and cleared when it is not.
        private void Show_Sold()
        {
            bool TmpSold = chkIsSold.Checked;
            Lbl_Sold.Enabled = TmpSold;
            CmbSoldDD.Enabled = TmpSold;
            CmbSoldMM.Enabled = TmpSold;
            CmbSoldYear.Enabled = TmpSold;
            CmdSoldCal.Enabled = TmpSold;
            if (!TmpSold)
            {
                CmbSoldDD.Text = "";
                CmbSoldMM.Text = "";
                CmbSoldYear.Text = "";
                //the calendar would otherwise be left open over a date nobody can now set
                if (CalFor == "S")
                {
                    CalFor = "";
                    monthCalendar1.Hide();
                }
            }
        }

        private void chkIsSold_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Sold();
        }

        private void Clear_Entry()
        {
            Filling = true;
            OrgId = 0;
            LblPropertyId.Text = "";
            Show_Id(false);
            txtName.Text = "";
            txtAddress.Text = "";
            txtSuburb.Text = "";
            CmbState.Text = "";
            txtPostCode.Text = "";
            CmbPurchDD.Text = "";
            CmbPurchMM.Text = "";
            CmbPurchYear.Text = "";
            chkIsSold.Checked = false;
            CmbSoldDD.Text = "";
            CmbSoldMM.Text = "";
            CmbSoldYear.Text = "";
            Filling = false;

            Show_Sold();
            gvProperty.ClearSelection();
            LblNote.Text = "";
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Clear_Entry();
        }

        //---- dates in and out -------------------------------------------------------

        //Stored as yyyyMMdd, the same as every other date in this database.
        private string Date_From(ComboBox parDD, ComboBox parMM, ComboBox parYear)
        {
            string TmpDD = parDD.Text.Trim();
            string TmpMM = parMM.Text.Trim();
            string TmpYear = parYear.Text.Trim();
            if (TmpDD == "" && TmpMM == "" && TmpYear == "")
            {
                return "";
            }
            return TmpYear + TmpMM + TmpDD;
        }

        //---- the calendar -----------------------------------------------------------
        //
        //The same arrangement Daily Input has: three dropdowns and a ".." beside them that opens
        //a MonthCalendar, which fills them in and hides again.  One calendar serves both dates,
        //so which one asked for it is remembered while it is open.

        //"P" for Purchase, "S" for Sold; empty when the calendar is not up
        string CalFor = "";

        private void Open_Calendar(string parWhich, ComboBox parDD, ComboBox parMM, ComboBox parYear)
        {
            CalFor = parWhich;

            //A property cannot be bought or sold in the future, and the year dropdowns only go
            //back to 1950 - so the calendar is held to the same range.  Without the lower bound
            //it could return a year the dropdown does not carry, and assigning a missing value
            //to a DropDownList does nothing at all, silently: the calendar would appear to work
            //and the date would not change.
            monthCalendar1.MinDate = new DateTime(1950, 1, 1);
            monthCalendar1.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

            //Daily Input parses its three boxes straight into a date, which cannot be done here:
            //a date that has not been filled in yet is blank, and blank does not parse.
            DateTime TmpStart;
            if (!Whole_Date(parDD, parMM, parYear, out TmpStart))
            {
                TmpStart = DateTime.Today;
            }
            if (TmpStart < monthCalendar1.MinDate) { TmpStart = monthCalendar1.MinDate; }
            if (TmpStart > monthCalendar1.MaxDate) { TmpStart = monthCalendar1.MaxDate; }

            monthCalendar1.SetDate(TmpStart);
            monthCalendar1.BringToFront();
            monthCalendar1.Show();
        }

        private bool Whole_Date(ComboBox parDD, ComboBox parMM, ComboBox parYear, out DateTime parDate)
        {
            parDate = DateTime.Today;
            string TmpText = parDD.Text.Trim() + parMM.Text.Trim() + parYear.Text.Trim();
            if (TmpText.Length != 8)
            {
                return false;
            }
            return DateTime.TryParseExact(TmpText, "ddMMyyyy", CultureInfo.InvariantCulture,
                                          DateTimeStyles.None, out parDate);
        }

        private void CmdPurchCal_Click(object sender, EventArgs e)
        {
            Open_Calendar("P", CmbPurchDD, CmbPurchMM, CmbPurchYear);
        }

        private void CmdSoldCal_Click(object sender, EventArgs e)
        {
            //the sold date is only live once the property is marked sold
            if (!chkIsSold.Checked)
            {
                return;
            }
            Open_Calendar("S", CmbSoldDD, CmbSoldMM, CmbSoldYear);
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (CalFor == "P")
            {
                CmbPurchDD.Text = e.Start.Day.ToString("00", CultureInfo.InvariantCulture);
                CmbPurchMM.Text = e.Start.Month.ToString("00", CultureInfo.InvariantCulture);
                CmbPurchYear.Text = e.Start.Year.ToString("0000", CultureInfo.InvariantCulture);
            }
            else if (CalFor == "S")
            {
                CmbSoldDD.Text = e.Start.Day.ToString("00", CultureInfo.InvariantCulture);
                CmbSoldMM.Text = e.Start.Month.ToString("00", CultureInfo.InvariantCulture);
                CmbSoldYear.Text = e.Start.Year.ToString("0000", CultureInfo.InvariantCulture);
            }
            CalFor = "";
            monthCalendar1.Hide();
        }

        private void Set_Date(ComboBox parDD, ComboBox parMM, ComboBox parYear, string parYyyyMMdd)
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

        //A part-filled date is refused rather than stored as something that is not a date. The
        //shared k_Date check wants ddMMyyyy, so that is the order it is given.
        private bool Date_Ok(ComboBox parDD, ComboBox parMM, ComboBox parYear, string parWhich,
                             bool parNeeded, out string parValue, out string parWhy)
        {
            parValue = "";
            parWhy = "";
            string TmpDD = parDD.Text.Trim();
            string TmpMM = parMM.Text.Trim();
            string TmpYear = parYear.Text.Trim();

            if (TmpDD == "" && TmpMM == "" && TmpYear == "")
            {
                if (parNeeded)
                {
                    parWhy = parWhich + " is needed.";
                    return false;
                }
                return true;
            }
            if (TmpDD == "" || TmpMM == "" || TmpYear == "")
            {
                parWhy = parWhich + " needs a day, a month and a year.";
                return false;
            }
            if (!Mdl1.k_Date(TmpDD + TmpMM + TmpYear))
            {
                parWhy = parWhich + " is not a real date.";
                return false;
            }
            parValue = TmpYear + TmpMM + TmpDD;
            return true;
        }

        //---- what may be saved ------------------------------------------------------

        private string Quoted(string parText)
        {
            //a quote typed into an address would otherwise end the literal and break the
            //statement, so it is doubled the way SQL expects
            return "'" + (parText == null ? "" : parText.Trim()).Replace("'", "''") + "'";
        }

        private bool Read_Entry(out string parPurchase, out string parSold, out string parWhy)
        {
            parPurchase = "";
            parSold = "";
            parWhy = "";

            if (txtName.Text.Trim() == "")
            {
                parWhy = "Name cannot be empty !";
                return false;
            }
            string TmpPost = txtPostCode.Text.Trim();
            if (TmpPost != "" && !Mdl1.k_Numeric(TmpPost))
            {
                parWhy = "Post Code must be digits only.";
                return false;
            }
            if (!Date_Ok(CmbPurchDD, CmbPurchMM, CmbPurchYear, "Purchase Date", true,
                         out parPurchase, out parWhy))
            {
                return false;
            }
            if (!Date_Ok(CmbSoldDD, CmbSoldMM, CmbSoldYear, "Sold Date", chkIsSold.Checked,
                         out parSold, out parWhy))
            {
                return false;
            }
            //a property cannot have been sold before it was bought
            if (parSold != "" && parPurchase != ""
                && string.CompareOrdinal(parSold, parPurchase) < 0)
            {
                parWhy = "Sold Date is before Purchase Date.";
                return false;
            }
            return true;
        }

        private string Values(string parPurchase, string parSold)
        {
            return Quoted(txtName.Text) + ", "
                 + Quoted(txtAddress.Text) + ", "
                 + Quoted(txtSuburb.Text) + ", "
                 + Quoted(CmbState.Text) + ", "
                 + Quoted(txtPostCode.Text) + ", "
                 + Quoted(parPurchase) + ", "
                 + (chkIsSold.Checked ? "True" : "False") + ", "
                 + Quoted(parSold);
        }

        //Property_Id is a plain number rather than an AutoNumber, so the next one is worked out
        //here. Max + 1 rather than count + 1, which would repeat an id after a deletion.
        private int Next_Id()
        {
            int TmpNext = 1;
            Mdl1.Ssql = "select Max([Property_Id]) as N from TblProperty";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && reader["N"] != DBNull.Value)
            {
                TmpNext = Convert.ToInt32(reader["N"]) + 1;
            }
            reader.Close();
            return TmpNext;
        }

        private bool Exists(int parId)
        {
            Mdl1.Ssql = "select [Property_Id] from TblProperty where [Property_Id] = "
                      + parId.ToString(CultureInfo.InvariantCulture);
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        //---- add, update, delete ----------------------------------------------------

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpPurchase;
                string TmpSold;
                string TmpWhy;
                if (!Read_Entry(out TmpPurchase, out TmpSold, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                int TmpId = Next_Id();
                Mdl1.Ssql = "Insert into TblProperty (" + Fields + ") values ("
                          + TmpId.ToString(CultureInfo.InvariantCulture) + ", "
                          + Values(TmpPurchase, TmpSold) + ")";
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
                    MessageBox.Show("Please select a property from the list first !", "Error Message");
                    return;
                }
                if (!Exists(OrgId))
                {
                    MessageBox.Show("Data not found for Property Id : "
                        + OrgId.ToString(CultureInfo.InvariantCulture), "Error Message");
                    return;
                }

                string TmpPurchase;
                string TmpSold;
                string TmpWhy;
                if (!Read_Entry(out TmpPurchase, out TmpSold, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                //the id itself is never changed - it is the key the row is found by
                Mdl1.Ssql = "Update TblProperty set"
                          + " [Name] = " + Quoted(txtName.Text) + ","
                          + " [Address] = " + Quoted(txtAddress.Text) + ","
                          + " [Suburb] = " + Quoted(txtSuburb.Text) + ","
                          + " [State] = " + Quoted(CmbState.Text) + ","
                          + " [Post_Code] = " + Quoted(txtPostCode.Text) + ","
                          + " [Purchase_Date] = " + Quoted(TmpPurchase) + ","
                          + " [Is_Sold] = " + (chkIsSold.Checked ? "True" : "False") + ","
                          + " [Sold_Date] = " + Quoted(TmpSold)
                          + " where [Property_Id] = " + OrgId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for Property Id : "
                    + OrgId.ToString(CultureInfo.InvariantCulture), "Success");
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
                    MessageBox.Show("Please select a property from the list first !", "Error Message");
                    return;
                }
                if (!Exists(OrgId))
                {
                    MessageBox.Show("Data not found for Property Id : "
                        + OrgId.ToString(CultureInfo.InvariantCulture), "Error Message");
                    return;
                }

                DialogResult Response = MessageBox.Show(
                    "Delete property " + OrgId.ToString(CultureInfo.InvariantCulture)
                    + ", " + txtName.Text.Trim() + " ?", "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblProperty where [Property_Id] = "
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
