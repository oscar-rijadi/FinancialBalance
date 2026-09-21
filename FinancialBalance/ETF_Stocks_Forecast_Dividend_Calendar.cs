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

namespace FinancialBalance
{
    public partial class ETF_Stocks_Forecast_Dividend_Calendar : Form
    {
        bool Filling;

        //Index-aligned with CmbPortfolio: entry 0 is "All" and carries no portfolio code.
        //Held as a list rather than looked up by description, because descriptions
        //are not unique in TblETFStocksPortfolioCode.
        List<string> FlagCodes = new List<string>();

        //the twelve months being forecast, each held as the first of that month
        List<DateTime> Months = new List<DateTime>();

        public ETF_Stocks_Forecast_Dividend_Calendar()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Forecast_Dividend_Calendar_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Portfolio();
            Filling = false;

            Build_Months();
            Get_Data();
        }

        //"All" plus one entry per portfolio code, showing its description
        private void Fill_Portfolio()
        {
            CmbPortfolio.Items.Clear();
            FlagCodes.Clear();

            CmbPortfolio.Items.Add("All");
            FlagCodes.Add(null);

            Mdl1.Ssql = "select Portfolio_Code, [Description] from TblETFStocksPortfolioCode"
                      + (chkMainOnly.Checked ? " where [Is_Main] = True" : "")
                      + " order by Portfolio_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = reader["Portfolio_Code"].ToString().Trim();
                string TmpDesc = reader["Description"].ToString().Trim();
                if (TmpDesc == "")
                {
                    TmpDesc = TmpCode;
                }
                CmbPortfolio.Items.Add(TmpDesc);
                FlagCodes.Add(TmpCode);
            }
            reader.Close();

            CmbPortfolio.Text = "All";
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        //With Main Only ticked, only purchases whose portfolio is marked Is_Main count.  A
        //purchase with no portfolio at all is excluded too, since it belongs to no main one.
        private string Main_Filter()
        {
            if (!chkMainOnly.Checked)
            {
                return "";
            }
            return " and [Portfolio_Code] In (select Portfolio_Code from TblETFStocksPortfolioCode where [Is_Main] = True)";
        }

        private void chkMainOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //the portfolio list itself changes, so rebuild from the top
            Filling = true;
            Fill_Portfolio();
            Filling = false;
            Get_Data();
        }

        //The window starts with the month we are in, not the one after.  A payment is placed
        //by stepping forward from the last one actually received, so a holding that has already
        //paid this month gets nothing in the first column anyway - while one whose turn falls
        //due about now is still shown.
        private void Build_Months()
        {
            Months.Clear();
            DateTime TmpStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            for (int i = 0; i < 12; i++)
            {
                Months.Add(TmpStart.AddMonths(i));
            }
        }

        private bool Is_Dollar(string parCurr)
        {
            if (parCurr == null)
            {
                return false;
            }
            string TmpCurr = parCurr.Trim().ToUpper();
            return (TmpCurr == "AUD" || TmpCurr == "USD");
        }

        private string Money(double parValue, string parCurr)
        {
            if (!Is_Dollar(parCurr))
            {
                return Mdl1.FormatAmt(parValue);
            }
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        private double Read_Double(object parValue)
        {
            double TmpValue;
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            if (double.TryParse(parValue.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        //Latest price for a ticker, or false when the ticker has never been priced.  The
        //same read ETF/Stock Portfolio Summary makes, and the same answer it acts on.
        private bool Get_Latest_Price(string parFullTicker, out double parPrice)
        {
            parPrice = 0;
            bool Found = false;

            Mdl1.Ssql = "select top 1 [Price] from TblETFStocksPrice where Full_Ticker = '"
                      + parFullTicker.Replace("'", "''") + "' order by Price_Date Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                parPrice = Read_Double(reader["Price"]);
                Found = true;
            }
            reader.Close();
            return Found;
        }

        //How many months apart the payments are.  Anything else - including a blank interval -
        //answers 0, which means the holding cannot be forecast rather than that it pays nothing.
        private int Interval_Months(string parInterval)
        {
            switch (parInterval.Trim().ToUpper())
            {
                case "MONTHLY":
                    return 1;
                case "QUARTERLY":
                    return 3;
                case "HALF YEARLY":
                    return 6;
                case "YEARLY":
                    return 12;
                default:
                    return 0;
            }
        }

        //The month a ticker last actually paid in, whatever portfolio it was held under - the
        //schedule belongs to the holding, not to the portfolio it sits in.  Returns false when
        //nothing has ever been received for it.
        private bool Last_Paid_Month(string parFullTicker, out DateTime parMonth)
        {
            parMonth = DateTime.MinValue;
            string TmpDate = "";

            Mdl1.Ssql = "select Max(Pay_Date) as LastPaid from TblETFStocksDistributionDividend"
                      + " where Full_Ticker = '" + parFullTicker.Replace("'", "''") + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && reader["LastPaid"] != DBNull.Value)
            {
                TmpDate = reader["LastPaid"].ToString().Trim();
            }
            reader.Close();

            if (TmpDate.Length < 6)
            {
                return false;
            }

            DateTime TmpParsed;
            if (!DateTime.TryParseExact(TmpDate.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out TmpParsed))
            {
                return false;
            }
            parMonth = TmpParsed;
            return true;
        }

        //Places one holding's payments across the twelve columns.  Stepping forward from the
        //last payment received is what makes this a calendar rather than a flat twelfth of the
        //year: a quarterly payer that last paid in July is due again in October, not in January.
        //With nothing on record there is no month to anchor to, so the run starts at the first
        //column and the note says how many were placed that way.
        private double[] Spread(double parPerPayment, int parStep, bool parAnchored, DateTime parAnchor)
        {
            double[] Result = new double[12];

            DateTime TmpNext;
            if (parAnchored)
            {
                TmpNext = parAnchor.AddMonths(parStep);
                while (TmpNext < Months[0])
                {
                    TmpNext = TmpNext.AddMonths(parStep);
                }
            }
            else
            {
                //Nothing to anchor to, so fall back on the cycle the calendar itself implies:
                //January, and every step from it - April, July and October for a quarterly
                //payer, January and July for a half yearly one. That is the cycle every
                //holding that does have a history actually pays on, so a holding with none
                //lands in step with the rest instead of on whichever month the page is opened.
                TmpNext = Months[0];
                while ((TmpNext.Month - 1) % parStep != 0)
                {
                    TmpNext = TmpNext.AddMonths(1);
                }
            }

            while (TmpNext <= Months[11])
            {
                int TmpIdx = ((TmpNext.Year - Months[0].Year) * 12) + (TmpNext.Month - Months[0].Month);
                if (TmpIdx >= 0 && TmpIdx < 12)
                {
                    Result[TmpIdx] += parPerPayment;
                }
                TmpNext = TmpNext.AddMonths(parStep);
            }
            return Result;
        }

        //What the ticker is already recorded as paying inside the window, summed per month for
        //the portfolio in view.  A distribution is often entered before the cash lands, so the
        //window routinely holds real figures for this month and the next - stepping past them
        //and forecasting from the anchor instead would leave those months looking empty.
        private double[] Actuals(string parFullTicker, string parPortfolioAnd)
        {
            double[] Result = new double[12];

            string TmpFrom = Months[0].ToString("yyyyMM", CultureInfo.InvariantCulture) + "01";
            string TmpTo = Months[11].ToString("yyyyMM", CultureInfo.InvariantCulture) + "31";

            Mdl1.Ssql = "select Pay_Date, Total_Amount from TblETFStocksDistributionDividend"
                      + " where Full_Ticker = '" + parFullTicker.Replace("'", "''") + "'"
                      + " and Pay_Date >= '" + TmpFrom + "' and Pay_Date <= '" + TmpTo + "'"
                      + parPortfolioAnd;
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpDate = reader["Pay_Date"].ToString().Trim();
                if (TmpDate.Length < 6)
                {
                    continue;
                }
                DateTime TmpMonth;
                if (!DateTime.TryParseExact(TmpDate.Substring(0, 6), "yyyyMM",
                                            CultureInfo.InvariantCulture, DateTimeStyles.None, out TmpMonth))
                {
                    continue;
                }
                int TmpIdx = ((TmpMonth.Year - Months[0].Year) * 12) + (TmpMonth.Month - Months[0].Month);
                if (TmpIdx >= 0 && TmpIdx < 12)
                {
                    Result[TmpIdx] += Read_Double(reader["Total_Amount"]);
                }
            }
            reader.Close();
            return Result;
        }

        private void Clear_Grid()
        {
            gvForecast.Columns.Clear();
            gvForecast.Rows.Clear();
            gvForecast.ColumnCount = 16;

            gvForecast.Columns[0].Name = "Full Ticker";
            gvForecast.Columns[0].FillWeight = 90;
            gvForecast.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvForecast.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //the two figures the whole row is worked out from, in front of the months they
            //produce, so a surprising run of months can be traced back without leaving the row
            gvForecast.Columns[1].Name = "Current Amount";
            gvForecast.Columns[1].FillWeight = 85;
            gvForecast.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvForecast.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvForecast.Columns[2].Name = "Yield";
            gvForecast.Columns[2].FillWeight = 50;
            gvForecast.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvForecast.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            for (int i = 0; i < 12; i++)
            {
                gvForecast.Columns[i + 3].Name = Months[i].ToString("MMM yyyy", CultureInfo.InvariantCulture);
                gvForecast.Columns[i + 3].FillWeight = 65;
                gvForecast.Columns[i + 3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gvForecast.Columns[i + 3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            gvForecast.Columns[15].Name = "Total";
            gvForecast.Columns[15].FillWeight = 80;
            gvForecast.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvForecast.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        //Only unsold holdings count towards a portfolio - the same rule ETF/Stock Portfolio
        //Summary applies, and the same two filters decide which of them are in view.
        private void Get_Data()
        {
            try
            {
                Clear_Grid();

                string TmpFlagCode = null;
                int idx = CmbPortfolio.SelectedIndex;
                if (idx > 0 && idx < FlagCodes.Count)
                {
                    TmpFlagCode = FlagCodes[idx];
                }

                //the same clause narrows the purchases and the distributions, so it is built once
                string TmpPortfolioAnd = "";
                if (TmpFlagCode != null)
                {
                    TmpPortfolioAnd += " and [Portfolio_Code] = '" + TmpFlagCode + "'";
                }
                TmpPortfolioAnd += Main_Filter();
                string TmpWhere = " where Is_Sold = False" + TmpPortfolioAnd;
                LblNote.Text = "Unsold holdings only"
                    + (TmpFlagCode == null ? "" : "  (portfolio " + TmpFlagCode + ")")
                    + (chkMainOnly.Checked ? "  (main portfolios only)" : "");

                //read the holdings first, so no reader is open while the rest is looked up
                List<string> Tickers = new List<string>();
                List<string> Currs = new List<string>();
                List<double> TotUnits = new List<double>();
                List<double> TotInvs = new List<double>();

                //a ticker is bought in one currency, so Max picks that one value
                Mdl1.Ssql = "select Full_Ticker, Max([Currency]) as Curr, Sum(Unit) as TotUnit,"
                          + " Sum(Real_Total_Cost_Base) as TotInv"
                          + " from TblETFStocksPurchase" + TmpWhere
                          + " group by Full_Ticker order by Full_Ticker";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tickers.Add(reader["Full_Ticker"].ToString().Trim());
                    Currs.Add(reader["Curr"] == DBNull.Value ? "" : reader["Curr"].ToString().Trim());
                    TotUnits.Add(Read_Double(reader["TotUnit"]));
                    TotInvs.Add(Read_Double(reader["TotInv"]));
                }
                reader.Close();

                double TotalUnit = 0;
                double TotalInvestment = 0;
                double TotalCurrent = 0;
                double[] MonthTotals = new double[12];
                double GrandTotal = 0;
                int NotForecast = 0;
                int Actual = 0;
                int Unpriced = 0;
                int Guessed = 0;
                bool AllDollar = true;

                for (int i = 0; i < Tickers.Count; i++)
                {
                    TotalUnit += TotUnits[i];
                    TotalInvestment += TotInvs[i];
                    if (!Is_Dollar(Currs[i]))
                    {
                        AllDollar = false;
                    }

                    //the yield is quoted against the market price, so that is what it is
                    //applied to - an unpriced holding therefore cannot be forecast at all
                    double TmpPrice;
                    bool Priced = Get_Latest_Price(Tickers[i], out TmpPrice);
                    double TmpCurrent = 0;
                    if (Priced)
                    {
                        TmpCurrent = Math.Round(TotUnits[i] * TmpPrice, 2);
                        TotalCurrent += TmpCurrent;
                    }

                    double TmpYield = 0;
                    string TmpInterval = "";
                    Mdl1.Ssql = "select Distribution_Dividend_Yield, Distribution_Dividend_Interval"
                              + " from TblETFStocks where Full_Ticker = '" + Tickers[i].Replace("'", "''") + "'";
                    OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        TmpYield = Read_Double(reader2["Distribution_Dividend_Yield"]);
                        TmpInterval = (reader2["Distribution_Dividend_Interval"] == DBNull.Value
                                       ? "" : reader2["Distribution_Dividend_Interval"].ToString().Trim());
                    }
                    reader2.Close();

                    int TmpStep = Interval_Months(TmpInterval);

                    //Nothing to go on is not the same as nothing to expect, so those rows say so
                    //rather than claiming a forecast of zero.
                    if (!Priced)
                    {
                        Unpriced++;
                    }
                    else if (TmpStep == 0 || TmpYield <= 0)
                    {
                        NotForecast++;
                    }
                    if (!Priced || TmpStep == 0 || TmpYield <= 0 || TmpCurrent <= 0)
                    {
                        //what is known is still shown; only the months are unanswerable
                        string[] blank = new string[16];
                        blank[0] = Tickers[i];
                        blank[1] = (Priced ? Money(TmpCurrent, Currs[i]) : "-");
                        blank[2] = TmpYield.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
                        for (int m = 3; m < 16; m++)
                        {
                            blank[m] = "-";
                        }
                        gvForecast.Rows.Add(blank);
                        continue;
                    }

                    double TmpAnnual = Math.Round(TmpCurrent * TmpYield / 100, 2);
                    double TmpPer = Math.Round(TmpAnnual / (12 / TmpStep), 2);

                    DateTime TmpAnchor;
                    bool Anchored = Last_Paid_Month(Tickers[i], out TmpAnchor);
                    if (!Anchored)
                    {
                        Guessed++;
                    }

                    double[] TmpRow = Spread(TmpPer, TmpStep, Anchored, TmpAnchor);
                    double[] TmpPaid = Actuals(Tickers[i], TmpPortfolioAnd);

                    double TmpRowTotal = 0;
                    string[] row = new string[16];
                    row[0] = Tickers[i];
                    row[1] = Money(TmpCurrent, Currs[i]);
                    row[2] = TmpYield.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
                    for (int m = 0; m < 12; m++)
                    {
                        //a figure already on record beats one worked out
                        double TmpCell = (TmpPaid[m] > 0 ? TmpPaid[m] : TmpRow[m]);
                        row[m + 3] = (TmpCell == 0 ? "" : Money(TmpCell, Currs[i]));
                        TmpRowTotal += TmpCell;
                        MonthTotals[m] += TmpCell;
                    }
                    row[15] = Money(TmpRowTotal, Currs[i]);
                    GrandTotal += TmpRowTotal;
                    gvForecast.Rows.Add(row);

                    //a recorded figure is not a forecast, and the difference matters when the
                    //question is why a month reads the way it does
                    int RowIdx = gvForecast.Rows.Count - 1;
                    for (int m = 0; m < 12; m++)
                    {
                        if (TmpPaid[m] > 0)
                        {
                            gvForecast.Rows[RowIdx].Cells[m + 3].Style.ForeColor = Color.FromArgb(0, 0, 192);
                            Actual++;
                        }
                    }
                }

                string TmpCurr = (Tickers.Count > 0 && AllDollar ? "AUD" : "");

                //A totals row inside the grid rather than twelve labels underneath: there is one
                //figure per month, and only the grid knows where each month's column has ended up.
                if (Tickers.Count > 0)
                {
                    string[] totals = new string[16];
                    totals[0] = "Total";
                    totals[1] = Money(TotalCurrent, TmpCurr);
                    //a yield is a rate, not something a column of them can be added up into
                    totals[2] = "";
                    for (int m = 0; m < 12; m++)
                    {
                        totals[m + 3] = Money(MonthTotals[m], TmpCurr);
                    }
                    totals[15] = Money(GrandTotal, TmpCurr);
                    gvForecast.Rows.Add(totals);

                    DataGridViewRow TotalRow = gvForecast.Rows[gvForecast.Rows.Count - 1];
                    TotalRow.DefaultCellStyle.Font = new Font(gvForecast.Font, FontStyle.Bold);
                    TotalRow.DefaultCellStyle.BackColor = Color.FromArgb(232, 232, 232);
                    TotalRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 232, 232);
                    TotalRow.DefaultCellStyle.SelectionForeColor = Color.Black;
                }

                LblTotUnit.Text = TotalUnit.ToString("#,##0.0000");
                LblTotInv.Text = Money(TotalInvestment, TmpCurr);
                LblTotCur.Text = Money(TotalCurrent, TmpCurr);
                LblGrand.Text = Money(GrandTotal, TmpCurr);

                //against what the holdings cost, as asked - so this is a yield on cost, and
                //reads lower than the per-ticker yields, which are quoted on today's price
                double TmpGrandYield = 0;
                if (TotalInvestment > 0)
                {
                    TmpGrandYield = (GrandTotal / TotalInvestment) * 100;
                }
                LblGrandYield.Text = TmpGrandYield.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";

                Show_Basis(Tickers.Count, NotForecast, Unpriced, Guessed, Actual);

                gvForecast.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Says what the figures rest on.  A forecast built from a yield typed on one page and a
        //payment history on another is worth only as much as those, so the page states its
        //workings rather than letting the numbers speak for themselves.
        private void Show_Basis(int parHoldings, int parNotForecast, int parUnpriced,
                                int parGuessed, int parActual)
        {
            string TmpText = "Forecast only. Each holding's yearly amount is its unit holding"
                + " multiplied by the latest recorded price, then by the Distribution/Dividend"
                + " Yield held in ETF/Stock Setup, split into equal payments by the"
                + " Distribution/Dividend Interval and placed by stepping forward from the last"
                + " payment on record.";

            if (parUnpriced > 0)
            {
                TmpText = TmpText + "   -   " + parUnpriced.ToString()
                    + " of " + parHoldings.ToString()
                    + " holding(s) have no price on record and are shown as \"-\".";
            }
            if (parNotForecast > 0)
            {
                TmpText = TmpText + "   -   " + parNotForecast.ToString()
                    + " of " + parHoldings.ToString()
                    + " holding(s) have no yield or no interval in ETF/Stock Setup and are shown as \"-\".";
            }
            if (parGuessed > 0)
            {
                TmpText = TmpText + "   -   " + parGuessed.ToString()
                    + " holding(s) have never paid, so their run falls on the January cycle"
                    + " (Jan/Apr/Jul/Oct quarterly, Jan/Jul half yearly) rather than on a month"
                    + " of their own.";
            }
            if (parActual > 0)
            {
                TmpText = TmpText + "   -   " + parActual.ToString()
                    + " month(s) shown in blue are already recorded in ETF/Stock"
                    + " Distribution/Dividend, not forecast.";
            }
            LblBasis.Text = TmpText;
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
