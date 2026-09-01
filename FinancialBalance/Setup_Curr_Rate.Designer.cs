namespace FinancialBalance
{
    partial class Setup_Curr_Rate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Curr_Rate));
            this.CmdBack = new System.Windows.Forms.Button();
            this.CmdSetup = new System.Windows.Forms.Button();
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrencyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnActivaPassivaSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFlagSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbCurr = new System.Windows.Forms.ComboBox();
            this.lblCurrName = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbDD = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbMM = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.CmdCal = new System.Windows.Forms.Button();
            this.LblDay = new System.Windows.Forms.Label();
            this.gvCurrRate = new System.Windows.Forms.DataGridView();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCurrRate)).BeginInit();
            this.SuspendLayout();
            // 
            // CmdBack
            // 
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(232, 342);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 27);
            this.CmdBack.TabIndex = 5;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // CmdSetup
            // 
            this.CmdSetup.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSetup.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdSetup.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSetup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSetup.Location = new System.Drawing.Point(128, 342);
            this.CmdSetup.Name = "CmdSetup";
            this.CmdSetup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdSetup.Size = new System.Drawing.Size(73, 25);
            this.CmdSetup.TabIndex = 6;
            this.CmdSetup.Text = "&Setup";
            this.CmdSetup.UseVisualStyleBackColor = false;
            this.CmdSetup.Click += new System.EventHandler(this.CmdSetup_Click);
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
            this.MainMenu1.Size = new System.Drawing.Size(574, 24);
            this.MainMenu1.TabIndex = 17;
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
            this.MnAcctRefSetup.Size = new System.Drawing.Size(123, 20);
            this.MnAcctRefSetup.Text = "&Accounting Ref Setup";
            this.MnAcctRefSetup.Click += new System.EventHandler(this.MnAcctRefSetup_Click);
            // 
            // MnCurrencyGroup
            // 
            this.MnCurrencyGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnCurrSetup});
            this.MnCurrencyGroup.Name = "MnCurrencyGroup";
            this.MnCurrencyGroup.Size = new System.Drawing.Size(75, 20);
            this.MnCurrencyGroup.Text = "&Currency";
            // 
            // MnCurrSetup
            // 
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(94, 20);
            this.MnCurrSetup.Text = "&Currency Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
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
            // MnETFStocksFlagSetup
            // 
            this.MnETFStocksFlagSetup.Name = "MnETFStocksFlagSetup";
            this.MnETFStocksFlagSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksFlagSetup.Text = "ETF/Stock &Portfolio Code Setup";
            this.MnETFStocksFlagSetup.Click += new System.EventHandler(this.MnETFStocksFlagSetup_Click);
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
            this.Label21.Location = new System.Drawing.Point(125, 30);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(292, 41);
            this.Label21.TabIndex = 18;
            this.Label21.Text = "CURRENCY RATE SETUP";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(16, 71);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(67, 25);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Currency";
            // 
            // CmbCurr
            // 
            this.CmbCurr.BackColor = System.Drawing.SystemColors.Window;
            this.CmbCurr.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbCurr.Location = new System.Drawing.Point(88, 70);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbCurr.Size = new System.Drawing.Size(49, 22);
            this.CmbCurr.TabIndex = 20;
            this.CmbCurr.SelectedIndexChanged += new System.EventHandler(this.CmbCurr_SelectedIndexChanged);
            // 
            // lblCurrName
            // 
            this.lblCurrName.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCurrName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrName.ForeColor = System.Drawing.Color.Black;
            this.lblCurrName.Location = new System.Drawing.Point(144, 72);
            this.lblCurrName.Name = "lblCurrName";
            this.lblCurrName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCurrName.Size = new System.Drawing.Size(289, 25);
            this.lblCurrName.TabIndex = 21;
            this.lblCurrName.Text = "Indonesian Rupiah";
            // 
            // txtRate
            // 
            this.txtRate.AcceptsReturn = true;
            this.txtRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtRate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRate.Location = new System.Drawing.Point(88, 310);
            this.txtRate.MaxLength = 16;
            this.txtRate.Name = "txtRate";
            this.txtRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRate.Size = new System.Drawing.Size(105, 20);
            this.txtRate.TabIndex = 22;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            this.txtRate.Leave += new System.EventHandler(this.txtRate_Leave);
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(16, 310);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(41, 25);
            this.Label5.TabIndex = 23;
            this.Label5.Text = "Rate";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(16, 286);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(41, 17);
            this.Label2.TabIndex = 24;
            this.Label2.Text = "Date";
            // 
            // CmbDD
            // 
            this.CmbDD.BackColor = System.Drawing.SystemColors.Window;
            this.CmbDD.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbDD.Location = new System.Drawing.Point(88, 285);
            this.CmbDD.Name = "CmbDD";
            this.CmbDD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbDD.Size = new System.Drawing.Size(41, 22);
            this.CmbDD.TabIndex = 25;
            this.CmbDD.SelectedIndexChanged += new System.EventHandler(this.CmbDD_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(136, 286);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(9, 21);
            this.Label3.TabIndex = 26;
            this.Label3.Text = "/";
            // 
            // CmbMM
            // 
            this.CmbMM.BackColor = System.Drawing.SystemColors.Window;
            this.CmbMM.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbMM.Location = new System.Drawing.Point(152, 285);
            this.CmbMM.Name = "CmbMM";
            this.CmbMM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbMM.Size = new System.Drawing.Size(41, 22);
            this.CmbMM.TabIndex = 27;
            this.CmbMM.SelectedIndexChanged += new System.EventHandler(this.CmbMM_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(200, 286);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(9, 25);
            this.Label4.TabIndex = 28;
            this.Label4.Text = "/";
            // 
            // CmbYear
            // 
            this.CmbYear.BackColor = System.Drawing.SystemColors.Window;
            this.CmbYear.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbYear.Location = new System.Drawing.Point(216, 285);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 29;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            // 
            // CmdCal
            // 
            this.CmdCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCal.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCal.Location = new System.Drawing.Point(280, 286);
            this.CmdCal.Name = "CmdCal";
            this.CmdCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdCal.Size = new System.Drawing.Size(25, 19);
            this.CmdCal.TabIndex = 30;
            this.CmdCal.Text = "..";
            this.CmdCal.UseVisualStyleBackColor = false;
            this.CmdCal.Click += new System.EventHandler(this.CmdCal_Click);
            // 
            // LblDay
            // 
            this.LblDay.BackColor = System.Drawing.Color.Transparent;
            this.LblDay.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblDay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblDay.Location = new System.Drawing.Point(312, 286);
            this.LblDay.Name = "LblDay";
            this.LblDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDay.Size = new System.Drawing.Size(121, 17);
            this.LblDay.TabIndex = 31;
            this.LblDay.Text = "Monday";
            // 
            // gvCurrRate
            // 
            this.gvCurrRate.AllowUserToAddRows = false;
            this.gvCurrRate.AllowUserToDeleteRows = false;
            this.gvCurrRate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCurrRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCurrRate.Location = new System.Drawing.Point(19, 98);
            this.gvCurrRate.MultiSelect = false;
            this.gvCurrRate.Name = "gvCurrRate";
            this.gvCurrRate.ReadOnly = true;
            this.gvCurrRate.Size = new System.Drawing.Size(529, 181);
            this.gvCurrRate.TabIndex = 32;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(315, 202);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 33;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // Setup_Curr_Rate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(574, 387);
            this.ControlBox = false;
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.gvCurrRate);
            this.Controls.Add(this.LblDay);
            this.Controls.Add(this.CmdCal);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.CmbMM);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.CmbDD);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblCurrName);
            this.Controls.Add(this.CmbCurr);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.CmdSetup);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_Curr_Rate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Currency Rate Setup";
            this.Load += new System.EventHandler(this.Setup_Curr_Rate_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCurrRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.Button CmdSetup;
        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnAcctTypeRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnAcctRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrencyGroup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrSetup;
        public System.Windows.Forms.ToolStripMenuItem MnActivaPassivaSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFlagSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbCurr;
        public System.Windows.Forms.Label lblCurrName;
        public System.Windows.Forms.TextBox txtRate;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbDD;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbMM;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Button CmdCal;
        public System.Windows.Forms.Label LblDay;
        private System.Windows.Forms.DataGridView gvCurrRate;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}