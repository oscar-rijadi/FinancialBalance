using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialBalance
{
    public partial class Compound_Interest_Calculator : Form
    {
        bool Filling;

        //Nothing here is read from or written to the database - it is arithmetic on what is typed.

        const int MaxYears = 50;
        const decimal MaxRate = 20;

        //How often money goes in, and how many times a year that is
        static readonly string[] DepositNames =
            { "Daily", "Weekly", "Fortnightly", "Monthly", "Annually" };
        static readonly int[] DepositPerYear = { 365, 52, 26, 12, 1 };

        //How often interest is worked out and added to the balance
        static readonly string[] CompoundNames = { "Monthly", "Annually" };
        static readonly int[] CompoundPerYear = { 12, 1 };

        //One year's end position, for the chart
        private class YearRow
        {
            public int Year;
            public decimal Initial;
            public decimal Contributed;
            public decimal Interest;
        }

        public Compound_Interest_Calculator()
        {
            InitializeComponent();
        }

        private void Compound_Interest_Calculator_Load(object sender, EventArgs e)
        {
            Clear_Grid();
            Filling = true;
            CmbDepositFreq.Items.Clear();
            CmbDepositFreq.Items.AddRange(DepositNames);
            CmbCompoundFreq.Items.Clear();
            CmbCompoundFreq.Items.AddRange(CompoundNames);

            //a starting point that shows the page doing something rather than an empty chart
            txtInitial.Text = "10000.00";
            txtRegular.Text = "200.00";
            CmbDepositFreq.Text = "Monthly";
            CmbCompoundFreq.Text = "Monthly";
            txtYears.Text = "10";
            txtRate.Text = "5.00";
            Filling = false;

            Recalculate();
        }

        //---- the year by year table --------------------------------------------------

        private void Clear_Grid()
        {
            gvYears.Rows.Clear();
            gvYears.Columns.Clear();
            gvYears.ColumnCount = 6;
            string[] names = new string[] { "Year", "Regular Deposits", "Yearly Deposits",
                                            "Total Interest", "Yearly Interest", "Total" };
            int[] weights = new int[] { 8, 19, 18, 19, 18, 18 };
            for (int i = 0; i < 6; i++)
            {
                gvYears.Columns[i].Name = names[i];
                gvYears.Columns[i].FillWeight = weights[i];
                //the year sits centred, every amount reads right
                DataGridViewContentAlignment TmpAlign =
                    (i == 0 ? DataGridViewContentAlignment.MiddleCenter : DataGridViewContentAlignment.MiddleRight);
                gvYears.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvYears.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        //The running figures are what the chart is drawn from; the yearly ones are the step up
        //from the year before, so the first year's step is measured from nothing.
        private void Show_Table(List<YearRow> parRows)
        {
            Clear_Grid();
            decimal LastContributed = 0;
            decimal LastInterest = 0;

            foreach (YearRow r in parRows)
            {
                gvYears.Rows.Add(new string[] {
                    r.Year.ToString(),
                    Money(r.Contributed),
                    Money(r.Contributed - LastContributed),
                    Money(r.Interest),
                    Money(r.Interest - LastInterest),
                    Money(r.Initial + r.Contributed + r.Interest) });
                LastContributed = r.Contributed;
                LastInterest = r.Interest;
            }
            gvYears.ClearSelection();
        }

        //---- what may be typed ------------------------------------------------------

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

        private void Input_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Recalculate();
        }

        //---- formatting -------------------------------------------------------------

        //No currency is asked for, so the amounts are shown as plain figures rather than being
        //labelled with a sign the page cannot know.
        private string Money(decimal parValue)
        {
            return Mdl1.FormatAmt((double)Math.Round(parValue, 2));
        }

        private bool Read_Amount(TextBox parBox, string parField, decimal parMax,
                                 out decimal parValue, out string parWhy)
        {
            parValue = 0;
            parWhy = "";
            string TmpText = parBox.Text.Trim();
            if (TmpText == "")
            {
                parWhy = parField + " is needed.";
                return false;
            }
            if (!decimal.TryParse(TmpText, NumberStyles.Any, CultureInfo.InvariantCulture, out parValue))
            {
                parWhy = parField + " must be a number.";
                return false;
            }
            if (parValue < 0)
            {
                parWhy = parField + " cannot be negative.";
                return false;
            }
            if (parMax > 0 && parValue > parMax)
            {
                parWhy = parField + " cannot be more than "
                       + parMax.ToString("0.##", CultureInfo.InvariantCulture) + ".";
                return false;
            }
            return true;
        }

        //---- the calculation --------------------------------------------------------
        //
        //Interest is added at the compound frequency; deposits go in at their own frequency and
        //are counted into whichever compounding period they fall in:
        //
        //    periods            = years x compounds per year
        //    rate per period    = annual rate / compounds per year
        //    deposit per period = regular deposit x deposits per year / compounds per year
        //
        //and each period runs
        //
        //    balance = balance x (1 + rate per period) + deposit per period
        //
        //so a deposit is treated as arriving at the end of its period and earns nothing in the
        //period it lands in. That is the ordinary-annuity convention. A calculator that assumes
        //deposits arrive at the start will show slightly more interest for the same inputs.
        //
        //Where the deposit frequency is finer than the compounding - weekly deposits with annual
        //compounding, say - the deposits are pooled into the compounding period rather than being
        //compounded separately, since interest is only worked out once per period.

        private int Frequency_Index(ComboBox parCombo, string[] parNames)
        {
            for (int i = 0; i < parNames.Length; i++)
            {
                if (parNames[i] == parCombo.Text.Trim())
                {
                    return i;
                }
            }
            return -1;
        }

        private bool Read_Inputs(out decimal parInitial, out decimal parPerPeriod,
                                 out decimal parRatePerPeriod, out int parPeriods,
                                 out int parYears, out int parPerYear, out string parWhy)
        {
            parInitial = 0;
            parPerPeriod = 0;
            parRatePerPeriod = 0;
            parPeriods = 0;
            parYears = 0;
            parPerYear = 0;

            decimal TmpRegular;
            decimal TmpYears;
            decimal TmpRate;

            if (!Read_Amount(txtInitial, "Initial Deposit", 0, out parInitial, out parWhy)) { return false; }
            if (!Read_Amount(txtRegular, "Regular Deposit", 0, out TmpRegular, out parWhy)) { return false; }
            if (!Read_Amount(txtYears, "Number of Years", MaxYears, out TmpYears, out parWhy)) { return false; }
            if (!Read_Amount(txtRate, "Annual Interest Rate", MaxRate, out TmpRate, out parWhy)) { return false; }

            //the chart is drawn a column per year, so part years have nothing to stand on
            if (TmpYears != Math.Truncate(TmpYears))
            {
                parWhy = "Number of Years must be a whole number of years.";
                return false;
            }
            if (TmpYears < 1)
            {
                parWhy = "Number of Years must be at least 1.";
                return false;
            }

            int TmpDep = Frequency_Index(CmbDepositFreq, DepositNames);
            int TmpCmp = Frequency_Index(CmbCompoundFreq, CompoundNames);
            if (TmpDep < 0)
            {
                parWhy = "Deposit Frequency must be chosen.";
                return false;
            }
            if (TmpCmp < 0)
            {
                parWhy = "Compound Frequency must be chosen.";
                return false;
            }

            parYears = (int)TmpYears;
            parPerYear = CompoundPerYear[TmpCmp];
            parPeriods = parYears * parPerYear;
            parRatePerPeriod = TmpRate / 100 / parPerYear;
            parPerPeriod = TmpRegular * DepositPerYear[TmpDep] / parPerYear;
            return true;
        }

        //Runs the periods a year at a time and records where the balance stands at each year end,
        //split into what was put in and what the interest added.
        private List<YearRow> Run(decimal parInitial, decimal parPerPeriod, decimal parRatePerPeriod,
                                  int parYears, int parPerYear)
        {
            List<YearRow> Rows = new List<YearRow>();
            decimal Balance = parInitial;
            decimal Contributed = 0;

            for (int y = 1; y <= parYears; y++)
            {
                for (int p = 0; p < parPerYear; p++)
                {
                    Balance = Balance * (1 + parRatePerPeriod) + parPerPeriod;
                    Contributed = Contributed + parPerPeriod;
                }
                YearRow Row = new YearRow();
                Row.Year = y;
                Row.Initial = parInitial;
                Row.Contributed = Math.Round(Contributed, 2);
                //what is left over once the deposits are accounted for
                Row.Interest = Math.Round(Balance - parInitial - Contributed, 2);
                Rows.Add(Row);
            }
            return Rows;
        }

        private void Recalculate()
        {
            try
            {
                decimal TmpInitial;
                decimal TmpPerPeriod;
                decimal TmpRate;
                int TmpPeriods;
                int TmpYears;
                int TmpPerYear;
                string TmpWhy;

                if (!Read_Inputs(out TmpInitial, out TmpPerPeriod, out TmpRate, out TmpPeriods,
                                 out TmpYears, out TmpPerYear, out TmpWhy))
                {
                    //said in the note rather than in a message box: this runs on every keystroke,
                    //and a dialog per character would be unusable
                    Show_Nothing(TmpWhy);
                    return;
                }

                List<YearRow> Rows = Run(TmpInitial, TmpPerPeriod, TmpRate, TmpYears, TmpPerYear);
                YearRow Last = Rows[Rows.Count - 1];

                LblSumInitial.Text = Money(Last.Initial);
                LblSumRegular.Text = Money(Last.Contributed);
                LblSumInterest.Text = Money(Last.Interest);
                LblSumTotal.Text = Money(Last.Initial + Last.Contributed + Last.Interest);

                LblNote.Text = "Interest added " + CmbCompoundFreq.Text.Trim().ToLower()
                             + ", deposits " + CmbDepositFreq.Text.Trim().ToLower()
                             + ", over " + TmpYears.ToString()
                             + (TmpYears == 1 ? " year." : " years.");
                LblNote.ForeColor = System.Drawing.Color.Black;

                Show_Chart(Rows);
                Show_Table(Rows);
            }
            catch (Exception ex)
            {
                Show_Nothing(ex.Message);
            }
        }

        private void Show_Nothing(string parWhy)
        {
            LblSumInitial.Text = "";
            LblSumRegular.Text = "";
            LblSumInterest.Text = "";
            LblSumTotal.Text = "";
            LblNote.Text = parWhy;
            LblNote.ForeColor = System.Drawing.Color.Red;
            pnlChart.Controls.Clear();
            Clear_Grid();
        }

        //---- the chart --------------------------------------------------------------
        //
        //A column per year, stacked into what was put in and what the interest added, so the
        //three parts add up to the balance at that year's end.

        private void Show_Chart(List<YearRow> parRows)
        {
            pnlChart.Controls.Clear();

            Chart ch = new Chart();
            ch.Width = pnlChart.Width;
            ch.Height = pnlChart.Height;
            ch.BackColor = System.Drawing.Color.Transparent;

            ChartArea ca = new ChartArea("ChartArea1");
            ca.BackColor = System.Drawing.Color.Transparent;
            ca.AxisX.Title = "Year";
            ca.AxisX.TitleFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            ca.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 7F);
            ca.AxisX.MajorGrid.Enabled = false;
            //a tick every year is unreadable at 50, so they are thinned to about a dozen
            ca.AxisX.Interval = Math.Max(1, (int)Math.Ceiling(parRows.Count / 12.0));
            ca.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 7F);
            ca.AxisY.LabelStyle.Format = "#,##0";
            ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            ch.ChartAreas.Add(ca);

            Legend le = new Legend("Legend1");
            le.Docking = Docking.Bottom;
            le.Font = new System.Drawing.Font("Arial", 8F);
            ch.Legends.Add(le);

            Series sInit = new Series("Initial Deposit");
            Series sReg = new Series("Regular Deposits");
            Series sInt = new Series("Total Interest");
            foreach (Series s in new Series[] { sInit, sReg, sInt })
            {
                s.ChartType = SeriesChartType.StackedColumn;
                s.Legend = "Legend1";
                s.Font = new System.Drawing.Font("Arial", 7F);
                ch.Series.Add(s);
            }
            sInit.Color = System.Drawing.Color.SteelBlue;
            sReg.Color = System.Drawing.Color.MediumSeaGreen;
            sInt.Color = System.Drawing.Color.Goldenrod;

            foreach (YearRow r in parRows)
            {
                sInit.Points.AddXY(r.Year, (double)r.Initial);
                sReg.Points.AddXY(r.Year, (double)r.Contributed);
                sInt.Points.AddXY(r.Year, (double)r.Interest);
                int idx = sInit.Points.Count - 1;
                string when = "Year " + r.Year.ToString() + " : ";
                sInit.Points[idx].ToolTip = when + "initial " + Money(r.Initial);
                sReg.Points[idx].ToolTip = when + "deposits " + Money(r.Contributed);
                sInt.Points[idx].ToolTip = when + "interest " + Money(r.Interest);
            }

            pnlChart.Controls.Add(ch);
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
