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
    public partial class Setup_ETF_Stocks_Flag : Form
    {
        bool Filling;

        public Setup_ETF_Stocks_Flag()
        {
            InitializeComponent();
        }

        private void Setup_ETF_Stocks_Flag_Load(object sender, EventArgs e)
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

        private void Clear_Grid()
        {
            gvFlag.Columns.Clear();
            gvFlag.ColumnCount = 2;
            gvFlag.Columns[0].Name = "Flag Code";
            gvFlag.Columns[0].FillWeight = 25;
            gvFlag.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvFlag.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvFlag.Columns[1].Name = "Description";
            gvFlag.Columns[1].FillWeight = 75;
            gvFlag.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvFlag.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Get_Data()
        {
            Filling = true;

            Clear_Grid();

            string[] row;

            Mdl1.Ssql = "select Flag_Code, [Description] from TblETFStocksPurchaseFlag order by Flag_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = new string[] { reader["Flag_Code"].ToString().Trim(), reader["Description"].ToString().Trim() };
                    gvFlag.Rows.Add(row);
                }
            }
            reader.Close();

            gvFlag.ClearSelection();

            Filling = false;
        }

        //Clicking a row loads it back into the inputs so it can be amended or deleted
        private void gvFlag_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            if (gvFlag.CurrentRow == null || gvFlag.CurrentRow.Cells[0].Value == null)
            {
                return;
            }

            Flag_Code.Text = gvFlag.CurrentRow.Cells[0].Value.ToString().Trim();
            if (gvFlag.CurrentRow.Cells[1].Value != null)
            {
                Description.Text = gvFlag.CurrentRow.Cells[1].Value.ToString().Trim();
            }
            else
            {
                Description.Text = "";
            }
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;

                if (Flag_Code.Text.Trim() == "")
                {
                    MessageBox.Show("Flag Code cannot be empty !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "select * from TblETFStocksPurchaseFlag where Flag_Code = '" + Flag_Code.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    FlagRecNotExist = false;
                }
                else
                {
                    FlagRecNotExist = true;
                }
                reader.Close();

                if (FlagRecNotExist)
                {
                    Mdl1.Ssql = "Insert into TblETFStocksPurchaseFlag ([Flag_Code], [Description]) values ('"
                        + Flag_Code.Text.Trim() + "', '" + Description.Text.Trim() + "')";
                }
                else
                {
                    Mdl1.Ssql = "Update TblETFStocksPurchaseFlag set [Description] = '" + Description.Text.Trim()
                        + "' where Flag_Code = '" + Flag_Code.Text.Trim() + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create or Update successfully for Flag Code : " + Flag_Code.Text.Trim(), "Success");

                Get_Data();
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
                bool FlagRecNotExist;

                Mdl1.Ssql = "select * from TblETFStocksPurchaseFlag where Flag_Code = '" + Flag_Code.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    FlagRecNotExist = false;
                }
                else
                {
                    FlagRecNotExist = true;
                }
                reader.Close();

                if (FlagRecNotExist)
                {
                    MessageBox.Show("Data not found for Flag Code : " + Flag_Code.Text.Trim(), "Error Message");
                    return;
                }
                else
                {
                    Mdl1.Ssql = "Delete from TblETFStocksPurchaseFlag  where Flag_Code = '" + Flag_Code.Text.Trim() + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Flag Code : " + Flag_Code.Text.Trim(), "Success");

                Get_Data();
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
