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
    public partial class Monthly_Closing : Form
    {
        string TmpLastClosingMonth;
        string TmpNextMonth;

        public Monthly_Closing()
        {
            InitializeComponent();
        }

        private void Monthly_Closing_Load(object sender, EventArgs e)
        {
            Mdl1.Fill_Month(CmbMM, CmbYear);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);
            GetLastClosing();
		    if (TmpLastClosingMonth != "190001")
            {
			    TmpNextMonth = Mdl1.GetNextMonth(TmpLastClosingMonth);
			    CmbMM.Text = TmpNextMonth.Trim().Substring(4,2);
			    CmbYear.Text = TmpNextMonth.Trim().Substring(0,4);
		    }
        }

        private void MnDaily_Click(object sender, EventArgs e)
        {
            Daily_Input Daily_Input = new Daily_Input();
            Daily_Input.Show();
            this.Close();
        }

        private void MnETFStocksTrans_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Transaction ETF_Stocks_Transaction = new ETF_Stocks_Transaction();
            ETF_Stocks_Transaction.Show();
            this.Close();
        }

        private void GetLastClosing()
        {
            try
            {
                TmpLastClosingMonth = "190001";
                Mdl1.Ssql = "select top 1 Trans_Month from TblMonthlyTrans where left(Acct_Code,1) = 'A' order by Trans_Month Desc";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    TmpLastClosingMonth = reader["Trans_Month"].ToString().Trim();
                }
                reader.Close();
                lblLastClosingMonth.Text = Mdl1.toLongMonth(TmpLastClosingMonth);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdClosing_Click(object sender, EventArgs e)
        {
            try
            {
                Mdl1.Ssql = "Delete from TblMonthlyTrans where Trans_Month = '" + CmbYear.Text + CmbMM.Text + "' and (left(Acct_Code,1) = 'A' or left(Acct_Code,1) = 'L')";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                Mdl1.Ssql = "Select * from TblAsset";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Mdl1.Ssql = "Insert into TblMonthlyTrans values('" + CmbYear.Text + CmbMM.Text + "', '" + reader["Acct_Code"].ToString().Trim() + "', " + reader["Balance"] + ")";
                        OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        cmd2.ExecuteNonQuery();
                    }
                }
                reader.Close();

                Mdl1.Ssql = "Select * from TblLiability";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Mdl1.Ssql = "Insert into TblMonthlyTrans values('" + CmbYear.Text + CmbMM.Text + "', '" + reader["Acct_Code"].ToString().Trim() + "', " + reader["Balance"] + ")";
                        OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        cmd2.ExecuteNonQuery();
                    }
                }
                reader.Close();

                MessageBox.Show("Closing Month " + Mdl1.toLongMonth(CmbYear.Text + CmbMM.Text) + " has been successfull !", "Success");
                GetLastClosing();
                TmpNextMonth = Mdl1.GetNextMonth(TmpLastClosingMonth);
                CmbMM.Text = TmpNextMonth.Trim().Substring(4, 2);
                CmbYear.Text = TmpNextMonth.Trim().Substring(0, 4);
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
