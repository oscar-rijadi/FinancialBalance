namespace FinancialBalance
{
    partial class ETF_Stocks_Investment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Investment));
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.MnMonthlyClosing = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockProcessGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.Label21 = new System.Windows.Forms.Label();
            this.LblGridCaption = new System.Windows.Forms.Label();
            this.gvPortfolio = new System.Windows.Forms.DataGridView();
            this.LblEntryCaption = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbDD = new System.Windows.Forms.ComboBox();
            this.CmbMM = new System.Windows.Forms.ComboBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.CmdCal = new System.Windows.Forms.Button();
            this.LblDay = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Label3 = new System.Windows.Forms.Label();
            this.CmbPortfolioCode = new System.Windows.Forms.ComboBox();
            this.LblPortfolioDesc = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.CmbInvType = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.LblEditCaption = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.CmbEditCurrency = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtEditCash = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtEditInvAmt = new System.Windows.Forms.TextBox();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdCancelEdit = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPortfolio)).BeginInit();
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
            this.MnETFStocksPrice,
            this.MnETFStocksDistribution,
            this.MnETFStocksTrans});
            this.MnETFStockProcessGroup.Name = "MnETFStockProcessGroup";
            this.MnETFStockProcessGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockProcessGroup.Text = "&ETF/Stock";
            //
            // MnETFStocksTrans
            //
            this.MnETFStocksTrans.Name = "MnETFStocksTrans";
            this.MnETFStocksTrans.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksTrans.Text = "ETF/Stock &Transaction";
            this.MnETFStocksTrans.Click += new System.EventHandler(this.MnETFStocksTrans_Click);
            //
            // MnETFStocksDistribution
            //
            this.MnETFStocksDistribution.Name = "MnETFStocksDistribution";
            this.MnETFStocksDistribution.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksDistribution.Text = "ETF/Stock &Distribution/Dividend";
            this.MnETFStocksDistribution.Click += new System.EventHandler(this.MnETFStocksDistribution_Click);
            //
            // MnETFStocksPrice
            //
            this.MnETFStocksPrice.Name = "MnETFStocksPrice";
            this.MnETFStocksPrice.Size = new System.Drawing.Size(216, 22);
            this.MnETFStocksPrice.Text = "ETF/Stock &Price";
            this.MnETFStocksPrice.Click += new System.EventHandler(this.MnETFStocksPrice_Click);
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(140, 28);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(440, 41);
            this.Label21.TabIndex = 1;
            this.Label21.Text = "ETF/STOCK INVESTMENT";
            //
            // LblGridCaption
            //
            this.LblGridCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblGridCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGridCaption.ForeColor = System.Drawing.Color.Black;
            this.LblGridCaption.Location = new System.Drawing.Point(19, 78);
            this.LblGridCaption.Name = "LblGridCaption";
            this.LblGridCaption.Size = new System.Drawing.Size(450, 20);
            this.LblGridCaption.TabIndex = 2;
            this.LblGridCaption.Text = "Portfolios";
            //
            // gvPortfolio
            //
            this.gvPortfolio.AllowUserToAddRows = false;
            this.gvPortfolio.AllowUserToDeleteRows = false;
            this.gvPortfolio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPortfolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPortfolio.Location = new System.Drawing.Point(19, 100);
            this.gvPortfolio.MultiSelect = false;
            this.gvPortfolio.Name = "gvPortfolio";
            this.gvPortfolio.ReadOnly = true;
            this.gvPortfolio.RowHeadersVisible = false;
            this.gvPortfolio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPortfolio.Size = new System.Drawing.Size(660, 150);
            this.gvPortfolio.TabIndex = 3;
            this.gvPortfolio.SelectionChanged += new System.EventHandler(this.gvPortfolio_SelectionChanged);
            //
            // LblEntryCaption
            //
            this.LblEntryCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblEntryCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEntryCaption.ForeColor = System.Drawing.Color.Black;
            this.LblEntryCaption.Location = new System.Drawing.Point(19, 262);
            this.LblEntryCaption.Name = "LblEntryCaption";
            this.LblEntryCaption.Size = new System.Drawing.Size(450, 20);
            this.LblEntryCaption.TabIndex = 4;
            this.LblEntryCaption.Text = "Add investment";
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(19, 292);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(120, 22);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Investment Date";
            //
            // CmbDD
            //
            this.CmbDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDD.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDD.FormattingEnabled = true;
            this.CmbDD.Location = new System.Drawing.Point(145, 290);
            this.CmbDD.Name = "CmbDD";
            this.CmbDD.Size = new System.Drawing.Size(41, 22);
            this.CmbDD.TabIndex = 6;
            this.CmbDD.SelectedIndexChanged += new System.EventHandler(this.CmbDD_SelectedIndexChanged);
            //
            // CmbMM
            //
            this.CmbMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMM.FormattingEnabled = true;
            this.CmbMM.Location = new System.Drawing.Point(195, 290);
            this.CmbMM.Name = "CmbMM";
            this.CmbMM.Size = new System.Drawing.Size(41, 22);
            this.CmbMM.TabIndex = 7;
            this.CmbMM.SelectedIndexChanged += new System.EventHandler(this.CmbMM_SelectedIndexChanged);
            //
            // CmbYear
            //
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.FormattingEnabled = true;
            this.CmbYear.Location = new System.Drawing.Point(245, 290);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 8;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            //
            // CmdCal
            //
            this.CmdCal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCal.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCal.Location = new System.Drawing.Point(309, 290);
            this.CmdCal.Name = "CmdCal";
            this.CmdCal.Size = new System.Drawing.Size(25, 19);
            this.CmdCal.TabIndex = 9;
            this.CmdCal.Text = "...";
            this.CmdCal.UseVisualStyleBackColor = false;
            this.CmdCal.Click += new System.EventHandler(this.CmdCal_Click);
            //
            // LblDay
            //
            this.LblDay.BackColor = System.Drawing.Color.Transparent;
            this.LblDay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDay.Location = new System.Drawing.Point(345, 293);
            this.LblDay.Name = "LblDay";
            this.LblDay.Size = new System.Drawing.Size(110, 17);
            this.LblDay.TabIndex = 10;
            //
            // monthCalendar1
            //
            this.monthCalendar1.Location = new System.Drawing.Point(400, 300);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 11;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            //
            // Label3
            //
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(19, 322);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(120, 22);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Portfolio Code";
            //
            // CmbPortfolioCode
            //
            this.CmbPortfolioCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortfolioCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPortfolioCode.FormattingEnabled = true;
            this.CmbPortfolioCode.Location = new System.Drawing.Point(145, 320);
            this.CmbPortfolioCode.Name = "CmbPortfolioCode";
            this.CmbPortfolioCode.Size = new System.Drawing.Size(157, 22);
            this.CmbPortfolioCode.TabIndex = 13;
            this.CmbPortfolioCode.SelectedIndexChanged += new System.EventHandler(this.CmbPortfolioCode_SelectedIndexChanged);
            //
            // LblPortfolioDesc
            //
            this.LblPortfolioDesc.BackColor = System.Drawing.Color.Transparent;
            this.LblPortfolioDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPortfolioDesc.ForeColor = System.Drawing.Color.Black;
            this.LblPortfolioDesc.Location = new System.Drawing.Point(310, 323);
            this.LblPortfolioDesc.Name = "LblPortfolioDesc";
            this.LblPortfolioDesc.Size = new System.Drawing.Size(370, 20);
            this.LblPortfolioDesc.TabIndex = 31;
            //
            // Label4
            //
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(19, 352);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(120, 22);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "Investment Type";
            //
            // CmbInvType
            //
            this.CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvType.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbInvType.FormattingEnabled = true;
            this.CmbInvType.Location = new System.Drawing.Point(145, 350);
            this.CmbInvType.Name = "CmbInvType";
            this.CmbInvType.Size = new System.Drawing.Size(157, 22);
            this.CmbInvType.TabIndex = 15;
            //
            // Label5
            //
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(19, 382);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(120, 22);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Currency";
            //
            // CmbCurrency
            //
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(145, 380);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(157, 22);
            this.CmbCurrency.TabIndex = 17;
            //
            // Label6
            //
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(19, 412);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(120, 22);
            this.Label6.TabIndex = 18;
            this.Label6.Text = "Amount";
            //
            // txtAmount
            //
            this.txtAmount.BackColor = System.Drawing.SystemColors.Window;
            this.txtAmount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAmount.Location = new System.Drawing.Point(145, 412);
            this.txtAmount.MaxLength = 20;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(157, 20);
            this.txtAmount.TabIndex = 19;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            //
            // CmdAdd
            //
            this.CmdAdd.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAdd.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdAdd.Location = new System.Drawing.Point(145, 444);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(100, 27);
            this.CmdAdd.TabIndex = 20;
            this.CmdAdd.Text = "&Add";
            this.CmdAdd.UseVisualStyleBackColor = false;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            //
            // LblEditCaption
            //
            this.LblEditCaption.BackColor = System.Drawing.Color.Transparent;
            this.LblEditCaption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEditCaption.ForeColor = System.Drawing.Color.Black;
            this.LblEditCaption.Location = new System.Drawing.Point(19, 486);
            this.LblEditCaption.Name = "LblEditCaption";
            this.LblEditCaption.Size = new System.Drawing.Size(450, 20);
            this.LblEditCaption.TabIndex = 21;
            this.LblEditCaption.Text = "Edit portfolio";
            //
            // Label7
            //
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(19, 516);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(120, 22);
            this.Label7.TabIndex = 22;
            this.Label7.Text = "Currency";
            //
            // CmbEditCurrency
            //
            this.CmbEditCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEditCurrency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEditCurrency.FormattingEnabled = true;
            this.CmbEditCurrency.Location = new System.Drawing.Point(145, 514);
            this.CmbEditCurrency.Name = "CmbEditCurrency";
            this.CmbEditCurrency.Size = new System.Drawing.Size(157, 22);
            this.CmbEditCurrency.TabIndex = 23;
            //
            // Label8
            //
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(19, 546);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(120, 22);
            this.Label8.TabIndex = 24;
            this.Label8.Text = "Cash";
            //
            // txtEditCash
            //
            this.txtEditCash.BackColor = System.Drawing.SystemColors.Window;
            this.txtEditCash.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditCash.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEditCash.Location = new System.Drawing.Point(145, 546);
            this.txtEditCash.MaxLength = 20;
            this.txtEditCash.Name = "txtEditCash";
            this.txtEditCash.Size = new System.Drawing.Size(157, 20);
            this.txtEditCash.TabIndex = 25;
            this.txtEditCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEditCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Signed_KeyPress);
            //
            // Label9
            //
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(19, 576);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(120, 22);
            this.Label9.TabIndex = 26;
            this.Label9.Text = "Investment Amount";
            //
            // txtEditInvAmt
            //
            this.txtEditInvAmt.BackColor = System.Drawing.SystemColors.Window;
            this.txtEditInvAmt.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditInvAmt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEditInvAmt.Location = new System.Drawing.Point(145, 576);
            this.txtEditInvAmt.MaxLength = 20;
            this.txtEditInvAmt.Name = "txtEditInvAmt";
            this.txtEditInvAmt.Size = new System.Drawing.Size(157, 20);
            this.txtEditInvAmt.TabIndex = 27;
            this.txtEditInvAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEditInvAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Signed_KeyPress);
            //
            // CmdUpdate
            //
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdUpdate.Location = new System.Drawing.Point(145, 608);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(100, 27);
            this.CmdUpdate.TabIndex = 28;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            //
            // CmdCancelEdit
            //
            this.CmdCancelEdit.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCancelEdit.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancelEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCancelEdit.Location = new System.Drawing.Point(255, 608);
            this.CmdCancelEdit.Name = "CmdCancelEdit";
            this.CmdCancelEdit.Size = new System.Drawing.Size(85, 27);
            this.CmdCancelEdit.TabIndex = 29;
            this.CmdCancelEdit.Text = "Cancel";
            this.CmdCancelEdit.UseVisualStyleBackColor = false;
            this.CmdCancelEdit.Click += new System.EventHandler(this.CmdCancelEdit_Click);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(594, 650);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 30;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Investment
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(700, 690);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdCancelEdit);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.txtEditInvAmt);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtEditCash);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.CmbEditCurrency);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.LblEditCaption);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.CmbCurrency);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.CmbInvType);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.LblPortfolioDesc);
            this.Controls.Add(this.CmbPortfolioCode);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.LblDay);
            this.Controls.Add(this.CmdCal);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.CmbMM);
            this.Controls.Add(this.CmbDD);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.LblEntryCaption);
            this.Controls.Add(this.gvPortfolio);
            this.Controls.Add(this.LblGridCaption);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "ETF_Stocks_Investment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Investment";
            this.Load += new System.EventHandler(this.ETF_Stocks_Investment_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPortfolio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnDaily;
        public System.Windows.Forms.ToolStripMenuItem MnMonthlyClosing;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockProcessGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksTrans;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDistribution;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksPrice;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label LblGridCaption;
        private System.Windows.Forms.DataGridView gvPortfolio;
        public System.Windows.Forms.Label LblEntryCaption;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbDD;
        public System.Windows.Forms.ComboBox CmbMM;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Button CmdCal;
        public System.Windows.Forms.Label LblDay;
        public System.Windows.Forms.MonthCalendar monthCalendar1;
        public System.Windows.Forms.Label Label3;
        public System.Windows.Forms.ComboBox CmbPortfolioCode;
        public System.Windows.Forms.Label LblPortfolioDesc;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox CmbInvType;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.ComboBox CmbCurrency;
        public System.Windows.Forms.Label Label6;
        public System.Windows.Forms.TextBox txtAmount;
        public System.Windows.Forms.Button CmdAdd;
        public System.Windows.Forms.Label LblEditCaption;
        public System.Windows.Forms.Label Label7;
        public System.Windows.Forms.ComboBox CmbEditCurrency;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.TextBox txtEditCash;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.TextBox txtEditInvAmt;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdCancelEdit;
        public System.Windows.Forms.Button CmdBack;
    }
}
