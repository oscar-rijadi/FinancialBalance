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
    public partial class Daily_Input : Form
    {
        bool FirstLoad;
        public Daily_Input()
        {
            InitializeComponent();
        }

        private void Daily_Input_Load(object sender, EventArgs e)
        {
            FirstLoad = true;
            Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

            Clear_Data();
		    Fill_Seq();
		    ChangeLblDay();
            FirstLoad = false;

            monthCalendar1.Hide();
        }

        private void MnMonthlyClosing_Click(object sender, EventArgs e)
        {
            Monthly_Closing Monthly_Closing = new Monthly_Closing();
            Monthly_Closing.Show();
            this.Close();
        }

        private void MnETFStocksTrans_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Transaction ETF_Stocks_Transaction = new ETF_Stocks_Transaction();
            ETF_Stocks_Transaction.Show();
            this.Close();
        }

        private void Clear_Data()
        {
            for (int i = 1; i <= 5; i++)
            {
                ComboBox CmbDebitAcctType = this.Controls.Find("CmbDebitAcctType" + i, true).FirstOrDefault() as ComboBox;
                Mdl1.Fill_Acct_Type_Trans(CmbDebitAcctType, "*");
                ComboBox CmbCreditAcctType = this.Controls.Find("CmbCreditAcctType" + i, true).FirstOrDefault() as ComboBox;
                Mdl1.Fill_Acct_Type_Trans(CmbCreditAcctType, "*");
                Label lblDebitCurr = this.Controls.Find("lblDebitCurr" + i, true).FirstOrDefault() as Label;
                lblDebitCurr.Text = "IDR";
                Label lblCreditCurr = this.Controls.Find("lblCreditCurr" + i, true).FirstOrDefault() as Label;
                lblCreditCurr.Text = "IDR";
                TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + i, true).FirstOrDefault() as TextBox;
                txtDebitBalanceCurr.Text = "0.00";
                TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + i, true).FirstOrDefault() as TextBox;
                txtCreditBalanceCurr.Text = "0.00";
                TextBox txtDebitRate = this.Controls.Find("txtDebitRate" + i, true).FirstOrDefault() as TextBox;
                txtDebitRate.Text = "1";
                TextBox txtCreditRate = this.Controls.Find("txtCreditRate" + i, true).FirstOrDefault() as TextBox;
                txtCreditRate.Text = "1";
                TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + i, true).FirstOrDefault() as TextBox;
                txtDebitBalance.Text = "0.00";
                TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + i, true).FirstOrDefault() as TextBox;
                txtCreditBalance.Text = "0.00";
            }
            lblTotDebitBalanceCurr.Text = "0.00";
		    lblTotCreditBalanceCurr.Text = "0.00";
		    lblTotDebitBalance.Text = "0.00";
            lblTotCreditBalance.Text = "0.00";
        }

        private void Fill_Seq()
        {            
            CmbSeq.Items.Clear();
            CmbSeq.Items.Add(" ");
            Mdl1.Ssql = "Select distinct(Trans_Seq) from TblDailyTrans where Trans_Date = '" + CmbYear.Text + CmbMM.Text + CmbDD.Text + "' order by Trans_Seq";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CmbSeq.Items.Add(reader["Trans_Seq"].ToString().Trim());
                }
                
            }
            reader.Close();
        }

        private void ChangeLblDay()
        {
            switch (DateTime.Parse(Mdl1.toLongDate(CmbYear.Text + CmbMM.Text + int.Parse(CmbDD.Text).ToString("00"))).DayOfWeek)
            {
                case DayOfWeek.Monday:
                    LblDay.Text = "Monday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Tuesday:
                    LblDay.Text = "Tuesday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Wednesday:
                    LblDay.Text = "Wednesday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Thursday:
                    LblDay.Text = "Thursday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Friday:
                    LblDay.Text = "Friday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Saturday:
                    LblDay.Text = "Saturday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Sunday:
                    LblDay.Text = "Sunday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(255);
                    break;
            }
        }

        private void CmbDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
                {
                    Fill_Seq();
                    ChangeLblDay();
                }
                else
                {
                    LblDay.Text = "";
                    MessageBox.Show("Invalid Date !", "Error Message");
                }
            }
        }

        private void CmbMM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
                {
                    Fill_Seq();
                    ChangeLblDay();
                }
                else
                {
                    LblDay.Text = "";
                    MessageBox.Show("Invalid Date !", "Error Message");
                }
            }
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
                {
                    Fill_Seq();
                    ChangeLblDay();
                }
                else
                {
                    LblDay.Text = "";
                    MessageBox.Show("Invalid Date !", "Error Message");
                }
            }
        }

        private void CmdCal_Click(object sender, EventArgs e)
        {
            FirstLoad = true;
            monthCalendar1.SetDate(new System.DateTime(int.Parse(CmbYear.Text), int.Parse(CmbMM.Text), int.Parse(CmbDD.Text), 0, 0, 0, 0));
            monthCalendar1.MaxDate = new System.DateTime(DateTime.Now.Year, 12, 31, 0, 0, 0, 0);
            monthCalendar1.Show();            
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            CmbDD.Text = e.Start.Day.ToString("00");
            CmbMM.Text = e.Start.Month.ToString("00");
            CmbYear.Text = e.Start.Year.ToString("0000");
            monthCalendar1.Hide();
        }

        private void CmbSeq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbSeq.Text.Trim() != "")
            {
                Get_Data();
            }
		    else
            {
			    Clear_Data();
            }
        }

        private void CmbDebitAcctType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbDebitAcctCode1, CmbDebitAcctType1.Text.Substring(0, 1));
        }
        private void CmbDebitAcctType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbDebitAcctCode2, CmbDebitAcctType2.Text.Substring(0, 1));
        }
        private void CmbDebitAcctType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbDebitAcctCode3, CmbDebitAcctType3.Text.Substring(0, 1));
        }
        private void CmbDebitAcctType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbDebitAcctCode4, CmbDebitAcctType4.Text.Substring(0, 1));
        }
        private void CmbDebitAcctType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbDebitAcctCode5, CmbDebitAcctType5.Text.Substring(0, 1));
        }

        private void CmbCreditAcctType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbCreditAcctCode1, CmbCreditAcctType1.Text.Substring(0, 1));
        }
        private void CmbCreditAcctType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbCreditAcctCode2, CmbCreditAcctType2.Text.Substring(0, 1));
        }
        private void CmbCreditAcctType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbCreditAcctCode3, CmbCreditAcctType3.Text.Substring(0, 1));
        }
        private void CmbCreditAcctType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbCreditAcctCode4, CmbCreditAcctType4.Text.Substring(0, 1));
        }
        private void CmbCreditAcctType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Code_Trans(CmbCreditAcctCode5, CmbCreditAcctType5.Text.Substring(0, 1));
        }

        private void ChangeDebitAcctCode(int parSeq)
        {
            Label lblDebitCurr = this.Controls.Find("lblDebitCurr" + parSeq, true).FirstOrDefault() as Label;
            lblDebitCurr.Text = "IDR";
            ComboBox CmbDebitAcctCode = this.Controls.Find("CmbDebitAcctCode" + parSeq, true).FirstOrDefault() as ComboBox;
            if (CmbDebitAcctCode.Text.Trim() != "")
            {
                Mdl1.Ssql = "Select * from TblAcctRef where Acct_Code = '" + CmbDebitAcctCode.Text.Substring(0, 5) + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lblDebitCurr.Text = reader["Curr_Code"].ToString().Trim();
                }
                reader.Close();
            }
            TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + parSeq, true).FirstOrDefault() as TextBox;
            txtDebitBalanceCurr.Text = "0.00";
            TextBox txtDebitRate = this.Controls.Find("txtDebitRate" + parSeq, true).FirstOrDefault() as TextBox;
            txtDebitRate.Text = "1";
            TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + parSeq, true).FirstOrDefault() as TextBox;
            txtDebitBalance.Text = "0.00";
            Calculate_Data();
        }
        private void CmbDebitAcctCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDebitAcctCode(1);
        }
        private void CmbDebitAcctCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDebitAcctCode(2);
        }
        private void CmbDebitAcctCode3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDebitAcctCode(3);
        }
        private void CmbDebitAcctCode4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDebitAcctCode(4);
        }
        private void CmbDebitAcctCode5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDebitAcctCode(5);
        }

        private void ChangeCreditAcctCode(int parSeq)
        {
            Label lblCreditCurr = this.Controls.Find("lblCreditCurr" + parSeq, true).FirstOrDefault() as Label;
            lblCreditCurr.Text = "IDR";
            ComboBox CmbCreditAcctCode = this.Controls.Find("CmbCreditAcctCode" + parSeq, true).FirstOrDefault() as ComboBox;
            if (CmbCreditAcctCode.Text.Trim() != "")
            {
                Mdl1.Ssql = "Select * from TblAcctRef where Acct_Code = '" + CmbCreditAcctCode.Text.Substring(0, 5) + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lblCreditCurr.Text = reader["Curr_Code"].ToString().Trim();
                }
                reader.Close();
            }
            TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + parSeq, true).FirstOrDefault() as TextBox;
            txtCreditBalanceCurr.Text = "0.00";
            TextBox txtCreditRate = this.Controls.Find("txtCreditRate" + parSeq, true).FirstOrDefault() as TextBox;
            txtCreditRate.Text = "1";
            TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + parSeq, true).FirstOrDefault() as TextBox;
            txtCreditBalance.Text = "0.00";
            Calculate_Data();
        }
        private void CmbCreditAcctCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCreditAcctCode(1);
        }
        private void CmbCreditAcctCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCreditAcctCode(2);
        }
        private void CmbCreditAcctCode3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCreditAcctCode(3);
        }
        private void CmbCreditAcctCode4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCreditAcctCode(4);
        }
        private void CmbCreditAcctCode5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCreditAcctCode(5);
        }

        private void Calculate_Data()
        {
            double TotDebitBalanceCurr = 0;
		    double TotDebitBalance = 0;
		    double TotCreditBalanceCurr = 0;
		    double TotCreditBalance = 0;
		    for (int i = 1; i <= 5; i++)
            {
                ComboBox CmbDebitAcctCode = this.Controls.Find("CmbDebitAcctCode" + i, true).FirstOrDefault() as ComboBox;
                Label lblDebitCurr = this.Controls.Find("lblDebitCurr" + i, true).FirstOrDefault() as Label;
                TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + i, true).FirstOrDefault() as TextBox;                
                TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + i, true).FirstOrDefault() as TextBox;
                if (CmbDebitAcctCode.Text.Trim() != "")
                {
                    TotDebitBalanceCurr += double.Parse(txtDebitBalanceCurr.Text);
                    TotDebitBalance += double.Parse(txtDebitBalance.Text);
                }

                ComboBox CmbCreditAcctCode = this.Controls.Find("CmbCreditAcctCode" + i, true).FirstOrDefault() as ComboBox;                
                Label lblCreditCurr = this.Controls.Find("lblCreditCurr" + i, true).FirstOrDefault() as Label;
                TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + i, true).FirstOrDefault() as TextBox;                
                TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + i, true).FirstOrDefault() as TextBox;
                if (CmbCreditAcctCode.Text.Trim() != "")
                {
                    TotCreditBalanceCurr += double.Parse(txtCreditBalanceCurr.Text);
                    TotCreditBalance += double.Parse(txtCreditBalance.Text);
                }
            }
		    lblTotDebitBalanceCurr.Text = Mdl1.FormatAmt(TotDebitBalanceCurr);
		    lblTotCreditBalanceCurr.Text = Mdl1.FormatAmt(TotCreditBalanceCurr);
            lblTotDebitBalance.Text = Mdl1.FormatAmt(TotDebitBalance);
            lblTotCreditBalance.Text = Mdl1.FormatAmt(TotCreditBalance);
        }

        private void Get_Data()
        {
            try
            {
                int i;
		        string TmpAcctType;
		        string TmpAcctTypeName;

		        Clear_Data();
		
		        i = 0;
		        Mdl1.Ssql = "Select A.*, B.Acct_Name from TblDailyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code" + " where A.Trans_Date = '" + CmbYear.Text + CmbMM.Text + CmbDD.Text + "' and A.Trans_Seq = '" + CmbSeq.Text.Trim() + "' and A.Trans_Type = 'D' order by A.Acct_Code";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        i += 1;
                        TmpAcctType = Mdl1.GetAcctType(reader["Acct_Code"].ToString().Trim());
				        TmpAcctTypeName = Mdl1.GetAcctTypeName(TmpAcctType.Trim());
                        ComboBox CmbDebitAcctType = this.Controls.Find("CmbDebitAcctType" + i, true).FirstOrDefault() as ComboBox;
                        ComboBox CmbDebitAcctCode = this.Controls.Find("CmbDebitAcctCode" + i, true).FirstOrDefault() as ComboBox;
                        TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtDebitRate = this.Controls.Find("txtDebitRate" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + i, true).FirstOrDefault() as TextBox;
                        CmbDebitAcctType.Text = TmpAcctType + " - " + TmpAcctTypeName;
                        CmbDebitAcctCode.Text = reader["Acct_Code"].ToString().Trim() + " - " + reader["Acct_Name"].ToString().Trim();
                        txtDebitBalanceCurr.Text = reader["Balance_Curr"].ToString().Trim();                        
                        txtDebitRate.Text = double.Parse(reader["Rate"].ToString().Trim()).ToString("#.##");
                        txtDebitBalance.Text = reader["Balance"].ToString().Trim();
                    }
                }
                reader.Close();

                i = 0;
		        Mdl1.Ssql = "Select A.*, B.Acct_Name from TblDailyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code" + " where A.Trans_Date = '" + CmbYear.Text + CmbMM.Text + CmbDD.Text + "' and A.Trans_Seq = '" + CmbSeq.Text.Trim() + "' and A.Trans_Type = 'C' order by A.Acct_Code";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        i += 1;
                        TmpAcctType = Mdl1.GetAcctType(reader["Acct_Code"].ToString().Trim());
				        TmpAcctTypeName = Mdl1.GetAcctTypeName(TmpAcctType.Trim());
                        ComboBox CmbCreditAcctType = this.Controls.Find("CmbCreditAcctType" + i, true).FirstOrDefault() as ComboBox;
                        ComboBox CmbCreditAcctCode = this.Controls.Find("CmbCreditAcctCode" + i, true).FirstOrDefault() as ComboBox;
                        TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtCreditRate = this.Controls.Find("txtCreditRate" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + i, true).FirstOrDefault() as TextBox;
                        CmbCreditAcctType.Text = TmpAcctType + " - " + TmpAcctTypeName;
                        CmbCreditAcctCode.Text = reader["Acct_Code"].ToString().Trim() + " - " + reader["Acct_Name"].ToString().Trim();
                        txtCreditBalanceCurr.Text = reader["Balance_Curr"].ToString().Trim();                        
                        txtCreditRate.Text = double.Parse(reader["Rate"].ToString().Trim()).ToString("#.##");
                        txtCreditBalance.Text = reader["Balance"].ToString().Trim();
                    }
                }
                reader.Close();
		
		        Calculate_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
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
        private void DebitBalanceCurrLeave(int parSeq)
        {
            TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtDebitRate = this.Controls.Find("txtDebitRate" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + parSeq, true).FirstOrDefault() as TextBox;

            txtDebitBalanceCurr.Text = Mdl1.checkNumeric(txtDebitBalanceCurr.Text).ToString();
            txtDebitBalance.Text = (double.Parse(txtDebitBalanceCurr.Text) * double.Parse(txtDebitRate.Text)).ToString();

            Calculate_Data();
        }
        private void CreditBalanceCurrLeave(int parSeq)
        {
            TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtCreditRate = this.Controls.Find("txtCreditRate" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + parSeq, true).FirstOrDefault() as TextBox;

            txtCreditBalanceCurr.Text = Mdl1.checkNumeric(txtCreditBalanceCurr.Text).ToString();
            txtCreditBalance.Text = (double.Parse(txtCreditBalanceCurr.Text) * double.Parse(txtCreditRate.Text)).ToString();

            Calculate_Data();
        }
        private void DebitRateLeave(int parSeq)
        {
            TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtDebitRate = this.Controls.Find("txtDebitRate" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + parSeq, true).FirstOrDefault() as TextBox;

            txtDebitRate.Text = Mdl1.checkNumeric(txtDebitRate.Text).ToString();
            txtDebitBalance.Text = (double.Parse(txtDebitBalanceCurr.Text) * double.Parse(txtDebitRate.Text)).ToString();

            Calculate_Data();
        }
        private void CreditRateLeave(int parSeq)
        {
            TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtCreditRate = this.Controls.Find("txtCreditRate" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + parSeq, true).FirstOrDefault() as TextBox;

            txtCreditRate.Text = Mdl1.checkNumeric(txtCreditRate.Text).ToString();
            txtCreditBalance.Text = (double.Parse(txtCreditBalanceCurr.Text) * double.Parse(txtCreditRate.Text)).ToString();

            Calculate_Data();
        }
        private void DebitBalanceLeave(int parSeq)
        {
            TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtDebitRate = this.Controls.Find("txtDebitRate" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + parSeq, true).FirstOrDefault() as TextBox;

            if (txtDebitRate.Text.Trim() == "1")
            {
                txtDebitBalanceCurr.Text = txtDebitBalance.Text;
            }

            Calculate_Data();
        }
        private void CreditBalanceLeave(int parSeq)
        {
            TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtCreditRate = this.Controls.Find("txtCreditRate" + parSeq, true).FirstOrDefault() as TextBox;
            TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + parSeq, true).FirstOrDefault() as TextBox;

            if (txtCreditRate.Text.Trim() == "1")
            {
                txtCreditBalanceCurr.Text = txtCreditBalance.Text;
            }

            Calculate_Data();
        }

        private void txtDebitBalanceCurr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalanceCurr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalanceCurr3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalanceCurr4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalanceCurr5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalanceCurr1_Leave(object sender, EventArgs e)
        {
            DebitBalanceCurrLeave(1);
        }
        private void txtDebitBalanceCurr2_Leave(object sender, EventArgs e)
        {
            DebitBalanceCurrLeave(2);
        }
        private void txtDebitBalanceCurr3_Leave(object sender, EventArgs e)
        {
            DebitBalanceCurrLeave(3);
        }
        private void txtDebitBalanceCurr4_Leave(object sender, EventArgs e)
        {
            DebitBalanceCurrLeave(4);
        }
        private void txtDebitBalanceCurr5_Leave(object sender, EventArgs e)
        {
            DebitBalanceCurrLeave(5);
        }

        private void txtCreditBalanceCurr1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalanceCurr2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalanceCurr3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalanceCurr4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalanceCurr5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalanceCurr1_Leave(object sender, EventArgs e)
        {
            CreditBalanceCurrLeave(1);
        }
        private void txtCreditBalanceCurr2_Leave(object sender, EventArgs e)
        {
            CreditBalanceCurrLeave(2);
        }
        private void txtCreditBalanceCurr3_Leave(object sender, EventArgs e)
        {
            CreditBalanceCurrLeave(3);
        }
        private void txtCreditBalanceCurr4_Leave(object sender, EventArgs e)
        {
            CreditBalanceCurrLeave(4);
        }
        private void txtCreditBalanceCurr5_Leave(object sender, EventArgs e)
        {
            CreditBalanceCurrLeave(5);
        }

        private void txtDebitRate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitRate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitRate3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitRate4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitRate5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitRate1_Leave(object sender, EventArgs e)
        {
            DebitRateLeave(1);
        }
        private void txtDebitRate2_Leave(object sender, EventArgs e)
        {
            DebitRateLeave(2);
        }
        private void txtDebitRate3_Leave(object sender, EventArgs e)
        {
            DebitRateLeave(3);
        }
        private void txtDebitRate4_Leave(object sender, EventArgs e)
        {
            DebitRateLeave(4);
        }
        private void txtDebitRate5_Leave(object sender, EventArgs e)
        {
            DebitRateLeave(5);
        }

        private void txtCreditRate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditRate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditRate3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditRate4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditRate5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditRate1_Leave(object sender, EventArgs e)
        {
            CreditRateLeave(1);
        }
        private void txtCreditRate2_Leave(object sender, EventArgs e)
        {
            CreditRateLeave(2);
        }
        private void txtCreditRate3_Leave(object sender, EventArgs e)
        {
            CreditRateLeave(3);
        }
        private void txtCreditRate4_Leave(object sender, EventArgs e)
        {
            CreditRateLeave(4);
        }
        private void txtCreditRate5_Leave(object sender, EventArgs e)
        {
            CreditRateLeave(5);
        }

        private void txtDebitBalance1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalance2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalance3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalance4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalance5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtDebitBalance1_Leave(object sender, EventArgs e)
        {
            DebitBalanceLeave(1);
        }
        private void txtDebitBalance2_Leave(object sender, EventArgs e)
        {
            DebitBalanceLeave(2);
        }
        private void txtDebitBalance3_Leave(object sender, EventArgs e)
        {
            DebitBalanceLeave(3);
        }
        private void txtDebitBalance4_Leave(object sender, EventArgs e)
        {
            DebitBalanceLeave(4);
        }
        private void txtDebitBalance5_Leave(object sender, EventArgs e)
        {
            DebitBalanceLeave(5);
        }

        private void txtCreditBalance1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalance2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalance3_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalance4_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalance5_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }
        private void txtCreditBalance1_Leave(object sender, EventArgs e)
        {
            CreditBalanceLeave(1);
        }
        private void txtCreditBalance2_Leave(object sender, EventArgs e)
        {
            CreditBalanceLeave(2);
        }
        private void txtCreditBalance3_Leave(object sender, EventArgs e)
        {
            CreditBalanceLeave(3);
        }
        private void txtCreditBalance4_Leave(object sender, EventArgs e)
        {
            CreditBalanceLeave(4);
        }
        private void txtCreditBalance5_Leave(object sender, EventArgs e)
        {
            CreditBalanceLeave(5);
        }

        private bool Validate_Input()
        {
            if (double.Parse(lblTotDebitBalance.Text) != double.Parse(lblTotCreditBalance.Text))
            {
                MessageBox.Show("Debit Balance not equal with Credit Balance !", "Error Message");
                return false;
            }
            return true;
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {                
		        int TmpSeq;
		        string TmpNewSeq;
		        if (Validate_Input())
                {
			        Mdl1.Ssql = "Select top 1 Trans_Seq from TblDailyTrans where Trans_Date = '" + CmbYear.Text + CmbMM.Text + CmbDD.Text + "' order by Trans_Seq Desc";
                    OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        TmpSeq = int.Parse(reader["Trans_Seq"].ToString().Trim()) + 1;                        
                    }
                    else
                    {
                        TmpSeq = 1;
                    }
                    reader.Close();
			        
                    TmpNewSeq = TmpSeq.ToString("000");
			
                    for (int i = 1; i <= 5; i++)
                    {
                        ComboBox CmbDebitAcctType = this.Controls.Find("CmbDebitAcctType" + i, true).FirstOrDefault() as ComboBox;
                        ComboBox CmbDebitAcctCode = this.Controls.Find("CmbDebitAcctCode" + i, true).FirstOrDefault() as ComboBox;
                        Label lblDebitCurr = this.Controls.Find("lblDebitCurr" + i, true).FirstOrDefault() as Label;
                        TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtDebitRate = this.Controls.Find("txtDebitRate" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + i, true).FirstOrDefault() as TextBox;
                        if (CmbDebitAcctCode.Text.Trim() != "")
                        {
                            if (Mdl1.CreUpdActivaPassivaMonthlyTrans(CmbYear.Text + CmbMM.Text + CmbDD.Text, TmpNewSeq, "D", CmbDebitAcctType.Text.Substring(0,1), CmbDebitAcctCode.Text.Substring(0,5), double.Parse(txtDebitBalanceCurr.Text), double.Parse(txtDebitRate.Text), double.Parse(txtDebitBalance.Text)))
                            {
                            }
                            else
                            {
                                return;
                            }
                        }

                        ComboBox CmbCreditAcctType = this.Controls.Find("CmbCreditAcctType" + i, true).FirstOrDefault() as ComboBox;
                        ComboBox CmbCreditAcctCode = this.Controls.Find("CmbCreditAcctCode" + i, true).FirstOrDefault() as ComboBox;
                        Label lblCreditCurr = this.Controls.Find("lblCreditCurr" + i, true).FirstOrDefault() as Label;
                        TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtCreditRate = this.Controls.Find("txtCreditRate" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + i, true).FirstOrDefault() as TextBox;
                        if (CmbCreditAcctCode.Text.Trim() != "")
                        {
                            if (Mdl1.CreUpdActivaPassivaMonthlyTrans(CmbYear.Text + CmbMM.Text + CmbDD.Text, TmpNewSeq, "C", CmbCreditAcctType.Text.Substring(0,1), CmbCreditAcctCode.Text.Substring(0,5), double.Parse(txtCreditBalanceCurr.Text), double.Parse(txtCreditRate.Text), double.Parse(txtCreditBalance.Text)))
                            {
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    MessageBox.Show("Create successfully for Date " + CmbDD.Text + "/" + CmbMM.Text + "/" + CmbYear.Text + " and Sequence " + TmpNewSeq + " !", "Success");
			        Fill_Seq();
		        }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }        

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            string TmpNewSeq;
            if (Validate_Input() && CmbSeq.Text.Trim() != "")
            {
			    if (Mdl1.DelActivaPassivaMonthlyTrans(CmbYear.Text + CmbMM.Text + CmbDD.Text, CmbSeq.Text.Trim()))
                {
				    TmpNewSeq = CmbSeq.Text.Trim();
                    for (int i = 1; i <= 5; i++)
                    {
                        ComboBox CmbDebitAcctType = this.Controls.Find("CmbDebitAcctType" + i, true).FirstOrDefault() as ComboBox;
                        ComboBox CmbDebitAcctCode = this.Controls.Find("CmbDebitAcctCode" + i, true).FirstOrDefault() as ComboBox;
                        Label lblDebitCurr = this.Controls.Find("lblDebitCurr" + i, true).FirstOrDefault() as Label;
                        TextBox txtDebitBalanceCurr = this.Controls.Find("txtDebitBalanceCurr" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtDebitRate = this.Controls.Find("txtDebitRate" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtDebitBalance = this.Controls.Find("txtDebitBalance" + i, true).FirstOrDefault() as TextBox;
                        if (CmbDebitAcctCode.Text.Trim() != "")
                        {
                            if (Mdl1.CreUpdActivaPassivaMonthlyTrans(CmbYear.Text + CmbMM.Text + CmbDD.Text, TmpNewSeq, "D", CmbDebitAcctType.Text.Substring(0,1), CmbDebitAcctCode.Text.Substring(0,5), double.Parse(txtDebitBalanceCurr.Text), double.Parse(txtDebitRate.Text), double.Parse(txtDebitBalance.Text)))
                            {
                            }
                            else
                            {
                                return;
                            }
                        }

                        ComboBox CmbCreditAcctType = this.Controls.Find("CmbCreditAcctType" + i, true).FirstOrDefault() as ComboBox;
                        ComboBox CmbCreditAcctCode = this.Controls.Find("CmbCreditAcctCode" + i, true).FirstOrDefault() as ComboBox;
                        Label lblCreditCurr = this.Controls.Find("lblCreditCurr" + i, true).FirstOrDefault() as Label;
                        TextBox txtCreditBalanceCurr = this.Controls.Find("txtCreditBalanceCurr" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtCreditRate = this.Controls.Find("txtCreditRate" + i, true).FirstOrDefault() as TextBox;
                        TextBox txtCreditBalance = this.Controls.Find("txtCreditBalance" + i, true).FirstOrDefault() as TextBox;
                        if (CmbCreditAcctCode.Text.Trim() != "")
                        {
                            if (Mdl1.CreUpdActivaPassivaMonthlyTrans(CmbYear.Text + CmbMM.Text + CmbDD.Text, TmpNewSeq, "C", CmbCreditAcctType.Text.Substring(0,1), CmbCreditAcctCode.Text.Substring(0,5), double.Parse(txtCreditBalanceCurr.Text), double.Parse(txtCreditRate.Text), double.Parse(txtCreditBalance.Text)))
                            {
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
				
                    MessageBox.Show("Update successfully for Date " + CmbDD.Text + "/" + CmbMM.Text + "/" + CmbYear.Text + " and Sequence " + TmpNewSeq + " !", "Success");
			        Fill_Seq();
                }
		    }
        }

        private void CmdDel_Click(object sender, EventArgs e)
        {
            string TmpNewSeq;
            if (CmbSeq.Text.Trim() != "")
            {
                if (Mdl1.DelActivaPassivaMonthlyTrans(CmbYear.Text + CmbMM.Text + CmbDD.Text, CmbSeq.Text.Trim()))
                {
                    TmpNewSeq = CmbSeq.Text.Trim();
                    MessageBox.Show("Delete successfully for Date " + CmbDD.Text + "/" + CmbMM.Text + "/" + CmbYear.Text + " and Sequence " + TmpNewSeq + " !", "Success");
                    Fill_Seq();
                }
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
