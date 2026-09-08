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
    public partial class Setup_Super_Fund : Form
    {
        bool Filling;

        //TblSuperFund has no key and only one column, so the name a row was read with is what
        //identifies it again.
        string OrgName;

        public Setup_Super_Fund()
        {
            InitializeComponent();
        }

        private void Setup_Super_Fund_Load(object sender, EventArgs e)
        {
            Get_Data();
        }

        //---- the menu -------------------------------------------------------------

        private void MnETFStocksInvPlanSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Investment_Plan Setup_ETF_Stocks_Investment_Plan = new Setup_ETF_Stocks_Investment_Plan();
            Setup_ETF_Stocks_Investment_Plan.Show();
            this.Close();
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

        private void MnSuperSetup_Click(object sender, EventArgs e)
        {
            Setup_Super Setup_Super = new Setup_Super();
            Setup_Super.Show();
            this.Close();
        }

        //---- the table ------------------------------------------------------------

        private void Clear_Grid()
        {
            gvFund.Rows.Clear();
            gvFund.Columns.Clear();
            gvFund.ColumnCount = 1;
            gvFund.Columns[0].Name = "Name";
            gvFund.Columns[0].FillWeight = 100;
            gvFund.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvFund.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();
                OrgName = null;

                Mdl1.Ssql = "select [Name] from TblSuperFund order by [Name]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gvFund.Rows.Add(new string[] { reader["Name"].ToString().Trim() });
                }
                reader.Close();

                gvFund.ClearSelection();
                Filling = false;
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Clicking a row copies it into the box, and remembers what it was so an update knows
        //which row it is changing.
        private void gvFund_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvFund.SelectedRows.Count > 0)
            {
                Row = gvFund.SelectedRows[0];
            }
            else
            {
                Row = gvFund.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }
            OrgName = Row.Cells[0].Value.ToString().Trim();
            txtName.Text = OrgName;
        }

        //---- add, update, delete --------------------------------------------------

        private bool Exists(string parName)
        {
            bool Found = false;
            Mdl1.Ssql = "select [Name] from TblSuperFund where [Name] = '" + parName + "'";
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
                string TmpName = txtName.Text.Trim();
                if (TmpName == "")
                {
                    MessageBox.Show("Name cannot be empty !", "Error Message");
                    return;
                }
                if (Exists(TmpName))
                {
                    MessageBox.Show("Name already exists : " + TmpName, "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblSuperFund ([Name]) values ('" + TmpName + "')";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Name : " + TmpName, "Success");
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
                if (OrgName == null)
                {
                    MessageBox.Show("Please select a super fund from the list first !", "Error Message");
                    return;
                }
                string TmpName = txtName.Text.Trim();
                if (TmpName == "")
                {
                    MessageBox.Show("Name cannot be empty !", "Error Message");
                    return;
                }
                if (TmpName == OrgName)
                {
                    MessageBox.Show("Name has not been changed.", "Error Message");
                    return;
                }
                if (Exists(TmpName))
                {
                    MessageBox.Show("Name already exists : " + TmpName, "Error Message");
                    return;
                }

                //The fund name is stored on each super record rather than referenced, so renaming
                //it here would orphan those rows.  They are carried across with it.
                int TmpUsed = 0;
                Mdl1.Ssql = "select Count(*) as N from TblSuper where [Super_Fund_Name] = '" + OrgName + "'";
                OleDbCommand cnt = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cnt.ExecuteReader();
                if (reader.Read())
                {
                    TmpUsed = int.Parse(reader["N"].ToString());
                }
                reader.Close();

                if (TmpUsed > 0)
                {
                    DialogResult Response = MessageBox.Show(
                        TmpUsed.ToString() + " super record(s) name this fund. They will be renamed with it. Continue ?",
                        "Confirmation", MessageBoxButtons.OKCancel);
                    if (Response != DialogResult.OK)
                    {
                        return;
                    }
                }

                Mdl1.Ssql = "Update TblSuperFund set [Name] = '" + TmpName + "' where [Name] = '" + OrgName + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                if (TmpUsed > 0)
                {
                    Mdl1.Ssql = "Update TblSuper set [Super_Fund_Name] = '" + TmpName + "'"
                              + " where [Super_Fund_Name] = '" + OrgName + "'";
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Update successfully for Name : " + TmpName, "Success");
                Get_Data();
                txtName.Text = "";
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
                string TmpName = txtName.Text.Trim();
                if (TmpName == "")
                {
                    MessageBox.Show("Please select a super fund from the list first !", "Error Message");
                    return;
                }
                if (!Exists(TmpName))
                {
                    MessageBox.Show("Data not found for Name : " + TmpName, "Error Message");
                    return;
                }

                //A super record naming this fund would be left pointing at nothing
                int TmpUsed = 0;
                Mdl1.Ssql = "select Count(*) as N from TblSuper where [Super_Fund_Name] = '" + TmpName + "'";
                OleDbCommand cnt = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cnt.ExecuteReader();
                if (reader.Read())
                {
                    TmpUsed = int.Parse(reader["N"].ToString());
                }
                reader.Close();

                if (TmpUsed > 0)
                {
                    MessageBox.Show(TmpUsed.ToString() + " super record(s) name this fund, so it cannot be deleted."
                        + Environment.NewLine + "Change or remove those records first, in Super Setup.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblSuperFund where [Name] = '" + TmpName + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Name : " + TmpName, "Success");
                Get_Data();
                txtName.Text = "";
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
