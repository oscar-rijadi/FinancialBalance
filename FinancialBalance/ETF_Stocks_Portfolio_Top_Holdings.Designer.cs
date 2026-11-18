namespace FinancialBalance
{
    partial class ETF_Stocks_Portfolio_Top_Holdings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Portfolio_Top_Holdings));
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbTicker = new System.Windows.Forms.ComboBox();
            this.CmdTop = new System.Windows.Forms.Button();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvSummary = new System.Windows.Forms.DataGridView();
            this.LblTotInvCap = new System.Windows.Forms.Label();
            this.LblTotInv = new System.Windows.Forms.Label();
            this.LblTotCurCap = new System.Windows.Forms.Label();
            this.LblTotCur = new System.Windows.Forms.Label();
            this.LblTotShareCap = new System.Windows.Forms.Label();
            this.LblTotShare = new System.Windows.Forms.Label();
            this.LblCurrency = new System.Windows.Forms.Label();
            this.LblTopNote = new System.Windows.Forms.Label();
            this.gvTop = new System.Windows.Forms.DataGridView();
            this.LblTotTopPctCap = new System.Windows.Forms.Label();
            this.LblTotTopPct = new System.Windows.Forms.Label();
            this.LblTotTopAudCap = new System.Windows.Forms.Label();
            this.LblTotTopAud = new System.Windows.Forms.Label();
            this.CmdExcel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTop)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 20);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(1120, 41);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK PORTFOLIO TOP HOLDINGS";
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
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(495, 76);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 22);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Full Ticker";
            //
            // CmbTicker
            //
            this.CmbTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTicker.FormattingEnabled = true;
            this.CmbTicker.Location = new System.Drawing.Point(580, 74);
            this.CmbTicker.Name = "CmbTicker";
            this.CmbTicker.Size = new System.Drawing.Size(160, 22);
            this.CmbTicker.TabIndex = 5;
            this.CmbTicker.SelectedIndexChanged += new System.EventHandler(this.CmbTicker_SelectedIndexChanged);
            //
            // CmdTop
            //
            this.CmdTop.BackColor = System.Drawing.SystemColors.Control;
            this.CmdTop.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdTop.Location = new System.Drawing.Point(760, 71);
            this.CmdTop.Name = "CmdTop";
            this.CmdTop.Size = new System.Drawing.Size(160, 27);
            this.CmdTop.TabIndex = 6;
            this.CmdTop.Text = "Get &Top 10 Holdings";
            this.CmdTop.UseVisualStyleBackColor = false;
            this.CmdTop.Click += new System.EventHandler(this.CmdTop_Click);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblNote.Location = new System.Drawing.Point(19, 104);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1121, 20);
            this.LblNote.TabIndex = 7;
            //
            // gvSummary
            //
            this.gvSummary.AllowUserToAddRows = false;
            this.gvSummary.AllowUserToDeleteRows = false;
            this.gvSummary.AllowUserToResizeRows = false;
            this.gvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSummary.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvSummary.Location = new System.Drawing.Point(19, 128);
            this.gvSummary.MultiSelect = false;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.ReadOnly = true;
            this.gvSummary.RowHeadersVisible = false;
            this.gvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSummary.Size = new System.Drawing.Size(1121, 200);
            this.gvSummary.TabIndex = 8;
            //
            // LblTotInvCap
            //
            this.LblTotInvCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotInvCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotInvCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotInvCap.Location = new System.Drawing.Point(19, 336);
            this.LblTotInvCap.Name = "LblTotInvCap";
            this.LblTotInvCap.Size = new System.Drawing.Size(125, 20);
            this.LblTotInvCap.TabIndex = 9;
            this.LblTotInvCap.Text = "Total Investment";
            //
            // LblTotInv
            //
            this.LblTotInv.BackColor = System.Drawing.Color.Transparent;
            this.LblTotInv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotInv.ForeColor = System.Drawing.Color.Black;
            this.LblTotInv.Location = new System.Drawing.Point(146, 336);
            this.LblTotInv.Name = "LblTotInv";
            this.LblTotInv.Size = new System.Drawing.Size(150, 20);
            this.LblTotInv.TabIndex = 10;
            this.LblTotInv.Text = "$0.00";
            //
            // LblTotCurCap
            //
            this.LblTotCurCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotCurCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotCurCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotCurCap.Location = new System.Drawing.Point(310, 336);
            this.LblTotCurCap.Name = "LblTotCurCap";
            this.LblTotCurCap.Size = new System.Drawing.Size(160, 20);
            this.LblTotCurCap.TabIndex = 11;
            this.LblTotCurCap.Text = "Total Current Amount";
            //
            // LblTotCur
            //
            this.LblTotCur.BackColor = System.Drawing.Color.Transparent;
            this.LblTotCur.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotCur.ForeColor = System.Drawing.Color.Black;
            this.LblTotCur.Location = new System.Drawing.Point(472, 336);
            this.LblTotCur.Name = "LblTotCur";
            this.LblTotCur.Size = new System.Drawing.Size(150, 20);
            this.LblTotCur.TabIndex = 12;
            this.LblTotCur.Text = "$0.00";
            //
            // LblTotShareCap
            //
            this.LblTotShareCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotShareCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotShareCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotShareCap.Location = new System.Drawing.Point(636, 336);
            this.LblTotShareCap.Name = "LblTotShareCap";
            this.LblTotShareCap.Size = new System.Drawing.Size(210, 20);
            this.LblTotShareCap.TabIndex = 13;
            this.LblTotShareCap.Text = "Percentage from whole portfolio";
            //
            // LblTotShare
            //
            this.LblTotShare.BackColor = System.Drawing.Color.Transparent;
            this.LblTotShare.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotShare.ForeColor = System.Drawing.Color.Black;
            this.LblTotShare.Location = new System.Drawing.Point(848, 336);
            this.LblTotShare.Name = "LblTotShare";
            this.LblTotShare.Size = new System.Drawing.Size(100, 20);
            this.LblTotShare.TabIndex = 14;
            this.LblTotShare.Text = "0.00 %";
            //
            // LblCurrency
            //
            this.LblCurrency.BackColor = System.Drawing.Color.Transparent;
            this.LblCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrency.ForeColor = System.Drawing.Color.DimGray;
            this.LblCurrency.Location = new System.Drawing.Point(19, 358);
            this.LblCurrency.Name = "LblCurrency";
            this.LblCurrency.Size = new System.Drawing.Size(1121, 18);
            this.LblCurrency.TabIndex = 15;
            this.LblCurrency.Text = "All amounts are in Australian Dollar (AUD)";
            //
            // LblTopNote
            //
            this.LblTopNote.BackColor = System.Drawing.Color.Transparent;
            this.LblTopNote.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTopNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblTopNote.Location = new System.Drawing.Point(19, 380);
            this.LblTopNote.Name = "LblTopNote";
            this.LblTopNote.Size = new System.Drawing.Size(1121, 34);
            this.LblTopNote.TabIndex = 16;
            //
            // gvTop
            //
            this.gvTop.AllowUserToAddRows = false;
            this.gvTop.AllowUserToDeleteRows = false;
            this.gvTop.AllowUserToResizeRows = false;
            this.gvTop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTop.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTop.Location = new System.Drawing.Point(19, 416);
            this.gvTop.MultiSelect = false;
            this.gvTop.Name = "gvTop";
            this.gvTop.ReadOnly = true;
            this.gvTop.RowHeadersVisible = false;
            this.gvTop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTop.Size = new System.Drawing.Size(1121, 246);
            this.gvTop.TabIndex = 17;
            //
            // LblTotTopPctCap
            //
            this.LblTotTopPctCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotTopPctCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotTopPctCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotTopPctCap.Location = new System.Drawing.Point(180, 678);
            this.LblTotTopPctCap.Name = "LblTotTopPctCap";
            this.LblTotTopPctCap.Size = new System.Drawing.Size(160, 20);
            this.LblTotTopPctCap.TabIndex = 22;
            this.LblTotTopPctCap.Text = "Total Allocation (%)";
            this.LblTotTopPctCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotTopPct
            //
            this.LblTotTopPct.BackColor = System.Drawing.Color.Transparent;
            this.LblTotTopPct.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotTopPct.ForeColor = System.Drawing.Color.Black;
            this.LblTotTopPct.Location = new System.Drawing.Point(344, 678);
            this.LblTotTopPct.Name = "LblTotTopPct";
            this.LblTotTopPct.Size = new System.Drawing.Size(100, 20);
            this.LblTotTopPct.TabIndex = 23;
            this.LblTotTopPct.Text = "0.00 %";
            this.LblTotTopPct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LblTotTopAudCap
            //
            this.LblTotTopAudCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotTopAudCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotTopAudCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotTopAudCap.Location = new System.Drawing.Point(452, 678);
            this.LblTotTopAudCap.Name = "LblTotTopAudCap";
            this.LblTotTopAudCap.Size = new System.Drawing.Size(170, 20);
            this.LblTotTopAudCap.TabIndex = 20;
            this.LblTotTopAudCap.Text = "Total Allocation (AUD)";
            this.LblTotTopAudCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotTopAud
            //
            this.LblTotTopAud.BackColor = System.Drawing.Color.Transparent;
            this.LblTotTopAud.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotTopAud.ForeColor = System.Drawing.Color.Black;
            this.LblTotTopAud.Location = new System.Drawing.Point(626, 678);
            this.LblTotTopAud.Name = "LblTotTopAud";
            this.LblTotTopAud.Size = new System.Drawing.Size(140, 20);
            this.LblTotTopAud.TabIndex = 21;
            this.LblTotTopAud.Text = "$0.00";
            this.LblTotTopAud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CmdExcel
            //
            this.CmdExcel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdExcel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdExcel.Location = new System.Drawing.Point(19, 674);
            this.CmdExcel.Name = "CmdExcel";
            this.CmdExcel.Size = new System.Drawing.Size(140, 28);
            this.CmdExcel.TabIndex = 18;
            this.CmdExcel.Text = "Generate to &Excel";
            this.CmdExcel.UseVisualStyleBackColor = false;
            this.CmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(1030, 674);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 19;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Portfolio_Top_Holdings
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1160, 714);
            this.ControlBox = false;
            this.Controls.Add(this.LblTotTopPct);
            this.Controls.Add(this.LblTotTopPctCap);
            this.Controls.Add(this.LblTotTopAud);
            this.Controls.Add(this.LblTotTopAudCap);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdExcel);
            this.Controls.Add(this.gvTop);
            this.Controls.Add(this.LblTopNote);
            this.Controls.Add(this.LblCurrency);
            this.Controls.Add(this.LblTotShare);
            this.Controls.Add(this.LblTotShareCap);
            this.Controls.Add(this.LblTotCur);
            this.Controls.Add(this.LblTotCurCap);
            this.Controls.Add(this.LblTotInv);
            this.Controls.Add(this.LblTotInvCap);
            this.Controls.Add(this.gvSummary);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmdTop);
            this.Controls.Add(this.CmbTicker);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Portfolio_Top_Holdings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Portfolio Top Holdings";
            this.Load += new System.EventHandler(this.ETF_Stocks_Portfolio_Top_Holdings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.CheckBox chkMainOnly;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbTicker;
        public System.Windows.Forms.Button CmdTop;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvSummary;
        public System.Windows.Forms.Label LblTotInvCap;
        public System.Windows.Forms.Label LblTotInv;
        public System.Windows.Forms.Label LblTotCurCap;
        public System.Windows.Forms.Label LblTotCur;
        public System.Windows.Forms.Label LblTotShareCap;
        public System.Windows.Forms.Label LblTotShare;
        public System.Windows.Forms.Label LblCurrency;
        public System.Windows.Forms.Label LblTopNote;
        private System.Windows.Forms.DataGridView gvTop;
        public System.Windows.Forms.Label LblTotTopPctCap;
        public System.Windows.Forms.Label LblTotTopPct;
        public System.Windows.Forms.Label LblTotTopAudCap;
        public System.Windows.Forms.Label LblTotTopAud;
        public System.Windows.Forms.Button CmdExcel;
        public System.Windows.Forms.Button CmdBack;
    }
}
