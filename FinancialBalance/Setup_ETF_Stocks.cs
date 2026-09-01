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
    public partial class Setup_ETF_Stocks : Form
    {
        bool Filling;

        public Setup_ETF_Stocks()
        {
            InitializeComponent();
        }

        private void Setup_ETF_Stocks_Load(object sender, EventArgs e)
        {
            Filling = true;
            Mdl1.Fill_ETF_Stocks_Exchange_Suffix(CmbExchangeSuffix);
            Mdl1.Fill_Yes_No(CmbInYahooFinance);
            Filling = false;

            Calculate_Full_Ticker();
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

        //Full Ticker is derived, never typed : "None" suffix means the ticker stands alone
        private void Calculate_Full_Ticker()
        {
            string TmpTicker = Ticker.Text.Trim();
            string TmpSuffix = CmbExchangeSuffix.Text.Trim();

            if (TmpSuffix == "None" || TmpSuffix == "")
            {
                Full_Ticker.Text = TmpTicker;
            }
            else
            {
                Full_Ticker.Text = TmpTicker + "." + TmpSuffix;
            }
        }

        private void Ticker_TextChanged(object sender, EventArgs e)
        {
            Calculate_Full_Ticker();
        }

        private void CmbExchangeSuffix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Calculate_Full_Ticker();
        }

        private void Clear_Grid()
        {
            gvETFStocks.Columns.Clear();
            gvETFStocks.ColumnCount = 4;
            gvETFStocks.Columns[0].Name = "Ticker";
            gvETFStocks.Columns[0].FillWeight = 25;
            gvETFStocks.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[1].Name = "Exchange Suffix";
            gvETFStocks.Columns[1].FillWeight = 25;
            gvETFStocks.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[2].Name = "Full Ticker";
            gvETFStocks.Columns[2].FillWeight = 30;
            gvETFStocks.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[3].Name = "In Yahoo Finance";
            gvETFStocks.Columns[3].FillWeight = 20;
            gvETFStocks.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Get_Data()
        {
            Filling = true;

            Clear_Grid();

            string[] row;
            string strInYahooFinance;

            Mdl1.Ssql = "select Ticker, Exchange_Suffix, Full_Ticker, In_YahooFinance from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["In_YahooFinance"].ToString().Trim() == "True")
                    {
                        strInYahooFinance = "Y";
                    }
                    else
                    {
                        strInYahooFinance = "N";
                    }
                    row = new string[] { reader["Ticker"].ToString().Trim(), reader["Exchange_Suffix"].ToString().Trim(), reader["Full_Ticker"].ToString().Trim(), strInYahooFinance };
                    gvETFStocks.Rows.Add(row);
                }
            }
            reader.Close();

            gvETFStocks.ClearSelection();

            Filling = false;
        }

        //Clicking a row loads it back into the entry fields
        private void gvETFStocks_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            if (gvETFStocks.CurrentRow == null || gvETFStocks.CurrentRow.Cells[0].Value == null)
            {
                return;
            }

            Filling = true;
            Ticker.Text = gvETFStocks.CurrentRow.Cells[0].Value.ToString().Trim();
            CmbExchangeSuffix.Text = gvETFStocks.CurrentRow.Cells[1].Value.ToString().Trim();
            CmbInYahooFinance.Text = gvETFStocks.CurrentRow.Cells[3].Value.ToString().Trim();
            Filling = false;

            Calculate_Full_Ticker();
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;
                string strInYahooFinance;

                if (Ticker.Text.Trim() == "")
                {
                    MessageBox.Show("Ticker cannot be empty !", "Error Message");
                    return;
                }

                if (CmbExchangeSuffix.Text.Trim() == "")
                {
                    MessageBox.Show("Exchange Suffix must be selected ! Please set one up first in ETF/Stock Suffix Setup.", "Error Message");
                    return;
                }

                Calculate_Full_Ticker();

                if (CmbInYahooFinance.Text.Trim() == "Y")
                {
                    strInYahooFinance = "1";
                }
                else
                {
                    strInYahooFinance = "0";
                }

                Mdl1.Ssql = "select * from TblETFStocks where Full_Ticker = '" + Full_Ticker.Text.Trim() + "'";
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
                    Mdl1.Ssql = "Insert into TblETFStocks (Ticker, Exchange_Suffix, Full_Ticker, In_YahooFinance) values ('" + Ticker.Text.Trim() + "', '" + CmbExchangeSuffix.Text.Trim() + "', '" + Full_Ticker.Text.Trim() + "', " + strInYahooFinance + ")";
                }
                else
                {
                    Mdl1.Ssql = "Update TblETFStocks set Ticker = '" + Ticker.Text.Trim() + "', Exchange_Suffix = '" + CmbExchangeSuffix.Text.Trim() + "', In_YahooFinance = " + strInYahooFinance + " where Full_Ticker = '" + Full_Ticker.Text.Trim() + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create or Update successfully for Full Ticker : " + Full_Ticker.Text.Trim(), "Success");

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

                Calculate_Full_Ticker();

                Mdl1.Ssql = "select * from TblETFStocks where Full_Ticker = '" + Full_Ticker.Text.Trim() + "'";
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
                    MessageBox.Show("Data not found for Full Ticker : " + Full_Ticker.Text.Trim(), "Error Message");
                    return;
                }
                else
                {
                    Mdl1.Ssql = "Delete from TblETFStocks  where Full_Ticker = '" + Full_Ticker.Text.Trim() + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Full Ticker : " + Full_Ticker.Text.Trim(), "Success");

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
