namespace FinancialBalance
{
    partial class ETF_Stocks_Investment_Plan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Investment_Plan));
            this.Label21 = new System.Windows.Forms.Label();
            this.Lbl_CmbPlan = new System.Windows.Forms.Label();
            this.CmbPlan = new System.Windows.Forms.ComboBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvAlloc = new System.Windows.Forms.DataGridView();
            this.Lbl_txtAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.LblNote2 = new System.Windows.Forms.Label();
            this.gvAmount = new System.Windows.Forms.DataGridView();
            this.Lbl_LblTotal = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.CmdExcel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.pnlChart = new System.Windows.Forms.FlowLayoutPanel();
            this.LblChartNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlloc)).BeginInit();
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
            this.Label21.Text = "ETF/STOCK INVESTMENT PLAN";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Lbl_CmbPlan
            //
            this.Lbl_CmbPlan.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbPlan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbPlan.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbPlan.Location = new System.Drawing.Point(19, 82);
            this.Lbl_CmbPlan.Name = "Lbl_CmbPlan";
            this.Lbl_CmbPlan.Size = new System.Drawing.Size(120, 20);
            this.Lbl_CmbPlan.TabIndex = 2;
            this.Lbl_CmbPlan.Text = "Investment Plan";
            //
            // CmbPlan
            //
            this.CmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPlan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPlan.FormattingEnabled = true;
            this.CmbPlan.Location = new System.Drawing.Point(145, 80);
            this.CmbPlan.Name = "CmbPlan";
            this.CmbPlan.Size = new System.Drawing.Size(300, 22);
            this.CmbPlan.TabIndex = 3;
            this.CmbPlan.SelectedIndexChanged += new System.EventHandler(this.CmbPlan_SelectedIndexChanged);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 108);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(640, 20);
            this.LblNote.TabIndex = 4;
            //
            // gvAlloc
            //
            this.gvAlloc.AllowUserToAddRows = false;
            this.gvAlloc.AllowUserToDeleteRows = false;
            this.gvAlloc.AllowUserToResizeRows = false;
            this.gvAlloc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAlloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAlloc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAlloc.Location = new System.Drawing.Point(19, 130);
            this.gvAlloc.MultiSelect = false;
            this.gvAlloc.Name = "gvAlloc";
            this.gvAlloc.ReadOnly = true;
            this.gvAlloc.RowHeadersVisible = false;
            this.gvAlloc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAlloc.Size = new System.Drawing.Size(640, 140);
            this.gvAlloc.TabIndex = 5;
            //
            // Lbl_txtAmount
            //
            this.Lbl_txtAmount.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtAmount.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtAmount.Location = new System.Drawing.Point(19, 286);
            this.Lbl_txtAmount.Name = "Lbl_txtAmount";
            this.Lbl_txtAmount.Size = new System.Drawing.Size(150, 20);
            this.Lbl_txtAmount.TabIndex = 6;
            this.Lbl_txtAmount.Text = "Investment Amount";
            //
            // txtAmount
            //
            this.txtAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAmount.Location = new System.Drawing.Point(175, 286);
            this.txtAmount.MaxLength = 20;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(150, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            //
            // LblNote2
            //
            this.LblNote2.BackColor = System.Drawing.Color.Transparent;
            this.LblNote2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote2.ForeColor = System.Drawing.Color.Black;
            this.LblNote2.Location = new System.Drawing.Point(19, 314);
            this.LblNote2.Name = "LblNote2";
            this.LblNote2.Size = new System.Drawing.Size(640, 20);
            this.LblNote2.TabIndex = 8;
            //
            // gvAmount
            //
            this.gvAmount.AllowUserToAddRows = false;
            this.gvAmount.AllowUserToDeleteRows = false;
            this.gvAmount.AllowUserToResizeRows = false;
            this.gvAmount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAmount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvAmount.Location = new System.Drawing.Point(19, 336);
            this.gvAmount.MultiSelect = false;
            this.gvAmount.Name = "gvAmount";
            this.gvAmount.ReadOnly = true;
            this.gvAmount.RowHeadersVisible = false;
            this.gvAmount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAmount.Size = new System.Drawing.Size(640, 196);
            this.gvAmount.TabIndex = 9;
            //
            // Lbl_LblTotal
            //
            this.Lbl_LblTotal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotal.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotal.Location = new System.Drawing.Point(19, 546);
            this.Lbl_LblTotal.Name = "Lbl_LblTotal";
            this.Lbl_LblTotal.Size = new System.Drawing.Size(180, 20);
            this.Lbl_LblTotal.TabIndex = 10;
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
            this.LblTotal.TabIndex = 11;
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmdExcel
            //
            this.CmdExcel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdExcel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdExcel.Location = new System.Drawing.Point(19, 580);
            this.CmdExcel.Name = "CmdExcel";
            this.CmdExcel.Size = new System.Drawing.Size(140, 28);
            this.CmdExcel.TabIndex = 12;
            this.CmdExcel.Text = "Generate to &Excel";
            this.CmdExcel.UseVisualStyleBackColor = false;
            this.CmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(549, 580);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 13;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // pnlChart
            //
            this.pnlChart.AutoScroll = true;
            this.pnlChart.BackColor = System.Drawing.Color.Transparent;
            this.pnlChart.Location = new System.Drawing.Point(680, 76);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(460, 532);
            this.pnlChart.TabIndex = 14;
            //
            // LblChartNote
            //
            this.LblChartNote.BackColor = System.Drawing.Color.Transparent;
            this.LblChartNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblChartNote.ForeColor = System.Drawing.Color.Black;
            this.LblChartNote.Location = new System.Drawing.Point(680, 320);
            this.LblChartNote.Name = "LblChartNote";
            this.LblChartNote.Size = new System.Drawing.Size(460, 40);
            this.LblChartNote.TabIndex = 15;
            this.LblChartNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblChartNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblChartNote.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //
            // ETF_Stocks_Investment_Plan
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1160, 680);
            this.ControlBox = false;
            this.Controls.Add(this.LblChartNote);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdExcel);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.Lbl_LblTotal);
            this.Controls.Add(this.gvAmount);
            this.Controls.Add(this.LblNote2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.Lbl_txtAmount);
            this.Controls.Add(this.gvAlloc);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmbPlan);
            this.Controls.Add(this.Lbl_CmbPlan);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Investment_Plan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Investment Plan";
            this.Load += new System.EventHandler(this.ETF_Stocks_Investment_Plan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAlloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Lbl_CmbPlan;
        public System.Windows.Forms.ComboBox CmbPlan;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvAlloc;
        public System.Windows.Forms.Label Lbl_txtAmount;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Label LblNote2;
        private System.Windows.Forms.DataGridView gvAmount;
        public System.Windows.Forms.Label Lbl_LblTotal;
        public System.Windows.Forms.Label LblTotal;
        public System.Windows.Forms.Button CmdExcel;
        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.FlowLayoutPanel pnlChart;
        public System.Windows.Forms.Label LblChartNote;
    }
}
