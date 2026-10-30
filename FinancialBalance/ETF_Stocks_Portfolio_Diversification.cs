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

        //Latest price for a ticker, or false when the ticker has never been priced.  The
        //currency comes back with it: a price is only a number until you know what it is
        //quoted in, and this page adds prices together.
        private bool Get_Latest_Price(string parFullTicker, out double parPrice, out string parCurr)
        {
            parPrice = 0;
            parCurr = "";
            bool Found = false;

            Mdl1.Ssql = "select top 1 [Price], [Currency] from TblETFStocksPrice where Full_Ticker = '" + parFullTicker
                      + "' order by Price_Date Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                parPrice = Read_Double(reader["Price"]);
                parCurr = (reader["Currency"] == DBNull.Value ? "" : reader["Currency"].ToString().Trim());
                Found = true;
            }
            reader.Close();
            return Found;
        }

        //---- into Australian Dollar -------------------------------------------------
        //
        //Every share on this page is one holding's value over the whole portfolio's, so the
        //values have to be in one currency before they are added.  They were not: a price was
        //taken at face value whatever it was quoted in, so a US holding counted its dollars as
        //though they were Australian ones and took a larger slice than it owns.
        //
        //TblCurrRate holds IDR per one unit of a currency, so a figure reaches AUD by way of
        //the rupiah, which is the pivot the whole application converts through:
        //
        //    AUD = amount x rate(currency) / rate(AUD)
        //
        //This is the same arithmetic, and the same month's rate, that ETF/Stock Portfolio
        //Summary uses - which matters, because that page's Total Current Amount is what these
        //shares are shares OF.  Had the two converted differently the percentages here would
        //not have matched the amounts there.
        private const string PageCurr = "AUD";

        //One rate per currency for the length of a refresh, rather than three queries per row.
        private Dictionary<string, double> RateCache = new Dictionary<string, double>();
        private Dictionary<string, bool> RateKnown = new Dictionary<string, bool>();
        private List<string> NoRate = new List<string>();
        private string RateMonth = "";

        //Every rate a refresh could want, read before a single row of data is.  The page
        //converts inside its read loops, and a second reader on the shared connection while
        //the first is still live is the one thing this connection will not stand.
        private void Begin_Rates()
        {
            RateCache.Clear();
            RateKnown.Clear();
            NoRate.Clear();
            RateMonth = DateTime.Now.ToString("yyyyMM");

            List<string> Codes = new List<string>();
            Codes.Add(PageCurr);
            Mdl1.Ssql = "select Curr_Code from TblCurrCode order by Curr_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = (reader["Curr_Code"] == DBNull.Value ? "" : reader["Curr_Code"].ToString().Trim().ToUpper());
                if (TmpCode != "" && !Codes.Contains(TmpCode))
                {
                    Codes.Add(TmpCode);
                }
            }
            reader.Close();

            for (int i = 0; i < Codes.Count; i++)
            {
                Load_Rate(Codes[i]);
            }
        }

        //GetCurrRate answers 1 for a currency it has never heard of, which would leave a figure
        //unconverted while looking exactly like one that needed no converting; asking the table
        //directly is what tells those two apart.
        private void Load_Rate(string parCurr)
        {
            if (RateCache.ContainsKey(parCurr))
            {
                return;
            }
            if (parCurr == "IDR")
            {
                //the pivot itself - one rupiah to the rupiah, and never a row to read
                RateCache[parCurr] = 1;
                RateKnown[parCurr] = true;
                return;
            }

            bool Known = Has_Rate(parCurr);
            double TmpRate = (Known ? Mdl1.GetCurrRate(parCurr, RateMonth) : 1);
            RateCache[parCurr] = (TmpRate <= 0 ? 1 : TmpRate);
            RateKnown[parCurr] = Known;
        }

        private bool Has_Rate(string parCurr)
        {
            bool Found = false;
            Mdl1.Ssql = "select top 1 Curr_Date from TblCurrRate where Curr_Code = '" + parCurr + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Found = reader.Read();
            reader.Close();
            return Found;
        }

        //Nothing here reads the database: every rate it can answer with was loaded before the
        //read loops opened.
        private double Rate_Of(string parCurr)
        {
            string strCurr = (parCurr == null ? "" : parCurr.Trim().ToUpper());
            if (strCurr == "")
            {
                strCurr = PageCurr;
            }

            if (RateCache.ContainsKey(strCurr))
            {
                if (!RateKnown[strCurr] && !NoRate.Contains(strCurr))
                {
                    NoRate.Add(strCurr);
                }
                return RateCache[strCurr];
            }

            //a currency on a price but not in Currency Setup, so there can be no rate for it either
            if (!NoRate.Contains(strCurr))
            {
                NoRate.Add(strCurr);
            }
            return 1;
        }

        private double To_AUD(double parAmount, string parCurr)
        {
            string strCurr = (parCurr == null ? "" : parCurr.Trim().ToUpper());
            //nothing said is taken as already being in AUD, which is what an empty Currency has
            //always meant on the purchase pages
            if (strCurr == "" || strCurr == PageCurr)
            {
                return parAmount;
            }
            return parAmount * Rate_Of(strCurr) / Rate_Of(PageCurr);
        }

        //any currency a price was quoted in that could not be converted
        private string Rate_Note()
        {
            if (NoRate.Count == 0)
            {
                return "";
            }
            return "   -   no currency rate on record for "
                 + String.Join(", ", NoRate.ToArray())
                 + ", counted unconverted";
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
        //current amount over total current amount, every amount in AUD.  An unpriced holding
        //has no share.
        private void Portfolio_Shares(out List<string> parTickers, out List<double> parShares)
        {
            parTickers = new List<string>();
            parShares = new List<double>();

            //before any reader is opened, because converting happens inside one
            Begin_Rates();

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

            LblNote.Text = "Unsold holdings only, valued in Australian Dollar"
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
                double TmpRawPrice;
                string TmpPriceCurr;
                double TmpCurrent = 0;
                if (Get_Latest_Price(Names[i], out TmpRawPrice, out TmpPriceCurr))
                {
                    //to four places before the units are applied, the way the summary page does it,
                    //so the two pages put the same figure against the same holding
                    double TmpPrice = Math.Round(To_AUD(TmpRawPrice, TmpPriceCurr), 4);
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

            //said once every price has been looked at, so only a currency actually used is named
            LblNote.Text = LblNote.Text + Rate_Note();
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
