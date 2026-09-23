namespace FinancialBalance
{
    partial class Setup_Interval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Interval));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrencyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrRateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnActivaPassivaSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnFinancialYearSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFlagSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivAllocSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvPlanSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnTaxGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnTaxAllocationSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnStateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyRentalExpTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperFundSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.gvInterval = new System.Windows.Forms.DataGridView();
            this.Lbl_Type_Name = new System.Windows.Forms.Label();
            this.Interval_Name = new System.Windows.Forms.TextBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInterval)).BeginInit();
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
            this.MnPropertyGroup,
            this.MnTaxGroup,
            this.MnSuperGroup});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(616, 24);
            this.MainMenu1.TabIndex = 1;
            // 
            // MnAcctTypeRefSetup
            // 
            this.MnAcctTypeRefSetup.Name = "MnAcctTypeRefSetup";
            this.MnAcctTypeRefSetup.Size = new System.Drawing.Size(150, 20);
            this.MnAcctTypeRefSetup.Text = "Accounting &Type Ref Setup";
            this.MnAcctTypeRefSetup.Click += new System.EventHandler(this.MnAcctTypeRefSetup_Click);
            // 
            // MnAcctRefSetup
            // 
            this.MnAcctRefSetup.Name = "MnAcctRefSetup";
            this.MnAcctRefSetup.Size = new System.Drawing.Size(150, 20);
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
            // MnCurrSetup
            // 
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(216, 22);
            this.MnCurrSetup.Text = "&Currency Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
            // 
            // MnCurrRateSetup
            // 
            this.MnCurrRateSetup.Name = "MnCurrRateSetup";
            this.MnCurrRateSetup.Size = new System.Drawing.Size(216, 22);
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
            // MnETFStocksSuffixSetup
            // 
            this.MnETFStocksSuffixSetup.Name = "MnETFStocksSuffixSetup";
            this.MnETFStocksSuffixSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksSuffixSetup.Text = "&ETF/Stock Suffix Setup";
            this.MnETFStocksSuffixSetup.Click += new System.EventHandler(this.MnETFStocksSuffixSetup_Click);
            // 
            // MnETFStocksSetup
            // 
            this.MnETFStocksSetup.Name = "MnETFStocksSetup";
            this.MnETFStocksSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksSetup.Text = "ETF/&Stock Setup";
            this.MnETFStocksSetup.Click += new System.EventHandler(this.MnETFStocksSetup_Click);
            // 
            // MnETFStocksFlagSetup
            // 
            this.MnETFStocksFlagSetup.Name = "MnETFStocksFlagSetup";
            this.MnETFStocksFlagSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksFlagSetup.Text = "ETF/Stock &Portfolio Code Setup";
            this.MnETFStocksFlagSetup.Click += new System.EventHandler(this.MnETFStocksFlagSetup_Click);
            // 
            // MnETFStocksDivTypeSetup
            // 
            this.MnETFStocksDivTypeSetup.Name = "MnETFStocksDivTypeSetup";
            this.MnETFStocksDivTypeSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksDivTypeSetup.Text = "ETF/Stock &Diversification Type Setup";
            this.MnETFStocksDivTypeSetup.Click += new System.EventHandler(this.MnETFStocksDivTypeSetup_Click);
            // 
            // MnETFStocksDivSetup
            // 
            this.MnETFStocksDivSetup.Name = "MnETFStocksDivSetup";
            this.MnETFStocksDivSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksDivSetup.Text = "ETF/Stock Di&versification Setup";
            this.MnETFStocksDivSetup.Click += new System.EventHandler(this.MnETFStocksDivSetup_Click);
            // 
            // MnETFStocksDivAllocSetup
            // 
            this.MnETFStocksDivAllocSetup.Name = "MnETFStocksDivAllocSetup";
            this.MnETFStocksDivAllocSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksDivAllocSetup.Text = "ETF/Stock Diversification &Allocation";
            this.MnETFStocksDivAllocSetup.Click += new System.EventHandler(this.MnETFStocksDivAllocSetup_Click);
            // 
            // MnETFStocksInvPlanSetup
            // 
            this.MnETFStocksInvPlanSetup.Name = "MnETFStocksInvPlanSetup";
            this.MnETFStocksInvPlanSetup.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksInvPlanSetup.Text = "ETF/Stock &Investment Plan Setup";
            this.MnETFStocksInvPlanSetup.Click += new System.EventHandler(this.MnETFStocksInvPlanSetup_Click);
            // 
            // MnPropertyGroup
            // 
            this.MnPropertyGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnStateSetup,
            this.MnPropertyRentalExpTypeSetup});
            this.MnPropertyGroup.Name = "MnPropertyGroup";
            this.MnPropertyGroup.Size = new System.Drawing.Size(75, 20);
            this.MnPropertyGroup.Text = "&Property";
            // 
            // MnTaxGroup
            // 
            this.MnTaxGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnTaxAllocationSetup});
            this.MnTaxGroup.Name = "MnTaxGroup";
            this.MnTaxGroup.Size = new System.Drawing.Size(75, 20);
            this.MnTaxGroup.Text = "Ta&x";
            // 
            // MnTaxAllocationSetup
            // 
            this.MnTaxAllocationSetup.Name = "MnTaxAllocationSetup";
            this.MnTaxAllocationSetup.Size = new System.Drawing.Size(216, 22);
            this.MnTaxAllocationSetup.Text = "Tax &Allocation Setup";
            this.MnTaxAllocationSetup.Click += new System.EventHandler(this.MnTaxAllocationSetup_Click);
            // 
            // MnStateSetup
            // 
            this.MnStateSetup.Name = "MnStateSetup";
            this.MnStateSetup.Size = new System.Drawing.Size(216, 22);
            this.MnStateSetup.Text = "&State Setup";
            this.MnStateSetup.Click += new System.EventHandler(this.MnStateSetup_Click);
            // 
            // MnPropertyRentalExpTypeSetup
            // 
            this.MnPropertyRentalExpTypeSetup.Name = "MnPropertyRentalExpTypeSetup";
            this.MnPropertyRentalExpTypeSetup.Size = new System.Drawing.Size(216, 22);
            this.MnPropertyRentalExpTypeSetup.Text = "Property Rental &Expense Type Setup";
            this.MnPropertyRentalExpTypeSetup.Click += new System.EventHandler(this.MnPropertyRentalExpTypeSetup_Click);
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
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(19, 27);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(557, 38);
            this.Label21.TabIndex = 2;
            this.Label21.Text = "INTERVAL SETUP";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label21.UseMnemonic = false;
            // 
            // gvInterval
            // 
            this.gvInterval.AllowUserToAddRows = false;
            this.gvInterval.AllowUserToDeleteRows = false;
            this.gvInterval.AllowUserToResizeRows = false;
            this.gvInterval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvInterval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvInterval.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvInterval.Location = new System.Drawing.Point(19, 71);
            this.gvInterval.MultiSelect = false;
            this.gvInterval.Name = "gvInterval";
            this.gvInterval.ReadOnly = true;
            this.gvInterval.RowHeadersVisible = false;
            this.gvInterval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvInterval.Size = new System.Drawing.Size(557, 190);
            this.gvInterval.TabIndex = 3;
            this.gvInterval.SelectionChanged += new System.EventHandler(this.gvType_SelectionChanged);
            // 
            // Lbl_Type_Name
            // 
            this.Lbl_Type_Name.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_Type_Name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Type_Name.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Type_Name.Location = new System.Drawing.Point(19, 272);
            this.Lbl_Type_Name.Name = "Lbl_Type_Name";
            this.Lbl_Type_Name.Size = new System.Drawing.Size(100, 22);
            this.Lbl_Type_Name.TabIndex = 4;
            this.Lbl_Type_Name.Text = "Name";
            this.Lbl_Type_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Interval_Name
            // 
            this.Interval_Name.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Interval_Name.Location = new System.Drawing.Point(128, 270);
            this.Interval_Name.MaxLength = 50;
            this.Interval_Name.Name = "Interval_Name";
            this.Interval_Name.Size = new System.Drawing.Size(300, 20);
            this.Interval_Name.TabIndex = 5;
            // 
            // LblNote
            // 
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 298);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(557, 22);
            this.LblNote.TabIndex = 6;
            this.LblNote.UseMnemonic = false;
            // 
            // CmdCreate
            // 
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.Location = new System.Drawing.Point(216, 326);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(85, 28);
            this.CmdCreate.TabIndex = 7;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            // 
            // CmdUpdate
            // 
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.Location = new System.Drawing.Point(311, 326);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(85, 28);
            this.CmdUpdate.TabIndex = 8;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            // 
            // CmdDel
            // 
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.Location = new System.Drawing.Point(406, 326);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 28);
            this.CmdDel.TabIndex = 9;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            // 
            // CmdBack
            // 
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(501, 326);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 28);
            this.CmdBack.TabIndex = 10;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // Setup_Interval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(616, 372);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.Interval_Name);
            this.Controls.Add(this.Lbl_Type_Name);
            this.Controls.Add(this.gvInterval);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_Interval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interval Setup";
            this.Load += new System.EventHandler(this.Setup_Interval_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInterval)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFlagSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivAllocSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvPlanSetup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyGroup;
        public System.Windows.Forms.ToolStripMenuItem MnTaxGroup;
        public System.Windows.Forms.ToolStripMenuItem MnTaxAllocationSetup;
        public System.Windows.Forms.ToolStripMenuItem MnStateSetup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyRentalExpTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperGroup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperFundSetup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperSetup;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.DataGridView gvInterval;
        public System.Windows.Forms.Label Lbl_Type_Name;
        public System.Windows.Forms.TextBox Interval_Name;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
