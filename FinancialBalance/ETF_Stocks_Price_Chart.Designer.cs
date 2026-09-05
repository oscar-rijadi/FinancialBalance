namespace FinancialBalance
{
    partial class ETF_Stocks_Price_Chart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ETF_Stocks_Price_Chart));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbTicker = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbFinYear = new System.Windows.Forms.ComboBox();
            this.LblCurrency = new System.Windows.Forms.Label();
            this.LblNote = new System.Windows.Forms.Label();
            this.chartPrice = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrice)).BeginInit();
            this.SuspendLayout();
            //
            // Label21
            //
            this.Label21.BackColor = System.Drawing.Color.Transparent;
            this.Label21.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label21.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Label21.Location = new System.Drawing.Point(120, 18);
            this.Label21.Name = "Label21";
            this.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label21.Size = new System.Drawing.Size(760, 38);
            this.Label21.TabIndex = 0;
            this.Label21.Text = "ETF/STOCK PRICE CHART";
            //
            // Label1
            //
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 70);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(90, 22);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Full Ticker";
            //
            // CmbTicker
            //
            this.CmbTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTicker.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTicker.FormattingEnabled = true;
            this.CmbTicker.Location = new System.Drawing.Point(115, 68);
            this.CmbTicker.Name = "CmbTicker";
            this.CmbTicker.Size = new System.Drawing.Size(200, 22);
            this.CmbTicker.TabIndex = 2;
            this.CmbTicker.SelectedIndexChanged += new System.EventHandler(this.CmbTicker_SelectedIndexChanged);
            //
            // Label2
            //
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(345, 70);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 22);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Financial Year";
            //
            // CmbFinYear
            //
            this.CmbFinYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFinYear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFinYear.FormattingEnabled = true;
            this.CmbFinYear.Location = new System.Drawing.Point(450, 68);
            this.CmbFinYear.Name = "CmbFinYear";
            this.CmbFinYear.Size = new System.Drawing.Size(200, 22);
            this.CmbFinYear.TabIndex = 4;
            this.CmbFinYear.SelectedIndexChanged += new System.EventHandler(this.CmbFinYear_SelectedIndexChanged);
            //
            // LblCurrency
            //
            this.LblCurrency.BackColor = System.Drawing.Color.Transparent;
            this.LblCurrency.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrency.ForeColor = System.Drawing.Color.Black;
            this.LblCurrency.Location = new System.Drawing.Point(690, 68);
            this.LblCurrency.Name = "LblCurrency";
            this.LblCurrency.Size = new System.Drawing.Size(180, 22);
            this.LblCurrency.TabIndex = 5;
            //
            // LblNote
            //
            this.LblNote.BackColor = System.Drawing.Color.Transparent;
            this.LblNote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNote.ForeColor = System.Drawing.Color.Black;
            this.LblNote.Location = new System.Drawing.Point(19, 98);
            this.LblNote.Name = "LblNote";
            this.LblNote.Size = new System.Drawing.Size(940, 20);
            this.LblNote.TabIndex = 6;
            //
            // chartPrice
            //
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8F);
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            //A price of $24 rising to $38 is the whole point of the chart, and an axis
            //anchored at zero squeezes that move into the top third.  The axis fits the
            //prices instead - the usual way a price series is drawn.
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 8F);
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.Silver;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chartPrice.ChartAreas.Add(chartArea1);
            this.chartPrice.Location = new System.Drawing.Point(19, 124);
            this.chartPrice.Name = "chartPrice";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            series1.IsValueShownAsLabel = true;
            series1.LabelFormat = "#,##0.00";
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Price";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            this.chartPrice.Series.Add(series1);
            this.chartPrice.Size = new System.Drawing.Size(940, 420);
            this.chartPrice.TabIndex = 7;
            this.chartPrice.TabStop = false;
            title1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            title1.Name = "MainTitle";
            this.chartPrice.Titles.Add(title1);
            //
            // CmdBack
            //
            this.CmdBack.BackColor = System.Drawing.SystemColors.Control;
            this.CmdBack.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdBack.Location = new System.Drawing.Point(874, 560);
            this.CmdBack.Name = "CmdBack";
            this.CmdBack.Size = new System.Drawing.Size(85, 27);
            this.CmdBack.TabIndex = 8;
            this.CmdBack.Text = "&Back";
            this.CmdBack.UseVisualStyleBackColor = false;
            this.CmdBack.Click += new System.EventHandler(this.CmdBack_Click);
            //
            // ETF_Stocks_Price_Chart
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.CancelButton = this.CmdBack;
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.ControlBox = false;
            this.Controls.Add(this.CmdBack);
            this.Controls.Add(this.chartPrice);
            this.Controls.Add(this.LblNote);
            this.Controls.Add(this.LblCurrency);
            this.Controls.Add(this.CmbFinYear);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.CmbTicker);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label21);
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 43);
            this.Name = "ETF_Stocks_Price_Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETF/Stock Price Chart";
            this.Load += new System.EventHandler(this.ETF_Stocks_Price_Chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Label21;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.ComboBox CmbTicker;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.ComboBox CmbFinYear;
        public System.Windows.Forms.Label LblCurrency;
        public System.Windows.Forms.Label LblNote;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartPrice;
        public System.Windows.Forms.Button CmdBack;
    }
}
