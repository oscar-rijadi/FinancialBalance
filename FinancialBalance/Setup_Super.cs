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
    public partial class Setup_Super : Form
    {
        bool Filling;

        //TblSuper has no key, so a row is identified by the values it held when it was picked
        //out of the grid.
        bool RowSelected;
        string OrgSuperCode;
        string OrgName;
        string OrgSuperFundName;

        public Setup_Super()
        {
            InitializeComponent();
        }

        private void Setup_Super_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Super_Fund();
            Filling = false;
            Get_Data();
        }

        //---- the menu -------------------------------------------------------------

        private void MnStateSetup_Click(object sender, EventArgs e)
        {
            Setup_State Setup_State = new Setup_State();
            Setup_State.Show();
            this.Close();
        }

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

        private void MnSuperFundSetup_Click(object sender, EventArgs e)
        {
            Setup_Super_Fund Setup_Super_Fund = new Setup_Super_Fund();
            Setup_Super_Fund.Show();
            this.Close();
        }

        //---- the fund dropdown ----------------------------------------------------

        private void Fill_Super_Fund()
        {
            CmbSuperFundName.Items.Clear();
            Mdl1.Ssql = "select [Name] from TblSuperFund order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbSuperFundName.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();
            if (CmbSuperFundName.Items.Count > 0)
            {
                CmbSuperFundName.SelectedIndex = 0;
            }
        }

        //---- the table ------------------------------------------------------------

        private void Clear_Grid()
        {
            gvSuper.Rows.Clear();
            gvSuper.Columns.Clear();
            gvSuper.ColumnCount = 3;
            string[] names = new string[] { "Super Code", "Name", "Super Fund Name" };
            int[] weights = new int[] { 16, 44, 40 };
            for (int i = 0; i < 3; i++)
            {
                gvSuper.Columns[i].Name = names[i];
                gvSuper.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign =
                    (i == 0 ? DataGridViewContentAlignment.MiddleCenter : DataGridViewContentAlignment.MiddleLeft);
                gvSuper.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvSuper.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();
                RowSelected = false;

                Mdl1.Ssql = "select [Super_Code], [Name], [Super_Fund_Name] from TblSuper order by [Super_Code]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gvSuper.Rows.Add(new string[] {
                        Read_Text(reader["Super_Code"]),
                        Read_Text(reader["Name"]),
                        Read_Text(reader["Super_Fund_Name"]) });
                }
                reader.Close();

                gvSuper.ClearSelection();
                Filling = false;
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private string Read_Text(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return "";
            }
            return parValue.ToString().Trim();
        }

        private void gvSuper_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //SelectionChanged fires while CurrentRow can still be pointing at the row being left
            DataGridViewRow Row = null;
            if (gvSuper.SelectedRows.Count > 0)
            {
                Row = gvSuper.SelectedRows[0];
            }
            else
            {
                Row = gvSuper.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            OrgSuperCode = Row.Cells[0].Value.ToString().Trim();
            OrgName = (Row.Cells[1].Value == null ? "" : Row.Cells[1].Value.ToString().Trim());
            OrgSuperFundName = (Row.Cells[2].Value == null ? "" : Row.Cells[2].Value.ToString().Trim());

            Filling = true;
            txtSuperCode.Text = OrgSuperCode;
            txtName.Text = OrgName;
            if (CmbSuperFundName.Items.Contains(OrgSuperFundName))
            {
                CmbSuperFundName.Text = OrgSuperFundName;
            }
            Filling = false;

            RowSelected = true;
        }

        //---- add, update, delete --------------------------------------------------

        private bool Validate_Entry()
        {
            if (txtSuperCode.Text.Trim() == "")
            {
                MessageBox.Show("Super Code cannot be empty !", "Error Message");
                return false;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Name cannot be empty !", "Error Message");
                return false;
            }
            if (CmbSuperFundName.Text.Trim() == "")
            {
                MessageBox.Show("Super Fund Name must be selected ! Please set one up first in Super Fund Setup.", "Error Message");
                return false;
            }
            return true;
        }

        private bool Code_Exists(string parCode)
        {
            bool Found = false;
            Mdl1.Ssql = "select [Super_Code] from TblSuper where [Super_Code] = '" + parCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        //Without a key the row is found again by every value it was read with
        private string Where_Original()
        {
            return " where [Super_Code] = '" + OrgSuperCode + "'"
                 + (OrgName == "" ? " and ([Name] Is Null or [Name] = '')" : " and [Name] = '" + OrgName + "'")
                 + (OrgSuperFundName == "" ? " and ([Super_Fund_Name] Is Null or [Super_Fund_Name] = '')"
                                           : " and [Super_Fund_Name] = '" + OrgSuperFundName + "'");
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate_Entry())
                {
                    return;
                }
                //Super Code is what identifies a super account, so it is kept unique
                if (Code_Exists(txtSuperCode.Text.Trim()))
                {
                    MessageBox.Show("Super Code already exists : " + txtSuperCode.Text.Trim(), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblSuper ([Super_Code], [Name], [Super_Fund_Name]) values ("
                          + "'" + txtSuperCode.Text.Trim() + "', "
                          + "'" + txtName.Text.Trim() + "', "
                          + "'" + CmbSuperFundName.Text.Trim() + "')";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Super Code : " + txtSuperCode.Text.Trim(), "Success");
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
                if (!RowSelected)
                {
                    MessageBox.Show("Please select a super record from the list first !", "Error Message");
                    return;
                }
                if (!Validate_Entry())
                {
                    return;
                }
                if (txtSuperCode.Text.Trim() != OrgSuperCode && Code_Exists(txtSuperCode.Text.Trim()))
                {
                    MessageBox.Show("Super Code already exists : " + txtSuperCode.Text.Trim(), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblSuper set "
                          + "[Super_Code] = '" + txtSuperCode.Text.Trim() + "', "
                          + "[Name] = '" + txtName.Text.Trim() + "', "
                          + "[Super_Fund_Name] = '" + CmbSuperFundName.Text.Trim() + "'"
                          + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for Super Code : " + txtSuperCode.Text.Trim(), "Success");
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
                if (!RowSelected)
                {
                    MessageBox.Show("Please select a super record from the list first !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblSuper" + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Super Code : " + OrgSuperCode, "Success");
                Get_Data();
                Clear_Entry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Clear_Entry()
        {
            Filling = true;
            RowSelected = false;
            txtSuperCode.Text = "";
            txtName.Text = "";
            if (CmbSuperFundName.Items.Count > 0)
            {
                CmbSuperFundName.SelectedIndex = 0;
            }
            Filling = false;
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
