namespace FinancialBalance
{
    partial class Dividend_Snowball_Calculator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dividend_Snowball_Calculator));
            this.Label21 = new System.Windows.Forms.Label();
            this.Lbl_txtStartingValue = new System.Windows.Forms.Label();
            this.txtStartingValue = new System.Windows.Forms.TextBox();
            this.Lbl_txtContribution = new System.Windows.Forms.Label();
            this.txtContribution = new System.Windows.Forms.TextBox();
            this.Lbl_CmbContributionFreq = new System.Windows.Forms.Label();
            this.CmbContributionFreq = new System.Windows.Forms.ComboBox();
            this.Lbl_txtContributionIncrease = new System.Windows.Forms.Label();
            this.txtContributionIncrease = new System.Windows.Forms.TextBox();
            this.LblIncreaseMax = new System.Windows.Forms.Label();
            this.Lbl_txtStartingYield = new System.Windows.Forms.Label();
            this.txtStartingYield = new System.Windows.Forms.TextBox();
            this.LblYieldMax = new System.Windows.Forms.Label();
            this.Lbl_txtDividendGrowth = new System.Windows.Forms.Label();
            this.txtDividendGrowth = new System.Windows.Forms.TextBox();
            this.LblDividendGrowthMax = new System.Windows.Forms.Label();
            this.Lbl_txtPortfolioGrowth = new System.Windows.Forms.Label();
            this.txtPortfolioGrowth = new System.Windows.Forms.TextBox();
            this.LblPortfolioGrowthMax = new System.Windows.Forms.Label();
            this.Lbl_CmbReinvested = new System.Windows.Forms.Label();
            this.CmbReinvested = new System.Windows.Forms.ComboBox();
            this.Lbl_txtYears = new System.Windows.Forms.Label();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.LblYearsMax = new System.Windows.Forms.Label();
            this.Lbl_txtTarget = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.LblTargetHint = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvYears = new System.Windows.Forms.DataGridView();
            this.Lbl_LblSumContribution = new System.Windows.Forms.Label();
            this.LblSumContribution = new System.Windows.Forms.Label();
            this.Lbl_LblSumMonthlyDividend = new System.Windows.Forms.Label();
            this.LblSumMonthlyDividend = new System.Windows.Forms.Label();
            this.Lbl_LblSumAnnualDividend = new System.Windows.Forms.Label();
            this.LblSumAnnualDividend = new System.Windows.Forms.Label();
            this.Lbl_LblSumYearsToTarget = new System.Windows.Forms.Label();
            this.LblSumYearsToTarget = new System.Windows.Forms.Label();
            this.Lbl_LblSumPortfolio = new System.Windows.Forms.Label();
            this.LblSumPortfolio = new System.Windows.Forms.Label();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvYears)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 26);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(1224, 32);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "DIVIDEND SNOWBALL CALCULATOR";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Lbl_txtStartingValue
            //
            this.Lbl_txtStartingValue.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtStartingValue.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtStartingValue.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtStartingValue.Location = new System.Drawing.Point(19, 82);
            this.Lbl_txtStartingValue.Name = "Lbl_txtStartingValue";
            this.Lbl_txtStartingValue.Size = new System.Drawing.Size(210, 20);
            this.Lbl_txtStartingValue.TabIndex = 2;
            this.Lbl_txtStartingValue.Text = "Starting Portfolio Value";
            //
            // txtStartingValue
            //
            this.txtStartingValue.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartingValue.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartingValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartingValue.Location = new System.Drawing.Point(235, 80);
            this.txtStartingValue.MaxLength = 20;
            this.txtStartingValue.Name = "txtStartingValue";
            this.txtStartingValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStartingValue.Size = new System.Drawing.Size(130, 20);
            this.txtStartingValue.TabIndex = 3;
            this.txtStartingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartingValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtStartingValue.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // Lbl_txtContribution
            //
            this.Lbl_txtContribution.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtContribution.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtContribution.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtContribution.Location = new System.Drawing.Point(19, 112);
            this.Lbl_txtContribution.Name = "Lbl_txtContribution";
            this.Lbl_txtContribution.Size = new System.Drawing.Size(210, 20);
            this.Lbl_txtContribution.TabIndex = 4;
            this.Lbl_txtContribution.Text = "Contribution Amount";
            //
            // txtContribution
            //
            this.txtContribution.BackColor = System.Drawing.SystemColors.Window;
            this.txtContribution.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContribution.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContribution.Location = new System.Drawing.Point(235, 110);
            this.txtContribution.MaxLength = 20;
            this.txtContribution.Name = "txtContribution";
            this.txtContribution.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtContribution.Size = new System.Drawing.Size(130, 20);
            this.txtContribution.TabIndex = 5;
            this.txtContribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtContribution.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtContribution.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // Lbl_CmbContributionFreq
            //
            this.Lbl_CmbContributionFreq.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbContributionFreq.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbContributionFreq.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbContributionFreq.Location = new System.Drawing.Point(19, 142);
            this.Lbl_CmbContributionFreq.Name = "Lbl_CmbContributionFreq";
            this.Lbl_CmbContributionFreq.Size = new System.Drawing.Size(210, 20);
            this.Lbl_CmbContributionFreq.TabIndex = 6;
            this.Lbl_CmbContributionFreq.Text = "Contribution Frequency";
            //
            // CmbContributionFreq
            //
            this.CmbContributionFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbContributionFreq.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbContributionFreq.FormattingEnabled = true;
            this.CmbContributionFreq.Location = new System.Drawing.Point(235, 138);
            this.CmbContributionFreq.Name = "CmbContributionFreq";
            this.CmbContributionFreq.Size = new System.Drawing.Size(130, 22);
            this.CmbContributionFreq.TabIndex = 7;
            this.CmbContributionFreq.SelectedIndexChanged += new System.EventHandler(this.Input_Changed);
            //
            // Lbl_txtContributionIncrease
            //
            this.Lbl_txtContributionIncrease.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtContributionIncrease.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtContributionIncrease.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtContributionIncrease.Location = new System.Drawing.Point(19, 172);
            this.Lbl_txtContributionIncrease.Name = "Lbl_txtContributionIncrease";
            this.Lbl_txtContributionIncrease.Size = new System.Drawing.Size(210, 20);
            this.Lbl_txtContributionIncrease.TabIndex = 8;
            this.Lbl_txtContributionIncrease.Text = "Annual Increase in Contribution";
            //
            // txtContributionIncrease
            //
            this.txtContributionIncrease.BackColor = System.Drawing.SystemColors.Window;
            this.txtContributionIncrease.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContributionIncrease.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContributionIncrease.Location = new System.Drawing.Point(235, 170);
            this.txtContributionIncrease.MaxLength = 20;
            this.txtContributionIncrease.Name = "txtContributionIncrease";
            this.txtContributionIncrease.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtContributionIncrease.Size = new System.Drawing.Size(130, 20);
            this.txtContributionIncrease.TabIndex = 9;
            this.txtContributionIncrease.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtContributionIncrease.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtContributionIncrease.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // LblIncreaseMax
            //
            this.LblIncreaseMax.BackColor = System.Drawing.Color.Transparent;
            this.LblIncreaseMax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIncreaseMax.ForeColor = System.Drawing.Color.DimGray;
            this.LblIncreaseMax.Location = new System.Drawing.Point(372, 172);
            this.LblIncreaseMax.Name = "LblIncreaseMax";
            this.LblIncreaseMax.Size = new System.Drawing.Size(110, 20);
            this.LblIncreaseMax.TabIndex = 10;
            this.LblIncreaseMax.Text = "0 to 100 %";
            //
            // Lbl_txtStartingYield
            //
            this.Lbl_txtStartingYield.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtStartingYield.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtStartingYield.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtStartingYield.Location = new System.Drawing.Point(19, 202);
            this.Lbl_txtStartingYield.Name = "Lbl_txtStartingYield";
            this.Lbl_txtStartingYield.Size = new System.Drawing.Size(210, 20);
            this.Lbl_txtStartingYield.TabIndex = 11;
            this.Lbl_txtStartingYield.Text = "Starting Dividend Yield";
            //
            // txtStartingYield
            //
            this.txtStartingYield.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartingYield.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartingYield.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartingYield.Location = new System.Drawing.Point(235, 200);
            this.txtStartingYield.MaxLength = 20;
            this.txtStartingYield.Name = "txtStartingYield";
            this.txtStartingYield.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStartingYield.Size = new System.Drawing.Size(130, 20);
            this.txtStartingYield.TabIndex = 12;
            this.txtStartingYield.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartingYield.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtStartingYield.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // LblYieldMax
            //
            this.LblYieldMax.BackColor = System.Drawing.Color.Transparent;
            this.LblYieldMax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYieldMax.ForeColor = System.Drawing.Color.DimGray;
            this.LblYieldMax.Location = new System.Drawing.Point(372, 202);
            this.LblYieldMax.Name = "LblYieldMax";
            this.LblYieldMax.Size = new System.Drawing.Size(110, 20);
            this.LblYieldMax.TabIndex = 13;
            this.LblYieldMax.Text = "0 to 100 %";
            //
            // Lbl_txtDividendGrowth
            //
            this.Lbl_txtDividendGrowth.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtDividendGrowth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtDividendGrowth.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtDividendGrowth.Location = new System.Drawing.Point(520, 82);
            this.Lbl_txtDividendGrowth.Name = "Lbl_txtDividendGrowth";
            this.Lbl_txtDividendGrowth.Size = new System.Drawing.Size(230, 20);
            this.Lbl_txtDividendGrowth.TabIndex = 14;
            this.Lbl_txtDividendGrowth.Text = "Annual Dividend Growth Rate";
            //
            // txtDividendGrowth
            //
            this.txtDividendGrowth.BackColor = System.Drawing.SystemColors.Window;
            this.txtDividendGrowth.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDividendGrowth.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDividendGrowth.Location = new System.Drawing.Point(756, 80);
            this.txtDividendGrowth.MaxLength = 20;
            this.txtDividendGrowth.Name = "txtDividendGrowth";
            this.txtDividendGrowth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDividendGrowth.Size = new System.Drawing.Size(130, 20);
            this.txtDividendGrowth.TabIndex = 15;
            this.txtDividendGrowth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDividendGrowth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtDividendGrowth.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // LblDividendGrowthMax
            //
            this.LblDividendGrowthMax.BackColor = System.Drawing.Color.Transparent;
            this.LblDividendGrowthMax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDividendGrowthMax.ForeColor = System.Drawing.Color.DimGray;
            this.LblDividendGrowthMax.Location = new System.Drawing.Point(893, 82);
            this.LblDividendGrowthMax.Name = "LblDividendGrowthMax";
            this.LblDividendGrowthMax.Size = new System.Drawing.Size(130, 20);
            this.LblDividendGrowthMax.TabIndex = 16;
            this.LblDividendGrowthMax.Text = "0 to 100 %";
            //
            // Lbl_txtPortfolioGrowth
            //
            this.Lbl_txtPortfolioGrowth.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtPortfolioGrowth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtPortfolioGrowth.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtPortfolioGrowth.Location = new System.Drawing.Point(520, 112);
            this.Lbl_txtPortfolioGrowth.Name = "Lbl_txtPortfolioGrowth";
            this.Lbl_txtPortfolioGrowth.Size = new System.Drawing.Size(230, 20);
            this.Lbl_txtPortfolioGrowth.TabIndex = 17;
            this.Lbl_txtPortfolioGrowth.Text = "Portfolio Growth Rate";
            //
            // txtPortfolioGrowth
            //
            this.txtPortfolioGrowth.BackColor = System.Drawing.SystemColors.Window;
            this.txtPortfolioGrowth.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPortfolioGrowth.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPortfolioGrowth.Location = new System.Drawing.Point(756, 110);
            this.txtPortfolioGrowth.MaxLength = 20;
            this.txtPortfolioGrowth.Name = "txtPortfolioGrowth";
            this.txtPortfolioGrowth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPortfolioGrowth.Size = new System.Drawing.Size(130, 20);
            this.txtPortfolioGrowth.TabIndex = 18;
            this.txtPortfolioGrowth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPortfolioGrowth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtPortfolioGrowth.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // LblPortfolioGrowthMax
            //
            this.LblPortfolioGrowthMax.BackColor = System.Drawing.Color.Transparent;
            this.LblPortfolioGrowthMax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPortfolioGrowthMax.ForeColor = System.Drawing.Color.DimGray;
            this.LblPortfolioGrowthMax.Location = new System.Drawing.Point(893, 112);
            this.LblPortfolioGrowthMax.Name = "LblPortfolioGrowthMax";
            this.LblPortfolioGrowthMax.Size = new System.Drawing.Size(130, 20);
            this.LblPortfolioGrowthMax.TabIndex = 19;
            this.LblPortfolioGrowthMax.Text = "0 to 100 %";
            //
            // Lbl_CmbReinvested
            //
            this.Lbl_CmbReinvested.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbReinvested.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbReinvested.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbReinvested.Location = new System.Drawing.Point(520, 142);
            this.Lbl_CmbReinvested.Name = "Lbl_CmbReinvested";
            this.Lbl_CmbReinvested.Size = new System.Drawing.Size(230, 20);
            this.Lbl_CmbReinvested.TabIndex = 20;
            this.Lbl_CmbReinvested.Text = "Dividend Reinvested";
            //
            // CmbReinvested
            //
            this.CmbReinvested.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbReinvested.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbReinvested.FormattingEnabled = true;
            this.CmbReinvested.Location = new System.Drawing.Point(756, 138);
            this.CmbReinvested.Name = "CmbReinvested";
            this.CmbReinvested.Size = new System.Drawing.Size(130, 22);
            this.CmbReinvested.TabIndex = 21;
            this.CmbReinvested.SelectedIndexChanged += new System.EventHandler(this.Input_Changed);
            //
            // Lbl_txtYears
            //
            this.Lbl_txtYears.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtYears.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtYears.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtYears.Location = new System.Drawing.Point(520, 172);
            this.Lbl_txtYears.Name = "Lbl_txtYears";
            this.Lbl_txtYears.Size = new System.Drawing.Size(230, 20);
            this.Lbl_txtYears.TabIndex = 22;
            this.Lbl_txtYears.Text = "Time Horizon";
            //
            // txtYears
            //
            this.txtYears.BackColor = System.Drawing.SystemColors.Window;
            this.txtYears.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYears.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYears.Location = new System.Drawing.Point(756, 170);
            this.txtYears.MaxLength = 20;
            this.txtYears.Name = "txtYears";
            this.txtYears.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYears.Size = new System.Drawing.Size(130, 20);
            this.txtYears.TabIndex = 23;
            this.txtYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYears.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Whole_KeyPress);
            this.txtYears.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // LblYearsMax
            //
            this.LblYearsMax.BackColor = System.Drawing.Color.Transparent;
            this.LblYearsMax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYearsMax.ForeColor = System.Drawing.Color.DimGray;
            this.LblYearsMax.Location = new System.Drawing.Point(893, 172);
            this.LblYearsMax.Name = "LblYearsMax";
            this.LblYearsMax.Size = new System.Drawing.Size(130, 20);
            this.LblYearsMax.TabIndex = 24;
            this.LblYearsMax.Text = "1 to 50 years";
            //
            // Lbl_txtTarget
            //
            this.Lbl_txtTarget.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtTarget.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtTarget.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtTarget.Location = new System.Drawing.Point(520, 202);
            this.Lbl_txtTarget.Name = "Lbl_txtTarget";
            this.Lbl_txtTarget.Size = new System.Drawing.Size(230, 20);
            this.Lbl_txtTarget.TabIndex = 25;
            this.Lbl_txtTarget.Text = "Target Annual Dividend Income";
            //
            // txtTarget
            //
            this.txtTarget.BackColor = System.Drawing.SystemColors.Window;
            this.txtTarget.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarget.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTarget.Location = new System.Drawing.Point(756, 200);
            this.txtTarget.MaxLength = 20;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTarget.Size = new System.Drawing.Size(130, 20);
            this.txtTarget.TabIndex = 26;
            this.txtTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtTarget.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // LblTargetHint
            //
            this.LblTargetHint.BackColor = System.Drawing.Color.Transparent;
            this.LblTargetHint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTargetHint.ForeColor = System.Drawing.Color.DimGray;
            this.LblTargetHint.Location = new System.Drawing.Point(893, 202);
            this.LblTargetHint.Name = "LblTargetHint";
            this.LblTargetHint.Size = new System.Drawing.Size(130, 20);
            this.LblTargetHint.TabIndex = 27;
            this.LblTargetHint.Text = "optional";
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 232);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1226, 44);
            this.LblNote.TabIndex = 28;
            //
            // gvYears
            //
            this.gvYears.AllowUserToAddRows = false;
            this.gvYears.AllowUserToDeleteRows = false;
            this.gvYears.AllowUserToResizeRows = false;
            this.gvYears.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvYears.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvYears.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvYears.Location = new System.Drawing.Point(19, 276);
            this.gvYears.MultiSelect = false;
            this.gvYears.Name = "gvYears";
            this.gvYears.ReadOnly = true;
            this.gvYears.RowHeadersVisible = false;
            this.gvYears.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvYears.Size = new System.Drawing.Size(1226, 238);
            this.gvYears.TabIndex = 29;
            //
            // Lbl_LblSumContribution
            //
            this.Lbl_LblSumContribution.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumContribution.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumContribution.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblSumContribution.Location = new System.Drawing.Point(19, 528);
            this.Lbl_LblSumContribution.Name = "Lbl_LblSumContribution";
            this.Lbl_LblSumContribution.Size = new System.Drawing.Size(230, 20);
            this.Lbl_LblSumContribution.TabIndex = 30;
            this.Lbl_LblSumContribution.Text = "Total Contribution";
            //
            // LblSumContribution
            //
            this.LblSumContribution.BackColor = System.Drawing.Color.Transparent;
            this.LblSumContribution.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumContribution.ForeColor = System.Drawing.Color.Black;
            this.LblSumContribution.Location = new System.Drawing.Point(255, 528);
            this.LblSumContribution.Name = "LblSumContribution";
            this.LblSumContribution.Size = new System.Drawing.Size(200, 20);
            this.LblSumContribution.TabIndex = 31;
            this.LblSumContribution.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_LblSumMonthlyDividend
            //
            this.Lbl_LblSumMonthlyDividend.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumMonthlyDividend.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumMonthlyDividend.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblSumMonthlyDividend.Location = new System.Drawing.Point(520, 528);
            this.Lbl_LblSumMonthlyDividend.Name = "Lbl_LblSumMonthlyDividend";
            this.Lbl_LblSumMonthlyDividend.Size = new System.Drawing.Size(300, 20);
            this.Lbl_LblSumMonthlyDividend.TabIndex = 32;
            this.Lbl_LblSumMonthlyDividend.Text = "Monthly Gross Dividend";
            //
            // LblSumMonthlyDividend
            //
            this.LblSumMonthlyDividend.BackColor = System.Drawing.Color.Transparent;
            this.LblSumMonthlyDividend.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumMonthlyDividend.ForeColor = System.Drawing.Color.Black;
            this.LblSumMonthlyDividend.Location = new System.Drawing.Point(826, 528);
            this.LblSumMonthlyDividend.Name = "LblSumMonthlyDividend";
            this.LblSumMonthlyDividend.Size = new System.Drawing.Size(210, 20);
            this.LblSumMonthlyDividend.TabIndex = 33;
            this.LblSumMonthlyDividend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_LblSumAnnualDividend
            //
            this.Lbl_LblSumAnnualDividend.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumAnnualDividend.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumAnnualDividend.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblSumAnnualDividend.Location = new System.Drawing.Point(19, 558);
            this.Lbl_LblSumAnnualDividend.Name = "Lbl_LblSumAnnualDividend";
            this.Lbl_LblSumAnnualDividend.Size = new System.Drawing.Size(230, 20);
            this.Lbl_LblSumAnnualDividend.TabIndex = 34;
            this.Lbl_LblSumAnnualDividend.Text = "Annual Gross Dividend";
            //
            // LblSumAnnualDividend
            //
            this.LblSumAnnualDividend.BackColor = System.Drawing.Color.Transparent;
            this.LblSumAnnualDividend.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumAnnualDividend.ForeColor = System.Drawing.Color.Black;
            this.LblSumAnnualDividend.Location = new System.Drawing.Point(255, 558);
            this.LblSumAnnualDividend.Name = "LblSumAnnualDividend";
            this.LblSumAnnualDividend.Size = new System.Drawing.Size(200, 20);
            this.LblSumAnnualDividend.TabIndex = 35;
            this.LblSumAnnualDividend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_LblSumYearsToTarget
            //
            this.Lbl_LblSumYearsToTarget.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumYearsToTarget.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumYearsToTarget.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblSumYearsToTarget.Location = new System.Drawing.Point(520, 558);
            this.Lbl_LblSumYearsToTarget.Name = "Lbl_LblSumYearsToTarget";
            this.Lbl_LblSumYearsToTarget.Size = new System.Drawing.Size(300, 20);
            this.Lbl_LblSumYearsToTarget.TabIndex = 36;
            this.Lbl_LblSumYearsToTarget.Text = "Years to reach Target Annual Dividend Income";
            //
            // LblSumYearsToTarget
            //
            this.LblSumYearsToTarget.BackColor = System.Drawing.Color.Transparent;
            this.LblSumYearsToTarget.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumYearsToTarget.ForeColor = System.Drawing.Color.Black;
            this.LblSumYearsToTarget.Location = new System.Drawing.Point(826, 558);
            this.LblSumYearsToTarget.Name = "LblSumYearsToTarget";
            this.LblSumYearsToTarget.Size = new System.Drawing.Size(210, 20);
            this.LblSumYearsToTarget.TabIndex = 37;
            this.LblSumYearsToTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_LblSumPortfolio
            //
            this.Lbl_LblSumPortfolio.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumPortfolio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumPortfolio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Lbl_LblSumPortfolio.Location = new System.Drawing.Point(19, 594);
            this.Lbl_LblSumPortfolio.Name = "Lbl_LblSumPortfolio";
            this.Lbl_LblSumPortfolio.Size = new System.Drawing.Size(230, 24);
            this.Lbl_LblSumPortfolio.TabIndex = 38;
            this.Lbl_LblSumPortfolio.Text = "Portfolio Value";
            //
            // LblSumPortfolio
            //
            this.LblSumPortfolio.BackColor = System.Drawing.Color.Transparent;
            this.LblSumPortfolio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumPortfolio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblSumPortfolio.Location = new System.Drawing.Point(255, 594);
            this.LblSumPortfolio.Name = "LblSumPortfolio";
            this.LblSumPortfolio.Size = new System.Drawing.Size(200, 24);
            this.LblSumPortfolio.TabIndex = 39;
            this.LblSumPortfolio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(1134, 662);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 40;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Dividend_Snowball_Calculator
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1264, 700);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblSumPortfolio);
            this.Controls.Add(this.Lbl_LblSumPortfolio);
            this.Controls.Add(this.LblSumYearsToTarget);
            this.Controls.Add(this.Lbl_LblSumYearsToTarget);
            this.Controls.Add(this.LblSumAnnualDividend);
            this.Controls.Add(this.Lbl_LblSumAnnualDividend);
            this.Controls.Add(this.LblSumMonthlyDividend);
            this.Controls.Add(this.Lbl_LblSumMonthlyDividend);
            this.Controls.Add(this.LblSumContribution);
            this.Controls.Add(this.Lbl_LblSumContribution);
            this.Controls.Add(this.gvYears);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.LblTargetHint);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.Lbl_txtTarget);
            this.Controls.Add(this.LblYearsMax);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.Lbl_txtYears);
            this.Controls.Add(this.CmbReinvested);
            this.Controls.Add(this.Lbl_CmbReinvested);
            this.Controls.Add(this.LblPortfolioGrowthMax);
            this.Controls.Add(this.txtPortfolioGrowth);
            this.Controls.Add(this.Lbl_txtPortfolioGrowth);
            this.Controls.Add(this.LblDividendGrowthMax);
            this.Controls.Add(this.txtDividendGrowth);
            this.Controls.Add(this.Lbl_txtDividendGrowth);
            this.Controls.Add(this.LblYieldMax);
            this.Controls.Add(this.txtStartingYield);
            this.Controls.Add(this.Lbl_txtStartingYield);
            this.Controls.Add(this.LblIncreaseMax);
            this.Controls.Add(this.txtContributionIncrease);
            this.Controls.Add(this.Lbl_txtContributionIncrease);
            this.Controls.Add(this.CmbContributionFreq);
            this.Controls.Add(this.Lbl_CmbContributionFreq);
            this.Controls.Add(this.txtContribution);
            this.Controls.Add(this.Lbl_txtContribution);
            this.Controls.Add(this.txtStartingValue);
            this.Controls.Add(this.Lbl_txtStartingValue);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "Dividend_Snowball_Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dividend Snowball Calculator";
            this.Load += new System.EventHandler(this.Dividend_Snowball_Calculator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvYears)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Lbl_txtStartingValue;
        public System.Windows.Forms.TextBox txtStartingValue;
        public System.Windows.Forms.Label Lbl_txtContribution;
        public System.Windows.Forms.TextBox txtContribution;
        public System.Windows.Forms.Label Lbl_CmbContributionFreq;
        public System.Windows.Forms.ComboBox CmbContributionFreq;
        public System.Windows.Forms.Label Lbl_txtContributionIncrease;
        public System.Windows.Forms.TextBox txtContributionIncrease;
        public System.Windows.Forms.Label LblIncreaseMax;
        public System.Windows.Forms.Label Lbl_txtStartingYield;
        public System.Windows.Forms.TextBox txtStartingYield;
        public System.Windows.Forms.Label LblYieldMax;
        public System.Windows.Forms.Label Lbl_txtDividendGrowth;
        public System.Windows.Forms.TextBox txtDividendGrowth;
        public System.Windows.Forms.Label LblDividendGrowthMax;
        public System.Windows.Forms.Label Lbl_txtPortfolioGrowth;
        public System.Windows.Forms.TextBox txtPortfolioGrowth;
        public System.Windows.Forms.Label LblPortfolioGrowthMax;
        public System.Windows.Forms.Label Lbl_CmbReinvested;
        public System.Windows.Forms.ComboBox CmbReinvested;
        public System.Windows.Forms.Label Lbl_txtYears;
        public System.Windows.Forms.TextBox txtYears;
        public System.Windows.Forms.Label LblYearsMax;
        public System.Windows.Forms.Label Lbl_txtTarget;
        public System.Windows.Forms.TextBox txtTarget;
        public System.Windows.Forms.Label LblTargetHint;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvYears;
        public System.Windows.Forms.Label Lbl_LblSumContribution;
        public System.Windows.Forms.Label LblSumContribution;
        public System.Windows.Forms.Label Lbl_LblSumMonthlyDividend;
        public System.Windows.Forms.Label LblSumMonthlyDividend;
        public System.Windows.Forms.Label Lbl_LblSumAnnualDividend;
        public System.Windows.Forms.Label LblSumAnnualDividend;
        public System.Windows.Forms.Label Lbl_LblSumYearsToTarget;
        public System.Windows.Forms.Label LblSumYearsToTarget;
        public System.Windows.Forms.Label Lbl_LblSumPortfolio;
        public System.Windows.Forms.Label LblSumPortfolio;
        public System.Windows.Forms.Button CmdBack;
    }
}
