using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace FinancialBalance
{
    public partial class Dividend_Snowball_Calculator : Form
    {
        bool Filling;

        //Nothing here is read from or written to the database - it is arithmetic on what is typed.

        const int MaxYears = 50;
        const decimal MaxPercent = 100;
        //how far past the horizon the target is chased before the page gives up on it
        const int SearchYears = 100;

        //How often money goes in, and how many times a year that is
        static readonly string[] FrequencyNames =
            { "Daily", "Weekly", "Fortnightly", "Monthly", "Annually" };
        static readonly int[] FrequencyPerYear = { 365, 52, 26, 12, 1 };

        static readonly string[] YesNo = { "Yes", "No" };

        //One year of the snowball, in the order the table shows it
        private class YearRow
        {
            public int Year;
            public decimal Starting;
            public decimal Contribution;
            public decimal Invested;
            public decimal Yield;
            public decimal Gross;
            public decimal Reinvested;
            public decimal Cash;
            public decimal Ending;
        }

        //Everything the run needs, gathered once so the horizon can be varied without re-reading
        //the boxes - the target search runs the same model out past the horizon.
        private class Inputs
        {
            public decimal Starting;
            public decimal FirstYearContribution;
            public decimal ContributionIncrease;
            public decimal StartingYield;
            public decimal DividendGrowth;
            public decimal PortfolioGrowth;
            public bool Reinvest;
            public int Years;
            public decimal Target;
            public bool HasTarget;
        }

        public Dividend_Snowball_Calculator()
        {
            InitializeComponent();
        }

        private void Dividend_Snowball_Calculator_Load(object sender, EventArgs e)
        {
            Clear_Grid();
            Filling = true;
            CmbContributionFreq.Items.Clear();
            CmbContributionFreq.Items.AddRange(FrequencyNames);
            CmbReinvested.Items.Clear();
            CmbReinvested.Items.AddRange(YesNo);

            //a starting point that shows the page doing something rather than an empty table
            txtStartingValue.Text = "50000.00";
            txtContribution.Text = "500.00";
            CmbContributionFreq.Text = "Monthly";
            txtContributionIncrease.Text = "3.00";
            txtStartingYield.Text = "4.00";
            txtDividendGrowth.Text = "5.00";
            txtPortfolioGrowth.Text = "7.00";
            CmbReinvested.Text = "Yes";
            txtYears.Text = "20";
            txtTarget.Text = "50000.00";
            Filling = false;

            Recalculate();
        }

        //---- the year by year table --------------------------------------------------

        private void Clear_Grid()
        {
            gvYears.Rows.Clear();
            gvYears.Columns.Clear();
            gvYears.ColumnCount = 9;
            string[] names = new string[] { "Year", "Starting Balance", "Yearly Contribution",
                                            "Total Investment", "Yearly Dividend Yield",
                                            "Gross Dividend", "Reinvested", "Taken as Cash",
                                            "Ending Balance" };
            int[] weights = new int[] { 6, 12, 12, 12, 11, 12, 11, 11, 13 };
            for (int i = 0; i < 9; i++)
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

        private void Show_Table(List<YearRow> parRows)
        {
            Clear_Grid();
            foreach (YearRow r in parRows)
            {
                gvYears.Rows.Add(new string[] {
                    r.Year.ToString(),
                    Money(r.Starting),
                    Money(r.Contribution),
                    Money(r.Invested),
                    Percent(r.Yield),
                    Money(r.Gross),
                    Money(r.Reinvested),
                    Money(r.Cash),
                    Money(r.Ending) });
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

        //Time Horizon is a count of years, so it takes digits only - the shared numeric handler
        //lets a decimal point through.
        private void Whole_KeyPress(object sender, KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            if (!((KeyAscii >= 48 && KeyAscii <= 57) || KeyAscii == 8))
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

        private string Money(decimal parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt((double)Math.Round(Math.Abs(parValue), 2));
            }
            return "$" + Mdl1.FormatAmt((double)Math.Round(parValue, 2));
        }

        private string Percent(decimal parValue)
        {
            return Math.Round(parValue, 2).ToString("#,##0.00") + " %";
        }

        private bool Read_Amount(TextBox parBox, string parField, decimal parMax, bool parBlankIsZero,
                                 out decimal parValue, out string parWhy)
        {
            parValue = 0;
            parWhy = "";
            string TmpText = parBox.Text.Trim();
            if (TmpText == "")
            {
                if (parBlankIsZero)
                {
                    return true;
                }
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

        //---- the calculation --------------------------------------------------------
        //
        //A year at a time. The balance carried in is last year's ending balance, the contribution
        //steps up by its annual increase, and the yield steps up by the dividend growth rate:
        //
        //    Yearly Contribution   = Contribution Amount x times a year x (1 + increase) ^ (year - 1)
        //    Total Investment      = Starting Balance + Yearly Contribution
        //    Yearly Dividend Yield = Starting Dividend Yield x (1 + dividend growth) ^ (year - 1)
        //    Gross Dividend        = Total Investment x Yearly Dividend Yield
        //    Reinvested            = Gross Dividend when reinvesting, otherwise nothing
        //    Taken as Cash         = Gross Dividend when not reinvesting, otherwise nothing
        //    Ending Balance        = Starting Balance x (1 + growth)
        //                          + (Yearly Contribution + Reinvested) x (1 + growth / 2)
        //
        //The balance held all year earns the growth rate in full; the contributions and any
        //reinvested dividend arrive spread through the year, so they earn half of it. That is the
        //usual half-year convention, and it is why the two terms carry different rates.

        private decimal Pow(decimal parBase, int parExponent)
        {
            decimal TmpResult = 1;
            for (int i = 0; i < parExponent; i++)
            {
                TmpResult = TmpResult * parBase;
            }
            return TmpResult;
        }

        private bool Read_Inputs(out Inputs parIn, out string parWhy)
        {
            parIn = new Inputs();
            decimal TmpContribution;
            decimal TmpYears;

            if (!Read_Amount(txtStartingValue, "Starting Portfolio Value", 0, false,
                             out parIn.Starting, out parWhy)) { return false; }
            if (!Read_Amount(txtContribution, "Contribution Amount", 0, false,
                             out TmpContribution, out parWhy)) { return false; }
            if (!Read_Amount(txtContributionIncrease, "Annual Increase in Contribution", MaxPercent, false,
                             out parIn.ContributionIncrease, out parWhy)) { return false; }
            if (!Read_Amount(txtStartingYield, "Starting Dividend Yield", MaxPercent, false,
                             out parIn.StartingYield, out parWhy)) { return false; }
            if (!Read_Amount(txtDividendGrowth, "Annual Dividend Growth Rate", MaxPercent, false,
                             out parIn.DividendGrowth, out parWhy)) { return false; }
            if (!Read_Amount(txtPortfolioGrowth, "Portfolio Growth Rate", MaxPercent, false,
                             out parIn.PortfolioGrowth, out parWhy)) { return false; }
            if (!Read_Amount(txtYears, "Time Horizon", MaxYears, false,
                             out TmpYears, out parWhy)) { return false; }
            if (!Read_Amount(txtTarget, "Target Annual Dividend Income", 0, true,
                             out parIn.Target, out parWhy)) { return false; }

            //a row per year, so part years have nothing to stand on
            if (TmpYears != Math.Truncate(TmpYears))
            {
                parWhy = "Time Horizon must be a whole number of years.";
                return false;
            }
            if (TmpYears < 1)
            {
                parWhy = "Time Horizon must be at least 1 year.";
                return false;
            }

            int TmpFreq = Frequency_Index(CmbContributionFreq, FrequencyNames);
            int TmpReinvest = Frequency_Index(CmbReinvested, YesNo);
            if (TmpFreq < 0)
            {
                parWhy = "Contribution Frequency must be chosen.";
                return false;
            }
            if (TmpReinvest < 0)
            {
                parWhy = "Dividend Reinvested must be chosen.";
                return false;
            }

            parIn.Years = (int)TmpYears;
            parIn.FirstYearContribution = TmpContribution * FrequencyPerYear[TmpFreq];
            parIn.Reinvest = (TmpReinvest == 0);
            parIn.HasTarget = (parIn.Target > 0);
            return true;
        }

        //One year, worked out from the balance carried into it. The table and the target search
        //both go through here, so there is only ever one statement of the recurrence.
        private YearRow Year_From(Inputs parIn, int parYear, decimal parStarting)
        {
            decimal Growth = parIn.PortfolioGrowth / 100;
            YearRow Row = new YearRow();
            Row.Year = parYear;
            Row.Starting = parStarting;
            Row.Contribution = parIn.FirstYearContribution
                             * Pow(1 + parIn.ContributionIncrease / 100, parYear - 1);
            Row.Invested = Row.Starting + Row.Contribution;
            Row.Yield = parIn.StartingYield * Pow(1 + parIn.DividendGrowth / 100, parYear - 1);
            Row.Gross = Row.Invested * Row.Yield / 100;
            Row.Reinvested = (parIn.Reinvest ? Row.Gross : 0);
            Row.Cash = (parIn.Reinvest ? 0 : Row.Gross);
            Row.Ending = Row.Starting * (1 + Growth)
                       + (Row.Contribution + Row.Reinvested) * (1 + Growth / 2);
            return Row;
        }

        private List<YearRow> Run(Inputs parIn, int parYears)
        {
            List<YearRow> Rows = new List<YearRow>();
            decimal Balance = parIn.Starting;
            for (int y = 1; y <= parYears; y++)
            {
                YearRow Row = Year_From(parIn, y, Balance);
                Rows.Add(Row);
                Balance = Row.Ending;
            }
            return Rows;
        }

        //The first year whose gross dividend covers the target. The table stops at the horizon,
        //but the question is how long it takes, so the same model is stepped on past it and the
        //answer says so when it lands beyond.
        //
        //It stops the moment the target is cleared rather than projecting the whole search first:
        //a reinvested dividend on a yield that is itself growing outruns what a decimal can hold
        //well inside a century, and that is no reason for the page to give up on the years it
        //could work out.
        private string Years_To_Target(Inputs parIn)
        {
            if (!parIn.HasTarget)
            {
                return "-";
            }
            int TmpLimit = Math.Max(parIn.Years, SearchYears);
            int TmpCovered = 0;
            try
            {
                decimal Balance = parIn.Starting;
                for (int y = 1; y <= TmpLimit; y++)
                {
                    YearRow Row = Year_From(parIn, y, Balance);
                    TmpCovered = y;
                    if (Row.Gross >= parIn.Target)
                    {
                        string TmpAnswer = y.ToString() + (y == 1 ? " year" : " years");
                        if (y > parIn.Years)
                        {
                            TmpAnswer = TmpAnswer + " (beyond the horizon)";
                        }
                        return TmpAnswer;
                    }
                    Balance = Row.Ending;
                }
            }
            catch (OverflowException)
            {
                //the projection ran away before the target was met - say how far it got rather
                //than losing the table and the totals along with it
            }
            return "Not reached within " + TmpCovered.ToString() + " years";
        }

        private void Recalculate()
        {
            try
            {
                Inputs TmpIn;
                string TmpWhy;

                if (!Read_Inputs(out TmpIn, out TmpWhy))
                {
                    //said in the note rather than in a message box: this runs on every keystroke,
                    //and a dialog per character would be unusable
                    Show_Nothing(TmpWhy);
                    return;
                }

                List<YearRow> Rows = Run(TmpIn, TmpIn.Years);
                YearRow Last = Rows[Rows.Count - 1];
                decimal TmpTotalContribution = 0;
                foreach (YearRow r in Rows)
                {
                    TmpTotalContribution = TmpTotalContribution + r.Contribution;
                }

                LblSumContribution.Text = Money(TmpTotalContribution);
                LblSumPortfolio.Text = Money(Last.Ending);
                LblSumAnnualDividend.Text = Money(Last.Gross);
                LblSumMonthlyDividend.Text = Money(Last.Gross / 12);
                LblSumYearsToTarget.Text = Years_To_Target(TmpIn);

                LblNote.Text = (TmpIn.Reinvest ? "Dividends reinvested" : "Dividends taken as cash")
                             + ", contributions " + CmbContributionFreq.Text.Trim().ToLower()
                             + " rising " + Percent(TmpIn.ContributionIncrease) + " a year, over "
                             + TmpIn.Years.ToString() + (TmpIn.Years == 1 ? " year." : " years.")
                             + "  Ending Balance = Starting Balance x (1 + growth)"
                             + " + (Yearly Contribution + Reinvested) x (1 + growth / 2),"
                             + " so money added during the year earns half a year's growth.";
                LblNote.ForeColor = System.Drawing.Color.Black;

                Show_Table(Rows);
            }
            catch (OverflowException)
            {
                Show_Nothing("These figures grow too large to work out. Please lower a rate or the time horizon.");
            }
            catch (Exception ex)
            {
                Show_Nothing(ex.Message);
            }
        }

        private void Show_Nothing(string parWhy)
        {
            LblSumContribution.Text = "";
            LblSumPortfolio.Text = "";
            LblSumAnnualDividend.Text = "";
            LblSumMonthlyDividend.Text = "";
            LblSumYearsToTarget.Text = "";
            LblNote.Text = parWhy;
            LblNote.ForeColor = System.Drawing.Color.Red;
            Clear_Grid();
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
