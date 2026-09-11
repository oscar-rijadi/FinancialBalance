namespace FinancialBalance
{
    partial class Property_Purchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Property_Purchase));
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
            this.MnSuperProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.gvPurchase = new System.Windows.Forms.DataGridView();
            this.Lbl_CmbPropertyId = new System.Windows.Forms.Label();
            this.CmbPropertyId = new System.Windows.Forms.ComboBox();
            this.LblPropertyName = new System.Windows.Forms.Label();
            this.Lbl_Purchase = new System.Windows.Forms.Label();
            this.CmbPurchDD = new System.Windows.Forms.ComboBox();
            this.CmbPurchMM = new System.Windows.Forms.ComboBox();
            this.CmbPurchYear = new System.Windows.Forms.ComboBox();
            this.CmdPurchCal = new System.Windows.Forms.Button();
            this.Lbl_txtPurchasePrice = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.Lbl_txtStampDuty = new System.Windows.Forms.Label();
            this.txtStampDuty = new System.Windows.Forms.TextBox();
            this.Lbl_txtConveyancing = new System.Windows.Forms.Label();
            this.txtConveyancing = new System.Windows.Forms.TextBox();
            this.Lbl_txtInspection = new System.Windows.Forms.Label();
            this.txtInspection = new System.Windows.Forms.TextBox();
            this.Lbl_txtBuyersAgent = new System.Windows.Forms.Label();
            this.txtBuyersAgent = new System.Windows.Forms.TextBox();
            this.Lbl_txtSettlement = new System.Windows.Forms.Label();
            this.txtSettlement = new System.Windows.Forms.TextBox();
            this.Lbl_txtOtherCost = new System.Windows.Forms.Label();
            this.txtOtherCost = new System.Windows.Forms.TextBox();
            this.Lbl_txtDownPayment = new System.Windows.Forms.Label();
            this.txtDownPayment = new System.Windows.Forms.TextBox();
            this.Lbl_txtInitialLoan = new System.Windows.Forms.Label();
            this.txtInitialLoan = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.LblNote = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchase)).BeginInit();
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
            this.MainMenu1.Size = new System.Drawing.Size(1264, 24);
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
            this.MnPropertySetup});
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
            this.Label21.Size = new System.Drawing.Size(1224, 40);
            this.Label21.TabIndex = 2;
            this.Label21.Text = "PROPERTY PURCHASE";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvPurchase
            // 
            this.gvPurchase.AllowUserToAddRows = false;
            this.gvPurchase.AllowUserToDeleteRows = false;
            this.gvPurchase.AllowUserToResizeRows = false;
            this.gvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPurchase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvPurchase.Location = new System.Drawing.Point(19, 76);
            this.gvPurchase.MultiSelect = false;
            this.gvPurchase.Name = "gvPurchase";
            this.gvPurchase.ReadOnly = true;
            this.gvPurchase.RowHeadersVisible = false;
            this.gvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPurchase.Size = new System.Drawing.Size(1226, 230);
            this.gvPurchase.TabIndex = 3;
            this.gvPurchase.SelectionChanged += new System.EventHandler(this.gvPurchase_SelectionChanged);
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
            this.LblPropertyName.Size = new System.Drawing.Size(200, 22);
            this.LblPropertyName.TabIndex = 6;
            // 
            // Lbl_Purchase
            // 
            this.Lbl_Purchase.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Purchase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Purchase.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Purchase.Location = new System.Drawing.Point(19, 354);
            this.Lbl_Purchase.Name = "Lbl_Purchase";
            this.Lbl_Purchase.Size = new System.Drawing.Size(140, 22);
            this.Lbl_Purchase.TabIndex = 7;
            this.Lbl_Purchase.Text = "Purchase Date";
            this.Lbl_Purchase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbPurchDD
            // 
            this.CmbPurchDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPurchDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPurchDD.FormattingEnabled = true;
            this.CmbPurchDD.Location = new System.Drawing.Point(165, 352);
            this.CmbPurchDD.Name = "CmbPurchDD";
            this.CmbPurchDD.Size = new System.Drawing.Size(41, 22);
            this.CmbPurchDD.TabIndex = 8;
            // 
            // CmbPurchMM
            // 
            this.CmbPurchMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPurchMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPurchMM.FormattingEnabled = true;
            this.CmbPurchMM.Location = new System.Drawing.Point(215, 352);
            this.CmbPurchMM.Name = "CmbPurchMM";
            this.CmbPurchMM.Size = new System.Drawing.Size(41, 22);
            this.CmbPurchMM.TabIndex = 9;
            // 
            // CmbPurchYear
            // 
            this.CmbPurchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPurchYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPurchYear.FormattingEnabled = true;
            this.CmbPurchYear.Location = new System.Drawing.Point(265, 352);
            this.CmbPurchYear.Name = "CmbPurchYear";
            this.CmbPurchYear.Size = new System.Drawing.Size(57, 22);
            this.CmbPurchYear.TabIndex = 10;
            // 
            // CmdPurchCal
            // 
            this.CmdPurchCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdPurchCal.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdPurchCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdPurchCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdPurchCal.Location = new System.Drawing.Point(330, 353);
            this.CmdPurchCal.Name = "CmdPurchCal";
            this.CmdPurchCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdPurchCal.Size = new System.Drawing.Size(25, 19);
            this.CmdPurchCal.TabIndex = 11;
            this.CmdPurchCal.Text = "..";
            this.CmdPurchCal.UseVisualStyleBackColor = false;
            this.CmdPurchCal.Click += new System.EventHandler(this.CmdPurchCal_Click);
            // 
            // Lbl_txtPurchasePrice
            // 
            this.Lbl_txtPurchasePrice.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtPurchasePrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtPurchasePrice.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtPurchasePrice.Location = new System.Drawing.Point(19, 384);
            this.Lbl_txtPurchasePrice.Name = "Lbl_txtPurchasePrice";
            this.Lbl_txtPurchasePrice.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtPurchasePrice.TabIndex = 12;
            this.Lbl_txtPurchasePrice.Text = "Purchase Price";
            this.Lbl_txtPurchasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtPurchasePrice.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchasePrice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPurchasePrice.Location = new System.Drawing.Point(165, 382);
            this.txtPurchasePrice.MaxLength = 18;
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPurchasePrice.Size = new System.Drawing.Size(120, 20);
            this.txtPurchasePrice.TabIndex = 13;
            this.txtPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtStampDuty
            // 
            this.Lbl_txtStampDuty.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtStampDuty.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtStampDuty.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtStampDuty.Location = new System.Drawing.Point(19, 414);
            this.Lbl_txtStampDuty.Name = "Lbl_txtStampDuty";
            this.Lbl_txtStampDuty.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtStampDuty.TabIndex = 14;
            this.Lbl_txtStampDuty.Text = "Stamp Duty";
            this.Lbl_txtStampDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStampDuty
            // 
            this.txtStampDuty.BackColor = System.Drawing.SystemColors.Window;
            this.txtStampDuty.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStampDuty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStampDuty.Location = new System.Drawing.Point(165, 412);
            this.txtStampDuty.MaxLength = 18;
            this.txtStampDuty.Name = "txtStampDuty";
            this.txtStampDuty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStampDuty.Size = new System.Drawing.Size(120, 20);
            this.txtStampDuty.TabIndex = 15;
            this.txtStampDuty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStampDuty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtConveyancing
            // 
            this.Lbl_txtConveyancing.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtConveyancing.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtConveyancing.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtConveyancing.Location = new System.Drawing.Point(470, 324);
            this.Lbl_txtConveyancing.Name = "Lbl_txtConveyancing";
            this.Lbl_txtConveyancing.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtConveyancing.TabIndex = 16;
            this.Lbl_txtConveyancing.Text = "Conveyancing Cost";
            this.Lbl_txtConveyancing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConveyancing
            // 
            this.txtConveyancing.BackColor = System.Drawing.SystemColors.Window;
            this.txtConveyancing.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConveyancing.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConveyancing.Location = new System.Drawing.Point(626, 322);
            this.txtConveyancing.MaxLength = 18;
            this.txtConveyancing.Name = "txtConveyancing";
            this.txtConveyancing.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtConveyancing.Size = new System.Drawing.Size(120, 20);
            this.txtConveyancing.TabIndex = 17;
            this.txtConveyancing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtConveyancing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtInspection
            // 
            this.Lbl_txtInspection.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtInspection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtInspection.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtInspection.Location = new System.Drawing.Point(470, 354);
            this.Lbl_txtInspection.Name = "Lbl_txtInspection";
            this.Lbl_txtInspection.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtInspection.TabIndex = 18;
            this.Lbl_txtInspection.Text = "B&&P Inspection Cost";
            this.Lbl_txtInspection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInspection
            // 
            this.txtInspection.BackColor = System.Drawing.SystemColors.Window;
            this.txtInspection.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInspection.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInspection.Location = new System.Drawing.Point(626, 352);
            this.txtInspection.MaxLength = 18;
            this.txtInspection.Name = "txtInspection";
            this.txtInspection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInspection.Size = new System.Drawing.Size(120, 20);
            this.txtInspection.TabIndex = 19;
            this.txtInspection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInspection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtBuyersAgent
            // 
            this.Lbl_txtBuyersAgent.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtBuyersAgent.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtBuyersAgent.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtBuyersAgent.Location = new System.Drawing.Point(470, 384);
            this.Lbl_txtBuyersAgent.Name = "Lbl_txtBuyersAgent";
            this.Lbl_txtBuyersAgent.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtBuyersAgent.TabIndex = 20;
            this.Lbl_txtBuyersAgent.Text = "BA Cost";
            this.Lbl_txtBuyersAgent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBuyersAgent
            // 
            this.txtBuyersAgent.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuyersAgent.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyersAgent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBuyersAgent.Location = new System.Drawing.Point(626, 382);
            this.txtBuyersAgent.MaxLength = 18;
            this.txtBuyersAgent.Name = "txtBuyersAgent";
            this.txtBuyersAgent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBuyersAgent.Size = new System.Drawing.Size(120, 20);
            this.txtBuyersAgent.TabIndex = 21;
            this.txtBuyersAgent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBuyersAgent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtSettlement
            // 
            this.Lbl_txtSettlement.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtSettlement.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtSettlement.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtSettlement.Location = new System.Drawing.Point(470, 414);
            this.Lbl_txtSettlement.Name = "Lbl_txtSettlement";
            this.Lbl_txtSettlement.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtSettlement.TabIndex = 22;
            this.Lbl_txtSettlement.Text = "Settlement Cost";
            this.Lbl_txtSettlement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSettlement
            // 
            this.txtSettlement.BackColor = System.Drawing.SystemColors.Window;
            this.txtSettlement.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettlement.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSettlement.Location = new System.Drawing.Point(626, 412);
            this.txtSettlement.MaxLength = 18;
            this.txtSettlement.Name = "txtSettlement";
            this.txtSettlement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSettlement.Size = new System.Drawing.Size(120, 20);
            this.txtSettlement.TabIndex = 23;
            this.txtSettlement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSettlement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtOtherCost
            // 
            this.Lbl_txtOtherCost.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOtherCost.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOtherCost.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOtherCost.Location = new System.Drawing.Point(860, 324);
            this.Lbl_txtOtherCost.Name = "Lbl_txtOtherCost";
            this.Lbl_txtOtherCost.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtOtherCost.TabIndex = 24;
            this.Lbl_txtOtherCost.Text = "Other Cost";
            this.Lbl_txtOtherCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOtherCost
            // 
            this.txtOtherCost.BackColor = System.Drawing.SystemColors.Window;
            this.txtOtherCost.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherCost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOtherCost.Location = new System.Drawing.Point(1016, 322);
            this.txtOtherCost.MaxLength = 18;
            this.txtOtherCost.Name = "txtOtherCost";
            this.txtOtherCost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOtherCost.Size = new System.Drawing.Size(120, 20);
            this.txtOtherCost.TabIndex = 25;
            this.txtOtherCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOtherCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtDownPayment
            // 
            this.Lbl_txtDownPayment.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtDownPayment.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtDownPayment.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtDownPayment.Location = new System.Drawing.Point(860, 354);
            this.Lbl_txtDownPayment.Name = "Lbl_txtDownPayment";
            this.Lbl_txtDownPayment.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtDownPayment.TabIndex = 26;
            this.Lbl_txtDownPayment.Text = "DP";
            this.Lbl_txtDownPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDownPayment
            // 
            this.txtDownPayment.BackColor = System.Drawing.SystemColors.Window;
            this.txtDownPayment.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDownPayment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDownPayment.Location = new System.Drawing.Point(1016, 352);
            this.txtDownPayment.MaxLength = 18;
            this.txtDownPayment.Name = "txtDownPayment";
            this.txtDownPayment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDownPayment.Size = new System.Drawing.Size(120, 20);
            this.txtDownPayment.TabIndex = 27;
            this.txtDownPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDownPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Lbl_txtInitialLoan
            // 
            this.Lbl_txtInitialLoan.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtInitialLoan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtInitialLoan.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtInitialLoan.Location = new System.Drawing.Point(860, 384);
            this.Lbl_txtInitialLoan.Name = "Lbl_txtInitialLoan";
            this.Lbl_txtInitialLoan.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtInitialLoan.TabIndex = 28;
            this.Lbl_txtInitialLoan.Text = "Initial Loan";
            this.Lbl_txtInitialLoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInitialLoan
            // 
            this.txtInitialLoan.BackColor = System.Drawing.SystemColors.Window;
            this.txtInitialLoan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInitialLoan.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInitialLoan.Location = new System.Drawing.Point(1016, 382);
            this.txtInitialLoan.MaxLength = 18;
            this.txtInitialLoan.Name = "txtInitialLoan";
            this.txtInitialLoan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInitialLoan.Size = new System.Drawing.Size(120, 20);
            this.txtInitialLoan.TabIndex = 29;
            this.txtInitialLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInitialLoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(200, 130);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 30;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // LblNote
            // 
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 452);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1226, 22);
            this.LblNote.TabIndex = 31;
            // 
            // CmdCreate
            // 
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(789, 484);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdCreate.Size = new System.Drawing.Size(85, 28);
            this.CmdCreate.TabIndex = 32;
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
            this.CmdUpdate.Location = new System.Drawing.Point(884, 484);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdUpdate.Size = new System.Drawing.Size(85, 28);
            this.CmdUpdate.TabIndex = 33;
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
            this.CmdClear.Location = new System.Drawing.Point(979, 484);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdClear.Size = new System.Drawing.Size(85, 28);
            this.CmdClear.TabIndex = 34;
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
            this.CmdDel.Location = new System.Drawing.Point(1074, 484);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(85, 28);
            this.CmdDel.TabIndex = 35;
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
            this.CmdBack.Location = new System.Drawing.Point(1160, 484);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(85, 28);
            this.CmdBack.TabIndex = 36;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Property_Purchase
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1264, 600);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.txtInitialLoan);
            this.Controls.Add(this.Lbl_txtInitialLoan);
            this.Controls.Add(this.txtDownPayment);
            this.Controls.Add(this.Lbl_txtDownPayment);
            this.Controls.Add(this.txtOtherCost);
            this.Controls.Add(this.Lbl_txtOtherCost);
            this.Controls.Add(this.txtSettlement);
            this.Controls.Add(this.Lbl_txtSettlement);
            this.Controls.Add(this.txtBuyersAgent);
            this.Controls.Add(this.Lbl_txtBuyersAgent);
            this.Controls.Add(this.txtInspection);
            this.Controls.Add(this.Lbl_txtInspection);
            this.Controls.Add(this.txtConveyancing);
            this.Controls.Add(this.Lbl_txtConveyancing);
            this.Controls.Add(this.txtStampDuty);
            this.Controls.Add(this.Lbl_txtStampDuty);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.Lbl_txtPurchasePrice);
            this.Controls.Add(this.CmdPurchCal);
            this.Controls.Add(this.CmbPurchYear);
            this.Controls.Add(this.CmbPurchMM);
            this.Controls.Add(this.CmbPurchDD);
            this.Controls.Add(this.Lbl_Purchase);
            this.Controls.Add(this.LblPropertyName);
            this.Controls.Add(this.CmbPropertyId);
            this.Controls.Add(this.Lbl_CmbPropertyId);
            this.Controls.Add(this.gvPurchase);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Property_Purchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Purchase";
            this.Load += new System.EventHandler(this.Property_Purchase_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchase)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnSuperProcess;
        public System.Windows.Forms.Label Label21;
        private System.Windows.Forms.DataGridView gvPurchase;
        public System.Windows.Forms.Label Lbl_CmbPropertyId;
        public System.Windows.Forms.ComboBox CmbPropertyId;
        public System.Windows.Forms.Label LblPropertyName;
        public System.Windows.Forms.Label Lbl_Purchase;
        public System.Windows.Forms.ComboBox CmbPurchDD;
        public System.Windows.Forms.ComboBox CmbPurchMM;
        public System.Windows.Forms.ComboBox CmbPurchYear;
        public System.Windows.Forms.Button CmdPurchCal;
        public System.Windows.Forms.Label Lbl_txtPurchasePrice;
        public System.Windows.Forms.TextBox txtPurchasePrice;
        public System.Windows.Forms.Label Lbl_txtStampDuty;
        public System.Windows.Forms.TextBox txtStampDuty;
        public System.Windows.Forms.Label Lbl_txtConveyancing;
        public System.Windows.Forms.TextBox txtConveyancing;
        public System.Windows.Forms.Label Lbl_txtInspection;
        public System.Windows.Forms.TextBox txtInspection;
        public System.Windows.Forms.Label Lbl_txtBuyersAgent;
        public System.Windows.Forms.TextBox txtBuyersAgent;
        public System.Windows.Forms.Label Lbl_txtSettlement;
        public System.Windows.Forms.TextBox txtSettlement;
        public System.Windows.Forms.Label Lbl_txtOtherCost;
        public System.Windows.Forms.TextBox txtOtherCost;
        public System.Windows.Forms.Label Lbl_txtDownPayment;
        public System.Windows.Forms.TextBox txtDownPayment;
        public System.Windows.Forms.Label Lbl_txtInitialLoan;
        public System.Windows.Forms.TextBox txtInitialLoan;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
