namespace FinancialBalance
{
    partial class ETF_Stocks_Ticker_Historical_Data
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Ticker_Historical_Data));
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbTicker = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbFinYear = new System.Windows.Forms.ComboBox();
            this.LblCurrency = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.LblPurchase = new System.Windows.Forms.Label();
            this.gvPurchase = new System.Windows.Forms.DataGridView();
            this.LblPurUnitCap = new System.Windows.Forms.Label();
            this.LblPurUnit = new System.Windows.Forms.Label();
            this.LblPurCurrentUnitCap = new System.Windows.Forms.Label();
            this.LblPurCurrentUnit = new System.Windows.Forms.Label();
            this.LblPurSoldUnitCap = new System.Windows.Forms.Label();
            this.LblPurSoldUnit = new System.Windows.Forms.Label();
            this.LblPurAvgCostCap = new System.Windows.Forms.Label();
            this.LblPurAvgCost = new System.Windows.Forms.Label();
            this.LblPurAvgRealCap = new System.Windows.Forms.Label();
            this.LblPurAvgReal = new System.Windows.Forms.Label();
            this.LblPurTotalCostCap = new System.Windows.Forms.Label();
            this.LblPurTotalCost = new System.Windows.Forms.Label();
            this.LblPurTotalRealCap = new System.Windows.Forms.Label();
            this.LblPurTotalReal = new System.Windows.Forms.Label();
            this.LblSale = new System.Windows.Forms.Label();
            this.gvSale = new System.Windows.Forms.DataGridView();
            this.LblSaleUnitCap = new System.Windows.Forms.Label();
            this.LblSaleUnit = new System.Windows.Forms.Label();
            this.LblSaleAmountCap = new System.Windows.Forms.Label();
            this.LblSaleAmount = new System.Windows.Forms.Label();
            this.LblSalePaperCap = new System.Windows.Forms.Label();
            this.LblSalePaper = new System.Windows.Forms.Label();
            this.LblSaleRealCap = new System.Windows.Forms.Label();
            this.LblSaleReal = new System.Windows.Forms.Label();
            this.LblDistribution = new System.Windows.Forms.Label();
            this.gvDistribution = new System.Windows.Forms.DataGridView();
            this.LblDistTotalCap = new System.Windows.Forms.Label();
            this.LblDistTotal = new System.Windows.Forms.Label();
            this.CmdBack = new System.Windows.Forms.Button();
            this.LblPurPriceCap = new System.Windows.Forms.Label();
            this.LblPurPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistribution)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(19, 10);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(1226, 38);
            this.Label21.TabIndex = 8;
            this.Label21.Text = "ETF/STOCK TICKER HISTORICAL DATA";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 60);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 20);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Portfolio";
            //
            // CmbPortfolio
            //
            this.CmbPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPortfolio.FormattingEnabled = true;
            this.CmbPortfolio.Location = new System.Drawing.Point(85, 58);
            this.CmbPortfolio.Name = "CmbPortfolio";
            this.CmbPortfolio.Size = new System.Drawing.Size(220, 22);
            this.CmbPortfolio.TabIndex = 0;
            this.CmbPortfolio.SelectedIndexChanged += new System.EventHandler(this.CmbPortfolio_SelectedIndexChanged);
            //
            // chkMainOnly
            //
            this.chkMainOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkMainOnly.Checked = true;
            this.chkMainOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMainOnly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMainOnly.ForeColor = System.Drawing.Color.Black;
            this.chkMainOnly.Location = new System.Drawing.Point(318, 57);
            this.chkMainOnly.Name = "chkMainOnly";
            this.chkMainOnly.Size = new System.Drawing.Size(90, 24);
            this.chkMainOnly.TabIndex = 1;
            this.chkMainOnly.Text = "Main Only";
            this.chkMainOnly.UseVisualStyleBackColor = false;
            this.chkMainOnly.CheckedChanged += new System.EventHandler(this.chkMainOnly_CheckedChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(420, 60);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 20);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Full Ticker";
            //
            // CmbTicker
            //
            this.CmbTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTicker.FormattingEnabled = true;
            this.CmbTicker.Location = new System.Drawing.Point(498, 58);
            this.CmbTicker.Name = "CmbTicker";
            this.CmbTicker.Size = new System.Drawing.Size(140, 22);
            this.CmbTicker.TabIndex = 2;
            this.CmbTicker.SelectedIndexChanged += new System.EventHandler(this.CmbTicker_SelectedIndexChanged);
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(655, 60);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(98, 20);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Financial Year";
            //
            // CmbFinYear
            //
            this.CmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinYear.FormattingEnabled = true;
            this.CmbFinYear.Location = new System.Drawing.Point(755, 58);
            this.CmbFinYear.Name = "CmbFinYear";
            this.CmbFinYear.Size = new System.Drawing.Size(130, 22);
            this.CmbFinYear.TabIndex = 3;
            this.CmbFinYear.SelectedIndexChanged += new System.EventHandler(this.CmbFinYear_SelectedIndexChanged);
            //
            // LblCurrency
            //
            this.LblCurrency.BackColor = System.Drawing.Color.Transparent;
            this.LblCurrency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblCurrency.Location = new System.Drawing.Point(905, 58);
            this.LblCurrency.Name = "LblCurrency";
            this.LblCurrency.Size = new System.Drawing.Size(340, 22);
            this.LblCurrency.TabIndex = 12;
            this.LblCurrency.Text = "Currency : -";
            this.LblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 86);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1226, 20);
            this.LblNote.TabIndex = 13;
            //
            // LblPurchase
            //
            this.LblPurchase.BackColor = System.Drawing.Color.Transparent;
            this.LblPurchase.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurchase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblPurchase.Location = new System.Drawing.Point(19, 110);
            this.LblPurchase.Name = "LblPurchase";
            this.LblPurchase.Size = new System.Drawing.Size(300, 22);
            this.LblPurchase.TabIndex = 14;
            this.LblPurchase.Text = "Purchase";
            //
            // gvPurchase
            //
            this.gvPurchase.AllowUserToAddRows = false;
            this.gvPurchase.AllowUserToDeleteRows = false;
            this.gvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPurchase.Location = new System.Drawing.Point(19, 134);
            this.gvPurchase.MultiSelect = false;
            this.gvPurchase.Name = "gvPurchase";
            this.gvPurchase.ReadOnly = true;
            this.gvPurchase.RowHeadersVisible = false;
            this.gvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPurchase.Size = new System.Drawing.Size(1226, 200);
            this.gvPurchase.TabIndex = 4;
            //
            // LblPurUnitCap
            //
            this.LblPurUnitCap.BackColor = System.Drawing.Color.Transparent;
            this.LblPurUnitCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurUnitCap.ForeColor = System.Drawing.Color.Black;
            this.LblPurUnitCap.Location = new System.Drawing.Point(19, 340);
            this.LblPurUnitCap.Name = "LblPurUnitCap";
            this.LblPurUnitCap.Size = new System.Drawing.Size(175, 20);
            this.LblPurUnitCap.TabIndex = 15;
            this.LblPurUnitCap.Text = "Total Purchase Unit";
            this.LblPurUnitCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblPurUnit
            //
            this.LblPurUnit.BackColor = System.Drawing.Color.Transparent;
            this.LblPurUnit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurUnit.ForeColor = System.Drawing.Color.Black;
            this.LblPurUnit.Location = new System.Drawing.Point(196, 340);
            this.LblPurUnit.Name = "LblPurUnit";
            this.LblPurUnit.Size = new System.Drawing.Size(125, 20);
            this.LblPurUnit.TabIndex = 16;
            this.LblPurUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblPurCurrentUnitCap
            //
            this.LblPurCurrentUnitCap.BackColor = System.Drawing.Color.Transparent;
            this.LblPurCurrentUnitCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurCurrentUnitCap.ForeColor = System.Drawing.Color.Black;
            this.LblPurCurrentUnitCap.Location = new System.Drawing.Point(19, 362);
            this.LblPurCurrentUnitCap.Name = "LblPurCurrentUnitCap";
            this.LblPurCurrentUnitCap.Size = new System.Drawing.Size(175, 20);
            this.LblPurCurrentUnitCap.TabIndex = 17;
            this.LblPurCurrentUnitCap.Text = "Total Current Unit";
            this.LblPurCurrentUnitCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblPurCurrentUnit
            //
            this.LblPurCurrentUnit.BackColor = System.Drawing.Color.Transparent;
            this.LblPurCurrentUnit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurCurrentUnit.ForeColor = System.Drawing.Color.Black;
            this.LblPurCurrentUnit.Location = new System.Drawing.Point(196, 362);
            this.LblPurCurrentUnit.Name = "LblPurCurrentUnit";
            this.LblPurCurrentUnit.Size = new System.Drawing.Size(125, 20);
            this.LblPurCurrentUnit.TabIndex = 18;
            this.LblPurCurrentUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblPurSoldUnitCap
            //
            this.LblPurSoldUnitCap.BackColor = System.Drawing.Color.Transparent;
            this.LblPurSoldUnitCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurSoldUnitCap.ForeColor = System.Drawing.Color.Black;
            this.LblPurSoldUnitCap.Location = new System.Drawing.Point(19, 384);
            this.LblPurSoldUnitCap.Name = "LblPurSoldUnitCap";
            this.LblPurSoldUnitCap.Size = new System.Drawing.Size(175, 20);
            this.LblPurSoldUnitCap.TabIndex = 19;
            this.LblPurSoldUnitCap.Text = "Total Sold Unit";
            this.LblPurSoldUnitCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblPurSoldUnit
            //
            this.LblPurSoldUnit.BackColor = System.Drawing.Color.Transparent;
            this.LblPurSoldUnit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurSoldUnit.ForeColor = System.Drawing.Color.Black;
            this.LblPurSoldUnit.Location = new System.Drawing.Point(196, 384);
            this.LblPurSoldUnit.Name = "LblPurSoldUnit";
            this.LblPurSoldUnit.Size = new System.Drawing.Size(125, 20);
            this.LblPurSoldUnit.TabIndex = 20;
            this.LblPurSoldUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblPurAvgCostCap
            //
            this.LblPurAvgCostCap.BackColor = System.Drawing.Color.Transparent;
            this.LblPurAvgCostCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurAvgCostCap.ForeColor = System.Drawing.Color.Black;
            this.LblPurAvgCostCap.Location = new System.Drawing.Point(440, 340);
            this.LblPurAvgCostCap.Name = "LblPurAvgCostCap";
            this.LblPurAvgCostCap.Size = new System.Drawing.Size(195, 20);
            this.LblPurAvgCostCap.TabIndex = 21;
            this.LblPurAvgCostCap.Text = "Average Cost Base";
            this.LblPurAvgCostCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblPurAvgCost
            //
            this.LblPurAvgCost.BackColor = System.Drawing.Color.Transparent;
            this.LblPurAvgCost.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurAvgCost.ForeColor = System.Drawing.Color.Black;
            this.LblPurAvgCost.Location = new System.Drawing.Point(637, 340);
            this.LblPurAvgCost.Name = "LblPurAvgCost";
            this.LblPurAvgCost.Size = new System.Drawing.Size(135, 20);
            this.LblPurAvgCost.TabIndex = 22;
            this.LblPurAvgCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblPurAvgRealCap
            //
            this.LblPurAvgRealCap.BackColor = System.Drawing.Color.Transparent;
            this.LblPurAvgRealCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurAvgRealCap.ForeColor = System.Drawing.Color.Black;
            this.LblPurAvgRealCap.Location = new System.Drawing.Point(440, 362);
            this.LblPurAvgRealCap.Name = "LblPurAvgRealCap";
            this.LblPurAvgRealCap.Size = new System.Drawing.Size(195, 20);
            this.LblPurAvgRealCap.TabIndex = 23;
            this.LblPurAvgRealCap.Text = "Average Real Cost Base";
            this.LblPurAvgRealCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblPurAvgReal
            //
            this.LblPurAvgReal.BackColor = System.Drawing.Color.Transparent;
            this.LblPurAvgReal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurAvgReal.ForeColor = System.Drawing.Color.Black;
            this.LblPurAvgReal.Location = new System.Drawing.Point(637, 362);
            this.LblPurAvgReal.Name = "LblPurAvgReal";
            this.LblPurAvgReal.Size = new System.Drawing.Size(135, 20);
            this.LblPurAvgReal.TabIndex = 24;
            this.LblPurAvgReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblPurTotalCostCap
            //
            this.LblPurTotalCostCap.BackColor = System.Drawing.Color.Transparent;
            this.LblPurTotalCostCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurTotalCostCap.ForeColor = System.Drawing.Color.Black;
            this.LblPurTotalCostCap.Location = new System.Drawing.Point(860, 340);
            this.LblPurTotalCostCap.Name = "LblPurTotalCostCap";
            this.LblPurTotalCostCap.Size = new System.Drawing.Size(220, 20);
            this.LblPurTotalCostCap.TabIndex = 25;
            this.LblPurTotalCostCap.Text = "Grand Total Cost Base";
            this.LblPurTotalCostCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblPurTotalCost
            //
            this.LblPurTotalCost.BackColor = System.Drawing.Color.Transparent;
            this.LblPurTotalCost.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurTotalCost.ForeColor = System.Drawing.Color.Black;
            this.LblPurTotalCost.Location = new System.Drawing.Point(1082, 340);
            this.LblPurTotalCost.Name = "LblPurTotalCost";
            this.LblPurTotalCost.Size = new System.Drawing.Size(163, 20);
            this.LblPurTotalCost.TabIndex = 26;
            this.LblPurTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblPurTotalRealCap
            //
            this.LblPurTotalRealCap.BackColor = System.Drawing.Color.Transparent;
            this.LblPurTotalRealCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurTotalRealCap.ForeColor = System.Drawing.Color.Black;
            this.LblPurTotalRealCap.Location = new System.Drawing.Point(860, 362);
            this.LblPurTotalRealCap.Name = "LblPurTotalRealCap";
            this.LblPurTotalRealCap.Size = new System.Drawing.Size(220, 20);
            this.LblPurTotalRealCap.TabIndex = 27;
            this.LblPurTotalRealCap.Text = "Grand Total Real Cost Base";
            this.LblPurTotalRealCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblPurTotalReal
            //
            this.LblPurTotalReal.BackColor = System.Drawing.Color.Transparent;
            this.LblPurTotalReal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurTotalReal.ForeColor = System.Drawing.Color.Black;
            this.LblPurTotalReal.Location = new System.Drawing.Point(1082, 362);
            this.LblPurTotalReal.Name = "LblPurTotalReal";
            this.LblPurTotalReal.Size = new System.Drawing.Size(163, 20);
            this.LblPurTotalReal.TabIndex = 28;
            this.LblPurTotalReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblSale
            //
            this.LblSale.BackColor = System.Drawing.Color.Transparent;
            this.LblSale.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblSale.Location = new System.Drawing.Point(19, 412);
            this.LblSale.Name = "LblSale";
            this.LblSale.Size = new System.Drawing.Size(300, 22);
            this.LblSale.TabIndex = 29;
            this.LblSale.Text = "Sale";
            //
            // gvSale
            //
            this.gvSale.AllowUserToAddRows = false;
            this.gvSale.AllowUserToDeleteRows = false;
            this.gvSale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSale.Location = new System.Drawing.Point(19, 436);
            this.gvSale.MultiSelect = false;
            this.gvSale.Name = "gvSale";
            this.gvSale.ReadOnly = true;
            this.gvSale.RowHeadersVisible = false;
            this.gvSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSale.Size = new System.Drawing.Size(796, 170);
            this.gvSale.TabIndex = 5;
            //
            // LblSaleUnitCap
            //
            this.LblSaleUnitCap.BackColor = System.Drawing.Color.Transparent;
            this.LblSaleUnitCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaleUnitCap.ForeColor = System.Drawing.Color.Black;
            this.LblSaleUnitCap.Location = new System.Drawing.Point(19, 612);
            this.LblSaleUnitCap.Name = "LblSaleUnitCap";
            this.LblSaleUnitCap.Size = new System.Drawing.Size(190, 20);
            this.LblSaleUnitCap.TabIndex = 30;
            this.LblSaleUnitCap.Text = "Total Sold Unit";
            this.LblSaleUnitCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblSaleUnit
            //
            this.LblSaleUnit.BackColor = System.Drawing.Color.Transparent;
            this.LblSaleUnit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaleUnit.ForeColor = System.Drawing.Color.Black;
            this.LblSaleUnit.Location = new System.Drawing.Point(211, 612);
            this.LblSaleUnit.Name = "LblSaleUnit";
            this.LblSaleUnit.Size = new System.Drawing.Size(150, 20);
            this.LblSaleUnit.TabIndex = 31;
            this.LblSaleUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblSaleAmountCap
            //
            this.LblSaleAmountCap.BackColor = System.Drawing.Color.Transparent;
            this.LblSaleAmountCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaleAmountCap.ForeColor = System.Drawing.Color.Black;
            this.LblSaleAmountCap.Location = new System.Drawing.Point(19, 634);
            this.LblSaleAmountCap.Name = "LblSaleAmountCap";
            this.LblSaleAmountCap.Size = new System.Drawing.Size(190, 20);
            this.LblSaleAmountCap.TabIndex = 32;
            this.LblSaleAmountCap.Text = "Grand Total Sold Amount";
            this.LblSaleAmountCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblSaleAmount
            //
            this.LblSaleAmount.BackColor = System.Drawing.Color.Transparent;
            this.LblSaleAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaleAmount.ForeColor = System.Drawing.Color.Black;
            this.LblSaleAmount.Location = new System.Drawing.Point(211, 634);
            this.LblSaleAmount.Name = "LblSaleAmount";
            this.LblSaleAmount.Size = new System.Drawing.Size(150, 20);
            this.LblSaleAmount.TabIndex = 33;
            this.LblSaleAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblSalePaperCap
            //
            this.LblSalePaperCap.BackColor = System.Drawing.Color.Transparent;
            this.LblSalePaperCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSalePaperCap.ForeColor = System.Drawing.Color.Black;
            this.LblSalePaperCap.Location = new System.Drawing.Point(420, 612);
            this.LblSalePaperCap.Name = "LblSalePaperCap";
            this.LblSalePaperCap.Size = new System.Drawing.Size(215, 20);
            this.LblSalePaperCap.TabIndex = 34;
            this.LblSalePaperCap.Text = "Total Profit/Loss On Paper";
            this.LblSalePaperCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblSalePaper
            //
            this.LblSalePaper.BackColor = System.Drawing.Color.Transparent;
            this.LblSalePaper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSalePaper.ForeColor = System.Drawing.Color.Black;
            this.LblSalePaper.Location = new System.Drawing.Point(637, 612);
            this.LblSalePaper.Name = "LblSalePaper";
            this.LblSalePaper.Size = new System.Drawing.Size(150, 20);
            this.LblSalePaper.TabIndex = 35;
            this.LblSalePaper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblSaleRealCap
            //
            this.LblSaleRealCap.BackColor = System.Drawing.Color.Transparent;
            this.LblSaleRealCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaleRealCap.ForeColor = System.Drawing.Color.Black;
            this.LblSaleRealCap.Location = new System.Drawing.Point(420, 634);
            this.LblSaleRealCap.Name = "LblSaleRealCap";
            this.LblSaleRealCap.Size = new System.Drawing.Size(215, 20);
            this.LblSaleRealCap.TabIndex = 36;
            this.LblSaleRealCap.Text = "Total Real Profit/Loss";
            this.LblSaleRealCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblSaleReal
            //
            this.LblSaleReal.BackColor = System.Drawing.Color.Transparent;
            this.LblSaleReal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSaleReal.ForeColor = System.Drawing.Color.Black;
            this.LblSaleReal.Location = new System.Drawing.Point(637, 634);
            this.LblSaleReal.Name = "LblSaleReal";
            this.LblSaleReal.Size = new System.Drawing.Size(150, 20);
            this.LblSaleReal.TabIndex = 37;
            this.LblSaleReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDistribution
            //
            this.LblDistribution.BackColor = System.Drawing.Color.Transparent;
            this.LblDistribution.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDistribution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblDistribution.Location = new System.Drawing.Point(835, 412);
            this.LblDistribution.Name = "LblDistribution";
            this.LblDistribution.Size = new System.Drawing.Size(300, 22);
            this.LblDistribution.TabIndex = 38;
            this.LblDistribution.Text = "Distribution/Dividend";
            //
            // gvDistribution
            //
            this.gvDistribution.AllowUserToAddRows = false;
            this.gvDistribution.AllowUserToDeleteRows = false;
            this.gvDistribution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDistribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDistribution.Location = new System.Drawing.Point(835, 436);
            this.gvDistribution.MultiSelect = false;
            this.gvDistribution.Name = "gvDistribution";
            this.gvDistribution.ReadOnly = true;
            this.gvDistribution.RowHeadersVisible = false;
            this.gvDistribution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDistribution.Size = new System.Drawing.Size(410, 170);
            this.gvDistribution.TabIndex = 6;
            //
            // LblDistTotalCap
            //
            this.LblDistTotalCap.BackColor = System.Drawing.Color.Transparent;
            this.LblDistTotalCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDistTotalCap.ForeColor = System.Drawing.Color.Black;
            this.LblDistTotalCap.Location = new System.Drawing.Point(835, 612);
            this.LblDistTotalCap.Name = "LblDistTotalCap";
            this.LblDistTotalCap.Size = new System.Drawing.Size(215, 20);
            this.LblDistTotalCap.TabIndex = 39;
            this.LblDistTotalCap.Text = "Total Distribution/Dividend";
            this.LblDistTotalCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblDistTotal
            //
            this.LblDistTotal.BackColor = System.Drawing.Color.Transparent;
            this.LblDistTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDistTotal.ForeColor = System.Drawing.Color.Black;
            this.LblDistTotal.Location = new System.Drawing.Point(1082, 612);
            this.LblDistTotal.Name = "LblDistTotal";
            this.LblDistTotal.Size = new System.Drawing.Size(163, 20);
            this.LblDistTotal.TabIndex = 40;
            this.LblDistTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(1160, 644);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 7;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // LblPurPriceCap
            //
            this.LblPurPriceCap.BackColor = System.Drawing.Color.Transparent;
            this.LblPurPriceCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurPriceCap.ForeColor = System.Drawing.Color.Black;
            this.LblPurPriceCap.Location = new System.Drawing.Point(440, 384);
            this.LblPurPriceCap.Name = "LblPurPriceCap";
            this.LblPurPriceCap.Size = new System.Drawing.Size(195, 20);
            this.LblPurPriceCap.TabIndex = 41;
            this.LblPurPriceCap.Text = "Latest Price";
            this.LblPurPriceCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblPurPrice
            //
            this.LblPurPrice.BackColor = System.Drawing.Color.Transparent;
            this.LblPurPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPurPrice.ForeColor = System.Drawing.Color.Black;
            this.LblPurPrice.Location = new System.Drawing.Point(637, 384);
            this.LblPurPrice.Name = "LblPurPrice";
            this.LblPurPrice.Size = new System.Drawing.Size(135, 20);
            this.LblPurPrice.TabIndex = 42;
            this.LblPurPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // ETF_Stocks_Ticker_Historical_Data
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1264, 680);
            this.ControlBox = false;
            this.Controls.Add(this.LblPurPrice);
            this.Controls.Add(this.LblPurPriceCap);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblDistTotal);
            this.Controls.Add(this.LblDistTotalCap);
            this.Controls.Add(this.gvDistribution);
            this.Controls.Add(this.LblDistribution);
            this.Controls.Add(this.LblSaleReal);
            this.Controls.Add(this.LblSaleRealCap);
            this.Controls.Add(this.LblSalePaper);
            this.Controls.Add(this.LblSalePaperCap);
            this.Controls.Add(this.LblSaleAmount);
            this.Controls.Add(this.LblSaleAmountCap);
            this.Controls.Add(this.LblSaleUnit);
            this.Controls.Add(this.LblSaleUnitCap);
            this.Controls.Add(this.gvSale);
            this.Controls.Add(this.LblSale);
            this.Controls.Add(this.LblPurTotalReal);
            this.Controls.Add(this.LblPurTotalRealCap);
            this.Controls.Add(this.LblPurTotalCost);
            this.Controls.Add(this.LblPurTotalCostCap);
            this.Controls.Add(this.LblPurAvgReal);
            this.Controls.Add(this.LblPurAvgRealCap);
            this.Controls.Add(this.LblPurAvgCost);
            this.Controls.Add(this.LblPurAvgCostCap);
            this.Controls.Add(this.LblPurSoldUnit);
            this.Controls.Add(this.LblPurSoldUnitCap);
            this.Controls.Add(this.LblPurCurrentUnit);
            this.Controls.Add(this.LblPurCurrentUnitCap);
            this.Controls.Add(this.LblPurUnit);
            this.Controls.Add(this.LblPurUnitCap);
            this.Controls.Add(this.gvPurchase);
            this.Controls.Add(this.LblPurchase);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.LblCurrency);
            this.Controls.Add(this.CmbFinYear);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.CmbTicker);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Ticker_Historical_Data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Ticker Historical Data";
            this.Load += new System.EventHandler(this.ETF_Stocks_Ticker_Historical_Data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistribution)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.CheckBox chkMainOnly;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbTicker;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbFinYear;
        public System.Windows.Forms.Label LblCurrency;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.Label LblPurchase;
        private System.Windows.Forms.DataGridView gvPurchase;
        public System.Windows.Forms.Label LblPurUnitCap;
        public System.Windows.Forms.Label LblPurUnit;
        public System.Windows.Forms.Label LblPurCurrentUnitCap;
        public System.Windows.Forms.Label LblPurCurrentUnit;
        public System.Windows.Forms.Label LblPurSoldUnitCap;
        public System.Windows.Forms.Label LblPurSoldUnit;
        public System.Windows.Forms.Label LblPurAvgCostCap;
        public System.Windows.Forms.Label LblPurAvgCost;
        public System.Windows.Forms.Label LblPurAvgRealCap;
        public System.Windows.Forms.Label LblPurAvgReal;
        public System.Windows.Forms.Label LblPurTotalCostCap;
        public System.Windows.Forms.Label LblPurTotalCost;
        public System.Windows.Forms.Label LblPurTotalRealCap;
        public System.Windows.Forms.Label LblPurTotalReal;
        public System.Windows.Forms.Label LblSale;
        private System.Windows.Forms.DataGridView gvSale;
        public System.Windows.Forms.Label LblSaleUnitCap;
        public System.Windows.Forms.Label LblSaleUnit;
        public System.Windows.Forms.Label LblSaleAmountCap;
        public System.Windows.Forms.Label LblSaleAmount;
        public System.Windows.Forms.Label LblSalePaperCap;
        public System.Windows.Forms.Label LblSalePaper;
        public System.Windows.Forms.Label LblSaleRealCap;
        public System.Windows.Forms.Label LblSaleReal;
        public System.Windows.Forms.Label LblDistribution;
        private System.Windows.Forms.DataGridView gvDistribution;
        public System.Windows.Forms.Label LblDistTotalCap;
        public System.Windows.Forms.Label LblDistTotal;
        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.Label LblPurPriceCap;
        public System.Windows.Forms.Label LblPurPrice;
    }
}
