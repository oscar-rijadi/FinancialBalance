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
    public partial class ETF_Stocks_Transaction : Form
    {
        bool FirstLoad;
        bool Filling;

        //Buys live in TblETFStocksPurchase, sells in TblETFStocksSale.  The grid shows both,
        //so each grid row remembers which table it came from and its position within it.
        List<string> RowSource = new List<string>();
        List<int> RowOrdinal = new List<int>();

        //Neither table has a primary key, so a row is identified by the values it held when
        //it was picked out of the grid.  A null entry means the column was Null.
        bool RowSelected;
        string OrgSource;
        string OrgTransDate;
        string OrgFullTicker;
        string OrgCurrency;
        string OrgUnit;
        string OrgCostBase;
        string OrgFee;
        string OrgTotalCostBase;
        string OrgRealTotalCostBase;
        string OrgIsSold;
        string OrgFlagCode;
        string OrgSoldDate;

        //one MonthCalendar serves both date pickers
        string CalTarget = "TRANS";
        string OrgSellingPricePerUnit;
        string OrgSellingTotalAmount;

        public ETF_Stocks_Transaction()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Transaction_Load(object sender, EventArgs e)
        {
            FirstLoad = true;
            Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            Mdl1.Fill_Date(CmbSoldDD, CmbSoldMM, CmbSoldYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

            Filling = true;
            CmbTransType.Items.Clear();
            CmbTransType.Items.Add("Buy");
            CmbTransType.Items.Add("Sell");
            CmbTransType.Text = "Buy";
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

        //A Buy captures cost; a Sell captures proceeds.  Only one set applies at a time.
        private bool Is_Sell()
        {
            return (CmbTransType.Text.Trim() == "Sell");
        }

        private string Cur_Table()
        {
            return (Is_Sell() ? "TblETFStocksSale" : "TblETFStocksPurchase");
        }

        private string Org_Table()
        {
            return (OrgSource == "S" ? "TblETFStocksSale" : "TblETFStocksPurchase");
        }

        private void Show_Fields_For_Type()
        {
            bool Sell = Is_Sell();

            //Buy-only inputs
            Label5.Visible = !Sell;
            txtCostBase.Visible = !Sell;
            Label6.Visible = !Sell;
            txtFee.Visible = !Sell;
            Label7.Visible = !Sell;
            txtTotalCostBase.Visible = !Sell;
            Label8.Visible = !Sell;
            txtRealTotalCostBase.Visible = !Sell;
            chkDRIP.Visible = !Sell;
            chkSold.Visible = !Sell;
            Label11.Visible = !Sell;
            CmbFlagCode.Visible = !Sell;
            Show_Sold_Date();

            //Sell-only inputs
            Label9.Visible = Sell;
            txtSellingPricePerUnit.Visible = Sell;
            Label10.Visible = Sell;
            txtSellingTotalAmount.Visible = Sell;

            //a Sell is built from the lots being sold, so Unit is derived rather than typed
            LblLots.Visible = Sell;
            gvLots.Visible = Sell;
            txtUnit.ReadOnly = Sell;
            txtUnit.BackColor = (Sell ? System.Drawing.SystemColors.Control : System.Drawing.SystemColors.Window);
        }

        private void Apply_Trans_Type_Rules()
        {
            Show_Fields_For_Type();

            //whatever is hidden is not captured, so reset it rather than carry it over
            if (Is_Sell())
            {
                chkDRIP.Checked = false;
                chkSold.Checked = false;
                Reset_Sold_Date();
                txtCostBase.Text = "0.00";
                txtFee.Text = "0.00";
            }
            else
            {
                txtSellingPricePerUnit.Text = "0.00";
            }
        }

        private void CmbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Apply_Trans_Type_Rules();
            Load_Lots();
            //the reset above changes what the derived boxes should read
            Calculate_Totals();
        }

        private void CmbFullTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Load_Lots();
        }

        //Purchases default to the OB flag
        private void Set_Default_Flag()
        {
            if (CmbFlagCode.Items.Contains("OB"))
            {
                CmbFlagCode.Text = "OB";
            }
        }

        //Sold Date belongs to a Buy that has been marked sold; nothing else shows it
        private void Show_Sold_Date()
        {
            bool Visible = (!Is_Sell() && chkSold.Checked);

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

        //Null unless this is a Buy that is marked sold
        private string Get_Sold_Date()
        {
            if (Is_Sell() || !chkSold.Checked)
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

        //Fill_Curr defaults to IDR for the accounting pages; ETF trades default to AUD
        private void Set_Default_Currency()
        {
            if (CmbCurrency.Items.Contains("AUD"))
            {
                CmbCurrency.Text = "AUD";
            }
        }

        //Date in the same yyyyMMdd form every other table uses
        private string Get_Trans_Date()
        {
            return CmbYear.Text + CmbMM.Text + CmbDD.Text;
        }

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

        private void Clear_Grid()
        {
            gvTrans.Columns.Clear();
            gvTrans.ColumnCount = 13;
            string[] names = new string[] { "Type", "Full Ticker", "Currency", "Unit", "Cost Base", "Fee", "Total Cost Base", "Real Total Cost Base", "DRIP", "Sold", "Flag", "Selling Price/Unit", "Selling Total Amount" };
            int[] weights = new int[] { 5, 9, 6, 8, 8, 5, 9, 10, 5, 5, 5, 9, 11 };
            for (int i = 0; i < 13; i++)
            {
                gvTrans.Columns[i].Name = names[i];
                gvTrans.Columns[i].FillWeight = weights[i];
                if ((i >= 3 && i <= 7) || i >= 11)
                {
                    gvTrans.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvTrans.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    gvTrans.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gvTrans.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private string Select_Purchases()
        {
            return "select Trans_Date, Full_Ticker, [Currency], Unit, Cost_Base, Fee, Total_Cost_Base, Real_Total_Cost_Base, Is_Sold, [Portfolio_Code], [Sold_Date] from TblETFStocksPurchase"
                 + " where Trans_Date = '" + Get_Trans_Date() + "' order by Full_Ticker";
        }

        private string Select_Sales()
        {
            return "select Trans_Date, Full_Ticker, [Currency], Unit, [Selling_Price_Per_Unit], [Selling_Total_Amount] from TblETFStocksSale"
                 + " where Trans_Date = '" + Get_Trans_Date() + "' order by Full_Ticker";
        }

        private void Get_Data()
        {
            Filling = true;
            RowSelected = false;
            RowSource.Clear();
            RowOrdinal.Clear();

            Clear_Grid();

            string[] row;

            //purchases first, then sales
            Mdl1.Ssql = Select_Purchases();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                double TmpRealTotal = Read_Double(reader["Real_Total_Cost_Base"]);
                row = new string[] {
                    "Buy",
                    reader["Full_Ticker"].ToString().Trim(),
                    reader["Currency"].ToString().Trim(),
                    Format_Unit(reader["Unit"]),
                    Mdl1.FormatAmt(Read_Double(reader["Cost_Base"])),
                    Mdl1.FormatAmt(Read_Double(reader["Fee"])),
                    Mdl1.FormatAmt(Read_Double(reader["Total_Cost_Base"])),
                    Mdl1.FormatAmt(TmpRealTotal),
                    (TmpRealTotal == 0 ? "Y" : "N"),
                    (reader["Is_Sold"].ToString().Trim() == "True" ? "Y" : "N"),
                    reader["Portfolio_Code"].ToString().Trim(),
                    "-",
                    "-"
                };
                gvTrans.Rows.Add(row);
                RowSource.Add("P");
                RowOrdinal.Add(i);
                i++;
            }
            reader.Close();

            Mdl1.Ssql = Select_Sales();
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            i = 0;
            while (reader.Read())
            {
                row = new string[] {
                    "Sell",
                    reader["Full_Ticker"].ToString().Trim(),
                    reader["Currency"].ToString().Trim(),
                    Format_Unit(reader["Unit"]),
                    "-",
                    "-",
                    "-",
                    "-",
                    "-",
                    "-",
                    "-",
                    Mdl1.FormatAmt(Read_Double(reader["Selling_Price_Per_Unit"])),
                    Mdl1.FormatAmt(Read_Double(reader["Selling_Total_Amount"]))
                };
                gvTrans.Rows.Add(row);
                RowSource.Add("S");
                RowOrdinal.Add(i);
                i++;
            }
            reader.Close();

            gvTrans.ClearSelection();

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

        private string Format_Unit(object parValue)
        {
            return Read_Double(parValue).ToString("#,##0.0000");
        }

        private void Clear_Entry()
        {
            Filling = true;
            RowSelected = false;
            CmbTransType.Text = "Buy";
            Set_Default_Currency();
            if (CmbFullTicker.Items.Count > 0)
            {
                CmbFullTicker.Text = CmbFullTicker.Items[0].ToString();
            }
            txtUnit.Text = "0.0000";
            txtCostBase.Text = "0.00";
            txtFee.Text = "0.00";
            txtSellingPricePerUnit.Text = "0.00";
            chkDRIP.Checked = false;
            chkSold.Checked = false;
            Reset_Sold_Date();
            Set_Default_Flag();
            Filling = false;
            Apply_Trans_Type_Rules();
            Load_Lots();
            Calculate_Totals();
        }

        //Buy  : Total = round(Unit x Cost Base, 2) + Fee, and DRIP zeroes the real total
        //Sell : Selling Total Amount = round(Unit x Selling Price/Unit, 2)
        private void Calculate_Totals()
        {
            double TmpUnit;
            double TmpCostBase;
            double TmpFee;
            double TmpSellingPrice;

            double.TryParse(txtUnit.Text.Trim(), out TmpUnit);
            double.TryParse(txtCostBase.Text.Trim(), out TmpCostBase);
            double.TryParse(txtFee.Text.Trim(), out TmpFee);
            double.TryParse(txtSellingPricePerUnit.Text.Trim(), out TmpSellingPrice);

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

            txtSellingTotalAmount.Text = Mdl1.FormatAmt(Math.Round(TmpUnit * TmpSellingPrice, 2));
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

        private void txtCostBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtSellingPricePerUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void gvTrans_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            if (gvTrans.CurrentRow == null || gvTrans.CurrentRow.Cells[0].Value == null)
            {
                return;
            }

            int idx = gvTrans.CurrentRow.Index;
            if (idx < 0 || idx >= RowSource.Count)
            {
                return;
            }

            string Src = RowSource[idx];
            int Ord = RowOrdinal[idx];

            //Re-read from the owning table so the originals are exact, not display-rounded
            Mdl1.Ssql = (Src == "P" ? Select_Purchases() : Select_Sales());
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            bool Found = false;
            while (reader.Read())
            {
                if (i == Ord)
                {
                    OrgSource = Src;
                    OrgTransDate = reader["Trans_Date"].ToString().Trim();
                    OrgFullTicker = reader["Full_Ticker"].ToString().Trim();
                    OrgCurrency = reader["Currency"].ToString().Trim();
                    OrgUnit = Sql_Num(reader["Unit"], 4);
                    if (Src == "P")
                    {
                        OrgCostBase = Sql_Num(reader["Cost_Base"], 2);
                        OrgFee = Sql_Num(reader["Fee"], 2);
                        OrgTotalCostBase = Sql_Num(reader["Total_Cost_Base"], 2);
                        OrgRealTotalCostBase = Sql_Num(reader["Real_Total_Cost_Base"], 2);
                        OrgIsSold = (reader["Is_Sold"].ToString().Trim() == "True" ? "True" : "False");
                        OrgFlagCode = (reader["Portfolio_Code"] == DBNull.Value ? null : reader["Portfolio_Code"].ToString().Trim());
                        OrgSoldDate = (reader["Sold_Date"] == DBNull.Value ? null : reader["Sold_Date"].ToString().Trim());
                        if (OrgSoldDate == "")
                        {
                            OrgSoldDate = null;
                        }
                    }
                    else
                    {
                        OrgSellingPricePerUnit = Sql_Num(reader["Selling_Price_Per_Unit"], 2);
                        OrgSellingTotalAmount = Sql_Num(reader["Selling_Total_Amount"], 2);
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
            CmbTransType.Text = (Src == "P" ? "Buy" : "Sell");
            CmbFullTicker.Text = OrgFullTicker;
            CmbCurrency.Text = OrgCurrency;
            txtUnit.Text = (OrgUnit == null ? "0.0000" : OrgUnit);
            if (Src == "P")
            {
                txtCostBase.Text = (OrgCostBase == null ? "0.00" : OrgCostBase);
                txtFee.Text = (OrgFee == null ? "0.00" : OrgFee);
                txtSellingPricePerUnit.Text = "0.00";
                chkDRIP.Checked = (Read_Double(OrgRealTotalCostBase) == 0);
                chkSold.Checked = (OrgIsSold == "True");
                Set_Sold_Date(OrgSoldDate);
                if (OrgFlagCode != null && CmbFlagCode.Items.Contains(OrgFlagCode))
                {
                    CmbFlagCode.Text = OrgFlagCode;
                }
                else
                {
                    Set_Default_Flag();
                }
            }
            else
            {
                txtCostBase.Text = "0.00";
                txtFee.Text = "0.00";
                txtSellingPricePerUnit.Text = (OrgSellingPricePerUnit == null ? "0.00" : OrgSellingPricePerUnit);
                chkDRIP.Checked = false;
                chkSold.Checked = false;
                Reset_Sold_Date();
                Set_Default_Flag();
            }
            Filling = false;

            //show the half of the form this row's type uses, without wiping what was just loaded
            Show_Fields_For_Type();

            RowSelected = true;
            Calculate_Totals();
        }

        private void Clear_Lots_Grid()
        {
            gvLots.Rows.Clear();
            gvLots.Columns.Clear();
            gvLots.ColumnCount = 5;
            string[] names = new string[] { "Purchase Date", "Unit", "Purchase Price / Unit",
                                            "Real Purchase Amount", "Sold Unit" };
            int[] weights = new int[] { 20, 18, 22, 22, 18 };
            for (int i = 0; i < 5; i++)
            {
                gvLots.Columns[i].Name = names[i];
                gvLots.Columns[i].FillWeight = weights[i];
                gvLots.Columns[i].ReadOnly = (i < 4);
                if (i == 0)
                {
                    gvLots.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    gvLots.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    gvLots.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvLots.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        //Each row keeps the values it was read with, because the purchase table has no key
        //and the update has to find exactly this lot again.
        private void Load_Lots()
        {
            if (!Is_Sell())
            {
                gvLots.Rows.Clear();
                return;
            }

            try
            {
                Filling = true;
                Clear_Lots_Grid();

                string TmpTicker = CmbFullTicker.Text.Trim();
                if (TmpTicker != "")
                {
                    Mdl1.Ssql = "select Trans_Date, Full_Ticker, [Currency], Unit, Cost_Base, Fee,"
                              + " Total_Cost_Base, Real_Total_Cost_Base, [Portfolio_Code]"
                              + " from TblETFStocksPurchase where Is_Sold = False and Full_Ticker = '"
                              + TmpTicker + "' order by Trans_Date";
                    OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    List<string[]> Lots = new List<string[]>();
                    while (reader.Read())
                    {
                        Lots.Add(new string[] {
                            reader["Trans_Date"].ToString().Trim(),
                            reader["Full_Ticker"].ToString().Trim(),
                            reader["Currency"].ToString().Trim(),
                            Sql_Num(reader["Unit"], 4),
                            Sql_Num(reader["Cost_Base"], 2),
                            Sql_Num(reader["Fee"], 2),
                            Sql_Num(reader["Total_Cost_Base"], 2),
                            Sql_Num(reader["Real_Total_Cost_Base"], 2),
                            (reader["Portfolio_Code"] == DBNull.Value ? null : reader["Portfolio_Code"].ToString().Trim())
                        });
                    }
                    reader.Close();

                    for (int i = 0; i < Lots.Count; i++)
                    {
                        double TmpUnit = Read_Double(Lots[i][3]);
                        gvLots.Rows.Add(new string[] {
                            Format_Purchase_Date(Lots[i][0]),
                            TmpUnit.ToString("#,##0.0000"),
                            Mdl1.FormatAmt(Read_Double(Lots[i][4])),
                            Mdl1.FormatAmt(Read_Double(Lots[i][7])),
                            "0.0000" });
                        gvLots.Rows[gvLots.Rows.Count - 1].Tag = Lots[i];
                    }
                }

                gvLots.ClearSelection();
                Filling = false;
                Sum_Sold_Units();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private string Format_Purchase_Date(string parYyyyMMdd)
        {
            DateTime TmpDate;
            if (DateTime.TryParseExact(parYyyyMMdd, "yyyyMMdd", new CultureInfo("en-AU"),
                                       DateTimeStyles.None, out TmpDate))
            {
                return TmpDate.ToString("dd-MMM-yyyy", new CultureInfo("en-AU"));
            }
            return parYyyyMMdd;
        }

        private double Read_Double(string parText)
        {
            double TmpValue;
            if (parText != null && double.TryParse(parText, NumberStyles.Number, CultureInfo.InvariantCulture, out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        private double Lot_Unit(int parRow)
        {
            string[] o = (string[])gvLots.Rows[parRow].Tag;
            return Read_Double(o[3]);
        }

        private double Sold_Unit(int parRow)
        {
            object v = gvLots.Rows[parRow].Cells[4].Value;
            double d;
            if (v == null || !double.TryParse(v.ToString().Trim(), out d))
            {
                return 0;
            }
            return d;
        }

        //Unit on a Sell is the sum of what is being taken from each lot
        private void Sum_Sold_Units()
        {
            double Tot = 0;
            for (int i = 0; i < gvLots.Rows.Count; i++)
            {
                Tot += Sold_Unit(i);
            }
            Filling = true;
            txtUnit.Text = Tot.ToString("0.0000");
            Filling = false;
            Calculate_Totals();
        }

        //Digits and a decimal point only, the same filter the amount boxes use
        private void gvLots_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox box = e.Control as TextBox;
            if (box == null)
            {
                return;
            }
            box.KeyPress -= new KeyPressEventHandler(Lot_KeyPress);
            if (gvLots.CurrentCell != null && gvLots.CurrentCell.ColumnIndex == 4)
            {
                box.KeyPress += new KeyPressEventHandler(Lot_KeyPress);
            }
        }

        private void Lot_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void gvLots_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Filling || e.ColumnIndex != 4)
            {
                return;
            }

            object v = gvLots.Rows[e.RowIndex].Cells[4].Value;
            string s = (v == null ? "" : v.ToString().Trim());
            double d;

            if (s == "")
            {
                d = 0;
            }
            else if (!double.TryParse(s, out d))
            {
                MessageBox.Show("Sold Unit must be a number !", "Error Message");
                d = 0;
            }
            else if (d < 0)
            {
                MessageBox.Show("Sold Unit cannot be negative !", "Error Message");
                d = 0;
            }
            else
            {
                string TmpPlain = s.Replace(",", "");
                int TmpDot = TmpPlain.IndexOf('.');
                if (TmpDot >= 0 && (TmpPlain.Length - TmpDot - 1) > 4)
                {
                    MessageBox.Show("Sold Unit can have a maximum of 4 decimal points !", "Error Message");
                    d = Math.Round(d, 4);
                }
            }

            double TmpMax = Lot_Unit(e.RowIndex);
            if (d > TmpMax)
            {
                MessageBox.Show("Sold Unit cannot be more than the " + TmpMax.ToString("#,##0.0000")
                    + " unit(s) held in that purchase !", "Error Message");
                d = TmpMax;
            }

            Filling = true;
            gvLots.Rows[e.RowIndex].Cells[4].Value = d.ToString("0.0000");
            Filling = false;

            Sum_Sold_Units();
        }

        //What the units being sold originally cost, totalled over the lots they come from.
        //
        //Deliberately mirrors the arithmetic in Apply_Sale_To_Lots below - the closed part of
        //a lot carries the whole of that lot's fee, and the same rounding is applied at the
        //same points - so the profit recorded against a sale always agrees with the cost the
        //settlement leaves behind on the purchase rows.
        //
        //parPaperCost counts every lot.  parRealCost skips lots bought with no real money
        //(Real_Total_Cost_Base of 0, which is how a DRIP is held), because those units cost
        //nothing and so all of their proceeds are real profit.
        private void Sale_Cost_Of_Units(out double parPaperCost, out double parRealCost)
        {
            parPaperCost = 0;
            parRealCost = 0;

            for (int i = 0; i < gvLots.Rows.Count; i++)
            {
                double TmpSold = Sold_Unit(i);
                if (TmpSold <= 0)
                {
                    continue;
                }

                string[] o = (string[])gvLots.Rows[i].Tag;
                double TmpCost = Read_Double(o[4]);
                double TmpFee = Read_Double(o[5]);
                bool RealWasZero = (Read_Double(o[7]) == 0);

                double SoldTotal = Math.Round(Math.Round(TmpSold * TmpCost, 2) + TmpFee, 2);

                parPaperCost += SoldTotal;
                parRealCost += (RealWasZero ? 0 : SoldTotal);
            }

            parPaperCost = Math.Round(parPaperCost, 2);
            parRealCost = Math.Round(parRealCost, 2);
        }

        //A Sell closes the units it takes and leaves the remainder open.  A lot sold in
        //full is simply closed; a lot sold in part is split into a closed row for the
        //units sold and a new open row for what is left.
        private void Apply_Sale_To_Lots(string parSoldDate)
        {
            for (int i = 0; i < gvLots.Rows.Count; i++)
            {
                double TmpSold = Sold_Unit(i);
                if (TmpSold <= 0)
                {
                    continue;
                }

                string[] o = (string[])gvLots.Rows[i].Tag;
                string OrgDate = o[0];
                string OrgTicker = o[1];
                string OrgCurr = o[2];
                string OrgUnit = o[3];
                string OrgCost = o[4];
                string OrgFee = o[5];
                string OrgTotal = o[6];
                string OrgReal = o[7];
                string OrgCode = o[8];

                string Where = " where Trans_Date = '" + OrgDate + "'"
                             + " and Full_Ticker = '" + OrgTicker + "'"
                             + " and [Currency] = '" + OrgCurr + "'"
                             + " and Unit = " + OrgUnit
                             + " and Cost_Base = " + OrgCost
                             + " and Fee = " + OrgFee
                             + " and Total_Cost_Base = " + OrgTotal
                             + " and Real_Total_Cost_Base = " + OrgReal
                             + " and Is_Sold = False"
                             + (OrgCode == null ? " and [Portfolio_Code] Is Null" : " and [Portfolio_Code] = '" + OrgCode + "'");

                double TmpLotUnit = Read_Double(OrgUnit);
                double TmpCost = Read_Double(OrgCost);
                double TmpFee = Read_Double(OrgFee);
                bool RealWasZero = (Read_Double(OrgReal) == 0);

                OleDbCommand cmd;

                if (Math.Abs(TmpSold - TmpLotUnit) < 0.00005)
                {
                    //sold in full - close it as it stands
                    Mdl1.Ssql = "Update TblETFStocksPurchase set Is_Sold = True, [Sold_Date] = '" + parSoldDate + "'" + Where;
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                    continue;
                }

                //the closed part keeps the original fee
                double SoldTotal = Math.Round(Math.Round(TmpSold * TmpCost, 2) + TmpFee, 2);
                double SoldReal = (RealWasZero ? 0 : SoldTotal);

                Mdl1.Ssql = "Update TblETFStocksPurchase set "
                          + "Unit = " + TmpSold.ToString("0.0000", CultureInfo.InvariantCulture) + ", "
                          + "Total_Cost_Base = " + SoldTotal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "Real_Total_Cost_Base = " + SoldReal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "Is_Sold = True, [Sold_Date] = '" + parSoldDate + "'"
                          + Where;
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                //the remainder carries on as a new open lot, with no fee of its own
                double RestUnit = Math.Round(TmpLotUnit - TmpSold, 4);
                double RestTotal = Math.Round(RestUnit * TmpCost, 2);
                double RestReal = (RealWasZero ? 0 : RestTotal);

                Mdl1.Ssql = "Insert into TblETFStocksPurchase (Trans_Date, Full_Ticker, [Currency], Unit, Cost_Base, Fee,"
                          + " Total_Cost_Base, Real_Total_Cost_Base, Is_Sold, [Portfolio_Code], [Sold_Date]) values ("
                          + "'" + OrgDate + "', '" + OrgTicker + "', '" + OrgCurr + "', "
                          + RestUnit.ToString("0.0000", CultureInfo.InvariantCulture) + ", "
                          + TmpCost.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "0.00, "
                          + RestTotal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + RestReal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "False, "
                          + (OrgCode == null ? "Null" : "'" + OrgCode + "'") + ", Null)";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();
            }
        }

        //Culture-independent literal for SQL, at the scale the column stores.
        //Returns null when the stored value is Null.
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

        //Only the fields on show for the current type are captured
        private bool Validate_Entry(out decimal parUnit, out decimal parCostBase, out decimal parFee,
                                    out decimal parTotal, out decimal parRealTotal,
                                    out decimal parSellingPrice, out decimal parSellingTotal)
        {
            parUnit = 0;
            parCostBase = 0;
            parFee = 0;
            parTotal = 0;
            parRealTotal = 0;
            parSellingPrice = 0;
            parSellingTotal = 0;

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

            if (Is_Sell())
            {
                if (parUnit <= 0)
                {
                    MessageBox.Show("Enter the units being sold against one or more purchases first !", "Error Message");
                    return false;
                }
                if (!Valid_Amount(txtSellingPricePerUnit.Text, 2, "Selling Price/Unit", out parSellingPrice))
                {
                    return false;
                }
                parSellingTotal = Math.Round(parUnit * parSellingPrice, 2);
            }
            else
            {
                if (!Valid_Amount(txtCostBase.Text, 2, "Cost Base", out parCostBase))
                {
                    return false;
                }
                if (!Valid_Amount(txtFee.Text, 2, "Fee", out parFee))
                {
                    return false;
                }
                parTotal = Math.Round(Math.Round(parUnit * parCostBase, 2) + parFee, 2);
                parRealTotal = (chkDRIP.Checked ? 0 : parTotal);
            }
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

        //Access stores Yes/No True as -1, so a WHERE must compare against True/False,
        //never 1/0 - "Is_Sold = 1" silently matches nothing
        private string Where_Original()
        {
            string Where = " where Trans_Date = '" + OrgTransDate + "'"
                         + " and Full_Ticker = '" + OrgFullTicker + "'"
                         + " and [Currency] = '" + OrgCurrency + "'"
                         + Where_Col("Unit", OrgUnit);

            if (OrgSource == "P")
            {
                Where += Where_Col("Cost_Base", OrgCostBase)
                       + Where_Col("Fee", OrgFee)
                       + Where_Col("Total_Cost_Base", OrgTotalCostBase)
                       + Where_Col("Real_Total_Cost_Base", OrgRealTotalCostBase)
                       + " and Is_Sold = " + OrgIsSold
                       + (OrgFlagCode == null ? " and [Portfolio_Code] Is Null" : " and [Portfolio_Code] = '" + OrgFlagCode + "'")
                       + (OrgSoldDate == null ? " and [Sold_Date] Is Null" : " and [Sold_Date] = '" + OrgSoldDate + "'");
            }
            else
            {
                Where += Where_Col("[Selling_Price_Per_Unit]", OrgSellingPricePerUnit)
                       + Where_Col("[Selling_Total_Amount]", OrgSellingTotalAmount);
            }
            return Where;
        }

        //Without a key, identical rows are indistinguishable - warn before touching them all
        private bool Confirm_Affected(string parAction)
        {
            int TmpCount = 0;
            Mdl1.Ssql = "select count(*) as N from " + Org_Table() + Where_Original();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpCount = int.Parse(reader["N"].ToString());
            }
            reader.Close();

            if (TmpCount == 0)
            {
                MessageBox.Show("The selected transaction could no longer be found.", "Error Message");
                return false;
            }
            if (TmpCount > 1)
            {
                DialogResult Response = MessageBox.Show(TmpCount.ToString() + " identical transactions exist for this date. " + parAction + " will affect all " + TmpCount.ToString() + " of them. Continue ?", "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        //Insert the entry area into whichever table matches the current type
        private void Insert_Current(decimal parUnit, decimal parCostBase, decimal parFee,
                                    decimal parTotal, decimal parRealTotal,
                                    decimal parSellingPrice, decimal parSellingTotal)
        {
            if (Is_Sell())
            {
                //worked out from the lots on screen, which is why this runs before
                //Apply_Sale_To_Lots settles them away
                double TmpPaperCost;
                double TmpRealCost;
                Sale_Cost_Of_Units(out TmpPaperCost, out TmpRealCost);

                double TmpSellingTotal = (double)parSellingTotal;
                double TmpPaperProfit = Math.Round(TmpSellingTotal - TmpPaperCost, 2);
                double TmpRealProfit = Math.Round(TmpSellingTotal - TmpRealCost, 2);

                Mdl1.Ssql = "Insert into TblETFStocksSale (Trans_Date, Full_Ticker, [Currency], Unit, [Selling_Price_Per_Unit], [Selling_Total_Amount], [Profit_Or_Loss_On_Paper], [Real_Profit_Or_Loss]) values ("
                    + "'" + Get_Trans_Date() + "', "
                    + "'" + CmbFullTicker.Text.Trim() + "', "
                    + "'" + CmbCurrency.Text.Trim() + "', "
                    + Num(parUnit, 4) + ", "
                    + Num(parSellingPrice, 2) + ", "
                    + Num(parSellingTotal, 2) + ", "
                    + TmpPaperProfit.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                    + TmpRealProfit.ToString("0.00", CultureInfo.InvariantCulture) + ")";
            }
            else
            {
                Mdl1.Ssql = "Insert into TblETFStocksPurchase (Trans_Date, Full_Ticker, [Currency], Unit, Cost_Base, Fee, Total_Cost_Base, Real_Total_Cost_Base, Is_Sold, [Portfolio_Code], [Sold_Date]) values ("
                    + "'" + Get_Trans_Date() + "', "
                    + "'" + CmbFullTicker.Text.Trim() + "', "
                    + "'" + CmbCurrency.Text.Trim() + "', "
                    + Num(parUnit, 4) + ", "
                    + Num(parCostBase, 2) + ", "
                    + Num(parFee, 2) + ", "
                    + Num(parTotal, 2) + ", "
                    + Num(parRealTotal, 2) + ", "
                    + (chkSold.Checked ? "True" : "False") + ", "
                    + "'" + CmbFlagCode.Text.Trim() + "', "
                    + Sql_Sold_Date() + ")";
            }
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            cmd.ExecuteNonQuery();
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpUnit;
                decimal TmpCostBase;
                decimal TmpFee;
                decimal TmpTotal;
                decimal TmpRealTotal;
                decimal TmpSellingPrice;
                decimal TmpSellingTotal;

                if (!Validate_Entry(out TmpUnit, out TmpCostBase, out TmpFee, out TmpTotal, out TmpRealTotal, out TmpSellingPrice, out TmpSellingTotal))
                {
                    return;
                }

                Insert_Current(TmpUnit, TmpCostBase, TmpFee, TmpTotal, TmpRealTotal, TmpSellingPrice, TmpSellingTotal);

                //a Sell also has to take those units out of the purchases they came from
                if (Is_Sell())
                {
                    Apply_Sale_To_Lots(Get_Trans_Date());
                }

                MessageBox.Show("Create successfully for " + CmbFullTicker.Text.Trim() + " on " + Mdl1.toLongDate(Get_Trans_Date()), "Success");

                Get_Data();
                Clear_Entry();
                Load_Lots();
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
                decimal TmpFee;
                decimal TmpTotal;
                decimal TmpRealTotal;
                decimal TmpSellingPrice;
                decimal TmpSellingTotal;

                if (!RowSelected)
                {
                    MessageBox.Show("Please select a transaction from the list first !", "Error Message");
                    return;
                }
                if (!Validate_Entry(out TmpUnit, out TmpCostBase, out TmpFee, out TmpTotal, out TmpRealTotal, out TmpSellingPrice, out TmpSellingTotal))
                {
                    return;
                }
                if (!Confirm_Affected("Update"))
                {
                    return;
                }

                bool WasSell = (OrgSource == "S");
                OleDbCommand cmd;

                if (WasSell != Is_Sell())
                {
                    //the type changed, so the row moves between tables
                    Mdl1.Ssql = "Delete from " + Org_Table() + Where_Original();
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();

                    Insert_Current(TmpUnit, TmpCostBase, TmpFee, TmpTotal, TmpRealTotal, TmpSellingPrice, TmpSellingTotal);
                }
                else if (Is_Sell())
                {
                    Mdl1.Ssql = "Update TblETFStocksSale set "
                        + "Full_Ticker = '" + CmbFullTicker.Text.Trim() + "', "
                        + "[Currency] = '" + CmbCurrency.Text.Trim() + "', "
                        + "Unit = " + Num(TmpUnit, 4) + ", "
                        + "[Selling_Price_Per_Unit] = " + Num(TmpSellingPrice, 2) + ", "
                        + "[Selling_Total_Amount] = " + Num(TmpSellingTotal, 2)
                        + Where_Original();
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Mdl1.Ssql = "Update TblETFStocksPurchase set "
                        + "Full_Ticker = '" + CmbFullTicker.Text.Trim() + "', "
                        + "[Currency] = '" + CmbCurrency.Text.Trim() + "', "
                        + "Unit = " + Num(TmpUnit, 4) + ", "
                        + "Cost_Base = " + Num(TmpCostBase, 2) + ", "
                        + "Fee = " + Num(TmpFee, 2) + ", "
                        + "Total_Cost_Base = " + Num(TmpTotal, 2) + ", "
                        + "Real_Total_Cost_Base = " + Num(TmpRealTotal, 2) + ", "
                        + "Is_Sold = " + (chkSold.Checked ? "True" : "False") + ", "
                        + "[Portfolio_Code] = '" + CmbFlagCode.Text.Trim() + "', "
                        + "[Sold_Date] = " + Sql_Sold_Date()
                        + Where_Original();
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                }

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
                    MessageBox.Show("Please select a transaction from the list first !", "Error Message");
                    return;
                }
                if (!Confirm_Affected("Delete"))
                {
                    return;
                }

                Mdl1.Ssql = "Delete from " + Org_Table() + Where_Original();
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
