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
    public partial class ETF_Stocks_Portfolio_Summary : Form
    {
        bool Filling;

        //Index-aligned with CmbPortfolio: entry 0 is "All" and carries no flag code.
        //Held as a list rather than looked up by description, because descriptions
        //are not unique in TblETFStocksPurchaseFlag.
        List<string> FlagCodes = new List<string>();

        //tickers the current portfolio actually holds, feeding the Full Ticker dropdown
        List<string> SummaryTickers = new List<string>();

        public ETF_Stocks_Portfolio_Summary()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Portfolio_Summary_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Portfolio();
            Filling = false;

            Refresh_All();
        }

        //"All" plus one entry per purchase flag, showing its description
        private void Fill_Portfolio()
        {
            CmbPortfolio.Items.Clear();
            FlagCodes.Clear();

            CmbPortfolio.Items.Add("All");
            FlagCodes.Add(null);

            Mdl1.Ssql = "select Flag_Code, [Description] from TblETFStocksPurchaseFlag"
                      + (chkMainOnly.Checked ? " where [Is_Main] = True" : "")
                      + " order by Flag_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = reader["Flag_Code"].ToString().Trim();
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
            Refresh_All();
        }

        //With Main Only ticked, only purchases whose flag is marked Is_Main count.  A purchase
        //with no flag at all is excluded too, since it belongs to no main portfolio.
        private string Main_Filter()
        {
            if (!chkMainOnly.Checked)
            {
                return "";
            }
            return " and [Flag_Code] In (select Flag_Code from TblETFStocksPurchaseFlag where [Is_Main] = True)";
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
            Refresh_All();
        }

        //Changing portfolio rebuilds the holdings list, so the ticker choice resets to All
        private void Refresh_All()
        {
            Get_Data();
            Fill_Ticker();
            Show_View();
        }

        private void Fill_Ticker()
        {
            Filling = true;
            CmbTicker.Items.Clear();
            CmbTicker.Items.Add("All");
            for (int i = 0; i < SummaryTickers.Count; i++)
            {
                CmbTicker.Items.Add(SummaryTickers[i]);
            }
            CmbTicker.Text = "All";
            Filling = false;
        }

        private void CmbTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_View();
        }

        //All  -> the per-ticker summary and its totals
        //ticker -> the individual purchases behind that one holding
        private void Show_View()
        {
            bool ShowAll = (CmbTicker.Text.Trim() == "" || CmbTicker.Text.Trim() == "All");

            gvSummary.Visible = ShowAll;
            LblTotInvCap.Visible = ShowAll;
            LblTotInv.Visible = ShowAll;
            LblTotCurCap.Visible = ShowAll;
            LblTotCur.Visible = ShowAll;
            LblTotPLCap.Visible = ShowAll;
            LblTotPL.Visible = ShowAll;
            LblTotPctCap.Visible = ShowAll;
            LblTotPct.Visible = ShowAll;

            gvDetail.Visible = !ShowAll;
            LblDTotUnitCap.Visible = !ShowAll;
            LblDTotUnit.Visible = !ShowAll;
            LblDGrandTCBCap.Visible = !ShowAll;
            LblDGrandTCB.Visible = !ShowAll;
            LblDGrandTRCBCap.Visible = !ShowAll;
            LblDGrandTRCB.Visible = !ShowAll;
            LblDTotPLCap.Visible = !ShowAll;
            LblDTotPL.Visible = !ShowAll;
            LblDTotPctCap.Visible = !ShowAll;
            LblDTotPct.Visible = !ShowAll;

            if (!ShowAll)
            {
                Get_Detail(CmbTicker.Text.Trim());
            }
        }

        private void Clear_Grid()
        {
            gvSummary.Rows.Clear();
            gvSummary.Columns.Clear();
            gvSummary.ColumnCount = 8;
            string[] names = new string[] { "Full Ticker", "Total Unit", "Total Investment", "Current Price",
                                            "Total Current Amount", "Current Real Profit/Loss",
                                            "Percentage Current Real Profit/Loss",
                                            "Percentage from whole portfolio" };
            int[] weights = new int[] { 10, 10, 12, 11, 14, 15, 16, 16 };
            for (int i = 0; i < 8; i++)
            {
                gvSummary.Columns[i].Name = names[i];
                gvSummary.Columns[i].FillWeight = weights[i];
                if (i == 0)
                {
                    gvSummary.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    gvSummary.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    gvSummary.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvSummary.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        //AUD and USD are shown with a dollar sign; any other currency stays bare.
        //A negative reads -$12.34 rather than $-12.34.
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
            if (double.TryParse(parValue.ToString(), out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        //Latest price for a ticker, or false when the ticker has never been priced
        private bool Get_Latest_Price(string parFullTicker, out double parPrice)
        {
            parPrice = 0;
            bool Found = false;

            Mdl1.Ssql = "select top 1 [Price] from TblETFStocksPrice where Full_Ticker = '" + parFullTicker
                      + "' order by Price_Date Desc";
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

        //Only unsold holdings count towards a portfolio
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

                string TmpWhere = " where Is_Sold = False";
                if (TmpFlagCode != null)
                {
                    TmpWhere += " and [Flag_Code] = '" + TmpFlagCode + "'";
                }
                TmpWhere += Main_Filter();
                LblNote.Text = "Unsold holdings only"
                    + (TmpFlagCode == null ? "" : "  (flag " + TmpFlagCode + ")")
                    + (chkMainOnly.Checked ? "  (main portfolios only)" : "");

                double TotalInvestment = 0;
                double TotalCurrent = 0;
                double TotalProfit = 0;
                int Unpriced = 0;
                bool AllDollar = true;

                //read the aggregate first, so no reader is open while prices are looked up
                List<string> Tickers = new List<string>();
                List<string> Currs = new List<string>();
                List<double> TotUnits = new List<double>();
                List<double> TotInvs = new List<double>();

                //a ticker is bought in one currency, so Max picks that one value
                Mdl1.Ssql = "select Full_Ticker, Max([Currency]) as Curr, Sum(Unit) as TotUnit, Sum(Real_Total_Cost_Base) as TotInv"
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

                //first pass works out every figure and the portfolio totals
                List<bool> PricedList = new List<bool>();
                List<double> Prices = new List<double>();
                List<double> Currents = new List<double>();
                List<double> Profits = new List<double>();
                List<double> Percents = new List<double>();

                for (int i = 0; i < Tickers.Count; i++)
                {
                    double TmpPrice;
                    bool Priced = Get_Latest_Price(Tickers[i], out TmpPrice);

                    double TmpCurrent = 0;
                    double TmpProfit = 0;
                    double TmpPercent = 0;

                    if (Priced)
                    {
                        TmpCurrent = Math.Round(TotUnits[i] * TmpPrice, 2);
                        TmpProfit = Math.Round(TmpCurrent - TotInvs[i], 2);
                        if (TotInvs[i] > 0)
                        {
                            TmpPercent = (TmpProfit / TotInvs[i]) * 100;
                        }
                        TotalCurrent += TmpCurrent;
                        TotalProfit += TmpProfit;
                    }
                    else
                    {
                        Unpriced++;
                    }

                    TotalInvestment += TotInvs[i];
                    if (!Is_Dollar(Currs[i]))
                    {
                        AllDollar = false;
                    }

                    PricedList.Add(Priced);
                    Prices.Add(TmpPrice);
                    Currents.Add(TmpCurrent);
                    Profits.Add(TmpProfit);
                    Percents.Add(TmpPercent);
                }

                //second pass renders, now that the share of the whole portfolio is known
                for (int i = 0; i < Tickers.Count; i++)
                {
                    string[] row;

                    if (!PricedList[i])
                    {
                        //no price on record - the derived figures are unknown, not zero
                        row = new string[] { Tickers[i], TotUnits[i].ToString("#,##0.0000"),
                                             Money(TotInvs[i], Currs[i]), "-", "-", "-", "-", "-" };
                        gvSummary.Rows.Add(row);
                        continue;
                    }

                    double TmpShare = 0;
                    if (TotalCurrent > 0)
                    {
                        TmpShare = (Currents[i] / TotalCurrent) * 100;
                    }

                    row = new string[] {
                        Tickers[i],
                        TotUnits[i].ToString("#,##0.0000"),
                        Money(TotInvs[i], Currs[i]),
                        Money(Prices[i], Currs[i]),
                        Money(Currents[i], Currs[i]),
                        Money(Profits[i], Currs[i]),
                        Percents[i].ToString("#,##0.00") + " %",
                        TmpShare.ToString("#,##0.00") + " %"
                    };
                    gvSummary.Rows.Add(row);

                    //gain green, loss red, break-even left alone
                    int RowIdx = gvSummary.Rows.Count - 1;
                    Colour_Cell(gvSummary.Rows[RowIdx].Cells[5], Profits[i]);
                    Colour_Cell(gvSummary.Rows[RowIdx].Cells[6], Percents[i]);
                }

                Show_Totals(TotalInvestment, TotalCurrent, TotalProfit, Unpriced,
                            (Tickers.Count > 0 && AllDollar ? "AUD" : ""));

                gvSummary.ClearSelection();

                SummaryTickers.Clear();
                for (int i = 0; i < Tickers.Count; i++)
                {
                    SummaryTickers.Add(Tickers[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Each total is the sum of its own column.  An unpriced holding has a known
        //investment but no current value, so it lifts the investment total only - the
        //note says so, because the three figures then no longer reconcile.
        private void Show_Totals(double parInvestment, double parCurrent, double parProfit, int parUnpriced, string parCurr)
        {
            double TmpPercent = 0;
            if (parInvestment > 0)
            {
                TmpPercent = (parProfit / parInvestment) * 100;
            }

            LblTotInv.Text = Money(parInvestment, parCurr);
            LblTotCur.Text = Money(parCurrent, parCurr);
            LblTotPL.Text = Money(parProfit, parCurr);
            LblTotPct.Text = TmpPercent.ToString("#,##0.00") + " %";

            Colour_Label(LblTotPL, parProfit);
            Colour_Label(LblTotPct, TmpPercent);

            if (parUnpriced > 0)
            {
                LblNote.Text = LblNote.Text + "   -   " + parUnpriced.ToString()
                    + " holding(s) have no price and are excluded from the current amount and profit totals";
            }
        }

        private void Colour_Label(Label parLabel, double parValue)
        {
            if (parValue < 0)
            {
                parLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (parValue > 0)
            {
                parLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                parLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        //yyyyMMdd as stored, shown the way a person reads a date
        private string Format_Date(string parYyyyMMdd)
        {
            DateTime TmpDate;
            if (DateTime.TryParseExact(parYyyyMMdd, "yyyyMMdd", new CultureInfo("en-AU"),
                                       DateTimeStyles.None, out TmpDate))
            {
                return TmpDate.ToString("dd-MMM-yyyy", new CultureInfo("en-AU"));
            }
            return parYyyyMMdd;
        }

        private void Clear_Detail_Grid()
        {
            gvDetail.Rows.Clear();
            gvDetail.Columns.Clear();
            gvDetail.ColumnCount = 8;
            string[] names = new string[] { "Date", "Unit", "Cost Base Per Unit", "Fee",
                                            "Total Cost Base", "Real Total Cost Base",
                                            "Real Current Profit/Loss", "Flag Code" };
            int[] weights = new int[] { 12, 10, 14, 9, 13, 15, 17, 10 };
            for (int i = 0; i < 8; i++)
            {
                gvDetail.Columns[i].Name = names[i];
                gvDetail.Columns[i].FillWeight = weights[i];
                if (i == 0 || i == 7)
                {
                    gvDetail.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    gvDetail.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    gvDetail.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvDetail.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        //Every unsold purchase behind one ticker, under the same portfolio filter
        private void Get_Detail(string parFullTicker)
        {
            try
            {
                Clear_Detail_Grid();

                string TmpFlagCode = null;
                int idx = CmbPortfolio.SelectedIndex;
                if (idx > 0 && idx < FlagCodes.Count)
                {
                    TmpFlagCode = FlagCodes[idx];
                }

                double TmpPrice;
                bool Priced = Get_Latest_Price(parFullTicker, out TmpPrice);

                string TmpWhere = " where Is_Sold = False and Full_Ticker = '" + parFullTicker + "'";
                if (TmpFlagCode != null)
                {
                    TmpWhere += " and [Flag_Code] = '" + TmpFlagCode + "'";
                }
                TmpWhere += Main_Filter();

                LblNote.Text = "Unsold purchases of " + parFullTicker
                    + (TmpFlagCode == null ? "" : "  (flag " + TmpFlagCode + ")")
                    + (chkMainOnly.Checked ? "  (main portfolios only)" : "")
                    + (Priced ? "  -  latest price " + Mdl1.FormatAmt(TmpPrice)
                              : "  -  no price on record, profit/loss unknown");


                double TotUnit = 0;
                double TotCostBase = 0;
                double TotRealCostBase = 0;
                double TotProfit = 0;
                bool AllDollar = true;
                int RowCount = 0;

                Mdl1.Ssql = "select Trans_Date, [Currency], Unit, Cost_Base, Fee, Total_Cost_Base, Real_Total_Cost_Base, [Flag_Code]"
                          + " from TblETFStocksPurchase" + TmpWhere + " order by Trans_Date";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                List<string[]> Rows = new List<string[]>();
                List<double> Profits = new List<double>();
                while (reader.Read())
                {
                    double TmpUnit = Read_Double(reader["Unit"]);
                    double TmpCostBase = Read_Double(reader["Cost_Base"]);
                    double TmpFee = Read_Double(reader["Fee"]);
                    double TmpTotal = Read_Double(reader["Total_Cost_Base"]);
                    double TmpRealTotal = Read_Double(reader["Real_Total_Cost_Base"]);
                    string TmpFlag = (reader["Flag_Code"] == DBNull.Value ? "" : reader["Flag_Code"].ToString().Trim());
                    string TmpCurr = (reader["Currency"] == DBNull.Value ? "" : reader["Currency"].ToString().Trim());
                    if (!Is_Dollar(TmpCurr))
                    {
                        AllDollar = false;
                    }
                    RowCount++;

                    double TmpProfit = 0;
                    string strProfit = "-";
                    if (Priced)
                    {
                        TmpProfit = Math.Round((TmpUnit * TmpPrice) - TmpRealTotal, 2);
                        strProfit = Money(TmpProfit, TmpCurr);
                        TotProfit += TmpProfit;
                    }

                    Rows.Add(new string[] {
                        Format_Date(reader["Trans_Date"].ToString().Trim()),
                        TmpUnit.ToString("#,##0.0000"),
                        Money(TmpCostBase, TmpCurr),
                        Money(TmpFee, TmpCurr),
                        Money(TmpTotal, TmpCurr),
                        Money(TmpRealTotal, TmpCurr),
                        strProfit,
                        TmpFlag });
                    Profits.Add(TmpProfit);

                    TotUnit += TmpUnit;
                    TotCostBase += TmpTotal;
                    TotRealCostBase += TmpRealTotal;
                }
                reader.Close();

                for (int i = 0; i < Rows.Count; i++)
                {
                    gvDetail.Rows.Add(Rows[i]);
                    if (Priced)
                    {
                        Colour_Cell(gvDetail.Rows[gvDetail.Rows.Count - 1].Cells[6], Profits[i]);
                    }
                }
                gvDetail.ClearSelection();

                double TmpPercent = 0;
                if (TotRealCostBase > 0)
                {
                    TmpPercent = (TotProfit / TotRealCostBase) * 100;
                }

                string TmpTotCurr = (RowCount > 0 && AllDollar ? "AUD" : "");

                LblDTotUnit.Text = TotUnit.ToString("#,##0.0000");
                LblDGrandTCB.Text = Money(TotCostBase, TmpTotCurr);
                LblDGrandTRCB.Text = Money(TotRealCostBase, TmpTotCurr);
                if (Priced)
                {
                    LblDTotPL.Text = Money(TotProfit, TmpTotCurr);
                    LblDTotPct.Text = TmpPercent.ToString("#,##0.00") + " %";
                    Colour_Label(LblDTotPL, TotProfit);
                    Colour_Label(LblDTotPct, TmpPercent);
                }
                else
                {
                    LblDTotPL.Text = "-";
                    LblDTotPct.Text = "-";
                    Colour_Label(LblDTotPL, 0);
                    Colour_Label(LblDTotPct, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Colour_Cell(DataGridViewCell parCell, double parValue)
        {
            if (parValue < 0)
            {
                parCell.Style.ForeColor = System.Drawing.Color.Red;
                parCell.Style.SelectionForeColor = System.Drawing.Color.Red;
            }
            else if (parValue > 0)
            {
                parCell.Style.ForeColor = System.Drawing.Color.Green;
                parCell.Style.SelectionForeColor = System.Drawing.Color.Green;
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
