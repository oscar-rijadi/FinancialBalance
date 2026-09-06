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
    public partial class ETF_Stocks_Purchase : Form
    {
        bool FirstLoad;
        bool Filling;

        //TblETFStocksPurchase has no primary key, so a row is identified by the values it held
        //when it was picked out of the grid.  A null entry means the column was Null.
        bool RowSelected;
        string OrgTransDate;
        string OrgFullTicker;
        string OrgCurrency;
        string OrgUnit;
        string OrgOriginalCostBase;
        string OrgOriginalTotalCostBase;
        string OrgCostBase;
        string OrgFee;
        string OrgTotalCostBase;
        string OrgRealTotalCostBase;
        string OrgIsSold;
        string OrgFlagCode;
        string OrgSoldDate;
        string OrgSaleId;

        //one MonthCalendar serves both the transaction date and the sold date
        string CalTarget = "TRANS";

        public ETF_Stocks_Purchase()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Purchase_Load(object sender, EventArgs e)
        {
            FirstLoad = true;
            Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            Mdl1.Fill_Date(CmbSoldDD, CmbSoldMM, CmbSoldYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

            Filling = true;
            Fill_Full_Ticker();
            Mdl1.Fill_Curr(CmbCurrency);
            Set_Default_Currency();
            Mdl1.Fill_ETF_Stocks_Purchase_Flag(CmbFlagCode);
            Filling = false;

            ChangeLblDay();
            Clear_Entry();
            Get_Data();
            FirstLoad = false;

            monthCalendar1.Hide();
        }

        //---- the menu -------------------------------------------------------------

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

        private void MnETFStocksInvestment_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Investment ETF_Stocks_Investment = new ETF_Stocks_Investment();
            ETF_Stocks_Investment.Show();
            this.Close();
        }

        private void MnETFStocksSale_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Sale ETF_Stocks_Sale = new ETF_Stocks_Sale();
            ETF_Stocks_Sale.Show();
            this.Close();
        }

        private void MnETFStocksDistribution_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Distribution ETF_Stocks_Distribution = new ETF_Stocks_Distribution();
            ETF_Stocks_Distribution.Show();
            this.Close();
        }

        private void MnETFStocksFYRecon_Click(object sender, EventArgs e)
        {
            ETF_Stocks_FY_Reconciliation ETF_Stocks_FY_Reconciliation = new ETF_Stocks_FY_Reconciliation();
            ETF_Stocks_FY_Reconciliation.Show();
            this.Close();
        }

        //---- the ticker and portfolio ---------------------------------------------

        private void Fill_Full_Ticker()
        {
            CmbFullTicker.Items.Clear();
            Mdl1.Ssql = "Select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CmbFullTicker.Items.Add(reader["Full_Ticker"].ToString().Trim());
                }
            }
            reader.Close();
            if (CmbFullTicker.Items.Count > 0)
            {
                CmbFullTicker.Text = CmbFullTicker.Items[0].ToString();
            }
        }

        //Purchases default to the OB portfolio code
        private void Set_Default_Flag()
        {
            if (CmbFlagCode.Items.Contains("OB"))
            {
                CmbFlagCode.Text = "OB";
            }
            Show_Portfolio_Description();
        }

        private void CmbFlagCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Portfolio_Description();
        }

        //The code is what gets stored, but it is only five characters; the description is
        //shown beside it so the right portfolio is obvious without opening the setup page.
        private void Show_Portfolio_Description()
        {
            string TmpCode = CmbFlagCode.Text.Trim();
            if (TmpCode == "")
            {
                LblPortfolioDesc.Text = "";
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

            LblPortfolioDesc.Text = (TmpDesc == "" ? "-" : TmpDesc);
        }

        //Fill_Curr defaults to IDR for the accounting pages; ETF trades default to AUD
        private void Set_Default_Currency()
        {
            if (CmbCurrency.Items.Contains("AUD"))
            {
                CmbCurrency.Text = "AUD";
            }
        }

        //---- the sold date --------------------------------------------------------

        //Sold Date belongs to a purchase that has been marked sold; nothing else shows it
        private void Show_Sold_Date()
        {
            bool Visible = chkSold.Checked;

            Label12.Visible = Visible;
            CmbSoldDD.Visible = Visible;
            CmbSoldMM.Visible = Visible;
            CmbSoldYear.Visible = Visible;
            CmdSoldCal.Visible = Visible;
        }

        private void Reset_Sold_Date()
        {
            CmbSoldDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbSoldMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbSoldYear.Text = String.Format("{0:yyyy}", DateTime.Now);
        }

        private void chkSold_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //unticking discards the date rather than keeping it hidden
            if (!chkSold.Checked)
            {
                Reset_Sold_Date();
            }
            Show_Sold_Date();
        }

        //Null unless this purchase is marked sold
        private string Get_Sold_Date()
        {
            if (!chkSold.Checked)
            {
                return null;
            }
            return CmbSoldYear.Text + CmbSoldMM.Text + CmbSoldDD.Text;
        }

        private void Set_Sold_Date(string parYyyyMMdd)
        {
            if (parYyyyMMdd == null || parYyyyMMdd.Trim().Length != 8)
            {
                Reset_Sold_Date();
                return;
            }
            CmbSoldYear.Text = parYyyyMMdd.Substring(0, 4);
            CmbSoldMM.Text = parYyyyMMdd.Substring(4, 2);
            CmbSoldDD.Text = parYyyyMMdd.Substring(6, 2);
        }

        private void CmdSoldCal_Click(object sender, EventArgs e)
        {
            CalTarget = "SOLD";
            monthCalendar1.SetDate(new System.DateTime(int.Parse(CmbSoldYear.Text), int.Parse(CmbSoldMM.Text), int.Parse(CmbSoldDD.Text), 0, 0, 0, 0));
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        //---- the transaction date -------------------------------------------------

        //Date in the same yyyyMMdd form every other table uses
        private string Get_Trans_Date()
        {
            return CmbYear.Text + CmbMM.Text + CmbDD.Text;
        }

        private void ChangeLblDay()
        {
            switch (DateTime.Parse(Mdl1.toLongDate(Get_Trans_Date())).DayOfWeek)
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
                Clear_Entry();
                Get_Data();
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
            CalTarget = "TRANS";
            monthCalendar1.SetDate(new System.DateTime(int.Parse(CmbYear.Text), int.Parse(CmbMM.Text), int.Parse(CmbDD.Text), 0, 0, 0, 0));
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Hide();

            if (CalTarget == "SOLD")
            {
                CmbSoldDD.Text = e.Start.Day.ToString("00");
                CmbSoldMM.Text = e.Start.Month.ToString("00");
                CmbSoldYear.Text = e.Start.Year.ToString("0000");
                return;
            }

            FirstLoad = true;
            CmbDD.Text = e.Start.Day.ToString("00");
            CmbMM.Text = e.Start.Month.ToString("00");
            CmbYear.Text = e.Start.Year.ToString("0000");
            FirstLoad = false;
            DateChanged();
        }

        //---- the table ------------------------------------------------------------

        //Only purchases live on this page, so there is no Type column and none of the
        //selling columns that used to sit here showing nothing but a dash.
        private void Clear_Grid()
        {
            gvPurchase.Columns.Clear();
            gvPurchase.ColumnCount = 14;
            string[] names = new string[] { "Portfolio Code", "Full Ticker", "Currency", "Unit", "Original Cost Base", "Cost Base", "Fee", "Original Total Cost Base", "Total Cost Base", "Real Total Cost Base", "Reinvestment", "Sold", "Sold Date", "Sale Id" };
            int[] weights = new int[] { 7, 9, 6, 8, 10, 8, 5, 11, 9, 10, 8, 4, 8, 17 };
            for (int i = 0; i < 14; i++)
            {
                gvPurchase.Columns[i].Name = names[i];
                gvPurchase.Columns[i].FillWeight = weights[i];
                if (i >= 3 && i <= 9)
                {
                    gvPurchase.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvPurchase.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    gvPurchase.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gvPurchase.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private string Select_Purchases()
        {
            return "select Trans_Date, Full_Ticker, [Currency], Unit, [Original_Cost_Base], Cost_Base, Fee, [Original_Total_Cost_Base], Total_Cost_Base, Real_Total_Cost_Base, Is_Sold, [Portfolio_Code], [Sold_Date], [Sale_Id] from TblETFStocksPurchase"
                 + " where Trans_Date = '" + Get_Trans_Date() + "' order by Full_Ticker";
        }

        private void Get_Data()
        {
            Filling = true;
            RowSelected = false;

            Clear_Grid();

            Mdl1.Ssql = Select_Purchases();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                double TmpRealTotal = Read_Double(reader["Real_Total_Cost_Base"]);
                gvPurchase.Rows.Add(new string[] {
                    reader["Portfolio_Code"].ToString().Trim(),
                    reader["Full_Ticker"].ToString().Trim(),
                    reader["Currency"].ToString().Trim(),
                    Format_Unit(reader["Unit"]),
                    Mdl1.FormatAmt(Read_Double(reader["Original_Cost_Base"])),
                    Mdl1.FormatAmt(Read_Double(reader["Cost_Base"])),
                    Mdl1.FormatAmt(Read_Double(reader["Fee"])),
                    Mdl1.FormatAmt(Read_Double(reader["Original_Total_Cost_Base"])),
                    Mdl1.FormatAmt(Read_Double(reader["Total_Cost_Base"])),
                    Mdl1.FormatAmt(TmpRealTotal),
                    (TmpRealTotal == 0 ? "Y" : "N"),
                    (reader["Is_Sold"].ToString().Trim() == "True" ? "Y" : "N"),
                    Format_Sold_Date(reader["Sold_Date"]),
                    (reader["Sale_Id"] == DBNull.Value ? "" : reader["Sale_Id"].ToString().Trim())
                });
            }
            reader.Close();

            gvPurchase.ClearSelection();
            Filling = false;
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

        //Sold_Date is stored yyyyMMdd like every other date; the grid shows it the way the
        //rest of the app shows a date.  A lot that has not been sold has none.
        private string Format_Sold_Date(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return "";
            }
            string TmpText = parValue.ToString().Trim();
            DateTime TmpDate;
            if (DateTime.TryParseExact(TmpText, "yyyyMMdd", new CultureInfo("en-AU"),
                                       DateTimeStyles.None, out TmpDate))
            {
                return TmpDate.ToString("dd-MMM-yyyy", new CultureInfo("en-AU"));
            }
            return TmpText;
        }

        private string Format_Unit(object parValue)
        {
            return Read_Double(parValue).ToString("#,##0.0000");
        }

        //---- the entry area -------------------------------------------------------

        private void Clear_Entry()
        {
            Filling = true;
            RowSelected = false;
            Set_Default_Currency();
            if (CmbFullTicker.Items.Count > 0)
            {
                CmbFullTicker.Text = CmbFullTicker.Items[0].ToString();
            }
            txtUnit.Text = "0.0000";
            txtOriginalCostBase.Text = "0.00";
            txtCostBase.Text = "0.00";
            txtFee.Text = "0.00";
            chkDRIP.Checked = false;
            chkSold.Checked = false;
            Reset_Sold_Date();
            Set_Default_Flag();
            Filling = false;
            Show_Sold_Date();
            Calculate_Totals();
        }

        //Total Cost Base          = round(Unit x Cost Base, 2) + Fee
        //Original Total Cost Base = round(Unit x Original Cost Base, 2) + Fee
        //Reinvestment zeroes the real total, because a reinvested lot cost no new money.
        private void Calculate_Totals()
        {
            double TmpUnit;
            double TmpCostBase;
            double TmpOriginalCostBase;
            double TmpFee;

            double.TryParse(txtUnit.Text.Trim(), out TmpUnit);
            double.TryParse(txtCostBase.Text.Trim(), out TmpCostBase);
            double.TryParse(txtOriginalCostBase.Text.Trim(), out TmpOriginalCostBase);
            double.TryParse(txtFee.Text.Trim(), out TmpFee);

            txtOriginalTotalCostBase.Text = Mdl1.FormatAmt(
                Math.Round(Math.Round(TmpUnit * TmpOriginalCostBase, 2) + TmpFee, 2));

            double TmpTotal = Math.Round(Math.Round(TmpUnit * TmpCostBase, 2) + TmpFee, 2);
            txtTotalCostBase.Text = Mdl1.FormatAmt(TmpTotal);
            if (chkDRIP.Checked)
            {
                txtRealTotalCostBase.Text = Mdl1.FormatAmt(0);
            }
            else
            {
                txtRealTotalCostBase.Text = Mdl1.FormatAmt(TmpTotal);
            }
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Calculate_Totals();
        }

        private void chkDRIP_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Calculate_Totals();
        }

        private void CheckKeyPress(KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtOriginalCostBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtCostBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        //---- picking a row --------------------------------------------------------

        private void gvPurchase_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //SelectionChanged fires while CurrentRow can still be pointing at the row being
            //left, so the selection itself is asked which row it is.
            DataGridViewRow Row = null;
            if (gvPurchase.SelectedRows.Count > 0)
            {
                Row = gvPurchase.SelectedRows[0];
            }
            else
            {
                Row = gvPurchase.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            int Ord = Row.Index;
            if (Ord < 0)
            {
                return;
            }

            //Re-read from the table so the originals are exact, not display-rounded
            Mdl1.Ssql = Select_Purchases();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            bool Found = false;
            while (reader.Read())
            {
                if (i == Ord)
                {
                    OrgTransDate = reader["Trans_Date"].ToString().Trim();
                    OrgFullTicker = reader["Full_Ticker"].ToString().Trim();
                    OrgCurrency = reader["Currency"].ToString().Trim();
                    OrgUnit = Sql_Num(reader["Unit"], 4);
                    OrgOriginalCostBase = Sql_Num(reader["Original_Cost_Base"], 2);
                    OrgOriginalTotalCostBase = Sql_Num(reader["Original_Total_Cost_Base"], 2);
                    OrgCostBase = Sql_Num(reader["Cost_Base"], 2);
                    OrgFee = Sql_Num(reader["Fee"], 2);
                    OrgTotalCostBase = Sql_Num(reader["Total_Cost_Base"], 2);
                    OrgRealTotalCostBase = Sql_Num(reader["Real_Total_Cost_Base"], 2);
                    OrgIsSold = (reader["Is_Sold"].ToString().Trim() == "True" ? "True" : "False");
                    OrgFlagCode = (reader["Portfolio_Code"] == DBNull.Value ? null : reader["Portfolio_Code"].ToString().Trim());
                    OrgSoldDate = (reader["Sold_Date"] == DBNull.Value ? null : reader["Sold_Date"].ToString().Trim());
                    OrgSaleId = (reader["Sale_Id"] == DBNull.Value ? null : reader["Sale_Id"].ToString().Trim());
                    if (OrgSaleId == "")
                    {
                        OrgSaleId = null;
                    }
                    if (OrgSoldDate == "")
                    {
                        OrgSoldDate = null;
                    }
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
            CmbFullTicker.Text = OrgFullTicker;
            CmbCurrency.Text = OrgCurrency;
            txtUnit.Text = (OrgUnit == null ? "0.0000" : OrgUnit);
            txtOriginalCostBase.Text = (OrgOriginalCostBase == null ? "0.00" : OrgOriginalCostBase);
            txtCostBase.Text = (OrgCostBase == null ? "0.00" : OrgCostBase);
            txtFee.Text = (OrgFee == null ? "0.00" : OrgFee);
            chkDRIP.Checked = (Read_Double(OrgRealTotalCostBase) == 0);
            chkSold.Checked = (OrgIsSold == "True");
            Set_Sold_Date(OrgSoldDate);
            if (OrgFlagCode != null && CmbFlagCode.Items.Contains(OrgFlagCode))
            {
                CmbFlagCode.Text = OrgFlagCode;
                Show_Portfolio_Description();
            }
            else
            {
                Set_Default_Flag();
            }
            Filling = false;

            Show_Sold_Date();
            RowSelected = true;
            Calculate_Totals();
        }

        //---- validation and SQL helpers -------------------------------------------

        //Culture-independent literal for SQL, at the scale the column stores.
        //Returns null when the stored value is Null.
        private string Sql_Num(object parValue, int parDecimals)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return null;
            }
            double TmpValue;
            if (!double.TryParse(parValue.ToString(), out TmpValue))
            {
                return null;
            }
            return Math.Round(TmpValue, parDecimals).ToString("0." + new string('0', parDecimals), CultureInfo.InvariantCulture);
        }

        private bool Valid_Amount(string parText, int parDecimals, string parField, out decimal parValue)
        {
            parValue = 0;
            string TmpText = (parText == null ? "" : parText.Trim());
            if (TmpText == "")
            {
                MessageBox.Show(parField + " must be filled !", "Error Message");
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
            if (TmpDot >= 0 && TmpPlain.Length - TmpDot - 1 > parDecimals)
            {
                MessageBox.Show(parField + " cannot have more than " + parDecimals.ToString() + " decimal places !", "Error Message");
                return false;
            }
            return true;
        }

        private bool Validate_Entry(out decimal parUnit, out decimal parCostBase, out decimal parFee,
                                    out decimal parTotal, out decimal parRealTotal,
                                    out decimal parOriginalCostBase, out decimal parOriginalTotal)
        {
            parUnit = 0;
            parOriginalCostBase = 0;
            parOriginalTotal = 0;
            parCostBase = 0;
            parFee = 0;
            parTotal = 0;
            parRealTotal = 0;

            if (CmbFullTicker.Text.Trim() == "")
            {
                MessageBox.Show("Full Ticker must be selected ! Please set one up first in ETF/Stock Setup.", "Error Message");
                return false;
            }
            if (CmbCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Currency must be selected !", "Error Message");
                return false;
            }
            if (!Valid_Amount(txtUnit.Text, 4, "Unit", out parUnit))
            {
                return false;
            }
            if (!Valid_Amount(txtOriginalCostBase.Text, 2, "Original Cost Base", out parOriginalCostBase))
            {
                return false;
            }
            if (!Valid_Amount(txtCostBase.Text, 2, "Cost Base", out parCostBase))
            {
                return false;
            }
            if (!Valid_Amount(txtFee.Text, 2, "Fee", out parFee))
            {
                return false;
            }

            parOriginalTotal = Math.Round(Math.Round(parUnit * parOriginalCostBase, 2) + parFee, 2);
            parTotal = Math.Round(Math.Round(parUnit * parCostBase, 2) + parFee, 2);
            parRealTotal = (chkDRIP.Checked ? 0 : parTotal);
            return true;
        }

        private string Sql_Sold_Date()
        {
            string TmpDate = Get_Sold_Date();
            if (TmpDate == null)
            {
                return "Null";
            }
            return "'" + TmpDate + "'";
        }

        private string Num(decimal parValue, int parDecimals)
        {
            return parValue.ToString("0." + new string('0', parDecimals), CultureInfo.InvariantCulture);
        }

        private string Where_Col(string parCol, string parValue)
        {
            if (parValue == null)
            {
                return " and " + parCol + " Is Null";
            }
            return " and " + parCol + " = " + parValue;
        }

        //Without a key the row is found again by every value it was read with
        private string Where_Original()
        {
            return " where Trans_Date = '" + OrgTransDate + "'"
                 + " and Full_Ticker = '" + OrgFullTicker + "'"
                 + " and [Currency] = '" + OrgCurrency + "'"
                 + Where_Col("Unit", OrgUnit)
                 + Where_Col("[Original_Cost_Base]", OrgOriginalCostBase)
                 + Where_Col("Cost_Base", OrgCostBase)
                 + Where_Col("Fee", OrgFee)
                 + Where_Col("[Original_Total_Cost_Base]", OrgOriginalTotalCostBase)
                 + Where_Col("Total_Cost_Base", OrgTotalCostBase)
                 + Where_Col("Real_Total_Cost_Base", OrgRealTotalCostBase)
                 + " and Is_Sold = " + OrgIsSold
                 + (OrgFlagCode == null ? " and [Portfolio_Code] Is Null" : " and [Portfolio_Code] = '" + OrgFlagCode + "'")
                 + (OrgSoldDate == null ? " and [Sold_Date] Is Null" : " and [Sold_Date] = '" + OrgSoldDate + "'")
                 + (OrgSaleId == null ? " and [Sale_Id] Is Null" : " and [Sale_Id] = '" + OrgSaleId + "'");
        }

        //Without a key, identical rows are indistinguishable - warn before touching them all
        private bool Confirm_Affected(string parAction)
        {
            int TmpCount = 0;
            Mdl1.Ssql = "select count(*) as N from TblETFStocksPurchase" + Where_Original();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpCount = int.Parse(reader["N"].ToString());
            }
            reader.Close();

            if (TmpCount == 0)
            {
                MessageBox.Show("The selected purchase could no longer be found.", "Error Message");
                return false;
            }
            if (TmpCount > 1)
            {
                DialogResult Response = MessageBox.Show(TmpCount.ToString() + " identical purchases exist for this date. " + parAction + " will affect all " + TmpCount.ToString() + " of them. Continue ?", "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        //---- add, update, delete --------------------------------------------------

        private void Insert_Current(decimal parUnit, decimal parCostBase, decimal parFee,
                                    decimal parTotal, decimal parRealTotal,
                                    decimal parOriginalCostBase, decimal parOriginalTotal)
        {
            Mdl1.Ssql = "Insert into TblETFStocksPurchase (Trans_Date, Full_Ticker, [Currency], Unit, [Original_Cost_Base], Cost_Base, Fee, [Original_Total_Cost_Base], Total_Cost_Base, Real_Total_Cost_Base, Is_Sold, [Portfolio_Code], [Sold_Date]) values ("
                + "'" + Get_Trans_Date() + "', "
                + "'" + CmbFullTicker.Text.Trim() + "', "
                + "'" + CmbCurrency.Text.Trim() + "', "
                + Num(parUnit, 4) + ", "
                + Num(parOriginalCostBase, 2) + ", "
                + Num(parCostBase, 2) + ", "
                + Num(parFee, 2) + ", "
                + Num(parOriginalTotal, 2) + ", "
                + Num(parTotal, 2) + ", "
                + Num(parRealTotal, 2) + ", "
                + (chkSold.Checked ? "True" : "False") + ", "
                + "'" + CmbFlagCode.Text.Trim() + "', "
                + Sql_Sold_Date() + ")";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            cmd.ExecuteNonQuery();
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpUnit;
                decimal TmpCostBase;
                decimal TmpOriginalCostBase;
                decimal TmpOriginalTotal;
                decimal TmpFee;
                decimal TmpTotal;
                decimal TmpRealTotal;

                if (!Validate_Entry(out TmpUnit, out TmpCostBase, out TmpFee, out TmpTotal, out TmpRealTotal, out TmpOriginalCostBase, out TmpOriginalTotal))
                {
                    return;
                }

                Insert_Current(TmpUnit, TmpCostBase, TmpFee, TmpTotal, TmpRealTotal, TmpOriginalCostBase, TmpOriginalTotal);

                MessageBox.Show("Create successfully for " + CmbFullTicker.Text.Trim() + " on " + Mdl1.toLongDate(Get_Trans_Date()), "Success");

                Get_Data();
                Clear_Entry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpUnit;
                decimal TmpCostBase;
                decimal TmpOriginalCostBase;
                decimal TmpOriginalTotal;
                decimal TmpFee;
                decimal TmpTotal;
                decimal TmpRealTotal;

                if (!RowSelected)
                {
                    MessageBox.Show("Please select a purchase from the list first !", "Error Message");
                    return;
                }
                if (!Validate_Entry(out TmpUnit, out TmpCostBase, out TmpFee, out TmpTotal, out TmpRealTotal, out TmpOriginalCostBase, out TmpOriginalTotal))
                {
                    return;
                }
                if (!Confirm_Affected("Update"))
                {
                    return;
                }

                Mdl1.Ssql = "Update TblETFStocksPurchase set "
                    + "Full_Ticker = '" + CmbFullTicker.Text.Trim() + "', "
                    + "[Currency] = '" + CmbCurrency.Text.Trim() + "', "
                    + "Unit = " + Num(TmpUnit, 4) + ", "
                    + "[Original_Cost_Base] = " + Num(TmpOriginalCostBase, 2) + ", "
                    + "Cost_Base = " + Num(TmpCostBase, 2) + ", "
                    + "Fee = " + Num(TmpFee, 2) + ", "
                    + "[Original_Total_Cost_Base] = " + Num(TmpOriginalTotal, 2) + ", "
                    + "Total_Cost_Base = " + Num(TmpTotal, 2) + ", "
                    + "Real_Total_Cost_Base = " + Num(TmpRealTotal, 2) + ", "
                    + "Is_Sold = " + (chkSold.Checked ? "True" : "False") + ", "
                    + "[Portfolio_Code] = '" + CmbFlagCode.Text.Trim() + "', "
                    + "[Sold_Date] = " + Sql_Sold_Date()
                    + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + CmbFullTicker.Text.Trim() + " on " + Mdl1.toLongDate(Get_Trans_Date()), "Success");

                Get_Data();
                Clear_Entry();
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
                    MessageBox.Show("Please select a purchase from the list first !", "Error Message");
                    return;
                }
                if (!Confirm_Affected("Delete"))
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksPurchase" + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + OrgFullTicker + " on " + Mdl1.toLongDate(Get_Trans_Date()), "Success");

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
