namespace FinancialBalance
{
    partial class Setup_ETF_Stocks_Flag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_ETF_Stocks_Flag));
            this.CmdBack = new System.Windows.Forms.Button();
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
            this.MnETFStocksDivTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdSetup = new System.Windows.Forms.Button();
            this.Portfolio_Code = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbIsMain = new System.Windows.Forms.ComboBox();
            this.gvFlag = new System.Windows.Forms.DataGridView();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlag)).BeginInit();
            this.SuspendLayout();
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(320, 350);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 27);
            this.CmdBack.TabIndex = 6;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
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
            this.MnETFStocksDivTypeSetup,
            this.MnETFStocksDivSetup});
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
            // MnETFStocksDivTypeSetup
            // 
            this.MnETFStocksDivTypeSetup.Name = "MnETFStocksDivTypeSetup";
            this.MnETFStocksDivTypeSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksDivTypeSetup.Text = "ETF/Stock &Diversification Type Setup";
            this.MnETFStocksDivTypeSetup.Click += new System.EventHandler(this.MnETFStocksDivTypeSetup_Click);
            // 
            // MnETFStocksDivSetup
            // 
            this.MnETFStocksDivSetup.Name = "MnETFStocksDivSetup";
            this.MnETFStocksDivSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksDivSetup.Text = "ETF/Stock Di&versification Setup";
            this.MnETFStocksDivSetup.Click += new System.EventHandler(this.MnETFStocksDivSetup_Click);
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
            this.Label21.Text = "ETF/STOCK PORTFOLIO CODE SETUP";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(232, 350);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(73, 25);
            this.CmdDel.TabIndex = 11;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdSetup
            //
            this.CmdSetup.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSetup.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdSetup.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSetup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSetup.Location = new System.Drawing.Point(144, 350);
            this.CmdSetup.Name = "CmdSetup";
            this.CmdSetup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdSetup.Size = new System.Drawing.Size(73, 25);
            this.CmdSetup.TabIndex = 12;
            this.CmdSetup.Text = "&Setup";
            this.CmdSetup.UseVisualStyleBackColor = false;
            this.CmdSetup.Click += new System.EventHandler(this.CmdSetup_Click);
            //
            // Portfolio_Code
            //
            this.Portfolio_Code.AcceptsReturn = true;
            this.Portfolio_Code.BackColor = System.Drawing.SystemColors.Window;
            this.Portfolio_Code.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Portfolio_Code.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Portfolio_Code.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Portfolio_Code.Location = new System.Drawing.Point(128, 270);
            this.Portfolio_Code.MaxLength = 5;
            this.Portfolio_Code.Name = "Portfolio_Code";
            this.Portfolio_Code.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Portfolio_Code.Size = new System.Drawing.Size(54, 20);
            this.Portfolio_Code.TabIndex = 13;
            //
            // Description
            //
            this.Description.AcceptsReturn = true;
            this.Description.BackColor = System.Drawing.SystemColors.Window;
            this.Description.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Description.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Description.Location = new System.Drawing.Point(128, 294);
            this.Description.MaxLength = 50;
            this.Description.Name = "Description";
            this.Description.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Description.Size = new System.Drawing.Size(320, 20);
            this.Description.TabIndex = 14;
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
            this.Label1.Size = new System.Drawing.Size(106, 25);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Portfolio Code";
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
            this.Label2.Size = new System.Drawing.Size(106, 25);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Description";
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(16, 318);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(106, 25);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Is Main";
            //
            // CmbIsMain
            //
            this.CmbIsMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIsMain.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbIsMain.FormattingEnabled = true;
            this.CmbIsMain.Location = new System.Drawing.Point(128, 316);
            this.CmbIsMain.Name = "CmbIsMain";
            this.CmbIsMain.Size = new System.Drawing.Size(48, 22);
            this.CmbIsMain.TabIndex = 19;
            //
            // gvFlag
            //
            this.gvFlag.AllowUserToAddRows = false;
            this.gvFlag.AllowUserToDeleteRows = false;
            this.gvFlag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvFlag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFlag.Location = new System.Drawing.Point(19, 71);
            this.gvFlag.MultiSelect = false;
            this.gvFlag.Name = "gvFlag";
            this.gvFlag.ReadOnly = true;
            this.gvFlag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFlag.Size = new System.Drawing.Size(557, 190);
            this.gvFlag.TabIndex = 17;
            this.gvFlag.SelectionChanged += new System.EventHandler(this.gvFlag_SelectionChanged);
            //
            // Setup_ETF_Stocks_Flag
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(616, 396);
            this.ControlBox = false;
            this.Controls.Add(this.gvFlag);
            this.Controls.Add(this.CmbIsMain);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Portfolio_Code);
            this.Controls.Add(this.CmdSetup);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_ETF_Stocks_Flag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Portfolio Code Setup";
            this.Load += new System.EventHandler(this.Setup_ETF_Stocks_Flag_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button CmdBack;
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
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdSetup;
        public System.Windows.Forms.TextBox Portfolio_Code;
        public System.Windows.Forms.TextBox Description;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbIsMain;
        private System.Windows.Forms.DataGridView gvFlag;
    }
}
