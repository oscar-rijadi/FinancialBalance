using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FinancialBalance
{
    public partial class Setup_State : Form
    {
        //true while Get_Data is refilling the grid, so the rows it adds do not fire the selection
        //handler and type themselves back into the boxes
        bool Filling;

        //The code of the row picked out of the grid, so Update knows which row it is changing -
        //without it a changed code would be indistinguishable from a new one. Null until a row is
        //picked, which is what makes Update refuse before Add has anything to work on.
        string OrgCode;

        //The state codes are the official Australian abbreviations, so three characters is the
        //widest of them rather than a fixed width: NT, SA and WA are two.
        public Setup_State()
        {
            InitializeComponent();
        }

        private void Setup_State_Load(object sender, EventArgs e)
        {
            Get_Data();
        }

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

        private void Clear_Grid()
        {
            gvState.Columns.Clear();
            gvState.ColumnCount = 2;
            gvState.Columns[0].Name = "State Code";
            gvState.Columns[0].FillWeight = 25;
            gvState.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvState.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvState.Columns[1].Name = "State Name";
            gvState.Columns[1].FillWeight = 75;
            gvState.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvState.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();
                OrgCode = null;

                string[] row;

                //Name is a reserved word in Access, so it is bracketed wherever it appears
                Mdl1.Ssql = "select [Name], [Long_Name] from TblState order by [Name]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        row = new string[] { reader["Name"].ToString().Trim(), reader["Long_Name"].ToString().Trim() };
                        gvState.Rows.Add(row);
                    }
                }
                reader.Close();

                gvState.ClearSelection();
                Filling = false;
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Clicking a row copies it into the boxes, so an existing state can be changed or removed
        //without its code having to be typed back in by hand.
        private void gvState_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvState.SelectedRows.Count > 0)
            {
                Row = gvState.SelectedRows[0];
            }
            else
            {
                Row = gvState.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }
            OrgCode = Row.Cells[0].Value.ToString().Trim();
            State_Code.Text = OrgCode;
            State_Name.Text = (Row.Cells[1].Value == null ? "" : Row.Cells[1].Value.ToString().Trim());
        }

        //---- add, update, delete --------------------------------------------------
        //
        //Add and Update are separate, as on Super Fund Setup: one insists the code is new, the
        //other insists a row has been picked out of the grid. Nothing joins to TblState yet, so
        //neither has dependent rows to carry along or guard - unlike Super Fund Setup, where a
        //rename has to be pushed into TblSuper.

        private bool Exists(string parCode)
        {
            bool Found = false;
            Mdl1.Ssql = "select [Name] from TblState where [Name] = '" + parCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpCode = State_Code.Text.Trim();
                string TmpName = State_Name.Text.Trim();
                if (TmpCode == "")
                {
                    MessageBox.Show("State Code cannot be empty !", "Error Message");
                    return;
                }
                if (Exists(TmpCode))
                {
                    MessageBox.Show("State Code already exists : " + TmpCode, "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblState ([Name], [Long_Name]) values ('"
                          + TmpCode + "', '" + TmpName + "')";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for State Code : " + TmpCode, "Success");
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
                if (OrgCode == null)
                {
                    MessageBox.Show("Please select a state from the list first !", "Error Message");
                    return;
                }
                string TmpCode = State_Code.Text.Trim();
                string TmpName = State_Name.Text.Trim();
                if (TmpCode == "")
                {
                    MessageBox.Show("State Code cannot be empty !", "Error Message");
                    return;
                }

                //The row is found by the code it was picked under, so a changed code is a rename
                //of that row rather than a new one - which is the difference between this button
                //and Add. A code already in use would collide.
                if (TmpCode != OrgCode && Exists(TmpCode))
                {
                    MessageBox.Show("State Code already exists : " + TmpCode, "Error Message");
                    return;
                }
                if (TmpCode == OrgCode && TmpName == Org_Long_Name())
                {
                    MessageBox.Show("Nothing has been changed.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblState set [Name] = '" + TmpCode + "',"
                          + " [Long_Name] = '" + TmpName + "'"
                          + " where [Name] = '" + OrgCode + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for State Code : " + TmpCode, "Success");
                Get_Data();
                State_Code.Text = "";
                State_Name.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //What the picked row's name was, read back so an update that changes nothing can be told
        //apart from one that changes only the name.
        private string Org_Long_Name()
        {
            string TmpName = "";
            Mdl1.Ssql = "select [Long_Name] from TblState where [Name] = '" + OrgCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpName = reader["Long_Name"].ToString().Trim();
            }
            reader.Close();
            return TmpName;
        }

        private void CmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpCode = State_Code.Text.Trim();
                if (TmpCode == "")
                {
                    MessageBox.Show("Please select a state from the list first !", "Error Message");
                    return;
                }
                if (!Exists(TmpCode))
                {
                    MessageBox.Show("Data not found for State Code : " + TmpCode, "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblState where [Name] = '" + TmpCode + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for State Code : " + TmpCode, "Success");
                Get_Data();
                State_Code.Text = "";
                State_Name.Text = "";
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
