namespace FinancialBalance
{
    partial class ETF_Stocks_Portfolio_Diversification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Portfolio_Diversification));
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.pnlCharts = new System.Windows.Forms.FlowLayoutPanel();
            this.CmdBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(20, 18);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(920, 41);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK PORTFOLIO DIVERSIFICATION";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 70);
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
            this.CmbPortfolio.Location = new System.Drawing.Point(105, 68);
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
            this.chkMainOnly.Location = new System.Drawing.Point(380, 68);
            this.chkMainOnly.Name = "chkMainOnly";
            this.chkMainOnly.Size = new System.Drawing.Size(100, 24);
            this.chkMainOnly.TabIndex = 3;
            this.chkMainOnly.Text = "Main Only";
            this.chkMainOnly.UseVisualStyleBackColor = false;
            this.chkMainOnly.CheckedChanged += new System.EventHandler(this.chkMainOnly_CheckedChanged);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblNote.Location = new System.Drawing.Point(492, 72);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(448, 20);
            this.LblNote.TabIndex = 4;
            this.LblNote.Text = "";
            //
            // pnlCharts
            //
            this.pnlCharts.AutoScroll = true;
            this.pnlCharts.BackColor = System.Drawing.Color.Transparent;
            this.pnlCharts.Location = new System.Drawing.Point(19, 98);
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.Size = new System.Drawing.Size(922, 500);
            this.pnlCharts.TabIndex = 5;
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(436, 612);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(89, 27);
            this.CmdBack.TabIndex = 6;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Portfolio_Diversification
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(960, 652);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.pnlCharts);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Portfolio_Diversification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Portfolio Diversification";
            this.Load += new System.EventHandler(this.ETF_Stocks_Portfolio_Diversification_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.CheckBox chkMainOnly;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.FlowLayoutPanel pnlCharts;
        public System.Windows.Forms.Button CmdBack;
    }
}
