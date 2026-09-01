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

        public ETF_Stocks_Portfolio_Summary()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Portfolio_Summary_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Portfolio();
            Filling = false;

            Get_Data();
        }

        //"All" plus one entry per purchase flag, showing its description
        private void Fill_Portfolio()
        {
            CmbPortfolio.Items.Clear();
            FlagCodes.Clear();

            CmbPortfolio.Items.Add("All");
            FlagCodes.Add(null);

            Mdl1.Ssql = "select Flag_Code, [Description] from TblETFStocksPurchaseFlag order by Flag_Code";
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
            Get_Data();
        }

        private void Clear_Grid()
        {
            gvSummary.Rows.Clear();
            gvSummary.Columns.Clear();
            gvSummary.ColumnCount = 7;
            string[] names = new string[] { "Full Ticker", "Total Unit", "Total Investment", "Current Price",
                                            "Total Current Amount", "Current Real Profit/Loss",
                                            "Percentage Current Real Profit/Loss" };
            int[] weights = new int[] { 11, 11, 14, 12, 16, 17, 19 };
            for (int i = 0; i < 7; i++)
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
                LblNote.Text = "Unsold holdings only" + (TmpFlagCode == null ? "" : "  (flag " + TmpFlagCode + ")");

                double TotalInvestment = 0;
                double TotalCurrent = 0;
                double TotalProfit = 0;
                int Unpriced = 0;

                //read the aggregate first, so no reader is open while prices are looked up
                List<string> Tickers = new List<string>();
                List<double> TotUnits = new List<double>();
                List<double> TotInvs = new List<double>();

                Mdl1.Ssql = "select Full_Ticker, Sum(Unit) as TotUnit, Sum(Real_Total_Cost_Base) as TotInv"
                          + " from TblETFStocksPurchase" + TmpWhere
                          + " group by Full_Ticker order by Full_Ticker";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tickers.Add(reader["Full_Ticker"].ToString().Trim());
                    TotUnits.Add(Read_Double(reader["TotUnit"]));
                    TotInvs.Add(Read_Double(reader["TotInv"]));
                }
                reader.Close();

                for (int i = 0; i < Tickers.Count; i++)
                {
                    double TmpPrice;
                    bool Priced = Get_Latest_Price(Tickers[i], out TmpPrice);

                    string[] row;
                    if (!Priced)
                    {
                        //no price on record - the derived figures are unknown, not zero
                        row = new string[] { Tickers[i], TotUnits[i].ToString("#,##0.0000"),
                                             Mdl1.FormatAmt(TotInvs[i]), "-", "-", "-", "-" };
                        gvSummary.Rows.Add(row);
                        TotalInvestment += TotInvs[i];
                        Unpriced++;
                        continue;
                    }

                    double TmpCurrent = Math.Round(TotUnits[i] * TmpPrice, 2);
                    double TmpProfit = Math.Round(TmpCurrent - TotInvs[i], 2);
                    double TmpPercent = 0;
                    if (TotInvs[i] > 0)
                    {
                        TmpPercent = (TmpProfit / TotInvs[i]) * 100;
                    }

                    row = new string[] {
                        Tickers[i],
                        TotUnits[i].ToString("#,##0.0000"),
                        Mdl1.FormatAmt(TotInvs[i]),
                        Mdl1.FormatAmt(TmpPrice),
                        Mdl1.FormatAmt(TmpCurrent),
                        Mdl1.FormatAmt(TmpProfit),
                        TmpPercent.ToString("#,##0.00") + " %"
                    };
                    gvSummary.Rows.Add(row);

                    //gain green, loss red, break-even left alone
                    int RowIdx = gvSummary.Rows.Count - 1;
                    Colour_Cell(gvSummary.Rows[RowIdx].Cells[5], TmpProfit);
                    Colour_Cell(gvSummary.Rows[RowIdx].Cells[6], TmpPercent);

                    TotalInvestment += TotInvs[i];
                    TotalCurrent += TmpCurrent;
                    TotalProfit += TmpProfit;
                }

                Show_Totals(TotalInvestment, TotalCurrent, TotalProfit, Unpriced);

                gvSummary.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Each total is the sum of its own column.  An unpriced holding has a known
        //investment but no current value, so it lifts the investment total only - the
        //note says so, because the three figures then no longer reconcile.
        private void Show_Totals(double parInvestment, double parCurrent, double parProfit, int parUnpriced)
        {
            double TmpPercent = 0;
            if (parInvestment > 0)
            {
                TmpPercent = (parProfit / parInvestment) * 100;
            }

            LblTotInv.Text = Mdl1.FormatAmt(parInvestment);
            LblTotCur.Text = Mdl1.FormatAmt(parCurrent);
            LblTotPL.Text = Mdl1.FormatAmt(parProfit);
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
