namespace FinancialBalance
{
    partial class ETF_Stocks_Investment_Plan_By_Amount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Investment_Plan_By_Amount));
            this.Label21 = new System.Windows.Forms.Label();
            this.Lbl_CmbTicker = new System.Windows.Forms.Label();
            this.CmbTicker = new System.Windows.Forms.ComboBox();
            this.Lbl_txtAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvAmount = new System.Windows.Forms.DataGridView();
            this.Lbl_LblTotal = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.pnlChart = new System.Windows.Forms.FlowLayoutPanel();
            this.LblChartNote = new System.Windows.Forms.Label();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 30);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(1120, 32);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK INVESTMENT PLAN BY AMOUNT";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label21.UseMnemonic = false;
            // 
            // Lbl_CmbTicker
            // 
            this.Lbl_CmbTicker.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbTicker.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbTicker.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbTicker.Location = new System.Drawing.Point(19, 82);
            this.Lbl_CmbTicker.Name = "Lbl_CmbTicker";
            this.Lbl_CmbTicker.Size = new System.Drawing.Size(150, 20);
            this.Lbl_CmbTicker.TabIndex = 2;
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
            this.CmbTicker.TabIndex = 3;
            // 
            // Lbl_txtAmount
            // 
            this.Lbl_txtAmount.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtAmount.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtAmount.Location = new System.Drawing.Point(19, 112);
            this.Lbl_txtAmount.Name = "Lbl_txtAmount";
            this.Lbl_txtAmount.Size = new System.Drawing.Size(150, 20);
            this.Lbl_txtAmount.TabIndex = 4;
            this.Lbl_txtAmount.Text = "Investment Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(175, 110);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(150, 20);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            // 
            // CmdAdd
            // 
            this.CmdAdd.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAdd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAdd.Location = new System.Drawing.Point(340, 109);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(85, 24);
            this.CmdAdd.TabIndex = 6;
            this.CmdAdd.Text = "&Add";
            this.CmdAdd.UseVisualStyleBackColor = false;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // CmdDel
            // 
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.Location = new System.Drawing.Point(435, 109);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 24);
            this.CmdDel.TabIndex = 7;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            // 
            // CmdClear
            // 
            this.CmdClear.BackColor = System.Drawing.SystemColors.Control;
            this.CmdClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClear.Location = new System.Drawing.Point(530, 109);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.Size = new System.Drawing.Size(85, 24);
            this.CmdClear.TabIndex = 8;
            this.CmdClear.Text = "Clear &All";
            this.CmdClear.UseVisualStyleBackColor = false;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            // 
            // LblNote
            // 
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 142);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(640, 20);
            this.LblNote.TabIndex = 9;
            this.LblNote.UseMnemonic = false;
            // 
            // gvAmount
            // 
            this.gvAmount.AllowUserToAddRows = false;
            this.gvAmount.AllowUserToDeleteRows = false;
            this.gvAmount.AllowUserToResizeRows = false;
            this.gvAmount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAmount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAmount.Location = new System.Drawing.Point(19, 166);
            this.gvAmount.MultiSelect = false;
            this.gvAmount.Name = "gvAmount";
            this.gvAmount.ReadOnly = true;
            this.gvAmount.RowHeadersVisible = false;
            this.gvAmount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAmount.Size = new System.Drawing.Size(640, 360);
            this.gvAmount.TabIndex = 10;
            this.gvAmount.SelectionChanged += new System.EventHandler(this.gvAmount_SelectionChanged);
            // 
            // Lbl_LblTotal
            // 
            this.Lbl_LblTotal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotal.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotal.Location = new System.Drawing.Point(19, 546);
            this.Lbl_LblTotal.Name = "Lbl_LblTotal";
            this.Lbl_LblTotal.Size = new System.Drawing.Size(180, 20);
            this.Lbl_LblTotal.TabIndex = 11;
            this.Lbl_LblTotal.Text = "Total Investment Amount";
            // 
            // LblTotal
            // 
            this.LblTotal.BackColor = System.Drawing.Color.Transparent;
            this.LblTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.ForeColor = System.Drawing.Color.Black;
            this.LblTotal.Location = new System.Drawing.Point(205, 546);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(160, 20);
            this.LblTotal.TabIndex = 12;
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblTotal.UseMnemonic = false;
            // 
            // pnlChart
            // 
            this.pnlChart.AutoScroll = true;
            this.pnlChart.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlChart.WrapContents = false;
            this.pnlChart.BackColor = System.Drawing.Color.Transparent;
            this.pnlChart.Location = new System.Drawing.Point(680, 76);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(460, 532);
            this.pnlChart.TabIndex = 13;
            // 
            // LblChartNote
            // 
            this.LblChartNote.BackColor = System.Drawing.Color.Transparent;
            this.LblChartNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblChartNote.ForeColor = System.Drawing.Color.Black;
            this.LblChartNote.Location = new System.Drawing.Point(680, 320);
            this.LblChartNote.Name = "LblChartNote";
            this.LblChartNote.Size = new System.Drawing.Size(460, 40);
            this.LblChartNote.TabIndex = 14;
            this.LblChartNote.UseMnemonic = false;
            // 
            // CmdBack
            // 
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(549, 580);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 15;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // ETF_Stocks_Investment_Plan_By_Amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1160, 680);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblChartNote);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.Lbl_LblTotal);
            this.Controls.Add(this.gvAmount);
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
            this.Name = "ETF_Stocks_Investment_Plan_By_Amount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Investment Plan by Amount";
            this.Load += new System.EventHandler(this.ETF_Stocks_Investment_Plan_By_Amount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAmount)).EndInit();
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
        public System.Windows.Forms.DataGridView gvAmount;
        public System.Windows.Forms.Label Lbl_LblTotal;
        public System.Windows.Forms.Label LblTotal;
        public System.Windows.Forms.FlowLayoutPanel pnlChart;
        public System.Windows.Forms.Label LblChartNote;
        public System.Windows.Forms.Button CmdBack;
    }
}
