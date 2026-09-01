namespace FinancialBalance
{
    partial class Setup_ETF_Stocks_Div_Type
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_ETF_Stocks_Div_Type));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrencyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrRateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnActivaPassivaSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFlagSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivAllocSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.CmdSetup = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Div_Type_Name = new System.Windows.Forms.TextBox();
            this.gvDivType = new System.Windows.Forms.DataGridView();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDivType)).BeginInit();
            this.SuspendLayout();
            //
            // MainMenu1
            //
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnAcctTypeRefSetup,
            this.MnAcctRefSetup,
            this.MnCurrencyGroup,
            this.MnActivaPassivaSetup,
            this.MnETFStockGroup});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(616, 24);
            this.MainMenu1.TabIndex = 9;
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
            this.MnAcctRefSetup.Size = new System.Drawing.Size(123, 20);
            this.MnAcctRefSetup.Text = "&Accounting Ref Setup";
            this.MnAcctRefSetup.Click += new System.EventHandler(this.MnAcctRefSetup_Click);
            //
            // MnCurrencyGroup
            //
            this.MnCurrencyGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnCurrSetup,
            this.MnCurrRateSetup});
            this.MnCurrencyGroup.Name = "MnCurrencyGroup";
            this.MnCurrencyGroup.Size = new System.Drawing.Size(75, 20);
            this.MnCurrencyGroup.Text = "&Currency";
            //
            // MnCurrSetup
            //
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(93, 20);
            this.MnCurrSetup.Text = "&Currency Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
            //
            // MnCurrRateSetup
            //
            this.MnCurrRateSetup.Name = "MnCurrRateSetup";
            this.MnCurrRateSetup.Size = new System.Drawing.Size(120, 20);
            this.MnCurrRateSetup.Text = "Currency &Rate Setup";
            this.MnCurrRateSetup.Click += new System.EventHandler(this.MnCurrRateSetup_Click);
            //
            // MnActivaPassivaSetup
            //
            this.MnActivaPassivaSetup.Name = "MnActivaPassivaSetup";
            this.MnActivaPassivaSetup.Size = new System.Drawing.Size(119, 20);
            this.MnActivaPassivaSetup.Text = "Asset &Liability Setup";
            this.MnActivaPassivaSetup.Click += new System.EventHandler(this.MnActivaPassivaSetup_Click);
            //
            // MnETFStockGroup
            //
            this.MnETFStockGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnETFStocksSuffixSetup,
            this.MnETFStocksSetup,
            this.MnETFStocksFlagSetup,
            this.MnETFStocksDivSetup,
            this.MnETFStocksDivAllocSetup});
            this.MnETFStockGroup.Name = "MnETFStockGroup";
            this.MnETFStockGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockGroup.Text = "&ETF/Stock";
            //
            // MnETFStocksSuffixSetup
            //
            this.MnETFStocksSuffixSetup.Name = "MnETFStocksSuffixSetup";
            this.MnETFStocksSuffixSetup.Size = new System.Drawing.Size(140, 20);
            this.MnETFStocksSuffixSetup.Text = "&ETF/Stock Suffix Setup";
            this.MnETFStocksSuffixSetup.Click += new System.EventHandler(this.MnETFStocksSuffixSetup_Click);
            //
            // MnETFStocksSetup
            //
            this.MnETFStocksSetup.Name = "MnETFStocksSetup";
            this.MnETFStocksSetup.Size = new System.Drawing.Size(115, 20);
            this.MnETFStocksSetup.Text = "ETF/&Stock Setup";
            this.MnETFStocksSetup.Click += new System.EventHandler(this.MnETFStocksSetup_Click);
            //
            // MnETFStocksFlagSetup
            //
            this.MnETFStocksFlagSetup.Name = "MnETFStocksFlagSetup";
            this.MnETFStocksFlagSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksFlagSetup.Text = "ETF/Stock &Portfolio Code Setup";
            this.MnETFStocksFlagSetup.Click += new System.EventHandler(this.MnETFStocksFlagSetup_Click);
            //
            // MnETFStocksDivSetup
            //
            this.MnETFStocksDivSetup.Name = "MnETFStocksDivSetup";
            this.MnETFStocksDivSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksDivSetup.Text = "ETF/Stock Di&versification Setup";
            this.MnETFStocksDivSetup.Click += new System.EventHandler(this.MnETFStocksDivSetup_Click);
            // 
            // MnETFStocksDivAllocSetup
            // 
            this.MnETFStocksDivAllocSetup.Name = "MnETFStocksDivAllocSetup";
            this.MnETFStocksDivAllocSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksDivAllocSetup.Text = "ETF/Stock Diversification &Allocation";
            this.MnETFStocksDivAllocSetup.Click += new System.EventHandler(this.MnETFStocksDivAllocSetup_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 30);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(576, 41);
            this.Label21.TabIndex = 10;
            this.Label21.Text = "ETF/STOCK DIVERSIFICATION TYPE SETUP";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // CmdSetup
            //
            this.CmdSetup.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSetup.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdSetup.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSetup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSetup.Location = new System.Drawing.Point(144, 320);
            this.CmdSetup.Name = "CmdSetup";
            this.CmdSetup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdSetup.Size = new System.Drawing.Size(73, 25);
            this.CmdSetup.TabIndex = 12;
            this.CmdSetup.Text = "&Setup";
            this.CmdSetup.UseVisualStyleBackColor = false;
            this.CmdSetup.Click += new System.EventHandler(this.CmdSetup_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(232, 320);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(73, 25);
            this.CmdDel.TabIndex = 13;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdBack
            //
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(320, 320);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 27);
            this.CmdBack.TabIndex = 14;
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
            this.Label1.Location = new System.Drawing.Point(16, 274);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(106, 25);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Name";
            //
            // Div_Type_Name
            //
            this.Div_Type_Name.AcceptsReturn = true;
            this.Div_Type_Name.BackColor = System.Drawing.SystemColors.Window;
            this.Div_Type_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Div_Type_Name.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Div_Type_Name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Div_Type_Name.Location = new System.Drawing.Point(128, 274);
            this.Div_Type_Name.MaxLength = 50;
            this.Div_Type_Name.Name = "Div_Type_Name";
            this.Div_Type_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Div_Type_Name.Size = new System.Drawing.Size(320, 20);
            this.Div_Type_Name.TabIndex = 11;
            //
            // gvDivType
            //
            this.gvDivType.AllowUserToAddRows = false;
            this.gvDivType.AllowUserToDeleteRows = false;
            this.gvDivType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDivType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDivType.Location = new System.Drawing.Point(19, 78);
            this.gvDivType.MultiSelect = false;
            this.gvDivType.Name = "gvDivType";
            this.gvDivType.ReadOnly = true;
            this.gvDivType.RowHeadersVisible = false;
            this.gvDivType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDivType.Size = new System.Drawing.Size(576, 180);
            this.gvDivType.TabIndex = 20;
            this.gvDivType.SelectionChanged += new System.EventHandler(this.gvDivType_SelectionChanged);
            //
            // Setup_ETF_Stocks_Div_Type
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(616, 372);
            this.ControlBox = false;
            this.Controls.Add(this.gvDivType);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Div_Type_Name);
            this.Controls.Add(this.CmdSetup);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_ETF_Stocks_Div_Type";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Diversification Type Setup";
            this.Load += new System.EventHandler(this.Setup_ETF_Stocks_Div_Type_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDivType)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnETFStockGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFlagSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivAllocSetup;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Button CmdSetup;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox Div_Type_Name;
        private System.Windows.Forms.DataGridView gvDivType;
    }
}
