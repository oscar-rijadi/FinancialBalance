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
    public partial class Superannuation_Calculator : Form
    {
        bool Filling;

        //Nothing here is read from or written to the database - it is arithmetic on what is typed.
        //
        //The page follows the MoneySmart superannuation calculator:
        //https://moneysmart.gov.au/how-super-works/superannuation-calculator
        //
        //Everything is worked in TODAY'S DOLLARS. That is what makes the answer readable: a
        //balance forty years out is meaningless in the dollars of that year. The Super Return is
        //typed as a nominal rate, so it is deflated once at the start
        //
        //    living cost rise  d = (1 + cost of living) x (1 + living standards) - 1
        //    real return       r = (1 + return) / (1 + d) - 1
        //
        //and everything after that runs at r with the income, the fees and the insurance held
        //level. Holding income level is the same assumption: wages are taken to rise with the
        //cost of living and living standards together, which is exactly what d is, so in today's
        //dollars the salary does not move.

        const decimal ContribTaxRate = 15;      //concessional contributions are taxed at 15 %
        const int NonConcessionalMultiple = 4;  //the after-tax cap is four times the before-tax one

        const int MinAge = 18;
        const int MaxAge = 75;
        const int MinRetireAge = 60;
        const int MaxRetireAge = 75;

        //The investment options and what each is assumed to return a year, net of tax and
        //investment fees. "Other" leaves the rate alone so it can be typed.
        static readonly string[] OptionNames =
            { "Cash", "Conservative", "Moderate", "Balanced", "Growth", "High Growth", "Other" };
        static readonly decimal[] OptionReturns =
            { 3.70m, 4.90m, 5.70m, 6.10m, 6.40m, 6.80m, 0m };
        const string OtherOption = "Other";

        //One year's worth of the projection
        private class YearRow
        {
            public int Age;
            public decimal In;          //what went in, before tax and fees
            public decimal Tax;         //contributions tax on the before-tax part
            public decimal Fees;        //contribution fee, admin, insurance
            public decimal Earnings;
            public decimal Balance;     //at the end of the year
            public decimal NetAdded;    //what the contributions added once tax and fees came off
        }

        //What one run of the projection came to
        private class Result
        {
            public List<YearRow> Rows = new List<YearRow>();
            public decimal Now;
            public decimal Employer;
            public decimal Extra;
            public decimal Tax;
            public decimal Fees;
            public decimal Earnings;
            public decimal Final;
            public decimal RealReturn;
            public decimal Deflator;
            public bool CapBit;         //the concessional cap turned something away
            public bool AfterCapBit;    //so did the non-concessional cap
        }

        public Superannuation_Calculator()
        {
            InitializeComponent();
        }

        private void Superannuation_Calculator_Load(object sender, EventArgs e)
        {
            Clear_Grid();
            Filling = true;
            CmbOption.Items.Clear();
            CmbOption.Items.AddRange(OptionNames);

            //a starting point that shows the page doing something rather than an empty chart
            txtAge.Text = "30";
            txtRetireAge.Text = "67";
            txtIncome.Text = "100000.00";
            txtBalance.Text = "50000.00";
            txtEmployer.Text = "12.00";
            txtBeforeTax.Text = "0.00";
            txtAfterTax.Text = "0.00";
            txtCap.Text = "32500.00";
            CmbOption.Text = "Balanced";
            txtReturn.Text = "6.10";
            txtContribFee.Text = "0.00";
            txtAdminDollar.Text = "59.00";
            txtAdminPct.Text = "0.11";
            txtInsurance.Text = "599.00";
            txtCPI.Text = "2.50";
            txtLiving.Text = "1.20";
            Filling = false;

            Recalculate();
        }

        //---- the year by year table --------------------------------------------------

        private void Clear_Grid()
        {
            gvYears.Rows.Clear();
            gvYears.Columns.Clear();
            gvYears.ColumnCount = 6;
            string[] names = new string[] { "Age", "Contributions", "Tax", "Fees", "Earnings", "Balance" };
            //The weights are the pixel budget, and add to the 600 the grid has once its scrollbar
            //is taken off - only their ratio matters, so writing them this way makes each column
            //say what it is actually being given.
            int[] weights = new int[] { 45, 111, 111, 111, 111, 111 };
            for (int i = 0; i < 6; i++)
            {
                gvYears.Columns[i].Name = names[i];
                gvYears.Columns[i].FillWeight = weights[i];
                //the age sits centred, every amount reads right
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
                    r.Age.ToString(),
                    Money(r.In),
                    Money(r.Tax),
                    Money(r.Fees),
                    Money(r.Earnings),
                    Money(r.Balance) });
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

        //Picking an option fills the rate in; typing a rate of your own is what "Other" means, so
        //the dropdown follows the box rather than arguing with it.
        private void Option_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            int idx = Option_Index();
            if (idx >= 0 && CmbOption.Text.Trim() != OtherOption)
            {
                Filling = true;
                txtReturn.Text = OptionReturns[idx].ToString("0.00", CultureInfo.InvariantCulture);
                Filling = false;
            }
            Recalculate();
        }

        private void Return_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            int idx = Option_Index();
            if (idx >= 0 && CmbOption.Text.Trim() != OtherOption)
            {
                decimal TmpRate;
                bool Parsed = decimal.TryParse(txtReturn.Text.Trim(), NumberStyles.Any,
                                               CultureInfo.InvariantCulture, out TmpRate);
                if (!Parsed || TmpRate != OptionReturns[idx])
                {
                    Filling = true;
                    CmbOption.Text = OtherOption;
                    Filling = false;
                }
            }
            Recalculate();
        }

        private int Option_Index()
        {
            for (int i = 0; i < OptionNames.Length; i++)
            {
                if (OptionNames[i] == CmbOption.Text.Trim())
                {
                    return i;
                }
            }
            return -1;
        }

        //---- formatting -------------------------------------------------------------

        //No currency is asked for, so the amounts are shown as plain figures rather than being
        //labelled with a sign the page cannot know.
        private string Money(decimal parValue)
        {
            return Mdl1.FormatAmt((double)Math.Round(parValue, 2));
        }

        private string Rate(decimal parValue)
        {
            return Math.Round(parValue, 2).ToString("0.00", CultureInfo.InvariantCulture) + " %";
        }

        private bool Read_Amount(TextBox parBox, string parField, decimal parMin, decimal parMax,
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
            if (parValue < parMin)
            {
                parWhy = parField + " cannot be less than "
                       + parMin.ToString("0.##", CultureInfo.InvariantCulture) + ".";
                return false;
            }
            if (parValue > parMax)
            {
                parWhy = parField + " cannot be more than "
                       + parMax.ToString("0.##", CultureInfo.InvariantCulture) + ".";
                return false;
            }
            return true;
        }

        private bool Read_Whole(TextBox parBox, string parField, int parMin, int parMax,
                                out int parValue, out string parWhy)
        {
            parValue = 0;
            decimal TmpValue;
            if (!Read_Amount(parBox, parField, parMin, parMax, out TmpValue, out parWhy))
            {
                return false;
            }
            if (TmpValue != Math.Truncate(TmpValue))
            {
                parWhy = parField + " must be a whole number of years.";
                return false;
            }
            parValue = (int)TmpValue;
            return true;
        }

        //---- the calculation --------------------------------------------------------
        //
        //One year at a time, in today's dollars:
        //
        //    employer        = income x employer rate
        //    concessional    = employer + before-tax, up to the concessional cap - the employer
        //                      part counts first, since it arrives whether or not it is wanted
        //    contributions tax = concessional x 15 %
        //    after-tax       = what is typed, up to four times the cap
        //    contribution fee = (concessional + after-tax) x contribution fee rate
        //    net in          = concessional - tax + after-tax - contribution fee
        //
        //    average balance = opening balance + net in / 2
        //    earnings        = average balance x real return
        //    percentage fee  = average balance x admin fee rate
        //    closing balance = opening + net in + earnings - admin $ - insurance - percentage fee
        //
        //Contributions are taken to arrive evenly through the year, which is what the half of
        //"net in" in the average balance says: a year's contributions earn half a year's return.
        //Assuming they all arrive on day one would show more, and on the last day less.
        //
        //What is NOT modelled, and is said on the page as well: Division 293 tax on high incomes,
        //the government co-contribution, and the low income super tax offset. Each would need
        //thresholds of its own that this page does not ask for.

        private bool Read_Inputs(out Result parAnswer, out string parWhy)
        {
            parAnswer = null;
            parWhy = "";

            int TmpAge;
            int TmpRetire;
            decimal TmpIncome;
            decimal TmpBalance;
            decimal TmpEmployer;
            decimal TmpBefore;
            decimal TmpAfter;
            decimal TmpCap;
            decimal TmpReturn;
            decimal TmpContribFee;
            decimal TmpAdminDollar;
            decimal TmpAdminPct;
            decimal TmpInsurance;
            decimal TmpCPI;
            decimal TmpLiving;

            if (!Read_Whole(txtAge, "Age", MinAge, MaxAge, out TmpAge, out parWhy)) { return false; }
            if (!Read_Whole(txtRetireAge, "Retirement Age", MinRetireAge, MaxRetireAge, out TmpRetire, out parWhy)) { return false; }
            if (!Read_Amount(txtIncome, "Income per Year", 0, 1000000, out TmpIncome, out parWhy)) { return false; }
            if (!Read_Amount(txtBalance, "Super Balance", 0, 5000000, out TmpBalance, out parWhy)) { return false; }
            if (!Read_Amount(txtEmployer, "Employer Contribution", 10.5m, 25, out TmpEmployer, out parWhy)) { return false; }
            if (!Read_Amount(txtBeforeTax, "Before-tax Contribution", 0, 1000000, out TmpBefore, out parWhy)) { return false; }
            if (!Read_Amount(txtAfterTax, "After-tax Contribution", 0, 1000000, out TmpAfter, out parWhy)) { return false; }
            if (!Read_Amount(txtCap, "Concessional Cap", 0, 1000000, out TmpCap, out parWhy)) { return false; }
            if (!Read_Amount(txtReturn, "Super Return", 0, 20, out TmpReturn, out parWhy)) { return false; }
            if (!Read_Amount(txtContribFee, "Contribution Fee", 0, 10, out TmpContribFee, out parWhy)) { return false; }
            if (!Read_Amount(txtAdminDollar, "Admin Fee per Year", 0, 1000, out TmpAdminDollar, out parWhy)) { return false; }
            if (!Read_Amount(txtAdminPct, "Admin Fee", 0, 5, out TmpAdminPct, out parWhy)) { return false; }
            if (!Read_Amount(txtInsurance, "Insurance per Year", 0, 10000, out TmpInsurance, out parWhy)) { return false; }
            if (!Read_Amount(txtCPI, "Rise in Cost of Living", 0, 10, out TmpCPI, out parWhy)) { return false; }
            if (!Read_Amount(txtLiving, "Rise in Living Standards", 0, 10, out TmpLiving, out parWhy)) { return false; }

            if (TmpRetire <= TmpAge)
            {
                parWhy = "Retirement Age must be more than Age - there is nothing to project.";
                return false;
            }

            parAnswer = Run(TmpAge, TmpRetire, TmpIncome, TmpBalance, TmpEmployer, TmpBefore,
                            TmpAfter, TmpCap, TmpReturn, TmpContribFee, TmpAdminDollar,
                            TmpAdminPct, TmpInsurance, TmpCPI, TmpLiving);
            return true;
        }

        private Result Run(int parAge, int parRetire, decimal parIncome, decimal parBalance,
                           decimal parEmployerPct, decimal parBefore, decimal parAfter,
                           decimal parCap, decimal parReturn, decimal parContribFeePct,
                           decimal parAdminDollar, decimal parAdminPct, decimal parInsurance,
                           decimal parCPI, decimal parLiving)
        {
            Result Answer = new Result();
            Answer.Now = parBalance;

            //the two rises compound rather than being added: they are two separate escalations,
            //so 2.5 % and 1.2 % together are 3.73 % a year, not 3.70 %
            Answer.Deflator = (1 + parCPI / 100) * (1 + parLiving / 100) - 1;
            Answer.RealReturn = (1 + parReturn / 100) / (1 + Answer.Deflator) - 1;

            decimal Balance = parBalance;
            decimal AfterCap = parCap * NonConcessionalMultiple;

            for (int Age = parAge; Age < parRetire; Age++)
            {
                decimal Employer = parIncome * parEmployerPct / 100;

                //the employer part counts against the cap first - it arrives whether or not it is
                //wanted, so it is the salary sacrifice that has to give way
                decimal EmpCounted = Math.Min(Employer, parCap);
                decimal BeforeCounted = Math.Min(parBefore, parCap - EmpCounted);
                decimal Concessional = EmpCounted + BeforeCounted;
                if (Employer + parBefore > parCap)
                {
                    Answer.CapBit = true;
                }

                decimal AfterCounted = Math.Min(parAfter, AfterCap);
                if (parAfter > AfterCap)
                {
                    Answer.AfterCapBit = true;
                }

                decimal Tax = Concessional * ContribTaxRate / 100;
                decimal ContribFee = (Concessional + AfterCounted) * parContribFeePct / 100;
                decimal NetIn = Concessional - Tax + AfterCounted - ContribFee;

                decimal Average = Balance + NetIn / 2;
                decimal Earnings = Average * Answer.RealReturn;
                decimal PctFee = Average * parAdminPct / 100;
                decimal OtherFees = parAdminDollar + parInsurance + PctFee;

                Balance = Balance + NetIn + Earnings - OtherFees;

                YearRow Row = new YearRow();
                Row.Age = Age + 1;
                //kept unrounded: the table rounds when it prints, and the chart stacks these up,
                //so rounding them here would leave the columns a few cents short of the balance
                //after forty years of it
                Row.In = Concessional + AfterCounted;
                Row.Tax = Tax;
                Row.Fees = ContribFee + OtherFees;
                Row.Earnings = Earnings;
                Row.Balance = Balance;
                Row.NetAdded = NetIn - OtherFees;
                Answer.Rows.Add(Row);

                Answer.Employer += EmpCounted;
                Answer.Extra += BeforeCounted + AfterCounted;
                Answer.Tax += Tax;
                Answer.Fees += ContribFee + OtherFees;
                Answer.Earnings += Earnings;
            }

            Answer.Final = Balance;
            return Answer;
        }

        private void Recalculate()
        {
            try
            {
                Result Answer;
                string TmpWhy;

                if (!Read_Inputs(out Answer, out TmpWhy))
                {
                    //said in the note rather than in a message box: this runs on every keystroke,
                    //and a dialog per character would be unusable
                    Show_Nothing(TmpWhy);
                    return;
                }

                LblResult.Text = Money(Answer.Final);
                LblSumNow.Text = Money(Answer.Now);
                LblSumEmployer.Text = Money(Answer.Employer);
                LblSumExtra.Text = Money(Answer.Extra);
                LblSumTax.Text = Money(Answer.Tax);
                LblSumFees.Text = Money(Answer.Fees);
                LblSumEarnings.Text = Money(Answer.Earnings);

                LblNote.Text = Note_Text(Answer);
                LblNote.ForeColor = System.Drawing.Color.Black;

                Show_Chart(Answer);
                Show_Table(Answer.Rows);
            }
            catch (Exception ex)
            {
                Show_Nothing(ex.Message);
            }
        }

        private string Note_Text(Result parAnswer)
        {
            string strLine1 = parAnswer.Rows.Count.ToString()
                            + (parAnswer.Rows.Count == 1 ? " year" : " years")
                            + " to age " + txtRetireAge.Text.Trim()
                            + ", at " + Rate(Read_Shown(txtReturn))
                            + " a year less " + Rate(parAnswer.Deflator * 100)
                            + " for rising prices and living standards, so "
                            + Rate(parAnswer.RealReturn * 100) + " in today's dollars.";

            string strLine2 = "Contributions are taxed at " + Rate(ContribTaxRate)
                            + ", and fees, insurance and income are today's dollars held level.";
            if (parAnswer.CapBit)
            {
                strLine2 = strLine2 + "  The concessional cap of " + Money(Read_Shown(txtCap))
                         + " turns some of the before-tax contribution away.";
            }
            if (parAnswer.AfterCapBit)
            {
                strLine2 = strLine2 + "  The after-tax cap of "
                         + Money(Read_Shown(txtCap) * NonConcessionalMultiple)
                         + " turns some of the after-tax contribution away.";
            }

            string strLine3 = "Division 293 tax, the government co-contribution and the low income "
                            + "super tax offset are not included.";

            return strLine1 + Environment.NewLine + strLine2 + Environment.NewLine + strLine3;
        }

        //Only ever called once the box has already been read successfully
        private decimal Read_Shown(TextBox parBox)
        {
            decimal TmpValue;
            decimal.TryParse(parBox.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out TmpValue);
            return TmpValue;
        }

        private void Show_Nothing(string parWhy)
        {
            LblResult.Text = "";
            LblSumNow.Text = "";
            LblSumEmployer.Text = "";
            LblSumExtra.Text = "";
            LblSumTax.Text = "";
            LblSumFees.Text = "";
            LblSumEarnings.Text = "";
            LblNote.Text = parWhy;
            LblNote.ForeColor = System.Drawing.Color.Red;
            pnlChart.Controls.Clear();
            Clear_Grid();
        }

        //---- the chart --------------------------------------------------------------
        //
        //A column per year, stacked into the balance there is now, what the contributions added
        //once tax and every fee came off, and what the earnings added - so the three parts add up
        //to the balance at that year's end, and the middle one shows negative in any year the
        //fees are larger than what went in.

        private void Show_Chart(Result parAnswer)
        {
            pnlChart.Controls.Clear();

            Chart ch = new Chart();
            ch.Width = pnlChart.Width;
            ch.Height = pnlChart.Height;
            ch.BackColor = System.Drawing.Color.Transparent;

            ChartArea ca = new ChartArea("ChartArea1");
            ca.BackColor = System.Drawing.Color.Transparent;
            ca.AxisX.Title = "Age";
            ca.AxisX.TitleFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            ca.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 7F);
            ca.AxisX.MajorGrid.Enabled = false;
            //A label a year is unreadable over a working life, so the axis is ticked every Step
            //years. It is pinned to the ages actually plotted and offset half a year off the
            //bottom of that, so the ticks land on the first column and on the retirement age -
            //left to itself the axis picks round numbers of its own and labels ages that have no
            //column standing under them.
            int Step = Math.Max(1, (int)Math.Ceiling(parAnswer.Rows.Count / 10.0));
            ca.AxisX.Minimum = parAnswer.Rows[0].Age - 0.5;
            ca.AxisX.Maximum = parAnswer.Rows[parAnswer.Rows.Count - 1].Age + 0.5;
            ca.AxisX.Interval = Step;
            ca.AxisX.IntervalOffset = 0.5;
            ca.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 7F);
            ca.AxisY.LabelStyle.Format = "#,##0";
            ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            ch.ChartAreas.Add(ca);

            Legend le = new Legend("Legend1");
            le.Docking = Docking.Bottom;
            le.Font = new System.Drawing.Font("Arial", 7F);
            ch.Legends.Add(le);

            Series sNow = new Series("Balance Now");
            Series sCon = new Series("Contributions");
            Series sEar = new Series("Earnings");
            foreach (Series s in new Series[] { sNow, sCon, sEar })
            {
                s.ChartType = SeriesChartType.StackedColumn;
                s.Legend = "Legend1";
                s.Font = new System.Drawing.Font("Arial", 7F);
                ch.Series.Add(s);
            }
            sNow.Color = System.Drawing.Color.SteelBlue;
            sCon.Color = System.Drawing.Color.MediumSeaGreen;
            sEar.Color = System.Drawing.Color.Goldenrod;

            decimal RunCon = 0;
            decimal RunEar = 0;
            foreach (YearRow r in parAnswer.Rows)
            {
                RunCon = RunCon + r.NetAdded;
                RunEar = RunEar + r.Earnings;
                sNow.Points.AddXY(r.Age, (double)parAnswer.Now);
                sCon.Points.AddXY(r.Age, (double)RunCon);
                sEar.Points.AddXY(r.Age, (double)RunEar);
                int idx = sNow.Points.Count - 1;
                string when = "Age " + r.Age.ToString() + " : ";
                sNow.Points[idx].ToolTip = when + "balance now " + Money(parAnswer.Now);
                sCon.Points[idx].ToolTip = when + "contributions after tax and fees " + Money(RunCon);
                sEar.Points[idx].ToolTip = when + "earnings " + Money(RunEar)
                                         + "   -   balance " + Money(r.Balance);
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
