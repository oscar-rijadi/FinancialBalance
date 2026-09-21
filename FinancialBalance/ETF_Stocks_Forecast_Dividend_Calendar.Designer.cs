namespace FinancialBalance
{
    partial class ETF_Stocks_Forecast_Dividend_Calendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Forecast_Dividend_Calendar));
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvForecast = new System.Windows.Forms.DataGridView();
            this.LblTotUnitCap = new System.Windows.Forms.Label();
            this.LblTotUnit = new System.Windows.Forms.Label();
            this.LblTotInvCap = new System.Windows.Forms.Label();
            this.LblTotInv = new System.Windows.Forms.Label();
            this.LblTotCurCap = new System.Windows.Forms.Label();
            this.LblTotCur = new System.Windows.Forms.Label();
            this.LblGrandCap = new System.Windows.Forms.Label();
            this.LblGrand = new System.Windows.Forms.Label();
            this.LblGrandYieldCap = new System.Windows.Forms.Label();
            this.LblGrandYield = new System.Windows.Forms.Label();
            this.LblBasis = new System.Windows.Forms.Label();
            this.CmdExcel = new System.Windows.Forms.Button();
            this.CmdDrive = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvForecast)).BeginInit();
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
            this.Label21.Text = "ETF/STOCK FORECAST DIVIDEND CALENDAR";
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
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblNote.Location = new System.Drawing.Point(492, 78);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(969, 20);
            this.LblNote.TabIndex = 4;
            this.LblNote.Text = "Unsold holdings only";
            //
            // gvForecast
            //
            this.gvForecast.AllowUserToAddRows = false;
            this.gvForecast.AllowUserToDeleteRows = false;
            this.gvForecast.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvForecast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvForecast.Location = new System.Drawing.Point(19, 110);
            this.gvForecast.MultiSelect = false;
            this.gvForecast.Name = "gvForecast";
            this.gvForecast.ReadOnly = true;
            this.gvForecast.RowHeadersVisible = false;
            this.gvForecast.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvForecast.Size = new System.Drawing.Size(1442, 340);
            this.gvForecast.TabIndex = 5;
            //
            // LblTotUnitCap
            //
            this.LblTotUnitCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotUnitCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotUnitCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotUnitCap.Location = new System.Drawing.Point(460, 466);
            this.LblTotUnitCap.Name = "LblTotUnitCap";
            this.LblTotUnitCap.Size = new System.Drawing.Size(340, 20);
            this.LblTotUnitCap.TabIndex = 6;
            this.LblTotUnitCap.Text = "Total Unit";
            this.LblTotUnitCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotUnit
            //
            this.LblTotUnit.BackColor = System.Drawing.Color.Transparent;
            this.LblTotUnit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotUnit.ForeColor = System.Drawing.Color.Black;
            this.LblTotUnit.Location = new System.Drawing.Point(810, 466);
            this.LblTotUnit.Name = "LblTotUnit";
            this.LblTotUnit.Size = new System.Drawing.Size(210, 20);
            this.LblTotUnit.TabIndex = 7;
            this.LblTotUnit.Text = "0.00";
            //
            // LblTotInvCap
            //
            this.LblTotInvCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotInvCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotInvCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotInvCap.Location = new System.Drawing.Point(460, 490);
            this.LblTotInvCap.Name = "LblTotInvCap";
            this.LblTotInvCap.Size = new System.Drawing.Size(340, 20);
            this.LblTotInvCap.TabIndex = 8;
            this.LblTotInvCap.Text = "Total Investment";
            this.LblTotInvCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotInv
            //
            this.LblTotInv.BackColor = System.Drawing.Color.Transparent;
            this.LblTotInv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotInv.ForeColor = System.Drawing.Color.Black;
            this.LblTotInv.Location = new System.Drawing.Point(810, 490);
            this.LblTotInv.Name = "LblTotInv";
            this.LblTotInv.Size = new System.Drawing.Size(210, 20);
            this.LblTotInv.TabIndex = 9;
            this.LblTotInv.Text = "0.00";
            //
            // LblTotCurCap
            //
            this.LblTotCurCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotCurCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotCurCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotCurCap.Location = new System.Drawing.Point(460, 514);
            this.LblTotCurCap.Name = "LblTotCurCap";
            this.LblTotCurCap.Size = new System.Drawing.Size(340, 20);
            this.LblTotCurCap.TabIndex = 10;
            this.LblTotCurCap.Text = "Total Current Amount";
            this.LblTotCurCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotCur
            //
            this.LblTotCur.BackColor = System.Drawing.Color.Transparent;
            this.LblTotCur.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotCur.ForeColor = System.Drawing.Color.Black;
            this.LblTotCur.Location = new System.Drawing.Point(810, 514);
            this.LblTotCur.Name = "LblTotCur";
            this.LblTotCur.Size = new System.Drawing.Size(210, 20);
            this.LblTotCur.TabIndex = 11;
            this.LblTotCur.Text = "0.00";
            //
            // LblGrandCap
            //
            this.LblGrandCap.BackColor = System.Drawing.Color.Transparent;
            this.LblGrandCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrandCap.ForeColor = System.Drawing.Color.Black;
            this.LblGrandCap.Location = new System.Drawing.Point(460, 538);
            this.LblGrandCap.Name = "LblGrandCap";
            this.LblGrandCap.Size = new System.Drawing.Size(340, 20);
            this.LblGrandCap.TabIndex = 12;
            this.LblGrandCap.Text = "Grand Total Dividend (Next 12 Months)";
            this.LblGrandCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblGrand
            //
            this.LblGrand.BackColor = System.Drawing.Color.Transparent;
            this.LblGrand.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrand.ForeColor = System.Drawing.Color.Black;
            this.LblGrand.Location = new System.Drawing.Point(810, 538);
            this.LblGrand.Name = "LblGrand";
            this.LblGrand.Size = new System.Drawing.Size(210, 20);
            this.LblGrand.TabIndex = 13;
            this.LblGrand.Text = "0.00";
            //
            // LblGrandYieldCap
            //
            this.LblGrandYieldCap.BackColor = System.Drawing.Color.Transparent;
            this.LblGrandYieldCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrandYieldCap.ForeColor = System.Drawing.Color.Black;
            this.LblGrandYieldCap.Location = new System.Drawing.Point(460, 562);
            this.LblGrandYieldCap.Name = "LblGrandYieldCap";
            this.LblGrandYieldCap.Size = new System.Drawing.Size(340, 20);
            this.LblGrandYieldCap.TabIndex = 14;
            this.LblGrandYieldCap.Text = "Grand Total Yield";
            this.LblGrandYieldCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblGrandYield
            //
            this.LblGrandYield.BackColor = System.Drawing.Color.Transparent;
            this.LblGrandYield.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrandYield.ForeColor = System.Drawing.Color.Black;
            this.LblGrandYield.Location = new System.Drawing.Point(810, 562);
            this.LblGrandYield.Name = "LblGrandYield";
            this.LblGrandYield.Size = new System.Drawing.Size(210, 20);
            this.LblGrandYield.TabIndex = 15;
            this.LblGrandYield.Text = "0.00 %";
            //
            // LblBasis
            //
            this.LblBasis.BackColor = System.Drawing.Color.Transparent;
            this.LblBasis.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBasis.ForeColor = System.Drawing.Color.DimGray;
            this.LblBasis.Location = new System.Drawing.Point(19, 594);
            this.LblBasis.Name = "LblBasis";
            this.LblBasis.Size = new System.Drawing.Size(1442, 48);
            this.LblBasis.TabIndex = 16;
            this.LblBasis.Text = "";
            //
            // CmdExcel
            //
            this.CmdExcel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdExcel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdExcel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdExcel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdExcel.Location = new System.Drawing.Point(540, 650);
            this.CmdExcel.Name = "CmdExcel";
            this.CmdExcel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdExcel.Size = new System.Drawing.Size(120, 27);
            this.CmdExcel.TabIndex = 17;
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
            this.CmdDrive.Location = new System.Drawing.Point(670, 650);
            this.CmdDrive.Name = "CmdDrive";
            this.CmdDrive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDrive.Size = new System.Drawing.Size(170, 27);
            this.CmdDrive.TabIndex = 18;
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
            this.CmdBack.Location = new System.Drawing.Point(850, 650);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 27);
            this.CmdBack.TabIndex = 19;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Forecast_Dividend_Calendar
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1480, 688);
            this.Controls.Add(this.CmdDrive);
            this.Controls.Add(this.CmdExcel);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblBasis);
            this.Controls.Add(this.LblGrandYield);
            this.Controls.Add(this.LblGrandYieldCap);
            this.Controls.Add(this.LblGrand);
            this.Controls.Add(this.LblGrandCap);
            this.Controls.Add(this.LblTotCur);
            this.Controls.Add(this.LblTotCurCap);
            this.Controls.Add(this.LblTotInv);
            this.Controls.Add(this.LblTotInvCap);
            this.Controls.Add(this.LblTotUnit);
            this.Controls.Add(this.LblTotUnitCap);
            this.Controls.Add(this.gvForecast);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Forecast_Dividend_Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Forecast Dividend Calendar";
            this.Load += new System.EventHandler(this.ETF_Stocks_Forecast_Dividend_Calendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvForecast)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.CheckBox chkMainOnly;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvForecast;
        public System.Windows.Forms.Label LblTotUnitCap;
        public System.Windows.Forms.Label LblTotUnit;
        public System.Windows.Forms.Label LblTotInvCap;
        public System.Windows.Forms.Label LblTotInv;
        public System.Windows.Forms.Label LblTotCurCap;
        public System.Windows.Forms.Label LblTotCur;
        public System.Windows.Forms.Label LblGrandCap;
        public System.Windows.Forms.Label LblGrand;
        public System.Windows.Forms.Label LblGrandYieldCap;
        public System.Windows.Forms.Label LblGrandYield;
        public System.Windows.Forms.Label LblBasis;
        public System.Windows.Forms.Button CmdExcel;
        public System.Windows.Forms.Button CmdDrive;
        public System.Windows.Forms.Button CmdBack;
    }
}
