namespace FinancialBalance
{
    partial class Yearly_Statistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yearly_Statistic));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.CmdBack = new System.Windows.Forms.Button();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbCategory = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbAccount = new System.Windows.Forms.ComboBox();
            this.chartYearly = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gvStat = new System.Windows.Forms.DataGridView();
            this.lblNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStat)).BeginInit();
            this.SuspendLayout();
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(496, 726);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 25);
            this.CmdBack.TabIndex = 3;
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
            this.Label21.Location = new System.Drawing.Point(379, 0);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(320, 41);
            this.Label21.TabIndex = 4;
            this.Label21.Text = "YEARLY STATISTIC";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(193, 55);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(60, 16);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Category";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmbCategory
            //
            this.CmbCategory.BackColor = System.Drawing.SystemColors.Window;
            this.CmbCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCategory.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCategory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbCategory.Location = new System.Drawing.Point(258, 52);
            this.CmbCategory.Name = "CmbCategory";
            this.CmbCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbCategory.Size = new System.Drawing.Size(110, 22);
            this.CmbCategory.TabIndex = 0;
            this.CmbCategory.SelectedIndexChanged += new System.EventHandler(this.CmbCategory_SelectedIndexChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(389, 55);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(58, 16);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Account";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmbAccount
            //
            this.CmbAccount.BackColor = System.Drawing.SystemColors.Window;
            this.CmbAccount.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAccount.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAccount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbAccount.Location = new System.Drawing.Point(452, 52);
            this.CmbAccount.MaxDropDownItems = 20;
            this.CmbAccount.Name = "CmbAccount";
            this.CmbAccount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbAccount.Size = new System.Drawing.Size(430, 22);
            this.CmbAccount.TabIndex = 1;
            this.CmbAccount.SelectedIndexChanged += new System.EventHandler(this.CmbAccount_SelectedIndexChanged);
            //
            // chartYearly
            //
            this.chartYearly.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            chartArea1.AxisY.LabelStyle.Format = "#,##0";
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.Silver;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartYearly.ChartAreas.Add(chartArea1);
            this.chartYearly.Location = new System.Drawing.Point(16, 86);
            this.chartYearly.Name = "chartYearly";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "#,##0";
            series1.Name = "Amount";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chartYearly.Series.Add(series1);
            this.chartYearly.Size = new System.Drawing.Size(1046, 392);
            this.chartYearly.TabIndex = 7;
            this.chartYearly.TabStop = false;
            title1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            title1.Name = "MainTitle";
            this.chartYearly.Titles.Add(title1);
            //
            // gvStat
            //
            this.gvStat.AllowUserToAddRows = false;
            this.gvStat.AllowUserToDeleteRows = false;
            this.gvStat.AllowUserToResizeColumns = false;
            this.gvStat.AllowUserToResizeRows = false;
            this.gvStat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvStat.BackgroundColor = System.Drawing.Color.White;
            this.gvStat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gvStat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvStat.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvStat.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvStat.Location = new System.Drawing.Point(16, 486);
            this.gvStat.MultiSelect = false;
            this.gvStat.Name = "gvStat";
            this.gvStat.RowHeadersVisible = false;
            this.gvStat.RowTemplate.Height = 18;
            this.gvStat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvStat.Size = new System.Drawing.Size(1046, 210);
            this.gvStat.TabIndex = 2;
            //
            // lblNote
            //
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNote.Location = new System.Drawing.Point(16, 703);
            this.lblNote.Name = "lblNote";
            this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNote.Size = new System.Drawing.Size(1046, 16);
            this.lblNote.TabIndex = 8;
            //
            // Yearly_Statistic
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1078, 762);
            this.ControlBox = false;
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.gvStat);
            this.Controls.Add(this.chartYearly);
            this.Controls.Add(this.CmbAccount);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CmbCategory);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.CmdBack);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "Yearly_Statistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yearly Statistic";
            this.Load += new System.EventHandler(this.Yearly_Statistic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartYearly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbCategory;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbAccount;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartYearly;
        public System.Windows.Forms.DataGridView gvStat;
        public System.Windows.Forms.Label lblNote;
    }
}
