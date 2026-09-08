namespace FinancialBalance
{
    partial class Setup_ETF_Stocks_Investment_Plan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_ETF_Stocks_Investment_Plan));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrencyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnActivaPassivaSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnFinancialYearSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrRateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperFundSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFlagSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivAllocSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvPlan = new System.Windows.Forms.DataGridView();
            this.Lbl_txtName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.Lbl_CmbPlan = new System.Windows.Forms.Label();
            this.CmbPlan = new System.Windows.Forms.ComboBox();
            this.LblNote2 = new System.Windows.Forms.Label();
            this.gvAlloc = new System.Windows.Forms.DataGridView();
            this.Lbl_LblTotal = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.Lbl_CmbAllocPlan = new System.Windows.Forms.Label();
            this.CmbAllocPlan = new System.Windows.Forms.ComboBox();
            this.Lbl_CmbFullTicker = new System.Windows.Forms.Label();
            this.CmbFullTicker = new System.Windows.Forms.ComboBox();
            this.Lbl_txtAllocation = new System.Windows.Forms.Label();
            this.txtAllocation = new System.Windows.Forms.TextBox();
            this.CmdAllocCreate = new System.Windows.Forms.Button();
            this.CmdAllocUpdate = new System.Windows.Forms.Button();
            this.CmdAllocDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlloc)).BeginInit();
            this.SuspendLayout();
            //
            // MainMenu1
            //
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnAcctTypeRefSetup,
            this.MnAcctRefSetup,
            this.MnCurrencyGroup,
            this.MnActivaPassivaSetup,
            this.MnFinancialYearSetup,
            this.MnETFStockGroup,
            this.MnSuperGroup});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(700, 24);
            this.MainMenu1.TabIndex = 0;
            //
            // MnAcctTypeRefSetup
            //
            this.MnAcctTypeRefSetup.Name = "MnAcctTypeRefSetup";
            this.MnAcctTypeRefSetup.Size = new System.Drawing.Size(110, 20);
            this.MnAcctTypeRefSetup.Text = "Accounting &Type Ref Setup";
            this.MnAcctTypeRefSetup.Click += new System.EventHandler(this.MnAcctTypeRefSetup_Click);
            //
            // MnAcctRefSetup
            //
            this.MnAcctRefSetup.Name = "MnAcctRefSetup";
            this.MnAcctRefSetup.Size = new System.Drawing.Size(110, 20);
            this.MnAcctRefSetup.Text = "&Accounting Ref Setup";
            this.MnAcctRefSetup.Click += new System.EventHandler(this.MnAcctRefSetup_Click);
            //
            // MnCurrencyGroup
            //
            this.MnCurrencyGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnCurrSetup,
            this.MnCurrRateSetup});
            this.MnCurrencyGroup.Name = "MnCurrencyGroup";
            this.MnCurrencyGroup.Size = new System.Drawing.Size(150, 20);
            this.MnCurrencyGroup.Text = "&Currency";
            //
            // MnActivaPassivaSetup
            //
            this.MnActivaPassivaSetup.Name = "MnActivaPassivaSetup";
            this.MnActivaPassivaSetup.Size = new System.Drawing.Size(110, 20);
            this.MnActivaPassivaSetup.Text = "Asset &Liability Setup";
            this.MnActivaPassivaSetup.Click += new System.EventHandler(this.MnActivaPassivaSetup_Click);
            //
            // MnFinancialYearSetup
            //
            this.MnFinancialYearSetup.Name = "MnFinancialYearSetup";
            this.MnFinancialYearSetup.Size = new System.Drawing.Size(110, 20);
            this.MnFinancialYearSetup.Text = "&Financial Year Setup";
            this.MnFinancialYearSetup.Click += new System.EventHandler(this.MnFinancialYearSetup_Click);
            //
            // MnETFStockGroup
            //
            this.MnETFStockGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnETFStocksSuffixSetup,
            this.MnETFStocksSetup,
            this.MnETFStocksFlagSetup,
            this.MnETFStocksDivTypeSetup,
            this.MnETFStocksDivSetup,
            this.MnETFStocksDivAllocSetup});
            this.MnETFStockGroup.Name = "MnETFStockGroup";
            this.MnETFStockGroup.Size = new System.Drawing.Size(150, 20);
            this.MnETFStockGroup.Text = "&ETF/Stock";
            //
            // MnSuperGroup
            //
            this.MnSuperGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnSuperFundSetup,
            this.MnSuperSetup});
            this.MnSuperGroup.Name = "MnSuperGroup";
            this.MnSuperGroup.Size = new System.Drawing.Size(150, 20);
            this.MnSuperGroup.Text = "&Super";
            //
            // MnCurrSetup
            //
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(260, 22);
            this.MnCurrSetup.Text = "&Currency Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
            //
            // MnCurrRateSetup
            //
            this.MnCurrRateSetup.Name = "MnCurrRateSetup";
            this.MnCurrRateSetup.Size = new System.Drawing.Size(260, 22);
            this.MnCurrRateSetup.Text = "Currency &Rate Setup";
            this.MnCurrRateSetup.Click += new System.EventHandler(this.MnCurrRateSetup_Click);
            //
            // MnSuperFundSetup
            //
            this.MnSuperFundSetup.Name = "MnSuperFundSetup";
            this.MnSuperFundSetup.Size = new System.Drawing.Size(260, 22);
            this.MnSuperFundSetup.Text = "Super &Fund Setup";
            this.MnSuperFundSetup.Click += new System.EventHandler(this.MnSuperFundSetup_Click);
            //
            // MnSuperSetup
            //
            this.MnSuperSetup.Name = "MnSuperSetup";
            this.MnSuperSetup.Size = new System.Drawing.Size(260, 22);
            this.MnSuperSetup.Text = "Super Set&up";
            this.MnSuperSetup.Click += new System.EventHandler(this.MnSuperSetup_Click);
            //
            // MnETFStocksSuffixSetup
            //
            this.MnETFStocksSuffixSetup.Name = "MnETFStocksSuffixSetup";
            this.MnETFStocksSuffixSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksSuffixSetup.Text = "&ETF/Stock Suffix Setup";
            this.MnETFStocksSuffixSetup.Click += new System.EventHandler(this.MnETFStocksSuffixSetup_Click);
            //
            // MnETFStocksSetup
            //
            this.MnETFStocksSetup.Name = "MnETFStocksSetup";
            this.MnETFStocksSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksSetup.Text = "ETF/&Stock Setup";
            this.MnETFStocksSetup.Click += new System.EventHandler(this.MnETFStocksSetup_Click);
            //
            // MnETFStocksFlagSetup
            //
            this.MnETFStocksFlagSetup.Name = "MnETFStocksFlagSetup";
            this.MnETFStocksFlagSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksFlagSetup.Text = "ETF/Stock &Portfolio Code Setup";
            this.MnETFStocksFlagSetup.Click += new System.EventHandler(this.MnETFStocksFlagSetup_Click);
            //
            // MnETFStocksDivTypeSetup
            //
            this.MnETFStocksDivTypeSetup.Name = "MnETFStocksDivTypeSetup";
            this.MnETFStocksDivTypeSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksDivTypeSetup.Text = "ETF/Stock &Diversification Type Setup";
            this.MnETFStocksDivTypeSetup.Click += new System.EventHandler(this.MnETFStocksDivTypeSetup_Click);
            //
            // MnETFStocksDivSetup
            //
            this.MnETFStocksDivSetup.Name = "MnETFStocksDivSetup";
            this.MnETFStocksDivSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksDivSetup.Text = "ETF/Stock Di&versification Setup";
            this.MnETFStocksDivSetup.Click += new System.EventHandler(this.MnETFStocksDivSetup_Click);
            //
            // MnETFStocksDivAllocSetup
            //
            this.MnETFStocksDivAllocSetup.Name = "MnETFStocksDivAllocSetup";
            this.MnETFStocksDivAllocSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksDivAllocSetup.Text = "ETF/Stock Diversification &Allocation";
            this.MnETFStocksDivAllocSetup.Click += new System.EventHandler(this.MnETFStocksDivAllocSetup_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 30);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(660, 32);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK INVESTMENT PLAN SETUP";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 76);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(400, 20);
            this.LblNote.TabIndex = 2;
            //
            // gvPlan
            //
            this.gvPlan.AllowUserToAddRows = false;
            this.gvPlan.AllowUserToDeleteRows = false;
            this.gvPlan.AllowUserToResizeRows = false;
            this.gvPlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPlan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvPlan.Location = new System.Drawing.Point(19, 98);
            this.gvPlan.MultiSelect = false;
            this.gvPlan.Name = "gvPlan";
            this.gvPlan.ReadOnly = true;
            this.gvPlan.RowHeadersVisible = false;
            this.gvPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPlan.Size = new System.Drawing.Size(400, 120);
            this.gvPlan.TabIndex = 3;
            this.gvPlan.SelectionChanged += new System.EventHandler(this.gvPlan_SelectionChanged);
            //
            // Lbl_txtName
            //
            this.Lbl_txtName.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtName.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtName.Location = new System.Drawing.Point(19, 232);
            this.Lbl_txtName.Name = "Lbl_txtName";
            this.Lbl_txtName.Size = new System.Drawing.Size(60, 20);
            this.Lbl_txtName.TabIndex = 4;
            this.Lbl_txtName.Text = "Name";
            //
            // txtName
            //
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(85, 232);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(334, 20);
            this.txtName.TabIndex = 5;
            //
            // CmdCreate
            //
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.Location = new System.Drawing.Point(19, 262);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(95, 28);
            this.CmdCreate.TabIndex = 6;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.Location = new System.Drawing.Point(119, 262);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(95, 28);
            this.CmdUpdate.TabIndex = 7;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.Location = new System.Drawing.Point(219, 262);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(95, 28);
            this.CmdDel.TabIndex = 8;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // Lbl_CmbPlan
            //
            this.Lbl_CmbPlan.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbPlan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbPlan.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbPlan.Location = new System.Drawing.Point(19, 314);
            this.Lbl_CmbPlan.Name = "Lbl_CmbPlan";
            this.Lbl_CmbPlan.Size = new System.Drawing.Size(120, 20);
            this.Lbl_CmbPlan.TabIndex = 9;
            this.Lbl_CmbPlan.Text = "Investment Plan";
            //
            // CmbPlan
            //
            this.CmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPlan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPlan.FormattingEnabled = true;
            this.CmbPlan.Location = new System.Drawing.Point(145, 312);
            this.CmbPlan.Name = "CmbPlan";
            this.CmbPlan.Size = new System.Drawing.Size(300, 22);
            this.CmbPlan.TabIndex = 10;
            this.CmbPlan.SelectedIndexChanged += new System.EventHandler(this.CmbPlan_SelectedIndexChanged);
            //
            // LblNote2
            //
            this.LblNote2.BackColor = System.Drawing.Color.Transparent;
            this.LblNote2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote2.ForeColor = System.Drawing.Color.Black;
            this.LblNote2.Location = new System.Drawing.Point(19, 340);
            this.LblNote2.Name = "LblNote2";
            this.LblNote2.Size = new System.Drawing.Size(640, 20);
            this.LblNote2.TabIndex = 11;
            //
            // gvAlloc
            //
            this.gvAlloc.AllowUserToAddRows = false;
            this.gvAlloc.AllowUserToDeleteRows = false;
            this.gvAlloc.AllowUserToResizeRows = false;
            this.gvAlloc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAlloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAlloc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAlloc.Location = new System.Drawing.Point(19, 362);
            this.gvAlloc.MultiSelect = false;
            this.gvAlloc.Name = "gvAlloc";
            this.gvAlloc.ReadOnly = true;
            this.gvAlloc.RowHeadersVisible = false;
            this.gvAlloc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAlloc.Size = new System.Drawing.Size(640, 130);
            this.gvAlloc.TabIndex = 12;
            this.gvAlloc.SelectionChanged += new System.EventHandler(this.gvAlloc_SelectionChanged);
            //
            // Lbl_LblTotal
            //
            this.Lbl_LblTotal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotal.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotal.Location = new System.Drawing.Point(19, 500);
            this.Lbl_LblTotal.Name = "Lbl_LblTotal";
            this.Lbl_LblTotal.Size = new System.Drawing.Size(130, 20);
            this.Lbl_LblTotal.TabIndex = 13;
            this.Lbl_LblTotal.Text = "Total Percentage";
            //
            // LblTotal
            //
            this.LblTotal.BackColor = System.Drawing.Color.Transparent;
            this.LblTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.ForeColor = System.Drawing.Color.Black;
            this.LblTotal.Location = new System.Drawing.Point(155, 500);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(120, 20);
            this.LblTotal.TabIndex = 14;
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_CmbAllocPlan
            //
            this.Lbl_CmbAllocPlan.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbAllocPlan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbAllocPlan.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbAllocPlan.Location = new System.Drawing.Point(19, 532);
            this.Lbl_CmbAllocPlan.Name = "Lbl_CmbAllocPlan";
            this.Lbl_CmbAllocPlan.Size = new System.Drawing.Size(120, 20);
            this.Lbl_CmbAllocPlan.TabIndex = 15;
            this.Lbl_CmbAllocPlan.Text = "Investment Plan";
            //
            // CmbAllocPlan
            //
            this.CmbAllocPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAllocPlan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAllocPlan.FormattingEnabled = true;
            this.CmbAllocPlan.Location = new System.Drawing.Point(145, 530);
            this.CmbAllocPlan.Name = "CmbAllocPlan";
            this.CmbAllocPlan.Size = new System.Drawing.Size(300, 22);
            this.CmbAllocPlan.TabIndex = 16;
            //
            // Lbl_CmbFullTicker
            //
            this.Lbl_CmbFullTicker.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbFullTicker.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbFullTicker.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbFullTicker.Location = new System.Drawing.Point(19, 560);
            this.Lbl_CmbFullTicker.Name = "Lbl_CmbFullTicker";
            this.Lbl_CmbFullTicker.Size = new System.Drawing.Size(120, 20);
            this.Lbl_CmbFullTicker.TabIndex = 17;
            this.Lbl_CmbFullTicker.Text = "Full Ticker";
            //
            // CmbFullTicker
            //
            this.CmbFullTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFullTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFullTicker.FormattingEnabled = true;
            this.CmbFullTicker.Location = new System.Drawing.Point(145, 558);
            this.CmbFullTicker.Name = "CmbFullTicker";
            this.CmbFullTicker.Size = new System.Drawing.Size(300, 22);
            this.CmbFullTicker.TabIndex = 18;
            //
            // Lbl_txtAllocation
            //
            this.Lbl_txtAllocation.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtAllocation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtAllocation.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtAllocation.Location = new System.Drawing.Point(19, 588);
            this.Lbl_txtAllocation.Name = "Lbl_txtAllocation";
            this.Lbl_txtAllocation.Size = new System.Drawing.Size(120, 20);
            this.Lbl_txtAllocation.TabIndex = 19;
            this.Lbl_txtAllocation.Text = "Allocation";
            //
            // txtAllocation
            //
            this.txtAllocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtAllocation.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAllocation.Location = new System.Drawing.Point(145, 588);
            this.txtAllocation.MaxLength = 20;
            this.txtAllocation.Name = "txtAllocation";
            this.txtAllocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAllocation.Size = new System.Drawing.Size(150, 20);
            this.txtAllocation.TabIndex = 20;
            this.txtAllocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAllocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            //
            // CmdAllocCreate
            //
            this.CmdAllocCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAllocCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAllocCreate.Location = new System.Drawing.Point(19, 618);
            this.CmdAllocCreate.Name = "CmdAllocCreate";
            this.CmdAllocCreate.Size = new System.Drawing.Size(95, 28);
            this.CmdAllocCreate.TabIndex = 21;
            this.CmdAllocCreate.Text = "A&dd";
            this.CmdAllocCreate.UseVisualStyleBackColor = false;
            this.CmdAllocCreate.Click += new System.EventHandler(this.CmdAllocCreate_Click);
            //
            // CmdAllocUpdate
            //
            this.CmdAllocUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAllocUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAllocUpdate.Location = new System.Drawing.Point(119, 618);
            this.CmdAllocUpdate.Name = "CmdAllocUpdate";
            this.CmdAllocUpdate.Size = new System.Drawing.Size(95, 28);
            this.CmdAllocUpdate.TabIndex = 22;
            this.CmdAllocUpdate.Text = "Up&date";
            this.CmdAllocUpdate.UseVisualStyleBackColor = false;
            this.CmdAllocUpdate.Click += new System.EventHandler(this.CmdAllocUpdate_Click);
            //
            // CmdAllocDel
            //
            this.CmdAllocDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAllocDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAllocDel.Location = new System.Drawing.Point(219, 618);
            this.CmdAllocDel.Name = "CmdAllocDel";
            this.CmdAllocDel.Size = new System.Drawing.Size(95, 28);
            this.CmdAllocDel.TabIndex = 23;
            this.CmdAllocDel.Text = "De&lete";
            this.CmdAllocDel.UseVisualStyleBackColor = false;
            this.CmdAllocDel.Click += new System.EventHandler(this.CmdAllocDel_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(549, 618);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 24;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Setup_ETF_Stocks_Investment_Plan
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(700, 680);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdAllocDel);
            this.Controls.Add(this.CmdAllocUpdate);
            this.Controls.Add(this.CmdAllocCreate);
            this.Controls.Add(this.txtAllocation);
            this.Controls.Add(this.Lbl_txtAllocation);
            this.Controls.Add(this.CmbFullTicker);
            this.Controls.Add(this.Lbl_CmbFullTicker);
            this.Controls.Add(this.CmbAllocPlan);
            this.Controls.Add(this.Lbl_CmbAllocPlan);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.Lbl_LblTotal);
            this.Controls.Add(this.gvAlloc);
            this.Controls.Add(this.LblNote2);
            this.Controls.Add(this.CmbPlan);
            this.Controls.Add(this.Lbl_CmbPlan);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Lbl_txtName);
            this.Controls.Add(this.gvPlan);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_ETF_Stocks_Investment_Plan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Investment Plan Setup";
            this.Load += new System.EventHandler(this.Setup_ETF_Stocks_Investment_Plan_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlloc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnAcctTypeRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnAcctRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrencyGroup;
        public System.Windows.Forms.ToolStripMenuItem MnActivaPassivaSetup;
        public System.Windows.Forms.ToolStripMenuItem MnFinancialYearSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockGroup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperGroup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrRateSetup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperFundSetup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFlagSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivAllocSetup;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvPlan;
        public System.Windows.Forms.Label Lbl_txtName;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Label Lbl_CmbPlan;
        public System.Windows.Forms.ComboBox CmbPlan;
        public System.Windows.Forms.Label LblNote2;
        private System.Windows.Forms.DataGridView gvAlloc;
        public System.Windows.Forms.Label Lbl_LblTotal;
        public System.Windows.Forms.Label LblTotal;
        public System.Windows.Forms.Label Lbl_CmbAllocPlan;
        public System.Windows.Forms.ComboBox CmbAllocPlan;
        public System.Windows.Forms.Label Lbl_CmbFullTicker;
        public System.Windows.Forms.ComboBox CmbFullTicker;
        public System.Windows.Forms.Label Lbl_txtAllocation;
        public System.Windows.Forms.TextBox txtAllocation;
        public System.Windows.Forms.Button CmdAllocCreate;
        public System.Windows.Forms.Button CmdAllocUpdate;
        public System.Windows.Forms.Button CmdAllocDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
