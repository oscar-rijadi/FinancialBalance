namespace FinancialBalance
{
    partial class Property_Rental_Bank_Expense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Property_Rental_Bank_Expense));
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
            this.MnETFStocksTaxInterest = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFYRecon = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyRentalIncome = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.gvExpense = new System.Windows.Forms.DataGridView();
            this.Lbl_CmbPropertyId = new System.Windows.Forms.Label();
            this.CmbPropertyId = new System.Windows.Forms.ComboBox();
            this.LblPropertyName = new System.Windows.Forms.Label();
            this.Lbl_Month = new System.Windows.Forms.Label();
            this.CmbMonth = new System.Windows.Forms.ComboBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.Lbl_txtDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.Lbl_CmbCurrency = new System.Windows.Forms.Label();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.Lbl_txtInterest = new System.Windows.Forms.Label();
            this.txtInterest = new System.Windows.Forms.TextBox();
            this.Lbl_txtBankFee = new System.Windows.Forms.Label();
            this.txtBankFee = new System.Windows.Forms.TextBox();
            this.Lbl_txtTotalExpense = new System.Windows.Forms.Label();
            this.txtTotalExpense = new System.Windows.Forms.TextBox();
            this.Lbl_LblGrandTotal = new System.Windows.Forms.Label();
            this.LblGrandTotal = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExpense)).BeginInit();
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
            this.MainMenu1.Size = new System.Drawing.Size(852, 24);
            this.MainMenu1.TabIndex = 83;
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
            this.MnMonthlyClosing.Size = new System.Drawing.Size(107, 20);
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
            this.MnETFStocksTaxInterest,
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
            this.MnPropertySale,
            this.MnPropertyRentalIncome});
            this.MnPropertyProcessGroup.Name = "MnPropertyProcessGroup";
            this.MnPropertyProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnPropertyProcessGroup.Text = "P&roperty";
            // 
            // MnPropertySetup
            // 
            this.MnPropertySetup.Name = "MnPropertySetup";
            this.MnPropertySetup.Size = new System.Drawing.Size(137, 20);
            this.MnPropertySetup.Text = "P&roperty Setup";
            this.MnPropertySetup.Click += new System.EventHandler(this.MnPropertySetup_Click);
            // 
            // MnPropertySale
            // 
            this.MnPropertySale.Name = "MnPropertySale";
            this.MnPropertySale.Size = new System.Drawing.Size(137, 20);
            this.MnPropertySale.Text = "Property Sa&le";
            this.MnPropertySale.Click += new System.EventHandler(this.MnPropertySale_Click);
            // 
            // MnPropertyRentalIncome
            // 
            this.MnPropertyRentalIncome.Name = "MnPropertyRentalIncome";
            this.MnPropertyRentalIncome.Size = new System.Drawing.Size(216, 22);
            this.MnPropertyRentalIncome.Text = "Property Rental &Income";
            this.MnPropertyRentalIncome.Click += new System.EventHandler(this.MnPropertyRentalIncome_Click);
            // 
            // MnPropertyPurchase
            // 
            this.MnPropertyPurchase.Name = "MnPropertyPurchase";
            this.MnPropertyPurchase.Size = new System.Drawing.Size(137, 20);
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
            // MnETFStocksPurchase
            //
            this.MnETFStocksPurchase.Name = "MnETFStocksPurchase";
            this.MnETFStocksPurchase.Size = new System.Drawing.Size(137, 20);
            this.MnETFStocksPurchase.Text = "ETF/Stock &Purchase";
            this.MnETFStocksPurchase.Click += new System.EventHandler(this.MnETFStocksPurchase_Click);

            //
            // MnETFStocksSale
            //
            this.MnETFStocksSale.Name = "MnETFStocksSale";
            this.MnETFStocksSale.Size = new System.Drawing.Size(137, 20);
            this.MnETFStocksSale.Text = "ETF/Stock &Sale";
            this.MnETFStocksSale.Click += new System.EventHandler(this.MnETFStocksSale_Click);
            //
            // MnETFStocksDistribution
            //
            this.MnETFStocksDistribution.Name = "MnETFStocksDistribution";
            this.MnETFStocksDistribution.Size = new System.Drawing.Size(137, 20);
            this.MnETFStocksDistribution.Text = "ETF/Stock &Distribution/Dividend";
            this.MnETFStocksDistribution.Click += new System.EventHandler(this.MnETFStocksDistribution_Click);
            //
            // MnETFStocksInvestment
            //
            this.MnETFStocksInvestment.Name = "MnETFStocksInvestment";
            this.MnETFStocksInvestment.Size = new System.Drawing.Size(137, 20);
            this.MnETFStocksInvestment.Text = "ETF/Stock &Investment";
            this.MnETFStocksInvestment.Click += new System.EventHandler(this.MnETFStocksInvestment_Click);
            //
            // MnETFStocksCostBase
            //
            this.MnETFStocksCostBase.Name = "MnETFStocksCostBase";
            this.MnETFStocksCostBase.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksCostBase.Text = "ETF/Stock &Cost Base Adjustment";
            this.MnETFStocksCostBase.Click += new System.EventHandler(this.MnETFStocksCostBase_Click);
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
            // MnETFStocksTaxInterest
            // 
            this.MnETFStocksTaxInterest.Name = "MnETFStocksTaxInterest";
            this.MnETFStocksTaxInterest.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksTaxInterest.Text = "ETF/Stock Tax Deductable &Interest";
            this.MnETFStocksTaxInterest.Click += new System.EventHandler(this.MnETFStocksTaxInterest_Click);
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(19, 28);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(1062, 38);
            this.Label21.TabIndex = 2;
            this.Label21.Text = "PROPERTY RENTAL BANK EXPENSE";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label21.UseMnemonic = false;
            // 
            // gvExpense
            // 
            this.gvExpense.AllowUserToAddRows = false;
            this.gvExpense.AllowUserToDeleteRows = false;
            this.gvExpense.AllowUserToResizeRows = false;
            this.gvExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExpense.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvExpense.Location = new System.Drawing.Point(19, 76);
            this.gvExpense.MultiSelect = false;
            this.gvExpense.Name = "gvExpense";
            this.gvExpense.ReadOnly = true;
            this.gvExpense.RowHeadersVisible = false;
            this.gvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExpense.Size = new System.Drawing.Size(1062, 290);
            this.gvExpense.TabIndex = 3;
            this.gvExpense.SelectionChanged += new System.EventHandler(this.gvExpense_SelectionChanged);
            // 
            // Lbl_CmbPropertyId
            // 
            this.Lbl_CmbPropertyId.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbPropertyId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbPropertyId.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbPropertyId.Location = new System.Drawing.Point(19, 384);
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
            this.CmbPropertyId.Location = new System.Drawing.Point(165, 382);
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
            this.LblPropertyName.Location = new System.Drawing.Point(255, 384);
            this.LblPropertyName.Name = "LblPropertyName";
            this.LblPropertyName.Size = new System.Drawing.Size(240, 22);
            this.LblPropertyName.TabIndex = 6;
            this.LblPropertyName.UseMnemonic = false;
            // 
            // Lbl_Month
            // 
            this.Lbl_Month.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Month.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Month.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Month.Location = new System.Drawing.Point(19, 414);
            this.Lbl_Month.Name = "Lbl_Month";
            this.Lbl_Month.Size = new System.Drawing.Size(140, 22);
            this.Lbl_Month.TabIndex = 7;
            this.Lbl_Month.Text = "Month";
            this.Lbl_Month.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbMonth
            // 
            this.CmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMonth.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMonth.FormattingEnabled = true;
            this.CmbMonth.Location = new System.Drawing.Point(165, 412);
            this.CmbMonth.Name = "CmbMonth";
            this.CmbMonth.Size = new System.Drawing.Size(41, 22);
            this.CmbMonth.TabIndex = 8;
            // 
            // CmbYear
            // 
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.FormattingEnabled = true;
            this.CmbYear.Location = new System.Drawing.Point(215, 412);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 9;
            // 
            // Lbl_txtDescription
            // 
            this.Lbl_txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtDescription.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtDescription.Location = new System.Drawing.Point(19, 444);
            this.Lbl_txtDescription.Name = "Lbl_txtDescription";
            this.Lbl_txtDescription.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtDescription.TabIndex = 10;
            this.Lbl_txtDescription.Text = "Description";
            this.Lbl_txtDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(165, 442);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(330, 20);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Lbl_CmbCurrency
            // 
            this.Lbl_CmbCurrency.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbCurrency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbCurrency.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbCurrency.Location = new System.Drawing.Point(19, 474);
            this.Lbl_CmbCurrency.Name = "Lbl_CmbCurrency";
            this.Lbl_CmbCurrency.Size = new System.Drawing.Size(140, 22);
            this.Lbl_CmbCurrency.TabIndex = 12;
            this.Lbl_CmbCurrency.Text = "Currency";
            this.Lbl_CmbCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbCurrency
            // 
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(165, 472);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(80, 22);
            this.CmbCurrency.TabIndex = 13;
            // 
            // Lbl_txtInterest
            // 
            this.Lbl_txtInterest.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtInterest.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtInterest.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtInterest.Location = new System.Drawing.Point(560, 384);
            this.Lbl_txtInterest.Name = "Lbl_txtInterest";
            this.Lbl_txtInterest.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtInterest.TabIndex = 14;
            this.Lbl_txtInterest.Text = "Interest";
            this.Lbl_txtInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInterest
            // 
            this.txtInterest.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterest.Location = new System.Drawing.Point(706, 382);
            this.txtInterest.MaxLength = 18;
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(120, 20);
            this.txtInterest.TabIndex = 15;
            this.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtInterest.TextChanged += new System.EventHandler(this.Amount_Changed);
            // 
            // Lbl_txtBankFee
            // 
            this.Lbl_txtBankFee.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtBankFee.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtBankFee.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtBankFee.Location = new System.Drawing.Point(560, 414);
            this.Lbl_txtBankFee.Name = "Lbl_txtBankFee";
            this.Lbl_txtBankFee.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtBankFee.TabIndex = 16;
            this.Lbl_txtBankFee.Text = "Bank Fee";
            this.Lbl_txtBankFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBankFee
            // 
            this.txtBankFee.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankFee.Location = new System.Drawing.Point(706, 412);
            this.txtBankFee.MaxLength = 18;
            this.txtBankFee.Name = "txtBankFee";
            this.txtBankFee.Size = new System.Drawing.Size(120, 20);
            this.txtBankFee.TabIndex = 17;
            this.txtBankFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBankFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtBankFee.TextChanged += new System.EventHandler(this.Amount_Changed);
            // 
            // Lbl_txtTotalExpense
            // 
            this.Lbl_txtTotalExpense.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtTotalExpense.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtTotalExpense.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtTotalExpense.Location = new System.Drawing.Point(560, 444);
            this.Lbl_txtTotalExpense.Name = "Lbl_txtTotalExpense";
            this.Lbl_txtTotalExpense.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtTotalExpense.TabIndex = 18;
            this.Lbl_txtTotalExpense.Text = "Total Expense";
            this.Lbl_txtTotalExpense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalExpense
            // 
            this.txtTotalExpense.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalExpense.Location = new System.Drawing.Point(706, 442);
            this.txtTotalExpense.MaxLength = 18;
            this.txtTotalExpense.Name = "txtTotalExpense";
            this.txtTotalExpense.Size = new System.Drawing.Size(120, 20);
            this.txtTotalExpense.TabIndex = 19;
            this.txtTotalExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalExpense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Signed_KeyPress);
            this.txtTotalExpense.TextChanged += new System.EventHandler(this.TotalExpense_Changed);
            // 
            // Lbl_LblGrandTotal
            // 
            this.Lbl_LblGrandTotal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblGrandTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblGrandTotal.Location = new System.Drawing.Point(19, 506);
            this.Lbl_LblGrandTotal.Name = "Lbl_LblGrandTotal";
            this.Lbl_LblGrandTotal.Size = new System.Drawing.Size(140, 22);
            this.Lbl_LblGrandTotal.TabIndex = 20;
            this.Lbl_LblGrandTotal.Text = "Grand Total Expense";
            this.Lbl_LblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblGrandTotal
            // 
            this.LblGrandTotal.BackColor = System.Drawing.Color.Transparent;
            this.LblGrandTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.LblGrandTotal.Location = new System.Drawing.Point(165, 506);
            this.LblGrandTotal.Name = "LblGrandTotal";
            this.LblGrandTotal.Size = new System.Drawing.Size(120, 22);
            this.LblGrandTotal.TabIndex = 21;
            this.LblGrandTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblGrandTotal.UseMnemonic = false;
            // 
            // LblNote
            // 
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(320, 506);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(761, 22);
            this.LblNote.TabIndex = 22;
            this.LblNote.UseMnemonic = false;
            // 
            // CmdCreate
            // 
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.Location = new System.Drawing.Point(615, 542);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(85, 28);
            this.CmdCreate.TabIndex = 23;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            // 
            // CmdUpdate
            // 
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.Location = new System.Drawing.Point(710, 542);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(85, 28);
            this.CmdUpdate.TabIndex = 24;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            // 
            // CmdClear
            // 
            this.CmdClear.BackColor = System.Drawing.SystemColors.Control;
            this.CmdClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClear.Location = new System.Drawing.Point(805, 542);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.Size = new System.Drawing.Size(85, 28);
            this.CmdClear.TabIndex = 25;
            this.CmdClear.Text = "&Clear";
            this.CmdClear.UseVisualStyleBackColor = false;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            // 
            // CmdDel
            // 
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.Location = new System.Drawing.Point(900, 542);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 28);
            this.CmdDel.TabIndex = 26;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            // 
            // CmdBack
            // 
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(995, 542);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 28);
            this.CmdBack.TabIndex = 27;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // Property_Rental_Bank_Expense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.LblGrandTotal);
            this.Controls.Add(this.Lbl_LblGrandTotal);
            this.Controls.Add(this.txtTotalExpense);
            this.Controls.Add(this.Lbl_txtTotalExpense);
            this.Controls.Add(this.txtBankFee);
            this.Controls.Add(this.Lbl_txtBankFee);
            this.Controls.Add(this.txtInterest);
            this.Controls.Add(this.Lbl_txtInterest);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.Lbl_CmbCurrency);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.Lbl_txtDescription);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.CmbMonth);
            this.Controls.Add(this.Lbl_Month);
            this.Controls.Add(this.LblPropertyName);
            this.Controls.Add(this.CmbPropertyId);
            this.Controls.Add(this.Lbl_CmbPropertyId);
            this.Controls.Add(this.gvExpense);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Property_Rental_Bank_Expense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Rental Bank Expense";
            this.Load += new System.EventHandler(this.Property_Rental_Bank_Expense_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExpense)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksTaxInterest;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFYRecon;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertySetup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnPropertySale;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyRentalIncome;
        public System.Windows.Forms.ToolStripMenuItem MnSuperProcess;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.DataGridView gvExpense;
        public System.Windows.Forms.Label Lbl_CmbPropertyId;
        public System.Windows.Forms.ComboBox CmbPropertyId;
        public System.Windows.Forms.Label LblPropertyName;
        public System.Windows.Forms.Label Lbl_Month;
        public System.Windows.Forms.ComboBox CmbMonth;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Label Lbl_txtDescription;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label Lbl_CmbCurrency;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.Label Lbl_txtInterest;
        public System.Windows.Forms.TextBox txtInterest;
        public System.Windows.Forms.Label Lbl_txtBankFee;
        public System.Windows.Forms.TextBox txtBankFee;
        public System.Windows.Forms.Label Lbl_txtTotalExpense;
        public System.Windows.Forms.TextBox txtTotalExpense;
        public System.Windows.Forms.Label Lbl_LblGrandTotal;
        public System.Windows.Forms.Label LblGrandTotal;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
