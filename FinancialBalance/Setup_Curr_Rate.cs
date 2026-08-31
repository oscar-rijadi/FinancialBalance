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
    public partial class Setup_Curr_Rate : Form
    {
        bool FirstLoad;
        public Setup_Curr_Rate()
        {
            InitializeComponent();
        }

        private void Setup_Curr_Rate_Load(object sender, EventArgs e)
        {
            Mdl1.Fill_Curr(CmbCurr);
		    FirstLoad = true;
		    Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

		    ChangeLblDay();
		    Get_Curr_Name();
		    Get_Data();
		    txtRate.Text = "0";
		    Get_Rate();
            FirstLoad = false;

            monthCalendar1.Hide();
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

        private void Get_Curr_Name()
        {
            lblCurrName.Text = "";
            Mdl1.Ssql = "Select * from TblCurrCode where Curr_Code = '" + CmbCurr.Text + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                lblCurrName.Text = reader["Curr_Name"].ToString().Trim();
            }
            reader.Close();
        }

        private void Clear_Grid()
        {
            gvCurrRate.Columns.Clear();
            gvCurrRate.ColumnCount = 2;
            gvCurrRate.Columns[0].Name = "Curr Date";
            gvCurrRate.Columns[0].FillWeight = 35;
            gvCurrRate.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCurrRate.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCurrRate.Columns[1].Name = "Curr Rate";
            gvCurrRate.Columns[1].FillWeight = 65;
            gvCurrRate.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvCurrRate.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Get_Data()
        {
            Clear_Grid();

            string[] row;

            Mdl1.Ssql = "select Curr_Date, Curr_Rate from TblCurrRate where Curr_Code = '" + CmbCurr.Text + "' order by Curr_Date desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = new string[] { Mdl1.toLongDate(reader["Curr_Date"].ToString().Trim()), Mdl1.FormatAmt(double.Parse(reader["Curr_Rate"].ToString().Trim())) };
                    gvCurrRate.Rows.Add(row);
                }
            }
            reader.Close();
        }

        private void Get_Rate()
        {
            txtRate.Text = "0";
            Mdl1.Ssql = "Select * from TblCurrRate where Curr_Code = '" + CmbCurr.Text + "' and Curr_Date = '" + CmbYear.Text + CmbMM.Text + CmbDD.Text + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                txtRate.Text = reader["Curr_Rate"].ToString().Trim();
            }
            reader.Close();
        }

        private void CmbCurr_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Curr_Name();
		    Get_Data();
		    Get_Rate();
        }        

        private void CmbDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
                {
                    Get_Rate();
                    ChangeLblDay();
                }
                else
                {
                    LblDay.Text = "";
                    MessageBox.Show("Invalid Date !", "Error Message");
                    CmbDD.Focus();
                }
            }
        }

        private void CmbMM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
                {
                    Get_Rate();
                    ChangeLblDay();
                }
                else
                {
                    LblDay.Text = "";
                    MessageBox.Show("Invalid Date !", "Error Message");
                    CmbMM.Focus();
                }
            }
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!FirstLoad)
            {
                if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
                {
                    Get_Rate();
                    ChangeLblDay();
                }
                else
                {
                    LblDay.Text = "";
                    MessageBox.Show("Invalid Date !", "Error Message");
                    CmbYear.Focus();
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
            Get_Rate();
            ChangeLblDay();
            monthCalendar1.Hide();
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

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            txtRate.Text = Mdl1.checkNumeric(txtRate.Text).ToString();            
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;

                Mdl1.Ssql = "Select top 1 Curr_Date from TblCurrRate where Curr_Date = '" + CmbYear.Text + CmbMM.Text + CmbDD.Text + "' and Curr_Code = '" + CmbCurr.Text + "'";
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
                    Mdl1.Ssql = "Insert into TblCurrRate values ('" + CmbYear.Text + CmbMM.Text + CmbDD.Text + "', '" + CmbCurr.Text + "', " + txtRate.Text.Trim() + ")";
                }
                else
                {
                    Mdl1.Ssql = "Update TblCurrRate set Curr_Rate = '" + txtRate.Text.Trim() + "' where Curr_Date = '" + CmbYear.Text + CmbMM.Text + CmbDD.Text + "' and Curr_Code = '" + CmbCurr.Text + "'";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create or Update successfully for Currency Code : " + CmbCurr.Text + " and Date : " + Mdl1.toLongDate(CmbYear.Text + CmbMM.Text + CmbDD.Text), "Success");

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
