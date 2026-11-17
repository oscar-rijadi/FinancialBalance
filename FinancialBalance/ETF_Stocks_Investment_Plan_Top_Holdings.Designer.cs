namespace FinancialBalance
{
    partial class ETF_Stocks_Investment_Plan_Top_Holdings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Investment_Plan_Top_Holdings));
            this.Label21 = new System.Windows.Forms.Label();
            this.Lbl_CmbPlan = new System.Windows.Forms.Label();
            this.CmbPlan = new System.Windows.Forms.ComboBox();
            this.CmdTop = new System.Windows.Forms.Button();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvAlloc = new System.Windows.Forms.DataGridView();
            this.LblTopNote = new System.Windows.Forms.Label();
            this.gvTop = new System.Windows.Forms.DataGridView();
            this.CmdExcel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlloc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTop)).BeginInit();
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
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK INVESTMENT PLAN TOP HOLDINGS";
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
            this.Lbl_CmbPlan.TabIndex = 1;
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
            this.CmbPlan.TabIndex = 2;
            this.CmbPlan.SelectedIndexChanged += new System.EventHandler(this.CmbPlan_SelectedIndexChanged);
            //
            // CmdTop
            //
            this.CmdTop.BackColor = System.Drawing.SystemColors.Control;
            this.CmdTop.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdTop.Location = new System.Drawing.Point(455, 78);
            this.CmdTop.Name = "CmdTop";
            this.CmdTop.Size = new System.Drawing.Size(140, 26);
            this.CmdTop.TabIndex = 3;
            this.CmdTop.Text = "Get &Top 10 Holding";
            this.CmdTop.UseVisualStyleBackColor = false;
            this.CmdTop.Click += new System.EventHandler(this.CmdTop_Click);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 112);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(360, 34);
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
            this.gvAlloc.Location = new System.Drawing.Point(19, 150);
            this.gvAlloc.MultiSelect = false;
            this.gvAlloc.Name = "gvAlloc";
            this.gvAlloc.ReadOnly = true;
            this.gvAlloc.RowHeadersVisible = false;
            this.gvAlloc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAlloc.Size = new System.Drawing.Size(360, 380);
            this.gvAlloc.TabIndex = 5;
            //
            // LblTopNote
            //
            this.LblTopNote.BackColor = System.Drawing.Color.Transparent;
            this.LblTopNote.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTopNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblTopNote.Location = new System.Drawing.Point(395, 112);
            this.LblTopNote.Name = "LblTopNote";
            this.LblTopNote.Size = new System.Drawing.Size(745, 34);
            this.LblTopNote.TabIndex = 6;
            //
            // gvTop
            //
            this.gvTop.AllowUserToAddRows = false;
            this.gvTop.AllowUserToDeleteRows = false;
            this.gvTop.AllowUserToResizeRows = false;
            this.gvTop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTop.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvTop.Location = new System.Drawing.Point(395, 150);
            this.gvTop.MultiSelect = false;
            this.gvTop.Name = "gvTop";
            this.gvTop.ReadOnly = true;
            this.gvTop.RowHeadersVisible = false;
            this.gvTop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTop.Size = new System.Drawing.Size(745, 380);
            this.gvTop.TabIndex = 7;
            //
            // CmdExcel
            //
            this.CmdExcel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdExcel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdExcel.Location = new System.Drawing.Point(19, 546);
            this.CmdExcel.Name = "CmdExcel";
            this.CmdExcel.Size = new System.Drawing.Size(140, 28);
            this.CmdExcel.TabIndex = 8;
            this.CmdExcel.Text = "Generate to &Excel";
            this.CmdExcel.UseVisualStyleBackColor = false;
            this.CmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(1030, 546);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 9;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Investment_Plan_Top_Holdings
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1160, 590);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdExcel);
            this.Controls.Add(this.gvTop);
            this.Controls.Add(this.LblTopNote);
            this.Controls.Add(this.gvAlloc);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmdTop);
            this.Controls.Add(this.CmbPlan);
            this.Controls.Add(this.Lbl_CmbPlan);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Investment_Plan_Top_Holdings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Investment Plan Top Holdings";
            this.Load += new System.EventHandler(this.ETF_Stocks_Investment_Plan_Top_Holdings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAlloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Lbl_CmbPlan;
        public System.Windows.Forms.ComboBox CmbPlan;
        public System.Windows.Forms.Button CmdTop;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvAlloc;
        public System.Windows.Forms.Label LblTopNote;
        private System.Windows.Forms.DataGridView gvTop;
        public System.Windows.Forms.Button CmdExcel;
        public System.Windows.Forms.Button CmdBack;
    }
}
