namespace FinancialBalance
{
    partial class Setup_Activa_Passiva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Activa_Passiva));
            this.CmdBack = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdSetup = new System.Windows.Forms.Button();
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnAcctRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrRateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblCurr = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.CmbAcctCode = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbAcctType = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.gvActivaPassiva = new System.Windows.Forms.DataGridView();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvActivaPassiva)).BeginInit();
            this.SuspendLayout();
            // 
            // CmdBack
            // 
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(312, 510);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 27);
            this.CmdBack.TabIndex = 7;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // CmdDel
            // 
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(216, 510);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(73, 25);
            this.CmdDel.TabIndex = 8;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            // 
            // CmdSetup
            // 
            this.CmdSetup.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSetup.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdSetup.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSetup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSetup.Location = new System.Drawing.Point(120, 510);
            this.CmdSetup.Name = "CmdSetup";
            this.CmdSetup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdSetup.Size = new System.Drawing.Size(73, 25);
            this.CmdSetup.TabIndex = 9;
            this.CmdSetup.Text = "&Setup";
            this.CmdSetup.UseVisualStyleBackColor = false;
            this.CmdSetup.Click += new System.EventHandler(this.CmdSetup_Click);
            // 
            // MainMenu1
            // 
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnAcctTypeRefSetup,
            this.MnAcctRefSetup,
            this.MnCurrSetup,
            this.MnCurrRateSetup,
            this.MnETFStocksSuffixSetup});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(576, 24);
            this.MainMenu1.TabIndex = 13;
            // 
            // MnAcctTypeRefSetup
            // 
            this.MnAcctTypeRefSetup.Name = "MnAcctTypeRefSetup";
            this.MnAcctTypeRefSetup.Size = new System.Drawing.Size(150, 20);
            this.MnAcctTypeRefSetup.Text = "Accounting &Type Ref Setup";
            this.MnAcctTypeRefSetup.Click += new System.EventHandler(this.MnAcctTypeRefSetup_Click);
            // 
            // MnAcctRefSetup
            // 
            this.MnAcctRefSetup.Name = "MnAcctRefSetup";
            this.MnAcctRefSetup.Size = new System.Drawing.Size(123, 20);
            this.MnAcctRefSetup.Text = "&Accounting Ref Setup";
            this.MnAcctRefSetup.Click += new System.EventHandler(this.MnAcctRefSetup_Click);
            // 
            // MnCurrSetup
            // 
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(94, 20);
            this.MnCurrSetup.Text = "&Currency Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
            // 
            // MnCurrRateSetup
            // 
            this.MnCurrRateSetup.Name = "MnCurrRateSetup";
            this.MnCurrRateSetup.Size = new System.Drawing.Size(120, 20);
            this.MnCurrRateSetup.Text = "Currency &Rate Setup";
            this.MnCurrRateSetup.Click += new System.EventHandler(this.MnCurrRateSetup_Click);
            // 
            // MnETFStocksSuffixSetup
            // 
            this.MnETFStocksSuffixSetup.Name = "MnETFStocksSuffixSetup";
            this.MnETFStocksSuffixSetup.Size = new System.Drawing.Size(140, 20);
            this.MnETFStocksSuffixSetup.Text = "&ETF/Stock Suffix Setup";
            this.MnETFStocksSuffixSetup.Click += new System.EventHandler(this.MnETFStocksSuffixSetup_Click);
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(158, 30);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(274, 41);
            this.Label21.TabIndex = 14;
            this.Label21.Text = "ACTIVA PASSIVA SETUP";
            // 
            // txtBalance
            // 
            this.txtBalance.AcceptsReturn = true;
            this.txtBalance.BackColor = System.Drawing.SystemColors.Window;
            this.txtBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBalance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBalance.Location = new System.Drawing.Point(96, 470);
            this.txtBalance.MaxLength = 23;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBalance.Size = new System.Drawing.Size(169, 20);
            this.txtBalance.TabIndex = 15;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            this.txtBalance.Leave += new System.EventHandler(this.txtBalance_Leave);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(16, 470);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(73, 25);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Balance";
            // 
            // lblCurr
            // 
            this.lblCurr.BackColor = System.Drawing.Color.Transparent;
            this.lblCurr.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCurr.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurr.ForeColor = System.Drawing.Color.Black;
            this.lblCurr.Location = new System.Drawing.Point(96, 447);
            this.lblCurr.Name = "lblCurr";
            this.lblCurr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCurr.Size = new System.Drawing.Size(73, 21);
            this.lblCurr.TabIndex = 17;
            this.lblCurr.Text = "IDR";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(16, 446);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(73, 25);
            this.Label4.TabIndex = 18;
            this.Label4.Text = "Currency";
            // 
            // CmbAcctCode
            // 
            this.CmbAcctCode.BackColor = System.Drawing.SystemColors.Window;
            this.CmbAcctCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbAcctCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAcctCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAcctCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbAcctCode.Location = new System.Drawing.Point(96, 422);
            this.CmbAcctCode.Name = "CmbAcctCode";
            this.CmbAcctCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbAcctCode.Size = new System.Drawing.Size(281, 22);
            this.CmbAcctCode.TabIndex = 19;
            this.CmbAcctCode.SelectedIndexChanged += new System.EventHandler(this.CmbAcctCode_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(16, 423);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(73, 22);
            this.Label3.TabIndex = 20;
            this.Label3.Text = "Acct Code";
            // 
            // CmbAcctType
            // 
            this.CmbAcctType.BackColor = System.Drawing.SystemColors.Window;
            this.CmbAcctType.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbAcctType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAcctType.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAcctType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbAcctType.Location = new System.Drawing.Point(96, 397);
            this.CmbAcctType.Name = "CmbAcctType";
            this.CmbAcctType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbAcctType.Size = new System.Drawing.Size(97, 22);
            this.CmbAcctType.TabIndex = 21;
            this.CmbAcctType.SelectedIndexChanged += new System.EventHandler(this.CmbAcctType_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(16, 398);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(74, 25);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Acct Type";
            // 
            // gvActivaPassiva
            // 
            this.gvActivaPassiva.AllowUserToAddRows = false;
            this.gvActivaPassiva.AllowUserToDeleteRows = false;
            this.gvActivaPassiva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvActivaPassiva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvActivaPassiva.Location = new System.Drawing.Point(19, 70);
            this.gvActivaPassiva.MultiSelect = false;
            this.gvActivaPassiva.Name = "gvActivaPassiva";
            this.gvActivaPassiva.ReadOnly = true;
            this.gvActivaPassiva.Size = new System.Drawing.Size(537, 317);
            this.gvActivaPassiva.TabIndex = 23;
            // 
            // Setup_Activa_Passiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(576, 546);
            this.Controls.Add(this.gvActivaPassiva);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CmbAcctType);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.CmbAcctCode);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.lblCurr);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.CmdSetup);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_Activa_Passiva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activa Passiva Setup";
            this.Load += new System.EventHandler(this.Setup_Activa_Passiva_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvActivaPassiva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdSetup;
        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnAcctTypeRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnAcctRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrRateSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.TextBox txtBalance;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label lblCurr;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox CmbAcctCode;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbAcctType;
        public System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView gvActivaPassiva;
    }
}