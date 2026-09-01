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
    public partial class Setup_Acct_Type_Ref : Form
    {
        public Setup_Acct_Type_Ref()
        {
            InitializeComponent();
        }

        private void Setup_Acct_Type_Ref_Load(object sender, EventArgs e)
        {
            Get_Data();
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
            gvAcctTypeRef.Columns.Clear();
            gvAcctTypeRef.ColumnCount = 2;
            gvAcctTypeRef.Columns[0].Name = "Accounting Type";
            gvAcctTypeRef.Columns[0].FillWeight = 25;
            gvAcctTypeRef.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctTypeRef.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctTypeRef.Columns[1].Name = "Accounting Type Name";
            gvAcctTypeRef.Columns[1].FillWeight = 75;
            gvAcctTypeRef.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvAcctTypeRef.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;            
        }

        private void Get_Data()
        {
            Clear_Grid();

            string[] row;

            Mdl1.Ssql = "Select Acct_Type, Acct_Type_Name from TblAcctTypeRef order by Acct_Type";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = new string[] { reader["Acct_Type"].ToString().Trim(), reader["Acct_Type_Name"].ToString().Trim() };
                    gvAcctTypeRef.Rows.Add(row);                    
                }
            }
            reader.Close();
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;

                Mdl1.Ssql = "select * from TblAcctTypeRef where Acct_Type = '" + Acct_Type.Text.Trim() + "'";
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
                    Mdl1.Ssql = "Insert into TblAcctTypeRef values ('" + Acct_Type.Text.Trim() + "', '" + Acct_Type_Name.Text.Trim() + "')";
                }
                else
                {
                    Mdl1.Ssql = "Update TblAcctTypeRef set Acct_Type_Name = '" + Acct_Type_Name.Text.Trim() + "' where Acct_Type = '" + Acct_Type.Text.Trim() + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create or Update successfully for Acct Type : " + Acct_Type.Text.Trim(), "Success");

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

                Mdl1.Ssql = "select * from TblAcctTypeRef where Acct_Type = '" + Acct_Type.Text.Trim() + "'";
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
                    MessageBox.Show("Data not found for Acct Type : " + Acct_Type.Text.Trim(), "Error Message");
                    return;
                }
                else
                {
                    Mdl1.Ssql = "Delete from TblAcctTypeRef  where Acct_Type = '" + Acct_Type.Text.Trim() + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Acct Type : " + Acct_Type.Text.Trim(), "Success");

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
