namespace FinancialBalance
{
    partial class ETF_Stocks_Dividend_History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Dividend_History));
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbTicker = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbFinYear = new System.Windows.Forms.ComboBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvSummary = new System.Windows.Forms.DataGridView();
            this.gvDetail = new System.Windows.Forms.DataGridView();
            this.LblAgg1Cap = new System.Windows.Forms.Label();
            this.LblAgg1 = new System.Windows.Forms.Label();
            this.LblAgg2Cap = new System.Windows.Forms.Label();
            this.LblAgg2 = new System.Windows.Forms.Label();
            this.LblAgg3Cap = new System.Windows.Forms.Label();
            this.LblAgg3 = new System.Windows.Forms.Label();
            this.LblAgg4Cap = new System.Windows.Forms.Label();
            this.LblAgg4 = new System.Windows.Forms.Label();
            this.LblAgg5Cap = new System.Windows.Forms.Label();
            this.LblAgg5 = new System.Windows.Forms.Label();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(120, 18);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(700, 38);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK DIVIDEND HISTORY";
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 70);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(90, 22);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Portfolio";
            //
            // CmbPortfolio
            //
            this.CmbPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPortfolio.FormattingEnabled = true;
            this.CmbPortfolio.Location = new System.Drawing.Point(115, 68);
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
            this.chkMainOnly.ForeColor = System.Drawing.Color.Black;
            this.chkMainOnly.Location = new System.Drawing.Point(390, 68);
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
            this.Label2.Location = new System.Drawing.Point(19, 98);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(90, 22);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Full Ticker";
            //
            // CmbTicker
            //
            this.CmbTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTicker.FormattingEnabled = true;
            this.CmbTicker.Location = new System.Drawing.Point(115, 96);
            this.CmbTicker.Name = "CmbTicker";
            this.CmbTicker.Size = new System.Drawing.Size(260, 22);
            this.CmbTicker.TabIndex = 5;
            this.CmbTicker.SelectedIndexChanged += new System.EventHandler(this.CmbTicker_SelectedIndexChanged);
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(19, 126);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(90, 22);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Financial Year";
            //
            // CmbFinYear
            //
            this.CmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinYear.FormattingEnabled = true;
            this.CmbFinYear.Location = new System.Drawing.Point(115, 124);
            this.CmbFinYear.Name = "CmbFinYear";
            this.CmbFinYear.Size = new System.Drawing.Size(260, 22);
            this.CmbFinYear.TabIndex = 7;
            this.CmbFinYear.SelectedIndexChanged += new System.EventHandler(this.CmbFinYear_SelectedIndexChanged);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 154);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(900, 20);
            this.LblNote.TabIndex = 8;
            //
            // gvSummary
            //
            this.gvSummary.AllowUserToAddRows = false;
            this.gvSummary.AllowUserToDeleteRows = false;
            this.gvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSummary.Location = new System.Drawing.Point(19, 180);
            this.gvSummary.MultiSelect = false;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.ReadOnly = true;
            this.gvSummary.RowHeadersVisible = false;
            this.gvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSummary.Size = new System.Drawing.Size(900, 280);
            this.gvSummary.TabIndex = 9;
            //
            // gvDetail
            //
            this.gvDetail.AllowUserToAddRows = false;
            this.gvDetail.AllowUserToDeleteRows = false;
            this.gvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDetail.Location = new System.Drawing.Point(19, 180);
            this.gvDetail.MultiSelect = false;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.ReadOnly = true;
            this.gvDetail.RowHeadersVisible = false;
            this.gvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDetail.Size = new System.Drawing.Size(900, 280);
            this.gvDetail.TabIndex = 10;
            this.gvDetail.Visible = false;
            //
            // LblAgg1Cap
            //
            this.LblAgg1Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg1Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg1Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg1Cap.Location = new System.Drawing.Point(19, 472);
            this.LblAgg1Cap.Name = "LblAgg1Cap";
            this.LblAgg1Cap.Size = new System.Drawing.Size(260, 20);
            this.LblAgg1Cap.TabIndex = 11;
            //
            // LblAgg1
            //
            this.LblAgg1.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg1.ForeColor = System.Drawing.Color.Black;
            this.LblAgg1.Location = new System.Drawing.Point(285, 472);
            this.LblAgg1.Name = "LblAgg1";
            this.LblAgg1.Size = new System.Drawing.Size(160, 20);
            this.LblAgg1.TabIndex = 12;
            this.LblAgg1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg2Cap
            //
            this.LblAgg2Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg2Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg2Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg2Cap.Location = new System.Drawing.Point(19, 496);
            this.LblAgg2Cap.Name = "LblAgg2Cap";
            this.LblAgg2Cap.Size = new System.Drawing.Size(260, 20);
            this.LblAgg2Cap.TabIndex = 13;
            //
            // LblAgg2
            //
            this.LblAgg2.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg2.ForeColor = System.Drawing.Color.Black;
            this.LblAgg2.Location = new System.Drawing.Point(285, 496);
            this.LblAgg2.Name = "LblAgg2";
            this.LblAgg2.Size = new System.Drawing.Size(160, 20);
            this.LblAgg2.TabIndex = 14;
            this.LblAgg2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg3Cap
            //
            this.LblAgg3Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg3Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg3Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg3Cap.Location = new System.Drawing.Point(19, 520);
            this.LblAgg3Cap.Name = "LblAgg3Cap";
            this.LblAgg3Cap.Size = new System.Drawing.Size(260, 20);
            this.LblAgg3Cap.TabIndex = 15;
            //
            // LblAgg3
            //
            this.LblAgg3.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg3.ForeColor = System.Drawing.Color.Black;
            this.LblAgg3.Location = new System.Drawing.Point(285, 520);
            this.LblAgg3.Name = "LblAgg3";
            this.LblAgg3.Size = new System.Drawing.Size(160, 20);
            this.LblAgg3.TabIndex = 16;
            this.LblAgg3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg4Cap
            //
            this.LblAgg4Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg4Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg4Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg4Cap.Location = new System.Drawing.Point(19, 544);
            this.LblAgg4Cap.Name = "LblAgg4Cap";
            this.LblAgg4Cap.Size = new System.Drawing.Size(260, 20);
            this.LblAgg4Cap.TabIndex = 17;
            //
            // LblAgg4
            //
            this.LblAgg4.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg4.ForeColor = System.Drawing.Color.Black;
            this.LblAgg4.Location = new System.Drawing.Point(285, 544);
            this.LblAgg4.Name = "LblAgg4";
            this.LblAgg4.Size = new System.Drawing.Size(160, 20);
            this.LblAgg4.TabIndex = 18;
            this.LblAgg4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg5Cap
            //
            this.LblAgg5Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg5Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg5Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg5Cap.Location = new System.Drawing.Point(19, 568);
            this.LblAgg5Cap.Name = "LblAgg5Cap";
            this.LblAgg5Cap.Size = new System.Drawing.Size(260, 20);
            this.LblAgg5Cap.TabIndex = 19;
            //
            // LblAgg5
            //
            this.LblAgg5.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg5.ForeColor = System.Drawing.Color.Black;
            this.LblAgg5.Location = new System.Drawing.Point(285, 568);
            this.LblAgg5.Name = "LblAgg5";
            this.LblAgg5.Size = new System.Drawing.Size(160, 20);
            this.LblAgg5.TabIndex = 20;
            this.LblAgg5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(834, 600);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 11;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Dividend_History
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(940, 640);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblAgg1);
            this.Controls.Add(this.LblAgg1Cap);
            this.Controls.Add(this.LblAgg2);
            this.Controls.Add(this.LblAgg2Cap);
            this.Controls.Add(this.LblAgg3);
            this.Controls.Add(this.LblAgg3Cap);
            this.Controls.Add(this.LblAgg4);
            this.Controls.Add(this.LblAgg4Cap);
            this.Controls.Add(this.LblAgg5);
            this.Controls.Add(this.LblAgg5Cap);
            this.Controls.Add(this.gvDetail);
            this.Controls.Add(this.gvSummary);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmbFinYear);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.CmbTicker);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Dividend_History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Dividend History";
            this.Load += new System.EventHandler(this.ETF_Stocks_Dividend_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.CheckBox chkMainOnly;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbTicker;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbFinYear;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvSummary;
        private System.Windows.Forms.DataGridView gvDetail;
        public System.Windows.Forms.Label LblAgg1Cap;
        public System.Windows.Forms.Label LblAgg1;
        public System.Windows.Forms.Label LblAgg2Cap;
        public System.Windows.Forms.Label LblAgg2;
        public System.Windows.Forms.Label LblAgg3Cap;
        public System.Windows.Forms.Label LblAgg3;
        public System.Windows.Forms.Label LblAgg4Cap;
        public System.Windows.Forms.Label LblAgg4;
        public System.Windows.Forms.Label LblAgg5Cap;
        public System.Windows.Forms.Label LblAgg5;
        public System.Windows.Forms.Button CmdBack;
    }
}
