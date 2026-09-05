namespace FinancialBalance
{
    partial class ETF_Stocks_FY_Historical
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_FY_Historical));
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbFinYear = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbPortfolio = new System.Windows.Forms.ComboBox();
            this.chkMainOnly = new System.Windows.Forms.CheckBox();
            this.LblNote = new System.Windows.Forms.Label();
            this.gvHist = new System.Windows.Forms.DataGridView();
            this.LblAgg1Cap = new System.Windows.Forms.Label();
            this.LblAgg1 = new System.Windows.Forms.Label();
            this.LblAgg2Cap = new System.Windows.Forms.Label();
            this.LblAgg2 = new System.Windows.Forms.Label();
            this.LblAgg3Cap = new System.Windows.Forms.Label();
            this.LblAgg3 = new System.Windows.Forms.Label();
            this.LblAgg4Cap = new System.Windows.Forms.Label();
            this.LblAgg4 = new System.Windows.Forms.Label();
            this.LblAgg5Cap = new System.Windows.Forms.Label();
            this.LblAgg5 = new System.Windows.Forms.Label();
            this.LblAgg6Cap = new System.Windows.Forms.Label();
            this.LblAgg6 = new System.Windows.Forms.Label();
            this.LblAgg7Cap = new System.Windows.Forms.Label();
            this.LblAgg7 = new System.Windows.Forms.Label();
            this.LblAgg8Cap = new System.Windows.Forms.Label();
            this.LblAgg8 = new System.Windows.Forms.Label();
            this.LblAgg9Cap = new System.Windows.Forms.Label();
            this.LblAgg9 = new System.Windows.Forms.Label();
            this.LblAgg10Cap = new System.Windows.Forms.Label();
            this.LblAgg10 = new System.Windows.Forms.Label();
            this.LblAgg11Cap = new System.Windows.Forms.Label();
            this.LblAgg11 = new System.Windows.Forms.Label();
            this.LblAgg12Cap = new System.Windows.Forms.Label();
            this.LblAgg12 = new System.Windows.Forms.Label();
            this.CmdExcel = new System.Windows.Forms.Button();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvHist)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(180, 30);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(980, 38);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK FINANCIAL YEAR HISTORICAL";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 20);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Financial Year";
            //
            // CmbFinYear
            //
            this.CmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinYear.FormattingEnabled = true;
            this.CmbFinYear.Location = new System.Drawing.Point(125, 80);
            this.CmbFinYear.Name = "CmbFinYear";
            this.CmbFinYear.Size = new System.Drawing.Size(200, 22);
            this.CmbFinYear.TabIndex = 2;
            this.CmbFinYear.SelectedIndexChanged += new System.EventHandler(this.CmbFinYear_SelectedIndexChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(345, 82);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 20);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Portfolio";
            //
            // CmbPortfolio
            //
            this.CmbPortfolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPortfolio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPortfolio.FormattingEnabled = true;
            this.CmbPortfolio.Location = new System.Drawing.Point(435, 80);
            this.CmbPortfolio.Name = "CmbPortfolio";
            this.CmbPortfolio.Size = new System.Drawing.Size(260, 22);
            this.CmbPortfolio.TabIndex = 4;
            this.CmbPortfolio.SelectedIndexChanged += new System.EventHandler(this.CmbPortfolio_SelectedIndexChanged);
            //
            // chkMainOnly
            //
            this.chkMainOnly.AutoSize = false;
            this.chkMainOnly.BackColor = System.Drawing.Color.Transparent;
            this.chkMainOnly.Checked = true;
            this.chkMainOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMainOnly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMainOnly.Location = new System.Drawing.Point(715, 80);
            this.chkMainOnly.Name = "chkMainOnly";
            this.chkMainOnly.Size = new System.Drawing.Size(100, 24);
            this.chkMainOnly.TabIndex = 5;
            this.chkMainOnly.Text = "Main Only";
            this.chkMainOnly.UseVisualStyleBackColor = false;
            this.chkMainOnly.CheckedChanged += new System.EventHandler(this.chkMainOnly_CheckedChanged);
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 110);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(1300, 20);
            this.LblNote.TabIndex = 6;
            //
            // gvHist
            //
            this.gvHist.AllowUserToAddRows = false;
            this.gvHist.AllowUserToDeleteRows = false;
            this.gvHist.AllowUserToResizeRows = false;
            this.gvHist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvHist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvHist.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvHist.Location = new System.Drawing.Point(19, 136);
            this.gvHist.MultiSelect = false;
            this.gvHist.Name = "gvHist";
            this.gvHist.ReadOnly = true;
            this.gvHist.RowHeadersVisible = false;
            this.gvHist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvHist.Size = new System.Drawing.Size(1300, 240);
            this.gvHist.TabIndex = 7;
            //
            // LblAgg1Cap
            //
            this.LblAgg1Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg1Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg1Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg1Cap.Location = new System.Drawing.Point(19, 390);
            this.LblAgg1Cap.Name = "LblAgg1Cap";
            this.LblAgg1Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg1Cap.TabIndex = 8;
            //
            // LblAgg1
            //
            this.LblAgg1.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg1.ForeColor = System.Drawing.Color.Black;
            this.LblAgg1.Location = new System.Drawing.Point(335, 390);
            this.LblAgg1.Name = "LblAgg1";
            this.LblAgg1.Size = new System.Drawing.Size(170, 20);
            this.LblAgg1.TabIndex = 9;
            this.LblAgg1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg2Cap
            //
            this.LblAgg2Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg2Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg2Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg2Cap.Location = new System.Drawing.Point(19, 414);
            this.LblAgg2Cap.Name = "LblAgg2Cap";
            this.LblAgg2Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg2Cap.TabIndex = 10;
            //
            // LblAgg2
            //
            this.LblAgg2.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg2.ForeColor = System.Drawing.Color.Black;
            this.LblAgg2.Location = new System.Drawing.Point(335, 414);
            this.LblAgg2.Name = "LblAgg2";
            this.LblAgg2.Size = new System.Drawing.Size(170, 20);
            this.LblAgg2.TabIndex = 11;
            this.LblAgg2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg3Cap
            //
            this.LblAgg3Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg3Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg3Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg3Cap.Location = new System.Drawing.Point(19, 438);
            this.LblAgg3Cap.Name = "LblAgg3Cap";
            this.LblAgg3Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg3Cap.TabIndex = 12;
            //
            // LblAgg3
            //
            this.LblAgg3.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg3.ForeColor = System.Drawing.Color.Black;
            this.LblAgg3.Location = new System.Drawing.Point(335, 438);
            this.LblAgg3.Name = "LblAgg3";
            this.LblAgg3.Size = new System.Drawing.Size(170, 20);
            this.LblAgg3.TabIndex = 13;
            this.LblAgg3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg4Cap
            //
            this.LblAgg4Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg4Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg4Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg4Cap.Location = new System.Drawing.Point(19, 462);
            this.LblAgg4Cap.Name = "LblAgg4Cap";
            this.LblAgg4Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg4Cap.TabIndex = 14;
            //
            // LblAgg4
            //
            this.LblAgg4.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg4.ForeColor = System.Drawing.Color.Black;
            this.LblAgg4.Location = new System.Drawing.Point(335, 462);
            this.LblAgg4.Name = "LblAgg4";
            this.LblAgg4.Size = new System.Drawing.Size(170, 20);
            this.LblAgg4.TabIndex = 15;
            this.LblAgg4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg5Cap
            //
            this.LblAgg5Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg5Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg5Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg5Cap.Location = new System.Drawing.Point(19, 486);
            this.LblAgg5Cap.Name = "LblAgg5Cap";
            this.LblAgg5Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg5Cap.TabIndex = 16;
            //
            // LblAgg5
            //
            this.LblAgg5.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg5.ForeColor = System.Drawing.Color.Black;
            this.LblAgg5.Location = new System.Drawing.Point(335, 486);
            this.LblAgg5.Name = "LblAgg5";
            this.LblAgg5.Size = new System.Drawing.Size(170, 20);
            this.LblAgg5.TabIndex = 17;
            this.LblAgg5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg6Cap
            //
            this.LblAgg6Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg6Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg6Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg6Cap.Location = new System.Drawing.Point(19, 510);
            this.LblAgg6Cap.Name = "LblAgg6Cap";
            this.LblAgg6Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg6Cap.TabIndex = 18;
            //
            // LblAgg6
            //
            this.LblAgg6.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg6.ForeColor = System.Drawing.Color.Black;
            this.LblAgg6.Location = new System.Drawing.Point(335, 510);
            this.LblAgg6.Name = "LblAgg6";
            this.LblAgg6.Size = new System.Drawing.Size(170, 20);
            this.LblAgg6.TabIndex = 19;
            this.LblAgg6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg7Cap
            //
            this.LblAgg7Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg7Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg7Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg7Cap.Location = new System.Drawing.Point(545, 390);
            this.LblAgg7Cap.Name = "LblAgg7Cap";
            this.LblAgg7Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg7Cap.TabIndex = 20;
            //
            // LblAgg7
            //
            this.LblAgg7.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg7.ForeColor = System.Drawing.Color.Black;
            this.LblAgg7.Location = new System.Drawing.Point(861, 390);
            this.LblAgg7.Name = "LblAgg7";
            this.LblAgg7.Size = new System.Drawing.Size(170, 20);
            this.LblAgg7.TabIndex = 21;
            this.LblAgg7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg8Cap
            //
            this.LblAgg8Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg8Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg8Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg8Cap.Location = new System.Drawing.Point(545, 414);
            this.LblAgg8Cap.Name = "LblAgg8Cap";
            this.LblAgg8Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg8Cap.TabIndex = 22;
            //
            // LblAgg8
            //
            this.LblAgg8.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg8.ForeColor = System.Drawing.Color.Black;
            this.LblAgg8.Location = new System.Drawing.Point(861, 414);
            this.LblAgg8.Name = "LblAgg8";
            this.LblAgg8.Size = new System.Drawing.Size(170, 20);
            this.LblAgg8.TabIndex = 23;
            this.LblAgg8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg9Cap
            //
            this.LblAgg9Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg9Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg9Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg9Cap.Location = new System.Drawing.Point(545, 438);
            this.LblAgg9Cap.Name = "LblAgg9Cap";
            this.LblAgg9Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg9Cap.TabIndex = 24;
            //
            // LblAgg9
            //
            this.LblAgg9.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg9.ForeColor = System.Drawing.Color.Black;
            this.LblAgg9.Location = new System.Drawing.Point(861, 438);
            this.LblAgg9.Name = "LblAgg9";
            this.LblAgg9.Size = new System.Drawing.Size(170, 20);
            this.LblAgg9.TabIndex = 25;
            this.LblAgg9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg10Cap
            //
            this.LblAgg10Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg10Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg10Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg10Cap.Location = new System.Drawing.Point(545, 462);
            this.LblAgg10Cap.Name = "LblAgg10Cap";
            this.LblAgg10Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg10Cap.TabIndex = 26;
            //
            // LblAgg10
            //
            this.LblAgg10.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg10.ForeColor = System.Drawing.Color.Black;
            this.LblAgg10.Location = new System.Drawing.Point(861, 462);
            this.LblAgg10.Name = "LblAgg10";
            this.LblAgg10.Size = new System.Drawing.Size(170, 20);
            this.LblAgg10.TabIndex = 27;
            this.LblAgg10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg11Cap
            //
            this.LblAgg11Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg11Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg11Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg11Cap.Location = new System.Drawing.Point(545, 486);
            this.LblAgg11Cap.Name = "LblAgg11Cap";
            this.LblAgg11Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg11Cap.TabIndex = 28;
            //
            // LblAgg11
            //
            this.LblAgg11.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg11.ForeColor = System.Drawing.Color.Black;
            this.LblAgg11.Location = new System.Drawing.Point(861, 486);
            this.LblAgg11.Name = "LblAgg11";
            this.LblAgg11.Size = new System.Drawing.Size(170, 20);
            this.LblAgg11.TabIndex = 29;
            this.LblAgg11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // LblAgg12Cap
            //
            this.LblAgg12Cap.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg12Cap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg12Cap.ForeColor = System.Drawing.Color.Black;
            this.LblAgg12Cap.Location = new System.Drawing.Point(545, 510);
            this.LblAgg12Cap.Name = "LblAgg12Cap";
            this.LblAgg12Cap.Size = new System.Drawing.Size(310, 20);
            this.LblAgg12Cap.TabIndex = 30;
            //
            // LblAgg12
            //
            this.LblAgg12.BackColor = System.Drawing.Color.Transparent;
            this.LblAgg12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgg12.ForeColor = System.Drawing.Color.Black;
            this.LblAgg12.Location = new System.Drawing.Point(861, 510);
            this.LblAgg12.Name = "LblAgg12";
            this.LblAgg12.Size = new System.Drawing.Size(170, 20);
            this.LblAgg12.TabIndex = 31;
            this.LblAgg12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmdExcel
            //
            this.CmdExcel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdExcel.Location = new System.Drawing.Point(1090, 552);
            this.CmdExcel.Name = "CmdExcel";
            this.CmdExcel.Size = new System.Drawing.Size(110, 30);
            this.CmdExcel.TabIndex = 40;
            this.CmdExcel.Text = "Generate Excel";
            this.CmdExcel.UseVisualStyleBackColor = true;
            this.CmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            //
            // CmdBack
            //
            this.CmdBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.Location = new System.Drawing.Point(1210, 552);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(110, 30);
            this.CmdBack.TabIndex = 41;
            this.CmdBack.Text = "Back";
            this.CmdBack.UseVisualStyleBackColor = true;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_FY_Historical
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1340, 620);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.CmdExcel);
            this.Controls.Add(this.LblAgg12);
            this.Controls.Add(this.LblAgg12Cap);
            this.Controls.Add(this.LblAgg11);
            this.Controls.Add(this.LblAgg11Cap);
            this.Controls.Add(this.LblAgg10);
            this.Controls.Add(this.LblAgg10Cap);
            this.Controls.Add(this.LblAgg9);
            this.Controls.Add(this.LblAgg9Cap);
            this.Controls.Add(this.LblAgg8);
            this.Controls.Add(this.LblAgg8Cap);
            this.Controls.Add(this.LblAgg7);
            this.Controls.Add(this.LblAgg7Cap);
            this.Controls.Add(this.LblAgg6);
            this.Controls.Add(this.LblAgg6Cap);
            this.Controls.Add(this.LblAgg5);
            this.Controls.Add(this.LblAgg5Cap);
            this.Controls.Add(this.LblAgg4);
            this.Controls.Add(this.LblAgg4Cap);
            this.Controls.Add(this.LblAgg3);
            this.Controls.Add(this.LblAgg3Cap);
            this.Controls.Add(this.LblAgg2);
            this.Controls.Add(this.LblAgg2Cap);
            this.Controls.Add(this.LblAgg1);
            this.Controls.Add(this.LblAgg1Cap);
            this.Controls.Add(this.gvHist);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.chkMainOnly);
            this.Controls.Add(this.CmbPortfolio);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CmbFinYear);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_FY_Historical";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Financial Year Historical";
            this.Load += new System.EventHandler(this.ETF_Stocks_FY_Historical_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvHist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbFinYear;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbPortfolio;
        public System.Windows.Forms.CheckBox chkMainOnly;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.DataGridView gvHist;
        public System.Windows.Forms.Label LblAgg1Cap;
        public System.Windows.Forms.Label LblAgg1;
        public System.Windows.Forms.Label LblAgg2Cap;
        public System.Windows.Forms.Label LblAgg2;
        public System.Windows.Forms.Label LblAgg3Cap;
        public System.Windows.Forms.Label LblAgg3;
        public System.Windows.Forms.Label LblAgg4Cap;
        public System.Windows.Forms.Label LblAgg4;
        public System.Windows.Forms.Label LblAgg5Cap;
        public System.Windows.Forms.Label LblAgg5;
        public System.Windows.Forms.Label LblAgg6Cap;
        public System.Windows.Forms.Label LblAgg6;
        public System.Windows.Forms.Label LblAgg7Cap;
        public System.Windows.Forms.Label LblAgg7;
        public System.Windows.Forms.Label LblAgg8Cap;
        public System.Windows.Forms.Label LblAgg8;
        public System.Windows.Forms.Label LblAgg9Cap;
        public System.Windows.Forms.Label LblAgg9;
        public System.Windows.Forms.Label LblAgg10Cap;
        public System.Windows.Forms.Label LblAgg10;
        public System.Windows.Forms.Label LblAgg11Cap;
        public System.Windows.Forms.Label LblAgg11;
        public System.Windows.Forms.Label LblAgg12Cap;
        public System.Windows.Forms.Label LblAgg12;
        public System.Windows.Forms.Button CmdExcel;
        public System.Windows.Forms.Button CmdBack;
    }
}
