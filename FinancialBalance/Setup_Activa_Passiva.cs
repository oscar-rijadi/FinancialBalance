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
    public partial class Setup_Activa_Passiva : Form
    {
        public Setup_Activa_Passiva()
        {
            InitializeComponent();
        }

        private void Setup_Activa_Passiva_Load(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Type_Trans(CmbAcctType, "1,2");
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

        private void Clear_Grid()
        {
            gvActivaPassiva.Columns.Clear();
            gvActivaPassiva.ColumnCount = 5;
            gvActivaPassiva.Columns[0].Name = "Acct Code";
            gvActivaPassiva.Columns[0].FillWeight = 10;
            gvActivaPassiva.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActivaPassiva.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActivaPassiva.Columns[1].Name = "Acct Name";
            gvActivaPassiva.Columns[1].FillWeight = 32;
            gvActivaPassiva.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvActivaPassiva.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvActivaPassiva.Columns[2].Name = "Curr Code";
            gvActivaPassiva.Columns[2].FillWeight = 10;
            gvActivaPassiva.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActivaPassiva.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActivaPassiva.Columns[3].Name = "Balance";
            gvActivaPassiva.Columns[3].FillWeight = 24;
            gvActivaPassiva.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActivaPassiva.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActivaPassiva.Columns[4].Name = "Balance (IDR)";
            gvActivaPassiva.Columns[4].FillWeight = 24;
            gvActivaPassiva.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActivaPassiva.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Get_Data()
        {
            double TmpCurrRate;
		    double TotActiva;
            double TotPassiva;

            Clear_Grid();

            string[] row;

            TotActiva = 0;
            Mdl1.Ssql = "Select A.*, B.Acct_Name, B.Curr_Code from TblAsset A left join TblAcctRef B on B.Acct_Code = A.Acct_Code order by B.Acct_Order";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TmpCurrRate = 1;
                    if (reader["Curr_Code"].ToString().Trim() != "IDR")
                    {
                        TmpCurrRate = Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), String.Format("{0:yyyy}", DateTime.Now) + String.Format("{0:MM}", DateTime.Now));
                    }
                    row = new string[] { reader["Acct_Code"].ToString().Trim(), reader["Acct_Name"].ToString().Trim(), reader["Curr_Code"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim()) * TmpCurrRate) };
                    gvActivaPassiva.Rows.Add(row);
                    TotActiva += (double.Parse(reader["Balance"].ToString().Trim()) * TmpCurrRate);
                }                
            }
            reader.Close();
            row = new string[] { "", "Total Activa", "", "", Mdl1.FormatAmt(TotActiva) };
            gvActivaPassiva.Rows.Add(row);

            row = new string[] { "", "", "", "", "" };
            gvActivaPassiva.Rows.Add(row);

            TotPassiva = 0;
            Mdl1.Ssql = "Select A.*, B.Acct_Name, B.Curr_Code from TblLiability A left join TblAcctRef B on B.Acct_Code = A.Acct_Code order by B.Acct_Order";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TmpCurrRate = 1;
                    if (reader["Curr_Code"].ToString().Trim() != "IDR")
                    {
                        TmpCurrRate = Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), String.Format("{0:yyyy}", DateTime.Now) + String.Format("{0:MM}", DateTime.Now));
                    }
                    row = new string[] { reader["Acct_Code"].ToString().Trim(), reader["Acct_Name"].ToString().Trim(), reader["Curr_Code"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim()) * TmpCurrRate) };
                    gvActivaPassiva.Rows.Add(row);
                    TotPassiva += (double.Parse(reader["Balance"].ToString().Trim()) * TmpCurrRate);
                }
            }
            reader.Close();
            row = new string[] { "", "Total Passiva", "", "", Mdl1.FormatAmt(TotPassiva) };
            gvActivaPassiva.Rows.Add(row);

            row = new string[] { "", "", "", "", "" };
            gvActivaPassiva.Rows.Add(row);

            row = new string[] { "", "Grand Total", "", "", Mdl1.FormatAmt(TotActiva - TotPassiva) };
            gvActivaPassiva.Rows.Add(row);
        }        

        private void CmbAcctType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbAcctCode, CmbAcctType.Text.Trim().Substring(0, 1));
        }

        private void CmbAcctCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Detail();
        }

        private void Get_Detail()
        {
            bool DataExist;
            lblCurr.Text = "IDR";
		    txtBalance.Text = "0.00";

            if (CmbAcctCode.Text.Trim() == "")
            {
                return;
            }

            if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
            {
			    Mdl1.Ssql = "select A.*, B.Curr_Code from TblAsset A left join TblAcctRef B on B.Acct_Code = A.Acct_Code where A.Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
            }
		    else
            {
                Mdl1.Ssql = "select A.*, B.Curr_Code from TblLiability A left join TblAcctRef B on B.Acct_Code = A.Acct_Code where A.Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
		    }
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                lblCurr.Text = reader["Curr_Code"].ToString().Trim();
                txtBalance.Text = reader["Balance"].ToString().Trim();
                DataExist = true;
            }
            else
            {
                DataExist = false;
            }
            reader.Close();

            if (!DataExist)
            {
                Mdl1.Ssql = "Select Curr_Code from TblAcctRef where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lblCurr.Text = reader["Curr_Code"].ToString().Trim();                    
                }
                reader.Close();
            }
        }

        private void CheckKeyPress(KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtBalance_Leave(object sender, EventArgs e)
        {
            txtBalance.Text = Mdl1.checkNumeric(txtBalance.Text).ToString();
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;

                if (CmbAcctCode.Text.Trim() == "")
                {
                    MessageBox.Show("You should select any Acct Code", "Error Message");
                    CmbAcctCode.Focus();
                    return;
                }

                if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
                {
                    Mdl1.Ssql = "select * from TblAsset where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
                }
                else
                {
                    Mdl1.Ssql = "select * from TblLiability where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";                    
                }                
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
                    if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
                    {
                        Mdl1.Ssql = "Insert into TblAsset values ('" + CmbAcctCode.Text.Trim().Substring(0, 5) + "', " + double.Parse(txtBalance.Text.Trim()) + ")";
                    }
                    else
                    {
                        Mdl1.Ssql = "Insert into TblLiability values ('" + CmbAcctCode.Text.Trim().Substring(0, 5) + "', " + double.Parse(txtBalance.Text.Trim()) + ")";
                    }                     
                }
                else
                {
                    if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
                    {
                        Mdl1.Ssql = "Update TblAsset set Balance = " + double.Parse(txtBalance.Text.Trim()) + " where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";                        
                    }
                    else
                    {
                        Mdl1.Ssql = "Update TblLiability set Balance = " + double.Parse(txtBalance.Text.Trim()) + " where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";                        
                    }                    
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create or Update successfully for Acct Code : " + CmbAcctCode.Text.Trim().Substring(0, 5), "Success");

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

                if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
                {
                    Mdl1.Ssql = "select * from TblAsset where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
                }
                else
                {
                    Mdl1.Ssql = "select * from TblLiability where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
                }
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
                    MessageBox.Show("Data not found for Acct Code : " + CmbAcctCode.Text.Trim().Substring(0, 5), "Error Message");
                    return;
                }
                else
                {
                    if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
                    {
                        Mdl1.Ssql = "Delete from TblAsset where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
                    }
                    else
                    {
                        Mdl1.Ssql = "Delete from TblLiability where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";                        
                    }
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Acct Code : " + CmbAcctCode.Text.Trim().Substring(0, 5), "Success");

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
