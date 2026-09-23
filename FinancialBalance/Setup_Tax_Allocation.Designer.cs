namespace FinancialBalance
{
    partial class Setup_Tax_Allocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Tax_Allocation));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrencyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrRateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnActivaPassivaSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnFinancialYearSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnIntervalSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFlagSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivAllocSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvPlanSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnStateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnPropertyRentalExpTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperFundSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSuperSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.Lbl_LblTotal = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Tax_Rate = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Allocation = new System.Windows.Forms.TextBox();
            this.gvTaxAlloc = new System.Windows.Forms.DataGridView();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaxAlloc)).BeginInit();
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
            this.MnIntervalSetup,
            this.MnETFStockGroup,
            this.MnPropertyGroup,
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
            // MnIntervalSetup
            // 
            this.MnIntervalSetup.Name = "MnIntervalSetup";
            this.MnIntervalSetup.Size = new System.Drawing.Size(110, 20);
            this.MnIntervalSetup.Text = "&Interval Setup";
            this.MnIntervalSetup.Click += new System.EventHandler(this.MnIntervalSetup_Click);
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
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(19, 27);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(578, 44);
            this.Label21.TabIndex = 2;
            this.Label21.Text = "TAX ALLOCATION SETUP";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_LblTotal
            // 
            this.Lbl_LblTotal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotal.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotal.Location = new System.Drawing.Point(16, 322);
            this.Lbl_LblTotal.Name = "Lbl_LblTotal";
            this.Lbl_LblTotal.Size = new System.Drawing.Size(110, 25);
            this.Lbl_LblTotal.TabIndex = 30;
            this.Lbl_LblTotal.Text = "Total Allocation";
            // 
            // LblTotal
            // 
            this.LblTotal.BackColor = System.Drawing.Color.Transparent;
            this.LblTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.ForeColor = System.Drawing.Color.Black;
            this.LblTotal.Location = new System.Drawing.Point(136, 322);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(420, 25);
            this.LblTotal.TabIndex = 31;
            this.LblTotal.Text = "0.00 %";
            // 
            // CmdCreate
            // 
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(216, 354);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdCreate.Size = new System.Drawing.Size(85, 28);
            this.CmdCreate.TabIndex = 3;
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
            this.CmdUpdate.Location = new System.Drawing.Point(311, 354);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdUpdate.Size = new System.Drawing.Size(85, 28);
            this.CmdUpdate.TabIndex = 4;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            // 
            // CmdDel
            // 
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(406, 354);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(85, 28);
            this.CmdDel.TabIndex = 5;
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
            this.CmdBack.Location = new System.Drawing.Point(501, 354);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(85, 28);
            this.CmdBack.TabIndex = 6;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(16, 270);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(110, 24);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Tax Rate";
            // 
            // Tax_Rate
            // 
            this.Tax_Rate.AcceptsReturn = true;
            this.Tax_Rate.BackColor = System.Drawing.SystemColors.Window;
            this.Tax_Rate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Tax_Rate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tax_Rate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Tax_Rate.Location = new System.Drawing.Point(136, 270);
            this.Tax_Rate.MaxLength = 3;
            this.Tax_Rate.Name = "Tax_Rate";
            this.Tax_Rate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tax_Rate.Size = new System.Drawing.Size(100, 20);
            this.Tax_Rate.TabIndex = 8;
            this.Tax_Rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tax_Rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(16, 294);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(110, 25);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Allocation";
            // 
            // Allocation
            // 
            this.Allocation.AcceptsReturn = true;
            this.Allocation.BackColor = System.Drawing.SystemColors.Window;
            this.Allocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Allocation.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Allocation.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Allocation.Location = new System.Drawing.Point(136, 294);
            this.Allocation.MaxLength = 50;
            this.Allocation.Name = "Allocation";
            this.Allocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Allocation.Size = new System.Drawing.Size(100, 20);
            this.Allocation.TabIndex = 10;
            this.Allocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Allocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // gvTaxAlloc
            // 
            this.gvTaxAlloc.AllowUserToAddRows = false;
            this.gvTaxAlloc.AllowUserToDeleteRows = false;
            this.gvTaxAlloc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTaxAlloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTaxAlloc.Location = new System.Drawing.Point(19, 71);
            this.gvTaxAlloc.MultiSelect = false;
            this.gvTaxAlloc.Name = "gvTaxAlloc";
            this.gvTaxAlloc.ReadOnly = true;
            this.gvTaxAlloc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTaxAlloc.Size = new System.Drawing.Size(557, 190);
            this.gvTaxAlloc.TabIndex = 11;
            this.gvTaxAlloc.SelectionChanged += new System.EventHandler(this.gvTaxAlloc_SelectionChanged);
            //
            // Setup_Tax_Allocation
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(616, 400);
            this.ControlBox = false;
            this.Controls.Add(this.gvTaxAlloc);
            this.Controls.Add(this.Allocation);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Tax_Rate);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.Lbl_LblTotal);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_Tax_Allocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax Allocation Setup";
            this.Load += new System.EventHandler(this.Setup_Tax_Allocation_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaxAlloc)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnIntervalSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFlagSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivAllocSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvPlanSetup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyGroup;
        public System.Windows.Forms.ToolStripMenuItem MnStateSetup;
        public System.Windows.Forms.ToolStripMenuItem MnPropertyRentalExpTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperGroup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperFundSetup;
        public System.Windows.Forms.ToolStripMenuItem MnSuperSetup;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Lbl_LblTotal;
        public System.Windows.Forms.Label LblTotal;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox Tax_Rate;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox Allocation;
        private System.Windows.Forms.DataGridView gvTaxAlloc;
    }
}
