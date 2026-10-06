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
    public partial class ETF_Stocks_Ticker_Historical_Data : Form
    {
        bool Filling;

        //The Portfolio dropdown shows descriptions but filters on codes, so the codes are kept
        //in a list running parallel to the items - two portfolios sharing a description still
        //filter correctly.  A null entry is the "All" row.
        List<string> PortfolioCodes = new List<string>();

        //Every currency the rows on screen are recorded in, gathered as the three tables are
        //filled, so the note can say when they do not all agree with the one at the top.
        List<string> SeenCurrs = new List<string>();

        public ETF_Stocks_Ticker_Historical_Data()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Ticker_Historical_Data_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Portfolio();
            Fill_Ticker();
            Fill_Financial_Year();
            Filling = false;

            Get_Data();
        }

        //Main Only narrows the list itself, so a non-main portfolio cannot be chosen while it
        //is ticked - the same as ETF/Stock Dividend History.
        private void Fill_Portfolio()
        {
            CmbPortfolio.Items.Clear();
            PortfolioCodes.Clear();

            CmbPortfolio.Items.Add("All");
            PortfolioCodes.Add(null);

            Mdl1.Ssql = "select Portfolio_Code, [Description] from TblETFStocksPortfolioCode"
                      + (chkMainOnly.Checked ? " where [Is_Main] = True" : "")
                      + " order by Portfolio_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = reader["Portfolio_Code"].ToString().Trim();
                string TmpDesc = reader["Description"].ToString().Trim();
                if (TmpDesc == "")
                {
                    TmpDesc = TmpCode;
                }
                CmbPortfolio.Items.Add(TmpDesc);
                PortfolioCodes.Add(TmpCode);
            }
            reader.Close();

            CmbPortfolio.Text = "All";
        }

        //No "All" here: the page is the history of one ticker, so one is always chosen, and
        //the first in the list is where it starts.
        private void Fill_Ticker()
        {
            CmbTicker.Items.Clear();

            Mdl1.Ssql = "select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbTicker.Items.Add(reader["Full_Ticker"].ToString().Trim());
            }
            reader.Close();

            if (CmbTicker.Items.Count > 0)
            {
                CmbTicker.SelectedIndex = 0;
            }
        }

        //Most recently closed year first, which is the one usually being looked at
        private void Fill_Financial_Year()
        {
            CmbFinYear.Items.Clear();
            CmbFinYear.Items.Add("All");

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFinYear.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            CmbFinYear.Text = "All";
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void CmbTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void CmbFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void chkMainOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //the portfolio list itself changes, so rebuild it from the top
            Filling = true;
            Fill_Portfolio();
            Filling = false;
            Get_Data();
        }

        //---- filters -------------------------------------------------------------

        private string Selected_Portfolio_Code()
        {
            int idx = CmbPortfolio.SelectedIndex;
            if (idx < 0 || idx >= PortfolioCodes.Count)
            {
                return null;
            }
            return PortfolioCodes[idx];
        }

        //The chosen year's two dates.  Both are stored yyyyMMdd, so a plain string comparison
        //against a row's date is the same as a date comparison.
        private bool Financial_Year_Range(out string parStart, out string parEnd)
        {
            parStart = "";
            parEnd = "";

            string TmpName = CmbFinYear.Text.Trim();
            if (TmpName == "" || TmpName == "All")
            {
                return false;
            }

            Mdl1.Ssql = "select [Start_Date], [End_Date] from TblFinancialYear where [Name] = ?";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            cmd.Parameters.AddWithValue("@Name", TmpName);
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

        //One section's rows: the ticker always, then the portfolio and the financial year when
        //they narrow anything.  parDateField is the date the year is matched against -
        //Trans_Date for a purchase or a sale, Pay_Date for a payment.
        //
        //The values go in as parameters rather than being pasted into the statement, which is
        //what the Implementation notes ask of a new query.  Jet matches them by position, so
        //each is added in the order its ? appears.
        private OleDbCommand Section_Command(string parSelect, string parDateField)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = Mdl1.conn;

            string TmpWhere = " where Full_Ticker = ?";
            cmd.Parameters.AddWithValue("@Ticker", CmbTicker.Text.Trim());

            string TmpCode = Selected_Portfolio_Code();
            if (TmpCode != null)
            {
                TmpWhere = TmpWhere + " and [Portfolio_Code] = ?";
                cmd.Parameters.AddWithValue("@Code", TmpCode);
            }
            else if (chkMainOnly.Checked)
            {
                //"All" still respects Main Only, and a row carrying no code at all belongs to no
                //main portfolio, so it drops out with the rest
                TmpWhere = TmpWhere + " and [Portfolio_Code] In (select Portfolio_Code"
                         + " from TblETFStocksPortfolioCode where [Is_Main] = True)";
            }

            string TmpStart;
            string TmpEnd;
            if (Financial_Year_Range(out TmpStart, out TmpEnd))
            {
                TmpWhere = TmpWhere + " and " + parDateField + " >= ? and " + parDateField + " <= ?";
                cmd.Parameters.AddWithValue("@Start", TmpStart);
                cmd.Parameters.AddWithValue("@End", TmpEnd);
            }

            //newest first, and within a day the portfolios in reverse code order
            cmd.CommandText = parSelect + TmpWhere
                            + " order by " + parDateField + " Desc, [Portfolio_Code] Desc";
            Mdl1.Ssql = cmd.CommandText;
            return cmd;
        }

        //---- formatting ----------------------------------------------------------

        //Every money figure takes the sign, whatever the ticker is recorded in - the currency
        //at the top of the page says which dollar it is.  A negative reads -$12.34 rather than
        //$-12.34.
        private string Money(double parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        //Units are held to four places, and shown that way everywhere they are listed
        private string Format_Unit(double parValue)
        {
            return parValue.ToString("#,##0.0000");
        }

        private string Yes_No(object parValue)
        {
            return (Read_Text(parValue) == "True" ? "Y" : "N");
        }

        private string Format_Date(string parYyyyMMdd)
        {
            DateTime TmpDate;
            if (parYyyyMMdd != null && DateTime.TryParseExact(parYyyyMMdd.Trim(), "yyyyMMdd",
                    new CultureInfo("en-AU"), DateTimeStyles.None, out TmpDate))
            {
                return TmpDate.ToString("dd-MMM-yyyy", new CultureInfo("en-AU"));
            }
            return (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
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

        private string Read_Text(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return "";
            }
            return parValue.ToString().Trim();
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

        private void Colour_Label(Label parLabel, double parValue)
        {
            if (parValue < 0)
            {
                parLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (parValue > 0)
            {
                parLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                parLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        //A row's currency, remembered for the note before the row is shown
        private void Saw_Currency(object parValue)
        {
            string TmpCurr = Read_Text(parValue).ToUpper();
            if (TmpCurr != "" && !SeenCurrs.Contains(TmpCurr))
            {
                SeenCurrs.Add(TmpCurr);
            }
        }

        //---- grids ---------------------------------------------------------------

        //parAligns carries one letter a column - L, C or R.  Sorting is switched off: the order
        //is part of what the page says (newest first), and a click on a heading would sort the
        //formatted text, putting $9.00 after $10.00.
        private void Build_Grid(DataGridView parGrid, string[] parNames, int[] parWeights, string parAligns)
        {
            parGrid.Rows.Clear();
            parGrid.Columns.Clear();
            parGrid.ColumnCount = parNames.Length;
            for (int i = 0; i < parNames.Length; i++)
            {
                parGrid.Columns[i].Name = parNames[i];
                parGrid.Columns[i].FillWeight = parWeights[i];
                parGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                DataGridViewContentAlignment TmpAlign;
                if (parAligns[i] == 'R')
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleRight;
                }
                else if (parAligns[i] == 'C')
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                }
                parGrid.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                parGrid.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Clear_Purchase_Grid()
        {
            Build_Grid(gvPurchase,
                new string[] { "Purchase Date", "Portfolio Code", "Unit", "Original Cost Base",
                               "Cost Base", "Fee", "Original Total Cost Base", "Total Cost Base",
                               "Real Total Cost Base", "Is Sold", "Sold Date", "Sale Id", "Is Free" },
                new int[] { 7, 6, 7, 8, 8, 6, 9, 9, 9, 5, 8, 15, 5 },
                "CCRRRRRRRCCLC");
        }

        private void Clear_Sale_Grid()
        {
            Build_Grid(gvSale,
                new string[] { "Sold Date", "Portfolio Code", "Sale Id", "Unit", "Sold Price Per Unit",
                               "Sold Total Amount", "Profit/Loss On Paper", "Real Profit/Loss" },
                new int[] { 11, 9, 22, 10, 11, 12, 13, 12 },
                "CCLRRRRR");
        }

        private void Clear_Distribution_Grid()
        {
            Build_Grid(gvDistribution,
                new string[] { "Pay Date", "Portfolio Code", "Amount", "Is Reinvested" },
                new int[] { 26, 24, 28, 22 },
                "CCRC");
        }

        //---- the page --------------------------------------------------------------

        private void Get_Data()
        {
            try
            {
                SeenCurrs.Clear();
                Clear_Purchase_Grid();
                Clear_Sale_Grid();
                Clear_Distribution_Grid();

                if (CmbTicker.Text.Trim() == "")
                {
                    //nothing set up yet, so there is no ticker to have a history
                    Show_Purchase_Totals(0, 0, 0, 0, 0);
                    Show_Sale_Totals(0, 0, 0, 0);
                    Show_Distribution_Totals(0);
                    LblCurrency.Text = "Currency : -";
                    LblPurPriceCap.Text = "Latest Price";
                    LblPurPrice.Text = "-";
                    LblNote.Text = "No ETF or stock is set up yet - add one in ETF/Stock Setup.";
                    return;
                }

                Get_Purchases();
                Get_Sales();
                Get_Distributions();

                LblCurrency.Text = "Currency : " + Ticker_Currency();
                Show_Latest_Price();
                Show_Note();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Every lot bought, and what they add up to.  The totals are taken from the same rows
        //the table shows, so what is under the table and what is in it can never disagree.
        private void Get_Purchases()
        {
            double TotUnit = 0;
            double TotCurrent = 0;
            double TotSold = 0;
            double TotCost = 0;
            double TotReal = 0;

            OleDbCommand cmd = Section_Command("select Trans_Date, [Portfolio_Code], [Currency], Unit,"
                + " Original_Cost_Base, Cost_Base, Fee, Original_Total_Cost_Base, Total_Cost_Base,"
                + " Real_Total_Cost_Base, Is_Sold, Sold_Date, Sale_Id, Is_Free"
                + " from TblETFStocksPurchase", "Trans_Date");
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Saw_Currency(reader["Currency"]);

                double TmpUnit = Read_Double(reader["Unit"]);
                double TmpTotal = Read_Double(reader["Total_Cost_Base"]);
                double TmpReal = Read_Double(reader["Real_Total_Cost_Base"]);
                bool TmpIsSold = (Read_Text(reader["Is_Sold"]) == "True");

                gvPurchase.Rows.Add(new string[] {
                    Format_Date(Read_Text(reader["Trans_Date"])),
                    Read_Text(reader["Portfolio_Code"]),
                    Format_Unit(TmpUnit),
                    Money(Read_Double(reader["Original_Cost_Base"])),
                    Money(Read_Double(reader["Cost_Base"])),
                    Money(Read_Double(reader["Fee"])),
                    Money(Read_Double(reader["Original_Total_Cost_Base"])),
                    Money(TmpTotal),
                    Money(TmpReal),
                    (TmpIsSold ? "Y" : "N"),
                    Format_Date(Read_Text(reader["Sold_Date"])),
                    Read_Text(reader["Sale_Id"]),
                    Yes_No(reader["Is_Free"]) });

                TotUnit += TmpUnit;
                if (TmpIsSold)
                {
                    TotSold += TmpUnit;
                }
                else
                {
                    TotCurrent += TmpUnit;
                }
                TotCost += TmpTotal;
                TotReal += TmpReal;
            }
            reader.Close();

            Show_Purchase_Totals(TotUnit, TotCurrent, TotSold, TotCost, TotReal);
            gvPurchase.ClearSelection();
        }

        //Both averages are over every unit bought, sold or not, so they describe what the
        //ticker cost on the way in.  Nothing bought gives no denominator, and the average is
        //shown as nothing rather than left undefined.
        private void Show_Purchase_Totals(double parUnit, double parCurrent, double parSold,
                                          double parCost, double parReal)
        {
            LblPurUnit.Text = Format_Unit(parUnit);
            LblPurCurrentUnit.Text = Format_Unit(parCurrent);
            LblPurSoldUnit.Text = Format_Unit(parSold);
            LblPurAvgCost.Text = Money(parUnit == 0 ? 0 : parCost / parUnit);
            LblPurAvgReal.Text = Money(parUnit == 0 ? 0 : parReal / parUnit);
            LblPurTotalCost.Text = Money(parCost);
            LblPurTotalReal.Text = Money(parReal);
        }

        //The newest price on record for the ticker, under the averages so the two can be read
        //against each other.  Portfolio and Financial Year are ignored: a price belongs to the
        //ticker rather than to a portfolio, and "latest" means the newest there is - the same
        //lookup ETF/Stock Portfolio Summary makes.  The date goes beside the caption, since a
        //price from weeks ago reads very differently from one taken today.
        private void Show_Latest_Price()
        {
            Mdl1.Ssql = "select top 1 Price_Date, [Price], [Currency] from TblETFStocksPrice"
                      + " where Full_Ticker = ? order by Price_Date Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            cmd.Parameters.AddWithValue("@Ticker", CmbTicker.Text.Trim());
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = reader.Read();
            string TmpDate = "";
            double TmpPrice = 0;
            string TmpCurr = "";
            if (Found)
            {
                TmpDate = Read_Text(reader["Price_Date"]);
                TmpPrice = Read_Double(reader["Price"]);
                TmpCurr = Read_Text(reader["Currency"]).ToUpper();
            }
            reader.Close();

            if (!Found)
            {
                //never priced - ETF/Stock Price is where one is recorded
                LblPurPriceCap.Text = "Latest Price";
                LblPurPrice.Text = "-";
                return;
            }

            LblPurPriceCap.Text = "Latest Price (" + Format_Date(TmpDate) + ")";

            //A price carries a currency of its own, usually the ticker's but not necessarily.
            //When it differs from the one at the top of the page it is named, so the price
            //cannot be read as being in the same money as the averages above it.
            string TmpShown = LblCurrency.Text.Replace("Currency :", "").Trim();
            LblPurPrice.Text = (TmpCurr != "" && TmpCurr != TmpShown ? TmpCurr + " " : "") + Money(TmpPrice);
        }

        //Every sale, with the two profit columns coloured the way the rest of the application
        //colours a gain or a loss.
        private void Get_Sales()
        {
            double TotUnit = 0;
            double TotAmount = 0;
            double TotPaper = 0;
            double TotReal = 0;

            OleDbCommand cmd = Section_Command("select Trans_Date, [Portfolio_Code], [Currency], Sale_Id,"
                + " Unit, Selling_Price_Per_Unit, Selling_Total_Amount, Profit_Or_Loss_On_Paper,"
                + " Real_Profit_Or_Loss"
                + " from TblETFStocksSale", "Trans_Date");
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Saw_Currency(reader["Currency"]);

                double TmpUnit = Read_Double(reader["Unit"]);
                double TmpAmount = Read_Double(reader["Selling_Total_Amount"]);
                double TmpPaper = Read_Double(reader["Profit_Or_Loss_On_Paper"]);
                double TmpReal = Read_Double(reader["Real_Profit_Or_Loss"]);

                int idx = gvSale.Rows.Add(new string[] {
                    Format_Date(Read_Text(reader["Trans_Date"])),
                    Read_Text(reader["Portfolio_Code"]),
                    Read_Text(reader["Sale_Id"]),
                    Format_Unit(TmpUnit),
                    Money(Read_Double(reader["Selling_Price_Per_Unit"])),
                    Money(TmpAmount),
                    Money(TmpPaper),
                    Money(TmpReal) });
                Colour_Cell(gvSale.Rows[idx].Cells[6], TmpPaper);
                Colour_Cell(gvSale.Rows[idx].Cells[7], TmpReal);

                TotUnit += TmpUnit;
                TotAmount += TmpAmount;
                TotPaper += TmpPaper;
                TotReal += TmpReal;
            }
            reader.Close();

            Show_Sale_Totals(TotUnit, TotAmount, TotPaper, TotReal);
            gvSale.ClearSelection();
        }

        private void Show_Sale_Totals(double parUnit, double parAmount, double parPaper, double parReal)
        {
            LblSaleUnit.Text = Format_Unit(parUnit);
            LblSaleAmount.Text = Money(parAmount);
            LblSalePaper.Text = Money(parPaper);
            LblSaleReal.Text = Money(parReal);
            Colour_Label(LblSalePaper, parPaper);
            Colour_Label(LblSaleReal, parReal);
        }

        //Every distribution or dividend paid, whether it was taken as cash or put back in
        private void Get_Distributions()
        {
            double TotAmount = 0;

            OleDbCommand cmd = Section_Command("select Pay_Date, [Portfolio_Code], [Currency],"
                + " Total_Amount, Is_Reinvested"
                + " from TblETFStocksDistributionDividend", "Pay_Date");
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Saw_Currency(reader["Currency"]);

                double TmpAmount = Read_Double(reader["Total_Amount"]);
                gvDistribution.Rows.Add(new string[] {
                    Format_Date(Read_Text(reader["Pay_Date"])),
                    Read_Text(reader["Portfolio_Code"]),
                    Money(TmpAmount),
                    Yes_No(reader["Is_Reinvested"]) });

                TotAmount += TmpAmount;
            }
            reader.Close();

            Show_Distribution_Totals(TotAmount);
            gvDistribution.ClearSelection();
        }

        private void Show_Distribution_Totals(double parAmount)
        {
            LblDistTotal.Text = Money(parAmount);
        }

        //The currency the ticker is recorded in: the first row it has among the purchases, or
        //failing any the sales, or failing those the payments - newest first, the order the
        //tables are listed in.  It is asked of the ticker alone rather than through the other
        //dropdowns, so a year in which nothing happened still says what the ticker trades in.
        private string Ticker_Currency()
        {
            string[,] Sources = new string[,] {
                { "TblETFStocksPurchase", "Trans_Date" },
                { "TblETFStocksSale", "Trans_Date" },
                { "TblETFStocksDistributionDividend", "Pay_Date" } };

            for (int i = 0; i < Sources.GetLength(0); i++)
            {
                Mdl1.Ssql = "select [Currency] from " + Sources[i, 0]
                          + " where Full_Ticker = ? and Trim([Currency]) <> ''"
                          + " order by " + Sources[i, 1] + " Desc, [Portfolio_Code] Desc";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.Parameters.AddWithValue("@Ticker", CmbTicker.Text.Trim());
                OleDbDataReader reader = cmd.ExecuteReader();
                string TmpCurr = "";
                if (reader.Read())
                {
                    TmpCurr = Read_Text(reader["Currency"]).ToUpper();
                }
                reader.Close();

                if (TmpCurr != "")
                {
                    return TmpCurr;
                }
            }
            //a ticker set up but never bought, sold or paid
            return "-";
        }

        //What is on screen and what is narrowing it, so an empty table is explainable.  Nothing
        //on the page is converted, so rows recorded in a second currency would be added into the
        //totals as they stand - which is said rather than left to be noticed.
        private void Show_Note()
        {
            List<string> Parts = new List<string>();

            if (chkMainOnly.Checked)
            {
                Parts.Add("main portfolios only");
            }
            string TmpYear = CmbFinYear.Text.Trim();
            if (TmpYear != "" && TmpYear != "All")
            {
                string TmpStart;
                string TmpEnd;
                if (Financial_Year_Range(out TmpStart, out TmpEnd))
                {
                    Parts.Add("financial year " + TmpYear + "  (" + Format_Date(TmpStart)
                              + " to " + Format_Date(TmpEnd) + ")");
                }
                else
                {
                    Parts.Add("financial year " + TmpYear + "  (no dates set up, so no date filter applied)");
                }
            }

            string TmpText = gvPurchase.Rows.Count.ToString() + " purchase(s), "
                           + gvSale.Rows.Count.ToString() + " sale(s), "
                           + gvDistribution.Rows.Count.ToString() + " distribution/dividend(s)";
            if (Parts.Count > 0)
            {
                TmpText = TmpText + "   -   " + String.Join(", ", Parts.ToArray());
            }

            string TmpShown = LblCurrency.Text.Replace("Currency :", "").Trim();
            if (SeenCurrs.Count > 1 || (SeenCurrs.Count == 1 && SeenCurrs[0] != TmpShown))
            {
                TmpText = TmpText + "   -   rows recorded in " + String.Join(", ", SeenCurrs.ToArray())
                        + ", added up as recorded";
            }
            LblNote.Text = TmpText;
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
