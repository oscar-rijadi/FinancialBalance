namespace FinancialBalance
{
    partial class ETF_Stocks_Forecast_Dividend_Allocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Forecast_Dividend_Allocation));
            this.Label21 = new System.Windows.Forms.Label();
            this.Lbl_CmbTicker = new System.Windows.Forms.Label();
            this.CmbTicker = new System.Windows.Forms.ComboBox();
            this.Lbl_txtAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvAlloc = new System.Windows.Forms.DataGridView();
            this.Lbl_LblTotAmount = new System.Windows.Forms.Label();
            this.LblTotAmount = new System.Windows.Forms.Label();
            this.Lbl_LblTotYear = new System.Windows.Forms.Label();
            this.LblTotYear = new System.Windows.Forms.Label();
            this.Lbl_LblTotMonth = new System.Windows.Forms.Label();
            this.LblTotMonth = new System.Windows.Forms.Label();
            this.Lbl_LblYield = new System.Windows.Forms.Label();
            this.LblYield = new System.Windows.Forms.Label();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlloc)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 30);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(860, 32);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK FORECAST DIVIDEND ALLOCATION";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Lbl_CmbTicker
            //
            this.Lbl_CmbTicker.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbTicker.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbTicker.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbTicker.Location = new System.Drawing.Point(19, 82);
            this.Lbl_CmbTicker.Name = "Lbl_CmbTicker";
            this.Lbl_CmbTicker.Size = new System.Drawing.Size(150, 20);
            this.Lbl_CmbTicker.TabIndex = 1;
            this.Lbl_CmbTicker.Text = "Full Ticker";
            //
            // CmbTicker
            //
            this.CmbTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTicker.FormattingEnabled = true;
            this.CmbTicker.Location = new System.Drawing.Point(175, 80);
            this.CmbTicker.Name = "CmbTicker";
            this.CmbTicker.Size = new System.Drawing.Size(300, 22);
            this.CmbTicker.TabIndex = 2;
            //
            // Lbl_txtAmount
            //
            this.Lbl_txtAmount.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtAmount.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtAmount.Location = new System.Drawing.Point(19, 112);
            this.Lbl_txtAmount.Name = "Lbl_txtAmount";
            this.Lbl_txtAmount.Size = new System.Drawing.Size(150, 20);
            this.Lbl_txtAmount.TabIndex = 3;
            this.Lbl_txtAmount.Text = "Investment Amount";
            //
            // txtAmount
            //
            this.txtAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(175, 110);
            this.txtAmount.MaxLength = 15;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 20);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            //
            // CmdAdd
            //
            this.CmdAdd.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdAdd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdAdd.Location = new System.Drawing.Point(340, 109);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdAdd.Size = new System.Drawing.Size(85, 24);
            this.CmdAdd.TabIndex = 5;
            this.CmdAdd.Text = "&Add";
            this.CmdAdd.UseVisualStyleBackColor = false;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(435, 109);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(85, 24);
            this.CmdDel.TabIndex = 6;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdClear
            //
            this.CmdClear.BackColor = System.Drawing.SystemColors.Control;
            this.CmdClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdClear.Location = new System.Drawing.Point(530, 109);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdClear.Size = new System.Drawing.Size(85, 24);
            this.CmdClear.TabIndex = 7;
            this.CmdClear.Text = "Clear &All";
            this.CmdClear.UseVisualStyleBackColor = false;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblNote.Location = new System.Drawing.Point(19, 142);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(862, 20);
            this.LblNote.TabIndex = 8;
            this.LblNote.Text = "";
            //
            // gvAlloc
            //
            this.gvAlloc.AllowUserToAddRows = false;
            this.gvAlloc.AllowUserToDeleteRows = false;
            this.gvAlloc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAlloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAlloc.Location = new System.Drawing.Point(19, 166);
            this.gvAlloc.MultiSelect = false;
            this.gvAlloc.Name = "gvAlloc";
            this.gvAlloc.ReadOnly = true;
            this.gvAlloc.RowHeadersVisible = false;
            this.gvAlloc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAlloc.Size = new System.Drawing.Size(862, 360);
            this.gvAlloc.TabIndex = 9;
            this.gvAlloc.SelectionChanged += new System.EventHandler(this.gvAlloc_SelectionChanged);
            //
            // Lbl_LblTotAmount
            //
            this.Lbl_LblTotAmount.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotAmount.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotAmount.Location = new System.Drawing.Point(19, 546);
            this.Lbl_LblTotAmount.Name = "Lbl_LblTotAmount";
            this.Lbl_LblTotAmount.Size = new System.Drawing.Size(300, 20);
            this.Lbl_LblTotAmount.TabIndex = 10;
            this.Lbl_LblTotAmount.Text = "Total Investment Amount";
            //
            // LblTotAmount
            //
            this.LblTotAmount.BackColor = System.Drawing.Color.Transparent;
            this.LblTotAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotAmount.ForeColor = System.Drawing.Color.Black;
            this.LblTotAmount.Location = new System.Drawing.Point(329, 546);
            this.LblTotAmount.Name = "LblTotAmount";
            this.LblTotAmount.Size = new System.Drawing.Size(200, 20);
            this.LblTotAmount.TabIndex = 11;
            this.LblTotAmount.Text = "$0.00";
            //
            // Lbl_LblTotYear
            //
            this.Lbl_LblTotYear.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotYear.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotYear.Location = new System.Drawing.Point(19, 570);
            this.Lbl_LblTotYear.Name = "Lbl_LblTotYear";
            this.Lbl_LblTotYear.Size = new System.Drawing.Size(300, 20);
            this.Lbl_LblTotYear.TabIndex = 12;
            this.Lbl_LblTotYear.Text = "Total Distribution/Dividend per year";
            //
            // LblTotYear
            //
            this.LblTotYear.BackColor = System.Drawing.Color.Transparent;
            this.LblTotYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotYear.ForeColor = System.Drawing.Color.Black;
            this.LblTotYear.Location = new System.Drawing.Point(329, 570);
            this.LblTotYear.Name = "LblTotYear";
            this.LblTotYear.Size = new System.Drawing.Size(200, 20);
            this.LblTotYear.TabIndex = 13;
            this.LblTotYear.Text = "$0.00";
            //
            // Lbl_LblTotMonth
            //
            this.Lbl_LblTotMonth.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotMonth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotMonth.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotMonth.Location = new System.Drawing.Point(19, 594);
            this.Lbl_LblTotMonth.Name = "Lbl_LblTotMonth";
            this.Lbl_LblTotMonth.Size = new System.Drawing.Size(300, 20);
            this.Lbl_LblTotMonth.TabIndex = 14;
            this.Lbl_LblTotMonth.Text = "Total Distribution/Dividend per month";
            //
            // LblTotMonth
            //
            this.LblTotMonth.BackColor = System.Drawing.Color.Transparent;
            this.LblTotMonth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotMonth.ForeColor = System.Drawing.Color.Black;
            this.LblTotMonth.Location = new System.Drawing.Point(329, 594);
            this.LblTotMonth.Name = "LblTotMonth";
            this.LblTotMonth.Size = new System.Drawing.Size(200, 20);
            this.LblTotMonth.TabIndex = 15;
            this.LblTotMonth.Text = "$0.00";
            //
            // Lbl_LblYield
            //
            this.Lbl_LblYield.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblYield.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblYield.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblYield.Location = new System.Drawing.Point(19, 618);
            this.Lbl_LblYield.Name = "Lbl_LblYield";
            this.Lbl_LblYield.Size = new System.Drawing.Size(300, 20);
            this.Lbl_LblYield.TabIndex = 16;
            this.Lbl_LblYield.Text = "Yield";
            //
            // LblYield
            //
            this.LblYield.BackColor = System.Drawing.Color.Transparent;
            this.LblYield.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYield.ForeColor = System.Drawing.Color.Black;
            this.LblYield.Location = new System.Drawing.Point(329, 618);
            this.LblYield.Name = "LblYield";
            this.LblYield.Size = new System.Drawing.Size(200, 20);
            this.LblYield.TabIndex = 17;
            this.LblYield.Text = "0.00 %";
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(395, 652);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 18;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Forecast_Dividend_Allocation
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblYield);
            this.Controls.Add(this.Lbl_LblYield);
            this.Controls.Add(this.LblTotMonth);
            this.Controls.Add(this.Lbl_LblTotMonth);
            this.Controls.Add(this.LblTotYear);
            this.Controls.Add(this.Lbl_LblTotYear);
            this.Controls.Add(this.LblTotAmount);
            this.Controls.Add(this.Lbl_LblTotAmount);
            this.Controls.Add(this.gvAlloc);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.Lbl_txtAmount);
            this.Controls.Add(this.CmbTicker);
            this.Controls.Add(this.Lbl_CmbTicker);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Forecast_Dividend_Allocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Forecast Dividend Allocation";
            this.Load += new System.EventHandler(this.ETF_Stocks_Forecast_Dividend_Allocation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAlloc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Lbl_CmbTicker;
        public System.Windows.Forms.ComboBox CmbTicker;
        public System.Windows.Forms.Label Lbl_txtAmount;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Button CmdAdd;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvAlloc;
        public System.Windows.Forms.Label Lbl_LblTotAmount;
        public System.Windows.Forms.Label LblTotAmount;
        public System.Windows.Forms.Label Lbl_LblTotYear;
        public System.Windows.Forms.Label LblTotYear;
        public System.Windows.Forms.Label Lbl_LblTotMonth;
        public System.Windows.Forms.Label LblTotMonth;
        public System.Windows.Forms.Label Lbl_LblYield;
        public System.Windows.Forms.Label LblYield;
        public System.Windows.Forms.Button CmdBack;
    }
}
