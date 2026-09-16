namespace FinancialBalance
{
    partial class Property_Rental_Income
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Property_Rental_Income));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDailyInput = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksTaxInterest = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksCostBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFYRecon = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyRentalBankExpense = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertySale = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.gvRental = new System.Windows.Forms.DataGridView();
            this.Lbl_CmbPropertyId = new System.Windows.Forms.Label();
            this.CmbPropertyId = new System.Windows.Forms.ComboBox();
            this.LblPropertyName = new System.Windows.Forms.Label();
            this.Lbl_Month = new System.Windows.Forms.Label();
            this.CmbMonth = new System.Windows.Forms.ComboBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.Lbl_CmbCurrency = new System.Windows.Forms.Label();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.Lbl_txtIncome = new System.Windows.Forms.Label();
            this.txtIncome = new System.Windows.Forms.TextBox();
            this.Lbl_txtExpense = new System.Windows.Forms.Label();
            this.txtExpense = new System.Windows.Forms.TextBox();
            this.Lbl_txtProfitLoss = new System.Windows.Forms.Label();
            this.txtProfitLoss = new System.Windows.Forms.TextBox();
            this.Lbl_LblTotalProfitLoss = new System.Windows.Forms.Label();
            this.LblTotalProfitLoss = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRental)).BeginInit();
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
            this.MnETFStocksTaxInterest,
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
            // MnETFStocksTaxInterest
            // 
            this.MnETFStocksTaxInterest.Name = "MnETFStocksTaxInterest";
            this.MnETFStocksTaxInterest.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksTaxInterest.Text = "ETF/Stock Tax Deductable &Interest";
            this.MnETFStocksTaxInterest.Click += new System.EventHandler(this.MnETFStocksTaxInterest_Click);
            // 
            // MnPropertyProcessGroup
            // 
            this.MnPropertyProcessGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnPropertySetup,
            this.MnPropertyPurchase,
            this.MnPropertySale,
            this.MnPropertyRentalBankExpense});
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
            // MnPropertySale
            // 
            this.MnPropertySale.Name = "MnPropertySale";
            this.MnPropertySale.Size = new System.Drawing.Size(216, 22);
            this.MnPropertySale.Text = "Property Sa&le";
            this.MnPropertySale.Click += new System.EventHandler(this.MnPropertySale_Click);
            // 
            // MnPropertyRentalBankExpense
            // 
            this.MnPropertyRentalBankExpense.Name = "MnPropertyRentalBankExpense";
            this.MnPropertyRentalBankExpense.Size = new System.Drawing.Size(216, 22);
            this.MnPropertyRentalBankExpense.Text = "Property Rental &Bank Expense";
            this.MnPropertyRentalBankExpense.Click += new System.EventHandler(this.MnPropertyRentalBankExpense_Click);
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
            this.Label21.Text = "PROPERTY RENTAL INCOME";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvRental
            // 
            this.gvRental.AllowUserToAddRows = false;
            this.gvRental.AllowUserToDeleteRows = false;
            this.gvRental.AllowUserToResizeRows = false;
            this.gvRental.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvRental.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRental.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRental.Location = new System.Drawing.Point(19, 76);
            this.gvRental.MultiSelect = false;
            this.gvRental.Name = "gvRental";
            this.gvRental.ReadOnly = true;
            this.gvRental.RowHeadersVisible = false;
            this.gvRental.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRental.Size = new System.Drawing.Size(1062, 230);
            this.gvRental.TabIndex = 3;
            this.gvRental.SelectionChanged += new System.EventHandler(this.gvRental_SelectionChanged);
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
            this.LblPropertyName.UseMnemonic = false;
            // 
            // Lbl_Month
            // 
            this.Lbl_Month.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Month.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Month.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Month.Location = new System.Drawing.Point(19, 354);
            this.Lbl_Month.Name = "Lbl_Month";
            this.Lbl_Month.Size = new System.Drawing.Size(140, 22);
            this.Lbl_Month.TabIndex = 7;
            this.Lbl_Month.Text = "Rental Month";
            this.Lbl_Month.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbMonth
            // 
            this.CmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMonth.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMonth.FormattingEnabled = true;
            this.CmbMonth.Location = new System.Drawing.Point(165, 352);
            this.CmbMonth.Name = "CmbMonth";
            this.CmbMonth.Size = new System.Drawing.Size(41, 22);
            this.CmbMonth.TabIndex = 8;
            // 
            // CmbYear
            // 
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.FormattingEnabled = true;
            this.CmbYear.Location = new System.Drawing.Point(215, 352);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 9;
            // 
            // Lbl_CmbCurrency
            // 
            this.Lbl_CmbCurrency.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbCurrency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbCurrency.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbCurrency.Location = new System.Drawing.Point(19, 384);
            this.Lbl_CmbCurrency.Name = "Lbl_CmbCurrency";
            this.Lbl_CmbCurrency.Size = new System.Drawing.Size(140, 22);
            this.Lbl_CmbCurrency.TabIndex = 10;
            this.Lbl_CmbCurrency.Text = "Currency";
            this.Lbl_CmbCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CmbCurrency
            // 
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(165, 382);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(80, 22);
            this.CmbCurrency.TabIndex = 11;
            // 
            // Lbl_txtIncome
            // 
            this.Lbl_txtIncome.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtIncome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtIncome.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtIncome.Location = new System.Drawing.Point(19, 414);
            this.Lbl_txtIncome.Name = "Lbl_txtIncome";
            this.Lbl_txtIncome.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtIncome.TabIndex = 12;
            this.Lbl_txtIncome.Text = "Income";
            this.Lbl_txtIncome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIncome
            // 
            this.txtIncome.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncome.Location = new System.Drawing.Point(165, 412);
            this.txtIncome.MaxLength = 18;
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Size = new System.Drawing.Size(120, 20);
            this.txtIncome.TabIndex = 13;
            this.txtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIncome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtIncome.TextChanged += new System.EventHandler(this.Amount_Changed);
            // 
            // Lbl_txtExpense
            // 
            this.Lbl_txtExpense.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtExpense.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtExpense.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtExpense.Location = new System.Drawing.Point(19, 444);
            this.Lbl_txtExpense.Name = "Lbl_txtExpense";
            this.Lbl_txtExpense.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtExpense.TabIndex = 14;
            this.Lbl_txtExpense.Text = "Expense";
            this.Lbl_txtExpense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExpense
            // 
            this.txtExpense.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpense.Location = new System.Drawing.Point(165, 442);
            this.txtExpense.MaxLength = 18;
            this.txtExpense.Name = "txtExpense";
            this.txtExpense.Size = new System.Drawing.Size(120, 20);
            this.txtExpense.TabIndex = 15;
            this.txtExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtExpense.TextChanged += new System.EventHandler(this.Amount_Changed);
            // 
            // Lbl_txtProfitLoss
            // 
            this.Lbl_txtProfitLoss.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtProfitLoss.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtProfitLoss.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtProfitLoss.Location = new System.Drawing.Point(19, 474);
            this.Lbl_txtProfitLoss.Name = "Lbl_txtProfitLoss";
            this.Lbl_txtProfitLoss.Size = new System.Drawing.Size(140, 22);
            this.Lbl_txtProfitLoss.TabIndex = 16;
            this.Lbl_txtProfitLoss.Text = "Profit/Loss";
            this.Lbl_txtProfitLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfitLoss
            // 
            this.txtProfitLoss.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfitLoss.Location = new System.Drawing.Point(165, 472);
            this.txtProfitLoss.MaxLength = 18;
            this.txtProfitLoss.Name = "txtProfitLoss";
            this.txtProfitLoss.Size = new System.Drawing.Size(120, 20);
            this.txtProfitLoss.TabIndex = 17;
            this.txtProfitLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProfitLoss.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Signed_KeyPress);
            this.txtProfitLoss.TextChanged += new System.EventHandler(this.ProfitLoss_Changed);
            // 
            // Lbl_LblTotalProfitLoss
            // 
            this.Lbl_LblTotalProfitLoss.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotalProfitLoss.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotalProfitLoss.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotalProfitLoss.Location = new System.Drawing.Point(19, 506);
            this.Lbl_LblTotalProfitLoss.Name = "Lbl_LblTotalProfitLoss";
            this.Lbl_LblTotalProfitLoss.Size = new System.Drawing.Size(140, 22);
            this.Lbl_LblTotalProfitLoss.TabIndex = 18;
            this.Lbl_LblTotalProfitLoss.Text = "Total Profit/Loss";
            this.Lbl_LblTotalProfitLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTotalProfitLoss
            // 
            this.LblTotalProfitLoss.BackColor = System.Drawing.Color.Transparent;
            this.LblTotalProfitLoss.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalProfitLoss.ForeColor = System.Drawing.Color.Black;
            this.LblTotalProfitLoss.Location = new System.Drawing.Point(165, 506);
            this.LblTotalProfitLoss.Name = "LblTotalProfitLoss";
            this.LblTotalProfitLoss.Size = new System.Drawing.Size(120, 22);
            this.LblTotalProfitLoss.TabIndex = 19;
            this.LblTotalProfitLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblTotalProfitLoss.UseMnemonic = false;
            // 
            // LblNote
            // 
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(320, 506);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(761, 22);
            this.LblNote.TabIndex = 20;
            this.LblNote.UseMnemonic = false;
            // 
            // CmdCreate
            // 
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.Location = new System.Drawing.Point(615, 542);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(85, 28);
            this.CmdCreate.TabIndex = 21;
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
            this.CmdUpdate.TabIndex = 22;
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
            this.CmdClear.TabIndex = 23;
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
            this.CmdDel.TabIndex = 24;
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
            this.CmdBack.TabIndex = 25;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // Property_Rental_Income
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
            this.Controls.Add(this.LblTotalProfitLoss);
            this.Controls.Add(this.Lbl_LblTotalProfitLoss);
            this.Controls.Add(this.txtProfitLoss);
            this.Controls.Add(this.Lbl_txtProfitLoss);
            this.Controls.Add(this.txtExpense);
            this.Controls.Add(this.Lbl_txtExpense);
            this.Controls.Add(this.txtIncome);
            this.Controls.Add(this.Lbl_txtIncome);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.Lbl_CmbCurrency);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.CmbMonth);
            this.Controls.Add(this.Lbl_Month);
            this.Controls.Add(this.LblPropertyName);
            this.Controls.Add(this.CmbPropertyId);
            this.Controls.Add(this.Lbl_CmbPropertyId);
            this.Controls.Add(this.gvRental);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Property_Rental_Income";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Rental Income";
            this.Load += new System.EventHandler(this.Property_Rental_Income_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRental)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnDailyInput;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksTaxInterest;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvestment;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSale;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDistribution;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksCostBase;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFYRecon;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertySetup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyRentalBankExpense;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyPurchase;
        public System.Windows.Forms.ToolStripMenuItem MnPropertySale;
        public System.Windows.Forms.ToolStripMenuItem MnSuperProcess;
        public System.Windows.Forms.Label Label21;
        private System.Windows.Forms.DataGridView gvRental;
        public System.Windows.Forms.Label Lbl_CmbPropertyId;
        public System.Windows.Forms.ComboBox CmbPropertyId;
        public System.Windows.Forms.Label LblPropertyName;
        public System.Windows.Forms.Label Lbl_Month;
        public System.Windows.Forms.ComboBox CmbMonth;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Label Lbl_CmbCurrency;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.Label Lbl_txtIncome;
        public System.Windows.Forms.TextBox txtIncome;
        public System.Windows.Forms.Label Lbl_txtExpense;
        public System.Windows.Forms.TextBox txtExpense;
        public System.Windows.Forms.Label Lbl_txtProfitLoss;
        public System.Windows.Forms.TextBox txtProfitLoss;
        public System.Windows.Forms.Label Lbl_LblTotalProfitLoss;
        public System.Windows.Forms.Label LblTotalProfitLoss;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
