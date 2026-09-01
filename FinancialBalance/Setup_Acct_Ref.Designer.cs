namespace FinancialBalance
{
    partial class Setup_Acct_Ref
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup_Acct_Ref));
            this.CmdBack = new System.Windows.Forms.Button();
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.MnAcctTypeRefSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrencyGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnCurrRateSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnActivaPassivaSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStockGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSuffixSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksFlagSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivTypeSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.MnETFStocksDivAllocSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.CmdDel = new System.Windows.Forms.Button();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmbCurr = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.CmbAcctType = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtAcctName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbAcctCode = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.gvAcctRef = new System.Windows.Forms.DataGridView();
            this.Label21 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAcctOrder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbCurrentAsset = new System.Windows.Forms.ComboBox();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcctRef)).BeginInit();
            this.SuspendLayout();
            // 
            // CmdBack
            // 
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(374, 708);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(73, 25);
            this.CmdBack.TabIndex = 9;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            // 
            // MainMenu1
            // 
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnAcctTypeRefSetup,
            this.MnCurrencyGroup,
            this.MnActivaPassivaSetup,
            this.MnETFStockGroup});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(576, 24);
            this.MainMenu1.TabIndex = 14;
            // 
            // MnAcctTypeRefSetup
            // 
            this.MnAcctTypeRefSetup.Name = "MnAcctTypeRefSetup";
            this.MnAcctTypeRefSetup.Size = new System.Drawing.Size(163, 20);
            this.MnAcctTypeRefSetup.Text = "Accounting &Type Ref Setup";
            this.MnAcctTypeRefSetup.Click += new System.EventHandler(this.MnAcctTypeRefSetup_Click);
            // 
            // MnCurrencyGroup
            // 
            this.MnCurrencyGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnCurrSetup,
            this.MnCurrRateSetup});
            this.MnCurrencyGroup.Name = "MnCurrencyGroup";
            this.MnCurrencyGroup.Size = new System.Drawing.Size(75, 20);
            this.MnCurrencyGroup.Text = "&Currency";
            // 
            // MnCurrSetup
            // 
            this.MnCurrSetup.Name = "MnCurrSetup";
            this.MnCurrSetup.Size = new System.Drawing.Size(100, 20);
            this.MnCurrSetup.Text = "&Currency Setup";
            this.MnCurrSetup.Click += new System.EventHandler(this.MnCurrSetup_Click);
            // 
            // MnCurrRateSetup
            // 
            this.MnCurrRateSetup.Name = "MnCurrRateSetup";
            this.MnCurrRateSetup.Size = new System.Drawing.Size(126, 20);
            this.MnCurrRateSetup.Text = "Currency &Rate Setup";
            this.MnCurrRateSetup.Click += new System.EventHandler(this.MnCurrRateSetup_Click);
            // 
            // MnActivaPassivaSetup
            // 
            this.MnActivaPassivaSetup.Name = "MnActivaPassivaSetup";
            this.MnActivaPassivaSetup.Size = new System.Drawing.Size(126, 20);
            this.MnActivaPassivaSetup.Text = "Asset &Liability Setup";
            this.MnActivaPassivaSetup.Click += new System.EventHandler(this.MnActivaPassivaSetup_Click);
            // 
            // MnETFStockGroup
            // 
            this.MnETFStockGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnETFStocksSuffixSetup,
            this.MnETFStocksSetup,
            this.MnETFStocksFlagSetup,
            this.MnETFStocksDivTypeSetup,
            this.MnETFStocksDivSetup,
            this.MnETFStocksDivAllocSetup});
            this.MnETFStockGroup.Name = "MnETFStockGroup";
            this.MnETFStockGroup.Size = new System.Drawing.Size(75, 20);
            this.MnETFStockGroup.Text = "&ETF/Stock";
            // 
            // MnETFStocksSuffixSetup
            // 
            this.MnETFStocksSuffixSetup.Name = "MnETFStocksSuffixSetup";
            this.MnETFStocksSuffixSetup.Size = new System.Drawing.Size(140, 20);
            this.MnETFStocksSuffixSetup.Text = "&ETF/Stock Suffix Setup";
            this.MnETFStocksSuffixSetup.Click += new System.EventHandler(this.MnETFStocksSuffixSetup_Click);
            // 
            // MnETFStocksSetup
            // 
            this.MnETFStocksSetup.Name = "MnETFStocksSetup";
            this.MnETFStocksSetup.Size = new System.Drawing.Size(115, 20);
            this.MnETFStocksSetup.Text = "ETF/&Stock Setup";
            this.MnETFStocksSetup.Click += new System.EventHandler(this.MnETFStocksSetup_Click);
            // 
            // MnETFStocksFlagSetup
            // 
            this.MnETFStocksFlagSetup.Name = "MnETFStocksFlagSetup";
            this.MnETFStocksFlagSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksFlagSetup.Text = "ETF/Stock &Portfolio Code Setup";
            this.MnETFStocksFlagSetup.Click += new System.EventHandler(this.MnETFStocksFlagSetup_Click);
            // 
            // MnETFStocksDivTypeSetup
            // 
            this.MnETFStocksDivTypeSetup.Name = "MnETFStocksDivTypeSetup";
            this.MnETFStocksDivTypeSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksDivTypeSetup.Text = "ETF/Stock &Diversification Type Setup";
            this.MnETFStocksDivTypeSetup.Click += new System.EventHandler(this.MnETFStocksDivTypeSetup_Click);
            // 
            // MnETFStocksDivSetup
            // 
            this.MnETFStocksDivSetup.Name = "MnETFStocksDivSetup";
            this.MnETFStocksDivSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksDivSetup.Text = "ETF/Stock Di&versification Setup";
            this.MnETFStocksDivSetup.Click += new System.EventHandler(this.MnETFStocksDivSetup_Click);
            // 
            // MnETFStocksDivAllocSetup
            // 
            this.MnETFStocksDivAllocSetup.Name = "MnETFStocksDivAllocSetup";
            this.MnETFStocksDivAllocSetup.Size = new System.Drawing.Size(130, 20);
            this.MnETFStocksDivAllocSetup.Text = "ETF/Stock Diversification &Allocation";
            this.MnETFStocksDivAllocSetup.Click += new System.EventHandler(this.MnETFStocksDivAllocSetup_Click);
            // 
            // CmdDel
            // 
            this.CmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.CmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdDel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdDel.Location = new System.Drawing.Point(280, 708);
            this.CmdDel.Name = "CmdDel";
            this.CmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdDel.Size = new System.Drawing.Size(73, 25);
            this.CmdDel.TabIndex = 15;
            this.CmdDel.Text = "&Delete";
            this.CmdDel.UseVisualStyleBackColor = false;
            this.CmdDel.Click += new System.EventHandler(this.CmdDel_Click);
            // 
            // CmdUpdate
            // 
            this.CmdUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdUpdate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdUpdate.Location = new System.Drawing.Point(187, 708);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdUpdate.Size = new System.Drawing.Size(73, 25);
            this.CmdUpdate.TabIndex = 16;
            this.CmdUpdate.Text = "&Update";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            // 
            // CmdCreate
            // 
            this.CmdCreate.BackColor = System.Drawing.SystemColors.Control;
            this.CmdCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdCreate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdCreate.Location = new System.Drawing.Point(96, 708);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdCreate.Size = new System.Drawing.Size(73, 25);
            this.CmdCreate.TabIndex = 17;
            this.CmdCreate.Text = "&Create";
            this.CmdCreate.UseVisualStyleBackColor = false;
            this.CmdCreate.Click += new System.EventHandler(this.CmdCreate_Click);
            // 
            // CmbCurr
            // 
            this.CmbCurr.BackColor = System.Drawing.SystemColors.Window;
            this.CmbCurr.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbCurr.Location = new System.Drawing.Point(111, 625);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbCurr.Size = new System.Drawing.Size(49, 22);
            this.CmbCurr.TabIndex = 18;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(16, 628);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(60, 19);
            this.Label4.TabIndex = 19;
            this.Label4.Text = "Curr";
            // 
            // CmbAcctType
            // 
            this.CmbAcctType.BackColor = System.Drawing.SystemColors.Window;
            this.CmbAcctType.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbAcctType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAcctType.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAcctType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbAcctType.Location = new System.Drawing.Point(111, 598);
            this.CmbAcctType.Name = "CmbAcctType";
            this.CmbAcctType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbAcctType.Size = new System.Drawing.Size(97, 22);
            this.CmbAcctType.TabIndex = 20;
            this.CmbAcctType.SelectedIndexChanged += new System.EventHandler(this.CmbAcctType_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(16, 598);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(74, 25);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "Acct Type";
            // 
            // txtAcctName
            // 
            this.txtAcctName.AcceptsReturn = true;
            this.txtAcctName.BackColor = System.Drawing.SystemColors.Window;
            this.txtAcctName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAcctName.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcctName.Location = new System.Drawing.Point(111, 572);
            this.txtAcctName.MaxLength = 30;
            this.txtAcctName.Name = "txtAcctName";
            this.txtAcctName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAcctName.Size = new System.Drawing.Size(234, 20);
            this.txtAcctName.TabIndex = 22;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(16, 572);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(73, 25);
            this.Label2.TabIndex = 23;
            this.Label2.Text = "Acct Name";
            // 
            // CmbAcctCode
            // 
            this.CmbAcctCode.BackColor = System.Drawing.SystemColors.Window;
            this.CmbAcctCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbAcctCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAcctCode.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAcctCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbAcctCode.Location = new System.Drawing.Point(111, 544);
            this.CmbAcctCode.Name = "CmbAcctCode";
            this.CmbAcctCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbAcctCode.Size = new System.Drawing.Size(281, 22);
            this.CmbAcctCode.TabIndex = 24;
            this.CmbAcctCode.SelectedIndexChanged += new System.EventHandler(this.CmbAcctCode_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(16, 545);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(74, 21);
            this.Label3.TabIndex = 25;
            this.Label3.Text = "Acct Code";
            // 
            // gvAcctRef
            // 
            this.gvAcctRef.AllowUserToAddRows = false;
            this.gvAcctRef.AllowUserToDeleteRows = false;
            this.gvAcctRef.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAcctRef.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAcctRef.Location = new System.Drawing.Point(19, 74);
            this.gvAcctRef.MultiSelect = false;
            this.gvAcctRef.Name = "gvAcctRef";
            this.gvAcctRef.ReadOnly = true;
            this.gvAcctRef.Size = new System.Drawing.Size(524, 461);
            this.gvAcctRef.TabIndex = 26;
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(68, 30);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(417, 41);
            this.Label21.TabIndex = 27;
            this.Label21.Text = "ACCOUNTING REF SETUP";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(16, 653);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(73, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Acct Order";
            // 
            // txtAcctOrder
            // 
            this.txtAcctOrder.AcceptsReturn = true;
            this.txtAcctOrder.BackColor = System.Drawing.SystemColors.Window;
            this.txtAcctOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAcctOrder.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcctOrder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAcctOrder.Location = new System.Drawing.Point(111, 652);
            this.txtAcctOrder.MaxLength = 30;
            this.txtAcctOrder.Name = "txtAcctOrder";
            this.txtAcctOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAcctOrder.Size = new System.Drawing.Size(49, 20);
            this.txtAcctOrder.TabIndex = 29;
            this.txtAcctOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcctOrder_KeyPress);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(16, 680);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(89, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "Current Asset";
            // 
            // CmbCurrentAsset
            // 
            this.CmbCurrentAsset.BackColor = System.Drawing.SystemColors.Window;
            this.CmbCurrentAsset.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbCurrentAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrentAsset.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCurrentAsset.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbCurrentAsset.Location = new System.Drawing.Point(111, 677);
            this.CmbCurrentAsset.Name = "CmbCurrentAsset";
            this.CmbCurrentAsset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbCurrentAsset.Size = new System.Drawing.Size(49, 22);
            this.CmbCurrentAsset.TabIndex = 31;
            // 
            // Setup_Acct_Ref
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(576, 745);
            this.ControlBox = false;
            this.Controls.Add(this.CmbCurrentAsset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAcctOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.gvAcctRef);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.CmbAcctCode);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtAcctName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CmbAcctType);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.CmbCurr);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.CmdUpdate);
            this.Controls.Add(this.CmdDel);
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.MainMenu1);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "Setup_Acct_Ref";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounting Ref Setup";
            this.Load += new System.EventHandler(this.Setup_Acct_Ref_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvAcctRef)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem MnAcctTypeRefSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrencyGroup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrSetup;
        public System.Windows.Forms.ToolStripMenuItem MnCurrRateSetup;
        public System.Windows.Forms.ToolStripMenuItem MnActivaPassivaSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStockGroup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSuffixSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksFlagSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivTypeSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivSetup;
        public System.Windows.Forms.ToolStripMenuItem MnETFStocksDivAllocSetup;
        public System.Windows.Forms.Button CmdDel;
        public System.Windows.Forms.Button CmdUpdate;
        public System.Windows.Forms.Button CmdCreate;
        public System.Windows.Forms.ComboBox CmbCurr;
        public System.Windows.Forms.Label Label4;
        public System.Windows.Forms.ComboBox CmbAcctType;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.TextBox txtAcctName;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbAcctCode;
        public System.Windows.Forms.Label Label3;
        private System.Windows.Forms.DataGridView gvAcctRef;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtAcctOrder;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox CmbCurrentAsset;
    }
}