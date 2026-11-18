namespace FinancialBalance
{
    partial class ETF_Stocks_Dividend_History_Calendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Dividend_History_Calendar));
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.Lbl_CmbPeriod = new System.Windows.Forms.Label();
            this.CmbPeriod = new System.Windows.Forms.ComboBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvHistory = new System.Windows.Forms.DataGridView();
            this.LblInvCap = new System.Windows.Forms.Label();
            this.LblInv = new System.Windows.Forms.Label();
            this.LblGrandCap = new System.Windows.Forms.Label();
            this.LblGrand = new System.Windows.Forms.Label();
            this.LblYieldCap = new System.Windows.Forms.Label();
            this.LblYield = new System.Windows.Forms.Label();
            this.LblReinvCap = new System.Windows.Forms.Label();
            this.LblReinv = new System.Windows.Forms.Label();
            this.LblNotReinvCap = new System.Windows.Forms.Label();
            this.LblNotReinv = new System.Windows.Forms.Label();
            this.LblAverageCap = new System.Windows.Forms.Label();
            this.LblAverage = new System.Windows.Forms.Label();
            this.LblBasis = new System.Windows.Forms.Label();
            this.CmdExcel = new System.Windows.Forms.Button();
            this.CmdDrive = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(340, 20);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(800, 41);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK DIVIDEND HISTORY CALENDAR";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 76);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 22);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Portfolio";
            //
            // CmbPortfolio
            //
            this.CmbPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPortfolio.FormattingEnabled = true;
            this.CmbPortfolio.Location = new System.Drawing.Point(105, 74);
            this.CmbPortfolio.Name = "CmbPortfolio";
            this.CmbPortfolio.Size = new System.Drawing.Size(260, 22);
            this.CmbPortfolio.TabIndex = 2;
            this.CmbPortfolio.SelectedIndexChanged += new System.EventHandler(this.CmbPortfolio_SelectedIndexChanged);
            //
            // chkMainOnly
            //
            this.chkMainOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkMainOnly.Checked = true;
            this.chkMainOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMainOnly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMainOnly.Location = new System.Drawing.Point(380, 74);
            this.chkMainOnly.Name = "chkMainOnly";
            this.chkMainOnly.Size = new System.Drawing.Size(100, 24);
            this.chkMainOnly.TabIndex = 3;
            this.chkMainOnly.Text = "Main Only";
            this.chkMainOnly.UseVisualStyleBackColor = false;
            this.chkMainOnly.CheckedChanged += new System.EventHandler(this.chkMainOnly_CheckedChanged);
            //
            // Lbl_CmbPeriod
            //
            this.Lbl_CmbPeriod.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbPeriod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbPeriod.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbPeriod.Location = new System.Drawing.Point(492, 76);
            this.Lbl_CmbPeriod.Name = "Lbl_CmbPeriod";
            this.Lbl_CmbPeriod.Size = new System.Drawing.Size(56, 22);
            this.Lbl_CmbPeriod.TabIndex = 24;
            this.Lbl_CmbPeriod.Text = "Period";
            //
            // CmbPeriod
            //
            this.CmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPeriod.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPeriod.FormattingEnabled = true;
            this.CmbPeriod.Location = new System.Drawing.Point(552, 74);
            this.CmbPeriod.Name = "CmbPeriod";
            this.CmbPeriod.Size = new System.Drawing.Size(210, 22);
            this.CmbPeriod.TabIndex = 25;
            this.CmbPeriod.SelectedIndexChanged += new System.EventHandler(this.CmbPeriod_SelectedIndexChanged);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblNote.Location = new System.Drawing.Point(780, 78);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(681, 20);
            this.LblNote.TabIndex = 4;
            this.LblNote.Text = "Distributions/dividends received";
            //
            // gvHistory
            //
            this.gvHistory.AllowUserToAddRows = false;
            this.gvHistory.AllowUserToDeleteRows = false;
            this.gvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHistory.Location = new System.Drawing.Point(19, 110);
            this.gvHistory.MultiSelect = false;
            this.gvHistory.Name = "gvHistory";
            this.gvHistory.ReadOnly = true;
            this.gvHistory.RowHeadersVisible = false;
            this.gvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvHistory.Size = new System.Drawing.Size(1442, 340);
            this.gvHistory.TabIndex = 5;
            //
            // LblInvCap
            //
            this.LblInvCap.BackColor = System.Drawing.Color.Transparent;
            this.LblInvCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInvCap.ForeColor = System.Drawing.Color.Black;
            this.LblInvCap.Location = new System.Drawing.Point(460, 466);
            this.LblInvCap.Name = "LblInvCap";
            this.LblInvCap.Size = new System.Drawing.Size(340, 20);
            this.LblInvCap.TabIndex = 18;
            this.LblInvCap.Text = "Grand Total Investment";
            this.LblInvCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblInv
            //
            this.LblInv.BackColor = System.Drawing.Color.Transparent;
            this.LblInv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInv.ForeColor = System.Drawing.Color.Black;
            this.LblInv.Location = new System.Drawing.Point(810, 466);
            this.LblInv.Name = "LblInv";
            this.LblInv.Size = new System.Drawing.Size(210, 20);
            this.LblInv.TabIndex = 19;
            this.LblInv.Text = "0.00";
            //
            // LblGrandCap
            //
            this.LblGrandCap.BackColor = System.Drawing.Color.Transparent;
            this.LblGrandCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrandCap.ForeColor = System.Drawing.Color.Black;
            this.LblGrandCap.Location = new System.Drawing.Point(460, 490);
            this.LblGrandCap.Name = "LblGrandCap";
            this.LblGrandCap.Size = new System.Drawing.Size(340, 20);
            this.LblGrandCap.TabIndex = 6;
            this.LblGrandCap.Text = "Grand Total Dividend (Last 12 Months)";
            this.LblGrandCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblGrand
            //
            this.LblGrand.BackColor = System.Drawing.Color.Transparent;
            this.LblGrand.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrand.ForeColor = System.Drawing.Color.Black;
            this.LblGrand.Location = new System.Drawing.Point(810, 490);
            this.LblGrand.Name = "LblGrand";
            this.LblGrand.Size = new System.Drawing.Size(210, 20);
            this.LblGrand.TabIndex = 7;
            this.LblGrand.Text = "0.00";
            //
            // LblYieldCap
            //
            this.LblYieldCap.BackColor = System.Drawing.Color.Transparent;
            this.LblYieldCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYieldCap.ForeColor = System.Drawing.Color.Black;
            this.LblYieldCap.Location = new System.Drawing.Point(460, 514);
            this.LblYieldCap.Name = "LblYieldCap";
            this.LblYieldCap.Size = new System.Drawing.Size(340, 20);
            this.LblYieldCap.TabIndex = 20;
            this.LblYieldCap.Text = "Yield";
            this.LblYieldCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblYield
            //
            this.LblYield.BackColor = System.Drawing.Color.Transparent;
            this.LblYield.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYield.ForeColor = System.Drawing.Color.Black;
            this.LblYield.Location = new System.Drawing.Point(810, 514);
            this.LblYield.Name = "LblYield";
            this.LblYield.Size = new System.Drawing.Size(210, 20);
            this.LblYield.TabIndex = 21;
            this.LblYield.Text = "0.00 %";
            //
            // LblReinvCap
            //
            this.LblReinvCap.BackColor = System.Drawing.Color.Transparent;
            this.LblReinvCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReinvCap.ForeColor = System.Drawing.Color.Black;
            this.LblReinvCap.Location = new System.Drawing.Point(460, 538);
            this.LblReinvCap.Name = "LblReinvCap";
            this.LblReinvCap.Size = new System.Drawing.Size(340, 20);
            this.LblReinvCap.TabIndex = 8;
            this.LblReinvCap.Text = "Total Reinvested";
            this.LblReinvCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblReinv
            //
            this.LblReinv.BackColor = System.Drawing.Color.Transparent;
            this.LblReinv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReinv.ForeColor = System.Drawing.Color.Black;
            this.LblReinv.Location = new System.Drawing.Point(810, 538);
            this.LblReinv.Name = "LblReinv";
            this.LblReinv.Size = new System.Drawing.Size(210, 20);
            this.LblReinv.TabIndex = 9;
            this.LblReinv.Text = "0.00";
            //
            // LblNotReinvCap
            //
            this.LblNotReinvCap.BackColor = System.Drawing.Color.Transparent;
            this.LblNotReinvCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNotReinvCap.ForeColor = System.Drawing.Color.Black;
            this.LblNotReinvCap.Location = new System.Drawing.Point(460, 562);
            this.LblNotReinvCap.Name = "LblNotReinvCap";
            this.LblNotReinvCap.Size = new System.Drawing.Size(340, 20);
            this.LblNotReinvCap.TabIndex = 10;
            this.LblNotReinvCap.Text = "Total Not Reinvested";
            this.LblNotReinvCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblNotReinv
            //
            this.LblNotReinv.BackColor = System.Drawing.Color.Transparent;
            this.LblNotReinv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNotReinv.ForeColor = System.Drawing.Color.Black;
            this.LblNotReinv.Location = new System.Drawing.Point(810, 562);
            this.LblNotReinv.Name = "LblNotReinv";
            this.LblNotReinv.Size = new System.Drawing.Size(210, 20);
            this.LblNotReinv.TabIndex = 11;
            this.LblNotReinv.Text = "0.00";
            //
            // LblAverageCap
            //
            this.LblAverageCap.BackColor = System.Drawing.Color.Transparent;
            this.LblAverageCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAverageCap.ForeColor = System.Drawing.Color.Black;
            this.LblAverageCap.Location = new System.Drawing.Point(460, 586);
            this.LblAverageCap.Name = "LblAverageCap";
            this.LblAverageCap.Size = new System.Drawing.Size(340, 20);
            this.LblAverageCap.TabIndex = 12;
            this.LblAverageCap.Text = "Monthly Average";
            this.LblAverageCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAverage
            //
            this.LblAverage.BackColor = System.Drawing.Color.Transparent;
            this.LblAverage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAverage.ForeColor = System.Drawing.Color.Black;
            this.LblAverage.Location = new System.Drawing.Point(810, 586);
            this.LblAverage.Name = "LblAverage";
            this.LblAverage.Size = new System.Drawing.Size(210, 20);
            this.LblAverage.TabIndex = 13;
            this.LblAverage.Text = "0.00";
            //
            // LblBasis
            //
            this.LblBasis.BackColor = System.Drawing.Color.Transparent;
            this.LblBasis.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBasis.ForeColor = System.Drawing.Color.DimGray;
            this.LblBasis.Location = new System.Drawing.Point(19, 618);
            this.LblBasis.Name = "LblBasis";
            this.LblBasis.Size = new System.Drawing.Size(1442, 48);
            this.LblBasis.TabIndex = 14;
            this.LblBasis.Text = "";
            //
            // CmdExcel
            //
            this.CmdExcel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdExcel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdExcel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdExcel.Location = new System.Drawing.Point(540, 674);
            this.CmdExcel.Name = "CmdExcel";
            this.CmdExcel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdExcel.Size = new System.Drawing.Size(120, 27);
            this.CmdExcel.TabIndex = 15;
            this.CmdExcel.Text = "&Generate Excel";
            this.CmdExcel.UseVisualStyleBackColor = false;
            this.CmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            //
            // CmdDrive
            //
            this.CmdDrive.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDrive.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdDrive.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDrive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDrive.Location = new System.Drawing.Point(670, 674);
            this.CmdDrive.Name = "CmdDrive";
            this.CmdDrive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDrive.Size = new System.Drawing.Size(170, 27);
            this.CmdDrive.TabIndex = 16;
            this.CmdDrive.Text = "Generate to Google &Drive";
            this.CmdDrive.UseVisualStyleBackColor = false;
            this.CmdDrive.Click += new System.EventHandler(this.CmdDrive_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(850, 674);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 27);
            this.CmdBack.TabIndex = 17;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Dividend_History_Calendar
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1480, 712);
            this.Controls.Add(this.CmdDrive);
            this.Controls.Add(this.CmdExcel);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblBasis);
            this.Controls.Add(this.LblAverage);
            this.Controls.Add(this.LblAverageCap);
            this.Controls.Add(this.LblNotReinv);
            this.Controls.Add(this.LblNotReinvCap);
            this.Controls.Add(this.LblReinv);
            this.Controls.Add(this.LblReinvCap);
            this.Controls.Add(this.LblYield);
            this.Controls.Add(this.LblYieldCap);
            this.Controls.Add(this.LblGrand);
            this.Controls.Add(this.LblGrandCap);
            this.Controls.Add(this.LblInv);
            this.Controls.Add(this.LblInvCap);
            this.Controls.Add(this.gvHistory);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmbPeriod);
            this.Controls.Add(this.Lbl_CmbPeriod);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Dividend_History_Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Dividend History Calendar";
            this.Load += new System.EventHandler(this.ETF_Stocks_Dividend_History_Calendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.CheckBox chkMainOnly;
        public System.Windows.Forms.Label Lbl_CmbPeriod;
        public System.Windows.Forms.ComboBox CmbPeriod;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvHistory;
        public System.Windows.Forms.Label LblInvCap;
        public System.Windows.Forms.Label LblInv;
        public System.Windows.Forms.Label LblGrandCap;
        public System.Windows.Forms.Label LblGrand;
        public System.Windows.Forms.Label LblYieldCap;
        public System.Windows.Forms.Label LblYield;
        public System.Windows.Forms.Label LblReinvCap;
        public System.Windows.Forms.Label LblReinv;
        public System.Windows.Forms.Label LblNotReinvCap;
        public System.Windows.Forms.Label LblNotReinv;
        public System.Windows.Forms.Label LblAverageCap;
        public System.Windows.Forms.Label LblAverage;
        public System.Windows.Forms.Label LblBasis;
        public System.Windows.Forms.Button CmdExcel;
        public System.Windows.Forms.Button CmdDrive;
        public System.Windows.Forms.Button CmdBack;
    }
}
