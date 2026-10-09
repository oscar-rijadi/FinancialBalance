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
    public partial class ETF_Stocks_Price : Form
    {
        bool FirstLoad;
        bool Filling;

        //TblETFStocksPrice is keyed on (Price_Date, Full_Ticker), so one price per ticker
        //per day.  That makes Add an upsert and Delete an exact match - no guessing.
        const int MaxRows = 5;

        public ETF_Stocks_Price()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Price_Load(object sender, EventArgs e)
        {
            FirstLoad = true;
            Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

            Filling = true;
            Fill_Full_Ticker();
            Mdl1.Fill_Curr(CmbCurrency);
            Set_Default_Currency();
            Filling = false;

            txtPrice.Text = "0.00";
            ChangeLblDay();
            Clear_Grid();
            Get_All_Prices();
            Apply_Ticker_Rules();
            FirstLoad = false;

            monthCalendar1.Hide();
        }

        private void MnPropertySale_Click(object sender, EventArgs e)
        {
            Property_Sale Property_Sale = new Property_Sale();
            Property_Sale.Show();
            this.Close();
        }

        private void MnPropertyPurchase_Click(object sender, EventArgs e)
        {
            Property_Purchase Property_Purchase = new Property_Purchase();
            Property_Purchase.Show();
            this.Close();
        }

        private void MnPropertyRentalIncome_Click(object sender, EventArgs e)
        {
            Property_Rental_Income Property_Rental_Income = new Property_Rental_Income();
            Property_Rental_Income.Show();
            this.Close();
        }

        private void MnPropertyRentalBankExpense_Click(object sender, EventArgs e)
        {
            Property_Rental_Bank_Expense Property_Rental_Bank_Expense = new Property_Rental_Bank_Expense();
            Property_Rental_Bank_Expense.Show();
            this.Close();
        }

        private void MnPropertyRentalExpense_Click(object sender, EventArgs e)
        {
            Property_Rental_Expense Property_Rental_Expense = new Property_Rental_Expense();
            Property_Rental_Expense.Show();
            this.Close();
        }

        private void MnPropertySetup_Click(object sender, EventArgs e)
        {
            Setup_Property Setup_Property = new Setup_Property();
            Setup_Property.Show();
            this.Close();
        }

        private void MnSuperProcess_Click(object sender, EventArgs e)
        {
            Super_Financial_Year Super_Financial_Year = new Super_Financial_Year();
            Super_Financial_Year.Show();
            this.Close();
        }

        private void MnETFStocksCostBase_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Cost_Base_Adjustment ETF_Stocks_Cost_Base_Adjustment = new ETF_Stocks_Cost_Base_Adjustment();
            ETF_Stocks_Cost_Base_Adjustment.Show();
            this.Close();
        }

        private void MnDaily_Click(object sender, EventArgs e)
        {
            Daily_Input Daily_Input = new Daily_Input();
            Daily_Input.Show();
            this.Close();
        }

        private void MnMonthlyClosing_Click(object sender, EventArgs e)
        {
            Monthly_Closing Monthly_Closing = new Monthly_Closing();
            Monthly_Closing.Show();
            this.Close();
        }

        private void MnETFStocksPurchase_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Purchase ETF_Stocks_Purchase = new ETF_Stocks_Purchase();
            ETF_Stocks_Purchase.Show();
            this.Close();
        }

        private void MnETFStocksSale_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Sale ETF_Stocks_Sale = new ETF_Stocks_Sale();
            ETF_Stocks_Sale.Show();
            this.Close();
        }

        private void MnETFStocksDistribution_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Distribution ETF_Stocks_Distribution = new ETF_Stocks_Distribution();
            ETF_Stocks_Distribution.Show();
            this.Close();
        }

        private void MnETFStocksTaxInterest_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Tax_Interest ETF_Stocks_Tax_Interest = new ETF_Stocks_Tax_Interest();
            ETF_Stocks_Tax_Interest.Show();
            this.Close();
        }

        private void MnETFStocksInvestment_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Investment ETF_Stocks_Investment = new ETF_Stocks_Investment();
            ETF_Stocks_Investment.Show();
            this.Close();
        }

        private void MnETFStocksFYRecon_Click(object sender, EventArgs e)
        {
            ETF_Stocks_FY_Reconciliation ETF_Stocks_FY_Reconciliation = new ETF_Stocks_FY_Reconciliation();
            ETF_Stocks_FY_Reconciliation.Show();
            this.Close();
        }

        //Starts blank so nothing is loaded until a ticker is actually chosen
        private void Fill_Full_Ticker()
        {
            CmbFullTicker.Items.Clear();
            CmbFullTicker.Items.Add("");
            Mdl1.Ssql = "Select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CmbFullTicker.Items.Add(reader["Full_Ticker"].ToString().Trim());
                }
            }
            reader.Close();
            CmbFullTicker.Text = "";
        }

        //Fill_Curr defaults to IDR for the accounting pages; prices default to AUD
        private void Set_Default_Currency()
        {
            if (CmbCurrency.Items.Contains("AUD"))
            {
                CmbCurrency.Text = "AUD";
            }
        }

        //A synced currency need not be one of the codes set up in Currency Setup.  It is
        //still what the price is quoted in, so it is added to the list rather than dropped,
        //which keeps the dropdown showing what was actually stored.
        private void Select_Currency(string parCurrency)
        {
            string TmpCurrency = parCurrency.Trim();
            if (TmpCurrency == "")
            {
                return;
            }
            if (!CmbCurrency.Items.Contains(TmpCurrency))
            {
                CmbCurrency.Items.Add(TmpCurrency);
            }
            CmbCurrency.Text = TmpCurrency;
        }

        //Yahoo does not always send a currency back.  Rather than guess, fall back to
        //whatever that ticker was last priced in, and only then to AUD.
        private string Resolve_Currency(string parFullTicker, string parFetched)
        {
            if (parFetched.Trim() != "")
            {
                return parFetched.Trim();
            }

            double TmpPrice;
            string TmpCurrency;
            if (Latest_Price(parFullTicker, out TmpPrice, out TmpCurrency) && TmpCurrency != "")
            {
                return TmpCurrency;
            }
            return "AUD";
        }

        //Any ticker that is set up can be priced, so the button needs a ticker chosen and
        //nothing else.  It used to be gated on an In Yahoo Finance flag, which made sense while
        //Yahoo was the only source: a holding Yahoo did not carry could not be priced at all,
        //and a disabled button said so before the attempt.  The ASX prices its own listings now
        //and Yahoo the rest, between them covering everything here, so the flag had nothing left
        //to say and has since been dropped from TblETFStocks altogether.  A ticker neither
        //source carries still fails, with a message naming both - which is a better answer than
        //a greyed button, because it says what was tried.
        private void Apply_Ticker_Rules()
        {
            string Ticker = CmbFullTicker.Text.Trim();

            if (Ticker == "")
            {
                CmdSync.Enabled = false;
                LblGridCaption.Text = "Last " + MaxRows.ToString() + " prices";
                return;
            }

            CmdSync.Enabled = true;
            LblGridCaption.Text = "Last " + MaxRows.ToString() + " prices for " + Ticker;
        }

        private void CmbFullTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Apply_Ticker_Rules();
            Get_Data();
        }

        private string Get_Price_Date()
        {
            return CmbYear.Text + CmbMM.Text + CmbDD.Text;
        }

        private void ChangeLblDay()
        {
            switch (DateTime.Parse(Mdl1.toLongDate(Get_Price_Date())).DayOfWeek)
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

        private void DateChanged()
        {
            if (FirstLoad)
            {
                return;
            }
            if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
            {
                ChangeLblDay();
            }
            else
            {
                MessageBox.Show("Invalid Date !", "Error Message");
            }
        }

        private void CmbDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmbMM_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmdCal_Click(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(new System.DateTime(int.Parse(CmbYear.Text), int.Parse(CmbMM.Text), int.Parse(CmbDD.Text), 0, 0, 0, 0));
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            FirstLoad = true;
            CmbDD.Text = e.Start.Day.ToString("00");
            CmbMM.Text = e.Start.Month.ToString("00");
            CmbYear.Text = e.Start.Year.ToString("0000");
            FirstLoad = false;
            monthCalendar1.Hide();
            DateChanged();
        }

        private void Set_Date(string parYyyyMMdd)
        {
            FirstLoad = true;
            CmbYear.Text = parYyyyMMdd.Substring(0, 4);
            CmbMM.Text = parYyyyMMdd.Substring(4, 2);
            CmbDD.Text = parYyyyMMdd.Substring(6, 2);
            FirstLoad = false;
            ChangeLblDay();
        }

        private void Clear_All_Grid()
        {
            gvAllPrices.Rows.Clear();
            gvAllPrices.Columns.Clear();
            gvAllPrices.ColumnCount = 3;
            gvAllPrices.Columns[0].Name = "Full Ticker";
            gvAllPrices.Columns[0].FillWeight = 45;
            gvAllPrices.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvAllPrices.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvAllPrices.Columns[1].Name = "Currency";
            gvAllPrices.Columns[1].FillWeight = 20;
            gvAllPrices.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAllPrices.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAllPrices.Columns[2].Name = "Current Price";
            gvAllPrices.Columns[2].FillWeight = 35;
            gvAllPrices.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAllPrices.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        //Latest stored price for a ticker; false when it has never been priced
        private bool Latest_Price(string parFullTicker, out double parPrice, out string parCurrency)
        {
            parPrice = 0;
            parCurrency = "";
            bool Found = false;

            Mdl1.Ssql = "select top 1 [Price], [Currency] from TblETFStocksPrice where Full_Ticker = '" + parFullTicker
                      + "' order by Price_Date Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                parPrice = Read_Double(reader["Price"]);
                parCurrency = Read_Text(reader["Currency"]);
                Found = true;
            }
            reader.Close();
            return Found;
        }

        //Every ticker with its latest price, whether that price came from Yahoo or was typed in
        private void Get_All_Prices()
        {
            Clear_All_Grid();

            List<string> Tickers = new List<string>();
            Mdl1.Ssql = "select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Tickers.Add(reader["Full_Ticker"].ToString().Trim());
            }
            reader.Close();

            for (int i = 0; i < Tickers.Count; i++)
            {
                double TmpPrice;
                string TmpCurrency;
                string strPrice;
                string strCurrency;
                if (Latest_Price(Tickers[i], out TmpPrice, out TmpCurrency))
                {
                    strPrice = Mdl1.FormatAmt(TmpPrice);
                    strCurrency = (TmpCurrency == "" ? "-" : TmpCurrency);
                }
                else
                {
                    strPrice = "-";
                    strCurrency = "-";
                }
                gvAllPrices.Rows.Add(new string[] { Tickers[i], strCurrency, strPrice });
            }

            gvAllPrices.ClearSelection();
        }

        //Pull every Yahoo-tracked ticker in one pass, reporting once at the end
        private void CmdSyncAll_Click(object sender, EventArgs e)
        {
            List<string> Tickers = new List<string>();
            List<string> Failed = new List<string>();
            int Saved = 0;

            try
            {
                Mdl1.Ssql = "select Full_Ticker from TblETFStocks order by Full_Ticker";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tickers.Add(reader["Full_Ticker"].ToString().Trim());
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
                MessageBox.Show("No ticker is set up in ETF/Stock Setup.", "Error Message");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            CmdSyncAll.Enabled = false;
            CmdSync.Enabled = false;
            try
            {
                for (int i = 0; i < Tickers.Count; i++)
                {
                    decimal TmpPrice;
                    string TmpDate;
                    string TmpCurrency;
                    string TmpError;
                    bool WasUpdate;

                    if (Fetch_Price(Tickers[i], out TmpPrice, out TmpDate, out TmpCurrency, out TmpError))
                    {
                        Save_Price(Tickers[i], TmpDate, TmpPrice, Resolve_Currency(Tickers[i], TmpCurrency), out WasUpdate);
                        Saved++;
                    }
                    else
                    {
                        Failed.Add(Tickers[i] + " : " + TmpError);
                    }
                }

                Get_All_Prices();
                Get_Data();

                string strMsg = Saved.ToString() + " of " + Tickers.Count.ToString() + " ticker(s) updated.";
                if (Failed.Count > 0)
                {
                    strMsg = strMsg + Environment.NewLine + Environment.NewLine + "Not updated :" + Environment.NewLine;
                    for (int i = 0; i < Failed.Count; i++)
                    {
                        strMsg = strMsg + Environment.NewLine + Failed[i];
                    }
                    MessageBox.Show(strMsg, "Error Message");
                }
                else
                {
                    MessageBox.Show(strMsg, "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                CmdSyncAll.Enabled = true;
                Apply_Ticker_Rules();
            }
        }

        private void Clear_Grid()
        {
            gvPrice.Columns.Clear();
            gvPrice.ColumnCount = 3;
            gvPrice.Columns[0].Name = "Price Date";
            gvPrice.Columns[0].FillWeight = 45;
            gvPrice.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPrice.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPrice.Columns[1].Name = "Currency";
            gvPrice.Columns[1].FillWeight = 20;
            gvPrice.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPrice.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPrice.Columns[2].Name = "Price";
            gvPrice.Columns[2].FillWeight = 35;
            gvPrice.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPrice.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        //Most recent first, capped at MaxRows
        private void Get_Data()
        {
            Filling = true;

            Clear_Grid();

            string Ticker = CmbFullTicker.Text.Trim();
            if (Ticker != "")
            {
                string[] row;
                Mdl1.Ssql = "select top " + MaxRows.ToString() + " Price_Date, [Price], [Currency] from TblETFStocksPrice"
                          + " where Full_Ticker = '" + Ticker + "' order by Price_Date Desc";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string TmpDate = reader["Price_Date"].ToString().Trim();
                    string TmpCurrency = Read_Text(reader["Currency"]);
                    row = new string[] { Mdl1.toLongDate(TmpDate), (TmpCurrency == "" ? "-" : TmpCurrency), Mdl1.FormatAmt(Read_Double(reader["Price"])) };
                    gvPrice.Rows.Add(row);
                    gvPrice.Rows[gvPrice.Rows.Count - 1].Tag = TmpDate;
                }
                reader.Close();
            }

            gvPrice.ClearSelection();

            Filling = false;
        }

        //Rows written before Currency existed read back as null
        private string Read_Text(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return "";
            }
            return parValue.ToString().Trim();
        }

        private double Read_Double(object parValue)
        {
            double TmpValue;
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            if (double.TryParse(parValue.ToString(), out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        //Clicking a row loads it back into the date picker and price box
        private void gvPrice_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            if (gvPrice.CurrentRow == null || gvPrice.CurrentRow.Tag == null)
            {
                return;
            }

            Set_Date(gvPrice.CurrentRow.Tag.ToString());
            Select_Currency(gvPrice.CurrentRow.Cells[1].Value.ToString().Replace("-", ""));
            txtPrice.Text = gvPrice.CurrentRow.Cells[2].Value.ToString().Replace(",", "");
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        //Numeric, not negative, at most 2 decimal places
        private bool Valid_Price(string parText, out decimal parValue)
        {
            parValue = 0;

            string TmpText = parText.Trim();
            if (TmpText == "")
            {
                MessageBox.Show("Price cannot be empty !", "Error Message");
                return false;
            }
            if (!decimal.TryParse(TmpText, NumberStyles.Number, CultureInfo.CurrentCulture, out parValue))
            {
                MessageBox.Show("Price must be a number !", "Error Message");
                return false;
            }
            if (parValue < 0)
            {
                MessageBox.Show("Price cannot be negative !", "Error Message");
                return false;
            }

            string TmpPlain = TmpText.Replace(",", "");
            int TmpDot = TmpPlain.IndexOf('.');
            if (TmpDot >= 0 && (TmpPlain.Length - TmpDot - 1) > 2)
            {
                MessageBox.Show("Price can have a maximum of 2 decimal points !", "Error Message");
                return false;
            }
            return true;
        }

        //One row per ticker per date: insert when new, update when it already exists
        private bool Save_Price(string parTicker, string parDate, decimal parPrice, string parCurrency, out bool parWasUpdate)
        {
            parWasUpdate = false;

            Mdl1.Ssql = "select * from TblETFStocksPrice where Price_Date = '" + parDate + "' and Full_Ticker = '" + parTicker + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            parWasUpdate = reader.HasRows;
            reader.Close();

            string TmpPrice = parPrice.ToString("0.00", CultureInfo.InvariantCulture);

            if (parWasUpdate)
            {
                Mdl1.Ssql = "Update TblETFStocksPrice set [Price] = " + TmpPrice
                          + ", [Currency] = '" + parCurrency.Trim() + "'"
                          + " where Price_Date = '" + parDate + "' and Full_Ticker = '" + parTicker + "'";
            }
            else
            {
                Mdl1.Ssql = "Insert into TblETFStocksPrice (Price_Date, Full_Ticker, [Price], [Currency]) values ("
                          + "'" + parDate + "', '" + parTicker + "', " + TmpPrice + ", '" + parCurrency.Trim() + "')";
            }
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            cmd.ExecuteNonQuery();
            return true;
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpPrice;
                bool WasUpdate;

                string Ticker = CmbFullTicker.Text.Trim();
                if (Ticker == "")
                {
                    MessageBox.Show("Full Ticker must be selected !", "Error Message");
                    return;
                }
                if (CmbCurrency.Text.Trim() == "")
                {
                    MessageBox.Show("Currency must be selected !", "Error Message");
                    return;
                }
                if (!Valid_Price(txtPrice.Text, out TmpPrice))
                {
                    return;
                }

                Save_Price(Ticker, Get_Price_Date(), TmpPrice, CmbCurrency.Text.Trim(), out WasUpdate);

                MessageBox.Show((WasUpdate ? "Update" : "Create") + " successfully for " + Ticker
                    + " on " + Mdl1.toLongDate(Get_Price_Date()), "Success");

                Get_Data();
                Get_All_Prices();
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
                string Ticker = CmbFullTicker.Text.Trim();
                if (Ticker == "")
                {
                    MessageBox.Show("Full Ticker must be selected !", "Error Message");
                    return;
                }

                string TmpDate = Get_Price_Date();

                Mdl1.Ssql = "select * from TblETFStocksPrice where Price_Date = '" + TmpDate + "' and Full_Ticker = '" + Ticker + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                bool Exists = reader.HasRows;
                reader.Close();

                if (!Exists)
                {
                    MessageBox.Show("Data not found for " + Ticker + " on " + Mdl1.toLongDate(TmpDate), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksPrice where Price_Date = '" + TmpDate + "' and Full_Ticker = '" + Ticker + "'";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + Ticker + " on " + Mdl1.toLongDate(TmpDate), "Success");

                Get_Data();
                Get_All_Prices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //The ASX quotes its own listings, and for PMGOLD.AX it is the only source that has the
        //price right at all: Yahoo answers 17.94 against the 59.97 the exchange is showing.
        //Where both can answer they agree exactly - checked across every ASX holding here:
        //A200 144.90, BGBL 86.75, BSUB 25.59, DHHF 41.63, JPEQ 62.30, NDQ 64.18, SEMI 40.18,
        //VHY 82.48, VTEK 69.33, VVLU 80.30, every one identical.  So going to the exchange
        //first costs nothing and takes away the question of whether Yahoo has the symbol right.
        //
        //priceLast is the last traded price.  The payload carries no timestamp of any kind, and
        //neither does any other endpoint on this API - price-history, prices, intraday-prices
        //and price-chart are all 404 - so the date is today.  This is the latest price rather
        //than a historical one, and the table is keyed per day, so fetching twice in a day
        //updates the row rather than adding a second.
        //
        //Nothing in the payload names a currency either.  The ASX quotes in Australian dollars,
        //so that is what is recorded, rather than leaving it for Resolve_Currency to guess at.
        private bool Fetch_ASX_Price(string parCode, out decimal parPrice, out string parDate,
                                     out string parCurrency, out string parError)
        {
            parPrice = 0;
            parDate = "";
            parCurrency = "";
            parError = "";

            try
            {
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

                string Url = "https://asx.api.markitdigital.com/asx-research/1.0/companies/"
                           + Uri.EscapeDataString(parCode) + "/header";

                string Json;
                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add("User-Agent", "Mozilla/5.0");
                    Json = Client.DownloadString(Url);
                }

                Match PriceMatch = Regex.Match(Json, "\"priceLast\"\\s*:\\s*(-?[0-9]+(\\.[0-9]+)?)");
                if (!PriceMatch.Success)
                {
                    parError = "The ASX did not return a price for " + parCode + ".";
                    return false;
                }
                if (!decimal.TryParse(PriceMatch.Groups[1].Value, NumberStyles.Number,
                                      CultureInfo.InvariantCulture, out parPrice) || parPrice <= 0)
                {
                    parError = "Could not read the price the ASX returned for " + parCode + ".";
                    return false;
                }

                //the figures come back in full binary precision - JPEQ answers 62.300000000000004
                parPrice = Math.Round(parPrice, 2);
                parCurrency = "AUD";
                parDate = DateTime.Now.ToString("yyyyMMdd");
                return true;
            }
            catch (WebException ex)
            {
                //a code the exchange does not list comes back 400, not 404
                HttpWebResponse Response = ex.Response as HttpWebResponse;
                if (Response != null && (Response.StatusCode == HttpStatusCode.NotFound
                                         || Response.StatusCode == HttpStatusCode.BadRequest))
                {
                    parError = "The ASX does not list the code " + parCode + ".";
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

        //A holding on the Australian exchange, by the suffix ETF/Stock Setup builds into the
        //full ticker.  Everything without one is quoted somewhere the ASX cannot be asked about.
        private bool Is_ASX(string parFullTicker)
        {
            return parFullTicker.Trim().ToUpper().EndsWith(".AX");
        }

        //PMGOLD.AX is plain PMGOLD to the exchange's own API
        private string ASX_Code(string parFullTicker)
        {
            string TmpTicker = parFullTicker.Trim().ToUpper();
            int TmpDot = TmpTicker.LastIndexOf('.');
            return (TmpDot > 0 ? TmpTicker.Substring(0, TmpDot) : TmpTicker);
        }

        //Where a price comes from: the exchange that lists it where that can be asked, and
        //Yahoo for everything else.  An ASX holding the exchange will not answer for falls
        //through to Yahoo rather than failing outright, and that fallback is safe now that the
        //Yahoo side reads the daily series - even a symbol whose Yahoo quote is broken comes
        //back with a real price there, just the previous close rather than the last trade.
        private bool Fetch_Price(string parFullTicker, out decimal parPrice, out string parDate,
                                 out string parCurrency, out string parError)
        {
            parPrice = 0;
            parDate = "";
            parCurrency = "";
            parError = "";

            string TmpAsxError = "";
            if (Is_ASX(parFullTicker))
            {
                if (Fetch_ASX_Price(ASX_Code(parFullTicker), out parPrice, out parDate,
                                    out parCurrency, out TmpAsxError))
                {
                    return true;
                }
            }

            string TmpYahooError;
            if (Fetch_Yahoo_Price(parFullTicker, out parPrice, out parDate, out parCurrency,
                                  out TmpYahooError))
            {
                return true;
            }

            //both sides named, so a failure says what was actually tried rather than half of it
            parError = (TmpAsxError == "" ? TmpYahooError : TmpAsxError + "  " + TmpYahooError);
            return false;
        }

        //An epoch read in the exchange's timezone where Yahoo named one, and in this machine's
        //where it did not.  Only the date is wanted, so the offset only has to be right to
        //within a day - which is exactly what it decides.
        private string Exchange_Day(long parEpoch, bool parHasOffset, int parOffsetSeconds)
        {
            DateTimeOffset TmpWhen = DateTimeOffset.FromUnixTimeSeconds(parEpoch);
            if (parHasOffset)
            {
                return TmpWhen.ToOffset(TimeSpan.FromSeconds(parOffsetSeconds))
                              .ToString("yyyyMMdd", CultureInfo.InvariantCulture);
            }
            return TmpWhen.LocalDateTime.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
        }

        //Yahoo's chart endpoint carries a last traded price in its meta block, and for most
        //symbols that is the figure to take.  For some it is simply wrong.  PMGOLD.AX answers
        //a regularMarketPrice of 17.94 against a real price near 60, alongside a
        //regularMarketTime of 0, no volume, no day high or low and a null currency - which is
        //Yahoo saying it holds no current quote for the symbol rather than that the price is
        //that.  The daily series in the same payload is right.
        //
        //So the price is read off the series - the last bar in the window that has actually
        //closed - and the meta price is kept only for a symbol that returns no series at all.
        //For a symbol whose quote does work the two are the same figure to the cent: checked
        //against A200.AX, VHY.AX, NDQ.AX, GOOGL and SCHD, all five agreed exactly.
        //
        //The window is five days rather than one because it is the series being read now.  A
        //one day range holds a single bar, and that bar is empty until the day has closed.
        //
        //Still no JSON library: the two arrays are pulled out with a regular expression like
        //everything else here.  The quote block comes before the adjusted one in the payload
        //and "adjclose" does not match a search for "close" that includes its opening quote,
        //so the first match of each is the pair wanted.
        private bool Fetch_Yahoo_Price(string parTicker, out decimal parPrice, out string parDate, out string parCurrency, out string parError)
        {
            parPrice = 0;
            parDate = "";
            parCurrency = "";
            parError = "";

            try
            {
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

                string Url = "https://query1.finance.yahoo.com/v8/finance/chart/"
                           + Uri.EscapeDataString(parTicker) + "?interval=1d&range=5d";

                string Json;
                using (WebClient Client = new WebClient())
                {
                    Client.Headers.Add("User-Agent", "Mozilla/5.0");
                    Json = Client.DownloadString(Url);
                }

                //Which day a price belongs to is a question about the exchange, not about this machine.
                //Yahoo gives the epoch in UTC and the exchange's offset from it beside the price, so the
                //offset is what the epoch is read through: a US close at 16:00 EDT is 06:00 or 07:00 the
                //next morning in Australia, and dating it by local time filed every US price a day late.
                //
                //An exchange in this machine's own timezone is unaffected, because the two agree.
                //Without an offset to read it through there is nothing better than local time, which is
                //what this did throughout before.
                bool HasOffset = false;
                int TmpOffset = 0;
                Match OffsetMatch = Regex.Match(Json, "\"gmtoffset\"\\s*:\\s*(-?[0-9]+)");
                if (OffsetMatch.Success && int.TryParse(OffsetMatch.Groups[1].Value, NumberStyles.Integer,
                                                        CultureInfo.InvariantCulture, out TmpOffset))
                {
                    HasOffset = true;
                }

                //Yahoo answers in two places, and a price has to be taken together with the day it
                //belongs to.  Reading the price from one and the date from the other is what filed
                //SCHD's 7 October close of 32.65 under the 8th: the quote held the 8th's close of
                //33.15 and a timestamp to match, while the series had not been given the 8th's close
                //yet - the bar was there, with an open and a volume, but a null close.
                //
                //So the quote is taken whole where it is sound, and the series whole where it is not.
                //regularMarketTime decides which: PMGOLD.AX, whose quote price is simply wrong,
                //carries 0 there, and that is what sends it to the series.
                decimal TmpQuote = 0;
                long TmpQuoteWhen = 0;
                Match PriceMatch = Regex.Match(Json, "\"regularMarketPrice\"\\s*:\\s*(-?[0-9]+(\\.[0-9]+)?)");
                if (PriceMatch.Success)
                {
                    decimal.TryParse(PriceMatch.Groups[1].Value, NumberStyles.Number,
                                     CultureInfo.InvariantCulture, out TmpQuote);
                }
                Match TimeMatch = Regex.Match(Json, "\"regularMarketTime\"\\s*:\\s*([0-9]+)");
                if (TimeMatch.Success)
                {
                    long.TryParse(TimeMatch.Groups[1].Value, out TmpQuoteWhen);
                }

                if (TmpQuote > 0 && TmpQuoteWhen > 0)
                {
                    parPrice = Math.Round(TmpQuote, 2);
                    parDate = Exchange_Day(TmpQuoteWhen, HasOffset, TmpOffset);
                }
                else
                {
                    //the series instead, each close taken with its own bar's day
                    Match TimesMatch = Regex.Match(Json, "\"timestamp\"\\s*:\\s*\\[([^\\]]*)\\]");
                    Match ClosesMatch = Regex.Match(Json, "\"close\"\\s*:\\s*\\[([^\\]]*)\\]");
                    if (TimesMatch.Success && ClosesMatch.Success)
                    {
                        string[] Times = TimesMatch.Groups[1].Value.Split(',');
                        string[] Closes = ClosesMatch.Groups[1].Value.Split(',');

                        //backwards, because the last bar is empty while its own day is still running
                        for (int i = Closes.Length - 1; i >= 0; i--)
                        {
                            decimal TmpClose;
                            if (!decimal.TryParse(Closes[i].Trim(), NumberStyles.Number,
                                                  CultureInfo.InvariantCulture, out TmpClose) || TmpClose <= 0)
                            {
                                continue;
                            }
                            parPrice = Math.Round(TmpClose, 2);

                            long TmpWhen;
                            if (i < Times.Length && long.TryParse(Times[i].Trim(), out TmpWhen) && TmpWhen > 0)
                            {
                                parDate = Exchange_Day(TmpWhen, HasOffset, TmpOffset);
                            }
                            break;
                        }
                    }
                }

                if (parPrice <= 0)
                {
                    parError = "Yahoo Finance did not return a price for " + parTicker + ".";
                    return false;
                }

                //currency the price is quoted in, straight from the same meta block
                Match CurrMatch = Regex.Match(Json, "\"currency\"\\s*:\\s*\"([A-Za-z]{2,5})\"");
                if (CurrMatch.Success)
                {
                    parCurrency = CurrMatch.Groups[1].Value.Trim();
                }

                //Both of the paths above set the date alongside the price.  This is only for a payload
                //that carried a price with no usable time against it at all.
                if (parDate == "")
                {
                    parDate = DateTime.Now.ToString("yyyyMMdd");
                }
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

        private void CmdSync_Click(object sender, EventArgs e)
        {
            decimal TmpPrice;
            string TmpDate;
            string TmpCurrency;
            string TmpError;
            bool WasUpdate;

            string Ticker = CmbFullTicker.Text.Trim();
            if (Ticker == "")
            {
                MessageBox.Show("Full Ticker must be selected !", "Error Message");
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            CmdSync.Enabled = false;
            try
            {
                if (!Fetch_Price(Ticker, out TmpPrice, out TmpDate, out TmpCurrency, out TmpError))
                {
                    MessageBox.Show(TmpError, "Error Message");
                    return;
                }

                TmpCurrency = Resolve_Currency(Ticker, TmpCurrency);
                Save_Price(Ticker, TmpDate, TmpPrice, TmpCurrency, out WasUpdate);

                Set_Date(TmpDate);
                Select_Currency(TmpCurrency);
                txtPrice.Text = TmpPrice.ToString("0.00", CultureInfo.InvariantCulture);

                MessageBox.Show("Latest price for " + Ticker + " on " + Mdl1.toLongDate(TmpDate)
                    + " is " + TmpCurrency + " " + Mdl1.FormatAmt((double)TmpPrice) + " and has been "
                    + (WasUpdate ? "updated" : "saved") + ".", "Success");

                Get_Data();
                Get_All_Prices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                Apply_Ticker_Rules();
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
