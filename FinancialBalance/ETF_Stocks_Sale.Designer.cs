namespace FinancialBalance
{
    partial class ETF_Stocks_Sale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Sale));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksCostBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPurchase = new System.Windows.Forms.ToolStripMenuItem();
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
            this.gvSale = new System.Windows.Forms.DataGridView();
            this.LblLots = new System.Windows.Forms.Label();
            this.gvLots = new System.Windows.Forms.DataGridView();
            this.gvSoldLots = new System.Windows.Forms.DataGridView();
            this.LblSoldLots = new System.Windows.Forms.Label();
            this.LblSaleIdCap = new System.Windows.Forms.Label();
            this.LblSaleId = new System.Windows.Forms.Label();
            this.LblTotPurchaseCap = new System.Windows.Forms.Label();
            this.LblTotPurchase = new System.Windows.Forms.Label();
            this.LblTotRealPurchaseCap = new System.Windows.Forms.Label();
            this.LblTotRealPurchase = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.CmbFullTicker = new System.Windows.Forms.ComboBox();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtSellingPricePerUnit = new System.Windows.Forms.TextBox();
            this.txtSellingTotalAmount = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.CmbSellPortfolio = new System.Windows.Forms.ComboBox();
            this.LblSellPortfolioDesc = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSoldLots)).BeginInit();
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
            this.MnETFStocksPurchase,
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
            this.MnPropertySetup});
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
            // MnSuperProcess
            //
            this.MnSuperProcess.Name = "MnSuperProcess";
            this.MnSuperProcess.Size = new System.Drawing.Size(75, 20);
            this.MnSuperProcess.Text = "&Super";
            this.MnSuperProcess.Click += new System.EventHandler(this.MnSuperProcess_Click);
            //
            // MnETFStocksPurchase
            //
            this.MnETFStocksPurchase.Name = "MnETFStocksPurchase";
            this.MnETFStocksPurchase.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksPurchase.Text = "ETF/Stock &Purchase";
            this.MnETFStocksPurchase.Click += new System.EventHandler(this.MnETFStocksPurchase_Click);
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
            this.Label21.Text = "ETF/STOCK SALE";
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
            // gvSale
            //
            this.gvSale.AllowUserToAddRows = false;
            this.gvSale.AllowUserToDeleteRows = false;
            this.gvSale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSale.Location = new System.Drawing.Point(19, 115);
            this.gvSale.MultiSelect = false;
            this.gvSale.Name = "gvSale";
            this.gvSale.ReadOnly = true;
            this.gvSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSale.Size = new System.Drawing.Size(960, 210);
            this.gvSale.TabIndex = 9;
            this.gvSale.SelectionChanged += new System.EventHandler(this.gvSale_SelectionChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(19, 340);
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
            this.Label3.Location = new System.Drawing.Point(19, 368);
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
            this.Label4.Location = new System.Drawing.Point(19, 396);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(125, 22);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Unit";
            //
            // CmbFullTicker
            //
            this.CmbFullTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFullTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFullTicker.FormattingEnabled = true;
            this.CmbFullTicker.Location = new System.Drawing.Point(150, 340);
            this.CmbFullTicker.Name = "CmbFullTicker";
            this.CmbFullTicker.Size = new System.Drawing.Size(140, 22);
            this.CmbFullTicker.TabIndex = 19;
            this.CmbFullTicker.SelectedIndexChanged += new System.EventHandler(this.CmbFullTicker_SelectedIndexChanged);
            //
            // CmbCurrency
            //
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(150, 368);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(140, 22);
            this.CmbCurrency.TabIndex = 20;
            //
            // txtUnit
            //
            this.txtUnit.BackColor = System.Drawing.SystemColors.Control;
            this.txtUnit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnit.Location = new System.Drawing.Point(150, 396);
            this.txtUnit.MaxLength = 20;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnit.Size = new System.Drawing.Size(140, 20);
            this.txtUnit.TabIndex = 21;
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnit.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            //
            // Label9
            //
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(460, 340);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(160, 22);
            this.Label9.TabIndex = 35;
            this.Label9.Text = "Selling Price/Unit";
            //
            // Label10
            //
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(460, 368);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(160, 22);
            this.Label10.TabIndex = 36;
            this.Label10.Text = "Selling Total Amount";
            //
            // txtSellingPricePerUnit
            //
            this.txtSellingPricePerUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtSellingPricePerUnit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellingPricePerUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSellingPricePerUnit.Location = new System.Drawing.Point(625, 340);
            this.txtSellingPricePerUnit.MaxLength = 20;
            this.txtSellingPricePerUnit.Name = "txtSellingPricePerUnit";
            this.txtSellingPricePerUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSellingPricePerUnit.Size = new System.Drawing.Size(140, 20);
            this.txtSellingPricePerUnit.TabIndex = 37;
            this.txtSellingPricePerUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSellingPricePerUnit.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            this.txtSellingPricePerUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellingPricePerUnit_KeyPress);
            //
            // txtSellingTotalAmount
            //
            this.txtSellingTotalAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtSellingTotalAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellingTotalAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSellingTotalAmount.Location = new System.Drawing.Point(625, 368);
            this.txtSellingTotalAmount.Name = "txtSellingTotalAmount";
            this.txtSellingTotalAmount.ReadOnly = true;
            this.txtSellingTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSellingTotalAmount.Size = new System.Drawing.Size(140, 20);
            this.txtSellingTotalAmount.TabIndex = 38;
            this.txtSellingTotalAmount.TabStop = false;
            this.txtSellingTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // Label13
            //
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(460, 398);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(160, 22);
            this.Label13.TabIndex = 61;
            this.Label13.Text = "Portfolio";
            //
            // CmbSellPortfolio
            //
            this.CmbSellPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSellPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSellPortfolio.FormattingEnabled = true;
            this.CmbSellPortfolio.Location = new System.Drawing.Point(625, 396);
            this.CmbSellPortfolio.Name = "CmbSellPortfolio";
            this.CmbSellPortfolio.Size = new System.Drawing.Size(140, 22);
            this.CmbSellPortfolio.TabIndex = 62;
            this.CmbSellPortfolio.SelectedIndexChanged += new System.EventHandler(this.CmbSellPortfolio_SelectedIndexChanged);
            //
            // LblSellPortfolioDesc
            //
            this.LblSellPortfolioDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblSellPortfolioDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSellPortfolioDesc.ForeColor = System.Drawing.Color.Black;
            this.LblSellPortfolioDesc.Location = new System.Drawing.Point(775, 398);
            this.LblSellPortfolioDesc.Name = "LblSellPortfolioDesc";
            this.LblSellPortfolioDesc.Size = new System.Drawing.Size(210, 22);
            this.LblSellPortfolioDesc.TabIndex = 63;
            //
            // CmdCreate
            //
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(305, 610);
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
            this.CmdUpdate.Location = new System.Drawing.Point(400, 610);
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
            this.CmdDel.Location = new System.Drawing.Point(495, 610);
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
            this.CmdBack.Location = new System.Drawing.Point(590, 610);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 34;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // LblLots
            //
            this.LblLots.BackColor = System.Drawing.Color.Transparent;
            this.LblLots.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLots.ForeColor = System.Drawing.Color.Black;
            this.LblLots.Location = new System.Drawing.Point(19, 452);
            this.LblLots.Name = "LblLots";
            this.LblLots.Size = new System.Drawing.Size(600, 20);
            this.LblLots.TabIndex = 46;
            this.LblLots.Text = "Unsold purchases - enter how many units of each are being sold";
            //
            // LblTotPurchaseCap
            //
            this.LblTotPurchaseCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotPurchaseCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotPurchaseCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotPurchaseCap.Location = new System.Drawing.Point(19, 580);
            this.LblTotPurchaseCap.Name = "LblTotPurchaseCap";
            this.LblTotPurchaseCap.Size = new System.Drawing.Size(200, 20);
            this.LblTotPurchaseCap.TabIndex = 49;
            this.LblTotPurchaseCap.Text = "Total Purchase Amount";
            //
            // LblTotPurchase
            //
            this.LblTotPurchase.BackColor = System.Drawing.Color.Transparent;
            this.LblTotPurchase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotPurchase.ForeColor = System.Drawing.Color.Black;
            this.LblTotPurchase.Location = new System.Drawing.Point(225, 580);
            this.LblTotPurchase.Name = "LblTotPurchase";
            this.LblTotPurchase.Size = new System.Drawing.Size(150, 20);
            this.LblTotPurchase.TabIndex = 50;
            this.LblTotPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotRealPurchaseCap
            //
            this.LblTotRealPurchaseCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotRealPurchaseCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotRealPurchaseCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotRealPurchaseCap.Location = new System.Drawing.Point(400, 580);
            this.LblTotRealPurchaseCap.Name = "LblTotRealPurchaseCap";
            this.LblTotRealPurchaseCap.Size = new System.Drawing.Size(240, 20);
            this.LblTotRealPurchaseCap.TabIndex = 51;
            this.LblTotRealPurchaseCap.Text = "Total Real Purchase Amount";
            //
            // LblTotRealPurchase
            //
            this.LblTotRealPurchase.BackColor = System.Drawing.Color.Transparent;
            this.LblTotRealPurchase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotRealPurchase.ForeColor = System.Drawing.Color.Black;
            this.LblTotRealPurchase.Location = new System.Drawing.Point(645, 580);
            this.LblTotRealPurchase.Name = "LblTotRealPurchase";
            this.LblTotRealPurchase.Size = new System.Drawing.Size(150, 20);
            this.LblTotRealPurchase.TabIndex = 52;
            this.LblTotRealPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // gvSoldLots
            //
            this.gvSoldLots.AllowUserToAddRows = false;
            this.gvSoldLots.AllowUserToDeleteRows = false;
            this.gvSoldLots.AllowUserToResizeRows = false;
            this.gvSoldLots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSoldLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSoldLots.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvSoldLots.Location = new System.Drawing.Point(19, 474);
            this.gvSoldLots.MultiSelect = false;
            this.gvSoldLots.Name = "gvSoldLots";
            this.gvSoldLots.ReadOnly = true;
            this.gvSoldLots.RowHeadersVisible = false;
            this.gvSoldLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSoldLots.Size = new System.Drawing.Size(960, 100);
            this.gvSoldLots.TabIndex = 48;
            this.gvSoldLots.TabStop = false;
            //
            // LblSoldLots
            //
            this.LblSoldLots.BackColor = System.Drawing.Color.Transparent;
            this.LblSoldLots.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSoldLots.ForeColor = System.Drawing.Color.Black;
            this.LblSoldLots.Location = new System.Drawing.Point(19, 452);
            this.LblSoldLots.Name = "LblSoldLots";
            this.LblSoldLots.Size = new System.Drawing.Size(600, 20);
            this.LblSoldLots.TabIndex = 47;
            this.LblSoldLots.Text = "Purchases closed by this sale";
            //
            // LblSaleIdCap
            //
            this.LblSaleIdCap.BackColor = System.Drawing.Color.Transparent;
            this.LblSaleIdCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaleIdCap.ForeColor = System.Drawing.Color.Black;
            this.LblSaleIdCap.Location = new System.Drawing.Point(19, 424);
            this.LblSaleIdCap.Name = "LblSaleIdCap";
            this.LblSaleIdCap.Size = new System.Drawing.Size(120, 22);
            this.LblSaleIdCap.TabIndex = 45;
            this.LblSaleIdCap.Text = "Sale Id";
            //
            // LblSaleId
            //
            this.LblSaleId.BackColor = System.Drawing.Color.Transparent;
            this.LblSaleId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaleId.ForeColor = System.Drawing.Color.Black;
            this.LblSaleId.Location = new System.Drawing.Point(150, 424);
            this.LblSaleId.Name = "LblSaleId";
            this.LblSaleId.Size = new System.Drawing.Size(420, 22);
            this.LblSaleId.TabIndex = 46;
            //
            // gvLots
            //
            this.gvLots.AllowUserToAddRows = false;
            this.gvLots.AllowUserToDeleteRows = false;
            this.gvLots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLots.Location = new System.Drawing.Point(19, 474);
            this.gvLots.MultiSelect = false;
            this.gvLots.Name = "gvLots";
            this.gvLots.RowHeadersVisible = false;
            this.gvLots.Size = new System.Drawing.Size(960, 120);
            this.gvLots.TabIndex = 47;
            this.gvLots.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLots_CellEndEdit);
            this.gvLots.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvLots_EditingControlShowing);
            //
            // ETF_Stocks_Sale
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
            this.Controls.Add(this.LblSellPortfolioDesc);
            this.Controls.Add(this.CmbSellPortfolio);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.txtSellingTotalAmount);
            this.Controls.Add(this.txtSellingPricePerUnit);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.CmbFullTicker);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.LblTotPurchaseCap);
            this.Controls.Add(this.LblTotPurchase);
            this.Controls.Add(this.LblTotRealPurchaseCap);
            this.Controls.Add(this.LblTotRealPurchase);
            this.Controls.Add(this.gvSoldLots);
            this.Controls.Add(this.LblSoldLots);
            this.Controls.Add(this.LblSaleIdCap);
            this.Controls.Add(this.LblSaleId);
            this.Controls.Add(this.gvLots);
            this.Controls.Add(this.LblLots);
            this.Controls.Add(this.gvSale);
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
            this.Name = "ETF_Stocks_Sale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Sale";
            this.Load += new System.EventHandler(this.ETF_Stocks_Sale_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSoldLots)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnSuperProcess;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksCostBase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPurchase;
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
        private System.Windows.Forms.DataGridView gvSale;
        public System.Windows.Forms.Label LblLots;
        private System.Windows.Forms.DataGridView gvLots;
        private System.Windows.Forms.DataGridView gvSoldLots;
        public System.Windows.Forms.Label LblSoldLots;
        public System.Windows.Forms.Label LblSaleIdCap;
        public System.Windows.Forms.Label LblSaleId;
        public System.Windows.Forms.Label LblTotPurchaseCap;
        public System.Windows.Forms.Label LblTotPurchase;
        public System.Windows.Forms.Label LblTotRealPurchaseCap;
        public System.Windows.Forms.Label LblTotRealPurchase;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox CmbFullTicker;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.TextBox txtUnit;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.TextBox txtSellingPricePerUnit;
        public System.Windows.Forms.TextBox txtSellingTotalAmount;
        public System.Windows.Forms.Label Label13;
        public System.Windows.Forms.ComboBox CmbSellPortfolio;
        public System.Windows.Forms.Label LblSellPortfolioDesc;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
