using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace FinancialBalance
{
    public partial class Main_Form : Form
    {
        int maxBox = 16;
        int boxIdx, jump;
	    bool movingRight;
	    public bool stopNow;
        public bool Chk_Log;

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            LblDate.Text = String.Format("{0:dd MMMM yyyy hh:mm:ss}", DateTime.Now);

            Assembly _AsmObj = Assembly.GetExecutingAssembly();
            AssemblyName _CurrAsmName = _AsmObj.GetName();            
            LblVer.Text = "V " + _CurrAsmName.Version.Major.ToString() + "." + _CurrAsmName.Version.Minor.ToString() + "." + _CurrAsmName.Version.Build.ToString() + "." + _CurrAsmName.Version.Revision.ToString();
            
		    Run_Disp();

            Mdl1.StrYear = "";

            string errMsg = Mdl1.DB_Connect();
            if (errMsg.Trim() != "")
            {
                MessageBox.Show(errMsg, "Error Message");
            }

            Mdl1.SetupTable = false;
            Mdl1.Ssql = "select top 1 * from TblAcctRef";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            Mdl1.reader = cmd.ExecuteReader();
            if (Mdl1.reader.HasRows)
            {
                Mdl1.SetupTable = true;
            }
            else
            {
                Mdl1.SetupTable = false;
            }
            Mdl1.reader.Close();

            MnAcctTypeRefSetup.Enabled = true;
		    MnAcctRefSetup.Enabled = true;
		    MnCurrSetup.Enabled = true;
		    MnCurrRateSetup.Enabled = true;
		    MnActivaPassivaSetup.Enabled = true;
		    MnExit.Enabled = true;
		
		    if (Mdl1.SetupTable)
            {
			    MnDailyInput.Enabled = true;
			    MnMonthlyClosing.Enabled = true;
			    //MnYearStat.Enabled = true;
			    //MnYearSumm.Enabled = true;
            }
		    else
            {
			    MnDailyInput.Enabled = false;
                MnMonthlyClosing.Enabled = false;
			    //MnYearStat.Enabled = false;
			    //MnYearSumm.Enabled = false;
		    }
        }

        private void Main_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            int KeyAscii = (int)e.KeyChar;
            if (KeyAscii == 27)
            {
                MnExit_Click(MnExit, new System.EventArgs());
            }
        }

        private void Run_Disp()
        {
            maxBox = 16;
            for (int i = 0; i < maxBox; i++)
            {
                Label box = this.Controls.Find("box" + i, true).FirstOrDefault() as Label;
                box.BackColor = System.Drawing.Color.Transparent;
                box.BorderStyle = System.Windows.Forms.BorderStyle.None;
                if (i >= 4 && i <= 10)
                {
                    Label box2 = this.Controls.Find("box" + "2" + i, true).FirstOrDefault() as Label;
                    box2.BackColor = System.Drawing.Color.Transparent;
                    box2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
            stopNow = false;
            boxIdx = -1;
            jump = 1;
            movingRight = true;
            AnimationTimer.Interval = 150;
            AnimationTimer.Enabled = true;
        }

        private void MnDailyInput_Click(object sender, EventArgs e)
        {
            Daily_Input Daily_Input = new Daily_Input();
            Daily_Input.Show();
            this.Hide();
        }

        private void MnMonthlyClosing_Click(object sender, EventArgs e)
        {
            Monthly_Closing Monthly_Closing = new Monthly_Closing();
            Monthly_Closing.Show();
            this.Hide();
        }

        private void MnMonthlyInq_Click(object sender, EventArgs e)
        {
            Monthly_Inquiry Monthly_Inquiry = new Monthly_Inquiry();
            Monthly_Inquiry.Show();
            this.Hide();
        }   

        private void MnYearStat_Click(object sender, EventArgs e)
        {
            Yearly_Statistic Yearly_Statistic = new Yearly_Statistic();
            Yearly_Statistic.Show();
            this.Hide();
        }

        private void MnYearSumm_Click(object sender, EventArgs e)
        {
            Yearly_Summary Yearly_Summary = new Yearly_Summary();
            Yearly_Summary.Show();
            this.Hide();
        }

        private void MnAcctTypeRefSetup_Click(object sender, EventArgs e)
        {
            Setup_Acct_Type_Ref Setup_Acct_Type_Ref = new Setup_Acct_Type_Ref();
            Setup_Acct_Type_Ref.Show();
            this.Hide();
        }

        private void MnAcctRefSetup_Click(object sender, EventArgs e)
        {
            Setup_Acct_Ref Setup_Acct_Ref = new Setup_Acct_Ref();
            Setup_Acct_Ref.Show();
            this.Hide();
        }

        private void MnCurrSetup_Click(object sender, EventArgs e)
        {
            Setup_Curr Setup_Curr = new Setup_Curr();
            Setup_Curr.Show();
            this.Hide();
        }

        private void MnCurrRateSetup_Click(object sender, EventArgs e)
        {
            Setup_Curr_Rate Setup_Curr_Rate = new Setup_Curr_Rate();
            Setup_Curr_Rate.Show();
            this.Hide();
        }

        private void MnActivaPassivaSetup_Click(object sender, EventArgs e)
        {
            Setup_Activa_Passiva Setup_Activa_Passiva = new Setup_Activa_Passiva();
            Setup_Activa_Passiva.Show();
            this.Hide();
        }

        private void MnETFStocksSuffixSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Suffix Setup_ETF_Stocks_Suffix = new Setup_ETF_Stocks_Suffix();
            Setup_ETF_Stocks_Suffix.Show();
            this.Hide();
        }

        private void MnExit_Click(object sender, EventArgs e)
        {
            DialogResult Response = MessageBox.Show("Are You Sure Want to Exit ?", "Confirmation", MessageBoxButtons.OKCancel);
            if (Response == DialogResult.OK)
            {
			    Mdl1.DB_Disconnect();
                Application.Exit();
			}
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            LblDate.Text = String.Format("{0:dd MMMM yyyy hh:mm:ss}", DateTime.Now);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (stopNow)
            {
                AnimationTimer.Enabled = false;
            }

            System.Windows.Forms.Application.DoEvents();

            for (int i = 0; i < maxBox; i++)
            {
                Label box = this.Controls.Find("box" + i, true).FirstOrDefault() as Label;
                box.BackColor = System.Drawing.Color.Transparent;
                box.BorderStyle = System.Windows.Forms.BorderStyle.None;
                box.Enabled = false;
                if (i >= 4 && i <= 10)
                {
                    Label box2 = this.Controls.Find("box" + "2" + i, true).FirstOrDefault() as Label;
                    box2.BackColor = System.Drawing.Color.Transparent;
                    box2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    box2.Enabled = false;
                }
                if (Chk_Log)
                {
                    box.Enabled = true;
                    box.ForeColor = System.Drawing.Color.FromArgb(200, 0, 0);
                    if (i >= 4 && i <= 10)
                    {
                        Label box2 = this.Controls.Find("box" + "2" + i, true).FirstOrDefault() as Label;
                        box2.Enabled = true;
                        box2.ForeColor = System.Drawing.Color.FromArgb(200, 0, 0);
                    }
                }
            }

            boxIdx += jump;
            if (boxIdx > (maxBox - 1))
            {
                boxIdx = maxBox - 2;
                jump = -1;
                movingRight = false;
            }
            else
            {
                if (boxIdx < 0)
                {
                    boxIdx = 1;
                    jump = 1;
                    movingRight = true;
                }
            }

            if (boxIdx < 4 || boxIdx > 10)
            {
                Label box = this.Controls.Find("box" + boxIdx, true).FirstOrDefault() as Label;
                box.BackColor = System.Drawing.ColorTranslator.FromOle(0xC000);
            }
            if (boxIdx >= 4 && boxIdx <= 10)
            {
                Label box2 = this.Controls.Find("box" + "2" + boxIdx, true).FirstOrDefault() as Label;
                box2.BackColor = System.Drawing.ColorTranslator.FromOle(0xC000);
            }
            if (movingRight)
            {
                if ((boxIdx - 1) >= 0)
                {
                    int tmpboxIdx = boxIdx - 1;
                    if (tmpboxIdx < 4 || tmpboxIdx > 10)
                    {
                        Label box = this.Controls.Find("box" + tmpboxIdx, true).FirstOrDefault() as Label;
                        box.BackColor = System.Drawing.ColorTranslator.FromOle(0xFF00);
                    }
                    if (tmpboxIdx >= 4 && tmpboxIdx <= 10)
                    {
                        Label box2 = this.Controls.Find("box" + "2" + tmpboxIdx, true).FirstOrDefault() as Label;
                        box2.BackColor = System.Drawing.ColorTranslator.FromOle(0xFF00);
                    }
                }
                if ((boxIdx - 2) >= 0)
                {
                    int tmpboxIdx = boxIdx - 2;
                    if (tmpboxIdx < 4 || tmpboxIdx > 10)
                    {
                        Label box = this.Controls.Find("box" + tmpboxIdx, true).FirstOrDefault() as Label;
                        box.BackColor = System.Drawing.ColorTranslator.FromOle(0xFF00);
                    }
                    if (tmpboxIdx >= 4 && tmpboxIdx <= 10)
                    {
                        Label box2 = this.Controls.Find("box" + "2" + tmpboxIdx, true).FirstOrDefault() as Label;
                        box2.BackColor = System.Drawing.ColorTranslator.FromOle(0xFF00);
                    }
                }
            }
            else
            {
                if ((boxIdx + 1) <= (maxBox - 1))
                {
                    int tmpboxIdx = boxIdx + 1;
                    if (tmpboxIdx < 4 || tmpboxIdx > 10)
                    {
                        Label box = this.Controls.Find("box" + tmpboxIdx, true).FirstOrDefault() as Label;
                        box.BackColor = System.Drawing.ColorTranslator.FromOle(0xFF00);
                    }
                    if (tmpboxIdx >= 4 && tmpboxIdx <= 10)
                    {
                        Label box2 = this.Controls.Find("box" + "2" + tmpboxIdx, true).FirstOrDefault() as Label;
                        box2.BackColor = System.Drawing.ColorTranslator.FromOle(0xFF00);
                    }
                }
                if ((boxIdx + 2) <= (maxBox - 1))
                {
                    int tmpboxIdx = boxIdx + 2;
                    if (tmpboxIdx < 4 || tmpboxIdx > 10)
                    {
                        Label box = this.Controls.Find("box" + tmpboxIdx, true).FirstOrDefault() as Label;
                        box.BackColor = System.Drawing.ColorTranslator.FromOle(0xFF00);
                    }
                    if (tmpboxIdx >= 4 && tmpboxIdx <= 10)
                    {
                        Label box2 = this.Controls.Find("box" + "2" + tmpboxIdx, true).FirstOrDefault() as Label;
                        box2.BackColor = System.Drawing.ColorTranslator.FromOle(0xFF00);
                    }
                }
            }
        }        
    }
}
