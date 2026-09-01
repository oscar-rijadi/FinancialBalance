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
    public partial class Setup_Curr : Form
    {
        public Setup_Curr()
        {
            InitializeComponent();
        }

        private void Setup_Curr_Load(object sender, EventArgs e)
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

        private void Clear_Grid()
        {
            gvCurr.Columns.Clear();
            gvCurr.ColumnCount = 2;
            gvCurr.Columns[0].Name = "Curr Code";
            gvCurr.Columns[0].FillWeight = 25;
            gvCurr.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCurr.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCurr.Columns[1].Name = "Curr Name";
            gvCurr.Columns[1].FillWeight = 75;
            gvCurr.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvCurr.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;            
        }

        private void Get_Data()
        {
            Clear_Grid();

            string[] row;

            Mdl1.Ssql = "select Curr_Code, Curr_Name from TblCurrCode order by Curr_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = new string[] { reader["Curr_Code"].ToString().Trim(), reader["Curr_Name"].ToString().Trim() };
                    gvCurr.Rows.Add(row);
                }
            }
            reader.Close();
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;

                Mdl1.Ssql = "select * from TblCurrCode where Curr_Code = '" + Curr_Code.Text.Trim() + "'";
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
                    Mdl1.Ssql = "Insert into TblCurrCode values ('" + Curr_Code.Text.Trim() + "', '" + Curr_Name.Text.Trim() + "')";
                }
                else
                {
                    Mdl1.Ssql = "Update TblCurrCode set Curr_Name = '" + Curr_Name.Text.Trim() + "' where Curr_Code = '" + Curr_Code.Text.Trim() + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create or Update successfully for Currency Code : " + Curr_Code.Text.Trim(), "Success");

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

                Mdl1.Ssql = "select * from TblCurrCode where Curr_Code = '" + Curr_Code.Text.Trim() + "'";
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
                    MessageBox.Show("Data not found for Currency Code : " + Curr_Code.Text.Trim(), "Error Message");
                    return;
                }
                else
                {
                    Mdl1.Ssql = "Delete from TblCurrCode  where Curr_Code = '" + Curr_Code.Text.Trim() + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Currency Code : " + Curr_Code.Text.Trim(), "Success");

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
