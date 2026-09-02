namespace FinancialBalance
{
    partial class ETF_Stocks_Price
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Price));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbFullTicker = new System.Windows.Forms.ComboBox();
            this.CmdSync = new System.Windows.Forms.Button();
            this.LblSyncNote = new System.Windows.Forms.Label();
            this.gvPrice = new System.Windows.Forms.DataGridView();
            this.CmdSyncAll = new System.Windows.Forms.Button();
            this.LblAllCaption = new System.Windows.Forms.Label();
            this.gvAllPrices = new System.Windows.Forms.DataGridView();
            this.LblGridCaption = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbDD = new System.Windows.Forms.ComboBox();
            this.CmbMM = new System.Windows.Forms.ComboBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.CmdCal = new System.Windows.Forms.Button();
            this.LblDay = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllPrices)).BeginInit();
            this.SuspendLayout();
            //
            // MainMenu1
            //
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDaily,
            this.MnMonthlyClosing,
            this.MnETFStockProcessGroup});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(700, 24);
            this.MainMenu1.TabIndex = 0;
            //
            // MnDaily
            //
            this.MnDaily.Name = "MnDaily";
            this.MnDaily.Size = new System.Drawing.Size(71, 20);
            this.MnDaily.Text = "Daily &Input";
            this.MnDaily.Click += new System.EventHandler(this.MnDaily_Click);
            //
            // MnMonthlyClosing
            //
            this.MnMonthlyClosing.Name = "MnMonthlyClosing";
            this.MnMonthlyClosing.Size = new System.Drawing.Size(107, 20);
            this.MnMonthlyClosing.Text = "&Monthly Closing";
            this.MnMonthlyClosing.Click += new System.EventHandler(this.MnMonthlyClosing_Click);
            // 
            // MnETFStockProcessGroup
            // 
            this.MnETFStockProcessGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnETFStocksTrans,
            this.MnETFStocksInvestment});
            this.MnETFStockProcessGroup.Name = "MnETFStockProcessGroup";
            this.MnETFStockProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockProcessGroup.Text = "&ETF/Stock";
            //
            // MnETFStocksTrans
            //
            this.MnETFStocksTrans.Name = "MnETFStocksTrans";
            this.MnETFStocksTrans.Size = new System.Drawing.Size(137, 20);
            this.MnETFStocksTrans.Text = "ETF/Stock &Transaction";
            this.MnETFStocksTrans.Click += new System.EventHandler(this.MnETFStocksTrans_Click);
            //
            // MnETFStocksInvestment
            //
            this.MnETFStocksInvestment.Name = "MnETFStocksInvestment";
            this.MnETFStocksInvestment.Size = new System.Drawing.Size(137, 20);
            this.MnETFStocksInvestment.Text = "ETF/Stock &Investment";
            this.MnETFStocksInvestment.Click += new System.EventHandler(this.MnETFStocksInvestment_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(200, 28);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(320, 41);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK PRICE";
            //
            // CmdSyncAll
            //
            this.CmdSyncAll.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSyncAll.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSyncAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSyncAll.Location = new System.Drawing.Point(19, 78);
            this.CmdSyncAll.Name = "CmdSyncAll";
            this.CmdSyncAll.Size = new System.Drawing.Size(200, 27);
            this.CmdSyncAll.TabIndex = 20;
            this.CmdSyncAll.Text = "Sync &all with Yahoo Finance";
            this.CmdSyncAll.UseVisualStyleBackColor = false;
            this.CmdSyncAll.Click += new System.EventHandler(this.CmdSyncAll_Click);
            //
            // LblAllCaption
            //
            this.LblAllCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblAllCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAllCaption.ForeColor = System.Drawing.Color.Black;
            this.LblAllCaption.Location = new System.Drawing.Point(232, 84);
            this.LblAllCaption.Name = "LblAllCaption";
            this.LblAllCaption.Size = new System.Drawing.Size(450, 20);
            this.LblAllCaption.TabIndex = 21;
            this.LblAllCaption.Text = "Latest price of every ticker";
            //
            // gvAllPrices
            //
            this.gvAllPrices.AllowUserToAddRows = false;
            this.gvAllPrices.AllowUserToDeleteRows = false;
            this.gvAllPrices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAllPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAllPrices.Location = new System.Drawing.Point(19, 112);
            this.gvAllPrices.MultiSelect = false;
            this.gvAllPrices.Name = "gvAllPrices";
            this.gvAllPrices.ReadOnly = true;
            this.gvAllPrices.RowHeadersVisible = false;
            this.gvAllPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAllPrices.Size = new System.Drawing.Size(660, 150);
            this.gvAllPrices.TabIndex = 22;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 288);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(90, 22);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Full Ticker";
            //
            // CmbFullTicker
            //
            this.CmbFullTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFullTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFullTicker.FormattingEnabled = true;
            this.CmbFullTicker.Location = new System.Drawing.Point(115, 286);
            this.CmbFullTicker.Name = "CmbFullTicker";
            this.CmbFullTicker.Size = new System.Drawing.Size(150, 22);
            this.CmbFullTicker.TabIndex = 3;
            this.CmbFullTicker.SelectedIndexChanged += new System.EventHandler(this.CmbFullTicker_SelectedIndexChanged);
            //
            // CmdSync
            //
            this.CmdSync.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSync.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSync.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSync.Location = new System.Drawing.Point(290, 284);
            this.CmdSync.Name = "CmdSync";
            this.CmdSync.Size = new System.Drawing.Size(175, 27);
            this.CmdSync.TabIndex = 4;
            this.CmdSync.Text = "Sync with &Yahoo Finance";
            this.CmdSync.UseVisualStyleBackColor = false;
            this.CmdSync.Click += new System.EventHandler(this.CmdSync_Click);
            //
            // LblSyncNote
            //
            this.LblSyncNote.BackColor = System.Drawing.Color.Transparent;
            this.LblSyncNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSyncNote.ForeColor = System.Drawing.Color.DimGray;
            this.LblSyncNote.Location = new System.Drawing.Point(475, 290);
            this.LblSyncNote.Name = "LblSyncNote";
            this.LblSyncNote.Size = new System.Drawing.Size(210, 20);
            this.LblSyncNote.TabIndex = 5;
            this.LblSyncNote.Text = "";
            //
            // LblGridCaption
            //
            this.LblGridCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblGridCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGridCaption.ForeColor = System.Drawing.Color.Black;
            this.LblGridCaption.Location = new System.Drawing.Point(19, 320);
            this.LblGridCaption.Name = "LblGridCaption";
            this.LblGridCaption.Size = new System.Drawing.Size(400, 20);
            this.LblGridCaption.TabIndex = 6;
            this.LblGridCaption.Text = "Last 5 prices";
            //
            // gvPrice
            //
            this.gvPrice.AllowUserToAddRows = false;
            this.gvPrice.AllowUserToDeleteRows = false;
            this.gvPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPrice.Location = new System.Drawing.Point(19, 343);
            this.gvPrice.MultiSelect = false;
            this.gvPrice.Name = "gvPrice";
            this.gvPrice.ReadOnly = true;
            this.gvPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPrice.Size = new System.Drawing.Size(660, 160);
            this.gvPrice.TabIndex = 7;
            this.gvPrice.SelectionChanged += new System.EventHandler(this.gvPrice_SelectionChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(19, 510);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(90, 22);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Date";
            //
            // CmbDD
            //
            this.CmbDD.BackColor = System.Drawing.SystemColors.Window;
            this.CmbDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbDD.Location = new System.Drawing.Point(115, 508);
            this.CmbDD.Name = "CmbDD";
            this.CmbDD.Size = new System.Drawing.Size(41, 22);
            this.CmbDD.TabIndex = 9;
            this.CmbDD.SelectedIndexChanged += new System.EventHandler(this.CmbDD_SelectedIndexChanged);
            //
            // CmbMM
            //
            this.CmbMM.BackColor = System.Drawing.SystemColors.Window;
            this.CmbMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbMM.Location = new System.Drawing.Point(165, 508);
            this.CmbMM.Name = "CmbMM";
            this.CmbMM.Size = new System.Drawing.Size(41, 22);
            this.CmbMM.TabIndex = 10;
            this.CmbMM.SelectedIndexChanged += new System.EventHandler(this.CmbMM_SelectedIndexChanged);
            //
            // CmbYear
            //
            this.CmbYear.BackColor = System.Drawing.SystemColors.Window;
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbYear.Location = new System.Drawing.Point(215, 508);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 11;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            //
            // CmdCal
            //
            this.CmdCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCal.Location = new System.Drawing.Point(279, 508);
            this.CmdCal.Name = "CmdCal";
            this.CmdCal.Size = new System.Drawing.Size(25, 19);
            this.CmdCal.TabIndex = 12;
            this.CmdCal.Text = "..";
            this.CmdCal.UseVisualStyleBackColor = false;
            this.CmdCal.Click += new System.EventHandler(this.CmdCal_Click);
            //
            // LblDay
            //
            this.LblDay.BackColor = System.Drawing.Color.Transparent;
            this.LblDay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblDay.Location = new System.Drawing.Point(315, 511);
            this.LblDay.Name = "LblDay";
            this.LblDay.Size = new System.Drawing.Size(91, 17);
            this.LblDay.TabIndex = 13;
            this.LblDay.Text = "Monday";
            //
            // monthCalendar1
            //
            this.monthCalendar1.Location = new System.Drawing.Point(430, 440);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 14;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(19, 540);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(90, 22);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Price";
            //
            // txtPrice
            //
            this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrice.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(115, 540);
            this.txtPrice.MaxLength = 20;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(157, 20);
            this.txtPrice.TabIndex = 16;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            //
            // Label4
            //
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(19, 570);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(90, 22);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Currency";
            //
            // CmbCurrency
            //
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(115, 568);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(157, 22);
            this.CmbCurrency.TabIndex = 18;
            //
            // CmdAdd
            //
            this.CmdAdd.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAdd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdAdd.Location = new System.Drawing.Point(185, 615);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(100, 27);
            this.CmdAdd.TabIndex = 19;
            this.CmdAdd.Text = "&Add / Update";
            this.CmdAdd.UseVisualStyleBackColor = false;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(295, 615);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 27);
            this.CmdDel.TabIndex = 20;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(390, 615);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 21;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Price
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(700, 670);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.LblDay);
            this.Controls.Add(this.CmdCal);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.CmbMM);
            this.Controls.Add(this.CmbDD);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.gvPrice);
            this.Controls.Add(this.LblGridCaption);
            this.Controls.Add(this.LblSyncNote);
            this.Controls.Add(this.CmdSync);
            this.Controls.Add(this.CmbFullTicker);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.gvAllPrices);
            this.Controls.Add(this.LblAllCaption);
            this.Controls.Add(this.CmdSyncAll);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "ETF_Stocks_Price";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Price";
            this.Load += new System.EventHandler(this.ETF_Stocks_Price_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAllPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnDaily;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksTrans;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvestment;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbFullTicker;
        public System.Windows.Forms.Button CmdSync;
        public System.Windows.Forms.Label LblSyncNote;
        public System.Windows.Forms.Label LblGridCaption;
        private System.Windows.Forms.DataGridView gvPrice;
        public System.Windows.Forms.Button CmdSyncAll;
        public System.Windows.Forms.Label LblAllCaption;
        private System.Windows.Forms.DataGridView gvAllPrices;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbDD;
        public System.Windows.Forms.ComboBox CmbMM;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Button CmdCal;
        public System.Windows.Forms.Label LblDay;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.Button CmdAdd;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
