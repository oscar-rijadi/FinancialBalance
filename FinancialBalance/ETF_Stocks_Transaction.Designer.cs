namespace FinancialBalance
{
    partial class ETF_Stocks_Transaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Transaction));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksInvestment = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.LblDateCaption = new System.Windows.Forms.Label();
            this.CmbDD = new System.Windows.Forms.ComboBox();
            this.CmbMM = new System.Windows.Forms.ComboBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.CmdCal = new System.Windows.Forms.Button();
            this.LblDay = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.gvTrans = new System.Windows.Forms.DataGridView();
            this.LblLots = new System.Windows.Forms.Label();
            this.gvLots = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.CmbTransType = new System.Windows.Forms.ComboBox();
            this.CmbFullTicker = new System.Windows.Forms.ComboBox();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtCostBase = new System.Windows.Forms.TextBox();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.txtTotalCostBase = new System.Windows.Forms.TextBox();
            this.txtRealTotalCostBase = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtSellingPricePerUnit = new System.Windows.Forms.TextBox();
            this.txtSellingTotalAmount = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.CmbFlagCode = new System.Windows.Forms.ComboBox();
            this.LblPortfolioDesc = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.CmbSellPortfolio = new System.Windows.Forms.ComboBox();
            this.LblSellPortfolioDesc = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.CmbSoldDD = new System.Windows.Forms.ComboBox();
            this.CmbSoldMM = new System.Windows.Forms.ComboBox();
            this.CmbSoldYear = new System.Windows.Forms.ComboBox();
            this.CmdSoldCal = new System.Windows.Forms.Button();
            this.chkDRIP = new System.Windows.Forms.CheckBox();
            this.chkSold = new System.Windows.Forms.CheckBox();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLots)).BeginInit();
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
            this.MnETFStocksInvestment});
            this.MnETFStockProcessGroup.Name = "MnETFStockProcessGroup";
            this.MnETFStockProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockProcessGroup.Text = "&ETF/Stock";
            // 
            // MnETFStocksPrice
            // 
            this.MnETFStocksPrice.Name = "MnETFStocksPrice";
            this.MnETFStocksPrice.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksPrice.Text = "ETF/Stock &Price";
            this.MnETFStocksPrice.Click += new System.EventHandler(this.MnETFStocksPrice_Click);
            //
            // MnETFStocksInvestment
            //
            this.MnETFStocksInvestment.Name = "MnETFStocksInvestment";
            this.MnETFStocksInvestment.Size = new System.Drawing.Size(104, 20);
            this.MnETFStocksInvestment.Text = "ETF/Stock &Investment";
            this.MnETFStocksInvestment.Click += new System.EventHandler(this.MnETFStocksInvestment_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(280, 28);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(460, 41);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK TRANSACTION";
            //
            // LblDateCaption
            //
            this.LblDateCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblDateCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDateCaption.ForeColor = System.Drawing.Color.Black;
            this.LblDateCaption.Location = new System.Drawing.Point(19, 86);
            this.LblDateCaption.Name = "LblDateCaption";
            this.LblDateCaption.Size = new System.Drawing.Size(40, 20);
            this.LblDateCaption.TabIndex = 2;
            this.LblDateCaption.Text = "Date";
            //
            // CmbDD
            //
            this.CmbDD.BackColor = System.Drawing.SystemColors.Window;
            this.CmbDD.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbDD.Location = new System.Drawing.Point(62, 83);
            this.CmbDD.Name = "CmbDD";
            this.CmbDD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbDD.Size = new System.Drawing.Size(41, 22);
            this.CmbDD.TabIndex = 3;
            this.CmbDD.SelectedIndexChanged += new System.EventHandler(this.CmbDD_SelectedIndexChanged);
            //
            // CmbMM
            //
            this.CmbMM.BackColor = System.Drawing.SystemColors.Window;
            this.CmbMM.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbMM.Location = new System.Drawing.Point(112, 83);
            this.CmbMM.Name = "CmbMM";
            this.CmbMM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbMM.Size = new System.Drawing.Size(41, 22);
            this.CmbMM.TabIndex = 4;
            this.CmbMM.SelectedIndexChanged += new System.EventHandler(this.CmbMM_SelectedIndexChanged);
            //
            // CmbYear
            //
            this.CmbYear.BackColor = System.Drawing.SystemColors.Window;
            this.CmbYear.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbYear.Location = new System.Drawing.Point(162, 83);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 5;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            //
            // CmdCal
            //
            this.CmdCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCal.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCal.Location = new System.Drawing.Point(226, 83);
            this.CmdCal.Name = "CmdCal";
            this.CmdCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdCal.Size = new System.Drawing.Size(25, 19);
            this.CmdCal.TabIndex = 6;
            this.CmdCal.Text = "..";
            this.CmdCal.UseVisualStyleBackColor = false;
            this.CmdCal.Click += new System.EventHandler(this.CmdCal_Click);
            //
            // LblDay
            //
            this.LblDay.BackColor = System.Drawing.Color.Transparent;
            this.LblDay.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblDay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblDay.Location = new System.Drawing.Point(262, 86);
            this.LblDay.Name = "LblDay";
            this.LblDay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDay.Size = new System.Drawing.Size(91, 17);
            this.LblDay.TabIndex = 7;
            this.LblDay.Text = "Monday";
            //
            // monthCalendar1
            //
            this.monthCalendar1.Location = new System.Drawing.Point(400, 83);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            //
            // gvTrans
            //
            this.gvTrans.AllowUserToAddRows = false;
            this.gvTrans.AllowUserToDeleteRows = false;
            this.gvTrans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTrans.Location = new System.Drawing.Point(19, 115);
            this.gvTrans.MultiSelect = false;
            this.gvTrans.Name = "gvTrans";
            this.gvTrans.ReadOnly = true;
            this.gvTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTrans.Size = new System.Drawing.Size(960, 210);
            this.gvTrans.TabIndex = 9;
            this.gvTrans.SelectionChanged += new System.EventHandler(this.gvTrans_SelectionChanged);
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 340);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(125, 22);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Transaction Type";
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(19, 368);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(125, 22);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Full Ticker";
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(19, 396);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(125, 22);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Currency";
            //
            // Label4
            //
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(19, 424);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(125, 22);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Unit";
            //
            // Label5
            //
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(460, 340);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(160, 22);
            this.Label5.TabIndex = 14;
            this.Label5.Text = "Cost Base";
            //
            // Label6
            //
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(460, 368);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(160, 22);
            this.Label6.TabIndex = 15;
            this.Label6.Text = "Fee";
            //
            // Label7
            //
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(460, 396);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(160, 22);
            this.Label7.TabIndex = 16;
            this.Label7.Text = "Total Cost Base";
            //
            // Label8
            //
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(460, 424);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(160, 22);
            this.Label8.TabIndex = 17;
            this.Label8.Text = "Real Total Cost Base";
            //
            // CmbTransType
            //
            this.CmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTransType.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTransType.FormattingEnabled = true;
            this.CmbTransType.Location = new System.Drawing.Point(150, 340);
            this.CmbTransType.Name = "CmbTransType";
            this.CmbTransType.Size = new System.Drawing.Size(140, 22);
            this.CmbTransType.TabIndex = 18;
            this.CmbTransType.SelectedIndexChanged += new System.EventHandler(this.CmbTransType_SelectedIndexChanged);
            //
            // CmbFullTicker
            //
            this.CmbFullTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFullTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFullTicker.FormattingEnabled = true;
            this.CmbFullTicker.Location = new System.Drawing.Point(150, 368);
            this.CmbFullTicker.Name = "CmbFullTicker";
            this.CmbFullTicker.Size = new System.Drawing.Size(140, 22);
            this.CmbFullTicker.TabIndex = 19;
            this.CmbFullTicker.SelectedIndexChanged += new System.EventHandler(this.CmbFullTicker_SelectedIndexChanged);
            //
            // CmbCurrency
            //
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(150, 396);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(140, 22);
            this.CmbCurrency.TabIndex = 20;
            //
            // txtUnit
            //
            this.txtUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtUnit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnit.Location = new System.Drawing.Point(150, 424);
            this.txtUnit.MaxLength = 20;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnit.Size = new System.Drawing.Size(140, 20);
            this.txtUnit.TabIndex = 21;
            this.txtUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnit.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            this.txtUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnit_KeyPress);
            //
            // txtCostBase
            //
            this.txtCostBase.BackColor = System.Drawing.SystemColors.Window;
            this.txtCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCostBase.Location = new System.Drawing.Point(625, 340);
            this.txtCostBase.MaxLength = 20;
            this.txtCostBase.Name = "txtCostBase";
            this.txtCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCostBase.Size = new System.Drawing.Size(140, 20);
            this.txtCostBase.TabIndex = 22;
            this.txtCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostBase.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            this.txtCostBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostBase_KeyPress);
            //
            // txtFee
            //
            this.txtFee.BackColor = System.Drawing.SystemColors.Window;
            this.txtFee.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFee.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFee.Location = new System.Drawing.Point(625, 368);
            this.txtFee.MaxLength = 20;
            this.txtFee.Name = "txtFee";
            this.txtFee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFee.Size = new System.Drawing.Size(140, 20);
            this.txtFee.TabIndex = 23;
            this.txtFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFee.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            this.txtFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFee_KeyPress);
            //
            // txtTotalCostBase
            //
            this.txtTotalCostBase.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTotalCostBase.Location = new System.Drawing.Point(625, 396);
            this.txtTotalCostBase.Name = "txtTotalCostBase";
            this.txtTotalCostBase.ReadOnly = true;
            this.txtTotalCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalCostBase.Size = new System.Drawing.Size(140, 20);
            this.txtTotalCostBase.TabIndex = 24;
            this.txtTotalCostBase.TabStop = false;
            this.txtTotalCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // txtRealTotalCostBase
            //
            this.txtRealTotalCostBase.BackColor = System.Drawing.SystemColors.Control;
            this.txtRealTotalCostBase.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRealTotalCostBase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRealTotalCostBase.Location = new System.Drawing.Point(625, 424);
            this.txtRealTotalCostBase.Name = "txtRealTotalCostBase";
            this.txtRealTotalCostBase.ReadOnly = true;
            this.txtRealTotalCostBase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRealTotalCostBase.Size = new System.Drawing.Size(140, 20);
            this.txtRealTotalCostBase.TabIndex = 25;
            this.txtRealTotalCostBase.TabStop = false;
            this.txtRealTotalCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // Label9
            //
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(460, 340);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(160, 22);
            this.Label9.TabIndex = 32;
            this.Label9.Text = "Selling Price/Unit";
            //
            // Label10
            //
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(460, 368);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(160, 22);
            this.Label10.TabIndex = 33;
            this.Label10.Text = "Selling Total Amount";
            //
            // txtSellingPricePerUnit
            //
            this.txtSellingPricePerUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtSellingPricePerUnit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellingPricePerUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSellingPricePerUnit.Location = new System.Drawing.Point(625, 340);
            this.txtSellingPricePerUnit.MaxLength = 20;
            this.txtSellingPricePerUnit.Name = "txtSellingPricePerUnit";
            this.txtSellingPricePerUnit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSellingPricePerUnit.Size = new System.Drawing.Size(140, 20);
            this.txtSellingPricePerUnit.TabIndex = 34;
            this.txtSellingPricePerUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSellingPricePerUnit.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            this.txtSellingPricePerUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSellingPricePerUnit_KeyPress);
            //
            // txtSellingTotalAmount
            //
            this.txtSellingTotalAmount.BackColor = System.Drawing.SystemColors.Control;
            this.txtSellingTotalAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellingTotalAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSellingTotalAmount.Location = new System.Drawing.Point(625, 368);
            this.txtSellingTotalAmount.Name = "txtSellingTotalAmount";
            this.txtSellingTotalAmount.ReadOnly = true;
            this.txtSellingTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSellingTotalAmount.Size = new System.Drawing.Size(140, 20);
            this.txtSellingTotalAmount.TabIndex = 35;
            this.txtSellingTotalAmount.TabStop = false;
            this.txtSellingTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // Label11
            //
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(460, 452);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(160, 22);
            this.Label11.TabIndex = 36;
            this.Label11.Text = "Portfolio";
            //
            // CmbFlagCode
            //
            this.CmbFlagCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFlagCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFlagCode.FormattingEnabled = true;
            this.CmbFlagCode.Location = new System.Drawing.Point(625, 450);
            this.CmbFlagCode.Name = "CmbFlagCode";
            this.CmbFlagCode.Size = new System.Drawing.Size(140, 22);
            this.CmbFlagCode.TabIndex = 37;
            this.CmbFlagCode.SelectedIndexChanged += new System.EventHandler(this.CmbFlagCode_SelectedIndexChanged);
            //
            // LblPortfolioDesc
            //
            this.LblPortfolioDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblPortfolioDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPortfolioDesc.ForeColor = System.Drawing.Color.Black;
            this.LblPortfolioDesc.Location = new System.Drawing.Point(775, 452);
            this.LblPortfolioDesc.Name = "LblPortfolioDesc";
            this.LblPortfolioDesc.Size = new System.Drawing.Size(210, 22);
            this.LblPortfolioDesc.TabIndex = 60;
            //
            // Label13
            //
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(460, 398);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(160, 22);
            this.Label13.TabIndex = 61;
            this.Label13.Text = "Portfolio";
            //
            // CmbSellPortfolio
            //
            this.CmbSellPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSellPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSellPortfolio.FormattingEnabled = true;
            this.CmbSellPortfolio.Location = new System.Drawing.Point(625, 396);
            this.CmbSellPortfolio.Name = "CmbSellPortfolio";
            this.CmbSellPortfolio.Size = new System.Drawing.Size(140, 22);
            this.CmbSellPortfolio.TabIndex = 62;
            this.CmbSellPortfolio.SelectedIndexChanged += new System.EventHandler(this.CmbSellPortfolio_SelectedIndexChanged);
            //
            // LblSellPortfolioDesc
            //
            this.LblSellPortfolioDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblSellPortfolioDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSellPortfolioDesc.ForeColor = System.Drawing.Color.Black;
            this.LblSellPortfolioDesc.Location = new System.Drawing.Point(775, 398);
            this.LblSellPortfolioDesc.Name = "LblSellPortfolioDesc";
            this.LblSellPortfolioDesc.Size = new System.Drawing.Size(210, 22);
            this.LblSellPortfolioDesc.TabIndex = 63;
            //
            // Label12
            //
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(19, 480);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(125, 22);
            this.Label12.TabIndex = 38;
            this.Label12.Text = "Sold Date";
            //
            // CmbSoldDD
            //
            this.CmbSoldDD.BackColor = System.Drawing.SystemColors.Window;
            this.CmbSoldDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldDD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSoldDD.Location = new System.Drawing.Point(150, 478);
            this.CmbSoldDD.Name = "CmbSoldDD";
            this.CmbSoldDD.Size = new System.Drawing.Size(41, 22);
            this.CmbSoldDD.TabIndex = 39;
            //
            // CmbSoldMM
            //
            this.CmbSoldMM.BackColor = System.Drawing.SystemColors.Window;
            this.CmbSoldMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldMM.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSoldMM.Location = new System.Drawing.Point(200, 478);
            this.CmbSoldMM.Name = "CmbSoldMM";
            this.CmbSoldMM.Size = new System.Drawing.Size(41, 22);
            this.CmbSoldMM.TabIndex = 40;
            //
            // CmbSoldYear
            //
            this.CmbSoldYear.BackColor = System.Drawing.SystemColors.Window;
            this.CmbSoldYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSoldYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSoldYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbSoldYear.Location = new System.Drawing.Point(250, 478);
            this.CmbSoldYear.Name = "CmbSoldYear";
            this.CmbSoldYear.Size = new System.Drawing.Size(57, 22);
            this.CmbSoldYear.TabIndex = 41;
            //
            // CmdSoldCal
            //
            this.CmdSoldCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdSoldCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdSoldCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdSoldCal.Location = new System.Drawing.Point(314, 478);
            this.CmdSoldCal.Name = "CmdSoldCal";
            this.CmdSoldCal.Size = new System.Drawing.Size(25, 19);
            this.CmdSoldCal.TabIndex = 42;
            this.CmdSoldCal.Text = "..";
            this.CmdSoldCal.UseVisualStyleBackColor = false;
            this.CmdSoldCal.Click += new System.EventHandler(this.CmdSoldCal_Click);
            //
            // chkDRIP
            //
            this.chkDRIP.BackColor = System.Drawing.Color.Transparent;
            this.chkDRIP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDRIP.Location = new System.Drawing.Point(150, 452);
            this.chkDRIP.Name = "chkDRIP";
            this.chkDRIP.Size = new System.Drawing.Size(80, 24);
            this.chkDRIP.TabIndex = 26;
            this.chkDRIP.Text = "DRIP";
            this.chkDRIP.UseVisualStyleBackColor = false;
            this.chkDRIP.CheckedChanged += new System.EventHandler(this.chkDRIP_CheckedChanged);
            //
            // chkSold
            //
            this.chkSold.BackColor = System.Drawing.Color.Transparent;
            this.chkSold.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSold.Location = new System.Drawing.Point(240, 452);
            this.chkSold.Name = "chkSold";
            this.chkSold.Size = new System.Drawing.Size(80, 24);
            this.chkSold.TabIndex = 27;
            this.chkSold.Text = "Sold";
            this.chkSold.UseVisualStyleBackColor = false;
            this.chkSold.CheckedChanged += new System.EventHandler(this.chkSold_CheckedChanged);
            //
            // CmdCreate
            //
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(305, 610);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(85, 27);
            this.CmdCreate.TabIndex = 28;
            this.CmdCreate.Text = "&Add";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdUpdate.Location = new System.Drawing.Point(400, 610);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(85, 27);
            this.CmdUpdate.TabIndex = 29;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdDel
            //
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(495, 610);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.Size = new System.Drawing.Size(85, 27);
            this.CmdDel.TabIndex = 30;
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
            this.CmdBack.Location = new System.Drawing.Point(590, 610);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 31;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // LblLots
            //
            this.LblLots.BackColor = System.Drawing.Color.Transparent;
            this.LblLots.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLots.ForeColor = System.Drawing.Color.Black;
            this.LblLots.Location = new System.Drawing.Point(19, 442);
            this.LblLots.Name = "LblLots";
            this.LblLots.Size = new System.Drawing.Size(600, 20);
            this.LblLots.TabIndex = 43;
            this.LblLots.Text = "Unsold purchases - enter how many units of each are being sold";
            this.LblLots.Visible = false;
            //
            // gvLots
            //
            this.gvLots.AllowUserToAddRows = false;
            this.gvLots.AllowUserToDeleteRows = false;
            this.gvLots.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLots.Location = new System.Drawing.Point(19, 464);
            this.gvLots.MultiSelect = false;
            this.gvLots.Name = "gvLots";
            this.gvLots.RowHeadersVisible = false;
            this.gvLots.Size = new System.Drawing.Size(960, 130);
            this.gvLots.TabIndex = 44;
            this.gvLots.Visible = false;
            this.gvLots.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvLots_CellEndEdit);
            this.gvLots.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvLots_EditingControlShowing);
            //
            // ETF_Stocks_Transaction
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1000, 655);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.chkSold);
            this.Controls.Add(this.chkDRIP);
            this.Controls.Add(this.CmdSoldCal);
            this.Controls.Add(this.CmbSoldYear);
            this.Controls.Add(this.CmbSoldMM);
            this.Controls.Add(this.CmbSoldDD);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.CmbFlagCode);
            this.Controls.Add(this.LblSellPortfolioDesc);
            this.Controls.Add(this.CmbSellPortfolio);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.LblPortfolioDesc);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.txtSellingTotalAmount);
            this.Controls.Add(this.txtSellingPricePerUnit);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtRealTotalCostBase);
            this.Controls.Add(this.txtTotalCostBase);
            this.Controls.Add(this.txtFee);
            this.Controls.Add(this.txtCostBase);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.CmbFullTicker);
            this.Controls.Add(this.CmbTransType);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.gvLots);
            this.Controls.Add(this.LblLots);
            this.Controls.Add(this.gvTrans);
            this.Controls.Add(this.LblDay);
            this.Controls.Add(this.CmdCal);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.CmbMM);
            this.Controls.Add(this.CmbDD);
            this.Controls.Add(this.LblDateCaption);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "ETF_Stocks_Transaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Transaction";
            this.Load += new System.EventHandler(this.ETF_Stocks_Transaction_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLots)).EndInit();
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
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label LblDateCaption;
        public System.Windows.Forms.ComboBox CmbDD;
        public System.Windows.Forms.ComboBox CmbMM;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Button CmdCal;
        public System.Windows.Forms.Label LblDay;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView gvTrans;
        public System.Windows.Forms.Label LblLots;
        private System.Windows.Forms.DataGridView gvLots;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.ComboBox CmbTransType;
        public System.Windows.Forms.ComboBox CmbFullTicker;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.TextBox txtUnit;
        public System.Windows.Forms.TextBox txtCostBase;
        public System.Windows.Forms.TextBox txtFee;
        public System.Windows.Forms.TextBox txtTotalCostBase;
        public System.Windows.Forms.TextBox txtRealTotalCostBase;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.Label Label10;
        public System.Windows.Forms.TextBox txtSellingPricePerUnit;
        public System.Windows.Forms.TextBox txtSellingTotalAmount;
        public System.Windows.Forms.Label Label11;
        public System.Windows.Forms.Label LblPortfolioDesc;
        public System.Windows.Forms.Label Label13;
        public System.Windows.Forms.ComboBox CmbSellPortfolio;
        public System.Windows.Forms.Label LblSellPortfolioDesc;
        public System.Windows.Forms.ComboBox CmbFlagCode;
        public System.Windows.Forms.Label Label12;
        public System.Windows.Forms.ComboBox CmbSoldDD;
        public System.Windows.Forms.ComboBox CmbSoldMM;
        public System.Windows.Forms.ComboBox CmbSoldYear;
        public System.Windows.Forms.Button CmdSoldCal;
        public System.Windows.Forms.CheckBox chkDRIP;
        public System.Windows.Forms.CheckBox chkSold;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdBack;
    }
}
