using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace FinancialBalance
{
    public partial class Setup_Curr_Rate : Form
    {
        bool FirstLoad;

        //The base every rate on this page is measured in. A row here says how many rupiah one
        //unit of Curr_Code is worth, which is why IDR's own rate is 1 and why every conversion
        //in the application returns 1 for it without ever reading the table.
        const string BaseCurr = "IDR";
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

        private void MnPropertyRentalExpTypeSetup_Click(object sender, EventArgs e)
        {
            Setup_Property_Rental_Expense_Type Setup_Property_Rental_Expense_Type = new Setup_Property_Rental_Expense_Type();
            Setup_Property_Rental_Expense_Type.Show();
            this.Close();
        }

        private void MnTaxAllocationSetup_Click(object sender, EventArgs e)
        {
            Setup_Tax_Allocation Setup_Tax_Allocation = new Setup_Tax_Allocation();
            Setup_Tax_Allocation.Show();
            this.Close();
        }

        private void MnStateSetup_Click(object sender, EventArgs e)
        {
            Setup_State Setup_State = new Setup_State();
            Setup_State.Show();
            this.Close();
        }

        private void MnETFStocksInvPlanSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Investment_Plan Setup_ETF_Stocks_Investment_Plan = new Setup_ETF_Stocks_Investment_Plan();
            Setup_ETF_Stocks_Investment_Plan.Show();
            this.Close();
        }

        private void MnSuperFundSetup_Click(object sender, EventArgs e)
        {
            Setup_Super_Fund Setup_Super_Fund = new Setup_Super_Fund();
            Setup_Super_Fund.Show();
            this.Close();
        }

        private void MnSuperSetup_Click(object sender, EventArgs e)
        {
            Setup_Super Setup_Super = new Setup_Super();
            Setup_Super.Show();
            this.Close();
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

        private void MnIntervalSetup_Click(object sender, EventArgs e)
        {
            Setup_Interval Setup_Interval = new Setup_Interval();
            Setup_Interval.Show();
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

        //A rate is written in one place only, so the Setup button and the Get Latest Currency
        //button cannot drift apart on what a saved row looks like.
        private void Save_Rate(string parDate, string parCurr, double parRate)
        {
            bool FlagRecNotExist;

            Mdl1.Ssql = "Select top 1 Curr_Date from TblCurrRate where Curr_Date = '" + parDate + "' and Curr_Code = '" + parCurr + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            FlagRecNotExist = !reader.HasRows;
            reader.Close();

            if (FlagRecNotExist)
            {
                Mdl1.Ssql = "Insert into TblCurrRate values ('" + parDate + "', '" + parCurr + "', " + Sql_Rate(parRate) + ")";
            }
            else
            {
                Mdl1.Ssql = "Update TblCurrRate set Curr_Rate = " + Sql_Rate(parRate) + " where Curr_Date = '" + parDate + "' and Curr_Code = '" + parCurr + "'";
            }
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            cmd.ExecuteNonQuery();
        }

        //The rate goes into the statement as a bare number, so it has to be written the way SQL
        //reads one. On a machine whose decimal separator is a comma, 12617,80 would arrive as
        //two arguments rather than one rate.
        private string Sql_Rate(double parRate)
        {
            return Math.Round(parRate, 2).ToString("0.00", CultureInfo.InvariantCulture);
        }

        //Two of the codes in TblCurrCode are the user's own rather than ISO 4217, and Yahoo has
        //never heard of either of them. Anything not listed goes out as it stands, so a currency
        //added later under a proper code needs nothing doing here.
        private string Iso_Code(string parCurr)
        {
            string strCurr = parCurr.Trim().ToUpper();
            if (strCurr == "BHT")
            {
                return "THB";
            }
            if (strCurr == "YEN")
            {
                return "JPY";
            }
            return strCurr;
        }

        //Yahoo quotes a currency pair as if it were an instrument, so AUDIDR=X is the price of
        //one Australian dollar in rupiah - which is exactly what this table holds. The chart
        //endpoint is the one ETF/Stock Setup already uses: quote and quoteSummary answer 401
        //without a crumb, while this one answers plainly.
        private bool Fetch_Latest_Rate(string parCurr, out double parRate, out DateTime parWhen,
                                       out bool parQuoted, out string parError)
        {
            parRate = 0;
            parWhen = DateTime.Now;
            parQuoted = false;
            parError = "";

            //one rupiah to the rupiah, by definition - there is no pair to ask for
            if (parCurr.Trim().ToUpper() == BaseCurr)
            {
                parRate = 1;
                return true;
            }

            string strPair = Iso_Code(parCurr) + BaseCurr + "=X";

            try
            {
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

                string Url = "https://query1.finance.yahoo.com/v8/finance/chart/"
                           + Uri.EscapeDataString(strPair) + "?interval=1d&range=5d";

                string Json;
                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add("User-Agent", "Mozilla/5.0");
                    Json = Client.DownloadString(Url);
                }

                double TmpRaw;
                Match RateMatch = Regex.Match(Json, "\"regularMarketPrice\"\\s*:\\s*(-?[0-9]+(\\.[0-9]+)?)");
                if (!RateMatch.Success
                    || !double.TryParse(RateMatch.Groups[1].Value, NumberStyles.Number,
                                        CultureInfo.InvariantCulture, out TmpRaw)
                    || TmpRaw <= 0)
                {
                    parError = "Yahoo Finance did not return a rate for " + strPair + ".";
                    return false;
                }

                //Curr_Rate holds two decimal places, so a currency worth less than half a cent of a
                //rupiah cannot be stored at all. Saying so beats writing a zero that would then be
                //multiplied through every conversion in the application.
                parRate = Math.Round(TmpRaw, 2);
                if (parRate == 0)
                {
                    parError = "One " + parCurr.Trim() + " is worth "
                             + TmpRaw.ToString("0.########", CultureInfo.InvariantCulture) + " " + BaseCurr
                             + ", which rounds to nothing at the two decimal places a rate is stored to.";
                    return false;
                }

                long TmpWhen;
                Match WhenMatch = Regex.Match(Json, "\"regularMarketTime\"\\s*:\\s*([0-9]+)");
                if (WhenMatch.Success && long.TryParse(WhenMatch.Groups[1].Value, out TmpWhen))
                {
                    parWhen = DateTimeOffset.FromUnixTimeSeconds(TmpWhen).ToLocalTime().DateTime;
                    parQuoted = true;
                }

                return true;
            }
            catch (WebException ex)
            {
                HttpWebResponse Response = ex.Response as HttpWebResponse;
                if (Response != null && Response.StatusCode == HttpStatusCode.NotFound)
                {
                    parError = "Yahoo Finance does not quote " + strPair + ", so there is no rate to"
                             + " fetch for " + parCurr.Trim() + ".";
                }
                else
                {
                    parError = "Could not reach Yahoo Finance : " + ex.Message;
                }
                return false;
            }
            catch (Exception ex)
            {
                parError = ex.Message;
                return false;
            }
        }

        //Fetches and saves in one go, which is what sets it apart from the yield button on
        //ETF/Stock Setup. A yield is a starting point to be adjusted before it is stored; a rate
        //is a fact about a day, and there is nothing to look over before writing it down.
        private void CmdGetRate_Click(object sender, EventArgs e)
        {
            double TmpRate;
            DateTime TmpWhen;
            bool TmpQuoted;
            string TmpError;

            string strCurr = CmbCurr.Text.Trim();
            if (strCurr == "")
            {
                MessageBox.Show("Currency cannot be empty !", "Error Message");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            CmdGetRate.Enabled = false;
            CmdSetup.Enabled = false;
            CmdBack.Enabled = false;
            try
            {
                if (!Fetch_Latest_Rate(strCurr, out TmpRate, out TmpWhen, out TmpQuoted, out TmpError))
                {
                    MessageBox.Show(TmpError, "Error Message");
                    return;
                }

                //"Latest" means today, whatever date the page happened to be showing: a rate read
                //just now is not a fact about some other day. The pickers move with it so the page
                //ends up showing the row that was written rather than the one that was on screen.
                DateTime TmpToday = DateTime.Now;
                string strDate = TmpToday.ToString("yyyyMMdd");

                Save_Rate(strDate, strCurr, TmpRate);

                FirstLoad = true;
                CmbDD.Text = TmpToday.ToString("dd");
                CmbMM.Text = TmpToday.ToString("MM");
                CmbYear.Text = TmpToday.ToString("yyyy");
                FirstLoad = false;

                ChangeLblDay();
                Get_Data();
                Get_Rate();

                if (strCurr.ToUpper() == BaseCurr)
                {
                    MessageBox.Show(BaseCurr + " is what every other rate is measured in, so its own"
                        + " rate is 1.00 without going to the internet. Saved against "
                        + Mdl1.toLongDate(strDate) + ".", "Success");
                }
                else
                {
                    MessageBox.Show("Yahoo Finance quotes one " + strCurr + " at "
                        + TmpRate.ToString("#,##0.00", CultureInfo.InvariantCulture) + " " + BaseCurr
                        + (TmpQuoted ? ", as at " + TmpWhen.ToString("dd MMMM yyyy HH:mm") : "")
                        + ". Saved against " + Mdl1.toLongDate(strDate) + ".", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                CmdGetRate.Enabled = true;
                CmdSetup.Enabled = true;
                CmdBack.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                string strDate = CmbYear.Text + CmbMM.Text + CmbDD.Text;

                Save_Rate(strDate, CmbCurr.Text, Mdl1.checkNumeric(txtRate.Text));

                MessageBox.Show("Create or Update successfully for Currency Code : " + CmbCurr.Text + " and Date : " + Mdl1.toLongDate(strDate), "Success");

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
