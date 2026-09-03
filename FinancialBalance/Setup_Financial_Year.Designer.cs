namespace FinancialBalance
{
    partial class Setup_Financial_Year
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Financial_Year));
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
            this.MnETFStocksDivTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivAllocSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.gvFY = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbSDD = new System.Windows.Forms.ComboBox();
            this.CmbSMM = new System.Windows.Forms.ComboBox();
            this.CmbSYear = new System.Windows.Forms.ComboBox();
            this.CmdSCal = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbEDD = new System.Windows.Forms.ComboBox();
            this.CmbEMM = new System.Windows.Forms.ComboBox();
            this.CmbEYear = new System.Windows.Forms.ComboBox();
            this.CmdECal = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.CmdSetup = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFY)).BeginInit();
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
            this.MainMenu1.Size = new System.Drawing.Size(700, 24);
            this.MainMenu1.TabIndex = 0;
            //
            // MnAcctTypeRefSetup
            //
            this.MnAcctTypeRefSetup.Name = "MnAcctTypeRefSetup";
            this.MnAcctTypeRefSetup.Size = new System.Drawing.Size(163, 20);
            this.MnAcctTypeRefSetup.Text = "Accounting &Type Ref Setup";
            this.MnAcctTypeRefSetup.Click += new System.EventHandler(this.MnAcctTypeRefSetup_Click);
            //
            // MnAcctRefSetup
            //
            this.MnAcctRefSetup.Name = "MnAcctRefSetup";
            this.MnAcctRefSetup.Size = new System.Drawing.Size(133, 20);
            this.MnAcctRefSetup.Text = "&Accounting Ref Setup";
            this.MnAcctRefSetup.Click += new System.EventHandler(this.MnAcctRefSetup_Click);
            //
            // MnCurrencyGroup
            //
            this.MnCurrencyGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnCurrSetup,
            this.MnCurrRateSetup});
            this.MnCurrencyGroup.Name = "MnCurrencyGroup";
            this.MnCurrencyGroup.Size = new System.Drawing.Size(69, 20);
            this.MnCurrencyGroup.Text = "&Currency";
            //
            // MnCurrSetup
            //
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(180, 22);
            this.MnCurrSetup.Text = "&Currency Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
            //
            // MnCurrRateSetup
            //
            this.MnCurrRateSetup.Name = "MnCurrRateSetup";
            this.MnCurrRateSetup.Size = new System.Drawing.Size(180, 22);
            this.MnCurrRateSetup.Text = "Currency &Rate Setup";
            this.MnCurrRateSetup.Click += new System.EventHandler(this.MnCurrRateSetup_Click);
            //
            // MnActivaPassivaSetup
            //
            this.MnActivaPassivaSetup.Name = "MnActivaPassivaSetup";
            this.MnActivaPassivaSetup.Size = new System.Drawing.Size(120, 20);
            this.MnActivaPassivaSetup.Text = "Asset &Liability Setup";
            this.MnActivaPassivaSetup.Click += new System.EventHandler(this.MnActivaPassivaSetup_Click);
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
            this.MnETFStockGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockGroup.Text = "&ETF/Stock";
            //
            // MnETFStocksSuffixSetup
            //
            this.MnETFStocksSuffixSetup.Name = "MnETFStocksSuffixSetup";
            this.MnETFStocksSuffixSetup.Size = new System.Drawing.Size(280, 22);
            this.MnETFStocksSuffixSetup.Text = "ETF/Stock &Suffix Setup";
            this.MnETFStocksSuffixSetup.Click += new System.EventHandler(this.MnETFStocksSuffixSetup_Click);
            //
            // MnETFStocksSetup
            //
            this.MnETFStocksSetup.Name = "MnETFStocksSetup";
            this.MnETFStocksSetup.Size = new System.Drawing.Size(280, 22);
            this.MnETFStocksSetup.Text = "ETF/Stock Se&tup";
            this.MnETFStocksSetup.Click += new System.EventHandler(this.MnETFStocksSetup_Click);
            //
            // MnETFStocksFlagSetup
            //
            this.MnETFStocksFlagSetup.Name = "MnETFStocksFlagSetup";
            this.MnETFStocksFlagSetup.Size = new System.Drawing.Size(280, 22);
            this.MnETFStocksFlagSetup.Text = "ETF/Stock &Portfolio Code Setup";
            this.MnETFStocksFlagSetup.Click += new System.EventHandler(this.MnETFStocksFlagSetup_Click);
            //
            // MnETFStocksDivTypeSetup
            //
            this.MnETFStocksDivTypeSetup.Name = "MnETFStocksDivTypeSetup";
            this.MnETFStocksDivTypeSetup.Size = new System.Drawing.Size(280, 22);
            this.MnETFStocksDivTypeSetup.Text = "ETF/Stock &Diversification Type Setup";
            this.MnETFStocksDivTypeSetup.Click += new System.EventHandler(this.MnETFStocksDivTypeSetup_Click);
            //
            // MnETFStocksDivSetup
            //
            this.MnETFStocksDivSetup.Name = "MnETFStocksDivSetup";
            this.MnETFStocksDivSetup.Size = new System.Drawing.Size(280, 22);
            this.MnETFStocksDivSetup.Text = "ETF/Stock Di&versification Setup";
            this.MnETFStocksDivSetup.Click += new System.EventHandler(this.MnETFStocksDivSetup_Click);
            //
            // MnETFStocksDivAllocSetup
            //
            this.MnETFStocksDivAllocSetup.Name = "MnETFStocksDivAllocSetup";
            this.MnETFStocksDivAllocSetup.Size = new System.Drawing.Size(280, 22);
            this.MnETFStocksDivAllocSetup.Text = "ETF/Stock Diversification &Allocation";
            this.MnETFStocksDivAllocSetup.Click += new System.EventHandler(this.MnETFStocksDivAllocSetup_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(90, 30);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(520, 38);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "FINANCIAL YEAR SETUP";
            //
            // gvFY
            //
            this.gvFY.AllowUserToAddRows = false;
            this.gvFY.AllowUserToDeleteRows = false;
            this.gvFY.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvFY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFY.Location = new System.Drawing.Point(19, 80);
            this.gvFY.MultiSelect = false;
            this.gvFY.Name = "gvFY";
            this.gvFY.ReadOnly = true;
            this.gvFY.RowHeadersVisible = false;
            this.gvFY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvFY.Size = new System.Drawing.Size(660, 200);
            this.gvFY.TabIndex = 2;
            this.gvFY.SelectionChanged += new System.EventHandler(this.gvFY_SelectionChanged);
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 302);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(90, 22);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Name";
            //
            // txtName
            //
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(115, 302);
            this.txtName.MaxLength = 9;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 20);
            this.txtName.TabIndex = 4;
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(19, 332);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(90, 22);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Start Date";
            //
            // CmbSDD
            //
            this.CmbSDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSDD.FormattingEnabled = true;
            this.CmbSDD.Location = new System.Drawing.Point(115, 330);
            this.CmbSDD.Name = "CmbSDD";
            this.CmbSDD.Size = new System.Drawing.Size(41, 22);
            this.CmbSDD.TabIndex = 6;
            //
            // CmbSMM
            //
            this.CmbSMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSMM.FormattingEnabled = true;
            this.CmbSMM.Location = new System.Drawing.Point(165, 330);
            this.CmbSMM.Name = "CmbSMM";
            this.CmbSMM.Size = new System.Drawing.Size(41, 22);
            this.CmbSMM.TabIndex = 7;
            //
            // CmbSYear
            //
            this.CmbSYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSYear.FormattingEnabled = true;
            this.CmbSYear.Location = new System.Drawing.Point(215, 330);
            this.CmbSYear.Name = "CmbSYear";
            this.CmbSYear.Size = new System.Drawing.Size(57, 22);
            this.CmbSYear.TabIndex = 8;
            //
            // CmdSCal
            //
            this.CmdSCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSCal.Location = new System.Drawing.Point(279, 330);
            this.CmdSCal.Name = "CmdSCal";
            this.CmdSCal.Size = new System.Drawing.Size(25, 19);
            this.CmdSCal.TabIndex = 9;
            this.CmdSCal.Text = "...";
            this.CmdSCal.UseVisualStyleBackColor = false;
            this.CmdSCal.Click += new System.EventHandler(this.CmdSCal_Click);
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(19, 362);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(90, 22);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "End Date";
            //
            // CmbEDD
            //
            this.CmbEDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEDD.FormattingEnabled = true;
            this.CmbEDD.Location = new System.Drawing.Point(115, 360);
            this.CmbEDD.Name = "CmbEDD";
            this.CmbEDD.Size = new System.Drawing.Size(41, 22);
            this.CmbEDD.TabIndex = 11;
            //
            // CmbEMM
            //
            this.CmbEMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEMM.FormattingEnabled = true;
            this.CmbEMM.Location = new System.Drawing.Point(165, 360);
            this.CmbEMM.Name = "CmbEMM";
            this.CmbEMM.Size = new System.Drawing.Size(41, 22);
            this.CmbEMM.TabIndex = 12;
            //
            // CmbEYear
            //
            this.CmbEYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEYear.FormattingEnabled = true;
            this.CmbEYear.Location = new System.Drawing.Point(215, 360);
            this.CmbEYear.Name = "CmbEYear";
            this.CmbEYear.Size = new System.Drawing.Size(57, 22);
            this.CmbEYear.TabIndex = 13;
            //
            // CmdECal
            //
            this.CmdECal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdECal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdECal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdECal.Location = new System.Drawing.Point(279, 360);
            this.CmdECal.Name = "CmdECal";
            this.CmdECal.Size = new System.Drawing.Size(25, 19);
            this.CmdECal.TabIndex = 14;
            this.CmdECal.Text = "...";
            this.CmdECal.UseVisualStyleBackColor = false;
            this.CmdECal.Click += new System.EventHandler(this.CmdECal_Click);
            //
            // monthCalendar1
            //
            this.monthCalendar1.Location = new System.Drawing.Point(400, 300);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 15;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            //
            // CmdSetup
            //
            this.CmdSetup.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSetup.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSetup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSetup.Location = new System.Drawing.Point(115, 396);
            this.CmdSetup.Name = "CmdSetup";
            this.CmdSetup.Size = new System.Drawing.Size(100, 27);
            this.CmdSetup.TabIndex = 16;
            this.CmdSetup.Text = "&Add / Update";
            this.CmdSetup.UseVisualStyleBackColor = false;
            this.CmdSetup.Click += new System.EventHandler(this.CmdSetup_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(225, 396);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 27);
            this.CmdDel.TabIndex = 17;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdClear
            //
            this.CmdClear.BackColor = System.Drawing.SystemColors.Control;
            this.CmdClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdClear.Location = new System.Drawing.Point(320, 396);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.Size = new System.Drawing.Size(85, 27);
            this.CmdClear.TabIndex = 18;
            this.CmdClear.Text = "&Clear";
            this.CmdClear.UseVisualStyleBackColor = false;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(594, 396);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 19;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Setup_Financial_Year
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(700, 440);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdSetup);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.CmdECal);
            this.Controls.Add(this.CmbEYear);
            this.Controls.Add(this.CmbEMM);
            this.Controls.Add(this.CmbEDD);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.CmdSCal);
            this.Controls.Add(this.CmbSYear);
            this.Controls.Add(this.CmbSMM);
            this.Controls.Add(this.CmbSDD);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.gvFY);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_Financial_Year";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial Year Setup";
            this.Load += new System.EventHandler(this.Setup_Financial_Year_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFY)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivAllocSetup;
        public System.Windows.Forms.Label Label21;
        private System.Windows.Forms.DataGridView gvFY;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbSDD;
        public System.Windows.Forms.ComboBox CmbSMM;
        public System.Windows.Forms.ComboBox CmbSYear;
        public System.Windows.Forms.Button CmdSCal;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbEDD;
        public System.Windows.Forms.ComboBox CmbEMM;
        public System.Windows.Forms.ComboBox CmbEYear;
        public System.Windows.Forms.Button CmdECal;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.Button CmdSetup;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdBack;
    }
}
