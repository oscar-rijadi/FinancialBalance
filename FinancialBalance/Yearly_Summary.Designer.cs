namespace FinancialBalance
{
    partial class Yearly_Summary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yearly_Summary));
            this.CmdBack = new System.Windows.Forms.Button();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.gvIncome = new System.Windows.Forms.DataGridView();
            this.gvExpense = new System.Windows.Forms.DataGridView();
            this.Label12 = new System.Windows.Forms.Label();
            this.lblTotIncomeAUD = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.lblTotExpenseAUD = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.lblUSD = new System.Windows.Forms.Label();
            this.lblAUD = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.lblTotNetIncomeAUD = new System.Windows.Forms.Label();
            this.gvActiva = new System.Windows.Forms.DataGridView();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblTotAssetDifferencesAUD = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotOpenAssetAUD = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotCloseAssetAUD = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gvPassiva = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotOpenLiabilityAUD = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotCloseLiabilityAUD = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotLiabilityDifferencesAUD = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblGrandTotalDifferencesAUD = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvActiva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPassiva)).BeginInit();
            this.SuspendLayout();
            // 
            // CmdBack
            // 
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(496, 846);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 25);
            this.CmdBack.TabIndex = 9;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(424, 0);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(317, 41);
            this.Label21.TabIndex = 10;
            this.Label21.Text = "YEARLY SUMMARY";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(503, 37);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(44, 17);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Year";
            // 
            // CmbYear
            // 
            this.CmbYear.BackColor = System.Drawing.SystemColors.Window;
            this.CmbYear.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbYear.Location = new System.Drawing.Point(552, 37);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbYear.Size = new System.Drawing.Size(57, 22);
            this.CmbYear.TabIndex = 12;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            // 
            // Label11
            // 
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(16, 65);
            this.Label11.Name = "Label11";
            this.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label11.Size = new System.Drawing.Size(57, 17);
            this.Label11.TabIndex = 18;
            this.Label11.Text = "Income";
            // 
            // Label14
            // 
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(544, 65);
            this.Label14.Name = "Label14";
            this.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label14.Size = new System.Drawing.Size(73, 17);
            this.Label14.TabIndex = 22;
            this.Label14.Text = "Expense";
            // 
            // gvIncome
            // 
            this.gvIncome.AllowUserToAddRows = false;
            this.gvIncome.AllowUserToDeleteRows = false;
            this.gvIncome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvIncome.Location = new System.Drawing.Point(19, 85);
            this.gvIncome.MultiSelect = false;
            this.gvIncome.Name = "gvIncome";
            this.gvIncome.ReadOnly = true;
            this.gvIncome.Size = new System.Drawing.Size(510, 183);
            this.gvIncome.TabIndex = 35;
            // 
            // gvExpense
            // 
            this.gvExpense.AllowUserToAddRows = false;
            this.gvExpense.AllowUserToDeleteRows = false;
            this.gvExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExpense.Location = new System.Drawing.Point(547, 85);
            this.gvExpense.MultiSelect = false;
            this.gvExpense.Name = "gvExpense";
            this.gvExpense.ReadOnly = true;
            this.gvExpense.Size = new System.Drawing.Size(510, 183);
            this.gvExpense.TabIndex = 41;
            // 
            // Label12
            // 
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(16, 275);
            this.Label12.Name = "Label12";
            this.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label12.Size = new System.Drawing.Size(129, 17);
            this.Label12.TabIndex = 42;
            this.Label12.Text = "Total Income (AUD)";
            // 
            // lblTotIncomeAUD
            // 
            this.lblTotIncomeAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotIncomeAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotIncomeAUD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotIncomeAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotIncomeAUD.Location = new System.Drawing.Point(323, 275);
            this.lblTotIncomeAUD.Name = "lblTotIncomeAUD";
            this.lblTotIncomeAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotIncomeAUD.Size = new System.Drawing.Size(209, 17);
            this.lblTotIncomeAUD.TabIndex = 43;
            this.lblTotIncomeAUD.Text = "999,999,999,999,999.99";
            this.lblTotIncomeAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label15
            // 
            this.Label15.BackColor = System.Drawing.Color.Transparent;
            this.Label15.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(544, 275);
            this.Label15.Name = "Label15";
            this.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label15.Size = new System.Drawing.Size(145, 17);
            this.Label15.TabIndex = 44;
            this.Label15.Text = "Total Expense (AUD)";
            // 
            // lblTotExpenseAUD
            // 
            this.lblTotExpenseAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotExpenseAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotExpenseAUD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotExpenseAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotExpenseAUD.Location = new System.Drawing.Point(849, 275);
            this.lblTotExpenseAUD.Name = "lblTotExpenseAUD";
            this.lblTotExpenseAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotExpenseAUD.Size = new System.Drawing.Size(209, 17);
            this.lblTotExpenseAUD.TabIndex = 45;
            this.lblTotExpenseAUD.Text = "999,999,999,999,999.99";
            this.lblTotExpenseAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(8, 833);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(41, 17);
            this.Label5.TabIndex = 46;
            this.Label5.Text = "USD";
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(8, 854);
            this.Label8.Name = "Label8";
            this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label8.Size = new System.Drawing.Size(41, 17);
            this.Label8.TabIndex = 47;
            this.Label8.Text = "AUD";
            // 
            // lblUSD
            // 
            this.lblUSD.BackColor = System.Drawing.Color.Transparent;
            this.lblUSD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblUSD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSD.ForeColor = System.Drawing.Color.Black;
            this.lblUSD.Location = new System.Drawing.Point(56, 833);
            this.lblUSD.Name = "lblUSD";
            this.lblUSD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUSD.Size = new System.Drawing.Size(113, 17);
            this.lblUSD.TabIndex = 48;
            this.lblUSD.Text = "999,999,999.99";
            this.lblUSD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAUD
            // 
            this.lblAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAUD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAUD.ForeColor = System.Drawing.Color.Black;
            this.lblAUD.Location = new System.Drawing.Point(56, 854);
            this.lblAUD.Name = "lblAUD";
            this.lblAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblAUD.Size = new System.Drawing.Size(113, 17);
            this.lblAUD.TabIndex = 49;
            this.lblAUD.Text = "999,999,999.99";
            this.lblAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label17
            // 
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.Location = new System.Drawing.Point(264, 300);
            this.Label17.Name = "Label17";
            this.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label17.Size = new System.Drawing.Size(153, 17);
            this.Label17.TabIndex = 50;
            this.Label17.Text = "Net Income (AUD)";
            // 
            // lblTotNetIncomeAUD
            // 
            this.lblTotNetIncomeAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotNetIncomeAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotNetIncomeAUD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotNetIncomeAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotNetIncomeAUD.Location = new System.Drawing.Point(480, 300);
            this.lblTotNetIncomeAUD.Name = "lblTotNetIncomeAUD";
            this.lblTotNetIncomeAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotNetIncomeAUD.Size = new System.Drawing.Size(297, 17);
            this.lblTotNetIncomeAUD.TabIndex = 51;
            this.lblTotNetIncomeAUD.Text = "999,999,999,999,999.99";
            this.lblTotNetIncomeAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gvActiva
            // 
            this.gvActiva.AllowUserToAddRows = false;
            this.gvActiva.AllowUserToDeleteRows = false;
            this.gvActiva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvActiva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvActiva.Location = new System.Drawing.Point(18, 345);
            this.gvActiva.MultiSelect = false;
            this.gvActiva.Name = "gvActiva";
            this.gvActiva.ReadOnly = true;
            this.gvActiva.Size = new System.Drawing.Size(1040, 183);
            this.gvActiva.TabIndex = 52;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(16, 323);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(57, 17);
            this.Label2.TabIndex = 53;
            this.Label2.Text = "Asset";
            // 
            // lblTotAssetDifferencesAUD
            // 
            this.lblTotAssetDifferencesAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotAssetDifferencesAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotAssetDifferencesAUD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAssetDifferencesAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotAssetDifferencesAUD.Location = new System.Drawing.Point(480, 558);
            this.lblTotAssetDifferencesAUD.Name = "lblTotAssetDifferencesAUD";
            this.lblTotAssetDifferencesAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotAssetDifferencesAUD.Size = new System.Drawing.Size(297, 17);
            this.lblTotAssetDifferencesAUD.TabIndex = 55;
            this.lblTotAssetDifferencesAUD.Text = "999,999,999,999,999.99";
            this.lblTotAssetDifferencesAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 535);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(170, 17);
            this.label4.TabIndex = 56;
            this.label4.Text = "Total Open Asset (AUD)";
            // 
            // lblTotOpenAssetAUD
            // 
            this.lblTotOpenAssetAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotOpenAssetAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotOpenAssetAUD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotOpenAssetAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotOpenAssetAUD.Location = new System.Drawing.Point(320, 535);
            this.lblTotOpenAssetAUD.Name = "lblTotOpenAssetAUD";
            this.lblTotOpenAssetAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotOpenAssetAUD.Size = new System.Drawing.Size(209, 17);
            this.lblTotOpenAssetAUD.TabIndex = 57;
            this.lblTotOpenAssetAUD.Text = "999,999,999,999,999.99";
            this.lblTotOpenAssetAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(544, 535);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(174, 17);
            this.label7.TabIndex = 58;
            this.label7.Text = "Total Closing Asset (AUD)";
            // 
            // lblTotCloseAssetAUD
            // 
            this.lblTotCloseAssetAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotCloseAssetAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotCloseAssetAUD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotCloseAssetAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotCloseAssetAUD.Location = new System.Drawing.Point(848, 535);
            this.lblTotCloseAssetAUD.Name = "lblTotCloseAssetAUD";
            this.lblTotCloseAssetAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotCloseAssetAUD.Size = new System.Drawing.Size(209, 17);
            this.lblTotCloseAssetAUD.TabIndex = 59;
            this.lblTotCloseAssetAUD.Text = "999,999,999,999,999.99";
            this.lblTotCloseAssetAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 577);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 60;
            this.label6.Text = "Liability";
            // 
            // gvPassiva
            // 
            this.gvPassiva.AllowUserToAddRows = false;
            this.gvPassiva.AllowUserToDeleteRows = false;
            this.gvPassiva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPassiva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPassiva.Location = new System.Drawing.Point(19, 597);
            this.gvPassiva.MultiSelect = false;
            this.gvPassiva.Name = "gvPassiva";
            this.gvPassiva.ReadOnly = true;
            this.gvPassiva.Size = new System.Drawing.Size(1040, 163);
            this.gvPassiva.TabIndex = 61;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(16, 767);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(187, 17);
            this.label9.TabIndex = 62;
            this.label9.Text = "Total Open Liability (AUD)";
            // 
            // lblTotOpenLiabilityAUD
            // 
            this.lblTotOpenLiabilityAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotOpenLiabilityAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotOpenLiabilityAUD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotOpenLiabilityAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotOpenLiabilityAUD.Location = new System.Drawing.Point(320, 767);
            this.lblTotOpenLiabilityAUD.Name = "lblTotOpenLiabilityAUD";
            this.lblTotOpenLiabilityAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotOpenLiabilityAUD.Size = new System.Drawing.Size(209, 17);
            this.lblTotOpenLiabilityAUD.TabIndex = 63;
            this.lblTotOpenLiabilityAUD.Text = "999,999,999,999,999.99";
            this.lblTotOpenLiabilityAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Cursor = System.Windows.Forms.Cursors.Default;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(544, 767);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(197, 17);
            this.label13.TabIndex = 64;
            this.label13.Text = "Total Closing Liability (AUD)";
            // 
            // lblTotCloseLiabilityAUD
            // 
            this.lblTotCloseLiabilityAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotCloseLiabilityAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotCloseLiabilityAUD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotCloseLiabilityAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotCloseLiabilityAUD.Location = new System.Drawing.Point(848, 767);
            this.lblTotCloseLiabilityAUD.Name = "lblTotCloseLiabilityAUD";
            this.lblTotCloseLiabilityAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotCloseLiabilityAUD.Size = new System.Drawing.Size(209, 17);
            this.lblTotCloseLiabilityAUD.TabIndex = 65;
            this.lblTotCloseLiabilityAUD.Text = "999,999,999,999,999.99";
            this.lblTotCloseLiabilityAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(200, 789);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(252, 17);
            this.label10.TabIndex = 66;
            this.label10.Text = "Total Liability Differences (AUD)";
            // 
            // lblTotLiabilityDifferencesAUD
            // 
            this.lblTotLiabilityDifferencesAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblTotLiabilityDifferencesAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotLiabilityDifferencesAUD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotLiabilityDifferencesAUD.ForeColor = System.Drawing.Color.Black;
            this.lblTotLiabilityDifferencesAUD.Location = new System.Drawing.Point(480, 789);
            this.lblTotLiabilityDifferencesAUD.Name = "lblTotLiabilityDifferencesAUD";
            this.lblTotLiabilityDifferencesAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotLiabilityDifferencesAUD.Size = new System.Drawing.Size(297, 17);
            this.lblTotLiabilityDifferencesAUD.TabIndex = 67;
            this.lblTotLiabilityDifferencesAUD.Text = "999,999,999,999,999.99";
            this.lblTotLiabilityDifferencesAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Cursor = System.Windows.Forms.Cursors.Default;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(200, 813);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label16.Size = new System.Drawing.Size(238, 17);
            this.label16.TabIndex = 68;
            this.label16.Text = "Grand Total Differences (AUD)";
            // 
            // lblGrandTotalDifferencesAUD
            // 
            this.lblGrandTotalDifferencesAUD.BackColor = System.Drawing.Color.Transparent;
            this.lblGrandTotalDifferencesAUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblGrandTotalDifferencesAUD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotalDifferencesAUD.ForeColor = System.Drawing.Color.Black;
            this.lblGrandTotalDifferencesAUD.Location = new System.Drawing.Point(480, 813);
            this.lblGrandTotalDifferencesAUD.Name = "lblGrandTotalDifferencesAUD";
            this.lblGrandTotalDifferencesAUD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGrandTotalDifferencesAUD.Size = new System.Drawing.Size(297, 17);
            this.lblGrandTotalDifferencesAUD.TabIndex = 69;
            this.lblGrandTotalDifferencesAUD.Text = "999,999,999,999,999.99";
            this.lblGrandTotalDifferencesAUD.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Cursor = System.Windows.Forms.Cursors.Default;
            this.label19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(209, 558);
            this.label19.Name = "label19";
            this.label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label19.Size = new System.Drawing.Size(243, 17);
            this.label19.TabIndex = 70;
            this.label19.Text = "Total Asset Differences (AUD)";
            // 
            // Yearly_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1078, 882);
            this.ControlBox = false;
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblGrandTotalDifferencesAUD);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblTotLiabilityDifferencesAUD);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotCloseLiabilityAUD);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblTotOpenLiabilityAUD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gvPassiva);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotCloseAssetAUD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotOpenAssetAUD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotAssetDifferencesAUD);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.gvActiva);
            this.Controls.Add(this.lblTotNetIncomeAUD);
            this.Controls.Add(this.Label17);
            this.Controls.Add(this.lblAUD);
            this.Controls.Add(this.lblUSD);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.lblTotExpenseAUD);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.lblTotIncomeAUD);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.gvExpense);
            this.Controls.Add(this.gvIncome);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.CmdBack);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "Yearly_Summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yearly Summary";
            this.Load += new System.EventHandler(this.Yearly_Summary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvActiva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPassiva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.Label Label11;
        public System.Windows.Forms.Label Label14;
        private System.Windows.Forms.DataGridView gvIncome;
        private System.Windows.Forms.DataGridView gvExpense;
        public System.Windows.Forms.Label Label12;
        public System.Windows.Forms.Label lblTotIncomeAUD;
        public System.Windows.Forms.Label Label15;
        public System.Windows.Forms.Label lblTotExpenseAUD;
        public System.Windows.Forms.Label Label5;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.Label lblUSD;
        public System.Windows.Forms.Label lblAUD;
        public System.Windows.Forms.Label Label17;
        public System.Windows.Forms.Label lblTotNetIncomeAUD;
        private System.Windows.Forms.DataGridView gvActiva;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label lblTotAssetDifferencesAUD;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblTotOpenAssetAUD;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblTotCloseAssetAUD;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gvPassiva;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lblTotOpenLiabilityAUD;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label lblTotCloseLiabilityAUD;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblTotLiabilityDifferencesAUD;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label lblGrandTotalDifferencesAUD;
        public System.Windows.Forms.Label label19;
    }
}