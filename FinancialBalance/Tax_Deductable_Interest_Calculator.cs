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
    public partial class Tax_Deductable_Interest_Calculator : Form
    {
        //One band of the interest: the share of it taxed, and the rate it is taxed at. Interest
        //is rarely all taxed alike - part of it can fall in one bracket and part in the next, or
        //part be held in one name and part in another - so the page takes a list of bands rather
        //than a single rate.
        //
        //Everything here is a percentage.  The page turns an interest rate on paper into the
        //rate left after tax; what those rates are worth in money depends on the balance behind
        //them, which this page does not ask for and cannot know.
        private class Band
        {
            public double Rate;
            public double Allocation;
        }

        //In the order they were entered, so the list keeps a stable order rather than jumping
        //about as allocations are changed.
        List<Band> Bands = new List<Band>();

        //Guards the grid while it is being refilled, so the rows being added do not fire the
        //selection handler and type themselves back into the boxes.
        bool Filling;

        public Tax_Deductable_Interest_Calculator()
        {
            InitializeComponent();
        }

        private void Tax_Deductable_Interest_Calculator_Load(object sender, EventArgs e)
        {
            Load_Bands();
            Show_Data();
        }

        //The bands as Tax Allocation Setup holds them.  Read on the way in rather than
        //asked for line by line, so the page opens on the real split instead of on an
        //empty list that has to be retyped every time.
        //
        //Nothing here is written back.  The list can still be added to, changed and
        //cleared, because trying something is what a calculator is for - but the stored
        //bands are only ever read, and Tax Allocation Setup stays the one place they are
        //kept.  Reload puts them back after a what-if.
        private void Load_Bands()
        {
            try
            {
                Bands.Clear();

                Mdl1.Ssql = "select [Tax_Rate], [Allocation] from TblTaxAllocation"
                          + " order by [Tax_Rate]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Band TmpBand = new Band();
                    TmpBand.Rate = Math.Round(Read_Stored(reader["Tax_Rate"]), 2);
                    TmpBand.Allocation = Math.Round(Read_Stored(reader["Allocation"]), 2);
                    Bands.Add(TmpBand);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private double Read_Stored(object parValue)
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

        //Back to what is on file, which is the way out of a what-if that went nowhere.
        private void CmdReload_Click(object sender, EventArgs e)
        {
            Load_Bands();
            txtTax.Text = "";
            txtAlloc.Text = "";
            Show_Data();
        }

        //---- reading what was typed -------------------------------------------------

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

        private double Read_Box(TextBox parBox, int parDecimals)
        {
            string TmpText = parBox.Text.Trim().Replace(",", "").Replace("%", "");
            double TmpValue;
            if (!double.TryParse(TmpText, NumberStyles.Any, CultureInfo.InvariantCulture, out TmpValue))
            {
                return 0;
            }
            return Math.Round(TmpValue, parDecimals);
        }

        //kept to four places because it is the figure every other one is worked out from
        private double On_Paper()
        {
            return Read_Box(txtOnPaper, 4);
        }

        //---- formatting -------------------------------------------------------------

        //Two places for what was typed, which is how it will be read back.
        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
        }

        //Four for anything worked out, because each of these is a rate multiplied by two more
        //rates and two places would throw away most of what is left.  A 5.50 % rate with 15 % of
        //it taxed at 32.5 % gives 0.2681 %, which two places would round to 0.27 and a list of
        //bands would then fail to add up.
        private string Rate(double parValue)
        {
            return parValue.ToString("#,##0.0000", CultureInfo.InvariantCulture) + " %";
        }

        //---- the list ---------------------------------------------------------------

        private int At(double parRate)
        {
            for (int i = 0; i < Bands.Count; i++)
            {
                if (Bands[i].Rate == parRate)
                {
                    return i;
                }
            }
            return -1;
        }

        //Everything allocated so far, optionally ignoring one line - which is what lets a line be
        //changed to a larger share without its own old share counting against it.
        private double Allocated(int parExcept)
        {
            double TmpTotal = 0;
            for (int i = 0; i < Bands.Count; i++)
            {
                if (i != parExcept)
                {
                    TmpTotal += Bands[i].Allocation;
                }
            }
            return Math.Round(TmpTotal, 2);
        }

        //Add doubles as Update: a rate can only be in the list once, so naming it again changes
        //how much of the interest is taxed at it rather than adding a second line for it.
        private void CmdAdd_Click(object sender, EventArgs e)
        {
            double TmpRate = Read_Box(txtTax, 2);
            if (txtTax.Text.Trim() == "" || TmpRate < 0 || TmpRate > 100)
            {
                MessageBox.Show("Tax Percentage must be between 0 and 100.", "Error Message");
                return;
            }

            double TmpAlloc = Read_Box(txtAlloc, 2);
            if (TmpAlloc <= 0 || TmpAlloc > 100)
            {
                MessageBox.Show("Allocation must be more than 0 and at most 100 %.", "Error Message");
                return;
            }

            //The bands divide up one lot of interest, so they cannot come to more than all of it.
            int TmpAt = At(TmpRate);
            double TmpRest = Allocated(TmpAt);
            if (Math.Round(TmpRest + TmpAlloc, 2) > 100)
            {
                MessageBox.Show("That would allocate "
                    + Percent(Math.Round(TmpRest + TmpAlloc, 2))
                    + " in total." + Environment.NewLine
                    + "The allocations cannot come to more than 100 % - there is "
                    + Percent(Math.Round(100 - TmpRest, 2)) + " left to allocate.",
                    "Error Message");
                return;
            }

            if (TmpAt >= 0)
            {
                Bands[TmpAt].Allocation = TmpAlloc;
            }
            else
            {
                Band TmpBand = new Band();
                TmpBand.Rate = TmpRate;
                TmpBand.Allocation = TmpAlloc;
                Bands.Add(TmpBand);
            }

            txtTax.Text = "";
            txtAlloc.Text = "";
            Show_Data();
        }

        private void CmdDel_Click(object sender, EventArgs e)
        {
            if (txtTax.Text.Trim() == "")
            {
                MessageBox.Show("Please pick a line from the list first !", "Error Message");
                return;
            }
            int TmpAt = At(Read_Box(txtTax, 2));
            if (TmpAt < 0)
            {
                MessageBox.Show("Please pick a line from the list first !", "Error Message");
                return;
            }
            Bands.RemoveAt(TmpAt);
            txtTax.Text = "";
            txtAlloc.Text = "";
            Show_Data();
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            if (Bands.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("Clear every line ?", "Confirmation",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            Bands.Clear();
            txtTax.Text = "";
            txtAlloc.Text = "";
            Show_Data();
        }

        //Clicking a line copies it back into the boxes, so an allocation can be corrected or the
        //line removed without the rate having to be retyped exactly.
        private void gvTax_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvTax.SelectedRows.Count > 0)
            {
                Row = gvTax.SelectedRows[0];
            }
            else
            {
                Row = gvTax.CurrentRow;
            }
            if (Row == null || Row.Tag == null)
            {
                return;
            }
            int TmpAt = (int)Row.Tag;
            if (TmpAt < 0 || TmpAt >= Bands.Count)
            {
                return;
            }
            txtTax.Text = Bands[TmpAt].Rate.ToString("0.00", CultureInfo.InvariantCulture);
            txtAlloc.Text = Bands[TmpAt].Allocation.ToString("0.00", CultureInfo.InvariantCulture);
        }

        //The interest is the only thing every figure is a share of, so changing it redraws
        //everything rather than waiting for a button.
        private void txtOnPaper_TextChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Data();
        }

        //---- what it all comes to ---------------------------------------------------

        private void Clear_Grid()
        {
            gvTax.Rows.Clear();
            gvTax.Columns.Clear();
            gvTax.ColumnCount = 4;
            string[] names = new string[] { "Tax Percentage", "Allocation",
                                            "Allocated Interest", "Tax" };
            //every column on this page is a percentage, so none of them is money
            int[] weights = new int[] { 22, 22, 28, 28 };
            for (int i = 0; i < 4; i++)
            {
                gvTax.Columns[i].Name = names[i];
                gvTax.Columns[i].HeaderText = names[i];
                gvTax.Columns[i].FillWeight = weights[i];
                gvTax.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gvTax.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        //Everything on the page comes from the interest and the list, so it is all redrawn
        //together rather than each part being kept in step separately.
        private void Show_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                double TmpOnPaper = On_Paper();
                double TmpTotalAlloc = 0;
                double TmpTotalTax = 0;

                foreach (Band TmpBand in Bands)
                {
                    //the share of the rate this band covers, and what that share is taxed
                    double TmpAllocated = Math.Round(TmpOnPaper * TmpBand.Allocation / 100, 4);
                    double TmpTax = Math.Round(TmpAllocated * TmpBand.Rate / 100, 4);

                    TmpTotalAlloc += TmpBand.Allocation;
                    TmpTotalTax += TmpTax;

                    gvTax.Rows.Add(new string[] {
                        Percent(TmpBand.Rate),
                        Percent(TmpBand.Allocation),
                        Rate(TmpAllocated),
                        Rate(TmpTax) });
                    //the line's place in the list, so a click can find it again
                    gvTax.Rows[gvTax.Rows.Count - 1].Tag = gvTax.Rows.Count - 1;
                }

                gvTax.ClearSelection();
                Filling = false;

                TmpTotalAlloc = Math.Round(TmpTotalAlloc, 2);
                TmpTotalTax = Math.Round(TmpTotalTax, 4);

                LblOnPaper.Text = Rate(TmpOnPaper);
                LblTotAlloc.Text = Percent(TmpTotalAlloc);
                LblTotTax.Text = Rate(TmpTotalTax);
                //what is actually left once every band has taken its share
                LblReal.Text = Rate(Math.Round(TmpOnPaper - TmpTotalTax, 4));

                Show_Note(TmpTotalAlloc);
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Says where the allocation stands, because an unfinished list still produces a Real
        //Interest and it would otherwise look like an answer rather than a part-worked sum.
        private void Show_Note(double parTotalAlloc)
        {
            string TmpText = Bands.Count.ToString(CultureInfo.InvariantCulture) + " band(s)";

            if (parTotalAlloc < 100)
            {
                TmpText = TmpText + "   -   " + Percent(Math.Round(100 - parTotalAlloc, 2))
                    + " of the interest is not allocated to any band and is taxed at nothing,"
                    + " so Real Interest is higher than a fully allocated list would give.";
            }
            else
            {
                TmpText = TmpText + "   -   the whole of the interest is allocated.";
            }
            LblNote.Text = TmpText + Source();
        }

        //Said every time, because the figures are only as good as the bands behind them
        //and neither where they came from nor the fact that they are not being saved is
        //otherwise visible on the page.
        private string Source()
        {
            return "   -   bands from Tax Allocation Setup, not saved here";
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
