namespace FinancialBalance
{
    partial class Setup_Super_Fund
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Super_Fund));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrencyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrRateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnActivaPassivaSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnFinancialYearSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvPlanSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFlagSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivAllocSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.gvFund = new System.Windows.Forms.DataGridView();
            this.Lbl_txtName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFund)).BeginInit();
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
            this.MainMenu1.Size = new System.Drawing.Size(640, 24);
            this.MainMenu1.TabIndex = 0;
            //
            // MnAcctTypeRefSetup
            //
            this.MnAcctTypeRefSetup.Name = "MnAcctTypeRefSetup";
            this.MnAcctTypeRefSetup.Size = new System.Drawing.Size(150, 20);
            this.MnAcctTypeRefSetup.Text = "&Accounting Type Ref Setup";
            this.MnAcctTypeRefSetup.Click += new System.EventHandler(this.MnAcctTypeRefSetup_Click);
            //
            // MnAcctRefSetup
            //
            this.MnAcctRefSetup.Name = "MnAcctRefSetup";
            this.MnAcctRefSetup.Size = new System.Drawing.Size(150, 20);
            this.MnAcctRefSetup.Text = "Accounting &Ref Setup";
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
            // MnCurrSetup
            //
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(260, 22);
            this.MnCurrSetup.Text = "Currency &Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
            //
            // MnCurrRateSetup
            //
            this.MnCurrRateSetup.Name = "MnCurrRateSetup";
            this.MnCurrRateSetup.Size = new System.Drawing.Size(260, 22);
            this.MnCurrRateSetup.Text = "Currency &Rate Setup";
            this.MnCurrRateSetup.Click += new System.EventHandler(this.MnCurrRateSetup_Click);
            //
            // MnActivaPassivaSetup
            //
            this.MnActivaPassivaSetup.Name = "MnActivaPassivaSetup";
            this.MnActivaPassivaSetup.Size = new System.Drawing.Size(150, 20);
            this.MnActivaPassivaSetup.Text = "Asset &Liability Setup";
            this.MnActivaPassivaSetup.Click += new System.EventHandler(this.MnActivaPassivaSetup_Click);
            //
            // MnFinancialYearSetup
            //
            this.MnFinancialYearSetup.Name = "MnFinancialYearSetup";
            this.MnFinancialYearSetup.Size = new System.Drawing.Size(150, 20);
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
            this.MnETFStocksDivAllocSetup,
            this.MnETFStocksInvPlanSetup});
            this.MnETFStockGroup.Name = "MnETFStockGroup";
            this.MnETFStockGroup.Size = new System.Drawing.Size(150, 20);
            this.MnETFStockGroup.Text = "&ETF/Stock";
            // 
            // MnETFStocksInvPlanSetup
            // 
            this.MnETFStocksInvPlanSetup.Name = "MnETFStocksInvPlanSetup";
            this.MnETFStocksInvPlanSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksInvPlanSetup.Text = "ETF/Stock &Investment Plan Setup";
            this.MnETFStocksInvPlanSetup.Click += new System.EventHandler(this.MnETFStocksInvPlanSetup_Click);
            //
            // MnETFStocksSuffixSetup
            //
            this.MnETFStocksSuffixSetup.Name = "MnETFStocksSuffixSetup";
            this.MnETFStocksSuffixSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksSuffixSetup.Text = "ETF/Stock S&uffix Setup";
            this.MnETFStocksSuffixSetup.Click += new System.EventHandler(this.MnETFStocksSuffixSetup_Click);
            //
            // MnETFStocksSetup
            //
            this.MnETFStocksSetup.Name = "MnETFStocksSetup";
            this.MnETFStocksSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksSetup.Text = "ETF/Stock Set&up";
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
            this.MnETFStocksDivTypeSetup.Text = "ETF/Stock Diversification &Type Setup";
            this.MnETFStocksDivTypeSetup.Click += new System.EventHandler(this.MnETFStocksDivTypeSetup_Click);
            //
            // MnETFStocksDivSetup
            //
            this.MnETFStocksDivSetup.Name = "MnETFStocksDivSetup";
            this.MnETFStocksDivSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksDivSetup.Text = "ETF/Stock &Diversification Setup";
            this.MnETFStocksDivSetup.Click += new System.EventHandler(this.MnETFStocksDivSetup_Click);
            //
            // MnETFStocksDivAllocSetup
            //
            this.MnETFStocksDivAllocSetup.Name = "MnETFStocksDivAllocSetup";
            this.MnETFStocksDivAllocSetup.Size = new System.Drawing.Size(260, 22);
            this.MnETFStocksDivAllocSetup.Text = "ETF/Stock Diversification &Allocation";
            this.MnETFStocksDivAllocSetup.Click += new System.EventHandler(this.MnETFStocksDivAllocSetup_Click);
            //
            // MnSuperGroup
            //
            this.MnSuperGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnSuperSetup});
            this.MnSuperGroup.Name = "MnSuperGroup";
            this.MnSuperGroup.Size = new System.Drawing.Size(150, 20);
            this.MnSuperGroup.Text = "&Super";
            //
            // MnSuperSetup
            //
            this.MnSuperSetup.Name = "MnSuperSetup";
            this.MnSuperSetup.Size = new System.Drawing.Size(260, 22);
            this.MnSuperSetup.Text = "Super Set&up";
            this.MnSuperSetup.Click += new System.EventHandler(this.MnSuperSetup_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(19, 30);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(602, 38);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "SUPER FUND SETUP";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // gvFund
            //
            this.gvFund.AllowUserToAddRows = false;
            this.gvFund.AllowUserToDeleteRows = false;
            this.gvFund.AllowUserToResizeRows = false;
            this.gvFund.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvFund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFund.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvFund.Location = new System.Drawing.Point(19, 80);
            this.gvFund.MultiSelect = false;
            this.gvFund.Name = "gvFund";
            this.gvFund.ReadOnly = true;
            this.gvFund.RowHeadersVisible = false;
            this.gvFund.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFund.Size = new System.Drawing.Size(600, 220);
            this.gvFund.TabIndex = 2;
            this.gvFund.SelectionChanged += new System.EventHandler(this.gvFund_SelectionChanged);
            //
            // Lbl_txtName
            //
            this.Lbl_txtName.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtName.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtName.Location = new System.Drawing.Point(19, 322);
            this.Lbl_txtName.Name = "Lbl_txtName";
            this.Lbl_txtName.Size = new System.Drawing.Size(150, 20);
            this.Lbl_txtName.TabIndex = 3;
            this.Lbl_txtName.Text = "Name";
            //
            // txtName
            //
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(179, 320);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(400, 20);
            this.txtName.TabIndex = 4;
            //
            // CmdCreate
            //
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.Location = new System.Drawing.Point(240, 378);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(85, 28);
            this.CmdCreate.TabIndex = 5;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.Location = new System.Drawing.Point(335, 378);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(85, 28);
            this.CmdUpdate.TabIndex = 6;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.Location = new System.Drawing.Point(430, 378);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 28);
            this.CmdDel.TabIndex = 7;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(525, 378);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 28);
            this.CmdBack.TabIndex = 8;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Setup_Super_Fund
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(640, 420);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Lbl_txtName);
            this.Controls.Add(this.gvFund);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_Super_Fund";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Fund Setup";
            this.Load += new System.EventHandler(this.Setup_Super_Fund_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFund)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnAcctTypeRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnAcctRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrencyGroup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrRateSetup;
        public System.Windows.Forms.ToolStripMenuItem MnActivaPassivaSetup;
        public System.Windows.Forms.ToolStripMenuItem MnFinancialYearSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvPlanSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFlagSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivAllocSetup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperGroup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperSetup;
        public System.Windows.Forms.Label Label21;
        private System.Windows.Forms.DataGridView gvFund;
        public System.Windows.Forms.Label Lbl_txtName;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
