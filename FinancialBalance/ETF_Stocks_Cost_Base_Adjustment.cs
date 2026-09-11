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
    public partial class ETF_Stocks_Cost_Base_Adjustment : Form
    {
        bool Filling;

        //The filter dropdown shows portfolio descriptions but the table stores codes, so the
        //codes run alongside the items.  A null entry is the "All" row.
        List<string> FilterPortfolioCodes = new List<string>();

        //TblETFStocksCostBaseAdjustment has no key, so a row is identified by the values it held
        //when it was picked out of the grid.
        bool RowSelected;
        string OrgFinYear;
        string OrgPortfolioCode;
        string OrgFullTicker;
        string OrgCurrency;
        string OrgAdjType;
        string OrgAdjustment;

        //Every purchase row on offer, kept exactly as it was read so the update can find it
        //again in a table that has no key.
        List<string[]> LotRows = new List<string[]>();

        //Set once an adjustment has been spread over the rows currently listed.  Those rows
        //are the before picture from then on, and no longer match what is stored, so a second
        //press would match nothing and quietly report no work done.
        bool Recalculated;

        public ETF_Stocks_Cost_Base_Adjustment()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Cost_Base_Adjustment_Load(object sender, EventArgs e)
        {
            Filling = true;
            Clear_Adj_Grid();
            Clear_Lots_Grid(gvLots);
            Clear_Lots_Grid(gvResult);
            Fill_Financial_Year(CmbFilterFinYear, false);
            Fill_Filter_Portfolio();
            Fill_Ticker(CmbFilterTicker, false);
            Fill_Financial_Year(CmbFinYear, true);
            Fill_Portfolio_Code();
            Fill_Ticker(CmbTicker, true);
            Mdl1.Fill_Curr(CmbCurrency);
            Set_Default_Currency();
            Fill_Adj_Type();
            Filling = false;

            Clear_Entry();
            Get_Data();
        }

        //---- the menu -------------------------------------------------------------

        private void MnPropertyPurchase_Click(object sender, EventArgs e)
        {
            Property_Purchase Property_Purchase = new Property_Purchase();
            Property_Purchase.Show();
            this.Close();
        }

        private void MnPropertySetup_Click(object sender, EventArgs e)
        {
            Setup_Property Setup_Property = new Setup_Property();
            Setup_Property.Show();
            this.Close();
        }

        private void MnSuperProcess_Click(object sender, EventArgs e)
        {
            Super_Financial_Year Super_Financial_Year = new Super_Financial_Year();
            Super_Financial_Year.Show();
            this.Close();
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

        private void MnETFStocksInvestment_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Investment ETF_Stocks_Investment = new ETF_Stocks_Investment();
            ETF_Stocks_Investment.Show();
            this.Close();
        }

        private void MnETFStocksPurchase_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Purchase ETF_Stocks_Purchase = new ETF_Stocks_Purchase();
            ETF_Stocks_Purchase.Show();
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

        //---- filling the dropdowns ------------------------------------------------

        //Most recently closed year first.  The filter row carries an All entry; the entry row
        //does not, because a stored adjustment always belongs to one year.
        private void Fill_Financial_Year(ComboBox parCombo, bool parEntry)
        {
            parCombo.Items.Clear();
            if (!parEntry)
            {
                parCombo.Items.Add("All");
            }

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                parCombo.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            if (parCombo.Items.Count > 0)
            {
                parCombo.SelectedIndex = 0;
            }
        }

        private void Fill_Filter_Portfolio()
        {
            CmbFilterPortfolio.Items.Clear();
            FilterPortfolioCodes.Clear();
            CmbFilterPortfolio.Items.Add("All");
            FilterPortfolioCodes.Add(null);

            Mdl1.Ssql = "select Portfolio_Code, [Description] from TblETFStocksPortfolioCode order by Portfolio_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = reader["Portfolio_Code"].ToString().Trim();
                string TmpDesc = reader["Description"].ToString().Trim();
                CmbFilterPortfolio.Items.Add(TmpDesc == "" ? TmpCode : TmpDesc);
                FilterPortfolioCodes.Add(TmpCode);
            }
            reader.Close();
            CmbFilterPortfolio.Text = "All";
        }

        private void Fill_Portfolio_Code()
        {
            CmbPortfolioCode.Items.Clear();
            Mdl1.Ssql = "select Portfolio_Code from TblETFStocksPortfolioCode order by Portfolio_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbPortfolioCode.Items.Add(reader["Portfolio_Code"].ToString().Trim());
            }
            reader.Close();
            if (CmbPortfolioCode.Items.Count > 0)
            {
                CmbPortfolioCode.SelectedIndex = 0;
            }
        }

        private void Fill_Ticker(ComboBox parCombo, bool parEntry)
        {
            parCombo.Items.Clear();
            if (!parEntry)
            {
                parCombo.Items.Add("All");
            }

            Mdl1.Ssql = "select Full_Ticker from TblETFStocks order by Full_Ticker";
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

        private void Fill_Adj_Type()
        {
            CmbAdjType.Items.Clear();
            CmbAdjType.Items.Add("+");
            CmbAdjType.Items.Add("-");
            CmbAdjType.Text = "+";
        }

        //Fill_Curr defaults to IDR for the accounting pages; ETF trades default to AUD
        private void Set_Default_Currency()
        {
            if (CmbCurrency.Items.Contains("AUD"))
            {
                CmbCurrency.Text = "AUD";
            }
        }

        //---- formatting -----------------------------------------------------------

        //AUD and USD carry a dollar sign; any other currency stays bare, and a negative reads
        //-$12.34 rather than $-12.34.
        private bool Is_Dollar(string parCurr)
        {
            if (parCurr == null)
            {
                return false;
            }
            string TmpCurr = parCurr.Trim().ToUpper();
            return (TmpCurr == "AUD" || TmpCurr == "USD");
        }

        private string Money(double parValue, string parCurr)
        {
            if (!Is_Dollar(parCurr))
            {
                return Mdl1.FormatAmt(parValue);
            }
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        private double Read_Double(object parValue)
        {
            double TmpValue;
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            if (double.TryParse(parValue.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out TmpValue))
            {
                return TmpValue;
            }
            if (double.TryParse(parValue.ToString(), out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        private string Read_Text(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return "";
            }
            return parValue.ToString().Trim();
        }

        //yyyyMMdd as the rest of the app shows a date; blank when there is none
        private string Format_Date(string parYyyyMMdd)
        {
            if (parYyyyMMdd == null || parYyyyMMdd.Trim() == "")
            {
                return "";
            }
            DateTime TmpDate;
            if (DateTime.TryParseExact(parYyyyMMdd.Trim(), "yyyyMMdd", new CultureInfo("en-AU"),
                                       DateTimeStyles.None, out TmpDate))
            {
                return TmpDate.ToString("dd-MMM-yyyy", new CultureInfo("en-AU"));
            }
            return parYyyyMMdd.Trim();
        }

        //Culture-independent literal for SQL, at the scale the column stores
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

        private string Num(double parValue, int parDecimals)
        {
            return Math.Round(parValue, parDecimals).ToString("0." + new string('0', parDecimals), CultureInfo.InvariantCulture);
        }

        private string Where_Col(string parCol, string parValue)
        {
            if (parValue == null)
            {
                return " and " + parCol + " Is Null";
            }
            return " and " + parCol + " = " + parValue;
        }

        private string Where_Text(string parCol, string parValue)
        {
            if (parValue == null || parValue == "")
            {
                return " and " + parCol + " Is Null";
            }
            return " and " + parCol + " = '" + parValue + "'";
        }

        //---- the adjustment table -------------------------------------------------

        private void Clear_Adj_Grid()
        {
            gvAdj.Rows.Clear();
            gvAdj.Columns.Clear();
            gvAdj.ColumnCount = 6;
            string[] names = new string[] { "Financial Year", "Portfolio_Code", "Full Ticker",
                                            "Currency", "Adjustment Type", "Adjustment" };
            int[] weights = new int[] { 18, 16, 20, 12, 16, 18 };
            for (int i = 0; i < 6; i++)
            {
                gvAdj.Columns[i].Name = names[i];
                gvAdj.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign =
                    (i == 5 ? DataGridViewContentAlignment.MiddleRight : DataGridViewContentAlignment.MiddleCenter);
                gvAdj.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvAdj.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private string Filter_Portfolio_Code()
        {
            int idx = CmbFilterPortfolio.SelectedIndex;
            if (idx < 0 || idx >= FilterPortfolioCodes.Count)
            {
                return null;
            }
            return FilterPortfolioCodes[idx];
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Adj_Grid();
                RowSelected = false;

                string TmpYear = CmbFilterFinYear.Text.Trim();
                string TmpCode = Filter_Portfolio_Code();
                string TmpTicker = CmbFilterTicker.Text.Trim();

                Mdl1.Ssql = "select [Financial_Year], [Portfolio_Code], [Full_Ticker], [Currency],"
                          + " [Adjustment_Type], [Adjustment] from TblETFStocksCostBaseAdjustment"
                          + " where 1 = 1"
                          + (TmpYear == "" || TmpYear == "All" ? "" : " and [Financial_Year] = '" + TmpYear + "'")
                          + (TmpCode == null ? "" : " and [Portfolio_Code] = '" + TmpCode + "'")
                          + (TmpTicker == "" || TmpTicker == "All" ? "" : " and [Full_Ticker] = '" + TmpTicker + "'")
                          + " order by [Financial_Year], [Portfolio_Code], [Full_Ticker]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string TmpCurr = Read_Text(reader["Currency"]);
                    gvAdj.Rows.Add(new string[] {
                        Read_Text(reader["Financial_Year"]),
                        Read_Text(reader["Portfolio_Code"]),
                        Read_Text(reader["Full_Ticker"]),
                        TmpCurr,
                        Read_Text(reader["Adjustment_Type"]),
                        Money(Read_Double(reader["Adjustment"]), TmpCurr) });
                }
                reader.Close();

                gvAdj.ClearSelection();
                Filling = false;
                Show_Note();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Show_Note()
        {
            LblNote.Text = gvAdj.Rows.Count.ToString() + " adjustment(s)";
        }

        private void gvAdj_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //SelectionChanged fires while CurrentRow can still be pointing at the row being left
            DataGridViewRow Row = null;
            if (gvAdj.SelectedRows.Count > 0)
            {
                Row = gvAdj.SelectedRows[0];
            }
            else
            {
                Row = gvAdj.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            int Ord = Row.Index;
            Mdl1.Ssql = "select [Financial_Year], [Portfolio_Code], [Full_Ticker], [Currency],"
                      + " [Adjustment_Type], [Adjustment] from TblETFStocksCostBaseAdjustment"
                      + " where 1 = 1"
                      + (CmbFilterFinYear.Text.Trim() == "" || CmbFilterFinYear.Text.Trim() == "All" ? "" : " and [Financial_Year] = '" + CmbFilterFinYear.Text.Trim() + "'")
                      + (Filter_Portfolio_Code() == null ? "" : " and [Portfolio_Code] = '" + Filter_Portfolio_Code() + "'")
                      + (CmbFilterTicker.Text.Trim() == "" || CmbFilterTicker.Text.Trim() == "All" ? "" : " and [Full_Ticker] = '" + CmbFilterTicker.Text.Trim() + "'")
                      + " order by [Financial_Year], [Portfolio_Code], [Full_Ticker]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            bool Found = false;
            while (reader.Read())
            {
                if (i == Ord)
                {
                    OrgFinYear = Read_Text(reader["Financial_Year"]);
                    OrgPortfolioCode = Read_Text(reader["Portfolio_Code"]);
                    OrgFullTicker = Read_Text(reader["Full_Ticker"]);
                    OrgCurrency = Read_Text(reader["Currency"]);
                    OrgAdjType = Read_Text(reader["Adjustment_Type"]);
                    OrgAdjustment = Sql_Num(reader["Adjustment"], 2);
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
            if (CmbFinYear.Items.Contains(OrgFinYear)) { CmbFinYear.Text = OrgFinYear; }
            if (CmbPortfolioCode.Items.Contains(OrgPortfolioCode)) { CmbPortfolioCode.Text = OrgPortfolioCode; }
            if (CmbTicker.Items.Contains(OrgFullTicker)) { CmbTicker.Text = OrgFullTicker; }
            if (CmbCurrency.Items.Contains(OrgCurrency)) { CmbCurrency.Text = OrgCurrency; }
            if (CmbAdjType.Items.Contains(OrgAdjType)) { CmbAdjType.Text = OrgAdjType; }
            txtAdjustment.Text = (OrgAdjustment == null ? "0.00" : OrgAdjustment);
            Filling = false;

            Show_Portfolio_Description();
            RowSelected = true;
            Load_Lots();
        }

        //---- the entry area -------------------------------------------------------

        private void Clear_Entry()
        {
            Filling = true;
            RowSelected = false;
            if (CmbFinYear.Items.Count > 0) { CmbFinYear.SelectedIndex = 0; }
            if (CmbPortfolioCode.Items.Count > 0) { CmbPortfolioCode.SelectedIndex = 0; }
            if (CmbTicker.Items.Count > 0) { CmbTicker.SelectedIndex = 0; }
            Set_Default_Currency();
            CmbAdjType.Text = "+";
            txtAdjustment.Text = "0.00";
            Filling = false;

            Show_Portfolio_Description();
            Load_Lots();
            Clear_Lots_Grid(gvResult);
        }

        private void Show_Portfolio_Description()
        {
            string TmpCode = CmbPortfolioCode.Text.Trim();
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
                TmpDesc = Read_Text(reader["Description"]);
            }
            reader.Close();
            LblPortfolioDesc.Text = (TmpDesc == "" ? "-" : TmpDesc);
        }

        //Financial Year, Portfolio Code and Full Ticker all decide which lots are on offer
        private void Entry_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Portfolio_Description();
            Load_Lots();
        }

        //Currency and Adjustment Type change nothing but the record itself
        private void Currency_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Lot_Totals();
        }

        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        private void Adjustment_TextChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Lot_Totals();
        }

        //---- the purchases the adjustment applies to ------------------------------

        private void Clear_Lots_Grid(DataGridView parGrid)
        {
            parGrid.Rows.Clear();
            parGrid.Columns.Clear();
            parGrid.ColumnCount = 7;
            string[] names = new string[] { "Purchase Date", "Unit", "Cost Base/Unit",
                                            "Total Cost Base", "Real Total Cost Base",
                                            "Sold Date", "Sale Id" };
            int[] weights = new int[] { 12, 10, 13, 14, 15, 12, 24 };
            for (int i = 0; i < 7; i++)
            {
                parGrid.Columns[i].Name = names[i];
                parGrid.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign =
                    (i >= 1 && i <= 4 ? DataGridViewContentAlignment.MiddleRight : DataGridViewContentAlignment.MiddleLeft);
                parGrid.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                parGrid.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        //The year's two dates, or false when the year cannot be found
        private bool Year_Range(string parName, out string parStart, out string parEnd)
        {
            parStart = "";
            parEnd = "";
            if (parName == null || parName.Trim() == "")
            {
                return false;
            }
            Mdl1.Ssql = "select [Start_Date], [End_Date] from TblFinancialYear where [Name] = '" + parName.Trim() + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = false;
            if (reader.Read())
            {
                parStart = Read_Text(reader["Start_Date"]);
                parEnd = Read_Text(reader["End_Date"]);
                Found = (parStart != "" && parEnd != "");
            }
            reader.Close();
            return Found;
        }

        //Everything of that ticker, in that portfolio, bought on or before the year's end that is
        //either still held or was sold inside the year - the lots the year's cost base rests on.
        private string Select_Lots(string parStart, string parEnd)
        {
            return "select Trans_Date, Full_Ticker, [Currency], Unit, [Original_Cost_Base], Cost_Base, Fee,"
                 + " [Original_Total_Cost_Base], Total_Cost_Base, Real_Total_Cost_Base, Is_Sold,"
                 + " [Portfolio_Code], [Sold_Date], [Sale_Id] from TblETFStocksPurchase"
                 + " where Trans_Date <= '" + parEnd + "'"
                 + " and Full_Ticker = '" + CmbTicker.Text.Trim() + "'"
                 + " and [Portfolio_Code] = '" + CmbPortfolioCode.Text.Trim() + "'"
                 + " and (Is_Sold = False or (Is_Sold = True and [Sold_Date] >= '" + parStart + "'"
                 + " and [Sold_Date] <= '" + parEnd + "'))"
                 + " order by Trans_Date";
        }

        //Reads the lots the current selection covers.  Used twice: once for the table above the
        //button, and again afterwards for the result table.
        private void Read_Lots(List<string[]> parRows)
        {
            parRows.Clear();

            string TmpStart;
            string TmpEnd;
            if (!Year_Range(CmbFinYear.Text, out TmpStart, out TmpEnd)
                || CmbTicker.Text.Trim() == "" || CmbPortfolioCode.Text.Trim() == "")
            {
                return;
            }

            Mdl1.Ssql = Select_Lots(TmpStart, TmpEnd);
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //the whole row, kept as read, so the update can find it again
                parRows.Add(new string[] {
                    Read_Text(reader["Trans_Date"]),
                    Read_Text(reader["Full_Ticker"]),
                    Read_Text(reader["Currency"]),
                    Sql_Num(reader["Unit"], 4),
                    Sql_Num(reader["Original_Cost_Base"], 2),
                    Sql_Num(reader["Cost_Base"], 2),
                    Sql_Num(reader["Fee"], 2),
                    Sql_Num(reader["Original_Total_Cost_Base"], 2),
                    Sql_Num(reader["Total_Cost_Base"], 2),
                    Sql_Num(reader["Real_Total_Cost_Base"], 2),
                    (Read_Text(reader["Is_Sold"]) == "True" ? "True" : "False"),
                    Read_Text(reader["Portfolio_Code"]),
                    Read_Text(reader["Sold_Date"]),
                    Read_Text(reader["Sale_Id"]) });
            }
            reader.Close();
        }

        //The "before" table.  Reloading it also clears the result table and the applied flag,
        //because a different selection is a different question.
        private void Load_Lots()
        {
            try
            {
                Clear_Lots_Grid(gvLots);
                Clear_Lots_Grid(gvResult);
                Recalculated = false;

                Read_Lots(LotRows);
                Fill_Lots_Grid(gvLots, LotRows);
                Show_Lot_Totals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //The "after" table, read fresh so it shows what is now stored.  The table above is left
        //exactly as it was, so the two can be read side by side.
        private void Load_Result()
        {
            List<string[]> TmpRows = new List<string[]>();
            Read_Lots(TmpRows);
            Fill_Lots_Grid(gvResult, TmpRows);
        }

        private void Fill_Lots_Grid(DataGridView parGrid, List<string[]> parRows)
        {
            Clear_Lots_Grid(parGrid);
            for (int i = 0; i < parRows.Count; i++)
            {
                string[] o = parRows[i];
                parGrid.Rows.Add(new string[] {
                    Format_Date(o[0]),
                    Read_Double(o[3]).ToString("#,##0.0000"),
                    Money(Read_Double(o[5]), o[2]),
                    Money(Read_Double(o[8]), o[2]),
                    Money(Read_Double(o[9]), o[2]),
                    Format_Date(o[12]),
                    o[13] });
            }
            parGrid.ClearSelection();
        }

        //Total Unit is what the adjustment is spread over, so the per-unit figure follows it
        private void Show_Lot_Totals()
        {
            double TmpUnits = 0;
            for (int i = 0; i < LotRows.Count; i++)
            {
                TmpUnits += Read_Double(LotRows[i][3]);
            }
            TmpUnits = Math.Round(TmpUnits, 4);
            LblTotalUnit.Text = TmpUnits.ToString("#,##0.0000");

            double TmpAdjustment;
            double.TryParse(txtAdjustment.Text.Trim(), out TmpAdjustment);

            //nothing to spread it over means nothing per unit, rather than a divide by zero
            double TmpPerUnit = (TmpUnits > 0 ? Math.Round(TmpAdjustment / TmpUnits, 2) : 0);

            Filling = true;
            txtCalcCostBase.Text = Num(TmpPerUnit, 2);
            Filling = false;
        }

        //---- recalculating --------------------------------------------------------

        //Finds one purchase row again by every value it was read with, the table having no key
        private string Lot_Where(string[] o)
        {
            return " where Trans_Date = '" + o[0] + "'"
                 + " and Full_Ticker = '" + o[1] + "'"
                 + Where_Text("[Currency]", o[2])
                 + Where_Col("Unit", o[3])
                 + Where_Col("[Original_Cost_Base]", o[4])
                 + Where_Col("Cost_Base", o[5])
                 + Where_Col("Fee", o[6])
                 + Where_Col("[Original_Total_Cost_Base]", o[7])
                 + Where_Col("Total_Cost_Base", o[8])
                 + Where_Col("Real_Total_Cost_Base", o[9])
                 + " and Is_Sold = " + o[10]
                 + Where_Text("[Portfolio_Code]", o[11])
                 + Where_Text("[Sold_Date]", o[12])
                 + Where_Text("[Sale_Id]", o[13]);
        }

        private void CmdRecalc_Click(object sender, EventArgs e)
        {
            try
            {
                if (LotRows.Count == 0)
                {
                    MessageBox.Show("There are no purchases to recalculate for this year, portfolio and ticker.", "Error Message");
                    return;
                }

                if (Recalculated)
                {
                    MessageBox.Show("This adjustment has already been applied to the purchases listed above."
                        + Environment.NewLine + Environment.NewLine
                        + "That table is now the before picture and no longer matches what is stored, so it "
                        + "cannot be applied again from here. Re-choose the Financial Year, Portfolio Code or "
                        + "Full Ticker to read the current figures.", "Error Message");
                    return;
                }

                double TmpPerUnit;
                if (!double.TryParse(txtCalcCostBase.Text.Trim(), out TmpPerUnit))
                {
                    MessageBox.Show("Calculated Cost Base/Unit must be a number !", "Error Message");
                    return;
                }

                string TmpSign = CmbAdjType.Text.Trim();
                if (TmpSign != "+" && TmpSign != "-")
                {
                    MessageBox.Show("Adjustment Type must be + or - !", "Error Message");
                    return;
                }

                //This rewrites the stored cost base of real purchase rows and cannot be undone,
                //so it says exactly what it is about to do before doing it.
                DialogResult Response = MessageBox.Show(
                    "This will " + (TmpSign == "+" ? "add " : "subtract ") + Num(Math.Abs(TmpPerUnit), 2)
                    + " per unit " + (TmpSign == "+" ? "to" : "from") + " the Cost Base of "
                    + LotRows.Count.ToString() + " purchase row(s) of " + CmbTicker.Text.Trim()
                    + " in portfolio " + CmbPortfolioCode.Text.Trim() + ", and restate their totals."
                    + Environment.NewLine + Environment.NewLine
                    + "It changes stored purchases and cannot be undone. Continue ?",
                    "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return;
                }

                int TmpDone = 0;
                for (int i = 0; i < LotRows.Count; i++)
                {
                    string[] o = LotRows[i];
                    double TmpUnit = Read_Double(o[3]);
                    double TmpCostBase = Read_Double(o[5]);
                    double TmpFee = Read_Double(o[6]);
                    double TmpRealTotal = Read_Double(o[9]);

                    double NewCostBase = Math.Round(TmpSign == "+" ? TmpCostBase + TmpPerUnit
                                                                   : TmpCostBase - TmpPerUnit, 2);
                    //the lot's own fee still belongs in its total, exactly as it does everywhere
                    //else the total is worked out
                    double NewTotal = Math.Round(Math.Round(TmpUnit * NewCostBase, 2) + TmpFee, 2);
                    //a lot bought with no real money stays at nothing; anything else follows the total
                    double NewReal = (TmpRealTotal == 0 ? 0 : NewTotal);

                    Mdl1.Ssql = "Update TblETFStocksPurchase set "
                              + "Cost_Base = " + Num(NewCostBase, 2) + ", "
                              + "Total_Cost_Base = " + Num(NewTotal, 2) + ", "
                              + "Real_Total_Cost_Base = " + Num(NewReal, 2)
                              + Lot_Where(o);
                    OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    TmpDone += cmd.ExecuteNonQuery();
                }

                MessageBox.Show(TmpDone.ToString() + " purchase row(s) recalculated.", "Success");

                //Only the result table is re-read.  The table above keeps the figures the
                //adjustment started from, so before and after sit one above the other.
                Recalculated = true;
                Load_Result();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- add, update, delete --------------------------------------------------

        private bool Validate_Entry(out double parAdjustment)
        {
            parAdjustment = 0;
            if (CmbFinYear.Text.Trim() == "")
            {
                MessageBox.Show("Financial Year must be selected ! Please set one up first in Financial Year Setup.", "Error Message");
                return false;
            }
            if (CmbPortfolioCode.Text.Trim() == "")
            {
                MessageBox.Show("Portfolio Code must be selected !", "Error Message");
                return false;
            }
            if (CmbTicker.Text.Trim() == "")
            {
                MessageBox.Show("Full Ticker must be selected !", "Error Message");
                return false;
            }
            if (CmbCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Currency must be selected !", "Error Message");
                return false;
            }
            if (CmbAdjType.Text.Trim() != "+" && CmbAdjType.Text.Trim() != "-")
            {
                MessageBox.Show("Adjustment Type must be + or - !", "Error Message");
                return false;
            }

            string TmpText = txtAdjustment.Text.Trim();
            if (TmpText == "")
            {
                MessageBox.Show("Adjustment must be filled !", "Error Message");
                return false;
            }
            if (!double.TryParse(TmpText, out parAdjustment))
            {
                MessageBox.Show("Adjustment must be a number !", "Error Message");
                return false;
            }
            if (parAdjustment < 0)
            {
                MessageBox.Show("Adjustment cannot be negative ! Use the Adjustment Type to take it away.", "Error Message");
                return false;
            }
            string TmpPlain = TmpText.Replace(",", "");
            int TmpDot = TmpPlain.IndexOf('.');
            if (TmpDot >= 0 && TmpPlain.Length - TmpDot - 1 > 2)
            {
                MessageBox.Show("Adjustment cannot have more than 2 decimal places !", "Error Message");
                return false;
            }
            return true;
        }

        private string Where_Original()
        {
            return " where [Financial_Year] = '" + OrgFinYear + "'"
                 + Where_Text("[Portfolio_Code]", OrgPortfolioCode)
                 + Where_Text("[Full_Ticker]", OrgFullTicker)
                 + Where_Text("[Currency]", OrgCurrency)
                 + Where_Text("[Adjustment_Type]", OrgAdjType)
                 + Where_Col("[Adjustment]", OrgAdjustment);
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                double TmpAdjustment;
                if (!Validate_Entry(out TmpAdjustment))
                {
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksCostBaseAdjustment ([Financial_Year], [Portfolio_Code],"
                          + " [Full_Ticker], [Currency], [Adjustment_Type], [Adjustment]) values ("
                          + "'" + CmbFinYear.Text.Trim() + "', "
                          + "'" + CmbPortfolioCode.Text.Trim() + "', "
                          + "'" + CmbTicker.Text.Trim() + "', "
                          + "'" + CmbCurrency.Text.Trim() + "', "
                          + "'" + CmbAdjType.Text.Trim() + "', "
                          + Num(TmpAdjustment, 2) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + CmbTicker.Text.Trim(), "Success");
                Get_Data();
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
                if (!RowSelected)
                {
                    MessageBox.Show("Please select an adjustment from the list first !", "Error Message");
                    return;
                }
                double TmpAdjustment;
                if (!Validate_Entry(out TmpAdjustment))
                {
                    return;
                }

                Mdl1.Ssql = "Update TblETFStocksCostBaseAdjustment set "
                          + "[Financial_Year] = '" + CmbFinYear.Text.Trim() + "', "
                          + "[Portfolio_Code] = '" + CmbPortfolioCode.Text.Trim() + "', "
                          + "[Full_Ticker] = '" + CmbTicker.Text.Trim() + "', "
                          + "[Currency] = '" + CmbCurrency.Text.Trim() + "', "
                          + "[Adjustment_Type] = '" + CmbAdjType.Text.Trim() + "', "
                          + "[Adjustment] = " + Num(TmpAdjustment, 2)
                          + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + CmbTicker.Text.Trim(), "Success");
                Get_Data();
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
                    MessageBox.Show("Please select an adjustment from the list first !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksCostBaseAdjustment" + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + OrgFullTicker, "Success");
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
