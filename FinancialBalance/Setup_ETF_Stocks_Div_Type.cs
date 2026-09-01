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
    public partial class Setup_ETF_Stocks_Div_Type : Form
    {
        bool Filling;

        public Setup_ETF_Stocks_Div_Type()
        {
            InitializeComponent();
        }

        private void Setup_ETF_Stocks_Div_Type_Load(object sender, EventArgs e)
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

        private void MnETFStocksFlagSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Flag Setup_ETF_Stocks_Flag = new Setup_ETF_Stocks_Flag();
            Setup_ETF_Stocks_Flag.Show();
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
            gvDivType.Rows.Clear();
            gvDivType.Columns.Clear();
            gvDivType.ColumnCount = 1;
            gvDivType.Columns[0].Name = "Name";
            gvDivType.Columns[0].FillWeight = 100;
            gvDivType.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvDivType.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Get_Data()
        {
            Filling = true;

            Clear_Grid();

            Mdl1.Ssql = "select [Name] from TblETFStocksDiversificationType order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                gvDivType.Rows.Add(new string[] { reader["Name"].ToString().Trim() });
            }
            reader.Close();

            gvDivType.ClearSelection();

            Filling = false;
        }

        //Clicking a row loads it back into the input so it can be amended or deleted
        private void gvDivType_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            if (gvDivType.CurrentRow == null || gvDivType.CurrentRow.Cells[0].Value == null)
            {
                return;
            }
            Div_Type_Name.Text = gvDivType.CurrentRow.Cells[0].Value.ToString().Trim();
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;

                if (Div_Type_Name.Text.Trim() == "")
                {
                    MessageBox.Show("Name cannot be empty !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "select * from TblETFStocksDiversificationType where [Name] = '" + Div_Type_Name.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                FlagRecNotExist = !reader.HasRows;
                reader.Close();

                if (!FlagRecNotExist)
                {
                    MessageBox.Show("Diversification Type already exists : " + Div_Type_Name.Text.Trim(), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksDiversificationType ([Name]) values ('" + Div_Type_Name.Text.Trim() + "')";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Diversification Type : " + Div_Type_Name.Text.Trim(), "Success");

                Get_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //A type in use by TblETFStocksDiversification is kept, so the two tables stay in step
        private void CmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;
                int TmpUsed = 0;

                Mdl1.Ssql = "select * from TblETFStocksDiversificationType where [Name] = '" + Div_Type_Name.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                FlagRecNotExist = !reader.HasRows;
                reader.Close();

                if (FlagRecNotExist)
                {
                    MessageBox.Show("Data not found for Diversification Type : " + Div_Type_Name.Text.Trim(), "Error Message");
                    return;
                }

                Mdl1.Ssql = "select count(*) as N from TblETFStocksDiversification where [Type] = '" + Div_Type_Name.Text.Trim() + "'";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TmpUsed = int.Parse(reader["N"].ToString());
                }
                reader.Close();

                if (TmpUsed > 0)
                {
                    MessageBox.Show(Div_Type_Name.Text.Trim() + " is used by " + TmpUsed.ToString()
                        + " diversification(s). Remove those first.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksDiversificationType  where [Name] = '" + Div_Type_Name.Text.Trim() + "'";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Diversification Type : " + Div_Type_Name.Text.Trim(), "Success");

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
