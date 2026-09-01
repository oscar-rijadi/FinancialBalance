using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialBalance
{
    public partial class ETF_Stocks_Portfolio_Diversification : Form
    {
        bool Filling;

        //Index-aligned with CmbPortfolio: entry 0 is "All" and carries no code.
        //Held as a list rather than looked up by description, because descriptions
        //are not unique in TblETFStocksPortfolioCode.
        List<string> PortfolioCodes = new List<string>();

        public ETF_Stocks_Portfolio_Diversification()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Portfolio_Diversification_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Portfolio();
            Filling = false;

            Get_Data();
        }

        //"All" plus one entry per portfolio code, showing its description
        private void Fill_Portfolio()
        {
            CmbPortfolio.Items.Clear();
            PortfolioCodes.Clear();

            CmbPortfolio.Items.Add("All");
            PortfolioCodes.Add(null);

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
                PortfolioCodes.Add(TmpCode);
            }
            reader.Close();

            CmbPortfolio.Text = "All";
        }

        //With Main Only ticked, only purchases whose code is marked Is_Main count.  A purchase
        //with no code at all is excluded too, since it belongs to no main portfolio.
        private string Main_Filter()
        {
            if (!chkMainOnly.Checked)
            {
                return "";
            }
            return " and [Portfolio_Code] In (select Portfolio_Code from TblETFStocksPortfolioCode where [Is_Main] = True)";
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
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

        private void Clear_Charts()
        {
            while (pnlCharts.Controls.Count > 0)
            {
                Control c = pnlCharts.Controls[0];
                pnlCharts.Controls.Remove(c);
                c.Dispose();
            }
        }

        //Each ticker's share of the whole portfolio, exactly as the summary page derives it:
        //current amount over total current amount.  An unpriced holding has no share.
        private void Portfolio_Shares(out List<string> parTickers, out List<double> parShares)
        {
            parTickers = new List<string>();
            parShares = new List<double>();

            string TmpCode = null;
            int idx = CmbPortfolio.SelectedIndex;
            if (idx > 0 && idx < PortfolioCodes.Count)
            {
                TmpCode = PortfolioCodes[idx];
            }

            string TmpWhere = " where Is_Sold = False";
            if (TmpCode != null)
            {
                TmpWhere += " and [Portfolio_Code] = '" + TmpCode + "'";
            }
            TmpWhere += Main_Filter();

            LblNote.Text = "Unsold holdings only"
                + (TmpCode == null ? "" : "  (portfolio " + TmpCode + ")")
                + (chkMainOnly.Checked ? "  (main portfolios only)" : "");

            List<string> Names = new List<string>();
            List<double> Units = new List<double>();
            Mdl1.Ssql = "select Full_Ticker, Sum(Unit) as TotUnit from TblETFStocksPurchase"
                      + TmpWhere + " group by Full_Ticker order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Names.Add(reader["Full_Ticker"].ToString().Trim());
                Units.Add(Read_Double(reader["TotUnit"]));
            }
            reader.Close();

            //first pass for the portfolio total, second for each share
            List<double> Currents = new List<double>();
            double TotalCurrent = 0;
            for (int i = 0; i < Names.Count; i++)
            {
                double TmpPrice;
                double TmpCurrent = 0;
                if (Get_Latest_Price(Names[i], out TmpPrice))
                {
                    TmpCurrent = Math.Round(Units[i] * TmpPrice, 2);
                    TotalCurrent += TmpCurrent;
                }
                Currents.Add(TmpCurrent);
            }

            if (TotalCurrent <= 0)
            {
                return;
            }

            for (int i = 0; i < Names.Count; i++)
            {
                if (Currents[i] <= 0)
                {
                    continue;
                }
                parTickers.Add(Names[i]);
                parShares.Add((Currents[i] / TotalCurrent) * 100);
            }
        }

        //A ticker's share, split by its allocation for one diversification type.
        //share x allocation / 100, summed across every ticker in the portfolio.
        private void Get_Data()
        {
            try
            {
                Clear_Charts();

                List<string> Tickers;
                List<double> Shares;
                Portfolio_Shares(out Tickers, out Shares);

                if (Tickers.Count == 0)
                {
                    LblNote.Text = LblNote.Text + "   -   nothing to chart";
                    return;
                }

                List<string> Types = new List<string>();
                Mdl1.Ssql = "select [Name] from TblETFStocksDiversificationType order by [Name]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Types.Add(reader["Name"].ToString().Trim());
                }
                reader.Close();

                for (int t = 0; t < Types.Count; t++)
                {
                    List<string> SliceNames = new List<string>();
                    List<double> SliceValues = new List<double>();

                    for (int i = 0; i < Tickers.Count; i++)
                    {
                        Mdl1.Ssql = "select [Diversification_Name], [Percentage] from TblETFStocksDiversificationAllocation"
                                  + " where [Full_Ticker] = '" + Tickers[i] + "'"
                                  + " and [Diversification_Type] = '" + Types[t] + "'";
                        OleDbCommand c2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        OleDbDataReader r2 = c2.ExecuteReader();
                        List<string> Ns = new List<string>();
                        List<double> Ps = new List<double>();
                        while (r2.Read())
                        {
                            Ns.Add(r2["Diversification_Name"].ToString().Trim());
                            Ps.Add(Read_Double(r2["Percentage"]));
                        }
                        r2.Close();

                        for (int k = 0; k < Ns.Count; k++)
                        {
                            double TmpVal = (Shares[i] * Ps[k]) / 100;
                            int at = SliceNames.IndexOf(Ns[k]);
                            if (at < 0)
                            {
                                SliceNames.Add(Ns[k]);
                                SliceValues.Add(TmpVal);
                            }
                            else
                            {
                                SliceValues[at] = SliceValues[at] + TmpVal;
                            }
                        }
                    }

                    //whatever is not allocated is shown rather than left to inflate the rest
                    double TmpTotal = 0;
                    for (int k = 0; k < SliceValues.Count; k++)
                    {
                        TmpTotal += SliceValues[k];
                    }
                    if (TmpTotal < 99.995)
                    {
                        SliceNames.Add("(unallocated)");
                        SliceValues.Add(100 - TmpTotal);
                    }

                    pnlCharts.Controls.Add(Build_Chart(Types[t], SliceNames, SliceValues));
                }

                if (Types.Count == 0)
                {
                    LblNote.Text = LblNote.Text + "   -   no diversification type is set up";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private Chart Build_Chart(string parTitle, List<string> parNames, List<double> parValues)
        {
            Chart ch = new Chart();
            ch.Width = 440;
            ch.Height = 320;
            ch.Margin = new Padding(8);
            ch.BackColor = System.Drawing.Color.Transparent;

            ChartArea ca = new ChartArea("ChartArea1");
            ca.BackColor = System.Drawing.Color.Transparent;
            ch.ChartAreas.Add(ca);

            Title ti = new Title(parTitle);
            ti.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            ti.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            ch.Titles.Add(ti);

            Legend le = new Legend("Legend1");
            le.Docking = Docking.Bottom;
            le.Font = new System.Drawing.Font("Arial", 8F);
            ch.Legends.Add(le);

            Series se = new Series("Allocation");
            se.ChartType = SeriesChartType.Pie;
            se.Legend = "Legend1";
            se.Font = new System.Drawing.Font("Arial", 8F);
            ch.Series.Add(se);

            for (int i = 0; i < parNames.Count; i++)
            {
                if (parValues[i] <= 0)
                {
                    continue;
                }
                int idx = se.Points.AddXY(parNames[i], Math.Round(parValues[i], 2));
                DataPoint pt = se.Points[idx];
                pt.LegendText = parNames[i] + "  " + parValues[i].ToString("#,##0.00") + " %";
                pt.Label = parValues[i].ToString("#,##0.0") + " %";
                pt.ToolTip = parNames[i] + " : " + parValues[i].ToString("#,##0.00") + " % of the portfolio";
                if (parNames[i] == "(unallocated)")
                {
                    pt.Color = System.Drawing.Color.Gainsboro;
                }
            }

            if (se.Points.Count == 0)
            {
                Title none = new Title("nothing allocated");
                none.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic);
                none.ForeColor = System.Drawing.Color.DimGray;
                none.Docking = Docking.Bottom;
                ch.Titles.Add(none);
            }

            return ch;
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
