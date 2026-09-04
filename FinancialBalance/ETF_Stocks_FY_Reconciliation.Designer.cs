namespace FinancialBalance
{
    partial class ETF_Stocks_FY_Reconciliation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_FY_Reconciliation));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbFinYear = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvRecon = new System.Windows.Forms.DataGridView();
            this.LblEntryCaption = new System.Windows.Forms.Label();
            this.Lbl_CmbEntryFinYear = new System.Windows.Forms.Label();
            this.CmbEntryFinYear = new System.Windows.Forms.ComboBox();
            this.Lbl_CmbEntryCode = new System.Windows.Forms.Label();
            this.CmbEntryCode = new System.Windows.Forms.ComboBox();
            this.Lbl_CmbEntryCurrency = new System.Windows.Forms.Label();
            this.CmbEntryCurrency = new System.Windows.Forms.ComboBox();
            this.Lbl_txtPrevInv = new System.Windows.Forms.Label();
            this.txtPrevInv = new System.Windows.Forms.TextBox();
            this.Lbl_txtInvestment = new System.Windows.Forms.Label();
            this.txtInvestment = new System.Windows.Forms.TextBox();
            this.Lbl_txtSold = new System.Windows.Forms.Label();
            this.txtSold = new System.Windows.Forms.TextBox();
            this.Lbl_txtEndInv = new System.Windows.Forms.Label();
            this.txtEndInv = new System.Windows.Forms.TextBox();
            this.Lbl_txtOnPaperVal = new System.Windows.Forms.Label();
            this.txtOnPaperVal = new System.Windows.Forms.TextBox();
            this.Lbl_txtOnPaperPL = new System.Windows.Forms.Label();
            this.txtOnPaperPL = new System.Windows.Forms.TextBox();
            this.Lbl_txtOnPaperPct = new System.Windows.Forms.Label();
            this.txtOnPaperPct = new System.Windows.Forms.TextBox();
            this.Lbl_txtDD = new System.Windows.Forms.Label();
            this.txtDD = new System.Windows.Forms.TextBox();
            this.Lbl_txtDDYield = new System.Windows.Forms.Label();
            this.txtDDYield = new System.Windows.Forms.TextBox();
            this.Lbl_txtDDReinv = new System.Windows.Forms.Label();
            this.txtDDReinv = new System.Windows.Forms.TextBox();
            this.Lbl_txtDDNotReinv = new System.Windows.Forms.Label();
            this.txtDDNotReinv = new System.Windows.Forms.TextBox();
            this.Lbl_txtCapGainPaper = new System.Windows.Forms.Label();
            this.txtCapGainPaper = new System.Windows.Forms.TextBox();
            this.Lbl_txtCapGainReal = new System.Windows.Forms.Label();
            this.txtCapGainReal = new System.Windows.Forms.TextBox();
            this.Lbl_txtLoanInterest = new System.Windows.Forms.Label();
            this.txtLoanInterest = new System.Windows.Forms.TextBox();
            this.Lbl_txtTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.Lbl_txtRealPL = new System.Windows.Forms.Label();
            this.txtRealPL = new System.Windows.Forms.TextBox();
            this.Lbl_txtRealPct = new System.Windows.Forms.Label();
            this.txtRealPct = new System.Windows.Forms.TextBox();
            this.LblEntryDesc = new System.Windows.Forms.Label();
            this.LblInvestmentHint = new System.Windows.Forms.Label();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecon)).BeginInit();
            this.SuspendLayout();
            //
            // MainMenu1
            //
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDaily,
            this.MnMonthlyClosing,
            this.MnETFStockProcessGroup});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(1340, 24);
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
            // MnETFStockProcessGroup
            //
            this.MnETFStockProcessGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnETFStocksPrice,
            this.MnETFStocksInvestment,
            this.MnETFStocksTrans,
            this.MnETFStocksDistribution});
            this.MnETFStockProcessGroup.Name = "MnETFStockProcessGroup";
            this.MnETFStockProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockProcessGroup.Text = "&ETF/Stock";
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
            // MnETFStocksTrans
            //
            this.MnETFStocksTrans.Name = "MnETFStocksTrans";
            this.MnETFStocksTrans.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksTrans.Text = "ETF/Stock &Transaction";
            this.MnETFStocksTrans.Click += new System.EventHandler(this.MnETFStocksTrans_Click);
            //
            // MnETFStocksDistribution
            //
            this.MnETFStocksDistribution.Name = "MnETFStocksDistribution";
            this.MnETFStocksDistribution.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksDistribution.Text = "ETF/Stock &Distribution/Dividend";
            this.MnETFStocksDistribution.Click += new System.EventHandler(this.MnETFStocksDistribution_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(180, 30);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(980, 38);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK FINANCIAL YEAR RECONCILIATION";
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 22);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Financial Year";
            //
            // CmbFinYear
            //
            this.CmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinYear.FormattingEnabled = true;
            this.CmbFinYear.Location = new System.Drawing.Point(125, 80);
            this.CmbFinYear.Name = "CmbFinYear";
            this.CmbFinYear.Size = new System.Drawing.Size(200, 22);
            this.CmbFinYear.TabIndex = 3;
            this.CmbFinYear.SelectedIndexChanged += new System.EventHandler(this.CmbFinYear_SelectedIndexChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(355, 82);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 22);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Portfolio";
            //
            // CmbPortfolio
            //
            this.CmbPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPortfolio.FormattingEnabled = true;
            this.CmbPortfolio.Location = new System.Drawing.Point(435, 80);
            this.CmbPortfolio.Name = "CmbPortfolio";
            this.CmbPortfolio.Size = new System.Drawing.Size(260, 22);
            this.CmbPortfolio.TabIndex = 5;
            this.CmbPortfolio.SelectedIndexChanged += new System.EventHandler(this.CmbPortfolio_SelectedIndexChanged);
            //
            // chkMainOnly
            //
            this.chkMainOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkMainOnly.Checked = true;
            this.chkMainOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMainOnly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMainOnly.ForeColor = System.Drawing.Color.Black;
            this.chkMainOnly.Location = new System.Drawing.Point(715, 80);
            this.chkMainOnly.Name = "chkMainOnly";
            this.chkMainOnly.Size = new System.Drawing.Size(100, 24);
            this.chkMainOnly.TabIndex = 6;
            this.chkMainOnly.Text = "Main Only";
            this.chkMainOnly.UseVisualStyleBackColor = false;
            this.chkMainOnly.CheckedChanged += new System.EventHandler(this.chkMainOnly_CheckedChanged);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 110);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1300, 20);
            this.LblNote.TabIndex = 7;
            //
            // gvRecon
            //
            this.gvRecon.AllowUserToAddRows = false;
            this.gvRecon.AllowUserToDeleteRows = false;
            this.gvRecon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvRecon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvRecon.Location = new System.Drawing.Point(19, 136);
            this.gvRecon.MultiSelect = false;
            this.gvRecon.Name = "gvRecon";
            this.gvRecon.ReadOnly = true;
            this.gvRecon.RowHeadersVisible = false;
            this.gvRecon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRecon.Size = new System.Drawing.Size(1300, 204);
            this.gvRecon.TabIndex = 8;
            this.gvRecon.SelectionChanged += new System.EventHandler(this.gvRecon_SelectionChanged);
            //
            // LblEntryCaption
            //
            this.LblEntryCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblEntryCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEntryCaption.ForeColor = System.Drawing.Color.Black;
            this.LblEntryCaption.Location = new System.Drawing.Point(19, 350);
            this.LblEntryCaption.Name = "LblEntryCaption";
            this.LblEntryCaption.Size = new System.Drawing.Size(600, 22);
            this.LblEntryCaption.TabIndex = 10;
            this.LblEntryCaption.Text = "Add, update or delete a reconciliation";
            //
            // Lbl_CmbEntryFinYear
            //
            this.Lbl_CmbEntryFinYear.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbEntryFinYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbEntryFinYear.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbEntryFinYear.Location = new System.Drawing.Point(19, 378);
            this.Lbl_CmbEntryFinYear.Name = "Lbl_CmbEntryFinYear";
            this.Lbl_CmbEntryFinYear.Size = new System.Drawing.Size(150, 22);
            this.Lbl_CmbEntryFinYear.TabIndex = 11;
            this.Lbl_CmbEntryFinYear.Text = "Financial Year";
            //
            // CmbEntryFinYear
            //
            this.CmbEntryFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEntryFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEntryFinYear.FormattingEnabled = true;
            this.CmbEntryFinYear.Location = new System.Drawing.Point(175, 376);
            this.CmbEntryFinYear.Name = "CmbEntryFinYear";
            this.CmbEntryFinYear.Size = new System.Drawing.Size(150, 22);
            this.CmbEntryFinYear.TabIndex = 12;
            this.CmbEntryFinYear.SelectedIndexChanged += new System.EventHandler(this.CmbEntryFinYear_SelectedIndexChanged);
            //
            // Lbl_CmbEntryCode
            //
            this.Lbl_CmbEntryCode.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbEntryCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbEntryCode.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbEntryCode.Location = new System.Drawing.Point(19, 406);
            this.Lbl_CmbEntryCode.Name = "Lbl_CmbEntryCode";
            this.Lbl_CmbEntryCode.Size = new System.Drawing.Size(150, 22);
            this.Lbl_CmbEntryCode.TabIndex = 13;
            this.Lbl_CmbEntryCode.Text = "Portfolio Code";
            //
            // CmbEntryCode
            //
            this.CmbEntryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEntryCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEntryCode.FormattingEnabled = true;
            this.CmbEntryCode.Location = new System.Drawing.Point(175, 404);
            this.CmbEntryCode.Name = "CmbEntryCode";
            this.CmbEntryCode.Size = new System.Drawing.Size(150, 22);
            this.CmbEntryCode.TabIndex = 14;
            this.CmbEntryCode.SelectedIndexChanged += new System.EventHandler(this.CmbEntryCode_SelectedIndexChanged);
            //
            // Lbl_CmbEntryCurrency
            //
            this.Lbl_CmbEntryCurrency.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbEntryCurrency.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbEntryCurrency.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbEntryCurrency.Location = new System.Drawing.Point(19, 434);
            this.Lbl_CmbEntryCurrency.Name = "Lbl_CmbEntryCurrency";
            this.Lbl_CmbEntryCurrency.Size = new System.Drawing.Size(150, 22);
            this.Lbl_CmbEntryCurrency.TabIndex = 15;
            this.Lbl_CmbEntryCurrency.Text = "Currency";
            //
            // CmbEntryCurrency
            //
            this.CmbEntryCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEntryCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEntryCurrency.FormattingEnabled = true;
            this.CmbEntryCurrency.Location = new System.Drawing.Point(175, 432);
            this.CmbEntryCurrency.Name = "CmbEntryCurrency";
            this.CmbEntryCurrency.Size = new System.Drawing.Size(150, 22);
            this.CmbEntryCurrency.TabIndex = 16;
            this.CmbEntryCurrency.SelectedIndexChanged += new System.EventHandler(this.CmbEntryCurrency_SelectedIndexChanged);
            //
            // Lbl_txtPrevInv
            //
            this.Lbl_txtPrevInv.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtPrevInv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtPrevInv.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtPrevInv.Location = new System.Drawing.Point(19, 462);
            this.Lbl_txtPrevInv.Name = "Lbl_txtPrevInv";
            this.Lbl_txtPrevInv.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtPrevInv.TabIndex = 17;
            this.Lbl_txtPrevInv.Text = "Previous Investment";
            //
            // txtPrevInv
            //
            this.txtPrevInv.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrevInv.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrevInv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrevInv.Location = new System.Drawing.Point(175, 461);
            this.txtPrevInv.MaxLength = 20;
            this.txtPrevInv.Name = "txtPrevInv";
            this.txtPrevInv.Size = new System.Drawing.Size(150, 20);
            this.txtPrevInv.TabIndex = 18;
            this.txtPrevInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrevInv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtPrevInv.TextChanged += new System.EventHandler(this.txtPrevInv_TextChanged);
            //
            // Lbl_txtInvestment
            //
            this.Lbl_txtInvestment.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtInvestment.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtInvestment.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtInvestment.Location = new System.Drawing.Point(19, 490);
            this.Lbl_txtInvestment.Name = "Lbl_txtInvestment";
            this.Lbl_txtInvestment.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtInvestment.TabIndex = 19;
            this.Lbl_txtInvestment.Text = "Investment";
            //
            // txtInvestment
            //
            this.txtInvestment.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvestment.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvestment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInvestment.Location = new System.Drawing.Point(175, 489);
            this.txtInvestment.MaxLength = 20;
            this.txtInvestment.Name = "txtInvestment";
            this.txtInvestment.Size = new System.Drawing.Size(150, 20);
            this.txtInvestment.TabIndex = 20;
            this.txtInvestment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvestment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtInvestment.TextChanged += new System.EventHandler(this.txtInvestment_TextChanged);
            //
            // Lbl_txtSold
            //
            this.Lbl_txtSold.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtSold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtSold.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtSold.Location = new System.Drawing.Point(19, 518);
            this.Lbl_txtSold.Name = "Lbl_txtSold";
            this.Lbl_txtSold.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtSold.TabIndex = 21;
            this.Lbl_txtSold.Text = "Sold Amount";
            //
            // txtSold
            //
            this.txtSold.BackColor = System.Drawing.SystemColors.Window;
            this.txtSold.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSold.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSold.Location = new System.Drawing.Point(175, 517);
            this.txtSold.MaxLength = 20;
            this.txtSold.Name = "txtSold";
            this.txtSold.Size = new System.Drawing.Size(150, 20);
            this.txtSold.TabIndex = 22;
            this.txtSold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtSold.TextChanged += new System.EventHandler(this.txtSold_TextChanged);
            //
            // Lbl_txtEndInv
            //
            this.Lbl_txtEndInv.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtEndInv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtEndInv.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtEndInv.Location = new System.Drawing.Point(19, 546);
            this.Lbl_txtEndInv.Name = "Lbl_txtEndInv";
            this.Lbl_txtEndInv.Size = new System.Drawing.Size(150, 22);
            this.Lbl_txtEndInv.TabIndex = 23;
            this.Lbl_txtEndInv.Text = "Ending Investment";
            //
            // txtEndInv
            //
            this.txtEndInv.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndInv.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndInv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndInv.Location = new System.Drawing.Point(175, 545);
            this.txtEndInv.MaxLength = 20;
            this.txtEndInv.Name = "txtEndInv";
            this.txtEndInv.Size = new System.Drawing.Size(150, 20);
            this.txtEndInv.TabIndex = 24;
            this.txtEndInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEndInv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtEndInv.TextChanged += new System.EventHandler(this.txtEndInv_TextChanged);
            //
            // Lbl_txtOnPaperVal
            //
            this.Lbl_txtOnPaperVal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOnPaperVal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOnPaperVal.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOnPaperVal.Location = new System.Drawing.Point(545, 378);
            this.Lbl_txtOnPaperVal.Name = "Lbl_txtOnPaperVal";
            this.Lbl_txtOnPaperVal.Size = new System.Drawing.Size(230, 22);
            this.Lbl_txtOnPaperVal.TabIndex = 25;
            this.Lbl_txtOnPaperVal.Text = "On Paper Ending Value";
            //
            // txtOnPaperVal
            //
            this.txtOnPaperVal.BackColor = System.Drawing.SystemColors.Window;
            this.txtOnPaperVal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnPaperVal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOnPaperVal.Location = new System.Drawing.Point(780, 377);
            this.txtOnPaperVal.MaxLength = 20;
            this.txtOnPaperVal.Name = "txtOnPaperVal";
            this.txtOnPaperVal.Size = new System.Drawing.Size(150, 20);
            this.txtOnPaperVal.TabIndex = 26;
            this.txtOnPaperVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOnPaperVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtOnPaperVal.TextChanged += new System.EventHandler(this.txtOnPaperVal_TextChanged);
            //
            // Lbl_txtOnPaperPL
            //
            this.Lbl_txtOnPaperPL.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOnPaperPL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOnPaperPL.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOnPaperPL.Location = new System.Drawing.Point(545, 406);
            this.Lbl_txtOnPaperPL.Name = "Lbl_txtOnPaperPL";
            this.Lbl_txtOnPaperPL.Size = new System.Drawing.Size(230, 22);
            this.Lbl_txtOnPaperPL.TabIndex = 27;
            this.Lbl_txtOnPaperPL.Text = "On Paper Profit/Loss";
            //
            // txtOnPaperPL
            //
            this.txtOnPaperPL.BackColor = System.Drawing.SystemColors.Window;
            this.txtOnPaperPL.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnPaperPL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOnPaperPL.Location = new System.Drawing.Point(780, 405);
            this.txtOnPaperPL.MaxLength = 20;
            this.txtOnPaperPL.Name = "txtOnPaperPL";
            this.txtOnPaperPL.Size = new System.Drawing.Size(150, 20);
            this.txtOnPaperPL.TabIndex = 28;
            this.txtOnPaperPL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOnPaperPL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtOnPaperPL.TextChanged += new System.EventHandler(this.txtOnPaperPL_TextChanged);
            //
            // Lbl_txtOnPaperPct
            //
            this.Lbl_txtOnPaperPct.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOnPaperPct.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOnPaperPct.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOnPaperPct.Location = new System.Drawing.Point(545, 434);
            this.Lbl_txtOnPaperPct.Name = "Lbl_txtOnPaperPct";
            this.Lbl_txtOnPaperPct.Size = new System.Drawing.Size(230, 22);
            this.Lbl_txtOnPaperPct.TabIndex = 29;
            this.Lbl_txtOnPaperPct.Text = "Percentage On Paper Profit/Loss";
            //
            // txtOnPaperPct
            //
            this.txtOnPaperPct.BackColor = System.Drawing.SystemColors.Window;
            this.txtOnPaperPct.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnPaperPct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOnPaperPct.Location = new System.Drawing.Point(780, 433);
            this.txtOnPaperPct.MaxLength = 20;
            this.txtOnPaperPct.Name = "txtOnPaperPct";
            this.txtOnPaperPct.Size = new System.Drawing.Size(150, 20);
            this.txtOnPaperPct.TabIndex = 30;
            this.txtOnPaperPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOnPaperPct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            //
            // Lbl_txtDD
            //
            this.Lbl_txtDD.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtDD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtDD.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtDD.Location = new System.Drawing.Point(545, 462);
            this.Lbl_txtDD.Name = "Lbl_txtDD";
            this.Lbl_txtDD.Size = new System.Drawing.Size(230, 22);
            this.Lbl_txtDD.TabIndex = 31;
            this.Lbl_txtDD.Text = "Distribution/Dividend";
            //
            // txtDD
            //
            this.txtDD.BackColor = System.Drawing.SystemColors.Window;
            this.txtDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDD.Location = new System.Drawing.Point(780, 461);
            this.txtDD.MaxLength = 20;
            this.txtDD.Name = "txtDD";
            this.txtDD.Size = new System.Drawing.Size(150, 20);
            this.txtDD.TabIndex = 32;
            this.txtDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtDD.TextChanged += new System.EventHandler(this.txtDD_TextChanged);
            //
            // Lbl_txtDDYield
            //
            this.Lbl_txtDDYield.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtDDYield.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtDDYield.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtDDYield.Location = new System.Drawing.Point(545, 490);
            this.Lbl_txtDDYield.Name = "Lbl_txtDDYield";
            this.Lbl_txtDDYield.Size = new System.Drawing.Size(230, 22);
            this.Lbl_txtDDYield.TabIndex = 33;
            this.Lbl_txtDDYield.Text = "Distribution/Dividend Yield";
            //
            // txtDDYield
            //
            this.txtDDYield.BackColor = System.Drawing.SystemColors.Window;
            this.txtDDYield.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDYield.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDDYield.Location = new System.Drawing.Point(780, 489);
            this.txtDDYield.MaxLength = 20;
            this.txtDDYield.Name = "txtDDYield";
            this.txtDDYield.Size = new System.Drawing.Size(150, 20);
            this.txtDDYield.TabIndex = 34;
            this.txtDDYield.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDDYield.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            //
            // Lbl_txtDDReinv
            //
            this.Lbl_txtDDReinv.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtDDReinv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtDDReinv.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtDDReinv.Location = new System.Drawing.Point(545, 518);
            this.Lbl_txtDDReinv.Name = "Lbl_txtDDReinv";
            this.Lbl_txtDDReinv.Size = new System.Drawing.Size(230, 22);
            this.Lbl_txtDDReinv.TabIndex = 35;
            this.Lbl_txtDDReinv.Text = "Distribution/Dividend Reinvested";
            //
            // txtDDReinv
            //
            this.txtDDReinv.BackColor = System.Drawing.SystemColors.Window;
            this.txtDDReinv.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDReinv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDDReinv.Location = new System.Drawing.Point(780, 517);
            this.txtDDReinv.MaxLength = 20;
            this.txtDDReinv.Name = "txtDDReinv";
            this.txtDDReinv.Size = new System.Drawing.Size(150, 20);
            this.txtDDReinv.TabIndex = 36;
            this.txtDDReinv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDDReinv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            //
            // Lbl_txtDDNotReinv
            //
            this.Lbl_txtDDNotReinv.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtDDNotReinv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtDDNotReinv.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtDDNotReinv.Location = new System.Drawing.Point(545, 546);
            this.Lbl_txtDDNotReinv.Name = "Lbl_txtDDNotReinv";
            this.Lbl_txtDDNotReinv.Size = new System.Drawing.Size(230, 22);
            this.Lbl_txtDDNotReinv.TabIndex = 37;
            this.Lbl_txtDDNotReinv.Text = "Distribution/Dividend Not Reinvested";
            //
            // txtDDNotReinv
            //
            this.txtDDNotReinv.BackColor = System.Drawing.SystemColors.Window;
            this.txtDDNotReinv.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDDNotReinv.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDDNotReinv.Location = new System.Drawing.Point(780, 545);
            this.txtDDNotReinv.MaxLength = 20;
            this.txtDDNotReinv.Name = "txtDDNotReinv";
            this.txtDDNotReinv.Size = new System.Drawing.Size(150, 20);
            this.txtDDNotReinv.TabIndex = 38;
            this.txtDDNotReinv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDDNotReinv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            //
            // Lbl_txtCapGainPaper
            //
            this.Lbl_txtCapGainPaper.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtCapGainPaper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtCapGainPaper.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtCapGainPaper.Location = new System.Drawing.Point(940, 378);
            this.Lbl_txtCapGainPaper.Name = "Lbl_txtCapGainPaper";
            this.Lbl_txtCapGainPaper.Size = new System.Drawing.Size(185, 22);
            this.Lbl_txtCapGainPaper.TabIndex = 39;
            this.Lbl_txtCapGainPaper.Text = "Capital Gains On Paper";
            //
            // txtCapGainPaper
            //
            this.txtCapGainPaper.BackColor = System.Drawing.SystemColors.Window;
            this.txtCapGainPaper.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapGainPaper.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCapGainPaper.Location = new System.Drawing.Point(1135, 377);
            this.txtCapGainPaper.MaxLength = 20;
            this.txtCapGainPaper.Name = "txtCapGainPaper";
            this.txtCapGainPaper.Size = new System.Drawing.Size(150, 20);
            this.txtCapGainPaper.TabIndex = 40;
            this.txtCapGainPaper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapGainPaper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            //
            // Lbl_txtCapGainReal
            //
            this.Lbl_txtCapGainReal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtCapGainReal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtCapGainReal.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtCapGainReal.Location = new System.Drawing.Point(940, 406);
            this.Lbl_txtCapGainReal.Name = "Lbl_txtCapGainReal";
            this.Lbl_txtCapGainReal.Size = new System.Drawing.Size(185, 22);
            this.Lbl_txtCapGainReal.TabIndex = 41;
            this.Lbl_txtCapGainReal.Text = "Real Capital Gains";
            //
            // txtCapGainReal
            //
            this.txtCapGainReal.BackColor = System.Drawing.SystemColors.Window;
            this.txtCapGainReal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapGainReal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCapGainReal.Location = new System.Drawing.Point(1135, 405);
            this.txtCapGainReal.MaxLength = 20;
            this.txtCapGainReal.Name = "txtCapGainReal";
            this.txtCapGainReal.Size = new System.Drawing.Size(150, 20);
            this.txtCapGainReal.TabIndex = 42;
            this.txtCapGainReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCapGainReal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtCapGainReal.TextChanged += new System.EventHandler(this.txtCapGainReal_TextChanged);
            //
            // Lbl_txtLoanInterest
            //
            this.Lbl_txtLoanInterest.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtLoanInterest.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtLoanInterest.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtLoanInterest.Location = new System.Drawing.Point(940, 434);
            this.Lbl_txtLoanInterest.Name = "Lbl_txtLoanInterest";
            this.Lbl_txtLoanInterest.Size = new System.Drawing.Size(185, 22);
            this.Lbl_txtLoanInterest.TabIndex = 43;
            this.Lbl_txtLoanInterest.Text = "Investment Loan Interest";
            //
            // txtLoanInterest
            //
            this.txtLoanInterest.BackColor = System.Drawing.SystemColors.Window;
            this.txtLoanInterest.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanInterest.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLoanInterest.Location = new System.Drawing.Point(1135, 433);
            this.txtLoanInterest.MaxLength = 20;
            this.txtLoanInterest.Name = "txtLoanInterest";
            this.txtLoanInterest.Size = new System.Drawing.Size(150, 20);
            this.txtLoanInterest.TabIndex = 44;
            this.txtLoanInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLoanInterest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtLoanInterest.TextChanged += new System.EventHandler(this.txtLoanInterest_TextChanged);
            //
            // Lbl_txtTax
            //
            this.Lbl_txtTax.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtTax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtTax.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtTax.Location = new System.Drawing.Point(940, 462);
            this.Lbl_txtTax.Name = "Lbl_txtTax";
            this.Lbl_txtTax.Size = new System.Drawing.Size(185, 22);
            this.Lbl_txtTax.TabIndex = 45;
            this.Lbl_txtTax.Text = "Tax";
            //
            // txtTax
            //
            this.txtTax.BackColor = System.Drawing.SystemColors.Window;
            this.txtTax.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTax.Location = new System.Drawing.Point(1135, 461);
            this.txtTax.MaxLength = 20;
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(150, 20);
            this.txtTax.TabIndex = 46;
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtTax.TextChanged += new System.EventHandler(this.txtTax_TextChanged);
            //
            // Lbl_txtRealPL
            //
            this.Lbl_txtRealPL.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtRealPL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtRealPL.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtRealPL.Location = new System.Drawing.Point(940, 490);
            this.Lbl_txtRealPL.Name = "Lbl_txtRealPL";
            this.Lbl_txtRealPL.Size = new System.Drawing.Size(185, 22);
            this.Lbl_txtRealPL.TabIndex = 47;
            this.Lbl_txtRealPL.Text = "Real Profit/Loss";
            //
            // txtRealPL
            //
            this.txtRealPL.BackColor = System.Drawing.SystemColors.Window;
            this.txtRealPL.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRealPL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRealPL.Location = new System.Drawing.Point(1135, 489);
            this.txtRealPL.MaxLength = 20;
            this.txtRealPL.Name = "txtRealPL";
            this.txtRealPL.Size = new System.Drawing.Size(150, 20);
            this.txtRealPL.TabIndex = 48;
            this.txtRealPL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRealPL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtRealPL.TextChanged += new System.EventHandler(this.txtRealPL_TextChanged);
            //
            // Lbl_txtRealPct
            //
            this.Lbl_txtRealPct.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtRealPct.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtRealPct.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtRealPct.Location = new System.Drawing.Point(940, 518);
            this.Lbl_txtRealPct.Name = "Lbl_txtRealPct";
            this.Lbl_txtRealPct.Size = new System.Drawing.Size(185, 22);
            this.Lbl_txtRealPct.TabIndex = 49;
            this.Lbl_txtRealPct.Text = "Percentage Real Profit/Loss";
            //
            // txtRealPct
            //
            this.txtRealPct.BackColor = System.Drawing.SystemColors.Window;
            this.txtRealPct.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRealPct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRealPct.Location = new System.Drawing.Point(1135, 517);
            this.txtRealPct.MaxLength = 20;
            this.txtRealPct.Name = "txtRealPct";
            this.txtRealPct.Size = new System.Drawing.Size(150, 20);
            this.txtRealPct.TabIndex = 50;
            this.txtRealPct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRealPct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            //
            // LblEntryDesc
            //
            this.LblEntryDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblEntryDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEntryDesc.ForeColor = System.Drawing.Color.Black;
            this.LblEntryDesc.Location = new System.Drawing.Point(331, 406);
            this.LblEntryDesc.Name = "LblEntryDesc";
            this.LblEntryDesc.Size = new System.Drawing.Size(210, 22);
            this.LblEntryDesc.TabIndex = 51;
            //
            // LblInvestmentHint
            //
            this.LblInvestmentHint.BackColor = System.Drawing.Color.Transparent;
            this.LblInvestmentHint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInvestmentHint.ForeColor = System.Drawing.Color.Black;
            this.LblInvestmentHint.Location = new System.Drawing.Point(331, 490);
            this.LblInvestmentHint.Name = "LblInvestmentHint";
            this.LblInvestmentHint.Size = new System.Drawing.Size(210, 22);
            this.LblInvestmentHint.TabIndex = 60;
            this.LblInvestmentHint.Text = "Please minus any amount in cash";
            //
            // CmdAdd
            //
            this.CmdAdd.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAdd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdAdd.Location = new System.Drawing.Point(175, 580);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(100, 27);
            this.CmdAdd.TabIndex = 52;
            this.CmdAdd.Text = "&Add";
            this.CmdAdd.UseVisualStyleBackColor = false;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdUpdate.Location = new System.Drawing.Point(285, 580);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(100, 27);
            this.CmdUpdate.TabIndex = 53;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(395, 580);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(100, 27);
            this.CmdDel.TabIndex = 54;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdClear
            //
            this.CmdClear.BackColor = System.Drawing.SystemColors.Control;
            this.CmdClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdClear.Location = new System.Drawing.Point(505, 580);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.Size = new System.Drawing.Size(100, 27);
            this.CmdClear.TabIndex = 55;
            this.CmdClear.Text = "&Clear";
            this.CmdClear.UseVisualStyleBackColor = false;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(1234, 580);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 9;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_FY_Reconciliation
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1340, 640);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblEntryCaption);
            this.Controls.Add(this.Lbl_CmbEntryFinYear);
            this.Controls.Add(this.CmbEntryFinYear);
            this.Controls.Add(this.Lbl_CmbEntryCode);
            this.Controls.Add(this.CmbEntryCode);
            this.Controls.Add(this.Lbl_CmbEntryCurrency);
            this.Controls.Add(this.CmbEntryCurrency);
            this.Controls.Add(this.Lbl_txtPrevInv);
            this.Controls.Add(this.txtPrevInv);
            this.Controls.Add(this.Lbl_txtInvestment);
            this.Controls.Add(this.txtInvestment);
            this.Controls.Add(this.Lbl_txtSold);
            this.Controls.Add(this.txtSold);
            this.Controls.Add(this.Lbl_txtEndInv);
            this.Controls.Add(this.txtEndInv);
            this.Controls.Add(this.Lbl_txtOnPaperVal);
            this.Controls.Add(this.txtOnPaperVal);
            this.Controls.Add(this.Lbl_txtOnPaperPL);
            this.Controls.Add(this.txtOnPaperPL);
            this.Controls.Add(this.Lbl_txtOnPaperPct);
            this.Controls.Add(this.txtOnPaperPct);
            this.Controls.Add(this.Lbl_txtDD);
            this.Controls.Add(this.txtDD);
            this.Controls.Add(this.Lbl_txtDDYield);
            this.Controls.Add(this.txtDDYield);
            this.Controls.Add(this.Lbl_txtDDReinv);
            this.Controls.Add(this.txtDDReinv);
            this.Controls.Add(this.Lbl_txtDDNotReinv);
            this.Controls.Add(this.txtDDNotReinv);
            this.Controls.Add(this.Lbl_txtCapGainPaper);
            this.Controls.Add(this.txtCapGainPaper);
            this.Controls.Add(this.Lbl_txtCapGainReal);
            this.Controls.Add(this.txtCapGainReal);
            this.Controls.Add(this.Lbl_txtLoanInterest);
            this.Controls.Add(this.txtLoanInterest);
            this.Controls.Add(this.Lbl_txtTax);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.Lbl_txtRealPL);
            this.Controls.Add(this.txtRealPL);
            this.Controls.Add(this.Lbl_txtRealPct);
            this.Controls.Add(this.txtRealPct);
            this.Controls.Add(this.LblEntryDesc);
            this.Controls.Add(this.LblInvestmentHint);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.gvRecon);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CmbFinYear);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "ETF_Stocks_FY_Reconciliation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Financial Year Reconciliation";
            this.Load += new System.EventHandler(this.ETF_Stocks_FY_Reconciliation_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvRecon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnDaily;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvestment;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksTrans;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDistribution;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbFinYear;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.CheckBox chkMainOnly;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvRecon;
        public System.Windows.Forms.Label LblEntryCaption;
        public System.Windows.Forms.Label Lbl_CmbEntryFinYear;
        public System.Windows.Forms.ComboBox CmbEntryFinYear;
        public System.Windows.Forms.Label Lbl_CmbEntryCode;
        public System.Windows.Forms.ComboBox CmbEntryCode;
        public System.Windows.Forms.Label Lbl_CmbEntryCurrency;
        public System.Windows.Forms.ComboBox CmbEntryCurrency;
        public System.Windows.Forms.Label Lbl_txtPrevInv;
        public System.Windows.Forms.TextBox txtPrevInv;
        public System.Windows.Forms.Label Lbl_txtInvestment;
        public System.Windows.Forms.TextBox txtInvestment;
        public System.Windows.Forms.Label Lbl_txtSold;
        public System.Windows.Forms.TextBox txtSold;
        public System.Windows.Forms.Label Lbl_txtEndInv;
        public System.Windows.Forms.TextBox txtEndInv;
        public System.Windows.Forms.Label Lbl_txtOnPaperVal;
        public System.Windows.Forms.TextBox txtOnPaperVal;
        public System.Windows.Forms.Label Lbl_txtOnPaperPL;
        public System.Windows.Forms.TextBox txtOnPaperPL;
        public System.Windows.Forms.Label Lbl_txtOnPaperPct;
        public System.Windows.Forms.TextBox txtOnPaperPct;
        public System.Windows.Forms.Label Lbl_txtDD;
        public System.Windows.Forms.TextBox txtDD;
        public System.Windows.Forms.Label Lbl_txtDDYield;
        public System.Windows.Forms.TextBox txtDDYield;
        public System.Windows.Forms.Label Lbl_txtDDReinv;
        public System.Windows.Forms.TextBox txtDDReinv;
        public System.Windows.Forms.Label Lbl_txtDDNotReinv;
        public System.Windows.Forms.TextBox txtDDNotReinv;
        public System.Windows.Forms.Label Lbl_txtCapGainPaper;
        public System.Windows.Forms.TextBox txtCapGainPaper;
        public System.Windows.Forms.Label Lbl_txtCapGainReal;
        public System.Windows.Forms.TextBox txtCapGainReal;
        public System.Windows.Forms.Label Lbl_txtLoanInterest;
        public System.Windows.Forms.TextBox txtLoanInterest;
        public System.Windows.Forms.Label Lbl_txtTax;
        public System.Windows.Forms.TextBox txtTax;
        public System.Windows.Forms.Label Lbl_txtRealPL;
        public System.Windows.Forms.TextBox txtRealPL;
        public System.Windows.Forms.Label Lbl_txtRealPct;
        public System.Windows.Forms.TextBox txtRealPct;
        public System.Windows.Forms.Label LblEntryDesc;
        public System.Windows.Forms.Label LblInvestmentHint;
        public System.Windows.Forms.Button CmdAdd;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdBack;
    }
}
