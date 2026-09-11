namespace FinancialBalance
{
    partial class Setup_Property
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Property));
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
            this.MnPropertyPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.gvProperty = new System.Windows.Forms.DataGridView();
            this.Lbl_PropertyId = new System.Windows.Forms.Label();
            this.LblPropertyId = new System.Windows.Forms.Label();
            this.Lbl_txtName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Lbl_txtAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Lbl_txtSuburb = new System.Windows.Forms.Label();
            this.txtSuburb = new System.Windows.Forms.TextBox();
            this.Lbl_CmbState = new System.Windows.Forms.Label();
            this.CmbState = new System.Windows.Forms.ComboBox();
            this.Lbl_txtPostCode = new System.Windows.Forms.Label();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.Lbl_Purchase = new System.Windows.Forms.Label();
            this.CmbPurchDD = new System.Windows.Forms.ComboBox();
            this.CmbPurchMM = new System.Windows.Forms.ComboBox();
            this.CmbPurchYear = new System.Windows.Forms.ComboBox();
            this.CmdPurchCal = new System.Windows.Forms.Button();
            this.chkIsSold = new System.Windows.Forms.CheckBox();
            this.Lbl_Sold = new System.Windows.Forms.Label();
            this.CmbSoldDD = new System.Windows.Forms.ComboBox();
            this.CmbSoldMM = new System.Windows.Forms.ComboBox();
            this.CmbSoldYear = new System.Windows.Forms.ComboBox();
            this.CmdSoldCal = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.LblNote = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProperty)).BeginInit();
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
            this.MainMenu1.Size = new System.Drawing.Size(1000, 24);
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
            this.MnPropertyPurchase});
            this.MnPropertyProcessGroup.Name = "MnPropertyProcessGroup";
            this.MnPropertyProcessGroup.Size = new System.Drawing.Size(150, 20);
            this.MnPropertyProcessGroup.Text = "P&roperty";
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
            this.Label21.Size = new System.Drawing.Size(960, 40);
            this.Label21.TabIndex = 2;
            this.Label21.Text = "PROPERTY SETUP";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvProperty
            // 
            this.gvProperty.AllowUserToAddRows = false;
            this.gvProperty.AllowUserToDeleteRows = false;
            this.gvProperty.AllowUserToResizeRows = false;
            this.gvProperty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProperty.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvProperty.Location = new System.Drawing.Point(19, 76);
            this.gvProperty.MultiSelect = false;
            this.gvProperty.Name = "gvProperty";
            this.gvProperty.ReadOnly = true;
            this.gvProperty.RowHeadersVisible = false;
            this.gvProperty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProperty.Size = new System.Drawing.Size(962, 240);
            this.gvProperty.TabIndex = 3;
            this.gvProperty.SelectionChanged += new System.EventHandler(this.gvProperty_SelectionChanged);
            // 
            // Lbl_PropertyId
            // 
            this.Lbl_PropertyId.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_PropertyId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PropertyId.ForeColor = System.Drawing.Color.Black;
            this.Lbl_PropertyId.Location = new System.Drawing.Point(19, 334);
            this.Lbl_PropertyId.Name = "Lbl_PropertyId";
            this.Lbl_PropertyId.Size = new System.Drawing.Size(130, 22);
            this.Lbl_PropertyId.TabIndex = 4;
            this.Lbl_PropertyId.Text = "Property Id";
            this.Lbl_PropertyId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPropertyId
            // 
            this.LblPropertyId.BackColor = System.Drawing.Color.Transparent;
            this.LblPropertyId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPropertyId.ForeColor = System.Drawing.Color.Black;
            this.LblPropertyId.Location = new System.Drawing.Point(158, 334);
            this.LblPropertyId.Name = "LblPropertyId";
            this.LblPropertyId.Size = new System.Drawing.Size(120, 22);
            this.LblPropertyId.TabIndex = 5;
            // 
            // Lbl_txtName
            // 
            this.Lbl_txtName.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtName.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtName.Location = new System.Drawing.Point(19, 364);
            this.Lbl_txtName.Name = "Lbl_txtName";
            this.Lbl_txtName.Size = new System.Drawing.Size(130, 22);
            this.Lbl_txtName.TabIndex = 6;
            this.Lbl_txtName.Text = "Name";
            this.Lbl_txtName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(158, 362);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(300, 20);
            this.txtName.TabIndex = 7;
            // 
            // Lbl_txtAddress
            // 
            this.Lbl_txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtAddress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtAddress.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtAddress.Location = new System.Drawing.Point(19, 394);
            this.Lbl_txtAddress.Name = "Lbl_txtAddress";
            this.Lbl_txtAddress.Size = new System.Drawing.Size(130, 22);
            this.Lbl_txtAddress.TabIndex = 8;
            this.Lbl_txtAddress.Text = "Address";
            this.Lbl_txtAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddress.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddress.Location = new System.Drawing.Point(158, 392);
            this.txtAddress.MaxLength = 150;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAddress.Size = new System.Drawing.Size(300, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // Lbl_txtSuburb
            // 
            this.Lbl_txtSuburb.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtSuburb.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtSuburb.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtSuburb.Location = new System.Drawing.Point(19, 424);
            this.Lbl_txtSuburb.Name = "Lbl_txtSuburb";
            this.Lbl_txtSuburb.Size = new System.Drawing.Size(130, 22);
            this.Lbl_txtSuburb.TabIndex = 10;
            this.Lbl_txtSuburb.Text = "Suburb";
            this.Lbl_txtSuburb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSuburb
            // 
            this.txtSuburb.BackColor = System.Drawing.SystemColors.Window;
            this.txtSuburb.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuburb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSuburb.Location = new System.Drawing.Point(158, 422);
            this.txtSuburb.MaxLength = 50;
            this.txtSuburb.Name = "txtSuburb";
            this.txtSuburb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSuburb.Size = new System.Drawing.Size(300, 20);
            this.txtSuburb.TabIndex = 11;
            // 
            // Lbl_CmbState
            // 
            this.Lbl_CmbState.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbState.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbState.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbState.Location = new System.Drawing.Point(19, 454);
            this.Lbl_CmbState.Name = "Lbl_CmbState";
            this.Lbl_CmbState.Size = new System.Drawing.Size(130, 22);
            this.Lbl_CmbState.TabIndex = 12;
            this.Lbl_CmbState.Text = "State";
            this.Lbl_CmbState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbState
            // 
            this.CmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbState.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbState.FormattingEnabled = true;
            this.CmbState.Location = new System.Drawing.Point(158, 452);
            this.CmbState.Name = "CmbState";
            this.CmbState.Size = new System.Drawing.Size(80, 22);
            this.CmbState.TabIndex = 13;
            // 
            // Lbl_txtPostCode
            // 
            this.Lbl_txtPostCode.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtPostCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtPostCode.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtPostCode.Location = new System.Drawing.Point(520, 334);
            this.Lbl_txtPostCode.Name = "Lbl_txtPostCode";
            this.Lbl_txtPostCode.Size = new System.Drawing.Size(130, 22);
            this.Lbl_txtPostCode.TabIndex = 14;
            this.Lbl_txtPostCode.Text = "Post Code";
            this.Lbl_txtPostCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPostCode
            // 
            this.txtPostCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtPostCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPostCode.Location = new System.Drawing.Point(659, 332);
            this.txtPostCode.MaxLength = 4;
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPostCode.Size = new System.Drawing.Size(60, 20);
            this.txtPostCode.TabIndex = 15;
            // 
            // Lbl_Purchase
            // 
            this.Lbl_Purchase.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Purchase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Purchase.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Purchase.Location = new System.Drawing.Point(520, 364);
            this.Lbl_Purchase.Name = "Lbl_Purchase";
            this.Lbl_Purchase.Size = new System.Drawing.Size(130, 22);
            this.Lbl_Purchase.TabIndex = 16;
            this.Lbl_Purchase.Text = "Purchase Date";
            this.Lbl_Purchase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbPurchDD
            // 
            this.CmbPurchDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPurchDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPurchDD.FormattingEnabled = true;
            this.CmbPurchDD.Location = new System.Drawing.Point(659, 362);
            this.CmbPurchDD.Name = "CmbPurchDD";
            this.CmbPurchDD.Size = new System.Drawing.Size(41, 22);
            this.CmbPurchDD.TabIndex = 17;
            // 
            // CmbPurchMM
            // 
            this.CmbPurchMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPurchMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPurchMM.FormattingEnabled = true;
            this.CmbPurchMM.Location = new System.Drawing.Point(709, 362);
            this.CmbPurchMM.Name = "CmbPurchMM";
            this.CmbPurchMM.Size = new System.Drawing.Size(41, 22);
            this.CmbPurchMM.TabIndex = 18;
            // 
            // CmbPurchYear
            // 
            this.CmbPurchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPurchYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPurchYear.FormattingEnabled = true;
            this.CmbPurchYear.Location = new System.Drawing.Point(759, 362);
            this.CmbPurchYear.Name = "CmbPurchYear";
            this.CmbPurchYear.Size = new System.Drawing.Size(57, 22);
            this.CmbPurchYear.TabIndex = 19;
            // 
            // CmdPurchCal
            // 
            this.CmdPurchCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdPurchCal.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdPurchCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdPurchCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdPurchCal.Location = new System.Drawing.Point(824, 363);
            this.CmdPurchCal.Name = "CmdPurchCal";
            this.CmdPurchCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdPurchCal.Size = new System.Drawing.Size(25, 19);
            this.CmdPurchCal.TabIndex = 20;
            this.CmdPurchCal.Text = "..";
            this.CmdPurchCal.UseVisualStyleBackColor = false;
            this.CmdPurchCal.Click += new System.EventHandler(this.CmdPurchCal_Click);
            // 
            // chkIsSold
            // 
            this.chkIsSold.BackColor = System.Drawing.Color.Transparent;
            this.chkIsSold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsSold.Location = new System.Drawing.Point(659, 392);
            this.chkIsSold.Name = "chkIsSold";
            this.chkIsSold.Size = new System.Drawing.Size(100, 24);
            this.chkIsSold.TabIndex = 21;
            this.chkIsSold.Text = "Is Sold";
            this.chkIsSold.UseVisualStyleBackColor = false;
            this.chkIsSold.CheckedChanged += new System.EventHandler(this.chkIsSold_CheckedChanged);
            // 
            // Lbl_Sold
            // 
            this.Lbl_Sold.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Sold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Sold.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Sold.Location = new System.Drawing.Point(520, 424);
            this.Lbl_Sold.Name = "Lbl_Sold";
            this.Lbl_Sold.Size = new System.Drawing.Size(130, 22);
            this.Lbl_Sold.TabIndex = 22;
            this.Lbl_Sold.Text = "Sold Date";
            this.Lbl_Sold.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbSoldDD
            // 
            this.CmbSoldDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldDD.FormattingEnabled = true;
            this.CmbSoldDD.Location = new System.Drawing.Point(659, 422);
            this.CmbSoldDD.Name = "CmbSoldDD";
            this.CmbSoldDD.Size = new System.Drawing.Size(41, 22);
            this.CmbSoldDD.TabIndex = 23;
            // 
            // CmbSoldMM
            // 
            this.CmbSoldMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldMM.FormattingEnabled = true;
            this.CmbSoldMM.Location = new System.Drawing.Point(709, 422);
            this.CmbSoldMM.Name = "CmbSoldMM";
            this.CmbSoldMM.Size = new System.Drawing.Size(41, 22);
            this.CmbSoldMM.TabIndex = 24;
            // 
            // CmbSoldYear
            // 
            this.CmbSoldYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldYear.FormattingEnabled = true;
            this.CmbSoldYear.Location = new System.Drawing.Point(759, 422);
            this.CmbSoldYear.Name = "CmbSoldYear";
            this.CmbSoldYear.Size = new System.Drawing.Size(57, 22);
            this.CmbSoldYear.TabIndex = 25;
            // 
            // CmdSoldCal
            // 
            this.CmdSoldCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSoldCal.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdSoldCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSoldCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSoldCal.Location = new System.Drawing.Point(824, 423);
            this.CmdSoldCal.Name = "CmdSoldCal";
            this.CmdSoldCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdSoldCal.Size = new System.Drawing.Size(25, 19);
            this.CmdSoldCal.TabIndex = 26;
            this.CmdSoldCal.Text = "..";
            this.CmdSoldCal.UseVisualStyleBackColor = false;
            this.CmdSoldCal.Click += new System.EventHandler(this.CmdSoldCal_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(620, 150);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 27;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // LblNote
            // 
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 484);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(962, 22);
            this.LblNote.TabIndex = 28;
            // 
            // CmdCreate
            // 
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(525, 516);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdCreate.Size = new System.Drawing.Size(85, 28);
            this.CmdCreate.TabIndex = 29;
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
            this.CmdUpdate.Location = new System.Drawing.Point(620, 516);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdUpdate.Size = new System.Drawing.Size(85, 28);
            this.CmdUpdate.TabIndex = 30;
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
            this.CmdClear.Location = new System.Drawing.Point(715, 516);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdClear.Size = new System.Drawing.Size(85, 28);
            this.CmdClear.TabIndex = 31;
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
            this.CmdDel.Location = new System.Drawing.Point(810, 516);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(85, 28);
            this.CmdDel.TabIndex = 32;
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
            this.CmdBack.Location = new System.Drawing.Point(896, 516);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(85, 28);
            this.CmdBack.TabIndex = 33;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Setup_Property
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1000, 572);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.CmdSoldCal);
            this.Controls.Add(this.CmbSoldYear);
            this.Controls.Add(this.CmbSoldMM);
            this.Controls.Add(this.CmbSoldDD);
            this.Controls.Add(this.Lbl_Sold);
            this.Controls.Add(this.chkIsSold);
            this.Controls.Add(this.CmdPurchCal);
            this.Controls.Add(this.CmbPurchYear);
            this.Controls.Add(this.CmbPurchMM);
            this.Controls.Add(this.CmbPurchDD);
            this.Controls.Add(this.Lbl_Purchase);
            this.Controls.Add(this.txtPostCode);
            this.Controls.Add(this.Lbl_txtPostCode);
            this.Controls.Add(this.CmbState);
            this.Controls.Add(this.Lbl_CmbState);
            this.Controls.Add(this.txtSuburb);
            this.Controls.Add(this.Lbl_txtSuburb);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.Lbl_txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Lbl_txtName);
            this.Controls.Add(this.LblPropertyId);
            this.Controls.Add(this.Lbl_PropertyId);
            this.Controls.Add(this.gvProperty);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_Property";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Setup";
            this.Load += new System.EventHandler(this.Setup_Property_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProperty)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnPropertyPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnSuperProcess;
        public System.Windows.Forms.Label Label21;
        private System.Windows.Forms.DataGridView gvProperty;
        public System.Windows.Forms.Label Lbl_PropertyId;
        public System.Windows.Forms.Label LblPropertyId;
        public System.Windows.Forms.Label Lbl_txtName;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Label Lbl_txtAddress;
        public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.Label Lbl_txtSuburb;
        public System.Windows.Forms.TextBox txtSuburb;
        public System.Windows.Forms.Label Lbl_CmbState;
        public System.Windows.Forms.ComboBox CmbState;
        public System.Windows.Forms.Label Lbl_txtPostCode;
        public System.Windows.Forms.TextBox txtPostCode;
        public System.Windows.Forms.Label Lbl_Purchase;
        public System.Windows.Forms.ComboBox CmbPurchDD;
        public System.Windows.Forms.ComboBox CmbPurchMM;
        public System.Windows.Forms.ComboBox CmbPurchYear;
        public System.Windows.Forms.Button CmdPurchCal;
        public System.Windows.Forms.CheckBox chkIsSold;
        public System.Windows.Forms.Label Lbl_Sold;
        public System.Windows.Forms.ComboBox CmbSoldDD;
        public System.Windows.Forms.ComboBox CmbSoldMM;
        public System.Windows.Forms.ComboBox CmbSoldYear;
        public System.Windows.Forms.Button CmdSoldCal;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
