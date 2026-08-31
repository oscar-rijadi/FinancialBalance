namespace FinancialBalance
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.MnDailyInput = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.MnInquiry = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyInq = new System.Windows.Forms.ToolStripMenuItem();
            this.MnYearStat = new System.Windows.Forms.ToolStripMenuItem();
            this.MnYearSumm = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrRateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnActivaPassivaSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblVer = new System.Windows.Forms.Label();
            this.DateTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.box0 = new System.Windows.Forms.Label();
            this.box1 = new System.Windows.Forms.Label();
            this.box2 = new System.Windows.Forms.Label();
            this.box3 = new System.Windows.Forms.Label();
            this.box4 = new System.Windows.Forms.Label();
            this.box5 = new System.Windows.Forms.Label();
            this.box6 = new System.Windows.Forms.Label();
            this.box7 = new System.Windows.Forms.Label();
            this.box8 = new System.Windows.Forms.Label();
            this.box9 = new System.Windows.Forms.Label();
            this.box10 = new System.Windows.Forms.Label();
            this.box11 = new System.Windows.Forms.Label();
            this.box12 = new System.Windows.Forms.Label();
            this.box13 = new System.Windows.Forms.Label();
            this.box14 = new System.Windows.Forms.Label();
            this.box15 = new System.Windows.Forms.Label();
            this.box24 = new System.Windows.Forms.Label();
            this.box25 = new System.Windows.Forms.Label();
            this.box26 = new System.Windows.Forms.Label();
            this.box27 = new System.Windows.Forms.Label();
            this.box28 = new System.Windows.Forms.Label();
            this.box29 = new System.Windows.Forms.Label();
            this.box210 = new System.Windows.Forms.Label();
            this.MainMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnProcess,
            this.MnInquiry,
            this.MnAdmin,
            this.MnExit});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(573, 24);
            this.MainMenu1.TabIndex = 25;
            // 
            // MnProcess
            // 
            this.MnProcess.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDailyInput,
            this.MnMonthlyClosing,
            this.MnETFStocksTrans});
            this.MnProcess.Name = "MnProcess";
            this.MnProcess.Size = new System.Drawing.Size(56, 20);
            this.MnProcess.Text = "&Process";
            // 
            // MnDailyInput
            // 
            this.MnDailyInput.Name = "MnDailyInput";
            this.MnDailyInput.Size = new System.Drawing.Size(160, 22);
            this.MnDailyInput.Text = "&Daily Input";
            this.MnDailyInput.Click += new System.EventHandler(this.MnDailyInput_Click);
            // 
            // MnMonthlyClosing
            // 
            this.MnMonthlyClosing.Name = "MnMonthlyClosing";
            this.MnMonthlyClosing.Size = new System.Drawing.Size(160, 22);
            this.MnMonthlyClosing.Text = "&Monthly Closing";
            this.MnMonthlyClosing.Click += new System.EventHandler(this.MnMonthlyClosing_Click);
            // 
            // MnETFStocksTrans
            // 
            this.MnETFStocksTrans.Name = "MnETFStocksTrans";
            this.MnETFStocksTrans.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksTrans.Text = "ETF/Stock &Transaction";
            this.MnETFStocksTrans.Click += new System.EventHandler(this.MnETFStocksTrans_Click);
            // 
            // MnInquiry
            // 
            this.MnInquiry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnMonthlyInq,
            this.MnYearStat,
            this.MnYearSumm});
            this.MnInquiry.Name = "MnInquiry";
            this.MnInquiry.Size = new System.Drawing.Size(53, 20);
            this.MnInquiry.Text = "&Inquiry";
            // 
            // MnMonthlyInq
            // 
            this.MnMonthlyInq.Name = "MnMonthlyInq";
            this.MnMonthlyInq.Size = new System.Drawing.Size(162, 22);
            this.MnMonthlyInq.Text = "&Monthly Inquiry";
            this.MnMonthlyInq.Click += new System.EventHandler(this.MnMonthlyInq_Click);
            // 
            // MnYearStat
            // 
            this.MnYearStat.Name = "MnYearStat";
            this.MnYearStat.Size = new System.Drawing.Size(162, 22);
            this.MnYearStat.Text = "Yearly S&tatistic";
            this.MnYearStat.Click += new System.EventHandler(this.MnYearStat_Click);
            // 
            // MnYearSumm
            // 
            this.MnYearSumm.Name = "MnYearSumm";
            this.MnYearSumm.Size = new System.Drawing.Size(162, 22);
            this.MnYearSumm.Text = "Yearly S&ummary";
            this.MnYearSumm.Click += new System.EventHandler(this.MnYearSumm_Click);
            // 
            // MnAdmin
            // 
            this.MnAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnAcctTypeRefSetup,
            this.MnAcctRefSetup,
            this.MnCurrSetup,
            this.MnCurrRateSetup,
            this.MnActivaPassivaSetup,
            this.MnETFStocksSuffixSetup,
            this.MnETFStocksSetup});
            this.MnAdmin.Name = "MnAdmin";
            this.MnAdmin.Size = new System.Drawing.Size(87, 20);
            this.MnAdmin.Text = "&Administration";
            // 
            // MnAcctTypeRefSetup
            // 
            this.MnAcctTypeRefSetup.Name = "MnAcctTypeRefSetup";
            this.MnAcctTypeRefSetup.Size = new System.Drawing.Size(216, 22);
            this.MnAcctTypeRefSetup.Text = "Accounting &Type Ref Setup";
            this.MnAcctTypeRefSetup.Click += new System.EventHandler(this.MnAcctTypeRefSetup_Click);
            // 
            // MnAcctRefSetup
            // 
            this.MnAcctRefSetup.Name = "MnAcctRefSetup";
            this.MnAcctRefSetup.Size = new System.Drawing.Size(216, 22);
            this.MnAcctRefSetup.Text = "&Accounting Ref Setup";
            this.MnAcctRefSetup.Click += new System.EventHandler(this.MnAcctRefSetup_Click);
            // 
            // MnCurrSetup
            // 
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(216, 22);
            this.MnCurrSetup.Text = "&Currency Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
            // 
            // MnCurrRateSetup
            // 
            this.MnCurrRateSetup.Name = "MnCurrRateSetup";
            this.MnCurrRateSetup.Size = new System.Drawing.Size(216, 22);
            this.MnCurrRateSetup.Text = "Currency &Rate Setup";
            this.MnCurrRateSetup.Click += new System.EventHandler(this.MnCurrRateSetup_Click);
            // 
            // MnActivaPassivaSetup
            // 
            this.MnActivaPassivaSetup.Name = "MnActivaPassivaSetup";
            this.MnActivaPassivaSetup.Size = new System.Drawing.Size(216, 22);
            this.MnActivaPassivaSetup.Text = "Activa &Passiva Setup";
            this.MnActivaPassivaSetup.Click += new System.EventHandler(this.MnActivaPassivaSetup_Click);
            // 
            // MnETFStocksSuffixSetup
            // 
            this.MnETFStocksSuffixSetup.Name = "MnETFStocksSuffixSetup";
            this.MnETFStocksSuffixSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksSuffixSetup.Text = "&ETF/Stock Suffix Setup";
            this.MnETFStocksSuffixSetup.Click += new System.EventHandler(this.MnETFStocksSuffixSetup_Click);
            // 
            // MnETFStocksSetup
            // 
            this.MnETFStocksSetup.Name = "MnETFStocksSetup";
            this.MnETFStocksSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksSetup.Text = "ETF/&Stock Setup";
            this.MnETFStocksSetup.Click += new System.EventHandler(this.MnETFStocksSetup_Click);
            // 
            // MnExit
            // 
            this.MnExit.Name = "MnExit";
            this.MnExit.Size = new System.Drawing.Size(37, 20);
            this.MnExit.Text = "E&xit";
            this.MnExit.Click += new System.EventHandler(this.MnExit_Click);
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.BackColor = System.Drawing.Color.Transparent;
            this.LblDate.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.LblDate.ForeColor = System.Drawing.Color.Gray;
            this.LblDate.Location = new System.Drawing.Point(280, 24);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(243, 23);
            this.LblDate.TabIndex = 16;
            this.LblDate.Text = "DD/MM/Year HH:MM:SS";
            this.LblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblVer
            // 
            this.LblVer.AutoSize = true;
            this.LblVer.BackColor = System.Drawing.Color.Transparent;
            this.LblVer.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.LblVer.ForeColor = System.Drawing.Color.Gray;
            this.LblVer.Location = new System.Drawing.Point(8, 346);
            this.LblVer.Name = "LblVer";
            this.LblVer.Size = new System.Drawing.Size(77, 18);
            this.LblVer.TabIndex = 24;
            this.LblVer.Text = "v 1.0.0.0";
            // 
            // DateTimeTimer
            // 
            this.DateTimeTimer.Enabled = true;
            this.DateTimeTimer.Interval = 1000;
            this.DateTimeTimer.Tick += new System.EventHandler(this.DateTimeTimer_Tick);
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Enabled = true;
            this.AnimationTimer.Interval = 10;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // box0
            // 
            this.box0.BackColor = System.Drawing.Color.White;
            this.box0.Cursor = System.Windows.Forms.Cursors.Default;
            this.box0.Enabled = false;
            this.box0.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box0.Location = new System.Drawing.Point(24, 176);
            this.box0.Name = "box0";
            this.box0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box0.Size = new System.Drawing.Size(25, 25);
            this.box0.TabIndex = 26;
            this.box0.Text = "M";
            this.box0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box1
            // 
            this.box1.BackColor = System.Drawing.Color.White;
            this.box1.Cursor = System.Windows.Forms.Cursors.Default;
            this.box1.Enabled = false;
            this.box1.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box1.Location = new System.Drawing.Point(56, 176);
            this.box1.Name = "box1";
            this.box1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box1.Size = new System.Drawing.Size(25, 25);
            this.box1.TabIndex = 27;
            this.box1.Text = "O";
            this.box1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box2
            // 
            this.box2.BackColor = System.Drawing.Color.White;
            this.box2.Cursor = System.Windows.Forms.Cursors.Default;
            this.box2.Enabled = false;
            this.box2.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box2.Location = new System.Drawing.Point(88, 176);
            this.box2.Name = "box2";
            this.box2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box2.Size = new System.Drawing.Size(25, 25);
            this.box2.TabIndex = 28;
            this.box2.Text = "N";
            this.box2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box3
            // 
            this.box3.BackColor = System.Drawing.Color.White;
            this.box3.Cursor = System.Windows.Forms.Cursors.Default;
            this.box3.Enabled = false;
            this.box3.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box3.Location = new System.Drawing.Point(120, 176);
            this.box3.Name = "box3";
            this.box3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box3.Size = new System.Drawing.Size(25, 25);
            this.box3.TabIndex = 29;
            this.box3.Text = "T";
            this.box3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box4
            // 
            this.box4.BackColor = System.Drawing.Color.White;
            this.box4.Cursor = System.Windows.Forms.Cursors.Default;
            this.box4.Enabled = false;
            this.box4.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box4.Location = new System.Drawing.Point(152, 176);
            this.box4.Name = "box4";
            this.box4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box4.Size = new System.Drawing.Size(25, 25);
            this.box4.TabIndex = 30;
            this.box4.Text = "H";
            this.box4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box5
            // 
            this.box5.BackColor = System.Drawing.Color.White;
            this.box5.Cursor = System.Windows.Forms.Cursors.Default;
            this.box5.Enabled = false;
            this.box5.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box5.Location = new System.Drawing.Point(184, 176);
            this.box5.Name = "box5";
            this.box5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box5.Size = new System.Drawing.Size(25, 25);
            this.box5.TabIndex = 31;
            this.box5.Text = "L";
            this.box5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box6
            // 
            this.box6.BackColor = System.Drawing.Color.White;
            this.box6.Cursor = System.Windows.Forms.Cursors.Default;
            this.box6.Enabled = false;
            this.box6.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box6.Location = new System.Drawing.Point(216, 176);
            this.box6.Name = "box6";
            this.box6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box6.Size = new System.Drawing.Size(25, 25);
            this.box6.TabIndex = 32;
            this.box6.Text = "Y";
            this.box6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box7
            // 
            this.box7.BackColor = System.Drawing.Color.White;
            this.box7.Cursor = System.Windows.Forms.Cursors.Default;
            this.box7.Enabled = false;
            this.box7.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box7.Location = new System.Drawing.Point(264, 176);
            this.box7.Name = "box7";
            this.box7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box7.Size = new System.Drawing.Size(25, 25);
            this.box7.TabIndex = 33;
            this.box7.Text = "F";
            this.box7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box8
            // 
            this.box8.BackColor = System.Drawing.Color.White;
            this.box8.Cursor = System.Windows.Forms.Cursors.Default;
            this.box8.Enabled = false;
            this.box8.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box8.Location = new System.Drawing.Point(296, 176);
            this.box8.Name = "box8";
            this.box8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box8.Size = new System.Drawing.Size(25, 25);
            this.box8.TabIndex = 34;
            this.box8.Text = "I";
            this.box8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box9
            // 
            this.box9.BackColor = System.Drawing.Color.White;
            this.box9.Cursor = System.Windows.Forms.Cursors.Default;
            this.box9.Enabled = false;
            this.box9.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box9.Location = new System.Drawing.Point(328, 176);
            this.box9.Name = "box9";
            this.box9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box9.Size = new System.Drawing.Size(25, 25);
            this.box9.TabIndex = 35;
            this.box9.Text = "N";
            this.box9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box10
            // 
            this.box10.BackColor = System.Drawing.Color.White;
            this.box10.Cursor = System.Windows.Forms.Cursors.Default;
            this.box10.Enabled = false;
            this.box10.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box10.Location = new System.Drawing.Point(360, 176);
            this.box10.Name = "box10";
            this.box10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box10.Size = new System.Drawing.Size(25, 25);
            this.box10.TabIndex = 36;
            this.box10.Text = "A";
            this.box10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box11
            // 
            this.box11.BackColor = System.Drawing.Color.White;
            this.box11.Cursor = System.Windows.Forms.Cursors.Default;
            this.box11.Enabled = false;
            this.box11.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box11.Location = new System.Drawing.Point(392, 176);
            this.box11.Name = "box11";
            this.box11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box11.Size = new System.Drawing.Size(25, 25);
            this.box11.TabIndex = 37;
            this.box11.Text = "N";
            this.box11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box12
            // 
            this.box12.BackColor = System.Drawing.Color.White;
            this.box12.Cursor = System.Windows.Forms.Cursors.Default;
            this.box12.Enabled = false;
            this.box12.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box12.Location = new System.Drawing.Point(424, 176);
            this.box12.Name = "box12";
            this.box12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box12.Size = new System.Drawing.Size(25, 25);
            this.box12.TabIndex = 38;
            this.box12.Text = "C";
            this.box12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box13
            // 
            this.box13.BackColor = System.Drawing.Color.White;
            this.box13.Cursor = System.Windows.Forms.Cursors.Default;
            this.box13.Enabled = false;
            this.box13.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box13.Location = new System.Drawing.Point(456, 176);
            this.box13.Name = "box13";
            this.box13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box13.Size = new System.Drawing.Size(25, 25);
            this.box13.TabIndex = 39;
            this.box13.Text = "I";
            this.box13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box14
            // 
            this.box14.BackColor = System.Drawing.Color.White;
            this.box14.Cursor = System.Windows.Forms.Cursors.Default;
            this.box14.Enabled = false;
            this.box14.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box14.Location = new System.Drawing.Point(488, 176);
            this.box14.Name = "box14";
            this.box14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box14.Size = new System.Drawing.Size(25, 25);
            this.box14.TabIndex = 40;
            this.box14.Text = "A";
            this.box14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box15
            // 
            this.box15.BackColor = System.Drawing.Color.White;
            this.box15.Cursor = System.Windows.Forms.Cursors.Default;
            this.box15.Enabled = false;
            this.box15.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box15.Location = new System.Drawing.Point(520, 176);
            this.box15.Name = "box15";
            this.box15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box15.Size = new System.Drawing.Size(25, 25);
            this.box15.TabIndex = 41;
            this.box15.Text = "L";
            this.box15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box24
            // 
            this.box24.BackColor = System.Drawing.Color.White;
            this.box24.Cursor = System.Windows.Forms.Cursors.Default;
            this.box24.Enabled = false;
            this.box24.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box24.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box24.Location = new System.Drawing.Point(152, 208);
            this.box24.Name = "box24";
            this.box24.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box24.Size = new System.Drawing.Size(25, 25);
            this.box24.TabIndex = 42;
            this.box24.Text = "B";
            this.box24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box25
            // 
            this.box25.BackColor = System.Drawing.Color.White;
            this.box25.Cursor = System.Windows.Forms.Cursors.Default;
            this.box25.Enabled = false;
            this.box25.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box25.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box25.Location = new System.Drawing.Point(184, 208);
            this.box25.Name = "box25";
            this.box25.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box25.Size = new System.Drawing.Size(25, 25);
            this.box25.TabIndex = 43;
            this.box25.Text = "A";
            this.box25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box26
            // 
            this.box26.BackColor = System.Drawing.Color.White;
            this.box26.Cursor = System.Windows.Forms.Cursors.Default;
            this.box26.Enabled = false;
            this.box26.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box26.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box26.Location = new System.Drawing.Point(216, 208);
            this.box26.Name = "box26";
            this.box26.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box26.Size = new System.Drawing.Size(25, 25);
            this.box26.TabIndex = 44;
            this.box26.Text = "L";
            this.box26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box27
            // 
            this.box27.BackColor = System.Drawing.Color.White;
            this.box27.Cursor = System.Windows.Forms.Cursors.Default;
            this.box27.Enabled = false;
            this.box27.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box27.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box27.Location = new System.Drawing.Point(264, 208);
            this.box27.Name = "box27";
            this.box27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box27.Size = new System.Drawing.Size(25, 25);
            this.box27.TabIndex = 45;
            this.box27.Text = "A";
            this.box27.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box28
            // 
            this.box28.BackColor = System.Drawing.Color.White;
            this.box28.Cursor = System.Windows.Forms.Cursors.Default;
            this.box28.Enabled = false;
            this.box28.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box28.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box28.Location = new System.Drawing.Point(296, 208);
            this.box28.Name = "box28";
            this.box28.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box28.Size = new System.Drawing.Size(25, 25);
            this.box28.TabIndex = 46;
            this.box28.Text = "N";
            this.box28.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box29
            // 
            this.box29.BackColor = System.Drawing.Color.White;
            this.box29.Cursor = System.Windows.Forms.Cursors.Default;
            this.box29.Enabled = false;
            this.box29.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box29.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box29.Location = new System.Drawing.Point(328, 208);
            this.box29.Name = "box29";
            this.box29.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box29.Size = new System.Drawing.Size(25, 25);
            this.box29.TabIndex = 47;
            this.box29.Text = "C";
            this.box29.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // box210
            // 
            this.box210.BackColor = System.Drawing.Color.White;
            this.box210.Cursor = System.Windows.Forms.Cursors.Default;
            this.box210.Enabled = false;
            this.box210.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box210.ForeColor = System.Drawing.SystemColors.WindowText;
            this.box210.Location = new System.Drawing.Point(360, 208);
            this.box210.Name = "box210";
            this.box210.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box210.Size = new System.Drawing.Size(25, 25);
            this.box210.TabIndex = 48;
            this.box210.Text = "E";
            this.box210.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(573, 363);
            this.ControlBox = false;
            this.Controls.Add(this.box210);
            this.Controls.Add(this.box29);
            this.Controls.Add(this.box28);
            this.Controls.Add(this.box27);
            this.Controls.Add(this.box26);
            this.Controls.Add(this.box25);
            this.Controls.Add(this.box24);
            this.Controls.Add(this.box15);
            this.Controls.Add(this.box14);
            this.Controls.Add(this.box13);
            this.Controls.Add(this.box12);
            this.Controls.Add(this.box11);
            this.Controls.Add(this.box10);
            this.Controls.Add(this.box9);
            this.Controls.Add(this.box8);
            this.Controls.Add(this.box7);
            this.Controls.Add(this.box6);
            this.Controls.Add(this.box5);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.box0);
            this.Controls.Add(this.LblVer);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(4, 42);
            this.MainMenuStrip = this.MainMenu1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Financial Balance";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_Form_KeyPress);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnProcess;
        public System.Windows.Forms.ToolStripMenuItem MnDailyInput;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksTrans;
        public System.Windows.Forms.ToolStripMenuItem MnInquiry;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyInq;
        public System.Windows.Forms.ToolStripMenuItem MnYearStat;
        public System.Windows.Forms.ToolStripMenuItem MnYearSumm;
        public System.Windows.Forms.ToolStripMenuItem MnAdmin;
        public System.Windows.Forms.ToolStripMenuItem MnAcctTypeRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnAcctRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrRateSetup;
        public System.Windows.Forms.ToolStripMenuItem MnActivaPassivaSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSetup;
        public System.Windows.Forms.ToolStripMenuItem MnExit;
        public System.Windows.Forms.Timer DateTimeTimer;
        public System.Windows.Forms.Label LblDate;
        public System.Windows.Forms.Label LblVer;
        public System.Windows.Forms.Timer AnimationTimer;
        public System.Windows.Forms.Label box0;
        public System.Windows.Forms.Label box1;
        public System.Windows.Forms.Label box2;
        public System.Windows.Forms.Label box3;
        public System.Windows.Forms.Label box4;
        public System.Windows.Forms.Label box5;
        public System.Windows.Forms.Label box6;
        public System.Windows.Forms.Label box7;
        public System.Windows.Forms.Label box8;
        public System.Windows.Forms.Label box9;
        public System.Windows.Forms.Label box10;
        public System.Windows.Forms.Label box11;
        public System.Windows.Forms.Label box12;
        public System.Windows.Forms.Label box13;
        public System.Windows.Forms.Label box14;
        public System.Windows.Forms.Label box15;
        public System.Windows.Forms.Label box24;
        public System.Windows.Forms.Label box25;
        public System.Windows.Forms.Label box26;
        public System.Windows.Forms.Label box27;
        public System.Windows.Forms.Label box28;
        public System.Windows.Forms.Label box29;
        public System.Windows.Forms.Label box210;

    }
}

