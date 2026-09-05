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
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialBalance
{
    public partial class ETF_Stocks_Price_Chart : Form
    {
        bool Filling;

        //Eight points is as much as the chart can label without the dates running together.
        const int MaxPoints = 8;

        public ETF_Stocks_Price_Chart()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Price_Chart_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Ticker();
            Fill_Financial_Year();
            Filling = false;

            Draw_Chart();
        }

        private void Fill_Ticker()
        {
            CmbTicker.Items.Clear();

            Mdl1.Ssql = "select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbTicker.Items.Add(reader["Full_Ticker"].ToString().Trim());
            }
            reader.Close();

            if (CmbTicker.Items.Count > 0)
            {
                CmbTicker.SelectedIndex = 0;
            }
        }

        //Most recently closed year first, with All in front of it
        private void Fill_Financial_Year()
        {
            CmbFinYear.Items.Clear();
            CmbFinYear.Items.Add("All");

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFinYear.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            CmbFinYear.Text = "All";
        }

        private void CmbTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Draw_Chart();
        }

        private void CmbFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Draw_Chart();
        }

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

        //The chosen year's two dates, or an open range when All is selected
        private bool Year_Range(out string parStart, out string parEnd)
        {
            parStart = "";
            parEnd = "";

            string TmpName = CmbFinYear.Text.Trim();
            if (TmpName == "" || TmpName == "All")
            {
                return false;
            }

            Mdl1.Ssql = "select [Start_Date], [End_Date] from TblFinancialYear where [Name] = '" + TmpName + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = false;
            if (reader.Read())
            {
                parStart = Read_Text(reader["Start_Date"]);
                parEnd = Read_Text(reader["End_Date"]);
                Found = (parStart != "" && parEnd != "");
            }
            reader.Close();
            return Found;
        }

        //X axis labels carry the whole date, as asked
        private string Format_Date(string parYyyyMMdd)
        {
            DateTime TmpDate;
            if (parYyyyMMdd != null && DateTime.TryParseExact(parYyyyMMdd.Trim(), "yyyyMMdd",
                    new CultureInfo("en-AU"), DateTimeStyles.None, out TmpDate))
            {
                return TmpDate.ToString("dd-MMM-yyyy", new CultureInfo("en-AU"));
            }
            return (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
        }

        //Which of the available prices to plot.  The first and the last are always kept - they
        //are the ends of the range being shown - and the rest are taken at even intervals
        //between them, which is what spreads the points as widely as the data allows.
        //
        //Spacing them rather than taking any eight in a row matters: a ticker priced daily for
        //a week and then not again for a year would otherwise chart as one flat week.
        private List<int> Spread(int parCount)
        {
            List<int> Picked = new List<int>();

            if (parCount <= MaxPoints)
            {
                for (int i = 0; i < parCount; i++)
                {
                    Picked.Add(i);
                }
                return Picked;
            }

            for (int i = 0; i < MaxPoints; i++)
            {
                //i / (MaxPoints - 1) walks 0 to 1, so the ends land exactly on first and last
                int idx = (int)Math.Round((double)i * (parCount - 1) / (MaxPoints - 1));
                if (!Picked.Contains(idx))
                {
                    Picked.Add(idx);
                }
            }
            return Picked;
        }

        private void Draw_Chart()
        {
            try
            {
                chartPrice.Series["Price"].Points.Clear();
                chartPrice.Titles["MainTitle"].Text = "";
                LblCurrency.Text = "";
                LblNote.Text = "";

                string TmpTicker = CmbTicker.Text.Trim();
                if (TmpTicker == "")
                {
                    LblNote.Text = "No ticker has been set up yet - see ETF/Stock Setup.";
                    return;
                }

                string TmpStart;
                string TmpEnd;
                bool Windowed = Year_Range(out TmpStart, out TmpEnd);

                //everything on record for this ticker, oldest first, so the ends of the list
                //are the earliest and latest prices of the range being charted
                List<string> Dates = new List<string>();
                List<double> Prices = new List<double>();
                List<string> Currencies = new List<string>();

                Mdl1.Ssql = "select Price_Date, [Price], [Currency] from TblETFStocksPrice"
                          + " where Full_Ticker = '" + TmpTicker + "'"
                          + (Windowed ? " and Price_Date >= '" + TmpStart + "' and Price_Date <= '" + TmpEnd + "'" : "")
                          + " order by Price_Date";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dates.Add(Read_Text(reader["Price_Date"]));
                    Prices.Add(Read_Double(reader["Price"]));
                    Currencies.Add(Read_Text(reader["Currency"]));
                }
                reader.Close();

                if (Dates.Count == 0)
                {
                    LblNote.Text = "No price has been recorded for " + TmpTicker
                                 + (Windowed ? " in " + CmbFinYear.Text.Trim() : "") + ".";
                    return;
                }

                //the currency of the first price, as asked
                LblCurrency.Text = (Currencies[0] == "" ? "" : "Currency : " + Currencies[0]);

                List<int> Picked = Spread(Dates.Count);
                for (int i = 0; i < Picked.Count; i++)
                {
                    int idx = Picked[i];
                    int pt = chartPrice.Series["Price"].Points.AddXY(Format_Date(Dates[idx]), Prices[idx]);
                    chartPrice.Series["Price"].Points[pt].ToolTip = Format_Date(Dates[idx]) + " : " + Mdl1.FormatAmt(Prices[idx]);
                }

                chartPrice.Titles["MainTitle"].Text = TmpTicker
                    + (Windowed ? "   -   " + CmbFinYear.Text.Trim() : "   -   all prices on record");
                chartPrice.ChartAreas["ChartArea1"].AxisY.Title = "Price"
                    + (Currencies[0] == "" ? "" : " (" + Currencies[0] + ")");
                chartPrice.ChartAreas["ChartArea1"].AxisX.Title = "Date";

                LblNote.Text = Picked.Count.ToString() + " of " + Dates.Count.ToString() + " price(s) plotted, "
                             + Format_Date(Dates[0]) + " to " + Format_Date(Dates[Dates.Count - 1])
                             + (Dates.Count > MaxPoints ? "   -   spread evenly across the range" : "");
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
