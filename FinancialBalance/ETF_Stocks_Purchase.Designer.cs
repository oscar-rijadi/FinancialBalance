namespace FinancialBalance
{
    partial class ETF_Stocks_Purchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Purchase));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksCostBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFYRecon = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.LblDateCaption = new System.Windows.Forms.Label();
            this.CmbDD = new System.Windows.Forms.ComboBox();
            this.CmbMM = new System.Windows.Forms.ComboBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.CmdCal = new System.Windows.Forms.Button();
            this.LblDay = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.gvPurchase = new System.Windows.Forms.DataGridView();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.CmbFullTicker = new System.Windows.Forms.ComboBox();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtCostBase = new System.Windows.Forms.TextBox();
            this.txtOriginalCostBase = new System.Windows.Forms.TextBox();
            this.txtOriginalTotalCostBase = new System.Windows.Forms.TextBox();
            this.Lbl_txtOriginalCostBase = new System.Windows.Forms.Label();
            this.Lbl_txtOriginalTotalCostBase = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.txtTotalCostBase = new System.Windows.Forms.TextBox();
            this.txtRealTotalCostBase = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.CmbFlagCode = new System.Windows.Forms.ComboBox();
            this.LblPortfolioDesc = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.CmbSoldDD = new System.Windows.Forms.ComboBox();
            this.CmbSoldMM = new System.Windows.Forms.ComboBox();
            this.CmbSoldYear = new System.Windows.Forms.ComboBox();
            this.CmdSoldCal = new System.Windows.Forms.Button();
            this.chkDRIP = new System.Windows.Forms.CheckBox();
            this.chkSold = new System.Windows.Forms.CheckBox();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchase)).BeginInit();
            this.SuspendLayout();
            //
            // MainMenu1
            //
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDaily,
            this.MnMonthlyClosing,
            this.MnETFStockProcessGroup,
            this.MnPropertyProcessGroup,
            this.MnSuperProcess});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(1000, 24);
            this.MainMenu1.TabIndex = 0;
            //
            // MnDaily
            //
            this.MnDaily.Name = "MnDaily";
            this.MnDaily.Size = new System.Drawing.Size(71, 20);
            this.MnDaily.Text = "Daily &Input";
            this.MnDaily.Click += new System.EventHandler(this.MnDaily_Click);
            //
            // MnMonthlyClosing
            //
            this.MnMonthlyClosing.Name = "MnMonthlyClosing";
            this.MnMonthlyClosing.Size = new System.Drawing.Size(107, 20);
            this.MnMonthlyClosing.Text = "&Monthly Closing";
            this.MnMonthlyClosing.Click += new System.EventHandler(this.MnMonthlyClosing_Click);
            //
            // MnETFStocksCostBase
            //
            this.MnETFStocksCostBase.Name = "MnETFStocksCostBase";
            this.MnETFStocksCostBase.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksCostBase.Text = "ETF/Stock &Cost Base Adjustment";
            this.MnETFStocksCostBase.Click += new System.EventHandler(this.MnETFStocksCostBase_Click);
            //
            // MnETFStockProcessGroup
            //
            this.MnETFStockProcessGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnETFStocksPrice,
            this.MnETFStocksInvestment,
            this.MnETFStocksSale,
            this.MnETFStocksDistribution,
            this.MnETFStocksCostBase,
            this.MnETFStocksFYRecon});
            this.MnETFStockProcessGroup.Name = "MnETFStockProcessGroup";
            this.MnETFStockProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockProcessGroup.Text = "&ETF/Stock";
            // 
            // MnPropertyProcessGroup
            // 
            this.MnPropertyProcessGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnPropertySetup,
            this.MnPropertyPurchase,
            this.MnPropertySale});
            this.MnPropertyProcessGroup.Name = "MnPropertyProcessGroup";
            this.MnPropertyProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnPropertyProcessGroup.Text = "P&roperty";
            // 
            // MnPropertySetup
            // 
            this.MnPropertySetup.Name = "MnPropertySetup";
            this.MnPropertySetup.Size = new System.Drawing.Size(104, 20);
            this.MnPropertySetup.Text = "P&roperty Setup";
            this.MnPropertySetup.Click += new System.EventHandler(this.MnPropertySetup_Click);
            // 
            // MnPropertySale
            // 
            this.MnPropertySale.Name = "MnPropertySale";
            this.MnPropertySale.Size = new System.Drawing.Size(104, 20);
            this.MnPropertySale.Text = "Property Sa&le";
            this.MnPropertySale.Click += new System.EventHandler(this.MnPropertySale_Click);
            // 
            // MnPropertyPurchase
            // 
            this.MnPropertyPurchase.Name = "MnPropertyPurchase";
            this.MnPropertyPurchase.Size = new System.Drawing.Size(104, 20);
            this.MnPropertyPurchase.Text = "Property P&urchase";
            this.MnPropertyPurchase.Click += new System.EventHandler(this.MnPropertyPurchase_Click);
            //
            // MnSuperProcess
            //
            this.MnSuperProcess.Name = "MnSuperProcess";
            this.MnSuperProcess.Size = new System.Drawing.Size(75, 20);
            this.MnSuperProcess.Text = "&Super";
            this.MnSuperProcess.Click += new System.EventHandler(this.MnSuperProcess_Click);
            //
            // MnETFStocksSale
            //
            this.MnETFStocksSale.Name = "MnETFStocksSale";
            this.MnETFStocksSale.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksSale.Text = "ETF/Stock &Sale";
            this.MnETFStocksSale.Click += new System.EventHandler(this.MnETFStocksSale_Click);
            //
            // MnETFStocksPrice
            //
            this.MnETFStocksPrice.Name = "MnETFStocksPrice";
            this.MnETFStocksPrice.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksPrice.Text = "ETF/Stock &Price";
            this.MnETFStocksPrice.Click += new System.EventHandler(this.MnETFStocksPrice_Click);
            //
            // MnETFStocksFYRecon
            //
            this.MnETFStocksFYRecon.Name = "MnETFStocksFYRecon";
            this.MnETFStocksFYRecon.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksFYRecon.Text = "ETF/Stock Financial &Year Reconciliation";
            this.MnETFStocksFYRecon.Click += new System.EventHandler(this.MnETFStocksFYRecon_Click);
            //
            // MnETFStocksDistribution
            //
            this.MnETFStocksDistribution.Name = "MnETFStocksDistribution";
            this.MnETFStocksDistribution.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksDistribution.Text = "ETF/Stock &Distribution/Dividend";
            this.MnETFStocksDistribution.Click += new System.EventHandler(this.MnETFStocksDistribution_Click);
            //
            // MnETFStocksInvestment
            //
            this.MnETFStocksInvestment.Name = "MnETFStocksInvestment";
            this.MnETFStocksInvestment.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksInvestment.Text = "ETF/Stock &Investment";
            this.MnETFStocksInvestment.Click += new System.EventHandler(this.MnETFStocksInvestment_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(280, 28);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(460, 41);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK PURCHASE";
            //
            // LblDateCaption
            //
            this.LblDateCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblDateCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDateCaption.ForeColor = System.Drawing.Color.Black;
            this.LblDateCaption.Location = new System.Drawing.Point(19, 86);
            this.LblDateCaption.Name = "LblDateCaption";
            this.LblDateCaption.Size = new System.Drawing.Size(40, 20);
            this.LblDateCaption.TabIndex = 2;
            this.LblDateCaption.Text = "Date";
            //
            // CmbDD
            //
            this.CmbDD.BackColor = System.Drawing.SystemColors.Window;
            this.CmbDD.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbDD.Location = new System.Drawing.Point(62, 83);
            this.CmbDD.Name = "CmbDD";
            this.CmbDD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbDD.Size = new System.Drawing.Size(41, 22);
            this.CmbDD.TabIndex = 3;
            this.CmbDD.SelectedIndexChanged += new System.EventHandler(this.CmbDD_SelectedIndexChanged);
            //
            // CmbMM
            //
            this.CmbMM.BackColor = System.Drawing.SystemColors.Window;
            this.CmbMM.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbMM.Location = new System.Drawing.Point(112, 83);
            this.CmbMM.Name = "CmbMM";
            this.CmbMM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbMM.Size = new System.Drawing.Size(41, 22);
            this.CmbMM.TabIndex = 4;
            this.CmbMM.SelectedIndexChanged += new System.EventHandler(this.CmbMM_SelectedIndexChanged);
            //
            // CmbYear
            //
            this.CmbYear.BackColor = System.Drawing.SystemColors.Window;
            this.CmbYear.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbYear.Location = new System.Drawing.Point(162, 83);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 5;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            //
            // CmdCal
            //
            this.CmdCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCal.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCal.Location = new System.Drawing.Point(226, 83);
            this.CmdCal.Name = "CmdCal";
            this.CmdCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdCal.Size = new System.Drawing.Size(25, 19);
            this.CmdCal.TabIndex = 6;
            this.CmdCal.Text = "..";
            this.CmdCal.UseVisualStyleBackColor = false;
            this.CmdCal.Click += new System.EventHandler(this.CmdCal_Click);
            //
            // LblDay
            //
            this.LblDay.BackColor = System.Drawing.Color.Transparent;
            this.LblDay.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblDay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblDay.Location = new System.Drawing.Point(262, 86);
            this.LblDay.Name = "LblDay";
            this.LblDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDay.Size = new System.Drawing.Size(91, 17);
            this.LblDay.TabIndex = 7;
            this.LblDay.Text = "Monday";
            //
            // monthCalendar1
            //
            this.monthCalendar1.Location = new System.Drawing.Point(400, 83);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            //
            // gvPurchase
            //
            this.gvPurchase.AllowUserToAddRows = false;
            this.gvPurchase.AllowUserToDeleteRows = false;
            this.gvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPurchase.Location = new System.Drawing.Point(19, 115);
            this.gvPurchase.MultiSelect = false;
            this.gvPurchase.Name = "gvPurchase";
            this.gvPurchase.ReadOnly = true;
            this.gvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPurchase.Size = new System.Drawing.Size(960, 260);
            this.gvPurchase.TabIndex = 9;
            this.gvPurchase.SelectionChanged += new System.EventHandler(this.gvPurchase_SelectionChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(19, 392);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(125, 22);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Full Ticker";
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(19, 420);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(125, 22);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Currency";
            //
            // Label4
            //
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(19, 448);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(125, 22);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Unit";
            //
            // Label5
            //
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(460, 420);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(160, 22);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Cost Base";
            //
            // Label6
            //
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(460, 448);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(160, 22);
            this.Label6.TabIndex = 15;
            this.Label6.Text = "Fee";
            //
            // Label7
            //
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(460, 504);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(160, 22);
            this.Label7.TabIndex = 16;
            this.Label7.Text = "Total Cost Base";
            //
            // Label8
            //
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(460, 532);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(160, 22);
            this.Label8.TabIndex = 17;
            this.Label8.Text = "Real Total Cost Base";
            //
            // CmbFullTicker
            //
            this.CmbFullTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFullTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFullTicker.FormattingEnabled = true;
            this.CmbFullTicker.Location = new System.Drawing.Point(150, 392);
            this.CmbFullTicker.Name = "CmbFullTicker";
            this.CmbFullTicker.Size = new System.Drawing.Size(140, 22);
            this.CmbFullTicker.TabIndex = 19;
            //
            // CmbCurrency
            //
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(150, 420);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(140, 22);
            this.CmbCurrency.TabIndex = 20;
            //
            // txtUnit
            //
            this.txtUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtUnit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnit.Location = new System.Drawing.Point(150, 448);
            this.txtUnit.MaxLength = 20;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnit.Size = new System.Drawing.Size(140, 20);
            this.txtUnit.TabIndex = 21;
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnit.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            this.txtUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnit_KeyPress);
            //
            // Lbl_txtOriginalCostBase
            //
            this.Lbl_txtOriginalCostBase.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOriginalCostBase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOriginalCostBase.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOriginalCostBase.Location = new System.Drawing.Point(460, 392);
            this.Lbl_txtOriginalCostBase.Name = "Lbl_txtOriginalCostBase";
            this.Lbl_txtOriginalCostBase.Size = new System.Drawing.Size(160, 22);
            this.Lbl_txtOriginalCostBase.TabIndex = 70;
            this.Lbl_txtOriginalCostBase.Text = "Original Cost Base";
            //
            // txtOriginalCostBase
            //
            this.txtOriginalCostBase.BackColor = System.Drawing.SystemColors.Window;
            this.txtOriginalCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOriginalCostBase.Location = new System.Drawing.Point(625, 392);
            this.txtOriginalCostBase.MaxLength = 20;
            this.txtOriginalCostBase.Name = "txtOriginalCostBase";
            this.txtOriginalCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOriginalCostBase.Size = new System.Drawing.Size(140, 20);
            this.txtOriginalCostBase.TabIndex = 22;
            this.txtOriginalCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOriginalCostBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOriginalCostBase_KeyPress);
            this.txtOriginalCostBase.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            //
            // Lbl_txtOriginalTotalCostBase
            //
            this.Lbl_txtOriginalTotalCostBase.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOriginalTotalCostBase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOriginalTotalCostBase.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOriginalTotalCostBase.Location = new System.Drawing.Point(460, 476);
            this.Lbl_txtOriginalTotalCostBase.Name = "Lbl_txtOriginalTotalCostBase";
            this.Lbl_txtOriginalTotalCostBase.Size = new System.Drawing.Size(160, 22);
            this.Lbl_txtOriginalTotalCostBase.TabIndex = 72;
            this.Lbl_txtOriginalTotalCostBase.Text = "Original Total Cost Base";
            //
            // txtOriginalTotalCostBase
            //
            this.txtOriginalTotalCostBase.BackColor = System.Drawing.SystemColors.Control;
            this.txtOriginalTotalCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalTotalCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOriginalTotalCostBase.Location = new System.Drawing.Point(625, 476);
            this.txtOriginalTotalCostBase.Name = "txtOriginalTotalCostBase";
            this.txtOriginalTotalCostBase.ReadOnly = true;
            this.txtOriginalTotalCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOriginalTotalCostBase.Size = new System.Drawing.Size(140, 20);
            this.txtOriginalTotalCostBase.TabIndex = 26;
            this.txtOriginalTotalCostBase.TabStop = false;
            this.txtOriginalTotalCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // txtCostBase
            //
            this.txtCostBase.BackColor = System.Drawing.SystemColors.Window;
            this.txtCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCostBase.Location = new System.Drawing.Point(625, 420);
            this.txtCostBase.MaxLength = 20;
            this.txtCostBase.Name = "txtCostBase";
            this.txtCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCostBase.Size = new System.Drawing.Size(140, 20);
            this.txtCostBase.TabIndex = 24;
            this.txtCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostBase.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            this.txtCostBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostBase_KeyPress);
            //
            // txtFee
            //
            this.txtFee.BackColor = System.Drawing.SystemColors.Window;
            this.txtFee.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFee.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFee.Location = new System.Drawing.Point(625, 448);
            this.txtFee.MaxLength = 20;
            this.txtFee.Name = "txtFee";
            this.txtFee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFee.Size = new System.Drawing.Size(140, 20);
            this.txtFee.TabIndex = 25;
            this.txtFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFee.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            this.txtFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFee_KeyPress);
            //
            // txtTotalCostBase
            //
            this.txtTotalCostBase.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalCostBase.Location = new System.Drawing.Point(625, 504);
            this.txtTotalCostBase.Name = "txtTotalCostBase";
            this.txtTotalCostBase.ReadOnly = true;
            this.txtTotalCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalCostBase.Size = new System.Drawing.Size(140, 20);
            this.txtTotalCostBase.TabIndex = 27;
            this.txtTotalCostBase.TabStop = false;
            this.txtTotalCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // txtRealTotalCostBase
            //
            this.txtRealTotalCostBase.BackColor = System.Drawing.SystemColors.Control;
            this.txtRealTotalCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRealTotalCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRealTotalCostBase.Location = new System.Drawing.Point(625, 532);
            this.txtRealTotalCostBase.Name = "txtRealTotalCostBase";
            this.txtRealTotalCostBase.ReadOnly = true;
            this.txtRealTotalCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRealTotalCostBase.Size = new System.Drawing.Size(140, 20);
            this.txtRealTotalCostBase.TabIndex = 28;
            this.txtRealTotalCostBase.TabStop = false;
            this.txtRealTotalCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // Label11
            //
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(460, 560);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(160, 22);
            this.Label11.TabIndex = 39;
            this.Label11.Text = "Portfolio";
            //
            // CmbFlagCode
            //
            this.CmbFlagCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFlagCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFlagCode.FormattingEnabled = true;
            this.CmbFlagCode.Location = new System.Drawing.Point(625, 558);
            this.CmbFlagCode.Name = "CmbFlagCode";
            this.CmbFlagCode.Size = new System.Drawing.Size(140, 22);
            this.CmbFlagCode.TabIndex = 40;
            this.CmbFlagCode.SelectedIndexChanged += new System.EventHandler(this.CmbFlagCode_SelectedIndexChanged);
            //
            // LblPortfolioDesc
            //
            this.LblPortfolioDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblPortfolioDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPortfolioDesc.ForeColor = System.Drawing.Color.Black;
            this.LblPortfolioDesc.Location = new System.Drawing.Point(775, 560);
            this.LblPortfolioDesc.Name = "LblPortfolioDesc";
            this.LblPortfolioDesc.Size = new System.Drawing.Size(210, 22);
            this.LblPortfolioDesc.TabIndex = 60;
            //
            // Label12
            //
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(19, 504);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(125, 22);
            this.Label12.TabIndex = 41;
            this.Label12.Text = "Sold Date";
            //
            // CmbSoldDD
            //
            this.CmbSoldDD.BackColor = System.Drawing.SystemColors.Window;
            this.CmbSoldDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldDD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSoldDD.Location = new System.Drawing.Point(150, 502);
            this.CmbSoldDD.Name = "CmbSoldDD";
            this.CmbSoldDD.Size = new System.Drawing.Size(41, 22);
            this.CmbSoldDD.TabIndex = 42;
            //
            // CmbSoldMM
            //
            this.CmbSoldMM.BackColor = System.Drawing.SystemColors.Window;
            this.CmbSoldMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldMM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSoldMM.Location = new System.Drawing.Point(200, 502);
            this.CmbSoldMM.Name = "CmbSoldMM";
            this.CmbSoldMM.Size = new System.Drawing.Size(41, 22);
            this.CmbSoldMM.TabIndex = 43;
            //
            // CmbSoldYear
            //
            this.CmbSoldYear.BackColor = System.Drawing.SystemColors.Window;
            this.CmbSoldYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSoldYear.Location = new System.Drawing.Point(250, 502);
            this.CmbSoldYear.Name = "CmbSoldYear";
            this.CmbSoldYear.Size = new System.Drawing.Size(57, 22);
            this.CmbSoldYear.TabIndex = 44;
            //
            // CmdSoldCal
            //
            this.CmdSoldCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSoldCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSoldCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSoldCal.Location = new System.Drawing.Point(314, 502);
            this.CmdSoldCal.Name = "CmdSoldCal";
            this.CmdSoldCal.Size = new System.Drawing.Size(25, 19);
            this.CmdSoldCal.TabIndex = 45;
            this.CmdSoldCal.Text = "..";
            this.CmdSoldCal.UseVisualStyleBackColor = false;
            this.CmdSoldCal.Click += new System.EventHandler(this.CmdSoldCal_Click);
            //
            // chkDRIP
            //
            this.chkDRIP.BackColor = System.Drawing.Color.Transparent;
            this.chkDRIP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDRIP.Location = new System.Drawing.Point(150, 476);
            this.chkDRIP.Name = "chkDRIP";
            this.chkDRIP.Size = new System.Drawing.Size(120, 24);
            this.chkDRIP.TabIndex = 29;
            this.chkDRIP.Text = "Reinvestment";
            this.chkDRIP.UseVisualStyleBackColor = false;
            this.chkDRIP.CheckedChanged += new System.EventHandler(this.chkDRIP_CheckedChanged);
            //
            // chkSold
            //
            this.chkSold.BackColor = System.Drawing.Color.Transparent;
            this.chkSold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSold.Location = new System.Drawing.Point(285, 476);
            this.chkSold.Name = "chkSold";
            this.chkSold.Size = new System.Drawing.Size(80, 24);
            this.chkSold.TabIndex = 30;
            this.chkSold.Text = "Sold";
            this.chkSold.UseVisualStyleBackColor = false;
            this.chkSold.CheckedChanged += new System.EventHandler(this.chkSold_CheckedChanged);
            //
            // CmdCreate
            //
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(305, 600);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(85, 27);
            this.CmdCreate.TabIndex = 31;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdUpdate.Location = new System.Drawing.Point(400, 600);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(85, 27);
            this.CmdUpdate.TabIndex = 32;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(495, 600);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 27);
            this.CmdDel.TabIndex = 33;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(590, 600);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 34;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Purchase
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1000, 655);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.chkSold);
            this.Controls.Add(this.chkDRIP);
            this.Controls.Add(this.CmdSoldCal);
            this.Controls.Add(this.CmbSoldYear);
            this.Controls.Add(this.CmbSoldMM);
            this.Controls.Add(this.CmbSoldDD);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.CmbFlagCode);
            this.Controls.Add(this.LblPortfolioDesc);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.txtRealTotalCostBase);
            this.Controls.Add(this.txtTotalCostBase);
            this.Controls.Add(this.txtFee);
            this.Controls.Add(this.txtOriginalCostBase);
            this.Controls.Add(this.Lbl_txtOriginalCostBase);
            this.Controls.Add(this.txtOriginalTotalCostBase);
            this.Controls.Add(this.Lbl_txtOriginalTotalCostBase);
            this.Controls.Add(this.txtCostBase);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.CmbFullTicker);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.gvPurchase);
            this.Controls.Add(this.LblDay);
            this.Controls.Add(this.CmdCal);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.CmbMM);
            this.Controls.Add(this.CmbDD);
            this.Controls.Add(this.LblDateCaption);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "ETF_Stocks_Purchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Purchase";
            this.Load += new System.EventHandler(this.ETF_Stocks_Purchase_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnDaily;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertySetup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertySale;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnSuperProcess;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksCostBase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSale;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFYRecon;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDistribution;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvestment;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label LblDateCaption;
        public System.Windows.Forms.ComboBox CmbDD;
        public System.Windows.Forms.ComboBox CmbMM;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Button CmdCal;
        public System.Windows.Forms.Label LblDay;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView gvPurchase;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.ComboBox CmbFullTicker;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.TextBox txtUnit;
        public System.Windows.Forms.TextBox txtCostBase;
        public System.Windows.Forms.TextBox txtOriginalCostBase;
        public System.Windows.Forms.TextBox txtOriginalTotalCostBase;
        public System.Windows.Forms.Label Lbl_txtOriginalCostBase;
        public System.Windows.Forms.Label Lbl_txtOriginalTotalCostBase;
        public System.Windows.Forms.TextBox txtFee;
        public System.Windows.Forms.TextBox txtTotalCostBase;
        public System.Windows.Forms.TextBox txtRealTotalCostBase;
        public System.Windows.Forms.Label Label11;
        public System.Windows.Forms.Label LblPortfolioDesc;
        public System.Windows.Forms.ComboBox CmbFlagCode;
        public System.Windows.Forms.Label Label12;
        public System.Windows.Forms.ComboBox CmbSoldDD;
        public System.Windows.Forms.ComboBox CmbSoldMM;
        public System.Windows.Forms.ComboBox CmbSoldYear;
        public System.Windows.Forms.Button CmdSoldCal;
        public System.Windows.Forms.CheckBox chkDRIP;
        public System.Windows.Forms.CheckBox chkSold;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
