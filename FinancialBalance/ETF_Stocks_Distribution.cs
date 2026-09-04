using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace FinancialBalance
{
    public partial class ETF_Stocks_Distribution : Form
    {
        bool FirstLoad;
        bool Filling;

        //TblETFStocksDistributionDividend has no primary key - the same ticker can pay twice
        //on one date - so a row is identified by the values it held when it was picked out of
        //the grid, and update and delete match on all of them.
        bool RowSelected;
        string OrgPayDate;
        string OrgFullTicker;
        string OrgPortfolioCode;
        string OrgCurrency;
        string OrgEntitledUnit;
        string OrgAmountPerUnit;
        string OrgTotalAmount;
        string OrgIsDrip;

        public ETF_Stocks_Distribution()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Distribution_Load(object sender, EventArgs e)
        {
            FirstLoad = true;
            Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

            Filling = true;
            Fill_Full_Ticker(CmbFilterTicker);
            Fill_Full_Ticker(CmbFullTicker);
            Mdl1.Fill_ETF_Stocks_Purchase_Flag(CmbFilterPortfolio);
            Mdl1.Fill_ETF_Stocks_Purchase_Flag(CmbPortfolio);
            Mdl1.Fill_Curr(CmbCurrency);
            Set_Default_Currency();
            Filling = false;

            //both dropdowns were filled with events suppressed, so the descriptions are
            //resolved once here rather than waiting for a selection that may never change
            Show_Filter_Description();
            Show_Portfolio_Description();

            ChangeLblDay();
            Clear_Grid();
            Clear_Entry();
            Get_Data();
            FirstLoad = false;

            monthCalendar1.Hide();
        }

        private void MnDaily_Click(object sender, EventArgs e)
        {
            Daily_Input Daily_Input = new Daily_Input();
            Daily_Input.Show();
            this.Close();
        }

        private void MnMonthlyClosing_Click(object sender, EventArgs e)
        {
            Monthly_Closing Monthly_Closing = new Monthly_Closing();
            Monthly_Closing.Show();
            this.Close();
        }

        private void MnETFStocksPrice_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Price ETF_Stocks_Price = new ETF_Stocks_Price();
            ETF_Stocks_Price.Show();
            this.Close();
        }

        private void MnETFStocksFYRecon_Click(object sender, EventArgs e)
        {
            ETF_Stocks_FY_Reconciliation ETF_Stocks_FY_Reconciliation = new ETF_Stocks_FY_Reconciliation();
            ETF_Stocks_FY_Reconciliation.Show();
            this.Close();
        }

        private void MnETFStocksInvestment_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Investment ETF_Stocks_Investment = new ETF_Stocks_Investment();
            ETF_Stocks_Investment.Show();
            this.Close();
        }

        private void MnETFStocksTrans_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Transaction ETF_Stocks_Transaction = new ETF_Stocks_Transaction();
            ETF_Stocks_Transaction.Show();
            this.Close();
        }

        private void Fill_Full_Ticker(ComboBox parCombo)
        {
            parCombo.Items.Clear();
            Mdl1.Ssql = "Select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                parCombo.Items.Add(reader["Full_Ticker"].ToString().Trim());
            }
            reader.Close();
            if (parCombo.Items.Count > 0)
            {
                parCombo.SelectedIndex = 0;
            }
        }

        //Fill_Curr defaults to IDR for the accounting pages; ETF money defaults to AUD
        private void Set_Default_Currency()
        {
            if (CmbCurrency.Items.Contains("AUD"))
            {
                CmbCurrency.Text = "AUD";
            }
        }

        //The code is what gets stored, but it is only five characters; the description is
        //shown beside it so the right portfolio is obvious without opening the setup page.
        private void Show_Description_For(ComboBox parCombo, Label parLabel)
        {
            string TmpCode = parCombo.Text.Trim();
            if (TmpCode == "")
            {
                parLabel.Text = "";
                return;
            }

            string TmpDesc = "";
            Mdl1.Ssql = "select Description from TblETFStocksPortfolioCode where Portfolio_Code = '" + TmpCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpDesc = (reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString().Trim());
            }
            reader.Close();

            parLabel.Text = (TmpDesc == "" ? "-" : TmpDesc);
        }

        private void Show_Filter_Description()
        {
            Show_Description_For(CmbFilterPortfolio, LblFilterDesc);
        }

        private void Show_Portfolio_Description()
        {
            Show_Description_For(CmbPortfolio, LblPortfolioDesc);
        }

        private void CmbFilterTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void CmbFilterPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Filter_Description();
            Get_Data();
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Portfolio_Description();
        }

        private string Get_Pay_Date()
        {
            return CmbYear.Text + CmbMM.Text + CmbDD.Text;
        }

        private void ChangeLblDay()
        {
            switch (DateTime.Parse(Mdl1.toLongDate(Get_Pay_Date())).DayOfWeek)
            {
                case DayOfWeek.Monday:
                    LblDay.Text = "Monday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Tuesday:
                    LblDay.Text = "Tuesday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Wednesday:
                    LblDay.Text = "Wednesday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Thursday:
                    LblDay.Text = "Thursday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Friday:
                    LblDay.Text = "Friday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Saturday:
                    LblDay.Text = "Saturday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Sunday:
                    LblDay.Text = "Sunday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(255);
                    break;
            }
        }

        private void DateChanged()
        {
            if (FirstLoad)
            {
                return;
            }
            if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
            {
                ChangeLblDay();
            }
            else
            {
                MessageBox.Show("Invalid Date !", "Error Message");
            }
        }

        private void CmbDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmbMM_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmdCal_Click(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(new System.DateTime(int.Parse(CmbYear.Text), int.Parse(CmbMM.Text), int.Parse(CmbDD.Text), 0, 0, 0, 0));
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            FirstLoad = true;
            CmbDD.Text = e.Start.Day.ToString("00");
            CmbMM.Text = e.Start.Month.ToString("00");
            CmbYear.Text = e.Start.Year.ToString("0000");
            FirstLoad = false;
            monthCalendar1.Hide();
            DateChanged();
        }

        private void Set_Date(string parYyyyMMdd)
        {
            FirstLoad = true;
            CmbYear.Text = parYyyyMMdd.Substring(0, 4);
            CmbMM.Text = parYyyyMMdd.Substring(4, 2);
            CmbDD.Text = parYyyyMMdd.Substring(6, 2);
            FirstLoad = false;
            ChangeLblDay();
        }

        private double Read_Double(object parValue)
        {
            double TmpValue;
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            if (double.TryParse(parValue.ToString(), out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        //Culture-independent literal for SQL, at the scale the column stores
        private string Sql_Num(object parValue, int parDecimals)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return null;
            }
            decimal TmpValue;
            if (!decimal.TryParse(parValue.ToString(), out TmpValue))
            {
                TmpValue = 0;
            }
            return TmpValue.ToString("0." + new string('0', parDecimals), CultureInfo.InvariantCulture);
        }

        private string Num(decimal parValue, int parDecimals)
        {
            return parValue.ToString("0." + new string('0', parDecimals), CultureInfo.InvariantCulture);
        }

        private void Clear_Grid()
        {
            gvDist.Columns.Clear();
            gvDist.ColumnCount = 8;
            string[] names = new string[] { "Pay Date", "Full Ticker", "Portfolio Code", "Currency",
                                            "Entitled Unit", "Amount Per Unit", "Total Amount", "Reinvested" };
            int[] weights = new int[] { 13, 13, 12, 9, 13, 14, 14, 7 };
            for (int i = 0; i < 8; i++)
            {
                gvDist.Columns[i].Name = names[i];
                gvDist.Columns[i].FillWeight = weights[i];
                if (i <= 1)
                {
                    gvDist.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    gvDist.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else if (i <= 3 || i == 7)
                {
                    gvDist.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gvDist.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    gvDist.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvDist.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private string Select_Rows()
        {
            return "select Pay_Date, Full_Ticker, [Portfolio_Code], [Currency], [Entitled_Unit],"
                 + " [Amount_Per_Unit], [Total_Amount], [Is_Reinvested] from TblETFStocksDistributionDividend"
                 + " where Full_Ticker = '" + CmbFilterTicker.Text.Trim() + "'"
                 + " and [Portfolio_Code] = '" + CmbFilterPortfolio.Text.Trim() + "'"
                 + " order by Pay_Date Desc";
        }

        //Most recent payment first, for the ticker and portfolio on show
        private void Get_Data()
        {
            Filling = true;
            RowSelected = false;

            gvDist.Rows.Clear();

            if (CmbFilterTicker.Text.Trim() != "" && CmbFilterPortfolio.Text.Trim() != "")
            {
                Mdl1.Ssql = Select_Rows();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string TmpDate = reader["Pay_Date"].ToString().Trim();
                    gvDist.Rows.Add(new string[] {
                        Mdl1.toLongDate(TmpDate),
                        reader["Full_Ticker"].ToString().Trim(),
                        reader["Portfolio_Code"].ToString().Trim(),
                        reader["Currency"].ToString().Trim(),
                        Read_Double(reader["Entitled_Unit"]).ToString("#,##0.0000"),
                        Read_Double(reader["Amount_Per_Unit"]).ToString("#,##0.0000"),
                        Mdl1.FormatAmt(Read_Double(reader["Total_Amount"])),
                        (reader["Is_Reinvested"].ToString().Trim() == "True" ? "Y" : "N") });
                }
                reader.Close();
            }

            gvDist.ClearSelection();
            LblFilterCaption.Text = "Show  (" + gvDist.Rows.Count.ToString() + " payment(s))";

            Filling = false;
        }

        //Clicking a row loads it into the entry area and remembers it for update or delete
        private void gvDist_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }

            DataGridViewRow Row = null;
            if (gvDist.SelectedRows.Count > 0)
            {
                Row = gvDist.SelectedRows[0];
            }
            else
            {
                Row = gvDist.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            int Ord = Row.Index;

            //re-read from the table so the originals are exact rather than display-rounded
            Mdl1.Ssql = Select_Rows();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            bool Found = false;
            while (reader.Read())
            {
                if (i == Ord)
                {
                    OrgPayDate = reader["Pay_Date"].ToString().Trim();
                    OrgFullTicker = reader["Full_Ticker"].ToString().Trim();
                    OrgPortfolioCode = (reader["Portfolio_Code"] == DBNull.Value ? null : reader["Portfolio_Code"].ToString().Trim());
                    OrgCurrency = (reader["Currency"] == DBNull.Value ? null : reader["Currency"].ToString().Trim());
                    OrgEntitledUnit = Sql_Num(reader["Entitled_Unit"], 4);
                    OrgAmountPerUnit = Sql_Num(reader["Amount_Per_Unit"], 4);
                    OrgTotalAmount = Sql_Num(reader["Total_Amount"], 2);
                    OrgIsDrip = (reader["Is_Reinvested"].ToString().Trim() == "True" ? "True" : "False");
                    Found = true;
                    break;
                }
                i++;
            }
            reader.Close();

            if (!Found)
            {
                return;
            }

            Filling = true;
            Set_Date(OrgPayDate);
            if (CmbFullTicker.Items.Contains(OrgFullTicker))
            {
                CmbFullTicker.Text = OrgFullTicker;
            }
            if (OrgPortfolioCode != null && CmbPortfolio.Items.Contains(OrgPortfolioCode))
            {
                CmbPortfolio.Text = OrgPortfolioCode;
            }
            if (OrgCurrency != null && !CmbCurrency.Items.Contains(OrgCurrency))
            {
                CmbCurrency.Items.Add(OrgCurrency);
            }
            if (OrgCurrency != null)
            {
                CmbCurrency.Text = OrgCurrency;
            }
            txtEntitledUnit.Text = (OrgEntitledUnit == null ? "0.0000" : OrgEntitledUnit);
            txtAmountPerUnit.Text = (OrgAmountPerUnit == null ? "0.0000" : OrgAmountPerUnit);
            txtTotalAmount.Text = (OrgTotalAmount == null ? "0.00" : OrgTotalAmount);
            chkDrip.Checked = (OrgIsDrip == "True");
            Filling = false;

            Show_Portfolio_Description();
            RowSelected = true;
            LblEntryCaption.Text = "Distribution / dividend  (editing the selected payment)";
        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        //Total Amount is derived from the two boxes above it, but stays editable - a manual
        //figure stands until one of those two changes again, which is what re-derives it.
        private void Amount_TextChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Calculate_Total();
        }

        private void Calculate_Total()
        {
            double TmpUnit;
            double TmpPerUnit;
            double.TryParse(txtEntitledUnit.Text.Trim(), out TmpUnit);
            double.TryParse(txtAmountPerUnit.Text.Trim(), out TmpPerUnit);

            Filling = true;
            txtTotalAmount.Text = Math.Round(TmpUnit * TmpPerUnit, 2).ToString("0.00", CultureInfo.InvariantCulture);
            Filling = false;
        }

        //Numeric, not negative, and no more than parDecimals decimal places
        private bool Valid_Amount(string parText, int parDecimals, string parField, out decimal parValue)
        {
            parValue = 0;

            string TmpText = parText.Trim();
            if (TmpText == "")
            {
                MessageBox.Show(parField + " cannot be empty !", "Error Message");
                return false;
            }
            if (!decimal.TryParse(TmpText, NumberStyles.Number, CultureInfo.CurrentCulture, out parValue))
            {
                MessageBox.Show(parField + " must be a number !", "Error Message");
                return false;
            }
            if (parValue < 0)
            {
                MessageBox.Show(parField + " cannot be negative !", "Error Message");
                return false;
            }

            string TmpPlain = TmpText.Replace(",", "");
            int TmpDot = TmpPlain.IndexOf('.');
            if (TmpDot >= 0 && (TmpPlain.Length - TmpDot - 1) > parDecimals)
            {
                MessageBox.Show(parField + " can have a maximum of " + parDecimals.ToString() + " decimal points !", "Error Message");
                return false;
            }
            return true;
        }

        private bool Validate_Entry(out decimal parEntitledUnit, out decimal parAmountPerUnit, out decimal parTotalAmount)
        {
            parEntitledUnit = 0;
            parAmountPerUnit = 0;
            parTotalAmount = 0;

            if (CmbFullTicker.Text.Trim() == "")
            {
                MessageBox.Show("Full Ticker must be selected ! Please set one up first in ETF/Stock Setup.", "Error Message");
                return false;
            }
            if (CmbPortfolio.Text.Trim() == "")
            {
                MessageBox.Show("Portfolio must be selected ! Please set one up first in ETF/Stock Portfolio Code Setup.", "Error Message");
                return false;
            }
            if (CmbCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Currency must be selected !", "Error Message");
                return false;
            }
            if (!Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
            {
                MessageBox.Show("Invalid Date !", "Error Message");
                return false;
            }
            if (!Valid_Amount(txtEntitledUnit.Text, 4, "Entitled Unit", out parEntitledUnit))
            {
                return false;
            }
            if (!Valid_Amount(txtAmountPerUnit.Text, 4, "Amount Per Unit", out parAmountPerUnit))
            {
                return false;
            }
            if (!Valid_Amount(txtTotalAmount.Text, 2, "Total Amount", out parTotalAmount))
            {
                return false;
            }
            return true;
        }

        private string Where_Col(string parCol, string parValue)
        {
            if (parValue == null)
            {
                return " and " + parCol + " Is Null";
            }
            return " and " + parCol + " = " + parValue;
        }

        private string Where_Original()
        {
            return " where Pay_Date = '" + OrgPayDate + "'"
                 + " and Full_Ticker = '" + OrgFullTicker + "'"
                 + (OrgPortfolioCode == null ? " and [Portfolio_Code] Is Null" : " and [Portfolio_Code] = '" + OrgPortfolioCode + "'")
                 + (OrgCurrency == null ? " and [Currency] Is Null" : " and [Currency] = '" + OrgCurrency + "'")
                 + Where_Col("[Entitled_Unit]", OrgEntitledUnit)
                 + Where_Col("[Amount_Per_Unit]", OrgAmountPerUnit)
                 + Where_Col("[Total_Amount]", OrgTotalAmount)
                 + " and [Is_Reinvested] = " + OrgIsDrip;
        }

        //Without a key, identical rows are indistinguishable - warn before touching them all
        private bool Confirm_Affected(string parAction)
        {
            int TmpCount = 0;
            Mdl1.Ssql = "select count(*) as N from TblETFStocksDistributionDividend" + Where_Original();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpCount = int.Parse(reader["N"].ToString());
            }
            reader.Close();

            if (TmpCount == 0)
            {
                MessageBox.Show("The selected payment could no longer be found.", "Error Message");
                return false;
            }
            if (TmpCount > 1)
            {
                DialogResult Response = MessageBox.Show(TmpCount.ToString() + " identical payments exist. " + parAction
                    + " will affect all " + TmpCount.ToString() + " of them. Continue ?", "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        private void Clear_Entry()
        {
            Filling = true;
            RowSelected = false;
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);
            if (CmbFilterTicker.Text.Trim() != "" && CmbFullTicker.Items.Contains(CmbFilterTicker.Text.Trim()))
            {
                CmbFullTicker.Text = CmbFilterTicker.Text.Trim();
            }
            if (CmbFilterPortfolio.Text.Trim() != "" && CmbPortfolio.Items.Contains(CmbFilterPortfolio.Text.Trim()))
            {
                CmbPortfolio.Text = CmbFilterPortfolio.Text.Trim();
            }
            Set_Default_Currency();
            txtEntitledUnit.Text = "0.0000";
            txtAmountPerUnit.Text = "0.0000";
            txtTotalAmount.Text = "0.00";
            chkDrip.Checked = false;
            Filling = false;

            Show_Portfolio_Description();
            ChangeLblDay();
            LblEntryCaption.Text = "Distribution / dividend";
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Filling = true;
            gvDist.ClearSelection();
            Filling = false;
            Clear_Entry();
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpEntitledUnit;
                decimal TmpAmountPerUnit;
                decimal TmpTotalAmount;

                if (!Validate_Entry(out TmpEntitledUnit, out TmpAmountPerUnit, out TmpTotalAmount))
                {
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksDistributionDividend (Pay_Date, Full_Ticker, [Portfolio_Code],"
                          + " [Currency], [Entitled_Unit], [Amount_Per_Unit], [Total_Amount], [Is_Reinvested]) values ("
                          + "'" + Get_Pay_Date() + "', "
                          + "'" + CmbFullTicker.Text.Trim() + "', "
                          + "'" + CmbPortfolio.Text.Trim() + "', "
                          + "'" + CmbCurrency.Text.Trim() + "', "
                          + Num(TmpEntitledUnit, 4) + ", "
                          + Num(TmpAmountPerUnit, 4) + ", "
                          + Num(TmpTotalAmount, 2) + ", "
                          + (chkDrip.Checked ? "True" : "False") + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + CmbFullTicker.Text.Trim() + " on "
                    + Mdl1.toLongDate(Get_Pay_Date()), "Success");

                Show_Saved_Row();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //A payment just saved may not be under the filter currently on show; move the filter
        //to it rather than leaving the user staring at an unchanged table.
        private void Show_Saved_Row()
        {
            Filling = true;
            if (CmbFilterTicker.Items.Contains(CmbFullTicker.Text.Trim()))
            {
                CmbFilterTicker.Text = CmbFullTicker.Text.Trim();
            }
            if (CmbFilterPortfolio.Items.Contains(CmbPortfolio.Text.Trim()))
            {
                CmbFilterPortfolio.Text = CmbPortfolio.Text.Trim();
            }
            Filling = false;

            Show_Filter_Description();
            Get_Data();
            Clear_Entry();
        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpEntitledUnit;
                decimal TmpAmountPerUnit;
                decimal TmpTotalAmount;

                if (!RowSelected)
                {
                    MessageBox.Show("Please select a payment in the table first !", "Error Message");
                    return;
                }
                if (!Validate_Entry(out TmpEntitledUnit, out TmpAmountPerUnit, out TmpTotalAmount))
                {
                    return;
                }
                if (!Confirm_Affected("Update"))
                {
                    return;
                }

                Mdl1.Ssql = "Update TblETFStocksDistributionDividend set "
                          + "Pay_Date = '" + Get_Pay_Date() + "', "
                          + "Full_Ticker = '" + CmbFullTicker.Text.Trim() + "', "
                          + "[Portfolio_Code] = '" + CmbPortfolio.Text.Trim() + "', "
                          + "[Currency] = '" + CmbCurrency.Text.Trim() + "', "
                          + "[Entitled_Unit] = " + Num(TmpEntitledUnit, 4) + ", "
                          + "[Amount_Per_Unit] = " + Num(TmpAmountPerUnit, 4) + ", "
                          + "[Total_Amount] = " + Num(TmpTotalAmount, 2) + ", "
                          + "[Is_Reinvested] = " + (chkDrip.Checked ? "True" : "False")
                          + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + CmbFullTicker.Text.Trim() + " on "
                    + Mdl1.toLongDate(Get_Pay_Date()), "Success");

                Show_Saved_Row();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!RowSelected)
                {
                    MessageBox.Show("Please select a payment in the table first !", "Error Message");
                    return;
                }
                if (!Confirm_Affected("Delete"))
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksDistributionDividend" + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + OrgFullTicker + " on "
                    + Mdl1.toLongDate(OrgPayDate), "Success");

                Get_Data();
                Clear_Entry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
