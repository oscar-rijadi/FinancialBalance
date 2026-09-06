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
    public partial class ETF_Stocks_Sale : Form
    {
        bool FirstLoad;
        bool Filling;

        //TblETFStocksSale has no primary key, so a row is identified by the values it held
        //when it was picked out of the grid.  A null entry means the column was Null.
        bool RowSelected;
        string OrgTransDate;
        string OrgSaleId;
        string OrgFullTicker;
        string OrgCurrency;
        string OrgUnit;
        string OrgSellingPricePerUnit;
        string OrgSellingTotalAmount;
        string OrgSellPortfolioCode;

        public ETF_Stocks_Sale()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Sale_Load(object sender, EventArgs e)
        {
            FirstLoad = true;
            Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

            Filling = true;
            Fill_Full_Ticker();
            Mdl1.Fill_Curr(CmbCurrency);
            Set_Default_Currency();
            Mdl1.Fill_ETF_Stocks_Purchase_Flag(CmbSellPortfolio);
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

        private void MnETFStocksPurchase_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Purchase ETF_Stocks_Purchase = new ETF_Stocks_Purchase();
            ETF_Stocks_Purchase.Show();
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

        private void CmbFullTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Load_Lots();
        }

        //Sells default to the OB portfolio, the same as purchases
        private void Set_Default_Sell_Portfolio()
        {
            if (CmbSellPortfolio.Items.Contains("OB"))
            {
                CmbSellPortfolio.Text = "OB";
            }
            Show_Sell_Portfolio_Description();
        }

        private void CmbSellPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Sell_Portfolio_Description();
            //the lots on offer belong to the chosen portfolio, so the list has to be redrawn
            Load_Lots();
        }

        //The code is what gets stored, but it is only five characters; the description is
        //shown beside it so the right portfolio is obvious without opening the setup page.
        private void Show_Sell_Portfolio_Description()
        {
            string TmpCode = CmbSellPortfolio.Text.Trim();
            if (TmpCode == "")
            {
                LblSellPortfolioDesc.Text = "";
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

            LblSellPortfolioDesc.Text = (TmpDesc == "" ? "-" : TmpDesc);
        }

        //Fill_Curr defaults to IDR for the accounting pages; ETF trades default to AUD
        private void Set_Default_Currency()
        {
            if (CmbCurrency.Items.Contains("AUD"))
            {
                CmbCurrency.Text = "AUD";
            }
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
            monthCalendar1.SetDate(new System.DateTime(int.Parse(CmbYear.Text), int.Parse(CmbMM.Text), int.Parse(CmbDD.Text), 0, 0, 0, 0));
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Hide();

            FirstLoad = true;
            CmbDD.Text = e.Start.Day.ToString("00");
            CmbMM.Text = e.Start.Month.ToString("00");
            CmbYear.Text = e.Start.Year.ToString("0000");
            FirstLoad = false;
            DateChanged();
        }

        //---- the table ------------------------------------------------------------

        //Only sales live on this page, so none of the purchase columns appear.
        private void Clear_Grid()
        {
            gvSale.Columns.Clear();
            gvSale.ColumnCount = 9;
            string[] names = new string[] { "Sale Id", "Full Ticker", "Currency", "Unit", "Selling Price/Unit", "Selling Total Amount", "Portfolio Code", "Profit/Loss On Paper", "Real Profit/Loss" };
            int[] weights = new int[] { 21, 12, 7, 10, 12, 14, 9, 15, 13 };
            for (int i = 0; i < 9; i++)
            {
                gvSale.Columns[i].Name = names[i];
                gvSale.Columns[i].FillWeight = weights[i];
                if ((i >= 3 && i <= 5) || i >= 7)
                {
                    gvSale.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvSale.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    gvSale.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gvSale.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private string Select_Sales()
        {
            return "select Trans_Date, [Sale_Id], Full_Ticker, [Currency], Unit, [Selling_Price_Per_Unit], [Selling_Total_Amount], [Portfolio_Code], [Profit_Or_Loss_On_Paper], [Real_Profit_Or_Loss] from TblETFStocksSale"
                 + " where Trans_Date = '" + Get_Trans_Date() + "' order by Full_Ticker";
        }

        private void Get_Data()
        {
            Filling = true;
            RowSelected = false;

            Clear_Grid();

            Mdl1.Ssql = Select_Sales();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCurr = reader["Currency"].ToString().Trim();
                double TmpPaper = Read_Double(reader["Profit_Or_Loss_On_Paper"]);
                double TmpReal = Read_Double(reader["Real_Profit_Or_Loss"]);

                gvSale.Rows.Add(new string[] {
                    (reader["Sale_Id"] == DBNull.Value ? "" : reader["Sale_Id"].ToString().Trim()),
                    reader["Full_Ticker"].ToString().Trim(),
                    TmpCurr,
                    Format_Unit(reader["Unit"]),
                    Mdl1.FormatAmt(Read_Double(reader["Selling_Price_Per_Unit"])),
                    Mdl1.FormatAmt(Read_Double(reader["Selling_Total_Amount"])),
                    (reader["Portfolio_Code"] == DBNull.Value ? "-" : reader["Portfolio_Code"].ToString().Trim()),
                    Money(TmpPaper, TmpCurr),
                    Money(TmpReal, TmpCurr)
                });

                DataGridViewRow Row = gvSale.Rows[gvSale.Rows.Count - 1];
                Colour_Cell(Row.Cells[7], TmpPaper);
                Colour_Cell(Row.Cells[8], TmpReal);
            }
            reader.Close();

            gvSale.ClearSelection();
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

        //AUD and USD carry a dollar sign; any other currency stays bare, and a negative
        //reads -$12.34 rather than $-12.34.
        private bool Is_Dollar(string parCurr)
        {
            if (parCurr == null)
            {
                return false;
            }
            string TmpCurr = parCurr.Trim().ToUpper();
            return (TmpCurr == "AUD" || TmpCurr == "USD");
        }

        //Losses in red, gains in green; zero is left alone
        private void Colour_Cell(DataGridViewCell parCell, double parValue)
        {
            if (parValue < 0)
            {
                parCell.Style.ForeColor = System.Drawing.Color.Red;
                parCell.Style.SelectionForeColor = System.Drawing.Color.Red;
            }
            else if (parValue > 0)
            {
                parCell.Style.ForeColor = System.Drawing.Color.Green;
                parCell.Style.SelectionForeColor = System.Drawing.Color.Green;
            }
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
            txtSellingPricePerUnit.Text = "0.00";
            Set_Default_Sell_Portfolio();
            Filling = false;
            LblSaleId.Text = "";
            Clear_Sold_Lots_Grid();
            Show_Mode(false);
            Load_Lots();
            Calculate_Totals();
        }

        //Selling Total Amount = round(Unit x Selling Price/Unit, 2)
        private void Calculate_Totals()
        {
            double TmpUnit;
            double TmpSellingPrice;

            double.TryParse(txtUnit.Text.Trim(), out TmpUnit);
            double.TryParse(txtSellingPricePerUnit.Text.Trim(), out TmpSellingPrice);

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

        private void txtSellingPricePerUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        //---- the lots being sold --------------------------------------------------

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
            try
            {
                Filling = true;
                Clear_Lots_Grid();

                string TmpTicker = CmbFullTicker.Text.Trim();
                if (TmpTicker != "")
                {
                    //units can only be sold out of the portfolio that holds them
                    string TmpPortfolio = CmbSellPortfolio.Text.Trim();
                    Mdl1.Ssql = "select Trans_Date, Full_Ticker, [Currency], Unit, Cost_Base, Fee,"
                              + " Total_Cost_Base, Real_Total_Cost_Base, [Portfolio_Code],"
                              + " [Original_Cost_Base]"
                              + " from TblETFStocksPurchase where Is_Sold = False and Full_Ticker = '"
                              + TmpTicker + "'"
                              + (TmpPortfolio == "" ? "" : " and [Portfolio_Code] = '" + TmpPortfolio + "'")
                              + " order by Trans_Date";
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
                            (reader["Portfolio_Code"] == DBNull.Value ? null : reader["Portfolio_Code"].ToString().Trim()),
                            Sql_Num(reader["Original_Cost_Base"], 2)
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
        private void Apply_Sale_To_Lots(string parSoldDate, string parSaleId)
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
                string OrgOrigCost = o[9];

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
                    Mdl1.Ssql = "Update TblETFStocksPurchase set Is_Sold = True, [Sold_Date] = '" + parSoldDate + "'"
                              + ", [Sale_Id] = '" + parSaleId + "'" + Where;
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                    continue;
                }

                //the closed part keeps the original fee
                double LotOrigCost = Read_Double(OrgOrigCost);
                double SoldTotal = Math.Round(Math.Round(TmpSold * TmpCost, 2) + TmpFee, 2);
                double SoldReal = (RealWasZero ? 0 : SoldTotal);
                //Original_Total_Cost_Base has to be restated for the units that stay on this
                //row, exactly as Total_Cost_Base is.  Left alone it would keep the whole lot's
                //figure against a fraction of the units.
                double SoldOrigTotal = Math.Round(Math.Round(TmpSold * LotOrigCost, 2) + TmpFee, 2);

                Mdl1.Ssql = "Update TblETFStocksPurchase set "
                          + "Unit = " + TmpSold.ToString("0.0000", CultureInfo.InvariantCulture) + ", "
                          + "[Original_Total_Cost_Base] = " + SoldOrigTotal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "Total_Cost_Base = " + SoldTotal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "Real_Total_Cost_Base = " + SoldReal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "Is_Sold = True, [Sold_Date] = '" + parSoldDate + "', "
                          + "[Sale_Id] = '" + parSaleId + "'"
                          + Where;
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                //the remainder carries on as a new open lot, with no fee of its own
                double RestUnit = Math.Round(TmpLotUnit - TmpSold, 4);
                double RestTotal = Math.Round(RestUnit * TmpCost, 2);
                double RestReal = (RealWasZero ? 0 : RestTotal);
                //What the units originally cost travels with them, so a lot split by a part
                //sale does not lose its original figures.  The per-unit original is carried
                //across unchanged and the total is restated for the units that remain.
                double RestOrigTotal = Math.Round(RestUnit * LotOrigCost, 2);

                Mdl1.Ssql = "Insert into TblETFStocksPurchase (Trans_Date, Full_Ticker, [Currency], Unit, [Original_Cost_Base], Cost_Base, Fee,"
                          + " [Original_Total_Cost_Base], Total_Cost_Base, Real_Total_Cost_Base, Is_Sold, [Portfolio_Code], [Sold_Date]) values ("
                          + "'" + OrgDate + "', '" + OrgTicker + "', '" + OrgCurr + "', "
                          + RestUnit.ToString("0.0000", CultureInfo.InvariantCulture) + ", "
                          + LotOrigCost.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + TmpCost.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "0.00, "
                          + RestOrigTotal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + RestTotal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + RestReal.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                          + "False, "
                          + (OrgCode == null ? "Null" : "'" + OrgCode + "'") + ", Null)";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();
            }
        }

        //---- the two modes --------------------------------------------------------

        //The page is either entering a new sale - unsold lots on offer, Add available - or
        //reading back a stored one, where the lots on screen are the ones that sale closed and
        //there is nothing to add.
        private void Show_Mode(bool parSelected)
        {
            LblSaleIdCap.Visible = parSelected;
            LblSaleId.Visible = parSelected;

            LblLots.Visible = !parSelected;
            gvLots.Visible = !parSelected;
            LblSoldLots.Visible = parSelected;
            gvSoldLots.Visible = parSelected;
            LblTotPurchaseCap.Visible = parSelected;
            LblTotPurchase.Visible = parSelected;
            LblTotRealPurchaseCap.Visible = parSelected;
            LblTotRealPurchase.Visible = parSelected;

            CmdCreate.Visible = !parSelected;
        }

        //The currencies the closed lots were bought in.  A total only carries a dollar sign
        //when they all share one dollar currency - adding AUD to USD gives an amount in neither.
        List<string> SoldLotCurrencies = new List<string>();

        private void Clear_Sold_Lots_Grid()
        {
            gvSoldLots.Rows.Clear();
            gvSoldLots.Columns.Clear();
            gvSoldLots.ColumnCount = 5;
            string[] names = new string[] { "Purchase Date", "Unit", "Purchase Price / Unit",
                                            "Purchase Amount", "Real Purchase Amount" };
            int[] weights = new int[] { 20, 16, 22, 20, 22 };
            for (int i = 0; i < 5; i++)
            {
                gvSoldLots.Columns[i].Name = names[i];
                gvSoldLots.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign =
                    (i == 0 ? DataGridViewContentAlignment.MiddleLeft : DataGridViewContentAlignment.MiddleRight);
                gvSoldLots.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvSoldLots.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        //Every purchase row this sale closed, found by the id the sale stamped on them
        private void Load_Sold_Lots(string parSaleId)
        {
            Clear_Sold_Lots_Grid();
            SoldLotCurrencies.Clear();
            Show_Sold_Lot_Totals();
            if (parSaleId == null || parSaleId.Trim() == "")
            {
                return;
            }

            Mdl1.Ssql = "select Trans_Date, [Currency], Unit, Cost_Base, Total_Cost_Base, Real_Total_Cost_Base"
                      + " from TblETFStocksPurchase where [Sale_Id] = '" + parSaleId.Trim() + "'"
                      + " order by Trans_Date";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCurr = (reader["Currency"] == DBNull.Value ? "" : reader["Currency"].ToString().Trim());
                if (TmpCurr != "" && !SoldLotCurrencies.Contains(TmpCurr))
                {
                    SoldLotCurrencies.Add(TmpCurr);
                }
                gvSoldLots.Rows.Add(new string[] {
                    Format_Purchase_Date(reader["Trans_Date"].ToString().Trim()),
                    Format_Unit(reader["Unit"]),
                    Money(Read_Double(reader["Cost_Base"]), TmpCurr),
                    Money(Read_Double(reader["Total_Cost_Base"]), TmpCurr),
                    Money(Read_Double(reader["Real_Total_Cost_Base"]), TmpCurr) });
            }
            reader.Close();
            gvSoldLots.ClearSelection();
            Show_Sold_Lot_Totals();
        }

        //What the closed lots came to, under the table that lists them
        private void Show_Sold_Lot_Totals()
        {
            double TmpPurchaseAmount;
            double TmpRealAmount;
            Sold_Lot_Costs(out TmpPurchaseAmount, out TmpRealAmount);

            string TmpCurr = (SoldLotCurrencies.Count == 1 ? SoldLotCurrencies[0] : "");
            LblTotPurchase.Text = Money(TmpPurchaseAmount, TmpCurr);
            LblTotRealPurchase.Text = Money(TmpRealAmount, TmpCurr);
        }

        //The two costs the profit figures are worked out from, read back off the grid so they
        //are exactly the amounts on screen.
        private void Sold_Lot_Costs(out double parPurchaseAmount, out double parRealAmount)
        {
            parPurchaseAmount = 0;
            parRealAmount = 0;
            for (int i = 0; i < gvSoldLots.Rows.Count; i++)
            {
                parPurchaseAmount += Money_Value(gvSoldLots.Rows[i].Cells[3].Value);
                parRealAmount += Money_Value(gvSoldLots.Rows[i].Cells[4].Value);
            }
            parPurchaseAmount = Math.Round(parPurchaseAmount, 2);
            parRealAmount = Math.Round(parRealAmount, 2);
        }

        //undoes the display formatting - the dollar sign, the thousands separators and the
        //leading minus that Money puts in front of the sign
        private double Money_Value(object parValue)
        {
            if (parValue == null)
            {
                return 0;
            }
            string TmpText = parValue.ToString().Trim().Replace("$", "").Replace(",", "");
            double TmpValue;
            if (double.TryParse(TmpText, NumberStyles.Number, CultureInfo.CurrentCulture, out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        //---- picking a row --------------------------------------------------------

        private void gvSale_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //SelectionChanged fires while CurrentRow can still be pointing at the row being
            //left, so the selection itself is asked which row it is.
            DataGridViewRow Row = null;
            if (gvSale.SelectedRows.Count > 0)
            {
                Row = gvSale.SelectedRows[0];
            }
            else
            {
                Row = gvSale.CurrentRow;
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
            Mdl1.Ssql = Select_Sales();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            bool Found = false;
            while (reader.Read())
            {
                if (i == Ord)
                {
                    OrgTransDate = reader["Trans_Date"].ToString().Trim();
                    OrgSaleId = (reader["Sale_Id"] == DBNull.Value ? null : reader["Sale_Id"].ToString().Trim());
                    if (OrgSaleId == "")
                    {
                        OrgSaleId = null;
                    }
                    OrgFullTicker = reader["Full_Ticker"].ToString().Trim();
                    OrgCurrency = reader["Currency"].ToString().Trim();
                    OrgUnit = Sql_Num(reader["Unit"], 4);
                    OrgSellingPricePerUnit = Sql_Num(reader["Selling_Price_Per_Unit"], 2);
                    OrgSellingTotalAmount = Sql_Num(reader["Selling_Total_Amount"], 2);
                    OrgSellPortfolioCode = (reader["Portfolio_Code"] == DBNull.Value ? null : reader["Portfolio_Code"].ToString().Trim());
                    if (OrgSellPortfolioCode == "")
                    {
                        OrgSellPortfolioCode = null;
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
            txtSellingPricePerUnit.Text = (OrgSellingPricePerUnit == null ? "0.00" : OrgSellingPricePerUnit);
            if (OrgSellPortfolioCode != null && CmbSellPortfolio.Items.Contains(OrgSellPortfolioCode))
            {
                CmbSellPortfolio.Text = OrgSellPortfolioCode;
                Show_Sell_Portfolio_Description();
            }
            else
            {
                Set_Default_Sell_Portfolio();
            }
            Filling = false;

            //reading back a stored sale: the lots on offer are replaced by the ones this
            //sale closed, and its own figures are shown rather than recomputed
            LblSaleId.Text = (OrgSaleId == null ? "-" : OrgSaleId);
            Load_Sold_Lots(OrgSaleId);
            Show_Mode(true);

            Filling = true;
            txtUnit.Text = (OrgUnit == null ? "0.0000" : OrgUnit);
            txtSellingTotalAmount.Text = Mdl1.FormatAmt(Read_Double(OrgSellingTotalAmount));
            Filling = false;

            RowSelected = true;
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

        private bool Validate_Entry(out decimal parUnit, out decimal parSellingPrice, out decimal parSellingTotal)
        {
            parUnit = 0;
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
            return true;
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
                 + (OrgSaleId == null ? " and [Sale_Id] Is Null" : " and [Sale_Id] = '" + OrgSaleId + "'")
                 + " and Full_Ticker = '" + OrgFullTicker + "'"
                 + " and [Currency] = '" + OrgCurrency + "'"
                 + Where_Col("Unit", OrgUnit)
                 + Where_Col("[Selling_Price_Per_Unit]", OrgSellingPricePerUnit)
                 + Where_Col("[Selling_Total_Amount]", OrgSellingTotalAmount)
                 + (OrgSellPortfolioCode == null ? " and [Portfolio_Code] Is Null" : " and [Portfolio_Code] = '" + OrgSellPortfolioCode + "'");
        }

        //Without a key, identical rows are indistinguishable - warn before touching them all
        private bool Confirm_Affected(string parAction)
        {
            int TmpCount = 0;
            Mdl1.Ssql = "select count(*) as N from TblETFStocksSale" + Where_Original();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpCount = int.Parse(reader["N"].ToString());
            }
            reader.Close();

            if (TmpCount == 0)
            {
                MessageBox.Show("The selected sale could no longer be found.", "Error Message");
                return false;
            }
            if (TmpCount > 1)
            {
                DialogResult Response = MessageBox.Show(TmpCount.ToString() + " identical sales exist for this date. " + parAction + " will affect all " + TmpCount.ToString() + " of them. Continue ?", "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        //---- add, update, delete --------------------------------------------------

        //One identifier per sale, stamped on the sale itself and on every purchase lot the sale
        //closes, so the two sides can be tied back together afterwards.
        //
        //Trans_Date is 8, Full_Ticker up to 31, Portfolio_Code up to 5 and the time 6, plus three
        //separators: 53 characters at worst against a 50-character column.  Real tickers are far
        //shorter than 31, but a long one would be rejected by the database rather than silently
        //cut, so the length is checked before anything is written.
        private bool New_Sale_Id(out string parSaleId)
        {
            parSaleId = Get_Trans_Date()
                      + "_" + CmbFullTicker.Text.Trim()
                      + "_" + CmbSellPortfolio.Text.Trim()
                      + "_" + DateTime.Now.ToString("HHmmss");
            if (parSaleId.Length > 50)
            {
                MessageBox.Show("The Sale Id for this sale would be " + parSaleId.Length.ToString()
                    + " characters, and the field holds 50. Shorten the ticker or the portfolio code.",
                    "Error Message");
                return false;
            }
            return true;
        }


        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpUnit;
                decimal TmpSellingPrice;
                decimal TmpSellingTotal;

                if (!Validate_Entry(out TmpUnit, out TmpSellingPrice, out TmpSellingTotal))
                {
                    return;
                }

                string TmpSaleId;
                if (!New_Sale_Id(out TmpSaleId))
                {
                    return;
                }

                //worked out from the lots on screen, which is why this runs before
                //Apply_Sale_To_Lots settles them away
                double TmpPaperCost;
                double TmpRealCost;
                Sale_Cost_Of_Units(out TmpPaperCost, out TmpRealCost);

                double TmpSellingTotalD = (double)TmpSellingTotal;
                double TmpPaperProfit = Math.Round(TmpSellingTotalD - TmpPaperCost, 2);
                double TmpRealProfit = Math.Round(TmpSellingTotalD - TmpRealCost, 2);

                Mdl1.Ssql = "Insert into TblETFStocksSale (Trans_Date, [Sale_Id], Full_Ticker, [Currency], Unit, [Selling_Price_Per_Unit], [Selling_Total_Amount], [Profit_Or_Loss_On_Paper], [Real_Profit_Or_Loss], [Portfolio_Code]) values ("
                    + "'" + Get_Trans_Date() + "', "
                    + "'" + TmpSaleId + "', "
                    + "'" + CmbFullTicker.Text.Trim() + "', "
                    + "'" + CmbCurrency.Text.Trim() + "', "
                    + Num(TmpUnit, 4) + ", "
                    + Num(TmpSellingPrice, 2) + ", "
                    + Num(TmpSellingTotal, 2) + ", "
                    + TmpPaperProfit.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                    + TmpRealProfit.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                    + "'" + CmbSellPortfolio.Text.Trim() + "')";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                //the sale also has to take those units out of the purchases they came from
                Apply_Sale_To_Lots(Get_Trans_Date(), TmpSaleId);

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
                decimal TmpSellingPrice;
                decimal TmpSellingTotal;

                if (!RowSelected)
                {
                    MessageBox.Show("Please select a sale from the list first !", "Error Message");
                    return;
                }
                if (!Validate_Entry(out TmpUnit, out TmpSellingPrice, out TmpSellingTotal))
                {
                    return;
                }
                if (!Confirm_Affected("Update"))
                {
                    return;
                }

                //restated against the lots this sale actually closed, which are the rows on
                //screen.  On paper counts every lot; the real figure ignores what the reinvested
                //ones cost, because those units cost no money of their own.
                //A sale with no Sale_Id cannot say which lots it closed, so the table above it is
                //empty and the costs would come out as zero - restating the profits from that would
                //quietly rewrite them as the whole proceeds.  Those two columns are left alone
                //instead, and only a sale that knows its lots has them recomputed.
                string TmpProfitSet = "";
                if (OrgSaleId != null && OrgSaleId.Trim() != "")
                {
                    double TmpPurchaseAmount;
                    double TmpRealAmount;
                    Sold_Lot_Costs(out TmpPurchaseAmount, out TmpRealAmount);
                    double TmpPaperProfit = Math.Round((double)TmpSellingTotal - TmpPurchaseAmount, 2);
                    double TmpRealProfit = Math.Round((double)TmpSellingTotal - TmpRealAmount, 2);
                    TmpProfitSet = "[Profit_Or_Loss_On_Paper] = " + TmpPaperProfit.ToString("0.00", CultureInfo.InvariantCulture) + ", "
                                 + "[Real_Profit_Or_Loss] = " + TmpRealProfit.ToString("0.00", CultureInfo.InvariantCulture) + ", ";
                }

                Mdl1.Ssql = "Update TblETFStocksSale set "
                    + "Full_Ticker = '" + CmbFullTicker.Text.Trim() + "', "
                    + "[Currency] = '" + CmbCurrency.Text.Trim() + "', "
                    + "Unit = " + Num(TmpUnit, 4) + ", "
                    + "[Selling_Price_Per_Unit] = " + Num(TmpSellingPrice, 2) + ", "
                    + "[Selling_Total_Amount] = " + Num(TmpSellingTotal, 2) + ", "
                    + TmpProfitSet
                    + "[Portfolio_Code] = '" + CmbSellPortfolio.Text.Trim() + "'"
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
                    MessageBox.Show("Please select a sale from the list first !", "Error Message");
                    return;
                }
                if (!Confirm_Affected("Delete"))
                {
                    return;
                }

                //the lots this sale closed go back to being held, before the sale itself goes
                if (OrgSaleId != null && OrgSaleId.Trim() != "")
                {
                    Mdl1.Ssql = "Update TblETFStocksPurchase set Is_Sold = False, [Sold_Date] = Null, [Sale_Id] = Null"
                              + " where [Sale_Id] = '" + OrgSaleId.Trim() + "'";
                    OleDbCommand release = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    release.ExecuteNonQuery();
                }

                Mdl1.Ssql = "Delete from TblETFStocksSale" + Where_Original();
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
