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
            Fill_Interval();
            Filling = false;

            Calculate_Full_Ticker();
            Get_Data();
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

        //Blank first, so a ticker that pays nothing on a schedule can say so. The rest come
        //from TblInterval, which Interval Setup keeps.
        private void Fill_Interval()
        {
            CmbInterval.Items.Clear();
            CmbInterval.Items.Add("");

            Mdl1.Ssql = "select [Name] from TblInterval order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbInterval.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            CmbInterval.Text = "";
        }

        //Only digits and a decimal point, as everywhere else a figure is typed. A yield
        //cannot be negative, so no minus sign is let through.
        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        //A share of the price, not an amount, so two places and a per-cent sign.
        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
        }

        private double Yield()
        {
            string TmpText = txtYield.Text.Trim().Replace("%", "").Replace(",", "");
            double TmpValue;
            if (!double.TryParse(TmpText, NumberStyles.Any, CultureInfo.InvariantCulture, out TmpValue))
            {
                return 0;
            }
            return Math.Round(TmpValue, 2);
        }

        private double Read_Double(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            double TmpValue;
            if (double.TryParse(parValue.ToString(), NumberStyles.Any,
                                CultureInfo.InvariantCulture, out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        //Yahoo has no free endpoint that simply states a yield - the quote and quoteSummary
        //ones now answer 401 without a crumb. The chart endpoint still answers plainly, and
        //asked for dividend events it carries everything the figure is made of: what was
        //paid over the window, and the price to measure it against. So the yield is worked
        //out here rather than read off - trailing twelve months over the current price,
        //which is what Yahoo's own figure means.
        private bool Fetch_Yahoo_Yield(string parTicker, out double parYield, out int parCount,
                                       out double parTotal, out double parPrice,
                                       out string parCurrency, out string parError)
        {
            parYield = 0;
            parCount = 0;
            parTotal = 0;
            parPrice = 0;
            parCurrency = "";
            parError = "";

            try
            {
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

                string Url = "https://query1.finance.yahoo.com/v8/finance/chart/"
                           + Uri.EscapeDataString(parTicker) + "?interval=1d&range=1y&events=div";

                string Json;
                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add("User-Agent", "Mozilla/5.0");
                    Json = Client.DownloadString(Url);
                }

                Match PriceMatch = Regex.Match(Json, "\"regularMarketPrice\"\\s*:\\s*(-?[0-9]+(\\.[0-9]+)?)");
                if (!PriceMatch.Success
                    || !double.TryParse(PriceMatch.Groups[1].Value, NumberStyles.Number,
                                        CultureInfo.InvariantCulture, out parPrice)
                    || parPrice <= 0)
                {
                    parError = "Yahoo Finance did not return a price for " + parTicker
                             + ", so a yield cannot be worked out.";
                    return false;
                }

                Match CurrMatch = Regex.Match(Json, "\"currency\"\\s*:\\s*\"([A-Za-z]{2,5})\"");
                if (CurrMatch.Success)
                {
                    parCurrency = CurrMatch.Groups[1].Value.Trim();
                }

                //Each dividend event is an amount against the date it went ex.  The pair is
                //unique to those events - a split carries a ratio, not an amount - so they can
                //be read straight out of the payload without walking into the events block.
                long CutOff = DateTimeOffset.UtcNow.AddYears(-1).ToUnixTimeSeconds();
                foreach (Match Div in Regex.Matches(Json,
                             "\"amount\"\\s*:\\s*(-?[0-9]+(?:\\.[0-9]+)?)\\s*,\\s*\"date\"\\s*:\\s*([0-9]+)"))
                {
                    double TmpAmount;
                    long TmpWhen;
                    if (!double.TryParse(Div.Groups[1].Value, NumberStyles.Number,
                                         CultureInfo.InvariantCulture, out TmpAmount))
                    {
                        continue;
                    }
                    if (!long.TryParse(Div.Groups[2].Value, out TmpWhen) || TmpWhen < CutOff)
                    {
                        continue;
                    }
                    parTotal += TmpAmount;
                    parCount++;
                }

                parTotal = Math.Round(parTotal, 4);
                parYield = Math.Round((parTotal / parPrice) * 100, 2);
                return true;
            }
            catch (WebException ex)
            {
                HttpWebResponse Response = ex.Response as HttpWebResponse;
                if (Response != null && Response.StatusCode == HttpStatusCode.NotFound)
                {
                    parError = "Yahoo Finance does not recognise the ticker " + parTicker + ".";
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

        //Fills the yield box and stops there.  Nothing is written, so the figure can be
        //overtyped like any other before Setup is pressed - Yahoo's number is a starting
        //point, not the last word.
        private void CmdGetYield_Click(object sender, EventArgs e)
        {
            double TmpYield;
            int TmpCount;
            double TmpTotal;
            double TmpPrice;
            string TmpCurrency;
            string TmpError;

            Calculate_Full_Ticker();
            string TmpTicker = Full_Ticker.Text.Trim();
            if (TmpTicker == "")
            {
                MessageBox.Show("Ticker cannot be empty !", "Error Message");
                return;
            }
            //the same gate the price page puts on its sync, read off the form rather than
            //the table so it also answers for a ticker not saved yet
            if (CmbInYahooFinance.Text.Trim() != "Y")
            {
                MessageBox.Show(TmpTicker + " is not flagged as In Yahoo Finance.", "Error Message");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            CmdGetYield.Enabled = false;
            try
            {
                if (!Fetch_Yahoo_Yield(TmpTicker, out TmpYield, out TmpCount, out TmpTotal,
                                       out TmpPrice, out TmpCurrency, out TmpError))
                {
                    MessageBox.Show(TmpError, "Error Message");
                    return;
                }

                txtYield.Text = TmpYield.ToString("0.00", CultureInfo.InvariantCulture);

                string TmpMoney = (TmpCurrency == "" ? "" : TmpCurrency + " ");
                if (TmpCount == 0)
                {
                    //a real answer rather than a failure: plenty of tickers pay nothing
                    MessageBox.Show("Yahoo Finance shows no distribution or dividend for "
                        + TmpTicker + " in the last 12 months, so the yield is 0.00 %."
                        + " Press Setup to save it.", "Success");
                }
                else
                {
                    MessageBox.Show(TmpCount.ToString() + " distribution(s) totalling "
                        + TmpMoney + TmpTotal.ToString("#,##0.0000", CultureInfo.InvariantCulture)
                        + " in the last 12 months against a price of "
                        + TmpMoney + TmpPrice.ToString("#,##0.00", CultureInfo.InvariantCulture)
                        + " gives " + TmpTicker + " a yield of "
                        + TmpYield.ToString("0.00", CultureInfo.InvariantCulture) + " %."
                        + " Change it if you need to, then press Setup to save it.", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                CmdGetYield.Enabled = true;
            }
        }

        private void Clear_Grid()
        {
            gvETFStocks.Columns.Clear();
            gvETFStocks.ColumnCount = 6;
            gvETFStocks.Columns[0].Name = "Ticker";
            gvETFStocks.Columns[0].FillWeight = 14;
            gvETFStocks.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[1].Name = "Exchange Suffix";
            gvETFStocks.Columns[1].FillWeight = 21;
            gvETFStocks.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[2].Name = "Full Ticker";
            gvETFStocks.Columns[2].FillWeight = 17;
            gvETFStocks.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[3].Name = "In Yahoo Finance";
            gvETFStocks.Columns[3].FillWeight = 21;
            gvETFStocks.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[4].Name = "Yield";
            gvETFStocks.Columns[4].FillWeight = 11;
            gvETFStocks.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvETFStocks.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvETFStocks.Columns[5].Name = "Interval";
            gvETFStocks.Columns[5].FillWeight = 16;
            gvETFStocks.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Get_Data()
        {
            Filling = true;

            Clear_Grid();

            string[] row;
            string strInYahooFinance;

            Mdl1.Ssql = "select Ticker, Exchange_Suffix, Full_Ticker, In_YahooFinance,"
                      + " Distribution_Dividend_Yield, Distribution_Dividend_Interval"
                      + " from TblETFStocks order by Full_Ticker";
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
                    row = new string[] { reader["Ticker"].ToString().Trim(),
                                         reader["Exchange_Suffix"].ToString().Trim(),
                                         reader["Full_Ticker"].ToString().Trim(),
                                         strInYahooFinance,
                                         Percent(Read_Double(reader["Distribution_Dividend_Yield"])),
                                         reader["Distribution_Dividend_Interval"].ToString().Trim() };
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
            //the grid carries the yield dressed with a per-cent sign; the box holds a bare
            //figure, since that is what may be typed back into it
            txtYield.Text = Read_Double(gvETFStocks.CurrentRow.Cells[4].Value.ToString()
                                .Replace("%", "").Replace(",", "").Trim())
                            .ToString("0.00", CultureInfo.InvariantCulture);
            CmbInterval.Text = (gvETFStocks.CurrentRow.Cells[5].Value == null
                                ? "" : gvETFStocks.CurrentRow.Cells[5].Value.ToString().Trim());
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
                    Mdl1.Ssql = "Insert into TblETFStocks (Ticker, Exchange_Suffix, Full_Ticker,"
                              + " In_YahooFinance, Distribution_Dividend_Yield,"
                              + " Distribution_Dividend_Interval) values ('"
                              + Ticker.Text.Trim() + "', '" + CmbExchangeSuffix.Text.Trim() + "', '"
                              + Full_Ticker.Text.Trim() + "', " + strInYahooFinance + ", "
                              + Yield().ToString("0.00", CultureInfo.InvariantCulture) + ", '"
                              + CmbInterval.Text.Trim().Replace("'", "''") + "')";
                }
                else
                {
                    Mdl1.Ssql = "Update TblETFStocks set Ticker = '" + Ticker.Text.Trim()
                              + "', Exchange_Suffix = '" + CmbExchangeSuffix.Text.Trim()
                              + "', In_YahooFinance = " + strInYahooFinance
                              + ", Distribution_Dividend_Yield = "
                              + Yield().ToString("0.00", CultureInfo.InvariantCulture)
                              + ", Distribution_Dividend_Interval = '" + CmbInterval.Text.Trim().Replace("'", "''")
                              + "' where Full_Ticker = '" + Full_Ticker.Text.Trim() + "'";
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
