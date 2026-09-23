namespace FinancialBalance
{
    partial class Tax_Deductable_Interest_Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tax_Deductable_Interest_Calculator));
            this.Label21 = new System.Windows.Forms.Label();
            this.Lbl_txtOnPaper = new System.Windows.Forms.Label();
            this.txtOnPaper = new System.Windows.Forms.TextBox();
            this.Lbl_txtTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.LblOnPaperPct = new System.Windows.Forms.Label();
            this.LblTaxMax = new System.Windows.Forms.Label();
            this.Lbl_txtAlloc = new System.Windows.Forms.Label();
            this.txtAlloc = new System.Windows.Forms.TextBox();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdReload = new System.Windows.Forms.Button();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvTax = new System.Windows.Forms.DataGridView();
            this.Lbl_LblOnPaper = new System.Windows.Forms.Label();
            this.LblOnPaper = new System.Windows.Forms.Label();
            this.Lbl_LblTotAlloc = new System.Windows.Forms.Label();
            this.LblTotAlloc = new System.Windows.Forms.Label();
            this.Lbl_LblTotTax = new System.Windows.Forms.Label();
            this.LblTotTax = new System.Windows.Forms.Label();
            this.Lbl_LblReal = new System.Windows.Forms.Label();
            this.LblReal = new System.Windows.Forms.Label();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvTax)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 26);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(860, 32);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "TAX DEDUCTABLE INTEREST CALCULATOR";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Lbl_txtOnPaper
            //
            this.Lbl_txtOnPaper.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtOnPaper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtOnPaper.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtOnPaper.Location = new System.Drawing.Point(19, 80);
            this.Lbl_txtOnPaper.Name = "Lbl_txtOnPaper";
            this.Lbl_txtOnPaper.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtOnPaper.TabIndex = 1;
            this.Lbl_txtOnPaper.Text = "On Paper Interest";
            //
            // txtOnPaper
            //
            this.txtOnPaper.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnPaper.Location = new System.Drawing.Point(200, 78);
            this.txtOnPaper.MaxLength = 15;
            this.txtOnPaper.Name = "txtOnPaper";
            this.txtOnPaper.Size = new System.Drawing.Size(150, 20);
            this.txtOnPaper.TabIndex = 2;
            this.txtOnPaper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOnPaper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtOnPaper.TextChanged += new System.EventHandler(this.txtOnPaper_TextChanged);
            //
            // Lbl_txtTax
            //
            this.Lbl_txtTax.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtTax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtTax.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtTax.Location = new System.Drawing.Point(19, 112);
            this.Lbl_txtTax.Name = "Lbl_txtTax";
            this.Lbl_txtTax.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtTax.TabIndex = 3;
            this.Lbl_txtTax.Text = "Tax Percentage";
            //
            // txtTax
            //
            this.txtTax.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTax.Location = new System.Drawing.Point(200, 110);
            this.txtTax.MaxLength = 10;
            this.txtTax.Name = "txtTax";
            this.txtTax.Size = new System.Drawing.Size(150, 20);
            this.txtTax.TabIndex = 4;
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            //
            // LblOnPaperPct
            //
            this.LblOnPaperPct.BackColor = System.Drawing.Color.Transparent;
            this.LblOnPaperPct.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOnPaperPct.ForeColor = System.Drawing.Color.DimGray;
            this.LblOnPaperPct.Location = new System.Drawing.Point(358, 80);
            this.LblOnPaperPct.Name = "LblOnPaperPct";
            this.LblOnPaperPct.Size = new System.Drawing.Size(260, 20);
            this.LblOnPaperPct.TabIndex = 22;
            this.LblOnPaperPct.Text = "% - a rate, not an amount";
            //
            // LblTaxMax
            //
            this.LblTaxMax.BackColor = System.Drawing.Color.Transparent;
            this.LblTaxMax.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTaxMax.ForeColor = System.Drawing.Color.DimGray;
            this.LblTaxMax.Location = new System.Drawing.Point(358, 112);
            this.LblTaxMax.Name = "LblTaxMax";
            this.LblTaxMax.Size = new System.Drawing.Size(260, 20);
            this.LblTaxMax.TabIndex = 5;
            this.LblTaxMax.Text = "0 to 100 %";
            //
            // Lbl_txtAlloc
            //
            this.Lbl_txtAlloc.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtAlloc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtAlloc.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtAlloc.Location = new System.Drawing.Point(19, 142);
            this.Lbl_txtAlloc.Name = "Lbl_txtAlloc";
            this.Lbl_txtAlloc.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtAlloc.TabIndex = 6;
            this.Lbl_txtAlloc.Text = "Allocation";
            //
            // txtAlloc
            //
            this.txtAlloc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlloc.Location = new System.Drawing.Point(200, 140);
            this.txtAlloc.MaxLength = 10;
            this.txtAlloc.Name = "txtAlloc";
            this.txtAlloc.Size = new System.Drawing.Size(150, 20);
            this.txtAlloc.TabIndex = 7;
            this.txtAlloc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAlloc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            //
            // CmdAdd
            //
            this.CmdAdd.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdAdd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdAdd.Location = new System.Drawing.Point(365, 139);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdAdd.Size = new System.Drawing.Size(85, 24);
            this.CmdAdd.TabIndex = 8;
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
            this.CmdDel.Location = new System.Drawing.Point(460, 139);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(85, 24);
            this.CmdDel.TabIndex = 9;
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
            this.CmdClear.Location = new System.Drawing.Point(555, 139);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdClear.Size = new System.Drawing.Size(85, 24);
            this.CmdClear.TabIndex = 10;
            this.CmdClear.Text = "Clear &All";
            this.CmdClear.UseVisualStyleBackColor = false;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            //
            // CmdReload
            //
            this.CmdReload.BackColor = System.Drawing.SystemColors.Control;
            this.CmdReload.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdReload.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdReload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdReload.Location = new System.Drawing.Point(650, 139);
            this.CmdReload.Name = "CmdReload";
            this.CmdReload.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdReload.Size = new System.Drawing.Size(85, 24);
            this.CmdReload.TabIndex = 23;
            this.CmdReload.Text = "&Reload";
            this.CmdReload.UseVisualStyleBackColor = false;
            this.CmdReload.Click += new System.EventHandler(this.CmdReload_Click);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblNote.Location = new System.Drawing.Point(19, 172);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(862, 36);
            this.LblNote.TabIndex = 11;
            this.LblNote.Text = "";
            //
            // gvTax
            //
            this.gvTax.AllowUserToAddRows = false;
            this.gvTax.AllowUserToDeleteRows = false;
            this.gvTax.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTax.Location = new System.Drawing.Point(19, 214);
            this.gvTax.MultiSelect = false;
            this.gvTax.Name = "gvTax";
            this.gvTax.ReadOnly = true;
            this.gvTax.RowHeadersVisible = false;
            this.gvTax.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTax.Size = new System.Drawing.Size(862, 250);
            this.gvTax.TabIndex = 12;
            this.gvTax.SelectionChanged += new System.EventHandler(this.gvTax_SelectionChanged);
            //
            // Lbl_LblOnPaper
            //
            this.Lbl_LblOnPaper.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblOnPaper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblOnPaper.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblOnPaper.Location = new System.Drawing.Point(19, 480);
            this.Lbl_LblOnPaper.Name = "Lbl_LblOnPaper";
            this.Lbl_LblOnPaper.Size = new System.Drawing.Size(250, 20);
            this.Lbl_LblOnPaper.TabIndex = 13;
            this.Lbl_LblOnPaper.Text = "On Paper Interest";
            //
            // LblOnPaper
            //
            this.LblOnPaper.BackColor = System.Drawing.Color.Transparent;
            this.LblOnPaper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOnPaper.ForeColor = System.Drawing.Color.Black;
            this.LblOnPaper.Location = new System.Drawing.Point(279, 480);
            this.LblOnPaper.Name = "LblOnPaper";
            this.LblOnPaper.Size = new System.Drawing.Size(200, 20);
            this.LblOnPaper.TabIndex = 14;
            this.LblOnPaper.Text = "0.0000 %";
            //
            // Lbl_LblTotAlloc
            //
            this.Lbl_LblTotAlloc.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotAlloc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotAlloc.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotAlloc.Location = new System.Drawing.Point(19, 504);
            this.Lbl_LblTotAlloc.Name = "Lbl_LblTotAlloc";
            this.Lbl_LblTotAlloc.Size = new System.Drawing.Size(250, 20);
            this.Lbl_LblTotAlloc.TabIndex = 15;
            this.Lbl_LblTotAlloc.Text = "Total Allocation";
            //
            // LblTotAlloc
            //
            this.LblTotAlloc.BackColor = System.Drawing.Color.Transparent;
            this.LblTotAlloc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotAlloc.ForeColor = System.Drawing.Color.Black;
            this.LblTotAlloc.Location = new System.Drawing.Point(279, 504);
            this.LblTotAlloc.Name = "LblTotAlloc";
            this.LblTotAlloc.Size = new System.Drawing.Size(200, 20);
            this.LblTotAlloc.TabIndex = 16;
            this.LblTotAlloc.Text = "0.00 %";
            //
            // Lbl_LblTotTax
            //
            this.Lbl_LblTotTax.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblTotTax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblTotTax.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblTotTax.Location = new System.Drawing.Point(19, 528);
            this.Lbl_LblTotTax.Name = "Lbl_LblTotTax";
            this.Lbl_LblTotTax.Size = new System.Drawing.Size(250, 20);
            this.Lbl_LblTotTax.TabIndex = 17;
            this.Lbl_LblTotTax.Text = "Total Tax";
            //
            // LblTotTax
            //
            this.LblTotTax.BackColor = System.Drawing.Color.Transparent;
            this.LblTotTax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotTax.ForeColor = System.Drawing.Color.Red;
            this.LblTotTax.Location = new System.Drawing.Point(279, 528);
            this.LblTotTax.Name = "LblTotTax";
            this.LblTotTax.Size = new System.Drawing.Size(200, 20);
            this.LblTotTax.TabIndex = 18;
            this.LblTotTax.Text = "0.0000 %";
            //
            // Lbl_LblReal
            //
            this.Lbl_LblReal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblReal.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblReal.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblReal.Location = new System.Drawing.Point(19, 556);
            this.Lbl_LblReal.Name = "Lbl_LblReal";
            this.Lbl_LblReal.Size = new System.Drawing.Size(250, 24);
            this.Lbl_LblReal.TabIndex = 19;
            this.Lbl_LblReal.Text = "Real Interest";
            //
            // LblReal
            //
            this.LblReal.BackColor = System.Drawing.Color.Transparent;
            this.LblReal.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReal.ForeColor = System.Drawing.Color.Green;
            this.LblReal.Location = new System.Drawing.Point(279, 556);
            this.LblReal.Name = "LblReal";
            this.LblReal.Size = new System.Drawing.Size(200, 24);
            this.LblReal.TabIndex = 20;
            this.LblReal.Text = "0.0000 %";
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(395, 592);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 21;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Tax_Deductable_Interest_Calculator
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(900, 634);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.LblReal);
            this.Controls.Add(this.Lbl_LblReal);
            this.Controls.Add(this.LblTotTax);
            this.Controls.Add(this.Lbl_LblTotTax);
            this.Controls.Add(this.LblTotAlloc);
            this.Controls.Add(this.Lbl_LblTotAlloc);
            this.Controls.Add(this.LblOnPaper);
            this.Controls.Add(this.Lbl_LblOnPaper);
            this.Controls.Add(this.gvTax);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.CmdReload);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.txtAlloc);
            this.Controls.Add(this.Lbl_txtAlloc);
            this.Controls.Add(this.LblTaxMax);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.Lbl_txtTax);
            this.Controls.Add(this.LblOnPaperPct);
            this.Controls.Add(this.txtOnPaper);
            this.Controls.Add(this.Lbl_txtOnPaper);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "Tax_Deductable_Interest_Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax Deductable Interest Calculator";
            this.Load += new System.EventHandler(this.Tax_Deductable_Interest_Calculator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvTax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Lbl_txtOnPaper;
        public System.Windows.Forms.TextBox txtOnPaper;
        public System.Windows.Forms.Label Lbl_txtTax;
        public System.Windows.Forms.TextBox txtTax;
        public System.Windows.Forms.Label LblOnPaperPct;
        public System.Windows.Forms.Label LblTaxMax;
        public System.Windows.Forms.Label Lbl_txtAlloc;
        public System.Windows.Forms.TextBox txtAlloc;
        public System.Windows.Forms.Button CmdAdd;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdReload;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvTax;
        public System.Windows.Forms.Label Lbl_LblOnPaper;
        public System.Windows.Forms.Label LblOnPaper;
        public System.Windows.Forms.Label Lbl_LblTotAlloc;
        public System.Windows.Forms.Label LblTotAlloc;
        public System.Windows.Forms.Label Lbl_LblTotTax;
        public System.Windows.Forms.Label LblTotTax;
        public System.Windows.Forms.Label Lbl_LblReal;
        public System.Windows.Forms.Label LblReal;
        public System.Windows.Forms.Button CmdBack;
    }
}
