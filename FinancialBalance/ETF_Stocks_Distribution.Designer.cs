namespace FinancialBalance
{
    partial class ETF_Stocks_Distribution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Distribution));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.LblFilterCaption = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbFilterTicker = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbFilterPortfolio = new System.Windows.Forms.ComboBox();
            this.LblFilterDesc = new System.Windows.Forms.Label();
            this.gvDist = new System.Windows.Forms.DataGridView();
            this.LblEntryCaption = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbDD = new System.Windows.Forms.ComboBox();
            this.CmbMM = new System.Windows.Forms.ComboBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.CmdCal = new System.Windows.Forms.Button();
            this.LblDay = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Label4 = new System.Windows.Forms.Label();
            this.CmbFullTicker = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.LblPortfolioDesc = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtEntitledUnit = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtAmountPerUnit = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.chkDrip = new System.Windows.Forms.CheckBox();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdClear = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDist)).BeginInit();
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
            this.MainMenu1.Size = new System.Drawing.Size(1000, 24);
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
            this.MnETFStocksPrice,
            this.MnETFStocksInvestment,
            this.MnETFStocksTrans});
            this.MnETFStockProcessGroup.Name = "MnETFStockProcessGroup";
            this.MnETFStockProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockProcessGroup.Text = "&ETF/Stock";
            //
            // MnETFStocksPrice
            //
            this.MnETFStocksPrice.Name = "MnETFStocksPrice";
            this.MnETFStocksPrice.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksPrice.Text = "ETF/Stock &Price";
            this.MnETFStocksPrice.Click += new System.EventHandler(this.MnETFStocksPrice_Click);
            //
            // MnETFStocksInvestment
            //
            this.MnETFStocksInvestment.Name = "MnETFStocksInvestment";
            this.MnETFStocksInvestment.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksInvestment.Text = "ETF/Stock &Investment";
            this.MnETFStocksInvestment.Click += new System.EventHandler(this.MnETFStocksInvestment_Click);
            //
            // MnETFStocksTrans
            //
            this.MnETFStocksTrans.Name = "MnETFStocksTrans";
            this.MnETFStocksTrans.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksTrans.Text = "ETF/Stock &Transaction";
            this.MnETFStocksTrans.Click += new System.EventHandler(this.MnETFStocksTrans_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(120, 30);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(760, 36);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK DISTRIBUTION / DIVIDEND";
            //
            // LblFilterCaption
            //
            this.LblFilterCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblFilterCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFilterCaption.ForeColor = System.Drawing.Color.Black;
            this.LblFilterCaption.Location = new System.Drawing.Point(19, 76);
            this.LblFilterCaption.Name = "LblFilterCaption";
            this.LblFilterCaption.Size = new System.Drawing.Size(400, 20);
            this.LblFilterCaption.TabIndex = 2;
            this.LblFilterCaption.Text = "Show";
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 104);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(110, 22);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Full Ticker";
            //
            // CmbFilterTicker
            //
            this.CmbFilterTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFilterTicker.FormattingEnabled = true;
            this.CmbFilterTicker.Location = new System.Drawing.Point(135, 102);
            this.CmbFilterTicker.Name = "CmbFilterTicker";
            this.CmbFilterTicker.Size = new System.Drawing.Size(150, 22);
            this.CmbFilterTicker.TabIndex = 4;
            this.CmbFilterTicker.SelectedIndexChanged += new System.EventHandler(this.CmbFilterTicker_SelectedIndexChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(305, 104);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 22);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Portfolio";
            //
            // CmbFilterPortfolio
            //
            this.CmbFilterPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFilterPortfolio.FormattingEnabled = true;
            this.CmbFilterPortfolio.Location = new System.Drawing.Point(390, 102);
            this.CmbFilterPortfolio.Name = "CmbFilterPortfolio";
            this.CmbFilterPortfolio.Size = new System.Drawing.Size(140, 22);
            this.CmbFilterPortfolio.TabIndex = 6;
            this.CmbFilterPortfolio.SelectedIndexChanged += new System.EventHandler(this.CmbFilterPortfolio_SelectedIndexChanged);
            //
            // LblFilterDesc
            //
            this.LblFilterDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblFilterDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFilterDesc.ForeColor = System.Drawing.Color.Black;
            this.LblFilterDesc.Location = new System.Drawing.Point(540, 104);
            this.LblFilterDesc.Name = "LblFilterDesc";
            this.LblFilterDesc.Size = new System.Drawing.Size(250, 22);
            this.LblFilterDesc.TabIndex = 7;
            //
            // gvDist
            //
            this.gvDist.AllowUserToAddRows = false;
            this.gvDist.AllowUserToDeleteRows = false;
            this.gvDist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvDist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDist.Location = new System.Drawing.Point(19, 132);
            this.gvDist.MultiSelect = false;
            this.gvDist.Name = "gvDist";
            this.gvDist.ReadOnly = true;
            this.gvDist.RowHeadersVisible = false;
            this.gvDist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDist.Size = new System.Drawing.Size(950, 170);
            this.gvDist.TabIndex = 8;
            this.gvDist.SelectionChanged += new System.EventHandler(this.gvDist_SelectionChanged);
            //
            // LblEntryCaption
            //
            this.LblEntryCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblEntryCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEntryCaption.ForeColor = System.Drawing.Color.Black;
            this.LblEntryCaption.Location = new System.Drawing.Point(19, 312);
            this.LblEntryCaption.Name = "LblEntryCaption";
            this.LblEntryCaption.Size = new System.Drawing.Size(500, 20);
            this.LblEntryCaption.TabIndex = 9;
            this.LblEntryCaption.Text = "Distribution / dividend";
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(19, 342);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(120, 22);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "Pay Date";
            //
            // CmbDD
            //
            this.CmbDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDD.FormattingEnabled = true;
            this.CmbDD.Location = new System.Drawing.Point(145, 340);
            this.CmbDD.Name = "CmbDD";
            this.CmbDD.Size = new System.Drawing.Size(41, 22);
            this.CmbDD.TabIndex = 11;
            this.CmbDD.SelectedIndexChanged += new System.EventHandler(this.CmbDD_SelectedIndexChanged);
            //
            // CmbMM
            //
            this.CmbMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMM.FormattingEnabled = true;
            this.CmbMM.Location = new System.Drawing.Point(195, 340);
            this.CmbMM.Name = "CmbMM";
            this.CmbMM.Size = new System.Drawing.Size(41, 22);
            this.CmbMM.TabIndex = 12;
            this.CmbMM.SelectedIndexChanged += new System.EventHandler(this.CmbMM_SelectedIndexChanged);
            //
            // CmbYear
            //
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.FormattingEnabled = true;
            this.CmbYear.Location = new System.Drawing.Point(245, 340);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 13;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            //
            // CmdCal
            //
            this.CmdCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCal.Location = new System.Drawing.Point(309, 340);
            this.CmdCal.Name = "CmdCal";
            this.CmdCal.Size = new System.Drawing.Size(25, 19);
            this.CmdCal.TabIndex = 14;
            this.CmdCal.Text = "...";
            this.CmdCal.UseVisualStyleBackColor = false;
            this.CmdCal.Click += new System.EventHandler(this.CmdCal_Click);
            //
            // LblDay
            //
            this.LblDay.BackColor = System.Drawing.Color.Transparent;
            this.LblDay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDay.Location = new System.Drawing.Point(345, 343);
            this.LblDay.Name = "LblDay";
            this.LblDay.Size = new System.Drawing.Size(110, 17);
            this.LblDay.TabIndex = 15;
            //
            // monthCalendar1
            //
            this.monthCalendar1.Location = new System.Drawing.Point(500, 350);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 16;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            //
            // Label4
            //
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(19, 372);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(120, 22);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Full Ticker";
            //
            // CmbFullTicker
            //
            this.CmbFullTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFullTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFullTicker.FormattingEnabled = true;
            this.CmbFullTicker.Location = new System.Drawing.Point(145, 370);
            this.CmbFullTicker.Name = "CmbFullTicker";
            this.CmbFullTicker.Size = new System.Drawing.Size(157, 22);
            this.CmbFullTicker.TabIndex = 18;
            //
            // Label5
            //
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(19, 402);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(120, 22);
            this.Label5.TabIndex = 19;
            this.Label5.Text = "Portfolio";
            //
            // CmbPortfolio
            //
            this.CmbPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPortfolio.FormattingEnabled = true;
            this.CmbPortfolio.Location = new System.Drawing.Point(145, 400);
            this.CmbPortfolio.Name = "CmbPortfolio";
            this.CmbPortfolio.Size = new System.Drawing.Size(157, 22);
            this.CmbPortfolio.TabIndex = 20;
            this.CmbPortfolio.SelectedIndexChanged += new System.EventHandler(this.CmbPortfolio_SelectedIndexChanged);
            //
            // LblPortfolioDesc
            //
            this.LblPortfolioDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblPortfolioDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPortfolioDesc.ForeColor = System.Drawing.Color.Black;
            this.LblPortfolioDesc.Location = new System.Drawing.Point(312, 402);
            this.LblPortfolioDesc.Name = "LblPortfolioDesc";
            this.LblPortfolioDesc.Size = new System.Drawing.Size(250, 22);
            this.LblPortfolioDesc.TabIndex = 21;
            //
            // Label6
            //
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(19, 432);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(120, 22);
            this.Label6.TabIndex = 22;
            this.Label6.Text = "Currency";
            //
            // CmbCurrency
            //
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(145, 430);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(157, 22);
            this.CmbCurrency.TabIndex = 23;
            //
            // Label7
            //
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(19, 462);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(120, 22);
            this.Label7.TabIndex = 24;
            this.Label7.Text = "Entitled Unit";
            //
            // txtEntitledUnit
            //
            this.txtEntitledUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtEntitledUnit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntitledUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEntitledUnit.Location = new System.Drawing.Point(145, 462);
            this.txtEntitledUnit.MaxLength = 20;
            this.txtEntitledUnit.Name = "txtEntitledUnit";
            this.txtEntitledUnit.Size = new System.Drawing.Size(157, 20);
            this.txtEntitledUnit.TabIndex = 25;
            this.txtEntitledUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEntitledUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtEntitledUnit.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            //
            // Label8
            //
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(19, 492);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(120, 22);
            this.Label8.TabIndex = 26;
            this.Label8.Text = "Amount Per Unit";
            //
            // txtAmountPerUnit
            //
            this.txtAmountPerUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmountPerUnit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmountPerUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAmountPerUnit.Location = new System.Drawing.Point(145, 492);
            this.txtAmountPerUnit.MaxLength = 20;
            this.txtAmountPerUnit.Name = "txtAmountPerUnit";
            this.txtAmountPerUnit.Size = new System.Drawing.Size(157, 20);
            this.txtAmountPerUnit.TabIndex = 27;
            this.txtAmountPerUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountPerUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            this.txtAmountPerUnit.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            //
            // Label9
            //
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(19, 522);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(120, 22);
            this.Label9.TabIndex = 28;
            this.Label9.Text = "Total Amount";
            //
            // txtTotalAmount
            //
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalAmount.Location = new System.Drawing.Point(145, 522);
            this.txtTotalAmount.MaxLength = 20;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(157, 20);
            this.txtTotalAmount.TabIndex = 29;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            //
            // chkDrip
            //
            this.chkDrip.BackColor = System.Drawing.Color.Transparent;
            this.chkDrip.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDrip.ForeColor = System.Drawing.Color.Black;
            this.chkDrip.Location = new System.Drawing.Point(145, 550);
            this.chkDrip.Name = "chkDrip";
            this.chkDrip.Size = new System.Drawing.Size(100, 22);
            this.chkDrip.TabIndex = 30;
            this.chkDrip.Text = "Reinvested";
            this.chkDrip.UseVisualStyleBackColor = false;
            //
            // CmdCreate
            //
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(145, 582);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(85, 27);
            this.CmdCreate.TabIndex = 31;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdUpdate.Location = new System.Drawing.Point(240, 582);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(85, 27);
            this.CmdUpdate.TabIndex = 32;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(335, 582);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 27);
            this.CmdDel.TabIndex = 33;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            //
            // CmdClear
            //
            this.CmdClear.BackColor = System.Drawing.SystemColors.Control;
            this.CmdClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdClear.Location = new System.Drawing.Point(430, 582);
            this.CmdClear.Name = "CmdClear";
            this.CmdClear.Size = new System.Drawing.Size(85, 27);
            this.CmdClear.TabIndex = 34;
            this.CmdClear.Text = "&Clear";
            this.CmdClear.UseVisualStyleBackColor = false;
            this.CmdClear.Click += new System.EventHandler(this.CmdClear_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(884, 582);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 35;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Distribution
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1000, 625);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdClear);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.chkDrip);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtAmountPerUnit);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtEntitledUnit);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.LblPortfolioDesc);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.CmbFullTicker);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.LblDay);
            this.Controls.Add(this.CmdCal);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.CmbMM);
            this.Controls.Add(this.CmbDD);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.LblEntryCaption);
            this.Controls.Add(this.gvDist);
            this.Controls.Add(this.LblFilterDesc);
            this.Controls.Add(this.CmbFilterPortfolio);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CmbFilterTicker);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.LblFilterCaption);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "ETF_Stocks_Distribution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Distribution/Dividend";
            this.Load += new System.EventHandler(this.ETF_Stocks_Distribution_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnDaily;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksInvestment;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksTrans;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label LblFilterCaption;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbFilterTicker;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbFilterPortfolio;
        public System.Windows.Forms.Label LblFilterDesc;
        private System.Windows.Forms.DataGridView gvDist;
        public System.Windows.Forms.Label LblEntryCaption;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbDD;
        public System.Windows.Forms.ComboBox CmbMM;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Button CmdCal;
        public System.Windows.Forms.Label LblDay;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox CmbFullTicker;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.Label LblPortfolioDesc;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.TextBox txtEntitledUnit;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.TextBox txtAmountPerUnit;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.TextBox txtTotalAmount;
        public System.Windows.Forms.CheckBox chkDrip;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdClear;
        public System.Windows.Forms.Button CmdBack;
    }
}
