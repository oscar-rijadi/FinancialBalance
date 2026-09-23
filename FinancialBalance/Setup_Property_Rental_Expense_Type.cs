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
    public partial class Setup_Property_Rental_Expense_Type : Form
    {
        //true while Get_Data is refilling the grid, so the rows it adds do not fire the selection
        //handler and type themselves back into the box
        bool Filling;

        //The name of the row picked out of the grid, so Update knows which row it is changing -
        //the name is all this table has, so without it a renamed type would be indistinguishable
        //from a new one. Null until a row is picked, which is what makes Update and Delete refuse
        //before anything has been chosen.
        string OrgName;

        public Setup_Property_Rental_Expense_Type()
        {
            InitializeComponent();
        }

        private void Setup_Property_Rental_Expense_Type_Load(object sender, EventArgs e)
        {
            Get_Data();
        }

        //---- the menu ---------------------------------------------------------------

        private void MnAcctTypeRefSetup_Click(object sender, EventArgs e)
        {
            Setup_Acct_Type_Ref Setup_Acct_Type_Ref = new Setup_Acct_Type_Ref();
            Setup_Acct_Type_Ref.Show();
            this.Close();
        }

        private void MnAcctRefSetup_Click(object sender, EventArgs e)
        {
            Setup_Acct_Ref Setup_Acct_Ref = new Setup_Acct_Ref();
            Setup_Acct_Ref.Show();
            this.Close();
        }

        private void MnCurrSetup_Click(object sender, EventArgs e)
        {
            Setup_Curr Setup_Curr = new Setup_Curr();
            Setup_Curr.Show();
            this.Close();
        }

        private void MnCurrRateSetup_Click(object sender, EventArgs e)
        {
            Setup_Curr_Rate Setup_Curr_Rate = new Setup_Curr_Rate();
            Setup_Curr_Rate.Show();
            this.Close();
        }

        private void MnActivaPassivaSetup_Click(object sender, EventArgs e)
        {
            Setup_Activa_Passiva Setup_Activa_Passiva = new Setup_Activa_Passiva();
            Setup_Activa_Passiva.Show();
            this.Close();
        }

        private void MnIntervalSetup_Click(object sender, EventArgs e)
        {
            Setup_Interval Setup_Interval = new Setup_Interval();
            Setup_Interval.Show();
            this.Close();
        }

        private void MnFinancialYearSetup_Click(object sender, EventArgs e)
        {
            Setup_Financial_Year Setup_Financial_Year = new Setup_Financial_Year();
            Setup_Financial_Year.Show();
            this.Close();
        }

        private void MnETFStocksSuffixSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Suffix Setup_ETF_Stocks_Suffix = new Setup_ETF_Stocks_Suffix();
            Setup_ETF_Stocks_Suffix.Show();
            this.Close();
        }

        private void MnETFStocksSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks Setup_ETF_Stocks = new Setup_ETF_Stocks();
            Setup_ETF_Stocks.Show();
            this.Close();
        }

        private void MnETFStocksFlagSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Flag Setup_ETF_Stocks_Flag = new Setup_ETF_Stocks_Flag();
            Setup_ETF_Stocks_Flag.Show();
            this.Close();
        }

        private void MnETFStocksDivTypeSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Div_Type Setup_ETF_Stocks_Div_Type = new Setup_ETF_Stocks_Div_Type();
            Setup_ETF_Stocks_Div_Type.Show();
            this.Close();
        }

        private void MnETFStocksDivSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Div Setup_ETF_Stocks_Div = new Setup_ETF_Stocks_Div();
            Setup_ETF_Stocks_Div.Show();
            this.Close();
        }

        private void MnETFStocksDivAllocSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Div_Alloc Setup_ETF_Stocks_Div_Alloc = new Setup_ETF_Stocks_Div_Alloc();
            Setup_ETF_Stocks_Div_Alloc.Show();
            this.Close();
        }

        private void MnETFStocksInvPlanSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Investment_Plan Setup_ETF_Stocks_Investment_Plan = new Setup_ETF_Stocks_Investment_Plan();
            Setup_ETF_Stocks_Investment_Plan.Show();
            this.Close();
        }

        private void MnTaxAllocationSetup_Click(object sender, EventArgs e)
        {
            Setup_Tax_Allocation Setup_Tax_Allocation = new Setup_Tax_Allocation();
            Setup_Tax_Allocation.Show();
            this.Close();
        }

        private void MnStateSetup_Click(object sender, EventArgs e)
        {
            Setup_State Setup_State = new Setup_State();
            Setup_State.Show();
            this.Close();
        }

        private void MnSuperFundSetup_Click(object sender, EventArgs e)
        {
            Setup_Super_Fund Setup_Super_Fund = new Setup_Super_Fund();
            Setup_Super_Fund.Show();
            this.Close();
        }

        private void MnSuperSetup_Click(object sender, EventArgs e)
        {
            Setup_Super Setup_Super = new Setup_Super();
            Setup_Super.Show();
            this.Close();
        }

        //---- the list ---------------------------------------------------------------

        private void Clear_Grid()
        {
            gvType.Rows.Clear();
            gvType.Columns.Clear();
            gvType.ColumnCount = 1;
            gvType.Columns[0].Name = "Name";
            gvType.Columns[0].HeaderText = "Name";
            gvType.Columns[0].FillWeight = 100;
            gvType.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvType.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();
                OrgName = null;

                //Name is a reserved word in Access, so it is bracketed wherever it appears
                Mdl1.Ssql = "select [Name] from TblPropertyRentalExpenseType order by [Name]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gvType.Rows.Add(new string[] { Read_Text(reader["Name"]) });
                }
                reader.Close();

                gvType.ClearSelection();
                Filling = false;
                Show_Note();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Show_Note()
        {
            LblNote.Text = gvType.Rows.Count.ToString(CultureInfo.InvariantCulture) + " type(s)";
        }

        private string Read_Text(object parValue)
        {
            return (parValue == null || parValue == DBNull.Value ? "" : parValue.ToString().Trim());
        }

        //Access takes a single quote as the end of a string, so one typed into a name is doubled
        //rather than left to break the statement.
        private string Quote(string parText)
        {
            return (parText == null ? "" : parText.Trim().Replace("'", "''"));
        }

        //Clicking a row copies it into the box, so an existing type can be renamed or removed
        //without its name having to be typed back in by hand.
        private void gvType_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvType.SelectedRows.Count > 0)
            {
                Row = gvType.SelectedRows[0];
            }
            else
            {
                Row = gvType.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }
            OrgName = Row.Cells[0].Value.ToString().Trim();
            Type_Name.Text = OrgName;
        }

        private void Clear_Entry()
        {
            Filling = true;
            OrgName = null;
            Type_Name.Text = "";
            gvType.ClearSelection();
            Filling = false;
        }

        //---- add, update, delete ----------------------------------------------------
        //
        //Add and Update are separate, as on State Setup: one insists the name is new, the other
        //insists a row has been picked out of the grid. Nothing joins to this table yet, so
        //neither has dependent rows to carry along or guard.

        private bool Exists(string parName)
        {
            Mdl1.Ssql = "select [Name] from TblPropertyRentalExpenseType"
                      + " where [Name] = '" + Quote(parName) + "'";
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
                string TmpName = Type_Name.Text.Trim();
                if (TmpName == "")
                {
                    MessageBox.Show("Name cannot be empty !", "Error Message");
                    return;
                }
                //the name is all this table has, so it is what makes a row the row it is
                if (Exists(TmpName))
                {
                    MessageBox.Show("Name already exists : " + TmpName, "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblPropertyRentalExpenseType ([Name]) values ('"
                          + Quote(TmpName) + "')";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Name : " + TmpName, "Success");
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
                if (OrgName == null)
                {
                    MessageBox.Show("Please select a type from the list first !", "Error Message");
                    return;
                }
                string TmpName = Type_Name.Text.Trim();
                if (TmpName == "")
                {
                    MessageBox.Show("Name cannot be empty !", "Error Message");
                    return;
                }
                //renaming onto a name that already exists would make two rows the same
                if (TmpName != OrgName && Exists(TmpName))
                {
                    MessageBox.Show("Name already exists : " + TmpName, "Error Message");
                    return;
                }
                if (!Exists(OrgName))
                {
                    MessageBox.Show("Data not found for Name : " + OrgName, "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblPropertyRentalExpenseType set [Name] = '" + Quote(TmpName)
                          + "' where [Name] = '" + Quote(OrgName) + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for Name : " + TmpName, "Success");
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
                if (OrgName == null)
                {
                    MessageBox.Show("Please select a type from the list first !", "Error Message");
                    return;
                }
                if (MessageBox.Show("Delete the type " + OrgName + " ?", "Confirmation",
                        MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblPropertyRentalExpenseType"
                          + " where [Name] = '" + Quote(OrgName) + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Name : " + OrgName, "Success");
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
