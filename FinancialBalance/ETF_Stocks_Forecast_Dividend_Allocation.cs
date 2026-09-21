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
    public partial class ETF_Stocks_Forecast_Dividend_Allocation : Form
    {
        //One line of what the user has typed in. Nothing is stored: this page asks "if I put
        //this much into these tickers, what would they pay me", which is a question about money
        //not yet invested. It reads TblETFStocks and writes nothing, the way ETF/Stock
        //Investment Plan by Amount and the two calculator pages do.
        private class Entry
        {
            public string Ticker;
            public double Amount;
        }

        //In the order they were entered, so the list keeps a stable order rather than jumping
        //about as amounts are changed.
        List<Entry> Entries = new List<Entry>();

        //Guards the grid while it is being refilled, so the rows being added do not fire the
        //selection handler and type themselves back into the boxes.
        bool Filling;

        public ETF_Stocks_Forecast_Dividend_Allocation()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Forecast_Dividend_Allocation_Load(object sender, EventArgs e)
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

        //Every ticker's yield in one read rather than one per line, and read afresh each time the
        //page is redrawn so a yield changed in ETF/Stock Setup shows here without reopening.
        private Dictionary<string, double> Yields()
        {
            Dictionary<string, double> Result = new Dictionary<string, double>();

            Mdl1.Ssql = "select [Full_Ticker], [Distribution_Dividend_Yield] from TblETFStocks";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpTicker = Read_Text(reader["Full_Ticker"]);
                if (TmpTicker != "" && !Result.ContainsKey(TmpTicker))
                {
                    Result.Add(TmpTicker, Read_Double(reader["Distribution_Dividend_Yield"]));
                }
            }
            reader.Close();
            return Result;
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

        //Add doubles as Update: a ticker can only be in the list once, so naming it again is
        //changing its amount rather than adding a second line for it.
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
        private void gvAlloc_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvAlloc.SelectedRows.Count > 0)
            {
                Row = gvAlloc.SelectedRows[0];
            }
            else
            {
                Row = gvAlloc.CurrentRow;
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
            gvAlloc.Rows.Clear();
            gvAlloc.Columns.Clear();
            gvAlloc.ColumnCount = 5;
            string[] names = new string[] { "Full Ticker", "Investment Amount", "Yield",
                                            "Distribution/Dividend per year",
                                            "Percentage from Whole" };
            //"Distribution/Dividend" is one unbreakable word, so its column carries the widest
            //floor of the five and is given the room to match
            int[] weights = new int[] { 16, 20, 12, 30, 22 };
            for (int i = 0; i < 5; i++)
            {
                gvAlloc.Columns[i].Name = names[i];
                gvAlloc.Columns[i].HeaderText = names[i];
                gvAlloc.Columns[i].FillWeight = weights[i];
                //the ticker reads left, every figure right
                DataGridViewContentAlignment TmpAlign = (i == 0
                    ? DataGridViewContentAlignment.MiddleLeft
                    : DataGridViewContentAlignment.MiddleRight);
                gvAlloc.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvAlloc.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
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

                Dictionary<string, double> TmpYields = Yields();
                double TmpTotal = Total();
                double TmpTotalYear = 0;
                int TmpNoYield = 0;

                foreach (Entry TmpEntry in Entries)
                {
                    double TmpYield = 0;
                    if (TmpYields.ContainsKey(TmpEntry.Ticker))
                    {
                        TmpYield = TmpYields[TmpEntry.Ticker];
                    }
                    if (TmpYield <= 0)
                    {
                        TmpNoYield++;
                    }

                    //The yield is held as a percentage figure - 4.25 means 4.25 % - so it is
                    //divided by a hundred before it multiplies the money, the same way
                    //ETF/Stock Forecast Dividend Calendar reads it.
                    double TmpYear = Math.Round(TmpEntry.Amount * TmpYield / 100, 2);
                    TmpTotalYear += TmpYear;

                    //each amount against the whole, which is what makes the shares comparable
                    //however much money is being talked about
                    double TmpShare = (TmpTotal > 0 ? TmpEntry.Amount / TmpTotal * 100 : 0);

                    gvAlloc.Rows.Add(new string[] {
                        TmpEntry.Ticker,
                        Money(TmpEntry.Amount),
                        Percent(TmpYield),
                        Money(TmpYear),
                        Percent(TmpShare) });
                    //the line's place in the list, so a click can find it again
                    gvAlloc.Rows[gvAlloc.Rows.Count - 1].Tag = gvAlloc.Rows.Count - 1;
                }

                gvAlloc.ClearSelection();
                Filling = false;

                TmpTotalYear = Math.Round(TmpTotalYear, 2);

                LblTotAmount.Text = Money(TmpTotal);
                LblTotYear.Text = Money(TmpTotalYear);
                //a year spread evenly, not what any month will actually pay - when each ticker
                //pays is ETF/Stock Forecast Dividend Calendar's question, not this page's
                LblTotMonth.Text = Money(Math.Round(TmpTotalYear / 12, 2));
                //the whole list's yield, which is the weighted average of the yields above it
                LblYield.Text = Percent(TmpTotal > 0 ? TmpTotalYear / TmpTotal * 100 : 0);

                LblNote.Text = Entries.Count.ToString(CultureInfo.InvariantCulture) + " ticker(s)"
                    + (TmpNoYield > 0
                       ? "   -   " + TmpNoYield.ToString(CultureInfo.InvariantCulture)
                         + " of them have no Distribution/Dividend Yield in ETF/Stock Setup,"
                         + " so they are counted as paying nothing"
                       : "");
            }
            catch (Exception ex)
            {
                Filling = false;
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
