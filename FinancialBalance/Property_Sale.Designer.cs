namespace FinancialBalance
{
    partial class Property_Sale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Property_Sale));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDailyInput = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksCostBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFYRecon = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.gvSale = new System.Windows.Forms.DataGridView();
            this.Lbl_CmbPropertyId = new System.Windows.Forms.Label();
            this.CmbPropertyId = new System.Windows.Forms.ComboBox();
            this.LblPropertyName = new System.Windows.Forms.Label();
            this.Lbl_Sold = new System.Windows.Forms.Label();
            this.CmbSoldDD = new System.Windows.Forms.ComboBox();
            this.CmbSoldMM = new System.Windows.Forms.ComboBox();
            this.CmbSoldYear = new System.Windows.Forms.ComboBox();
            this.CmdSoldCal = new System.Windows.Forms.Button();
            this.Lbl_txtSoldPrice = new System.Windows.Forms.Label();
            this.txtSoldPrice = new System.Windows.Forms.TextBox();
            this.Lbl_txtConveyancing = new System.Windows.Forms.Label();
            this.txtConveyancing = new System.Windows.Forms.TextBox();
            this.Lbl_txtSaleAgent = new System.Windows.Forms.Label();
            this.txtSaleAgent = new System.Windows.Forms.TextBox();
            this.Lbl_txtSettlement = new System.Windows.Forms.Label();
            this.txtSettlement = new System.Windows.Forms.TextBox();
            this.Lbl_txtOtherCost = new System.Windows.Forms.Label();
            this.txtOtherCost = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.LblNote = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSale)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDailyInput,
            this.MnMonthlyClosing,
            this.MnETFStockProcessGroup,
            this.MnPropertyProcessGroup,
            this.MnSuperProcess});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(1100, 24);
            this.MainMenu1.TabIndex = 1;
            // 
            // MnDailyInput
            // 
            this.MnDailyInput.Name = "MnDailyInput";
            this.MnDailyInput.Size = new System.Drawing.Size(150, 20);
            this.MnDailyInput.Text = "&Daily Input";
            this.MnDailyInput.Click += new System.EventHandler(this.MnDailyInput_Click);
            // 
            // MnMonthlyClosing
            // 
            this.MnMonthlyClosing.Name = "MnMonthlyClosing";
            this.MnMonthlyClosing.Size = new System.Drawing.Size(150, 20);
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
            this.MnETFStockProcessGroup.Size = new System.Drawing.Size(150, 20);
            this.MnETFStockProcessGroup.Text = "&ETF/Stock";
            // 
            // MnETFStocksPrice
            // 
            this.MnETFStocksPrice.Name = "MnETFStocksPrice";
            this.MnETFStocksPrice.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksPrice.Text = "ETF/Stock &Price";
            this.MnETFStocksPrice.Click += new System.EventHandler(this.MnETFStocksPrice_Click);
            // 
            // MnETFStocksInvestment
            // 
            this.MnETFStocksInvestment.Name = "MnETFStocksInvestment";
            this.MnETFStocksInvestment.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksInvestment.Text = "ETF/Stock &Investment";
            this.MnETFStocksInvestment.Click += new System.EventHandler(this.MnETFStocksInvestment_Click);
            // 
            // MnETFStocksPurchase
            // 
            this.MnETFStocksPurchase.Name = "MnETFStocksPurchase";
            this.MnETFStocksPurchase.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksPurchase.Text = "ETF/Stock &Purchase";
            this.MnETFStocksPurchase.Click += new System.EventHandler(this.MnETFStocksPurchase_Click);
            // 
            // MnETFStocksSale
            // 
            this.MnETFStocksSale.Name = "MnETFStocksSale";
            this.MnETFStocksSale.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksSale.Text = "ETF/Stock &Sale";
            this.MnETFStocksSale.Click += new System.EventHandler(this.MnETFStocksSale_Click);
            // 
            // MnETFStocksDistribution
            // 
            this.MnETFStocksDistribution.Name = "MnETFStocksDistribution";
            this.MnETFStocksDistribution.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksDistribution.Text = "ETF/Stock &Distribution/Dividend";
            this.MnETFStocksDistribution.Click += new System.EventHandler(this.MnETFStocksDistribution_Click);
            // 
            // MnETFStocksCostBase
            // 
            this.MnETFStocksCostBase.Name = "MnETFStocksCostBase";
            this.MnETFStocksCostBase.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksCostBase.Text = "ETF/Stock &Cost Base Adjustment";
            this.MnETFStocksCostBase.Click += new System.EventHandler(this.MnETFStocksCostBase_Click);
            // 
            // MnETFStocksFYRecon
            // 
            this.MnETFStocksFYRecon.Name = "MnETFStocksFYRecon";
            this.MnETFStocksFYRecon.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksFYRecon.Text = "ETF/Stock Financial &Year Reconciliation";
            this.MnETFStocksFYRecon.Click += new System.EventHandler(this.MnETFStocksFYRecon_Click);
            // 
            // MnPropertyProcessGroup
            // 
            this.MnPropertyProcessGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnPropertySetup,
            this.MnPropertyPurchase});
            this.MnPropertyProcessGroup.Name = "MnPropertyProcessGroup";
            this.MnPropertyProcessGroup.Size = new System.Drawing.Size(150, 20);
            this.MnPropertyProcessGroup.Text = "P&roperty";
            // 
            // MnPropertySetup
            // 
            this.MnPropertySetup.Name = "MnPropertySetup";
            this.MnPropertySetup.Size = new System.Drawing.Size(216, 22);
            this.MnPropertySetup.Text = "P&roperty Setup";
            this.MnPropertySetup.Click += new System.EventHandler(this.MnPropertySetup_Click);
            // 
            // MnPropertyPurchase
            // 
            this.MnPropertyPurchase.Name = "MnPropertyPurchase";
            this.MnPropertyPurchase.Size = new System.Drawing.Size(216, 22);
            this.MnPropertyPurchase.Text = "Property P&urchase";
            this.MnPropertyPurchase.Click += new System.EventHandler(this.MnPropertyPurchase_Click);
            // 
            // MnSuperProcess
            // 
            this.MnSuperProcess.Name = "MnSuperProcess";
            this.MnSuperProcess.Size = new System.Drawing.Size(150, 20);
            this.MnSuperProcess.Text = "&Super";
            this.MnSuperProcess.Click += new System.EventHandler(this.MnSuperProcess_Click);
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 28);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(1060, 40);
            this.Label21.TabIndex = 2;
            this.Label21.Text = "PROPERTY SALE";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvSale
            // 
            this.gvSale.AllowUserToAddRows = false;
            this.gvSale.AllowUserToDeleteRows = false;
            this.gvSale.AllowUserToResizeRows = false;
            this.gvSale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSale.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvSale.Location = new System.Drawing.Point(19, 76);
            this.gvSale.MultiSelect = false;
            this.gvSale.Name = "gvSale";
            this.gvSale.ReadOnly = true;
            this.gvSale.RowHeadersVisible = false;
            this.gvSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSale.Size = new System.Drawing.Size(1062, 230);
            this.gvSale.TabIndex = 3;
            this.gvSale.SelectionChanged += new System.EventHandler(this.gvSale_SelectionChanged);
            // 
            // Lbl_CmbPropertyId
            // 
            this.Lbl_CmbPropertyId.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbPropertyId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbPropertyId.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbPropertyId.Location = new System.Drawing.Point(19, 324);
            this.Lbl_CmbPropertyId.Name = "Lbl_CmbPropertyId";
            this.Lbl_CmbPropertyId.Size = new System.Drawing.Size(140, 22);
            this.Lbl_CmbPropertyId.TabIndex = 4;
            this.Lbl_CmbPropertyId.Text = "Property Id";
            this.Lbl_CmbPropertyId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbPropertyId
            // 
            this.CmbPropertyId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPropertyId.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPropertyId.FormattingEnabled = true;
            this.CmbPropertyId.Location = new System.Drawing.Point(165, 322);
            this.CmbPropertyId.Name = "CmbPropertyId";
            this.CmbPropertyId.Size = new System.Drawing.Size(80, 22);
            this.CmbPropertyId.TabIndex = 5;
            this.CmbPropertyId.SelectedIndexChanged += new System.EventHandler(this.CmbPropertyId_SelectedIndexChanged);
            // 
            // LblPropertyName
            // 
            this.LblPropertyName.BackColor = System.Drawing.Color.Transparent;
            this.LblPropertyName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPropertyName.ForeColor = System.Drawing.Color.Black;
            this.LblPropertyName.Location = new System.Drawing.Point(255, 324);
            this.LblPropertyName.Name = "LblPropertyName";
            this.LblPropertyName.Size = new System.Drawing.Size(240, 22);
            this.LblPropertyName.TabIndex = 6;
            // 
            // Lbl_Sold
            // 
            this.Lbl_Sold.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Sold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Sold.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Sold.Location = new System.Drawing.Point(19, 354);
            this.Lbl_Sold.Name = "Lbl_Sold";
            this.Lbl_Sold.Size = new System.Drawing.Size(140, 22);
            this.Lbl_Sold.TabIndex = 7;
            this.Lbl_Sold.Text = "Sold Date";
            this.Lbl_Sold.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbSoldDD
            // 
            this.CmbSoldDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldDD.FormattingEnabled = true;
            this.CmbSoldDD.Location = new System.Drawing.Point(165, 352);
            this.CmbSoldDD.Name = "CmbSoldDD";
            this.CmbSoldDD.Size = new System.Drawing.Size(41, 22);
            this.CmbSoldDD.TabIndex = 8;
            // 
            // CmbSoldMM
            // 
            this.CmbSoldMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldMM.FormattingEnabled = true;
            this.CmbSoldMM.Location = new System.Drawing.Point(215, 352);
            this.CmbSoldMM.Name = "CmbSoldMM";
            this.CmbSoldMM.Size = new System.Drawing.Size(41, 22);
            this.CmbSoldMM.TabIndex = 9;
            // 
            // CmbSoldYear
            // 
            this.CmbSoldYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldYear.FormattingEnabled = true;
            this.CmbSoldYear.Location = new System.Drawing.Point(265, 352);
            this.CmbSoldYear.Name = "CmbSoldYear";
            this.CmbSoldYear.Size = new System.Drawing.Size(57, 22);
            this.CmbSoldYear.TabIndex = 10;
            // 
            // CmdSoldCal
            // 
            this.CmdSoldCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSoldCal.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdSoldCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSoldCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSoldCal.Location = new System.Drawing.Point(330, 353);
            this.CmdSoldCal.Name = "CmdSoldCal";
            this.CmdSoldCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdSoldCal.Size = new System.Drawing.Size(25, 19);
            this.CmdSoldCal.TabIndex = 11;
            this.CmdSoldCal.Text = "..";
            this.CmdSoldCal.UseVisualStyleBackColor = false;
            this.CmdSoldCal.Click += new System.EventHandler(this.CmdSoldCal_Click);
            // 
            // Lbl_txtSoldPrice
            // 
            this.Lbl_txtSoldPrice.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtSoldPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtSoldPrice.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtSoldPrice.Location = new System.Drawing.Point(19, 384);
            this.Lbl_txtSoldPrice.Name = "Lbl_txtSoldPrice";
            this.Lbl_txtSoldPrice.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtSoldPrice.TabIndex = 12;
            this.Lbl_txtSoldPrice.Text = "Sold Price";
            this.Lbl_txtSoldPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoldPrice
            // 
            this.txtSoldPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtSoldPrice.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoldPrice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSoldPrice.Location = new System.Drawing.Point(165, 382);
            this.txtSoldPrice.MaxLength = 18;
            this.txtSoldPrice.Name = "txtSoldPrice";
            this.txtSoldPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSoldPrice.Size = new System.Drawing.Size(120, 20);
            this.txtSoldPrice.TabIndex = 13;
            this.txtSoldPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoldPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtConveyancing
            // 
            this.Lbl_txtConveyancing.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtConveyancing.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtConveyancing.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtConveyancing.Location = new System.Drawing.Point(19, 414);
            this.Lbl_txtConveyancing.Name = "Lbl_txtConveyancing";
            this.Lbl_txtConveyancing.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtConveyancing.TabIndex = 14;
            this.Lbl_txtConveyancing.Text = "Conveyancing Cost";
            this.Lbl_txtConveyancing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConveyancing
            // 
            this.txtConveyancing.BackColor = System.Drawing.SystemColors.Window;
            this.txtConveyancing.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConveyancing.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConveyancing.Location = new System.Drawing.Point(165, 412);
            this.txtConveyancing.MaxLength = 18;
            this.txtConveyancing.Name = "txtConveyancing";
            this.txtConveyancing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConveyancing.Size = new System.Drawing.Size(120, 20);
            this.txtConveyancing.TabIndex = 15;
            this.txtConveyancing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtConveyancing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtSaleAgent
            // 
            this.Lbl_txtSaleAgent.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtSaleAgent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtSaleAgent.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtSaleAgent.Location = new System.Drawing.Point(560, 324);
            this.Lbl_txtSaleAgent.Name = "Lbl_txtSaleAgent";
            this.Lbl_txtSaleAgent.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtSaleAgent.TabIndex = 16;
            this.Lbl_txtSaleAgent.Text = "Sale Agent Cost";
            this.Lbl_txtSaleAgent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSaleAgent
            // 
            this.txtSaleAgent.BackColor = System.Drawing.SystemColors.Window;
            this.txtSaleAgent.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleAgent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSaleAgent.Location = new System.Drawing.Point(716, 322);
            this.txtSaleAgent.MaxLength = 18;
            this.txtSaleAgent.Name = "txtSaleAgent";
            this.txtSaleAgent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSaleAgent.Size = new System.Drawing.Size(120, 20);
            this.txtSaleAgent.TabIndex = 17;
            this.txtSaleAgent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSaleAgent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtSettlement
            // 
            this.Lbl_txtSettlement.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtSettlement.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtSettlement.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtSettlement.Location = new System.Drawing.Point(560, 354);
            this.Lbl_txtSettlement.Name = "Lbl_txtSettlement";
            this.Lbl_txtSettlement.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtSettlement.TabIndex = 18;
            this.Lbl_txtSettlement.Text = "Settlement Cost";
            this.Lbl_txtSettlement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSettlement
            // 
            this.txtSettlement.BackColor = System.Drawing.SystemColors.Window;
            this.txtSettlement.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettlement.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSettlement.Location = new System.Drawing.Point(716, 352);
            this.txtSettlement.MaxLength = 18;
            this.txtSettlement.Name = "txtSettlement";
            this.txtSettlement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSettlement.Size = new System.Drawing.Size(120, 20);
            this.txtSettlement.TabIndex = 19;
            this.txtSettlement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSettlement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtOtherCost
            // 
            this.Lbl_txtOtherCost.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOtherCost.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOtherCost.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOtherCost.Location = new System.Drawing.Point(560, 384);
            this.Lbl_txtOtherCost.Name = "Lbl_txtOtherCost";
            this.Lbl_txtOtherCost.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtOtherCost.TabIndex = 20;
            this.Lbl_txtOtherCost.Text = "Other Cost";
            this.Lbl_txtOtherCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOtherCost
            // 
            this.txtOtherCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtOtherCost.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherCost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOtherCost.Location = new System.Drawing.Point(716, 382);
            this.txtOtherCost.MaxLength = 18;
            this.txtOtherCost.Name = "txtOtherCost";
            this.txtOtherCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOtherCost.Size = new System.Drawing.Size(120, 20);
            this.txtOtherCost.TabIndex = 21;
            this.txtOtherCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOtherCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(200, 130);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 22;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // LblNote
            // 
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 452);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1062, 22);
            this.LblNote.TabIndex = 23;
            // 
            // CmdCreate
            // 
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(615, 484);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdCreate.Size = new System.Drawing.Size(85, 28);
            this.CmdCreate.TabIndex = 24;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            // 
            // CmdUpdate
            // 
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdUpdate.Location = new System.Drawing.Point(710, 484);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdUpdate.Size = new System.Drawing.Size(85, 28);
            this.CmdUpdate.TabIndex = 25;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            // 
            // CmdClear
            // 
            this.CmdClear.BackColor = System.Drawing.SystemColors.Control;
            this.CmdClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdClear.Location = new System.Drawing.Point(805, 484);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdClear.Size = new System.Drawing.Size(85, 28);
            this.CmdClear.TabIndex = 26;
            this.CmdClear.Text = "&Clear";
            this.CmdClear.UseVisualStyleBackColor = false;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            // 
            // CmdDel
            // 
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(900, 484);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(85, 28);
            this.CmdDel.TabIndex = 27;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            // 
            // CmdBack
            // 
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(995, 484);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(85, 28);
            this.CmdBack.TabIndex = 28;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Property_Sale
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1100, 572);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.txtOtherCost);
            this.Controls.Add(this.Lbl_txtOtherCost);
            this.Controls.Add(this.txtSettlement);
            this.Controls.Add(this.Lbl_txtSettlement);
            this.Controls.Add(this.txtSaleAgent);
            this.Controls.Add(this.Lbl_txtSaleAgent);
            this.Controls.Add(this.txtConveyancing);
            this.Controls.Add(this.Lbl_txtConveyancing);
            this.Controls.Add(this.txtSoldPrice);
            this.Controls.Add(this.Lbl_txtSoldPrice);
            this.Controls.Add(this.CmdSoldCal);
            this.Controls.Add(this.CmbSoldYear);
            this.Controls.Add(this.CmbSoldMM);
            this.Controls.Add(this.CmbSoldDD);
            this.Controls.Add(this.Lbl_Sold);
            this.Controls.Add(this.LblPropertyName);
            this.Controls.Add(this.CmbPropertyId);
            this.Controls.Add(this.Lbl_CmbPropertyId);
            this.Controls.Add(this.gvSale);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Property_Sale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Sale";
            this.Load += new System.EventHandler(this.Property_Sale_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnDailyInput;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvestment;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSale;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDistribution;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksCostBase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFYRecon;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertySetup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnSuperProcess;
        public System.Windows.Forms.Label Label21;
        private System.Windows.Forms.DataGridView gvSale;
        public System.Windows.Forms.Label Lbl_CmbPropertyId;
        public System.Windows.Forms.ComboBox CmbPropertyId;
        public System.Windows.Forms.Label LblPropertyName;
        public System.Windows.Forms.Label Lbl_Sold;
        public System.Windows.Forms.ComboBox CmbSoldDD;
        public System.Windows.Forms.ComboBox CmbSoldMM;
        public System.Windows.Forms.ComboBox CmbSoldYear;
        public System.Windows.Forms.Button CmdSoldCal;
        public System.Windows.Forms.Label Lbl_txtSoldPrice;
        public System.Windows.Forms.TextBox txtSoldPrice;
        public System.Windows.Forms.Label Lbl_txtConveyancing;
        public System.Windows.Forms.TextBox txtConveyancing;
        public System.Windows.Forms.Label Lbl_txtSaleAgent;
        public System.Windows.Forms.TextBox txtSaleAgent;
        public System.Windows.Forms.Label Lbl_txtSettlement;
        public System.Windows.Forms.TextBox txtSettlement;
        public System.Windows.Forms.Label Lbl_txtOtherCost;
        public System.Windows.Forms.TextBox txtOtherCost;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
