namespace FinancialBalance
{
    partial class ETF_Stocks_Cost_Base_Adjustment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Cost_Base_Adjustment));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFYRecon = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbFilterFinYear = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbFilterPortfolio = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbFilterTicker = new System.Windows.Forms.ComboBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvAdj = new System.Windows.Forms.DataGridView();
            this.Label4 = new System.Windows.Forms.Label();
            this.CmbFinYear = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.CmbPortfolioCode = new System.Windows.Forms.ComboBox();
            this.LblPortfolioDesc = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.CmbTicker = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.CmbAdjType = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtAdjustment = new System.Windows.Forms.TextBox();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.LblLots = new System.Windows.Forms.Label();
            this.gvLots = new System.Windows.Forms.DataGridView();
            this.Label10 = new System.Windows.Forms.Label();
            this.LblTotalUnit = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtCalcCostBase = new System.Windows.Forms.TextBox();
            this.CmdRecalc = new System.Windows.Forms.Button();
            this.LblResult = new System.Windows.Forms.Label();
            this.gvResult = new System.Windows.Forms.DataGridView();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAdj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            this.SuspendLayout();
            //
            // MainMenu1
            //
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDaily,
            this.MnMonthlyClosing,
            this.MnETFStockProcessGroup,
            this.MnSuperProcess});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(1264, 24);
            this.MainMenu1.TabIndex = 0;
            //
            // MnDaily
            //
            this.MnDaily.Name = "MnDaily";
            this.MnDaily.Size = new System.Drawing.Size(90, 20);
            this.MnDaily.Text = "Daily &Input";
            this.MnDaily.Click += new System.EventHandler(this.MnDaily_Click);
            //
            // MnMonthlyClosing
            //
            this.MnMonthlyClosing.Name = "MnMonthlyClosing";
            this.MnMonthlyClosing.Size = new System.Drawing.Size(90, 20);
            this.MnMonthlyClosing.Text = "&Monthly Closing";
            this.MnMonthlyClosing.Click += new System.EventHandler(this.MnMonthlyClosing_Click);
            //
            // MnETFStockProcessGroup
            //
            this.MnETFStockProcessGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnETFStocksPrice,
            this.MnETFStocksInvestment,
            this.MnETFStocksPurchase,
            this.MnETFStocksSale,
            this.MnETFStocksDistribution,
            this.MnETFStocksFYRecon});
            this.MnETFStockProcessGroup.Name = "MnETFStockProcessGroup";
            this.MnETFStockProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockProcessGroup.Text = "&ETF/Stock";
            //
            // MnSuperProcess
            //
            this.MnSuperProcess.Name = "MnSuperProcess";
            this.MnSuperProcess.Size = new System.Drawing.Size(75, 20);
            this.MnSuperProcess.Text = "&Super";
            this.MnSuperProcess.Click += new System.EventHandler(this.MnSuperProcess_Click);
            //
            // MnETFStocksPrice
            //
            this.MnETFStocksPrice.Name = "MnETFStocksPrice";
            this.MnETFStocksPrice.Size = new System.Drawing.Size(240, 22);
            this.MnETFStocksPrice.Text = "ETF/Stock &Price";
            this.MnETFStocksPrice.Click += new System.EventHandler(this.MnETFStocksPrice_Click);
            //
            // MnETFStocksInvestment
            //
            this.MnETFStocksInvestment.Name = "MnETFStocksInvestment";
            this.MnETFStocksInvestment.Size = new System.Drawing.Size(240, 22);
            this.MnETFStocksInvestment.Text = "ETF/Stock &Investment";
            this.MnETFStocksInvestment.Click += new System.EventHandler(this.MnETFStocksInvestment_Click);
            //
            // MnETFStocksPurchase
            //
            this.MnETFStocksPurchase.Name = "MnETFStocksPurchase";
            this.MnETFStocksPurchase.Size = new System.Drawing.Size(240, 22);
            this.MnETFStocksPurchase.Text = "ETF/Stock P&urchase";
            this.MnETFStocksPurchase.Click += new System.EventHandler(this.MnETFStocksPurchase_Click);
            //
            // MnETFStocksSale
            //
            this.MnETFStocksSale.Name = "MnETFStocksSale";
            this.MnETFStocksSale.Size = new System.Drawing.Size(240, 22);
            this.MnETFStocksSale.Text = "ETF/Stock &Sale";
            this.MnETFStocksSale.Click += new System.EventHandler(this.MnETFStocksSale_Click);
            //
            // MnETFStocksDistribution
            //
            this.MnETFStocksDistribution.Name = "MnETFStocksDistribution";
            this.MnETFStocksDistribution.Size = new System.Drawing.Size(240, 22);
            this.MnETFStocksDistribution.Text = "ETF/Stock &Distribution/Dividend";
            this.MnETFStocksDistribution.Click += new System.EventHandler(this.MnETFStocksDistribution_Click);
            //
            // MnETFStocksFYRecon
            //
            this.MnETFStocksFYRecon.Name = "MnETFStocksFYRecon";
            this.MnETFStocksFYRecon.Size = new System.Drawing.Size(240, 22);
            this.MnETFStocksFYRecon.Text = "ETF/Stock Financial &Year Reconciliation";
            this.MnETFStocksFYRecon.Click += new System.EventHandler(this.MnETFStocksFYRecon_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.Blue;
            this.Label21.Location = new System.Drawing.Point(142, 30);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(980, 38);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK COST BASE ADJUSTMENT";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(110, 20);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Financial Year";
            //
            // CmbFilterFinYear
            //
            this.CmbFilterFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFilterFinYear.FormattingEnabled = true;
            this.CmbFilterFinYear.Location = new System.Drawing.Point(135, 80);
            this.CmbFilterFinYear.Name = "CmbFilterFinYear";
            this.CmbFilterFinYear.Size = new System.Drawing.Size(160, 22);
            this.CmbFilterFinYear.TabIndex = 3;
            this.CmbFilterFinYear.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(315, 82);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 20);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Portfolio";
            //
            // CmbFilterPortfolio
            //
            this.CmbFilterPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFilterPortfolio.FormattingEnabled = true;
            this.CmbFilterPortfolio.Location = new System.Drawing.Point(405, 80);
            this.CmbFilterPortfolio.Name = "CmbFilterPortfolio";
            this.CmbFilterPortfolio.Size = new System.Drawing.Size(240, 22);
            this.CmbFilterPortfolio.TabIndex = 5;
            this.CmbFilterPortfolio.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(665, 82);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(80, 20);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Full Ticker";
            //
            // CmbFilterTicker
            //
            this.CmbFilterTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFilterTicker.FormattingEnabled = true;
            this.CmbFilterTicker.Location = new System.Drawing.Point(755, 80);
            this.CmbFilterTicker.Name = "CmbFilterTicker";
            this.CmbFilterTicker.Size = new System.Drawing.Size(180, 22);
            this.CmbFilterTicker.TabIndex = 7;
            this.CmbFilterTicker.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 106);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1224, 20);
            this.LblNote.TabIndex = 8;
            //
            // gvAdj
            //
            this.gvAdj.AllowUserToAddRows = false;
            this.gvAdj.AllowUserToDeleteRows = false;
            this.gvAdj.AllowUserToResizeRows = false;
            this.gvAdj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAdj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAdj.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAdj.Location = new System.Drawing.Point(19, 128);
            this.gvAdj.MultiSelect = false;
            this.gvAdj.Name = "gvAdj";
            this.gvAdj.ReadOnly = true;
            this.gvAdj.RowHeadersVisible = false;
            this.gvAdj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAdj.Size = new System.Drawing.Size(1224, 80);
            this.gvAdj.TabIndex = 9;
            this.gvAdj.SelectionChanged += new System.EventHandler(this.gvAdj_SelectionChanged);
            //
            // Label4
            //
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(19, 218);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(150, 20);
            this.Label4.TabIndex = 10;
            this.Label4.Text = "Financial Year";
            //
            // CmbFinYear
            //
            this.CmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinYear.FormattingEnabled = true;
            this.CmbFinYear.Location = new System.Drawing.Point(175, 216);
            this.CmbFinYear.Name = "CmbFinYear";
            this.CmbFinYear.Size = new System.Drawing.Size(180, 22);
            this.CmbFinYear.TabIndex = 11;
            this.CmbFinYear.SelectedIndexChanged += new System.EventHandler(this.Entry_Changed);
            //
            // Label5
            //
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(560, 218);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(150, 20);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Portfolio Code";
            //
            // CmbPortfolioCode
            //
            this.CmbPortfolioCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortfolioCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPortfolioCode.FormattingEnabled = true;
            this.CmbPortfolioCode.Location = new System.Drawing.Point(716, 216);
            this.CmbPortfolioCode.Name = "CmbPortfolioCode";
            this.CmbPortfolioCode.Size = new System.Drawing.Size(120, 22);
            this.CmbPortfolioCode.TabIndex = 13;
            this.CmbPortfolioCode.SelectedIndexChanged += new System.EventHandler(this.Entry_Changed);
            //
            // LblPortfolioDesc
            //
            this.LblPortfolioDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblPortfolioDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPortfolioDesc.ForeColor = System.Drawing.Color.Black;
            this.LblPortfolioDesc.Location = new System.Drawing.Point(846, 218);
            this.LblPortfolioDesc.Name = "LblPortfolioDesc";
            this.LblPortfolioDesc.Size = new System.Drawing.Size(260, 20);
            this.LblPortfolioDesc.TabIndex = 14;
            //
            // Label6
            //
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(19, 246);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(150, 20);
            this.Label6.TabIndex = 15;
            this.Label6.Text = "Full Ticker";
            //
            // CmbTicker
            //
            this.CmbTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTicker.FormattingEnabled = true;
            this.CmbTicker.Location = new System.Drawing.Point(175, 244);
            this.CmbTicker.Name = "CmbTicker";
            this.CmbTicker.Size = new System.Drawing.Size(180, 22);
            this.CmbTicker.TabIndex = 16;
            this.CmbTicker.SelectedIndexChanged += new System.EventHandler(this.Entry_Changed);
            //
            // Label7
            //
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(560, 246);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(150, 20);
            this.Label7.TabIndex = 17;
            this.Label7.Text = "Currency";
            //
            // CmbCurrency
            //
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(716, 244);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(120, 22);
            this.CmbCurrency.TabIndex = 18;
            this.CmbCurrency.SelectedIndexChanged += new System.EventHandler(this.Currency_Changed);
            //
            // Label8
            //
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(19, 274);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(150, 20);
            this.Label8.TabIndex = 19;
            this.Label8.Text = "Adjustment Type";
            //
            // CmbAdjType
            //
            this.CmbAdjType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAdjType.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAdjType.FormattingEnabled = true;
            this.CmbAdjType.Location = new System.Drawing.Point(175, 272);
            this.CmbAdjType.Name = "CmbAdjType";
            this.CmbAdjType.Size = new System.Drawing.Size(120, 22);
            this.CmbAdjType.TabIndex = 20;
            this.CmbAdjType.SelectedIndexChanged += new System.EventHandler(this.Currency_Changed);
            //
            // Label9
            //
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(560, 274);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(150, 20);
            this.Label9.TabIndex = 21;
            this.Label9.Text = "Adjustment";
            //
            // txtAdjustment
            //
            this.txtAdjustment.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdjustment.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAdjustment.Location = new System.Drawing.Point(716, 274);
            this.txtAdjustment.MaxLength = 20;
            this.txtAdjustment.Name = "txtAdjustment";
            this.txtAdjustment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAdjustment.Size = new System.Drawing.Size(180, 20);
            this.txtAdjustment.TabIndex = 22;
            this.txtAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdjustment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtAdjustment.TextChanged += new System.EventHandler(this.Adjustment_TextChanged);
            //
            // CmdCreate
            //
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.Location = new System.Drawing.Point(175, 304);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(100, 28);
            this.CmdCreate.TabIndex = 23;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.Location = new System.Drawing.Point(285, 304);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(100, 28);
            this.CmdUpdate.TabIndex = 24;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.Location = new System.Drawing.Point(395, 304);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(100, 28);
            this.CmdDel.TabIndex = 25;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // LblLots
            //
            this.LblLots.BackColor = System.Drawing.Color.Transparent;
            this.LblLots.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLots.ForeColor = System.Drawing.Color.Black;
            this.LblLots.Location = new System.Drawing.Point(19, 342);
            this.LblLots.Name = "LblLots";
            this.LblLots.Size = new System.Drawing.Size(800, 20);
            this.LblLots.TabIndex = 26;
            this.LblLots.Text = "Purchases this adjustment applies to";
            //
            // gvLots
            //
            this.gvLots.AllowUserToAddRows = false;
            this.gvLots.AllowUserToDeleteRows = false;
            this.gvLots.AllowUserToResizeRows = false;
            this.gvLots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLots.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvLots.Location = new System.Drawing.Point(19, 364);
            this.gvLots.MultiSelect = false;
            this.gvLots.Name = "gvLots";
            this.gvLots.ReadOnly = true;
            this.gvLots.RowHeadersVisible = false;
            this.gvLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLots.Size = new System.Drawing.Size(1224, 110);
            this.gvLots.TabIndex = 27;
            this.gvLots.TabStop = false;
            //
            // Label10
            //
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(19, 484);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(150, 20);
            this.Label10.TabIndex = 28;
            this.Label10.Text = "Total Unit";
            //
            // LblTotalUnit
            //
            this.LblTotalUnit.BackColor = System.Drawing.Color.Transparent;
            this.LblTotalUnit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalUnit.ForeColor = System.Drawing.Color.Black;
            this.LblTotalUnit.Location = new System.Drawing.Point(175, 484);
            this.LblTotalUnit.Name = "LblTotalUnit";
            this.LblTotalUnit.Size = new System.Drawing.Size(180, 20);
            this.LblTotalUnit.TabIndex = 29;
            this.LblTotalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Label11
            //
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(560, 484);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(220, 20);
            this.Label11.TabIndex = 30;
            this.Label11.Text = "Calculated Cost Base/Unit";
            //
            // txtCalcCostBase
            //
            this.txtCalcCostBase.BackColor = System.Drawing.SystemColors.Window;
            this.txtCalcCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalcCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCalcCostBase.Location = new System.Drawing.Point(786, 482);
            this.txtCalcCostBase.MaxLength = 20;
            this.txtCalcCostBase.Name = "txtCalcCostBase";
            this.txtCalcCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCalcCostBase.Size = new System.Drawing.Size(160, 20);
            this.txtCalcCostBase.TabIndex = 31;
            this.txtCalcCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCalcCostBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            //
            // CmdRecalc
            //
            this.CmdRecalc.BackColor = System.Drawing.SystemColors.Control;
            this.CmdRecalc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdRecalc.Location = new System.Drawing.Point(19, 514);
            this.CmdRecalc.Name = "CmdRecalc";
            this.CmdRecalc.Size = new System.Drawing.Size(220, 30);
            this.CmdRecalc.TabIndex = 32;
            this.CmdRecalc.Text = "&Recalculate Cost Base";
            this.CmdRecalc.UseVisualStyleBackColor = false;
            this.CmdRecalc.Click += new System.EventHandler(this.CmdRecalc_Click);
            //
            // LblResult
            //
            this.LblResult.BackColor = System.Drawing.Color.Transparent;
            this.LblResult.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblResult.ForeColor = System.Drawing.Color.Black;
            this.LblResult.Location = new System.Drawing.Point(19, 552);
            this.LblResult.Name = "LblResult";
            this.LblResult.Size = new System.Drawing.Size(800, 20);
            this.LblResult.TabIndex = 33;
            this.LblResult.Text = "Result after recalculation";
            //
            // gvResult
            //
            this.gvResult.AllowUserToAddRows = false;
            this.gvResult.AllowUserToDeleteRows = false;
            this.gvResult.AllowUserToResizeRows = false;
            this.gvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResult.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvResult.Location = new System.Drawing.Point(19, 574);
            this.gvResult.MultiSelect = false;
            this.gvResult.Name = "gvResult";
            this.gvResult.ReadOnly = true;
            this.gvResult.RowHeadersVisible = false;
            this.gvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvResult.Size = new System.Drawing.Size(1224, 95);
            this.gvResult.TabIndex = 34;
            this.gvResult.TabStop = false;
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(1134, 678);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 30);
            this.CmdBack.TabIndex = 35;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Cost_Base_Adjustment
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1264, 720);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.gvResult);
            this.Controls.Add(this.LblResult);
            this.Controls.Add(this.CmdRecalc);
            this.Controls.Add(this.txtCalcCostBase);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.LblTotalUnit);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.gvLots);
            this.Controls.Add(this.LblLots);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.txtAdjustment);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.CmbAdjType);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.CmbTicker);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.LblPortfolioDesc);
            this.Controls.Add(this.CmbPortfolioCode);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.CmbFinYear);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.gvAdj);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmbFilterTicker);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.CmbFilterPortfolio);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CmbFilterFinYear);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Cost_Base_Adjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Cost Base Adjustment";
            this.MainMenuStrip = this.MainMenu1;
            this.Load += new System.EventHandler(this.ETF_Stocks_Cost_Base_Adjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAdj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnDaily;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperProcess;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvestment;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSale;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDistribution;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFYRecon;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbFilterFinYear;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbFilterPortfolio;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbFilterTicker;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvAdj;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox CmbFinYear;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.ComboBox CmbPortfolioCode;
        public System.Windows.Forms.Label LblPortfolioDesc;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.ComboBox CmbTicker;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.ComboBox CmbAdjType;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.TextBox txtAdjustment;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Label LblLots;
        private System.Windows.Forms.DataGridView gvLots;
        public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.Label LblTotalUnit;
        public System.Windows.Forms.Label Label11;
        public System.Windows.Forms.TextBox txtCalcCostBase;
        public System.Windows.Forms.Button CmdRecalc;
        public System.Windows.Forms.Label LblResult;
        private System.Windows.Forms.DataGridView gvResult;
        public System.Windows.Forms.Button CmdBack;
    }
}
