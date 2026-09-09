namespace FinancialBalance
{
    partial class Compound_Interest_Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compound_Interest_Calculator));
            this.Label21 = new System.Windows.Forms.Label();
            this.Lbl_txtInitial = new System.Windows.Forms.Label();
            this.txtInitial = new System.Windows.Forms.TextBox();
            this.Lbl_txtRegular = new System.Windows.Forms.Label();
            this.txtRegular = new System.Windows.Forms.TextBox();
            this.Lbl_CmbDepositFreq = new System.Windows.Forms.Label();
            this.CmbDepositFreq = new System.Windows.Forms.ComboBox();
            this.Lbl_CmbCompoundFreq = new System.Windows.Forms.Label();
            this.CmbCompoundFreq = new System.Windows.Forms.ComboBox();
            this.Lbl_txtYears = new System.Windows.Forms.Label();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.LblYearsMax = new System.Windows.Forms.Label();
            this.Lbl_txtRate = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.LblRateMax = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.Lbl_LblSumInitial = new System.Windows.Forms.Label();
            this.LblSumInitial = new System.Windows.Forms.Label();
            this.Lbl_LblSumRegular = new System.Windows.Forms.Label();
            this.LblSumRegular = new System.Windows.Forms.Label();
            this.Lbl_LblSumInterest = new System.Windows.Forms.Label();
            this.LblSumInterest = new System.Windows.Forms.Label();
            this.Lbl_LblSumTotal = new System.Windows.Forms.Label();
            this.LblSumTotal = new System.Windows.Forms.Label();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.gvYears = new System.Windows.Forms.DataGridView();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvYears)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 26);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(960, 32);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "COMPOUND INTEREST CALCULATOR";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Lbl_txtInitial
            //
            this.Lbl_txtInitial.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtInitial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtInitial.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtInitial.Location = new System.Drawing.Point(19, 88);
            this.Lbl_txtInitial.Name = "Lbl_txtInitial";
            this.Lbl_txtInitial.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtInitial.TabIndex = 2;
            this.Lbl_txtInitial.Text = "Initial Deposit";
            //
            // txtInitial
            //
            this.txtInitial.BackColor = System.Drawing.SystemColors.Window;
            this.txtInitial.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInitial.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInitial.Location = new System.Drawing.Point(200, 86);
            this.txtInitial.MaxLength = 20;
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtInitial.Size = new System.Drawing.Size(150, 20);
            this.txtInitial.TabIndex = 3;
            this.txtInitial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInitial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtInitial.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // Lbl_txtRegular
            //
            this.Lbl_txtRegular.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtRegular.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtRegular.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtRegular.Location = new System.Drawing.Point(19, 120);
            this.Lbl_txtRegular.Name = "Lbl_txtRegular";
            this.Lbl_txtRegular.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtRegular.TabIndex = 4;
            this.Lbl_txtRegular.Text = "Regular Deposit";
            //
            // txtRegular
            //
            this.txtRegular.BackColor = System.Drawing.SystemColors.Window;
            this.txtRegular.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegular.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRegular.Location = new System.Drawing.Point(200, 118);
            this.txtRegular.MaxLength = 20;
            this.txtRegular.Name = "txtRegular";
            this.txtRegular.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRegular.Size = new System.Drawing.Size(150, 20);
            this.txtRegular.TabIndex = 5;
            this.txtRegular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRegular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtRegular.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // Lbl_CmbDepositFreq
            //
            this.Lbl_CmbDepositFreq.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbDepositFreq.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbDepositFreq.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbDepositFreq.Location = new System.Drawing.Point(19, 152);
            this.Lbl_CmbDepositFreq.Name = "Lbl_CmbDepositFreq";
            this.Lbl_CmbDepositFreq.Size = new System.Drawing.Size(175, 20);
            this.Lbl_CmbDepositFreq.TabIndex = 6;
            this.Lbl_CmbDepositFreq.Text = "Deposit Frequency";
            //
            // CmbDepositFreq
            //
            this.CmbDepositFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDepositFreq.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDepositFreq.FormattingEnabled = true;
            this.CmbDepositFreq.Location = new System.Drawing.Point(200, 148);
            this.CmbDepositFreq.Name = "CmbDepositFreq";
            this.CmbDepositFreq.Size = new System.Drawing.Size(150, 22);
            this.CmbDepositFreq.TabIndex = 7;
            this.CmbDepositFreq.SelectedIndexChanged += new System.EventHandler(this.Input_Changed);
            //
            // Lbl_CmbCompoundFreq
            //
            this.Lbl_CmbCompoundFreq.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_CmbCompoundFreq.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CmbCompoundFreq.ForeColor = System.Drawing.Color.Black;
            this.Lbl_CmbCompoundFreq.Location = new System.Drawing.Point(19, 184);
            this.Lbl_CmbCompoundFreq.Name = "Lbl_CmbCompoundFreq";
            this.Lbl_CmbCompoundFreq.Size = new System.Drawing.Size(175, 20);
            this.Lbl_CmbCompoundFreq.TabIndex = 8;
            this.Lbl_CmbCompoundFreq.Text = "Compound Frequency";
            //
            // CmbCompoundFreq
            //
            this.CmbCompoundFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCompoundFreq.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompoundFreq.FormattingEnabled = true;
            this.CmbCompoundFreq.Location = new System.Drawing.Point(200, 180);
            this.CmbCompoundFreq.Name = "CmbCompoundFreq";
            this.CmbCompoundFreq.Size = new System.Drawing.Size(150, 22);
            this.CmbCompoundFreq.TabIndex = 9;
            this.CmbCompoundFreq.SelectedIndexChanged += new System.EventHandler(this.Input_Changed);
            //
            // Lbl_txtYears
            //
            this.Lbl_txtYears.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtYears.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtYears.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtYears.Location = new System.Drawing.Point(19, 216);
            this.Lbl_txtYears.Name = "Lbl_txtYears";
            this.Lbl_txtYears.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtYears.TabIndex = 10;
            this.Lbl_txtYears.Text = "Number of Years";
            //
            // txtYears
            //
            this.txtYears.BackColor = System.Drawing.SystemColors.Window;
            this.txtYears.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYears.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYears.Location = new System.Drawing.Point(200, 214);
            this.txtYears.MaxLength = 20;
            this.txtYears.Name = "txtYears";
            this.txtYears.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYears.Size = new System.Drawing.Size(150, 20);
            this.txtYears.TabIndex = 11;
            this.txtYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYears.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtYears.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // LblYearsMax
            //
            this.LblYearsMax.BackColor = System.Drawing.Color.Transparent;
            this.LblYearsMax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYearsMax.ForeColor = System.Drawing.Color.DimGray;
            this.LblYearsMax.Location = new System.Drawing.Point(358, 216);
            this.LblYearsMax.Name = "LblYearsMax";
            this.LblYearsMax.Size = new System.Drawing.Size(110, 20);
            this.LblYearsMax.TabIndex = 12;
            this.LblYearsMax.Text = "1 to 50";
            //
            // Lbl_txtRate
            //
            this.Lbl_txtRate.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_txtRate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_txtRate.ForeColor = System.Drawing.Color.Black;
            this.Lbl_txtRate.Location = new System.Drawing.Point(19, 248);
            this.Lbl_txtRate.Name = "Lbl_txtRate";
            this.Lbl_txtRate.Size = new System.Drawing.Size(175, 20);
            this.Lbl_txtRate.TabIndex = 13;
            this.Lbl_txtRate.Text = "Annual Interest Rate";
            //
            // txtRate
            //
            this.txtRate.BackColor = System.Drawing.SystemColors.Window;
            this.txtRate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRate.Location = new System.Drawing.Point(200, 246);
            this.txtRate.MaxLength = 20;
            this.txtRate.Name = "txtRate";
            this.txtRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRate.Size = new System.Drawing.Size(150, 20);
            this.txtRate.TabIndex = 14;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Amount_KeyPress);
            this.txtRate.TextChanged += new System.EventHandler(this.Input_Changed);
            //
            // LblRateMax
            //
            this.LblRateMax.BackColor = System.Drawing.Color.Transparent;
            this.LblRateMax.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRateMax.ForeColor = System.Drawing.Color.DimGray;
            this.LblRateMax.Location = new System.Drawing.Point(358, 248);
            this.LblRateMax.Name = "LblRateMax";
            this.LblRateMax.Size = new System.Drawing.Size(110, 20);
            this.LblRateMax.TabIndex = 15;
            this.LblRateMax.Text = "0 to 20 %";
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 288);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(450, 36);
            this.LblNote.TabIndex = 16;
            //
            // Lbl_LblSumInitial
            //
            this.Lbl_LblSumInitial.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumInitial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumInitial.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblSumInitial.Location = new System.Drawing.Point(19, 332);
            this.Lbl_LblSumInitial.Name = "Lbl_LblSumInitial";
            this.Lbl_LblSumInitial.Size = new System.Drawing.Size(200, 20);
            this.Lbl_LblSumInitial.TabIndex = 17;
            this.Lbl_LblSumInitial.Text = "Initial Deposit";
            //
            // LblSumInitial
            //
            this.LblSumInitial.BackColor = System.Drawing.Color.Transparent;
            this.LblSumInitial.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumInitial.ForeColor = System.Drawing.Color.Black;
            this.LblSumInitial.Location = new System.Drawing.Point(225, 332);
            this.LblSumInitial.Name = "LblSumInitial";
            this.LblSumInitial.Size = new System.Drawing.Size(220, 20);
            this.LblSumInitial.TabIndex = 18;
            this.LblSumInitial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_LblSumRegular
            //
            this.Lbl_LblSumRegular.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumRegular.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumRegular.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblSumRegular.Location = new System.Drawing.Point(19, 366);
            this.Lbl_LblSumRegular.Name = "Lbl_LblSumRegular";
            this.Lbl_LblSumRegular.Size = new System.Drawing.Size(200, 20);
            this.Lbl_LblSumRegular.TabIndex = 19;
            this.Lbl_LblSumRegular.Text = "Regular Deposits";
            //
            // LblSumRegular
            //
            this.LblSumRegular.BackColor = System.Drawing.Color.Transparent;
            this.LblSumRegular.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumRegular.ForeColor = System.Drawing.Color.Black;
            this.LblSumRegular.Location = new System.Drawing.Point(225, 366);
            this.LblSumRegular.Name = "LblSumRegular";
            this.LblSumRegular.Size = new System.Drawing.Size(220, 20);
            this.LblSumRegular.TabIndex = 20;
            this.LblSumRegular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_LblSumInterest
            //
            this.Lbl_LblSumInterest.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumInterest.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumInterest.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LblSumInterest.Location = new System.Drawing.Point(19, 400);
            this.Lbl_LblSumInterest.Name = "Lbl_LblSumInterest";
            this.Lbl_LblSumInterest.Size = new System.Drawing.Size(200, 20);
            this.Lbl_LblSumInterest.TabIndex = 21;
            this.Lbl_LblSumInterest.Text = "Total Interest";
            //
            // LblSumInterest
            //
            this.LblSumInterest.BackColor = System.Drawing.Color.Transparent;
            this.LblSumInterest.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumInterest.ForeColor = System.Drawing.Color.Black;
            this.LblSumInterest.Location = new System.Drawing.Point(225, 400);
            this.LblSumInterest.Name = "LblSumInterest";
            this.LblSumInterest.Size = new System.Drawing.Size(220, 20);
            this.LblSumInterest.TabIndex = 22;
            this.LblSumInterest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Lbl_LblSumTotal
            //
            this.Lbl_LblSumTotal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_LblSumTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LblSumTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Lbl_LblSumTotal.Location = new System.Drawing.Point(19, 438);
            this.Lbl_LblSumTotal.Name = "Lbl_LblSumTotal";
            this.Lbl_LblSumTotal.Size = new System.Drawing.Size(200, 24);
            this.Lbl_LblSumTotal.TabIndex = 23;
            this.Lbl_LblSumTotal.Text = "Total Savings";
            //
            // LblSumTotal
            //
            this.LblSumTotal.BackColor = System.Drawing.Color.Transparent;
            this.LblSumTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSumTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblSumTotal.Location = new System.Drawing.Point(225, 438);
            this.LblSumTotal.Name = "LblSumTotal";
            this.LblSumTotal.Size = new System.Drawing.Size(220, 24);
            this.LblSumTotal.TabIndex = 24;
            this.LblSumTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // pnlChart
            //
            this.pnlChart.BackColor = System.Drawing.Color.Transparent;
            this.pnlChart.Location = new System.Drawing.Point(490, 82);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(490, 370);
            this.pnlChart.TabIndex = 25;
            //
            // gvYears
            //
            this.gvYears.AllowUserToAddRows = false;
            this.gvYears.AllowUserToDeleteRows = false;
            this.gvYears.AllowUserToResizeRows = false;
            this.gvYears.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvYears.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvYears.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvYears.Location = new System.Drawing.Point(19, 470);
            this.gvYears.MultiSelect = false;
            this.gvYears.Name = "gvYears";
            this.gvYears.ReadOnly = true;
            this.gvYears.RowHeadersVisible = false;
            this.gvYears.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvYears.Size = new System.Drawing.Size(960, 190);
            this.gvYears.TabIndex = 26;
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(870, 662);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 28);
            this.CmdBack.TabIndex = 27;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // Compound_Interest_Calculator
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.gvYears);
            this.Controls.Add(this.pnlChart);
            this.Controls.Add(this.LblSumTotal);
            this.Controls.Add(this.Lbl_LblSumTotal);
            this.Controls.Add(this.LblSumInterest);
            this.Controls.Add(this.Lbl_LblSumInterest);
            this.Controls.Add(this.LblSumRegular);
            this.Controls.Add(this.Lbl_LblSumRegular);
            this.Controls.Add(this.LblSumInitial);
            this.Controls.Add(this.Lbl_LblSumInitial);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.LblRateMax);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.Lbl_txtRate);
            this.Controls.Add(this.LblYearsMax);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.Lbl_txtYears);
            this.Controls.Add(this.CmbCompoundFreq);
            this.Controls.Add(this.Lbl_CmbCompoundFreq);
            this.Controls.Add(this.CmbDepositFreq);
            this.Controls.Add(this.Lbl_CmbDepositFreq);
            this.Controls.Add(this.txtRegular);
            this.Controls.Add(this.Lbl_txtRegular);
            this.Controls.Add(this.txtInitial);
            this.Controls.Add(this.Lbl_txtInitial);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "Compound_Interest_Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compound Interest Calculator";
            this.Load += new System.EventHandler(this.Compound_Interest_Calculator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvYears)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Lbl_txtInitial;
        public System.Windows.Forms.TextBox txtInitial;
        public System.Windows.Forms.Label Lbl_txtRegular;
        public System.Windows.Forms.TextBox txtRegular;
        public System.Windows.Forms.Label Lbl_CmbDepositFreq;
        public System.Windows.Forms.ComboBox CmbDepositFreq;
        public System.Windows.Forms.Label Lbl_CmbCompoundFreq;
        public System.Windows.Forms.ComboBox CmbCompoundFreq;
        public System.Windows.Forms.Label Lbl_txtYears;
        public System.Windows.Forms.TextBox txtYears;
        public System.Windows.Forms.Label LblYearsMax;
        public System.Windows.Forms.Label Lbl_txtRate;
        public System.Windows.Forms.TextBox txtRate;
        public System.Windows.Forms.Label LblRateMax;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.Label Lbl_LblSumInitial;
        public System.Windows.Forms.Label LblSumInitial;
        public System.Windows.Forms.Label Lbl_LblSumRegular;
        public System.Windows.Forms.Label LblSumRegular;
        public System.Windows.Forms.Label Lbl_LblSumInterest;
        public System.Windows.Forms.Label LblSumInterest;
        public System.Windows.Forms.Label Lbl_LblSumTotal;
        public System.Windows.Forms.Label LblSumTotal;
        public System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.DataGridView gvYears;
        public System.Windows.Forms.Button CmdBack;
    }
}
