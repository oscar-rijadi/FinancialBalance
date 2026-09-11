namespace FinancialBalance
{
    partial class Super_Financial_Year
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Super_Financial_Year));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksCostBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFYRecon = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbFilterFinYear = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbFilterSuper = new System.Windows.Forms.ComboBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvSFY = new System.Windows.Forms.DataGridView();
            this.Lbl_CmbFinYear = new System.Windows.Forms.Label();
            this.CmbFinYear = new System.Windows.Forms.ComboBox();
            this.Lbl_CmbSuperCode = new System.Windows.Forms.Label();
            this.CmbSuperCode = new System.Windows.Forms.ComboBox();
            this.Lbl_CmbCurrency = new System.Windows.Forms.Label();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.Lbl_txtOpeningBalance = new System.Windows.Forms.Label();
            this.txtOpeningBalance = new System.Windows.Forms.TextBox();
            this.Lbl_txtContribution = new System.Windows.Forms.Label();
            this.txtContribution = new System.Windows.Forms.TextBox();
            this.Lbl_txtTransferIn = new System.Windows.Forms.Label();
            this.txtTransferIn = new System.Windows.Forms.TextBox();
            this.Lbl_txtInvestmentReturns = new System.Windows.Forms.Label();
            this.txtInvestmentReturns = new System.Windows.Forms.TextBox();
            this.Lbl_LblPctInvReturns = new System.Windows.Forms.Label();
            this.LblPctInvReturns = new System.Windows.Forms.Label();
            this.Lbl_txtAdminFee = new System.Windows.Forms.Label();
            this.txtAdminFee = new System.Windows.Forms.TextBox();
            this.Lbl_txtInsurancePremium = new System.Windows.Forms.Label();
            this.txtInsurancePremium = new System.Windows.Forms.TextBox();
            this.Lbl_txtGovermentTax = new System.Windows.Forms.Label();
            this.txtGovermentTax = new System.Windows.Forms.TextBox();
            this.Lbl_txtGovermentTaxBenefit = new System.Windows.Forms.Label();
            this.txtGovermentTaxBenefit = new System.Windows.Forms.TextBox();
            this.Lbl_txtInvestmentProfitOrLoss = new System.Windows.Forms.Label();
            this.txtInvestmentProfitOrLoss = new System.Windows.Forms.TextBox();
            this.Lbl_LblPctInvProfitOrLoss = new System.Windows.Forms.Label();
            this.LblPctInvProfitOrLoss = new System.Windows.Forms.Label();
            this.Lbl_txtTotalSurplusOrMinus = new System.Windows.Forms.Label();
            this.txtTotalSurplusOrMinus = new System.Windows.Forms.TextBox();
            this.Lbl_LblPctTotalSurplusOrMinus = new System.Windows.Forms.Label();
            this.LblPctTotalSurplusOrMinus = new System.Windows.Forms.Label();
            this.Lbl_txtTransferOut = new System.Windows.Forms.Label();
            this.txtTransferOut = new System.Windows.Forms.TextBox();
            this.Lbl_txtEndingBalance = new System.Windows.Forms.Label();
            this.txtEndingBalance = new System.Windows.Forms.TextBox();
            this.LblSuperDesc = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSFY)).BeginInit();
            this.SuspendLayout();
            //
            // MainMenu1
            //
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDaily,
            this.MnMonthlyClosing,
            this.MnETFStockProcessGroup,
            this.MnPropertyProcessGroup});
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
            // MnPropertySale
            // 
            this.MnPropertySale.Name = "MnPropertySale";
            this.MnPropertySale.Size = new System.Drawing.Size(260, 22);
            this.MnPropertySale.Text = "Property Sa&le";
            this.MnPropertySale.Click += new System.EventHandler(this.MnPropertySale_Click);
            // 
            // MnPropertySetup
            // 
            this.MnPropertySetup.Name = "MnPropertySetup";
            this.MnPropertySetup.Size = new System.Drawing.Size(260, 22);
            this.MnPropertySetup.Text = "P&roperty Setup";
            this.MnPropertySetup.Click += new System.EventHandler(this.MnPropertySetup_Click);
            // 
            // MnPropertyPurchase
            // 
            this.MnPropertyPurchase.Name = "MnPropertyPurchase";
            this.MnPropertyPurchase.Size = new System.Drawing.Size(260, 22);
            this.MnPropertyPurchase.Text = "Property P&urchase";
            this.MnPropertyPurchase.Click += new System.EventHandler(this.MnPropertyPurchase_Click);
            //
            // MnETFStocksPrice
            //
            this.MnETFStocksPrice.Name = "MnETFStocksPrice";
            this.MnETFStocksPrice.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksPrice.Text = "ETF/Stock &Price";
            this.MnETFStocksPrice.Click += new System.EventHandler(this.MnETFStocksPrice_Click);
            //
            // MnETFStocksInvestment
            //
            this.MnETFStocksInvestment.Name = "MnETFStocksInvestment";
            this.MnETFStocksInvestment.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksInvestment.Text = "ETF/Stock &Investment";
            this.MnETFStocksInvestment.Click += new System.EventHandler(this.MnETFStocksInvestment_Click);
            //
            // MnETFStocksPurchase
            //
            this.MnETFStocksPurchase.Name = "MnETFStocksPurchase";
            this.MnETFStocksPurchase.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksPurchase.Text = "ETF/Stock P&urchase";
            this.MnETFStocksPurchase.Click += new System.EventHandler(this.MnETFStocksPurchase_Click);
            //
            // MnETFStocksSale
            //
            this.MnETFStocksSale.Name = "MnETFStocksSale";
            this.MnETFStocksSale.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksSale.Text = "ETF/Stock &Sale";
            this.MnETFStocksSale.Click += new System.EventHandler(this.MnETFStocksSale_Click);
            //
            // MnETFStocksDistribution
            //
            this.MnETFStocksDistribution.Name = "MnETFStocksDistribution";
            this.MnETFStocksDistribution.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksDistribution.Text = "ETF/Stock &Distribution/Dividend";
            this.MnETFStocksDistribution.Click += new System.EventHandler(this.MnETFStocksDistribution_Click);
            //
            // MnETFStocksCostBase
            //
            this.MnETFStocksCostBase.Name = "MnETFStocksCostBase";
            this.MnETFStocksCostBase.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksCostBase.Text = "ETF/Stock &Cost Base Adjustment";
            this.MnETFStocksCostBase.Click += new System.EventHandler(this.MnETFStocksCostBase_Click);
            //
            // MnETFStocksFYRecon
            //
            this.MnETFStocksFYRecon.Name = "MnETFStocksFYRecon";
            this.MnETFStocksFYRecon.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksFYRecon.Text = "ETF/Stock Financial &Year Reconciliation";
            this.MnETFStocksFYRecon.Click += new System.EventHandler(this.MnETFStocksFYRecon_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(142, 30);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(980, 38);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "SUPER";
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
            this.Label2.Size = new System.Drawing.Size(60, 20);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Super";
            //
            // CmbFilterSuper
            //
            this.CmbFilterSuper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterSuper.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFilterSuper.FormattingEnabled = true;
            this.CmbFilterSuper.Location = new System.Drawing.Point(385, 80);
            this.CmbFilterSuper.Name = "CmbFilterSuper";
            this.CmbFilterSuper.Size = new System.Drawing.Size(320, 22);
            this.CmbFilterSuper.TabIndex = 5;
            this.CmbFilterSuper.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 108);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1224, 20);
            this.LblNote.TabIndex = 6;
            //
            // gvSFY
            //
            this.gvSFY.AllowUserToAddRows = false;
            this.gvSFY.AllowUserToDeleteRows = false;
            this.gvSFY.AllowUserToResizeRows = false;
            this.gvSFY.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSFY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSFY.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvSFY.Location = new System.Drawing.Point(19, 130);
            this.gvSFY.MultiSelect = false;
            this.gvSFY.Name = "gvSFY";
            this.gvSFY.ReadOnly = true;
            this.gvSFY.RowHeadersVisible = false;
            this.gvSFY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSFY.Size = new System.Drawing.Size(1224, 160);
            this.gvSFY.TabIndex = 7;
            this.gvSFY.SelectionChanged += new System.EventHandler(this.gvSFY_SelectionChanged);
            //
            // Lbl_CmbFinYear
            //
            this.Lbl_CmbFinYear.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbFinYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbFinYear.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbFinYear.Location = new System.Drawing.Point(19, 306);
            this.Lbl_CmbFinYear.Name = "Lbl_CmbFinYear";
            this.Lbl_CmbFinYear.Size = new System.Drawing.Size(175, 20);
            this.Lbl_CmbFinYear.TabIndex = 8;
            this.Lbl_CmbFinYear.Text = "Financial Year";
            //
            // CmbFinYear
            //
            this.CmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinYear.FormattingEnabled = true;
            this.CmbFinYear.Location = new System.Drawing.Point(200, 302);
            this.CmbFinYear.Name = "CmbFinYear";
            this.CmbFinYear.Size = new System.Drawing.Size(150, 22);
            this.CmbFinYear.TabIndex = 9;
            this.CmbFinYear.SelectedIndexChanged += new System.EventHandler(this.Entry_Changed);
            //
            // Lbl_CmbSuperCode
            //
            this.Lbl_CmbSuperCode.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbSuperCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbSuperCode.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbSuperCode.Location = new System.Drawing.Point(380, 306);
            this.Lbl_CmbSuperCode.Name = "Lbl_CmbSuperCode";
            this.Lbl_CmbSuperCode.Size = new System.Drawing.Size(245, 20);
            this.Lbl_CmbSuperCode.TabIndex = 10;
            this.Lbl_CmbSuperCode.Text = "Super Code";
            //
            // CmbSuperCode
            //
            this.CmbSuperCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSuperCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSuperCode.FormattingEnabled = true;
            this.CmbSuperCode.Location = new System.Drawing.Point(630, 302);
            this.CmbSuperCode.Name = "CmbSuperCode";
            this.CmbSuperCode.Size = new System.Drawing.Size(150, 22);
            this.CmbSuperCode.TabIndex = 11;
            this.CmbSuperCode.SelectedIndexChanged += new System.EventHandler(this.Entry_Changed);
            //
            // Lbl_CmbCurrency
            //
            this.Lbl_CmbCurrency.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbCurrency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbCurrency.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbCurrency.Location = new System.Drawing.Point(19, 334);
            this.Lbl_CmbCurrency.Name = "Lbl_CmbCurrency";
            this.Lbl_CmbCurrency.Size = new System.Drawing.Size(175, 20);
            this.Lbl_CmbCurrency.TabIndex = 12;
            this.Lbl_CmbCurrency.Text = "Currency";
            //
            // CmbCurrency
            //
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(200, 330);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(150, 22);
            this.CmbCurrency.TabIndex = 13;
            this.CmbCurrency.SelectedIndexChanged += new System.EventHandler(this.Entry_Changed);
            //
            // Lbl_txtOpeningBalance
            //
            this.Lbl_txtOpeningBalance.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOpeningBalance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOpeningBalance.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOpeningBalance.Location = new System.Drawing.Point(380, 334);
            this.Lbl_txtOpeningBalance.Name = "Lbl_txtOpeningBalance";
            this.Lbl_txtOpeningBalance.Size = new System.Drawing.Size(245, 20);
            this.Lbl_txtOpeningBalance.TabIndex = 14;
            this.Lbl_txtOpeningBalance.Text = "Opening Balance";
            //
            // txtOpeningBalance
            //
            this.txtOpeningBalance.BackColor = System.Drawing.SystemColors.Window;
            this.txtOpeningBalance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpeningBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOpeningBalance.Location = new System.Drawing.Point(630, 332);
            this.txtOpeningBalance.MaxLength = 20;
            this.txtOpeningBalance.Name = "txtOpeningBalance";
            this.txtOpeningBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOpeningBalance.Size = new System.Drawing.Size(150, 20);
            this.txtOpeningBalance.TabIndex = 15;
            this.txtOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOpeningBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtOpeningBalance.TextChanged += new System.EventHandler(this.txtOpeningBalance_TextChanged);
            //
            // Lbl_txtContribution
            //
            this.Lbl_txtContribution.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtContribution.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtContribution.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtContribution.Location = new System.Drawing.Point(810, 334);
            this.Lbl_txtContribution.Name = "Lbl_txtContribution";
            this.Lbl_txtContribution.Size = new System.Drawing.Size(250, 20);
            this.Lbl_txtContribution.TabIndex = 16;
            this.Lbl_txtContribution.Text = "Contribution";
            //
            // txtContribution
            //
            this.txtContribution.BackColor = System.Drawing.SystemColors.Window;
            this.txtContribution.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContribution.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContribution.Location = new System.Drawing.Point(1065, 332);
            this.txtContribution.MaxLength = 20;
            this.txtContribution.Name = "txtContribution";
            this.txtContribution.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtContribution.Size = new System.Drawing.Size(150, 20);
            this.txtContribution.TabIndex = 17;
            this.txtContribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtContribution.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtContribution.TextChanged += new System.EventHandler(this.txtContribution_TextChanged);
            //
            // Lbl_txtTransferIn
            //
            this.Lbl_txtTransferIn.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtTransferIn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtTransferIn.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtTransferIn.Location = new System.Drawing.Point(19, 362);
            this.Lbl_txtTransferIn.Name = "Lbl_txtTransferIn";
            this.Lbl_txtTransferIn.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtTransferIn.TabIndex = 18;
            this.Lbl_txtTransferIn.Text = "Transfer In";
            //
            // txtTransferIn
            //
            this.txtTransferIn.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransferIn.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransferIn.Location = new System.Drawing.Point(200, 360);
            this.txtTransferIn.MaxLength = 20;
            this.txtTransferIn.Name = "txtTransferIn";
            this.txtTransferIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTransferIn.Size = new System.Drawing.Size(150, 20);
            this.txtTransferIn.TabIndex = 19;
            this.txtTransferIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransferIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtTransferIn.TextChanged += new System.EventHandler(this.txtTransferIn_TextChanged);
            //
            // Lbl_txtInvestmentReturns
            //
            this.Lbl_txtInvestmentReturns.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtInvestmentReturns.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtInvestmentReturns.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtInvestmentReturns.Location = new System.Drawing.Point(380, 362);
            this.Lbl_txtInvestmentReturns.Name = "Lbl_txtInvestmentReturns";
            this.Lbl_txtInvestmentReturns.Size = new System.Drawing.Size(245, 20);
            this.Lbl_txtInvestmentReturns.TabIndex = 20;
            this.Lbl_txtInvestmentReturns.Text = "Investment Returns";
            //
            // txtInvestmentReturns
            //
            this.txtInvestmentReturns.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvestmentReturns.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvestmentReturns.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInvestmentReturns.Location = new System.Drawing.Point(630, 360);
            this.txtInvestmentReturns.MaxLength = 20;
            this.txtInvestmentReturns.Name = "txtInvestmentReturns";
            this.txtInvestmentReturns.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInvestmentReturns.Size = new System.Drawing.Size(150, 20);
            this.txtInvestmentReturns.TabIndex = 21;
            this.txtInvestmentReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvestmentReturns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtInvestmentReturns.TextChanged += new System.EventHandler(this.txtInvestmentReturns_TextChanged);
            //
            // Lbl_LblPctInvReturns
            //
            this.Lbl_LblPctInvReturns.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblPctInvReturns.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblPctInvReturns.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblPctInvReturns.Location = new System.Drawing.Point(810, 362);
            this.Lbl_LblPctInvReturns.Name = "Lbl_LblPctInvReturns";
            this.Lbl_LblPctInvReturns.Size = new System.Drawing.Size(250, 20);
            this.Lbl_LblPctInvReturns.TabIndex = 22;
            this.Lbl_LblPctInvReturns.Text = "Percentage Investment Returns";
            //
            // LblPctInvReturns
            //
            this.LblPctInvReturns.BackColor = System.Drawing.Color.Transparent;
            this.LblPctInvReturns.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPctInvReturns.ForeColor = System.Drawing.Color.Black;
            this.LblPctInvReturns.Location = new System.Drawing.Point(1065, 362);
            this.LblPctInvReturns.Name = "LblPctInvReturns";
            this.LblPctInvReturns.Size = new System.Drawing.Size(150, 20);
            this.LblPctInvReturns.TabIndex = 23;
            this.LblPctInvReturns.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_txtAdminFee
            //
            this.Lbl_txtAdminFee.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtAdminFee.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtAdminFee.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtAdminFee.Location = new System.Drawing.Point(19, 390);
            this.Lbl_txtAdminFee.Name = "Lbl_txtAdminFee";
            this.Lbl_txtAdminFee.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtAdminFee.TabIndex = 24;
            this.Lbl_txtAdminFee.Text = "Admin Fee";
            //
            // txtAdminFee
            //
            this.txtAdminFee.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdminFee.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminFee.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAdminFee.Location = new System.Drawing.Point(200, 388);
            this.txtAdminFee.MaxLength = 20;
            this.txtAdminFee.Name = "txtAdminFee";
            this.txtAdminFee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAdminFee.Size = new System.Drawing.Size(150, 20);
            this.txtAdminFee.TabIndex = 25;
            this.txtAdminFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdminFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtAdminFee.TextChanged += new System.EventHandler(this.txtAdminFee_TextChanged);
            //
            // Lbl_txtInsurancePremium
            //
            this.Lbl_txtInsurancePremium.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtInsurancePremium.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtInsurancePremium.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtInsurancePremium.Location = new System.Drawing.Point(380, 390);
            this.Lbl_txtInsurancePremium.Name = "Lbl_txtInsurancePremium";
            this.Lbl_txtInsurancePremium.Size = new System.Drawing.Size(245, 20);
            this.Lbl_txtInsurancePremium.TabIndex = 26;
            this.Lbl_txtInsurancePremium.Text = "Insurance Premium";
            //
            // txtInsurancePremium
            //
            this.txtInsurancePremium.BackColor = System.Drawing.SystemColors.Window;
            this.txtInsurancePremium.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsurancePremium.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInsurancePremium.Location = new System.Drawing.Point(630, 388);
            this.txtInsurancePremium.MaxLength = 20;
            this.txtInsurancePremium.Name = "txtInsurancePremium";
            this.txtInsurancePremium.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInsurancePremium.Size = new System.Drawing.Size(150, 20);
            this.txtInsurancePremium.TabIndex = 27;
            this.txtInsurancePremium.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInsurancePremium.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtInsurancePremium.TextChanged += new System.EventHandler(this.txtInsurancePremium_TextChanged);
            //
            // Lbl_txtGovermentTax
            //
            this.Lbl_txtGovermentTax.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtGovermentTax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtGovermentTax.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtGovermentTax.Location = new System.Drawing.Point(810, 390);
            this.Lbl_txtGovermentTax.Name = "Lbl_txtGovermentTax";
            this.Lbl_txtGovermentTax.Size = new System.Drawing.Size(250, 20);
            this.Lbl_txtGovermentTax.TabIndex = 28;
            this.Lbl_txtGovermentTax.Text = "Goverment Tax";
            //
            // txtGovermentTax
            //
            this.txtGovermentTax.BackColor = System.Drawing.SystemColors.Window;
            this.txtGovermentTax.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGovermentTax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGovermentTax.Location = new System.Drawing.Point(1065, 388);
            this.txtGovermentTax.MaxLength = 20;
            this.txtGovermentTax.Name = "txtGovermentTax";
            this.txtGovermentTax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGovermentTax.Size = new System.Drawing.Size(150, 20);
            this.txtGovermentTax.TabIndex = 29;
            this.txtGovermentTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGovermentTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtGovermentTax.TextChanged += new System.EventHandler(this.txtGovermentTax_TextChanged);
            //
            // Lbl_txtGovermentTaxBenefit
            //
            this.Lbl_txtGovermentTaxBenefit.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtGovermentTaxBenefit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtGovermentTaxBenefit.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtGovermentTaxBenefit.Location = new System.Drawing.Point(19, 418);
            this.Lbl_txtGovermentTaxBenefit.Name = "Lbl_txtGovermentTaxBenefit";
            this.Lbl_txtGovermentTaxBenefit.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtGovermentTaxBenefit.TabIndex = 30;
            this.Lbl_txtGovermentTaxBenefit.Text = "Goverment Tax Benefit";
            //
            // txtGovermentTaxBenefit
            //
            this.txtGovermentTaxBenefit.BackColor = System.Drawing.SystemColors.Window;
            this.txtGovermentTaxBenefit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGovermentTaxBenefit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGovermentTaxBenefit.Location = new System.Drawing.Point(200, 416);
            this.txtGovermentTaxBenefit.MaxLength = 20;
            this.txtGovermentTaxBenefit.Name = "txtGovermentTaxBenefit";
            this.txtGovermentTaxBenefit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGovermentTaxBenefit.Size = new System.Drawing.Size(150, 20);
            this.txtGovermentTaxBenefit.TabIndex = 31;
            this.txtGovermentTaxBenefit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGovermentTaxBenefit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtGovermentTaxBenefit.TextChanged += new System.EventHandler(this.txtGovermentTaxBenefit_TextChanged);
            //
            // Lbl_txtInvestmentProfitOrLoss
            //
            this.Lbl_txtInvestmentProfitOrLoss.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtInvestmentProfitOrLoss.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtInvestmentProfitOrLoss.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtInvestmentProfitOrLoss.Location = new System.Drawing.Point(380, 418);
            this.Lbl_txtInvestmentProfitOrLoss.Name = "Lbl_txtInvestmentProfitOrLoss";
            this.Lbl_txtInvestmentProfitOrLoss.Size = new System.Drawing.Size(245, 20);
            this.Lbl_txtInvestmentProfitOrLoss.TabIndex = 32;
            this.Lbl_txtInvestmentProfitOrLoss.Text = "Investment Profit/Loss";
            //
            // txtInvestmentProfitOrLoss
            //
            this.txtInvestmentProfitOrLoss.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvestmentProfitOrLoss.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvestmentProfitOrLoss.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInvestmentProfitOrLoss.Location = new System.Drawing.Point(630, 416);
            this.txtInvestmentProfitOrLoss.MaxLength = 20;
            this.txtInvestmentProfitOrLoss.Name = "txtInvestmentProfitOrLoss";
            this.txtInvestmentProfitOrLoss.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInvestmentProfitOrLoss.Size = new System.Drawing.Size(150, 20);
            this.txtInvestmentProfitOrLoss.TabIndex = 33;
            this.txtInvestmentProfitOrLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvestmentProfitOrLoss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtInvestmentProfitOrLoss.TextChanged += new System.EventHandler(this.txtInvestmentProfitOrLoss_TextChanged);
            //
            // Lbl_LblPctInvProfitOrLoss
            //
            this.Lbl_LblPctInvProfitOrLoss.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblPctInvProfitOrLoss.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblPctInvProfitOrLoss.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblPctInvProfitOrLoss.Location = new System.Drawing.Point(810, 418);
            this.Lbl_LblPctInvProfitOrLoss.Name = "Lbl_LblPctInvProfitOrLoss";
            this.Lbl_LblPctInvProfitOrLoss.Size = new System.Drawing.Size(250, 20);
            this.Lbl_LblPctInvProfitOrLoss.TabIndex = 34;
            this.Lbl_LblPctInvProfitOrLoss.Text = "Percentage Investment Profit/Loss";
            //
            // LblPctInvProfitOrLoss
            //
            this.LblPctInvProfitOrLoss.BackColor = System.Drawing.Color.Transparent;
            this.LblPctInvProfitOrLoss.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPctInvProfitOrLoss.ForeColor = System.Drawing.Color.Black;
            this.LblPctInvProfitOrLoss.Location = new System.Drawing.Point(1065, 418);
            this.LblPctInvProfitOrLoss.Name = "LblPctInvProfitOrLoss";
            this.LblPctInvProfitOrLoss.Size = new System.Drawing.Size(150, 20);
            this.LblPctInvProfitOrLoss.TabIndex = 35;
            this.LblPctInvProfitOrLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_txtTotalSurplusOrMinus
            //
            this.Lbl_txtTotalSurplusOrMinus.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtTotalSurplusOrMinus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtTotalSurplusOrMinus.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtTotalSurplusOrMinus.Location = new System.Drawing.Point(19, 446);
            this.Lbl_txtTotalSurplusOrMinus.Name = "Lbl_txtTotalSurplusOrMinus";
            this.Lbl_txtTotalSurplusOrMinus.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtTotalSurplusOrMinus.TabIndex = 36;
            this.Lbl_txtTotalSurplusOrMinus.Text = "Total Surplus/Minus";
            //
            // txtTotalSurplusOrMinus
            //
            this.txtTotalSurplusOrMinus.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalSurplusOrMinus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSurplusOrMinus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalSurplusOrMinus.Location = new System.Drawing.Point(200, 444);
            this.txtTotalSurplusOrMinus.MaxLength = 20;
            this.txtTotalSurplusOrMinus.Name = "txtTotalSurplusOrMinus";
            this.txtTotalSurplusOrMinus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalSurplusOrMinus.Size = new System.Drawing.Size(150, 20);
            this.txtTotalSurplusOrMinus.TabIndex = 37;
            this.txtTotalSurplusOrMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalSurplusOrMinus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtTotalSurplusOrMinus.TextChanged += new System.EventHandler(this.txtTotalSurplusOrMinus_TextChanged);
            //
            // Lbl_LblPctTotalSurplusOrMinus
            //
            this.Lbl_LblPctTotalSurplusOrMinus.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblPctTotalSurplusOrMinus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblPctTotalSurplusOrMinus.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblPctTotalSurplusOrMinus.Location = new System.Drawing.Point(380, 446);
            this.Lbl_LblPctTotalSurplusOrMinus.Name = "Lbl_LblPctTotalSurplusOrMinus";
            this.Lbl_LblPctTotalSurplusOrMinus.Size = new System.Drawing.Size(245, 20);
            this.Lbl_LblPctTotalSurplusOrMinus.TabIndex = 38;
            this.Lbl_LblPctTotalSurplusOrMinus.Text = "Percentage Total Surplus/Minus";
            //
            // LblPctTotalSurplusOrMinus
            //
            this.LblPctTotalSurplusOrMinus.BackColor = System.Drawing.Color.Transparent;
            this.LblPctTotalSurplusOrMinus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPctTotalSurplusOrMinus.ForeColor = System.Drawing.Color.Black;
            this.LblPctTotalSurplusOrMinus.Location = new System.Drawing.Point(630, 446);
            this.LblPctTotalSurplusOrMinus.Name = "LblPctTotalSurplusOrMinus";
            this.LblPctTotalSurplusOrMinus.Size = new System.Drawing.Size(150, 20);
            this.LblPctTotalSurplusOrMinus.TabIndex = 39;
            this.LblPctTotalSurplusOrMinus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_txtTransferOut
            //
            this.Lbl_txtTransferOut.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtTransferOut.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtTransferOut.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtTransferOut.Location = new System.Drawing.Point(810, 446);
            this.Lbl_txtTransferOut.Name = "Lbl_txtTransferOut";
            this.Lbl_txtTransferOut.Size = new System.Drawing.Size(250, 20);
            this.Lbl_txtTransferOut.TabIndex = 40;
            this.Lbl_txtTransferOut.Text = "Transfer Out";
            //
            // txtTransferOut
            //
            this.txtTransferOut.BackColor = System.Drawing.SystemColors.Window;
            this.txtTransferOut.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferOut.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTransferOut.Location = new System.Drawing.Point(1065, 444);
            this.txtTransferOut.MaxLength = 20;
            this.txtTransferOut.Name = "txtTransferOut";
            this.txtTransferOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTransferOut.Size = new System.Drawing.Size(150, 20);
            this.txtTransferOut.TabIndex = 41;
            this.txtTransferOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransferOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtTransferOut.TextChanged += new System.EventHandler(this.txtTransferOut_TextChanged);
            //
            // Lbl_txtEndingBalance
            //
            this.Lbl_txtEndingBalance.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtEndingBalance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtEndingBalance.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtEndingBalance.Location = new System.Drawing.Point(19, 474);
            this.Lbl_txtEndingBalance.Name = "Lbl_txtEndingBalance";
            this.Lbl_txtEndingBalance.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtEndingBalance.TabIndex = 42;
            this.Lbl_txtEndingBalance.Text = "Ending Balance";
            //
            // txtEndingBalance
            //
            this.txtEndingBalance.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndingBalance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndingBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndingBalance.Location = new System.Drawing.Point(200, 472);
            this.txtEndingBalance.MaxLength = 20;
            this.txtEndingBalance.Name = "txtEndingBalance";
            this.txtEndingBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEndingBalance.Size = new System.Drawing.Size(150, 20);
            this.txtEndingBalance.TabIndex = 43;
            this.txtEndingBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEndingBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtEndingBalance.TextChanged += new System.EventHandler(this.txtEndingBalance_TextChanged);
            //
            // LblSuperDesc
            //
            this.LblSuperDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblSuperDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSuperDesc.ForeColor = System.Drawing.Color.Black;
            this.LblSuperDesc.Location = new System.Drawing.Point(790, 306);
            this.LblSuperDesc.Name = "LblSuperDesc";
            this.LblSuperDesc.Size = new System.Drawing.Size(454, 20);
            this.LblSuperDesc.TabIndex = 44;
            //
            // CmdCreate
            //
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.Location = new System.Drawing.Point(200, 508);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(95, 28);
            this.CmdCreate.TabIndex = 45;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.Location = new System.Drawing.Point(300, 508);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(95, 28);
            this.CmdUpdate.TabIndex = 46;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.Location = new System.Drawing.Point(400, 508);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(95, 28);
            this.CmdDel.TabIndex = 47;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(1134, 508);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 48;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Super_Financial_Year
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1264, 560);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.LblSuperDesc);
            this.Controls.Add(this.txtEndingBalance);
            this.Controls.Add(this.Lbl_txtEndingBalance);
            this.Controls.Add(this.txtTransferOut);
            this.Controls.Add(this.Lbl_txtTransferOut);
            this.Controls.Add(this.LblPctTotalSurplusOrMinus);
            this.Controls.Add(this.Lbl_LblPctTotalSurplusOrMinus);
            this.Controls.Add(this.txtTotalSurplusOrMinus);
            this.Controls.Add(this.Lbl_txtTotalSurplusOrMinus);
            this.Controls.Add(this.LblPctInvProfitOrLoss);
            this.Controls.Add(this.Lbl_LblPctInvProfitOrLoss);
            this.Controls.Add(this.txtInvestmentProfitOrLoss);
            this.Controls.Add(this.Lbl_txtInvestmentProfitOrLoss);
            this.Controls.Add(this.txtGovermentTaxBenefit);
            this.Controls.Add(this.Lbl_txtGovermentTaxBenefit);
            this.Controls.Add(this.txtGovermentTax);
            this.Controls.Add(this.Lbl_txtGovermentTax);
            this.Controls.Add(this.txtInsurancePremium);
            this.Controls.Add(this.Lbl_txtInsurancePremium);
            this.Controls.Add(this.txtAdminFee);
            this.Controls.Add(this.Lbl_txtAdminFee);
            this.Controls.Add(this.LblPctInvReturns);
            this.Controls.Add(this.Lbl_LblPctInvReturns);
            this.Controls.Add(this.txtInvestmentReturns);
            this.Controls.Add(this.Lbl_txtInvestmentReturns);
            this.Controls.Add(this.txtTransferIn);
            this.Controls.Add(this.Lbl_txtTransferIn);
            this.Controls.Add(this.txtContribution);
            this.Controls.Add(this.Lbl_txtContribution);
            this.Controls.Add(this.txtOpeningBalance);
            this.Controls.Add(this.Lbl_txtOpeningBalance);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.Lbl_CmbCurrency);
            this.Controls.Add(this.CmbSuperCode);
            this.Controls.Add(this.Lbl_CmbSuperCode);
            this.Controls.Add(this.CmbFinYear);
            this.Controls.Add(this.Lbl_CmbFinYear);
            this.Controls.Add(this.gvSFY);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmbFilterSuper);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CmbFilterFinYear);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Super_Financial_Year";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super";
            this.Load += new System.EventHandler(this.Super_Financial_Year_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSFY)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvestment;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSale;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDistribution;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksCostBase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFYRecon;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbFilterFinYear;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbFilterSuper;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvSFY;
        public System.Windows.Forms.Label Lbl_CmbFinYear;
        public System.Windows.Forms.ComboBox CmbFinYear;
        public System.Windows.Forms.Label Lbl_CmbSuperCode;
        public System.Windows.Forms.ComboBox CmbSuperCode;
        public System.Windows.Forms.Label Lbl_CmbCurrency;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.Label Lbl_txtOpeningBalance;
        public System.Windows.Forms.TextBox txtOpeningBalance;
        public System.Windows.Forms.Label Lbl_txtContribution;
        public System.Windows.Forms.TextBox txtContribution;
        public System.Windows.Forms.Label Lbl_txtTransferIn;
        public System.Windows.Forms.TextBox txtTransferIn;
        public System.Windows.Forms.Label Lbl_txtInvestmentReturns;
        public System.Windows.Forms.TextBox txtInvestmentReturns;
        public System.Windows.Forms.Label Lbl_LblPctInvReturns;
        public System.Windows.Forms.Label LblPctInvReturns;
        public System.Windows.Forms.Label Lbl_txtAdminFee;
        public System.Windows.Forms.TextBox txtAdminFee;
        public System.Windows.Forms.Label Lbl_txtInsurancePremium;
        public System.Windows.Forms.TextBox txtInsurancePremium;
        public System.Windows.Forms.Label Lbl_txtGovermentTax;
        public System.Windows.Forms.TextBox txtGovermentTax;
        public System.Windows.Forms.Label Lbl_txtGovermentTaxBenefit;
        public System.Windows.Forms.TextBox txtGovermentTaxBenefit;
        public System.Windows.Forms.Label Lbl_txtInvestmentProfitOrLoss;
        public System.Windows.Forms.TextBox txtInvestmentProfitOrLoss;
        public System.Windows.Forms.Label Lbl_LblPctInvProfitOrLoss;
        public System.Windows.Forms.Label LblPctInvProfitOrLoss;
        public System.Windows.Forms.Label Lbl_txtTotalSurplusOrMinus;
        public System.Windows.Forms.TextBox txtTotalSurplusOrMinus;
        public System.Windows.Forms.Label Lbl_LblPctTotalSurplusOrMinus;
        public System.Windows.Forms.Label LblPctTotalSurplusOrMinus;
        public System.Windows.Forms.Label Lbl_txtTransferOut;
        public System.Windows.Forms.TextBox txtTransferOut;
        public System.Windows.Forms.Label Lbl_txtEndingBalance;
        public System.Windows.Forms.TextBox txtEndingBalance;
        public System.Windows.Forms.Label LblSuperDesc;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
