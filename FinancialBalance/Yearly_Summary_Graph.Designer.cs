namespace FinancialBalance
{
    partial class Yearly_Summary_Graph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yearly_Summary_Graph));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series seriesAsset = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series seriesLiability = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series seriesIncome = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series seriesExpense = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.CmdBack = new System.Windows.Forms.Button();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.chkAsset = new System.Windows.Forms.CheckBox();
            this.chkLiability = new System.Windows.Forms.CheckBox();
            this.chkIncome = new System.Windows.Forms.CheckBox();
            this.chkExpense = new System.Windows.Forms.CheckBox();
            this.chartGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gvGraph = new System.Windows.Forms.DataGridView();
            this.lblNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGraph)).BeginInit();
            this.SuspendLayout();
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(496, 728);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdBack.Size = new System.Drawing.Size(89, 25);
            this.CmdBack.TabIndex = 6;
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
            this.Label21.Location = new System.Drawing.Point(309, 0);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(460, 41);
            this.Label21.TabIndex = 7;
            this.Label21.Text = "YEARLY SUMMARY GRAPH";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(285, 55);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(40, 16);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Year";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CmbYear
            //
            this.CmbYear.BackColor = System.Drawing.SystemColors.Window;
            this.CmbYear.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbYear.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbYear.Location = new System.Drawing.Point(330, 52);
            this.CmbYear.MaxDropDownItems = 12;
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbYear.Size = new System.Drawing.Size(80, 22);
            this.CmbYear.TabIndex = 0;
            this.CmbYear.SelectedIndexChanged += new System.EventHandler(this.CmbYear_SelectedIndexChanged);
            //
            // chkAsset
            //
            this.chkAsset.BackColor = System.Drawing.Color.Transparent;
            this.chkAsset.Checked = true;
            this.chkAsset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAsset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAsset.Location = new System.Drawing.Point(440, 51);
            this.chkAsset.Name = "chkAsset";
            this.chkAsset.Size = new System.Drawing.Size(70, 24);
            this.chkAsset.TabIndex = 1;
            this.chkAsset.Text = "Asset";
            this.chkAsset.UseVisualStyleBackColor = false;
            this.chkAsset.CheckedChanged += new System.EventHandler(this.chkCategory_CheckedChanged);
            //
            // chkLiability
            //
            this.chkLiability.BackColor = System.Drawing.Color.Transparent;
            this.chkLiability.Checked = true;
            this.chkLiability.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLiability.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLiability.Location = new System.Drawing.Point(522, 51);
            this.chkLiability.Name = "chkLiability";
            this.chkLiability.Size = new System.Drawing.Size(80, 24);
            this.chkLiability.TabIndex = 2;
            this.chkLiability.Text = "Liability";
            this.chkLiability.UseVisualStyleBackColor = false;
            this.chkLiability.CheckedChanged += new System.EventHandler(this.chkCategory_CheckedChanged);
            //
            // chkIncome
            //
            this.chkIncome.BackColor = System.Drawing.Color.Transparent;
            this.chkIncome.Checked = true;
            this.chkIncome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncome.Location = new System.Drawing.Point(614, 51);
            this.chkIncome.Name = "chkIncome";
            this.chkIncome.Size = new System.Drawing.Size(78, 24);
            this.chkIncome.TabIndex = 3;
            this.chkIncome.Text = "Income";
            this.chkIncome.UseVisualStyleBackColor = false;
            this.chkIncome.CheckedChanged += new System.EventHandler(this.chkCategory_CheckedChanged);
            //
            // chkExpense
            //
            this.chkExpense.BackColor = System.Drawing.Color.Transparent;
            this.chkExpense.Checked = true;
            this.chkExpense.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExpense.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExpense.Location = new System.Drawing.Point(704, 51);
            this.chkExpense.Name = "chkExpense";
            this.chkExpense.Size = new System.Drawing.Size(88, 24);
            this.chkExpense.TabIndex = 4;
            this.chkExpense.Text = "Expense";
            this.chkExpense.UseVisualStyleBackColor = false;
            this.chkExpense.CheckedChanged += new System.EventHandler(this.chkCategory_CheckedChanged);
            //
            // chartGraph
            //
            this.chartGraph.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
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
            this.chartGraph.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            legend1.Name = "Legend1";
            this.chartGraph.Legends.Add(legend1);
            this.chartGraph.Location = new System.Drawing.Point(16, 86);
            this.chartGraph.Name = "chartGraph";
            seriesAsset.BorderWidth = 3;
            seriesAsset.ChartArea = "ChartArea1";
            seriesAsset.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesAsset.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))));
            seriesAsset.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            seriesAsset.Legend = "Legend1";
            seriesAsset.MarkerSize = 7;
            seriesAsset.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            seriesAsset.Name = "Asset";
            seriesAsset.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chartGraph.Series.Add(seriesAsset);
            seriesLiability.BorderWidth = 3;
            seriesLiability.ChartArea = "ChartArea1";
            seriesLiability.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesLiability.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            seriesLiability.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            seriesLiability.Legend = "Legend1";
            seriesLiability.MarkerSize = 7;
            seriesLiability.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            seriesLiability.Name = "Liability";
            seriesLiability.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chartGraph.Series.Add(seriesLiability);
            seriesIncome.BorderWidth = 3;
            seriesIncome.ChartArea = "ChartArea1";
            seriesIncome.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesIncome.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            seriesIncome.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            seriesIncome.Legend = "Legend1";
            seriesIncome.MarkerSize = 7;
            seriesIncome.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            seriesIncome.Name = "Income";
            seriesIncome.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chartGraph.Series.Add(seriesIncome);
            seriesExpense.BorderWidth = 3;
            seriesExpense.ChartArea = "ChartArea1";
            seriesExpense.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            seriesExpense.Color = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(125)))), ((int)(((byte)(49)))));
            seriesExpense.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            seriesExpense.Legend = "Legend1";
            seriesExpense.MarkerSize = 7;
            seriesExpense.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            seriesExpense.Name = "Expense";
            seriesExpense.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chartGraph.Series.Add(seriesExpense);
            this.chartGraph.Size = new System.Drawing.Size(1046, 376);
            this.chartGraph.TabIndex = 9;
            this.chartGraph.TabStop = false;
            title1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            title1.Name = "MainTitle";
            this.chartGraph.Titles.Add(title1);
            //
            // gvGraph
            //
            this.gvGraph.AllowUserToAddRows = false;
            this.gvGraph.AllowUserToDeleteRows = false;
            this.gvGraph.AllowUserToResizeColumns = false;
            this.gvGraph.AllowUserToResizeRows = false;
            this.gvGraph.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvGraph.BackgroundColor = System.Drawing.Color.White;
            this.gvGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gvGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvGraph.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvGraph.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvGraph.Location = new System.Drawing.Point(16, 470);
            this.gvGraph.MultiSelect = false;
            this.gvGraph.Name = "gvGraph";
            this.gvGraph.RowHeadersVisible = false;
            this.gvGraph.RowTemplate.Height = 18;
            this.gvGraph.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvGraph.Size = new System.Drawing.Size(1046, 196);
            this.gvGraph.TabIndex = 5;
            //
            // lblNote
            //
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNote.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNote.Location = new System.Drawing.Point(16, 674);
            this.lblNote.Name = "lblNote";
            this.lblNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNote.Size = new System.Drawing.Size(1046, 48);
            this.lblNote.TabIndex = 10;
            //
            // Yearly_Summary_Graph
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(1078, 762);
            this.ControlBox = false;
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.gvGraph);
            this.Controls.Add(this.chartGraph);
            this.Controls.Add(this.chkExpense);
            this.Controls.Add(this.chkIncome);
            this.Controls.Add(this.chkLiability);
            this.Controls.Add(this.chkAsset);
            this.Controls.Add(this.CmbYear);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.CmdBack);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "Yearly_Summary_Graph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yearly Summary Graph";
            this.Load += new System.EventHandler(this.Yearly_Summary_Graph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button CmdBack;
        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbYear;
        public System.Windows.Forms.CheckBox chkAsset;
        public System.Windows.Forms.CheckBox chkLiability;
        public System.Windows.Forms.CheckBox chkIncome;
        public System.Windows.Forms.CheckBox chkExpense;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartGraph;
        public System.Windows.Forms.DataGridView gvGraph;
        public System.Windows.Forms.Label lblNote;
    }
}
