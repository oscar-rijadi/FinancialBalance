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
    public partial class Setup_ETF_Stocks_Div : Form
    {
        bool Filling;

        public Setup_ETF_Stocks_Div()
        {
            InitializeComponent();
        }

        private void Setup_ETF_Stocks_Div_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Div_Type();
            Filling = false;

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

        private void MnETFStocksDivAllocSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Div_Alloc Setup_ETF_Stocks_Div_Alloc = new Setup_ETF_Stocks_Div_Alloc();
            Setup_ETF_Stocks_Div_Alloc.Show();
            this.Close();
        }

        //The Type list is exactly the rows of TblETFStocksDiversificationType
        private void Fill_Div_Type()
        {
            CmbDivType.Items.Clear();
            Mdl1.Ssql = "select [Name] from TblETFStocksDiversificationType order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbDivType.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();
            if (CmbDivType.Items.Count > 0)
            {
                CmbDivType.Text = CmbDivType.Items[0].ToString();
            }
        }

        private void Clear_Grid()
        {
            gvDiv.Rows.Clear();
            gvDiv.Columns.Clear();
            gvDiv.ColumnCount = 2;
            gvDiv.Columns[0].Name = "Type";
            gvDiv.Columns[0].FillWeight = 40;
            gvDiv.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvDiv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvDiv.Columns[1].Name = "Name";
            gvDiv.Columns[1].FillWeight = 60;
            gvDiv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvDiv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Get_Data()
        {
            Filling = true;

            Clear_Grid();

            Mdl1.Ssql = "select [Type], [Name] from TblETFStocksDiversification order by [Type], [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                gvDiv.Rows.Add(new string[] { reader["Type"].ToString().Trim(), reader["Name"].ToString().Trim() });
            }
            reader.Close();

            gvDiv.ClearSelection();

            Filling = false;
        }

        //Clicking a row loads it back into the inputs so it can be amended or deleted
        private void gvDiv_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            if (gvDiv.CurrentRow == null || gvDiv.CurrentRow.Cells[0].Value == null)
            {
                return;
            }

            string TmpType = gvDiv.CurrentRow.Cells[0].Value.ToString().Trim();
            if (CmbDivType.Items.Contains(TmpType))
            {
                CmbDivType.Text = TmpType;
            }
            Div_Name.Text = gvDiv.CurrentRow.Cells[1].Value.ToString().Trim();
        }

        //Type plus Name is the key, so an existing pair cannot be added twice
        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;

                if (CmbDivType.Text.Trim() == "")
                {
                    MessageBox.Show("Type must be selected ! Please set one up first in ETF/Stock Diversification Type Setup.", "Error Message");
                    return;
                }
                if (Div_Name.Text.Trim() == "")
                {
                    MessageBox.Show("Name cannot be empty !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "select * from TblETFStocksDiversification where [Type] = '" + CmbDivType.Text.Trim()
                          + "' and [Name] = '" + Div_Name.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                FlagRecNotExist = !reader.HasRows;
                reader.Close();

                if (!FlagRecNotExist)
                {
                    MessageBox.Show("Diversification already exists : " + CmbDivType.Text.Trim() + " / " + Div_Name.Text.Trim(), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksDiversification ([Type], [Name]) values ('"
                          + CmbDivType.Text.Trim() + "', '" + Div_Name.Text.Trim() + "')";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Diversification : " + CmbDivType.Text.Trim() + " / " + Div_Name.Text.Trim(), "Success");

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

                Mdl1.Ssql = "select * from TblETFStocksDiversification where [Type] = '" + CmbDivType.Text.Trim()
                          + "' and [Name] = '" + Div_Name.Text.Trim() + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                FlagRecNotExist = !reader.HasRows;
                reader.Close();

                if (FlagRecNotExist)
                {
                    MessageBox.Show("Data not found for Diversification : " + CmbDivType.Text.Trim() + " / " + Div_Name.Text.Trim(), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksDiversification  where [Type] = '" + CmbDivType.Text.Trim()
                          + "' and [Name] = '" + Div_Name.Text.Trim() + "'";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Diversification : " + CmbDivType.Text.Trim() + " / " + Div_Name.Text.Trim(), "Success");

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
