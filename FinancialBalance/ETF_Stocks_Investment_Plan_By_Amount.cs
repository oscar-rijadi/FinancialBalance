using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialBalance
{
    public partial class ETF_Stocks_Investment_Plan_By_Amount : Form
    {
        //One line of what the user has typed in. Nothing is stored: this page asks "if I put
        //these amounts into these tickers, what would the mix look like", which is a question
        //about money not yet invested. It reads TblETFStocks and the diversification tables and
        //writes nothing, the way the two calculator pages do.
        private class Entry
        {
            public string Ticker;
            public double Amount;
        }

        //In the order they were entered, so the list and the slices keep a stable order rather
        //than jumping about as amounts are changed.
        List<Entry> Entries = new List<Entry>();

        //Guards the grid while it is being refilled, so the rows being added do not fire the
        //selection handler and type themselves back into the boxes.
        bool Filling;

        //The three diversification types charted, named as they are in TblETFStocksDivType.
        //The same three the investment plan pages draw.
        static readonly string[] ChartTypes = new string[] { "Asset Class", "Geographic", "Investment Style" };

        public ETF_Stocks_Investment_Plan_By_Amount()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Investment_Plan_By_Amount_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Ticker();
            Filling = false;

            Show_Data();
        }

        //---- the dropdown -----------------------------------------------------------

        private void Fill_Ticker()
        {
            CmbTicker.Items.Clear();
            CmbTicker.Items.Add("");

            Mdl1.Ssql = "select [Full_Ticker] from TblETFStocks order by [Full_Ticker]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbTicker.Items.Add(Read_Text(reader["Full_Ticker"]));
            }
            reader.Close();

            CmbTicker.Text = "";
        }

        //---- reading what comes back ------------------------------------------------

        private string Read_Text(object parValue)
        {
            return (parValue == null || parValue == DBNull.Value ? "" : parValue.ToString().Trim());
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

        //---- formatting -------------------------------------------------------------

        private string Money(double parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
        }

        //---- the entry area ---------------------------------------------------------

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

        private double Amount()
        {
            string TmpText = txtAmount.Text.Trim().Replace("$", "").Replace(",", "");
            double TmpValue;
            if (!double.TryParse(TmpText, NumberStyles.Any, CultureInfo.InvariantCulture, out TmpValue))
            {
                return 0;
            }
            return Math.Round(TmpValue, 2);
        }

        private int At(string parTicker)
        {
            for (int i = 0; i < Entries.Count; i++)
            {
                if (Entries[i].Ticker == parTicker)
                {
                    return i;
                }
            }
            return -1;
        }

        //Add doubles as Update: a ticker can only be in the mix once, so naming it again is
        //changing the amount rather than adding a second line for it.
        private void CmdAdd_Click(object sender, EventArgs e)
        {
            string TmpTicker = CmbTicker.Text.Trim();
            if (TmpTicker == "")
            {
                MessageBox.Show("Please choose a Full Ticker.", "Error Message");
                return;
            }
            double TmpAmount = Amount();
            if (TmpAmount <= 0)
            {
                MessageBox.Show("Investment Amount must be more than zero.", "Error Message");
                return;
            }

            int TmpAt = At(TmpTicker);
            if (TmpAt >= 0)
            {
                Entries[TmpAt].Amount = TmpAmount;
            }
            else
            {
                Entry TmpEntry = new Entry();
                TmpEntry.Ticker = TmpTicker;
                TmpEntry.Amount = TmpAmount;
                Entries.Add(TmpEntry);
            }

            CmbTicker.Text = "";
            txtAmount.Text = "";
            Show_Data();
        }

        private void CmdDel_Click(object sender, EventArgs e)
        {
            string TmpTicker = CmbTicker.Text.Trim();
            int TmpAt = At(TmpTicker);
            if (TmpAt < 0)
            {
                MessageBox.Show("Please pick a line from the list first !", "Error Message");
                return;
            }
            Entries.RemoveAt(TmpAt);
            CmbTicker.Text = "";
            txtAmount.Text = "";
            Show_Data();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            if (Entries.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Clear every line ?", "Confirmation",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Entries.Clear();
            CmbTicker.Text = "";
            txtAmount.Text = "";
            Show_Data();
        }

        //Clicking a line copies it back into the boxes, so an amount can be corrected or the
        //line removed without the ticker having to be found in the dropdown again.
        private void gvAmount_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvAmount.SelectedRows.Count > 0)
            {
                Row = gvAmount.SelectedRows[0];
            }
            else
            {
                Row = gvAmount.CurrentRow;
            }
            if (Row == null || Row.Tag == null)
            {
                return;
            }
            int TmpAt = (int)Row.Tag;
            if (TmpAt < 0 || TmpAt >= Entries.Count)
            {
                return;
            }
            CmbTicker.Text = Entries[TmpAt].Ticker;
            txtAmount.Text = Entries[TmpAt].Amount.ToString("0.00", CultureInfo.InvariantCulture);
        }

        //---- the list ---------------------------------------------------------------

        private void Clear_Grid()
        {
            gvAmount.Rows.Clear();
            gvAmount.Columns.Clear();
            gvAmount.ColumnCount = 3;
            string[] names = new string[] { "Full Ticker", "Investment Amount", "Allocation" };
            int[] weights = new int[] { 34, 33, 33 };
            for (int i = 0; i < 3; i++)
            {
                gvAmount.Columns[i].Name = names[i];
                gvAmount.Columns[i].HeaderText = names[i];
                gvAmount.Columns[i].FillWeight = weights[i];
                //the ticker reads left, the two figures right
                DataGridViewContentAlignment TmpAlign = (i == 0
                    ? DataGridViewContentAlignment.MiddleLeft
                    : DataGridViewContentAlignment.MiddleRight);
                gvAmount.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvAmount.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private double Total()
        {
            double TmpTotal = 0;
            foreach (Entry TmpEntry in Entries)
            {
                TmpTotal += TmpEntry.Amount;
            }
            return Math.Round(TmpTotal, 2);
        }

        //Everything on the page comes from the list, so it is all redrawn together rather than
        //each part being kept in step separately.
        private void Show_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                double TmpTotal = Total();
                foreach (Entry TmpEntry in Entries)
                {
                    //each amount against the whole, which is what makes the shares comparable
                    //however much money is being talked about
                    double TmpShare = (TmpTotal > 0 ? TmpEntry.Amount / TmpTotal * 100 : 0);
                    gvAmount.Rows.Add(new string[] {
                        TmpEntry.Ticker,
                        Money(TmpEntry.Amount),
                        Percent(TmpShare) });
                    //the line's place in the list, so a click can find it again
                    gvAmount.Rows[gvAmount.Rows.Count - 1].Tag = gvAmount.Rows.Count - 1;
                }

                gvAmount.ClearSelection();
                Filling = false;

                LblTotal.Text = Money(TmpTotal);
                LblNote.Text = Entries.Count.ToString(CultureInfo.InvariantCulture) + " ticker(s)";
                Show_Chart();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the diversification charts ---------------------------------------------
        //
        //The same three pies the investment plan pages draw, by the same calculation: each
        //ticker's share of the money is split across that type's values in the proportions
        //recorded against the ticker, and the contributions are summed per name.
        //
        //    contribution = (Percentage / 100) * Allocation
        //
        //The difference from ETF/Stock Investment Plan is only where the allocations come from.
        //There they are read from a stored plan and have to total 100 before anything is drawn;
        //here they are worked out from the amounts typed in, so they total 100 by construction
        //and the charts appear as soon as there is any money in the list.

        private Dictionary<string, Dictionary<string, List<KeyValuePair<string, double>>>> Read_Diversification()
        {
            Dictionary<string, Dictionary<string, List<KeyValuePair<string, double>>>> ByType =
                new Dictionary<string, Dictionary<string, List<KeyValuePair<string, double>>>>();
            foreach (string TmpType in ChartTypes)
            {
                ByType.Add(TmpType, new Dictionary<string, List<KeyValuePair<string, double>>>());
            }

            Mdl1.Ssql = "select [Full_Ticker], [Diversification_Type], [Diversification_Name], [Percentage]"
                      + " from TblETFStocksDiversificationAllocation"
                      + " order by [Full_Ticker], [Diversification_Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpTicker = Read_Text(reader["Full_Ticker"]);
                string TmpType = Read_Text(reader["Diversification_Type"]);
                //a type nothing is charted for is read past rather than kept
                if (TmpTicker == "" || !ByType.ContainsKey(TmpType))
                {
                    continue;
                }
                Dictionary<string, List<KeyValuePair<string, double>>> ByTicker = ByType[TmpType];
                if (!ByTicker.ContainsKey(TmpTicker))
                {
                    ByTicker.Add(TmpTicker, new List<KeyValuePair<string, double>>());
                }
                ByTicker[TmpTicker].Add(new KeyValuePair<string, double>(
                    Read_Text(reader["Diversification_Name"]), Read_Double(reader["Percentage"])));
            }
            reader.Close();
            return ByType;
        }

        //What is in the list, as percentages of the whole - the same shape the plan pages hand
        //to the slice calculation.
        private List<KeyValuePair<string, double>> Allocations()
        {
            List<KeyValuePair<string, double>> Rows = new List<KeyValuePair<string, double>>();
            double TmpTotal = Total();
            if (TmpTotal <= 0)
            {
                return Rows;
            }
            foreach (Entry TmpEntry in Entries)
            {
                Rows.Add(new KeyValuePair<string, double>(
                    TmpEntry.Ticker, TmpEntry.Amount / TmpTotal * 100));
            }
            return Rows;
        }

        //Names come back in the order they were first met, so the slices keep a stable order
        //rather than jumping about between refreshes.
        private void Slices_For(Dictionary<string, List<KeyValuePair<string, double>>> parByTicker,
                                List<KeyValuePair<string, double>> parAllocations,
                                out List<string> parNames, out List<double> parValues)
        {
            parNames = new List<string>();
            parValues = new List<double>();

            List<string> Order = new List<string>();
            Dictionary<string, double> Totals = new Dictionary<string, double>();
            double Covered = 0;

            foreach (KeyValuePair<string, double> Alloc in parAllocations)
            {
                if (!parByTicker.ContainsKey(Alloc.Key))
                {
                    continue;
                }
                foreach (KeyValuePair<string, double> Div in parByTicker[Alloc.Key])
                {
                    double Share = Div.Value / 100 * Alloc.Value;
                    if (!Totals.ContainsKey(Div.Key))
                    {
                        Totals.Add(Div.Key, 0);
                        Order.Add(Div.Key);
                    }
                    Totals[Div.Key] = Totals[Div.Key] + Share;
                    Covered = Covered + Share;
                }
            }

            foreach (string Name in Order)
            {
                parNames.Add(Name);
                parValues.Add(Math.Round(Totals[Name], 2));
            }

            //A ticker with no rows of this type, or one whose own percentages do not reach 100,
            //leaves part of the money unaccounted for. Showing that as a slice is what the other
            //diversification pies do - one quietly totalling less than 100 would look complete
            //when it is not.
            double Rest = Math.Round(100 - Covered, 2);
            if (Rest > 0)
            {
                parNames.Add("(unallocated)");
                parValues.Add(Rest);
            }
        }

        private void Show_Chart()
        {
            pnlChart.Controls.Clear();
            bool Wanted = (Entries.Count > 0 && Total() > 0);

            pnlChart.Visible = Wanted;
            LblChartNote.Visible = !Wanted;
            if (!Wanted)
            {
                LblChartNote.Text = "The charts appear once there is an amount against a ticker.";
                return;
            }

            //the table is read once and then reused for all three charts
            Dictionary<string, Dictionary<string, List<KeyValuePair<string, double>>>> ByType =
                Read_Diversification();
            List<KeyValuePair<string, double>> Alloc = Allocations();

            foreach (string TmpType in ChartTypes)
            {
                List<string> Names;
                List<double> Values;
                Slices_For(ByType[TmpType], Alloc, out Names, out Values);
                pnlChart.Controls.Add(Build_Chart(TmpType, Names, Values));
            }
        }

        private Chart Build_Chart(string parTitle, List<string> parNames, List<double> parValues)
        {
            Chart ch = new Chart();
            //three of these stack in a 460-wide column, so they have to clear its vertical
            //scrollbar or the panel grows a horizontal one as well
            ch.Width = 410;
            ch.Height = 300;
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
                pt.ToolTip = parNames[i] + " : " + parValues[i].ToString("#,##0.00") + " % of the money";
                if (parNames[i] == "(unallocated)")
                {
                    pt.Color = System.Drawing.Color.Gainsboro;
                }
            }

            if (se.Points.Count == 0)
            {
                Title none = new Title("nothing allocated");
                none.Font = new System.Drawing.Font("Arial", 9F);
                none.ForeColor = System.Drawing.Color.Gray;
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
