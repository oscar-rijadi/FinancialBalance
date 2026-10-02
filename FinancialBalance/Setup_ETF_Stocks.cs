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
using System.IO;
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

        //Only digits and a decimal point, as everywhere else a figure is typed. Neither a yield
        //nor an expense ratio can be negative, so no minus sign is let through.
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

        private double Read_Box(TextBox parBox)
        {
            string TmpText = parBox.Text.Trim().Replace("%", "").Replace(",", "");
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
            Cursor.Current = Cursors.WaitCursor;
            Buttons(false);
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
                Buttons(true);
            }
        }

        //Nothing else on the page may be pressed while a run is in the air.  A Setup in the
        //middle of one would write the entry boxes' old figures straight back over ones just
        //fetched, and Back would leave the rest of the run talking to a closed form.
        private void Buttons(bool parOn)
        {
            CmdGetYield.Enabled = parOn;
            CmdGetAllYield.Enabled = parOn;
            CmdGetAllExpenseRatio.Enabled = parOn;
            CmdSetup.Enabled = parOn;
            CmdDel.Enabled = parOn;
            CmdBack.Enabled = parOn;
        }

        //Every flagged ticker in one pass, and this one writes.  The button beside it fills the
        //box and leaves saving to Setup, because one figure can be looked at before it is taken;
        //a whole list cannot, so these are saved as they come back - the same bargain
        //Get All Latest Currency makes on Currency Rate Setup.
        //
        //Every ticker that is set up is asked about.  The list used to be narrowed by an
        //In_YahooFinance flag, which is gone from the table: a ticker Yahoo does not carry is
        //reported as one it could not answer for rather than left silently out of the run,
        //which is the more honest of the two and costs one request to find out.
        private void CmdGetAllYield_Click(object sender, EventArgs e)
        {
            List<string> Tickers = new List<string>();
            List<string> Failed = new List<string>();
            Dictionary<string, double> Saved = new Dictionary<string, double>();

            try
            {
                //the whole list is read and the reader closed before any of it is fetched or
                //written.  Jet will not carry a second command on this connection while a reader
                //is open on it, and the updates below go down the same one.
                Mdl1.Ssql = "select Full_Ticker from TblETFStocks order by Full_Ticker";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string TmpTicker = reader["Full_Ticker"].ToString().Trim();
                    if (TmpTicker != "")
                    {
                        Tickers.Add(TmpTicker);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
                return;
            }

            if (Tickers.Count == 0)
            {
                MessageBox.Show("No ETF or stock is set up.", "Error Message");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Buttons(false);
            try
            {
                for (int i = 0; i < Tickers.Count; i++)
                {
                    double TmpYield;
                    int TmpCount;
                    double TmpTotal;
                    double TmpPrice;
                    string TmpCurrency;
                    string TmpError;

                    if (!Fetch_Yahoo_Yield(Tickers[i], out TmpYield, out TmpCount, out TmpTotal,
                                           out TmpPrice, out TmpCurrency, out TmpError))
                    {
                        //one ticker Yahoo will not answer for stops that ticker, not the run
                        Failed.Add(Tickers[i] + " : " + TmpError);
                        continue;
                    }

                    //a ticker that paid nothing has a yield of 0.00 %, which is an answer rather
                    //than a failure, and saving it is the point: it clears a figure that has
                    //stopped being true.
                    Mdl1.Ssql = "Update TblETFStocks set Distribution_Dividend_Yield = "
                              + TmpYield.ToString("0.00", CultureInfo.InvariantCulture)
                              + " where Full_Ticker = '" + Tickers[i].Replace("'", "''") + "'";
                    OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                    Saved[Tickers[i]] = TmpYield;
                }

                Get_Data();

                //the entry boxes are usually showing one of these tickers, and a box left holding
                //the old figure would be written straight back over the new one by the next Setup
                string TmpOnScreen = Full_Ticker.Text.Trim();
                if (TmpOnScreen != "" && Saved.ContainsKey(TmpOnScreen))
                {
                    txtYield.Text = Saved[TmpOnScreen].ToString("0.00", CultureInfo.InvariantCulture);
                }

                string TmpMsg = Saved.Count.ToString() + " of " + Tickers.Count.ToString()
                              + " dividend yield(s) updated from Yahoo Finance.";
                if (Failed.Count > 0)
                {
                    TmpMsg = TmpMsg + Environment.NewLine + Environment.NewLine
                           + "Not updated :" + Environment.NewLine;
                    for (int i = 0; i < Failed.Count; i++)
                    {
                        TmpMsg = TmpMsg + Environment.NewLine + Failed[i];
                    }
                    MessageBox.Show(TmpMsg, "Error Message");
                }
                else
                {
                    MessageBox.Show(TmpMsg, "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                Buttons(true);
                Cursor.Current = Cursors.Default;
            }
        }

        //WebClient keeps no cookies, and Yahoo's quoteSummary will not answer without the one
        //it hands out alongside a crumb, so the expense ratio requests go through
        //HttpWebRequest instead.  A null jar is simply a request that carries none.
        private string Download(string parUrl, CookieContainer parJar)
        {
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(parUrl);
            Request.UserAgent = "Mozilla/5.0";
            Request.CookieContainer = parJar;
            using (HttpWebResponse Response = (HttpWebResponse)Request.GetResponse())
            using (StreamReader Reader = new StreamReader(Response.GetResponseStream()))
            {
                return Reader.ReadToEnd();
            }
        }

        //An ASX ticker is asked of the ASX itself.  Yahoo knows these funds but leaves their
        //expense ratio empty, every one of them, and calls some active ETFs - JPEQ, VVLU -
        //EQUITY, which would pass them off as shares.  The research API behind asx.com.au
        //states it as managementFeePercent, already a percentage, for ETFs and listed
        //investment companies alike.  It is asked by the bare ASX code - A200, not A200.AX.
        private bool Fetch_ASX_Expense_Ratio(string parCode, out double parRatio, out string parError)
        {
            parRatio = 0;
            parError = "";

            try
            {
                string Json = Download("https://asx.api.markitdigital.com/asx-research/1.0/etfs/"
                                       + Uri.EscapeDataString(parCode) + "/key-statistics", null);

                //-32768 is how this API writes a figure it does not have, so a negative fee is
                //no fee rather than a refund
                Match FeeMatch = Regex.Match(Json, "\"managementFeePercent\"\\s*:\\s*(-?[0-9]+(?:\\.[0-9]+)?)");
                double TmpFee;
                if (FeeMatch.Success
                    && double.TryParse(FeeMatch.Groups[1].Value, NumberStyles.Number,
                                       CultureInfo.InvariantCulture, out TmpFee)
                    && TmpFee >= 0)
                {
                    parRatio = Math.Round(TmpFee, 2);
                    return true;
                }

                //No fee and no net asset value is a company rather than a fund - BHP answers
                //this way - and a company charges its holders nothing to run it, so 0.00 is an
                //answer rather than a failure.  A fund always carries a NAV, so one that comes
                //back without a fee is a figure the ASX does not have, and is not guessed at.
                if (!Regex.IsMatch(Json, "\"nav\"\\s*:"))
                {
                    parRatio = 0;
                    return true;
                }

                parError = "The ASX does not publish a management fee for " + parCode + ".";
                return false;
            }
            catch (WebException ex)
            {
                //an unknown code is answered with 400 "Symbol not found" rather than a 404
                HttpWebResponse Response = ex.Response as HttpWebResponse;
                if (Response != null && (Response.StatusCode == HttpStatusCode.BadRequest
                                         || Response.StatusCode == HttpStatusCode.NotFound))
                {
                    parError = "The ASX does not recognise the code " + parCode + ".";
                }
                else
                {
                    parError = "Could not reach the ASX : " + ex.Message;
                }
                return false;
            }
            catch (Exception ex)
            {
                parError = ex.Message;
                return false;
            }
        }

        //quoteSummary answers 401 to a bare request: it wants a crumb, and the crumb is only
        //handed to a caller holding the cookie fc.yahoo.com sets.  That page answers 404 and
        //sets the cookie anyway, so its failing is expected and not an error.  Returns the
        //crumb, or "" with the reason when there is none to be had.
        private string Get_Yahoo_Crumb(CookieContainer parJar, out string parError)
        {
            parError = "";

            try
            {
                Download("https://fc.yahoo.com/", parJar);
            }
            catch (WebException)
            {
                //the cookie comes back on the 404, which is all this request is for
            }

            try
            {
                string TmpCrumb = Download("https://query1.finance.yahoo.com/v1/test/getcrumb", parJar).Trim();
                if (TmpCrumb == "" || TmpCrumb.Contains("<") || TmpCrumb.Contains("{"))
                {
                    parError = "Yahoo Finance did not hand out a crumb, so it cannot be asked for an expense ratio.";
                    return "";
                }
                return TmpCrumb;
            }
            catch (Exception ex)
            {
                parError = "Could not reach Yahoo Finance : " + ex.Message;
                return "";
            }
        }

        //Anything not on the ASX is asked of Yahoo, which carries the ratio for US funds as a
        //fraction - 0.0006 for 0.06 %, sometimes written 5.9999997E-4.
        private bool Fetch_Yahoo_Expense_Ratio(string parTicker, CookieContainer parJar, string parCrumb,
                                               out double parRatio, out string parError)
        {
            parRatio = 0;
            parError = "";

            try
            {
                string Json = Download("https://query1.finance.yahoo.com/v10/finance/quoteSummary/"
                                       + Uri.EscapeDataString(parTicker) + "?modules=quoteType,fundProfile"
                                       + "&crumb=" + Uri.EscapeDataString(parCrumb), parJar);

                //a share is not a fund and charges nothing for holding it, so 0.00 - an answer,
                //not a failure
                Match TypeMatch = Regex.Match(Json, "\"quoteType\"\\s*:\\s*\"([A-Z]+)\"");
                if (TypeMatch.Success && TypeMatch.Groups[1].Value == "EQUITY")
                {
                    parRatio = 0;
                    return true;
                }

                //The same field turns up twice: once for the fund, and again under
                //feesExpensesInvestmentCat as the average for its category - 0.85 % against
                //SCHD's own 0.06 %.  Only the fund's own block is searched, so a fund Yahoo has
                //no figure for is reported as such rather than handed its category's.
                int TmpFrom = Json.IndexOf("\"feesExpensesInvestment\"", StringComparison.Ordinal);
                if (TmpFrom >= 0)
                {
                    string TmpBlock = Json.Substring(TmpFrom);
                    int TmpTo = TmpBlock.IndexOf("\"feesExpensesInvestmentCat\"", StringComparison.Ordinal);
                    if (TmpTo >= 0)
                    {
                        TmpBlock = TmpBlock.Substring(0, TmpTo);
                    }

                    Match RatioMatch = Regex.Match(TmpBlock,
                        "\"annualReportExpenseRatio\"\\s*:\\s*\\{\\s*\"raw\"\\s*:\\s*(-?[0-9.]+(?:[Ee][-+]?[0-9]+)?)");
                    double TmpRaw;
                    if (RatioMatch.Success
                        && double.TryParse(RatioMatch.Groups[1].Value, NumberStyles.Float,
                                           CultureInfo.InvariantCulture, out TmpRaw)
                        && TmpRaw >= 0)
                    {
                        parRatio = Math.Round(TmpRaw * 100, 2);
                        return true;
                    }
                }

                parError = "Yahoo Finance does not carry an expense ratio for " + parTicker + ".";
                return false;
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

        //Every ticker in one pass, saved as each comes back - the bargain Get All Dividend
        //Yield makes, for the same reason: a whole list cannot be looked over first.
        //
        //Where a ticker is asked depends on where it trades, and on nothing else: one on the
        //ASX is asked of the ASX, since Yahoo is not where its fee comes from, and anything
        //else is asked of Yahoo.  That used to need an In_YahooFinance flag to decide the
        //second half, and a ticker with neither the suffix nor the flag was dropped from the
        //run; with the flag gone from the table the suffix decides it on its own and nothing
        //is dropped.
        private void CmdGetAllExpenseRatio_Click(object sender, EventArgs e)
        {
            List<string> Tickers = new List<string>();
            Dictionary<string, string> AsxCodes = new Dictionary<string, string>();
            List<string> Failed = new List<string>();
            Dictionary<string, double> Saved = new Dictionary<string, double>();

            try
            {
                //read whole and closed before anything is fetched or written, for the same
                //reason as the yield run: the updates go down this same connection
                Mdl1.Ssql = "select Ticker, Exchange_Suffix, Full_Ticker"
                          + " from TblETFStocks order by Full_Ticker";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string TmpTicker = reader["Full_Ticker"].ToString().Trim();
                    if (TmpTicker == "")
                    {
                        continue;
                    }
                    Tickers.Add(TmpTicker);
                    if (reader["Exchange_Suffix"].ToString().Trim() == "AX")
                    {
                        AsxCodes[TmpTicker] = reader["Ticker"].ToString().Trim();
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
                return;
            }

            if (Tickers.Count == 0)
            {
                MessageBox.Show("No ETF or stock is set up.", "Error Message");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Buttons(false);
            try
            {
                CookieContainer YahooJar = new CookieContainer();
                string YahooCrumb = null;
                string YahooCrumbError = "";

                for (int i = 0; i < Tickers.Count; i++)
                {
                    double TmpRatio;
                    string TmpError;
                    bool TmpOk;

                    if (AsxCodes.ContainsKey(Tickers[i]))
                    {
                        TmpOk = Fetch_ASX_Expense_Ratio(AsxCodes[Tickers[i]], out TmpRatio, out TmpError);
                    }
                    else
                    {
                        //one crumb serves the whole run, so it is asked for once, by the first
                        //ticker that needs it - a run of nothing but ASX tickers never asks
                        if (YahooCrumb == null)
                        {
                            YahooCrumb = Get_Yahoo_Crumb(YahooJar, out YahooCrumbError);
                        }
                        if (YahooCrumb == "")
                        {
                            TmpRatio = 0;
                            TmpError = YahooCrumbError;
                            TmpOk = false;
                        }
                        else
                        {
                            TmpOk = Fetch_Yahoo_Expense_Ratio(Tickers[i], YahooJar, YahooCrumb,
                                                              out TmpRatio, out TmpError);
                        }
                    }

                    if (!TmpOk)
                    {
                        //one ticker that cannot be answered for stops that ticker, not the run,
                        //and what is already on record for it is left alone
                        Failed.Add(Tickers[i] + " : " + TmpError);
                        continue;
                    }

                    Mdl1.Ssql = "Update TblETFStocks set Expense_Ratio = "
                              + TmpRatio.ToString("0.00", CultureInfo.InvariantCulture)
                              + " where Full_Ticker = '" + Tickers[i].Replace("'", "''") + "'";
                    OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                    Saved[Tickers[i]] = TmpRatio;
                }

                Get_Data();

                //the box would otherwise write its old figure back over the new one on Setup
                string TmpOnScreen = Full_Ticker.Text.Trim();
                if (TmpOnScreen != "" && Saved.ContainsKey(TmpOnScreen))
                {
                    txtExpenseRatio.Text = Saved[TmpOnScreen].ToString("0.00", CultureInfo.InvariantCulture);
                }

                string TmpMsg = Saved.Count.ToString() + " of " + Tickers.Count.ToString()
                              + " expense ratio(s) updated.";
                if (Failed.Count > 0)
                {
                    TmpMsg = TmpMsg + Environment.NewLine + Environment.NewLine
                           + "Not updated :" + Environment.NewLine;
                    for (int i = 0; i < Failed.Count; i++)
                    {
                        TmpMsg = TmpMsg + Environment.NewLine + Failed[i];
                    }
                    MessageBox.Show(TmpMsg, "Error Message");
                }
                else
                {
                    MessageBox.Show(TmpMsg, "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                Buttons(true);
                Cursor.Current = Cursors.Default;
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
            gvETFStocks.Columns[1].FillWeight = 17;
            gvETFStocks.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[2].Name = "Full Ticker";
            gvETFStocks.Columns[2].FillWeight = 19;
            gvETFStocks.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvETFStocks.Columns[3].Name = "Yield";
            gvETFStocks.Columns[3].FillWeight = 15;
            gvETFStocks.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvETFStocks.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvETFStocks.Columns[4].Name = "Interval";
            gvETFStocks.Columns[4].FillWeight = 17;
            gvETFStocks.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvETFStocks.Columns[5].Name = "Expense Ratio";
            gvETFStocks.Columns[5].FillWeight = 18;
            gvETFStocks.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvETFStocks.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Get_Data()
        {
            Filling = true;

            Clear_Grid();

            string[] row;

            Mdl1.Ssql = "select Ticker, Exchange_Suffix, Full_Ticker,"
                      + " Distribution_Dividend_Yield, Distribution_Dividend_Interval, Expense_Ratio"
                      + " from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    row = new string[] { reader["Ticker"].ToString().Trim(),
                                         reader["Exchange_Suffix"].ToString().Trim(),
                                         reader["Full_Ticker"].ToString().Trim(),
                                         Percent(Read_Double(reader["Distribution_Dividend_Yield"])),
                                         reader["Distribution_Dividend_Interval"].ToString().Trim(),
                                         Percent(Read_Double(reader["Expense_Ratio"])) };
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
            //the grid carries the yield and the expense ratio dressed with a per-cent sign; the
            //boxes hold a bare figure, since that is what may be typed back into them
            txtYield.Text = Read_Double(gvETFStocks.CurrentRow.Cells[3].Value.ToString()
                                .Replace("%", "").Replace(",", "").Trim())
                            .ToString("0.00", CultureInfo.InvariantCulture);
            CmbInterval.Text = (gvETFStocks.CurrentRow.Cells[4].Value == null
                                ? "" : gvETFStocks.CurrentRow.Cells[4].Value.ToString().Trim());
            txtExpenseRatio.Text = Read_Double(gvETFStocks.CurrentRow.Cells[5].Value.ToString()
                                       .Replace("%", "").Replace(",", "").Trim())
                                   .ToString("0.00", CultureInfo.InvariantCulture);
            Filling = false;

            Calculate_Full_Ticker();
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                bool FlagRecNotExist;

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
                              + " Distribution_Dividend_Yield,"
                              + " Distribution_Dividend_Interval, Expense_Ratio) values ('"
                              + Ticker.Text.Trim() + "', '" + CmbExchangeSuffix.Text.Trim() + "', '"
                              + Full_Ticker.Text.Trim() + "', "
                              + Read_Box(txtYield).ToString("0.00", CultureInfo.InvariantCulture) + ", '"
                              + CmbInterval.Text.Trim().Replace("'", "''") + "', "
                              + Read_Box(txtExpenseRatio).ToString("0.00", CultureInfo.InvariantCulture) + ")";
                }
                else
                {
                    Mdl1.Ssql = "Update TblETFStocks set Ticker = '" + Ticker.Text.Trim()
                              + "', Exchange_Suffix = '" + CmbExchangeSuffix.Text.Trim()
                              + "', Distribution_Dividend_Yield = "
                              + Read_Box(txtYield).ToString("0.00", CultureInfo.InvariantCulture)
                              + ", Distribution_Dividend_Interval = '" + CmbInterval.Text.Trim().Replace("'", "''")
                              + "', Expense_Ratio = "
                              + Read_Box(txtExpenseRatio).ToString("0.00", CultureInfo.InvariantCulture)
                              + " where Full_Ticker = '" + Full_Ticker.Text.Trim() + "'";
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
