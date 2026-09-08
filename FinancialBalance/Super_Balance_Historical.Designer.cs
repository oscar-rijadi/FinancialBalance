namespace FinancialBalance
{
    partial class Super_Balance_Historical
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Super_Balance_Historical));
            this.Label21 = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvSuper = new System.Windows.Forms.DataGridView();
            this.Lbl_CmbFinYear = new System.Windows.Forms.Label();
            this.CmbFinYear = new System.Windows.Forms.ComboBox();
            this.Lbl_CmbSuper = new System.Windows.Forms.Label();
            this.CmbSuper = new System.Windows.Forms.ComboBox();
            this.LblNote2 = new System.Windows.Forms.Label();
            this.gvHist = new System.Windows.Forms.DataGridView();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvSuper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHist)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(142, 30);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(980, 38);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "SUPER BALANCE & HISTORICAL DATA";
            this.Label21.UseMnemonic = false;
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 84);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(700, 20);
            this.LblNote.TabIndex = 2;
            //
            // gvSuper
            //
            this.gvSuper.AllowUserToAddRows = false;
            this.gvSuper.AllowUserToDeleteRows = false;
            this.gvSuper.AllowUserToResizeRows = false;
            this.gvSuper.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvSuper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSuper.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvSuper.Location = new System.Drawing.Point(19, 106);
            this.gvSuper.MultiSelect = false;
            this.gvSuper.Name = "gvSuper";
            this.gvSuper.ReadOnly = true;
            this.gvSuper.RowHeadersVisible = false;
            this.gvSuper.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvSuper.Size = new System.Drawing.Size(700, 130);
            this.gvSuper.TabIndex = 3;
            //
            // Lbl_CmbFinYear
            //
            this.Lbl_CmbFinYear.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbFinYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbFinYear.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbFinYear.Location = new System.Drawing.Point(19, 256);
            this.Lbl_CmbFinYear.Name = "Lbl_CmbFinYear";
            this.Lbl_CmbFinYear.Size = new System.Drawing.Size(110, 20);
            this.Lbl_CmbFinYear.TabIndex = 4;
            this.Lbl_CmbFinYear.Text = "Financial Year";
            //
            // CmbFinYear
            //
            this.CmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinYear.FormattingEnabled = true;
            this.CmbFinYear.Location = new System.Drawing.Point(135, 254);
            this.CmbFinYear.Name = "CmbFinYear";
            this.CmbFinYear.Size = new System.Drawing.Size(160, 22);
            this.CmbFinYear.TabIndex = 5;
            this.CmbFinYear.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // Lbl_CmbSuper
            //
            this.Lbl_CmbSuper.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbSuper.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbSuper.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbSuper.Location = new System.Drawing.Point(315, 256);
            this.Lbl_CmbSuper.Name = "Lbl_CmbSuper";
            this.Lbl_CmbSuper.Size = new System.Drawing.Size(60, 20);
            this.Lbl_CmbSuper.TabIndex = 6;
            this.Lbl_CmbSuper.Text = "Super";
            //
            // CmbSuper
            //
            this.CmbSuper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSuper.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSuper.FormattingEnabled = true;
            this.CmbSuper.Location = new System.Drawing.Point(385, 254);
            this.CmbSuper.Name = "CmbSuper";
            this.CmbSuper.Size = new System.Drawing.Size(320, 22);
            this.CmbSuper.TabIndex = 7;
            this.CmbSuper.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            //
            // LblNote2
            //
            this.LblNote2.BackColor = System.Drawing.Color.Transparent;
            this.LblNote2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote2.ForeColor = System.Drawing.Color.Black;
            this.LblNote2.Location = new System.Drawing.Point(19, 280);
            this.LblNote2.Name = "LblNote2";
            this.LblNote2.Size = new System.Drawing.Size(1224, 20);
            this.LblNote2.TabIndex = 8;
            //
            // gvHist
            //
            this.gvHist.AllowUserToAddRows = false;
            this.gvHist.AllowUserToDeleteRows = false;
            this.gvHist.AllowUserToResizeRows = false;
            this.gvHist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvHist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHist.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvHist.Location = new System.Drawing.Point(19, 302);
            this.gvHist.MultiSelect = false;
            this.gvHist.Name = "gvHist";
            this.gvHist.ReadOnly = true;
            this.gvHist.RowHeadersVisible = false;
            this.gvHist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvHist.Size = new System.Drawing.Size(1224, 290);
            this.gvHist.TabIndex = 9;
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(1134, 610);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 10;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Super_Balance_Historical
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1264, 680);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.gvHist);
            this.Controls.Add(this.LblNote2);
            this.Controls.Add(this.CmbSuper);
            this.Controls.Add(this.Lbl_CmbSuper);
            this.Controls.Add(this.CmbFinYear);
            this.Controls.Add(this.Lbl_CmbFinYear);
            this.Controls.Add(this.gvSuper);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "Super_Balance_Historical";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Balance & Historical Data";
            this.Load += new System.EventHandler(this.Super_Balance_Historical_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSuper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label LblNote;
        private System.Windows.Forms.DataGridView gvSuper;
        public System.Windows.Forms.Label Lbl_CmbFinYear;
        public System.Windows.Forms.ComboBox CmbFinYear;
        public System.Windows.Forms.Label Lbl_CmbSuper;
        public System.Windows.Forms.ComboBox CmbSuper;
        public System.Windows.Forms.Label LblNote2;
        private System.Windows.Forms.DataGridView gvHist;
        public System.Windows.Forms.Button CmdBack;
    }
}
