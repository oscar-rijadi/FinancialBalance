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
    public partial class Before_Tax_Interest_Calculator : Form
    {
        //One band of the interest: the share of it taxed, and the rate it is taxed at.  The same
        //band Tax Deductable Interest Calculator takes, because this is the same question asked
        //from the other end - that page starts with the rate on paper and works out what is left,
        //this one starts with what is left and works out the rate on paper.
        //
        //Everything here is a percentage.  What these rates are worth in money depends on the
        //balance behind them, which this page does not ask for and cannot know.
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

        public Before_Tax_Interest_Calculator()
        {
            InitializeComponent();
        }

        private void Before_Tax_Interest_Calculator_Load(object sender, EventArgs e)
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

        //kept to four places because it is the figure the answer is worked out from
        private double After_Tax()
        {
            return Read_Box(txtAfterTax, 4);
        }

        //---- formatting -------------------------------------------------------------

        //Two places for what was typed, which is how it will be read back.
        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
        }

        //Four for anything worked out, because each of these is a rate multiplied by two more
        //rates and two places would throw away most of what is left.
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

        //The rate left after tax is the only thing every figure is worked back from, so changing
        //it redraws everything rather than waiting for a button.
        private void txtAfterTax_TextChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Data();
        }

        //---- working backwards ------------------------------------------------------

        //The share of the whole rate that tax takes, as a fraction.  Each band takes its
        //allocation of the rate and is taxed at its own percentage, so what the bands take
        //together does not depend on the rate at all - which is what makes the sum invertible.
        //
        //    after  =  before - sum(before x allocation x rate)
        //           =  before x (1 - K)          where K = sum(allocation x rate)
        //
        //so  before = after / (1 - K).
        private double Taken()
        {
            double TmpTaken = 0;
            foreach (Band TmpBand in Bands)
            {
                TmpTaken += (TmpBand.Allocation / 100) * (TmpBand.Rate / 100);
            }
            return TmpTaken;
        }

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

        //Everything on the page comes from the rate after tax and the list, so it is all redrawn
        //together rather than each part being kept in step separately.
        private void Show_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                double TmpAfter = After_Tax();
                double TmpTaken = Taken();

                //Everything taxed away at a hundred per cent leaves nothing, whatever the rate
                //before tax was - so there is no rate this page could name, and it says so rather
                //than dividing by zero.
                bool Possible = (TmpTaken < 1);

                //Rounded here, once, and every band worked off the rounded figure - so the
                //Allocated Interest column adds to exactly the Before Tax Interest shown
                //beneath it.  Carrying full precision into the bands instead left the column
                //summing to 5.5000 against an answer of 5.4999, which is the sort of thing
                //that gets read as a bug in the page rather than as rounding.
                //
                //The cost is at the other end : taking the tax back off the answer can land
                //a ten-thousandth away from the rate that was typed in.  That is unavoidable
                //once a rate is shown to four places at all, and it is the less visible of
                //the two - it takes a subtraction to notice, where a column that does not add
                //up is there on the face of it.
                double TmpBefore = (Possible ? Math.Round(TmpAfter / (1 - TmpTaken), 4) : 0);

                double TmpTotalAlloc = 0;
                double TmpTotalTax = 0;

                foreach (Band TmpBand in Bands)
                {
                    double TmpAllocated = (Possible
                        ? Math.Round(TmpBefore * TmpBand.Allocation / 100, 4) : 0);
                    double TmpTax = (Possible
                        ? Math.Round(TmpAllocated * TmpBand.Rate / 100, 4) : 0);

                    TmpTotalAlloc += TmpBand.Allocation;
                    TmpTotalTax += TmpTax;

                    gvTax.Rows.Add(new string[] {
                        Percent(TmpBand.Rate),
                        Percent(TmpBand.Allocation),
                        (Possible ? Rate(TmpAllocated) : "-"),
                        (Possible ? Rate(TmpTax) : "-") });
                    //the line's place in the list, so a click can find it again
                    gvTax.Rows[gvTax.Rows.Count - 1].Tag = gvTax.Rows.Count - 1;
                }

                gvTax.ClearSelection();
                Filling = false;

                TmpTotalAlloc = Math.Round(TmpTotalAlloc, 2);
                TmpTotalTax = Math.Round(TmpTotalTax, 4);

                LblAfterTax.Text = Rate(TmpAfter);
                LblTotAlloc.Text = Percent(TmpTotalAlloc);
                LblTotTax.Text = (Possible ? Rate(TmpTotalTax) : "-");
                //the rate that has to be earned for the one above to be left
                LblBefore.Text = (Possible ? Rate(TmpBefore) : "-");

                Show_Note(TmpTotalAlloc, TmpTaken, Possible);
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Says where the allocation stands, because an unfinished list still produces a Before Tax
        //Interest and it would otherwise look like an answer rather than a part-worked sum.
        private void Show_Note(double parTotalAlloc, double parTaken, bool parPossible)
        {
            if (!parPossible)
            {
                LblNote.Text = "Every part of the interest is taxed at 100 %, so nothing is left"
                    + " whatever the rate before tax - there is no rate that gives the one asked"
                    + " for." + Source();
                return;
            }

            string TmpText = Bands.Count.ToString(CultureInfo.InvariantCulture) + " band(s)"
                + "   -   the bands take " + Percent(Math.Round(parTaken * 100, 2))
                + " of the whole";

            if (parTotalAlloc < 100)
            {
                TmpText = TmpText + ", with " + Percent(Math.Round(100 - parTotalAlloc, 2))
                    + " of the interest not allocated to any band and so taxed at nothing.";
            }
            else
            {
                TmpText = TmpText + ", and the whole of the interest is allocated.";
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
