namespace FinancialBalance
{
    partial class ETF_Stocks_Portfolio_Summary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Portfolio_Summary));
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.gvSummary = new System.Windows.Forms.DataGridView();
            this.LblNote = new System.Windows.Forms.Label();
            this.LblTotInv = new System.Windows.Forms.Label();
            this.LblTotInvCap = new System.Windows.Forms.Label();
            this.LblTotCur = new System.Windows.Forms.Label();
            this.LblTotCurCap = new System.Windows.Forms.Label();
            this.LblTotPL = new System.Windows.Forms.Label();
            this.LblTotPLCap = new System.Windows.Forms.Label();
            this.LblTotPct = new System.Windows.Forms.Label();
            this.LblTotPctCap = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbTicker = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.gvDetail = new System.Windows.Forms.DataGridView();
            this.LblDTotUnit = new System.Windows.Forms.Label();
            this.LblDTotUnitCap = new System.Windows.Forms.Label();
            this.LblDGrandTCB = new System.Windows.Forms.Label();
            this.LblDGrandTCBCap = new System.Windows.Forms.Label();
            this.LblDGrandTRCB = new System.Windows.Forms.Label();
            this.LblDGrandTRCBCap = new System.Windows.Forms.Label();
            this.LblDTotPL = new System.Windows.Forms.Label();
            this.LblDTotPLCap = new System.Windows.Forms.Label();
            this.LblDTotPct = new System.Windows.Forms.Label();
            this.LblDTotPctCap = new System.Windows.Forms.Label();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(140, 20);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(660, 41);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK PORTFOLIO SUMMARY";
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
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblNote.Location = new System.Drawing.Point(492, 78);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(425, 20);
            this.LblNote.TabIndex = 3;
            this.LblNote.Text = "Unsold holdings only";
            //
            // gvSummary
            //
            this.gvSummary.AllowUserToAddRows = false;
            this.gvSummary.AllowUserToDeleteRows = false;
            this.gvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSummary.Location = new System.Drawing.Point(19, 134);
            this.gvSummary.MultiSelect = false;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.ReadOnly = true;
            this.gvSummary.RowHeadersVisible = false;
            this.gvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSummary.Size = new System.Drawing.Size(900, 300);
            this.gvSummary.TabIndex = 4;
            //
            // LblTotInvCap
            //
            this.LblTotInvCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotInvCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotInvCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotInvCap.Location = new System.Drawing.Point(360, 444);
            this.LblTotInvCap.Name = "LblTotInvCap";
            this.LblTotInvCap.Size = new System.Drawing.Size(320, 20);
            this.LblTotInvCap.TabIndex = 10;
            this.LblTotInvCap.Text = "Total Portfolio Investment";
            this.LblTotInvCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotInv
            //
            this.LblTotInv.BackColor = System.Drawing.Color.Transparent;
            this.LblTotInv.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotInv.ForeColor = System.Drawing.Color.Black;
            this.LblTotInv.Location = new System.Drawing.Point(690, 444);
            this.LblTotInv.Name = "LblTotInv";
            this.LblTotInv.Size = new System.Drawing.Size(210, 20);
            this.LblTotInv.TabIndex = 11;
            this.LblTotInv.Text = "0.00";
            this.LblTotInv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotCurCap
            //
            this.LblTotCurCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotCurCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotCurCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotCurCap.Location = new System.Drawing.Point(360, 468);
            this.LblTotCurCap.Name = "LblTotCurCap";
            this.LblTotCurCap.Size = new System.Drawing.Size(320, 20);
            this.LblTotCurCap.TabIndex = 12;
            this.LblTotCurCap.Text = "Total Portfolio Current Amount";
            this.LblTotCurCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotCur
            //
            this.LblTotCur.BackColor = System.Drawing.Color.Transparent;
            this.LblTotCur.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotCur.ForeColor = System.Drawing.Color.Black;
            this.LblTotCur.Location = new System.Drawing.Point(690, 468);
            this.LblTotCur.Name = "LblTotCur";
            this.LblTotCur.Size = new System.Drawing.Size(210, 20);
            this.LblTotCur.TabIndex = 13;
            this.LblTotCur.Text = "0.00";
            this.LblTotCur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotPLCap
            //
            this.LblTotPLCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotPLCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotPLCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotPLCap.Location = new System.Drawing.Point(360, 492);
            this.LblTotPLCap.Name = "LblTotPLCap";
            this.LblTotPLCap.Size = new System.Drawing.Size(320, 20);
            this.LblTotPLCap.TabIndex = 14;
            this.LblTotPLCap.Text = "Total Portfolio Current Real Profit/Loss";
            this.LblTotPLCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotPL
            //
            this.LblTotPL.BackColor = System.Drawing.Color.Transparent;
            this.LblTotPL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotPL.ForeColor = System.Drawing.Color.Black;
            this.LblTotPL.Location = new System.Drawing.Point(690, 492);
            this.LblTotPL.Name = "LblTotPL";
            this.LblTotPL.Size = new System.Drawing.Size(210, 20);
            this.LblTotPL.TabIndex = 15;
            this.LblTotPL.Text = "0.00";
            this.LblTotPL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotPctCap
            //
            this.LblTotPctCap.BackColor = System.Drawing.Color.Transparent;
            this.LblTotPctCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotPctCap.ForeColor = System.Drawing.Color.Black;
            this.LblTotPctCap.Location = new System.Drawing.Point(360, 516);
            this.LblTotPctCap.Name = "LblTotPctCap";
            this.LblTotPctCap.Size = new System.Drawing.Size(320, 20);
            this.LblTotPctCap.TabIndex = 16;
            this.LblTotPctCap.Text = "Percentage Portfolio Current Real Profit/Loss";
            this.LblTotPctCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblTotPct
            //
            this.LblTotPct.BackColor = System.Drawing.Color.Transparent;
            this.LblTotPct.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotPct.ForeColor = System.Drawing.Color.Black;
            this.LblTotPct.Location = new System.Drawing.Point(690, 516);
            this.LblTotPct.Name = "LblTotPct";
            this.LblTotPct.Size = new System.Drawing.Size(210, 20);
            this.LblTotPct.TabIndex = 17;
            this.LblTotPct.Text = "0.00";
            this.LblTotPct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(19, 104);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 22);
            this.Label2.TabIndex = 30;
            this.Label2.Text = "Full Ticker";
            //
            // CmbTicker
            //
            this.CmbTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTicker.FormattingEnabled = true;
            this.CmbTicker.Location = new System.Drawing.Point(105, 102);
            this.CmbTicker.Name = "CmbTicker";
            this.CmbTicker.Size = new System.Drawing.Size(260, 22);
            this.CmbTicker.TabIndex = 31;
            this.CmbTicker.SelectedIndexChanged += new System.EventHandler(this.CmbTicker_SelectedIndexChanged);
            //
            // chkMainOnly
            //
            this.chkMainOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkMainOnly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMainOnly.Location = new System.Drawing.Point(380, 74);
            this.chkMainOnly.Name = "chkMainOnly";
            this.chkMainOnly.Size = new System.Drawing.Size(100, 24);
            this.chkMainOnly.TabIndex = 43;
            this.chkMainOnly.Text = "Main Only";
            this.chkMainOnly.UseVisualStyleBackColor = false;
            this.chkMainOnly.CheckedChanged += new System.EventHandler(this.chkMainOnly_CheckedChanged);
            //
            // gvDetail
            //
            this.gvDetail.AllowUserToAddRows = false;
            this.gvDetail.AllowUserToDeleteRows = false;
            this.gvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDetail.Location = new System.Drawing.Point(19, 134);
            this.gvDetail.MultiSelect = false;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.ReadOnly = true;
            this.gvDetail.RowHeadersVisible = false;
            this.gvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDetail.Size = new System.Drawing.Size(900, 300);
            this.gvDetail.TabIndex = 32;
            this.gvDetail.Visible = false;
            //
            // LblDTotUnitCap
            //
            this.LblDTotUnitCap.BackColor = System.Drawing.Color.Transparent;
            this.LblDTotUnitCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDTotUnitCap.ForeColor = System.Drawing.Color.Black;
            this.LblDTotUnitCap.Location = new System.Drawing.Point(360, 444);
            this.LblDTotUnitCap.Name = "LblDTotUnitCap";
            this.LblDTotUnitCap.Size = new System.Drawing.Size(320, 20);
            this.LblDTotUnitCap.TabIndex = 33;
            this.LblDTotUnitCap.Text = "Total Unit";
            this.LblDTotUnitCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDTotUnit
            //
            this.LblDTotUnit.BackColor = System.Drawing.Color.Transparent;
            this.LblDTotUnit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDTotUnit.ForeColor = System.Drawing.Color.Black;
            this.LblDTotUnit.Location = new System.Drawing.Point(690, 444);
            this.LblDTotUnit.Name = "LblDTotUnit";
            this.LblDTotUnit.Size = new System.Drawing.Size(210, 20);
            this.LblDTotUnit.TabIndex = 34;
            this.LblDTotUnit.Text = "0.00";
            this.LblDTotUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDGrandTCBCap
            //
            this.LblDGrandTCBCap.BackColor = System.Drawing.Color.Transparent;
            this.LblDGrandTCBCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDGrandTCBCap.ForeColor = System.Drawing.Color.Black;
            this.LblDGrandTCBCap.Location = new System.Drawing.Point(360, 468);
            this.LblDGrandTCBCap.Name = "LblDGrandTCBCap";
            this.LblDGrandTCBCap.Size = new System.Drawing.Size(320, 20);
            this.LblDGrandTCBCap.TabIndex = 35;
            this.LblDGrandTCBCap.Text = "Grand Total Cost Base";
            this.LblDGrandTCBCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDGrandTCB
            //
            this.LblDGrandTCB.BackColor = System.Drawing.Color.Transparent;
            this.LblDGrandTCB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDGrandTCB.ForeColor = System.Drawing.Color.Black;
            this.LblDGrandTCB.Location = new System.Drawing.Point(690, 468);
            this.LblDGrandTCB.Name = "LblDGrandTCB";
            this.LblDGrandTCB.Size = new System.Drawing.Size(210, 20);
            this.LblDGrandTCB.TabIndex = 36;
            this.LblDGrandTCB.Text = "0.00";
            this.LblDGrandTCB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDGrandTRCBCap
            //
            this.LblDGrandTRCBCap.BackColor = System.Drawing.Color.Transparent;
            this.LblDGrandTRCBCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDGrandTRCBCap.ForeColor = System.Drawing.Color.Black;
            this.LblDGrandTRCBCap.Location = new System.Drawing.Point(360, 492);
            this.LblDGrandTRCBCap.Name = "LblDGrandTRCBCap";
            this.LblDGrandTRCBCap.Size = new System.Drawing.Size(320, 20);
            this.LblDGrandTRCBCap.TabIndex = 37;
            this.LblDGrandTRCBCap.Text = "Grand Total Real Cost Base";
            this.LblDGrandTRCBCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDGrandTRCB
            //
            this.LblDGrandTRCB.BackColor = System.Drawing.Color.Transparent;
            this.LblDGrandTRCB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDGrandTRCB.ForeColor = System.Drawing.Color.Black;
            this.LblDGrandTRCB.Location = new System.Drawing.Point(690, 492);
            this.LblDGrandTRCB.Name = "LblDGrandTRCB";
            this.LblDGrandTRCB.Size = new System.Drawing.Size(210, 20);
            this.LblDGrandTRCB.TabIndex = 38;
            this.LblDGrandTRCB.Text = "0.00";
            this.LblDGrandTRCB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDTotPLCap
            //
            this.LblDTotPLCap.BackColor = System.Drawing.Color.Transparent;
            this.LblDTotPLCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDTotPLCap.ForeColor = System.Drawing.Color.Black;
            this.LblDTotPLCap.Location = new System.Drawing.Point(360, 516);
            this.LblDTotPLCap.Name = "LblDTotPLCap";
            this.LblDTotPLCap.Size = new System.Drawing.Size(320, 20);
            this.LblDTotPLCap.TabIndex = 39;
            this.LblDTotPLCap.Text = "Total Real Current Profit/Loss";
            this.LblDTotPLCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDTotPL
            //
            this.LblDTotPL.BackColor = System.Drawing.Color.Transparent;
            this.LblDTotPL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDTotPL.ForeColor = System.Drawing.Color.Black;
            this.LblDTotPL.Location = new System.Drawing.Point(690, 516);
            this.LblDTotPL.Name = "LblDTotPL";
            this.LblDTotPL.Size = new System.Drawing.Size(210, 20);
            this.LblDTotPL.TabIndex = 40;
            this.LblDTotPL.Text = "0.00";
            this.LblDTotPL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDTotPctCap
            //
            this.LblDTotPctCap.BackColor = System.Drawing.Color.Transparent;
            this.LblDTotPctCap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDTotPctCap.ForeColor = System.Drawing.Color.Black;
            this.LblDTotPctCap.Location = new System.Drawing.Point(360, 540);
            this.LblDTotPctCap.Name = "LblDTotPctCap";
            this.LblDTotPctCap.Size = new System.Drawing.Size(320, 20);
            this.LblDTotPctCap.TabIndex = 41;
            this.LblDTotPctCap.Text = "Percentage Total Real Current Profit/Loss";
            this.LblDTotPctCap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblDTotPct
            //
            this.LblDTotPct.BackColor = System.Drawing.Color.Transparent;
            this.LblDTotPct.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDTotPct.ForeColor = System.Drawing.Color.Black;
            this.LblDTotPct.Location = new System.Drawing.Point(690, 540);
            this.LblDTotPct.Name = "LblDTotPct";
            this.LblDTotPct.Size = new System.Drawing.Size(210, 20);
            this.LblDTotPct.TabIndex = 42;
            this.LblDTotPct.Text = "0.00";
            this.LblDTotPct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(425, 578);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 27);
            this.CmdBack.TabIndex = 5;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Portfolio_Summary
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(940, 625);
            this.ControlBox = false;
            this.Controls.Add(this.LblTotInv);
            this.Controls.Add(this.LblTotInvCap);
            this.Controls.Add(this.LblTotCur);
            this.Controls.Add(this.LblTotCurCap);
            this.Controls.Add(this.LblTotPL);
            this.Controls.Add(this.LblTotPLCap);
            this.Controls.Add(this.LblTotPct);
            this.Controls.Add(this.LblTotPctCap);
            this.Controls.Add(this.LblDTotUnit);
            this.Controls.Add(this.LblDTotUnitCap);
            this.Controls.Add(this.LblDGrandTCB);
            this.Controls.Add(this.LblDGrandTCBCap);
            this.Controls.Add(this.LblDGrandTRCB);
            this.Controls.Add(this.LblDGrandTRCBCap);
            this.Controls.Add(this.LblDTotPL);
            this.Controls.Add(this.LblDTotPLCap);
            this.Controls.Add(this.LblDTotPct);
            this.Controls.Add(this.LblDTotPctCap);
            this.Controls.Add(this.gvDetail);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbTicker);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.gvSummary);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Portfolio_Summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Portfolio Summary";
            this.Load += new System.EventHandler(this.ETF_Stocks_Portfolio_Summary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvSummary;
        public System.Windows.Forms.Label LblTotInv;
        public System.Windows.Forms.Label LblTotInvCap;
        public System.Windows.Forms.Label LblTotCur;
        public System.Windows.Forms.Label LblTotCurCap;
        public System.Windows.Forms.Label LblTotPL;
        public System.Windows.Forms.Label LblTotPLCap;
        public System.Windows.Forms.Label LblTotPct;
        public System.Windows.Forms.Label LblTotPctCap;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbTicker;
        public System.Windows.Forms.CheckBox chkMainOnly;
        private System.Windows.Forms.DataGridView gvDetail;
        public System.Windows.Forms.Label LblDTotUnit;
        public System.Windows.Forms.Label LblDTotUnitCap;
        public System.Windows.Forms.Label LblDGrandTCB;
        public System.Windows.Forms.Label LblDGrandTCBCap;
        public System.Windows.Forms.Label LblDGrandTRCB;
        public System.Windows.Forms.Label LblDGrandTRCBCap;
        public System.Windows.Forms.Label LblDTotPL;
        public System.Windows.Forms.Label LblDTotPLCap;
        public System.Windows.Forms.Label LblDTotPct;
        public System.Windows.Forms.Label LblDTotPctCap;
        public System.Windows.Forms.Button CmdBack;
    }
}
