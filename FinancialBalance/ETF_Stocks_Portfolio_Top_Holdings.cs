using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinancialBalance
{
    //What the portfolio actually owns once each holding is looked through.  The holdings are
    //worked out exactly as ETF/Stock Portfolio Summary works them out - unsold purchases, the
    //latest price, every figure in AUD - and each one's share of the whole portfolio is what
    //Holdings_Lookup spreads across the companies it holds.  A company's dollar figure comes
    //the same way, from each holding's Total Current Amount.
    //
    //Read-only: nothing on this page writes to the database.
    public partial class ETF_Stocks_Portfolio_Top_Holdings : Form
    {
        bool Filling;

        //Index-aligned with CmbPortfolio: entry 0 is "All" and carries no portfolio code.
        //Held as a list rather than looked up by description, because descriptions
        //are not unique in TblETFStocksPortfolioCode.
        List<string> FlagCodes = new List<string>();

        //One holding of the portfolio in view, already in AUD
        private class Position
        {
            public string Ticker;
            public double Units;
            public double Investment;
            public bool Priced;
            public double Price;
            public double Current;
            public double Share;    //a percentage of the whole portfolio's current amount
        }

        //every holding of the portfolio in view, whichever ticker the dropdown narrows to
        List<Position> Positions = new List<Position>();
        double PortfolioCurrent;

        public ETF_Stocks_Portfolio_Top_Holdings()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Portfolio_Top_Holdings_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Portfolio();
            Filling = false;

            Refresh_All();
        }

        //---- the filters -----------------------------------------------------------

        //"All" plus one entry per portfolio code, showing its description
        private void Fill_Portfolio()
        {
            CmbPortfolio.Items.Clear();
            FlagCodes.Clear();

            CmbPortfolio.Items.Add("All");
            FlagCodes.Add(null);

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
                FlagCodes.Add(TmpCode);
            }
            reader.Close();

            CmbPortfolio.Text = "All";
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Refresh_All();
        }

        //With Main Only ticked, only purchases whose portfolio is marked Is_Main count.  A
        //purchase with no portfolio at all is excluded too, since it belongs to no main one.
        private string Main_Filter()
        {
            if (!chkMainOnly.Checked)
            {
                return "";
            }
            return " and [Portfolio_Code] In (select Portfolio_Code from TblETFStocksPortfolioCode where [Is_Main] = True)";
        }

        private void chkMainOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //the portfolio list itself changes, so rebuild from the top
            Filling = true;
            Fill_Portfolio();
            Filling = false;
            Refresh_All();
        }

        //Changing portfolio rebuilds the holdings, so the ticker choice resets to All
        private void Refresh_All()
        {
            Get_Data();
            Fill_Ticker();
            Show_Grid();
        }

        private void Fill_Ticker()
        {
            Filling = true;
            CmbTicker.Items.Clear();
            CmbTicker.Items.Add("All");
            foreach (Position TmpPos in Positions)
            {
                CmbTicker.Items.Add(TmpPos.Ticker);
            }
            CmbTicker.Text = "All";
            Filling = false;
        }

        private void CmbTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Grid();
        }

        private bool All_Tickers()
        {
            return (CmbTicker.Text.Trim() == "" || CmbTicker.Text.Trim() == "All");
        }

        //the holdings the dropdown leaves in view - all of them, or the one chosen
        private List<Position> In_View()
        {
            if (All_Tickers())
            {
                return Positions;
            }
            return Positions.Where(p => p.Ticker == CmbTicker.Text.Trim()).ToList();
        }

        //---- formatting ------------------------------------------------------------

        //Every figure on this page is in AUD, whatever currency it was stored in, so every
        //figure takes the sign. A negative reads -$12.34 rather than $-12.34.
        private string Money(double parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00") + " %";
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

        //---- into Australian Dollar -------------------------------------------------
        //
        //The same conversion ETF/Stock Portfolio Summary makes, so the two pages agree to the
        //cent.  TblCurrRate holds IDR per one unit, so a figure reaches AUD by way of the rupiah:
        //
        //    AUD = amount x rate(currency) / rate(AUD)
        //
        //at today's month's rate for every figure.
        private const string PageCurr = "AUD";

        private Dictionary<string, double> RateCache = new Dictionary<string, double>();
        private Dictionary<string, bool> RateKnown = new Dictionary<string, bool>();
        private List<string> NoRate = new List<string>();
        private string RateMonth = "";

        //Every rate a refresh could want, read before a single row of data is: the page converts
        //inside its read loops, and the shared connection will not stand a second open reader.
        private void Begin_Rates()
        {
            RateCache.Clear();
            RateKnown.Clear();
            NoRate.Clear();
            RateMonth = DateTime.Now.ToString("yyyyMM");

            List<string> Codes = new List<string>();
            Codes.Add(PageCurr);
            Mdl1.Ssql = "select Curr_Code from TblCurrCode order by Curr_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = (reader["Curr_Code"] == DBNull.Value ? "" : reader["Curr_Code"].ToString().Trim().ToUpper());
                if (TmpCode != "" && !Codes.Contains(TmpCode))
                {
                    Codes.Add(TmpCode);
                }
            }
            reader.Close();

            for (int i = 0; i < Codes.Count; i++)
            {
                Load_Rate(Codes[i]);
            }
        }

        //GetCurrRate answers 1 for a currency it has never heard of, so whether TblCurrRate
        //holds anything for it is asked separately - that is what lets the page say a figure
        //went unconverted instead of passing it off as converted.
        private void Load_Rate(string parCurr)
        {
            if (RateCache.ContainsKey(parCurr))
            {
                return;
            }
            if (parCurr == "IDR")
            {
                //the pivot itself - one rupiah to the rupiah, and never a row to read
                RateCache[parCurr] = 1;
                RateKnown[parCurr] = true;
                return;
            }

            bool Known = Has_Rate(parCurr);
            double TmpRate = (Known ? Mdl1.GetCurrRate(parCurr, RateMonth) : 1);
            RateCache[parCurr] = (TmpRate <= 0 ? 1 : TmpRate);
            RateKnown[parCurr] = Known;
        }

        private bool Has_Rate(string parCurr)
        {
            bool Found = false;
            Mdl1.Ssql = "select top 1 Curr_Date from TblCurrRate where Curr_Code = '" + parCurr + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Found = reader.Read();
            reader.Close();
            return Found;
        }

        //Nothing here reads the database: every rate it can answer with was loaded beforehand.
        private double Rate_Of(string parCurr)
        {
            string strCurr = (parCurr == null ? "" : parCurr.Trim().ToUpper());
            if (strCurr == "")
            {
                strCurr = PageCurr;
            }

            if (RateCache.ContainsKey(strCurr))
            {
                if (!RateKnown[strCurr] && !NoRate.Contains(strCurr))
                {
                    NoRate.Add(strCurr);
                }
                return RateCache[strCurr];
            }

            //a currency on a row but not in Currency Setup, so there can be no rate for it either
            if (!NoRate.Contains(strCurr))
            {
                NoRate.Add(strCurr);
            }
            return 1;
        }

        private double To_AUD(double parAmount, string parCurr)
        {
            string strCurr = (parCurr == null ? "" : parCurr.Trim().ToUpper());
            //nothing said is taken as already being in AUD
            if (strCurr == "" || strCurr == PageCurr)
            {
                return parAmount;
            }
            return parAmount * Rate_Of(strCurr) / Rate_Of(PageCurr);
        }

        private string Rate_Note()
        {
            if (NoRate.Count == 0)
            {
                return "";
            }
            return "   -   no currency rate on record for "
                 + String.Join(", ", NoRate.ToArray())
                 + ", shown unconverted";
        }

        //Latest price for a ticker and the currency it is quoted in, or false when the ticker
        //has never been priced - the same read ETF/Stock Portfolio Summary makes.
        private bool Get_Latest_Price(string parFullTicker, out double parPrice, out string parCurr)
        {
            parPrice = 0;
            parCurr = "";
            bool Found = false;

            Mdl1.Ssql = "select top 1 [Price], [Currency] from TblETFStocksPrice where Full_Ticker = '"
                      + parFullTicker.Replace("'", "''") + "' order by Price_Date Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                parPrice = Read_Double(reader["Price"]);
                parCurr = (reader["Currency"] == DBNull.Value ? "" : reader["Currency"].ToString().Trim());
                Found = true;
            }
            reader.Close();
            return Found;
        }

        //---- the holdings ----------------------------------------------------------

        //Only unsold holdings count towards a portfolio, the same rule ETF/Stock Portfolio
        //Summary applies.  Every holding of the portfolio is read whichever ticker is chosen,
        //since each one's share is of the whole.
        private void Get_Data()
        {
            try
            {
                Begin_Rates();
                Positions.Clear();
                PortfolioCurrent = 0;

                string TmpFlagCode = null;
                int idx = CmbPortfolio.SelectedIndex;
                if (idx > 0 && idx < FlagCodes.Count)
                {
                    TmpFlagCode = FlagCodes[idx];
                }

                string TmpWhere = " where Is_Sold = False";
                if (TmpFlagCode != null)
                {
                    TmpWhere += " and [Portfolio_Code] = '" + TmpFlagCode + "'";
                }
                TmpWhere += Main_Filter();

                //read the aggregate first, so no reader is open while prices are looked up
                List<string> Currs = new List<string>();
                Mdl1.Ssql = "select Full_Ticker, Max([Currency]) as Curr, Sum(Unit) as TotUnit,"
                          + " Sum(Real_Total_Cost_Base) as TotInv"
                          + " from TblETFStocksPurchase" + TmpWhere
                          + " group by Full_Ticker order by Full_Ticker";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Position TmpPos = new Position();
                    TmpPos.Ticker = reader["Full_Ticker"].ToString().Trim();
                    TmpPos.Units = Read_Double(reader["TotUnit"]);
                    TmpPos.Investment = Read_Double(reader["TotInv"]);
                    Positions.Add(TmpPos);
                    Currs.Add(reader["Curr"] == DBNull.Value ? "" : reader["Curr"].ToString().Trim());
                }
                reader.Close();

                //every amount into AUD before anything is derived from it
                for (int i = 0; i < Positions.Count; i++)
                {
                    Position TmpPos = Positions[i];
                    double TmpRawPrice;
                    string TmpPriceCurr;
                    TmpPos.Priced = Get_Latest_Price(TmpPos.Ticker, out TmpRawPrice, out TmpPriceCurr);
                    TmpPos.Investment = Math.Round(To_AUD(TmpPos.Investment, Currs[i]), 2);
                    if (TmpPos.Priced)
                    {
                        TmpPos.Price = Math.Round(To_AUD(TmpRawPrice, TmpPriceCurr), 4);
                        TmpPos.Current = Math.Round(TmpPos.Units * TmpPos.Price, 2);
                        PortfolioCurrent += TmpPos.Current;
                    }
                }

                //the share is of the whole portfolio's current amount, as the summary's
                //"Percentage from whole portfolio" is
                foreach (Position TmpPos in Positions)
                {
                    TmpPos.Share = (PortfolioCurrent > 0 ? TmpPos.Current / PortfolioCurrent * 100 : 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Clear_Grid()
        {
            gvSummary.Rows.Clear();
            gvSummary.Columns.Clear();
            gvSummary.ColumnCount = 6;
            string[] names = new string[] { "Full Ticker", "Total Unit", "Total Investment", "Current Price",
                                            "Total Current Amount", "Percentage from whole portfolio" };
            int[] weights = new int[] { 16, 14, 17, 15, 18, 20 };
            for (int i = 0; i < 6; i++)
            {
                gvSummary.Columns[i].Name = names[i];
                gvSummary.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign = (i == 0 ? DataGridViewContentAlignment.MiddleLeft
                                                                : DataGridViewContentAlignment.MiddleRight);
                gvSummary.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvSummary.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        //Shows the holdings the dropdown leaves in view, with their totals.  The top holdings
        //belonged to whatever was in view when they were looked up, so they go.
        private void Show_Grid()
        {
            Clear_Grid();
            Clear_Top_Grid();

            List<Position> TmpView = In_View();
            double TmpInvestment = 0;
            double TmpCurrent = 0;
            double TmpShare = 0;
            int Unpriced = 0;

            foreach (Position TmpPos in TmpView)
            {
                if (TmpPos.Priced)
                {
                    gvSummary.Rows.Add(new string[] { TmpPos.Ticker, TmpPos.Units.ToString("#,##0.0000"),
                                                      Money(TmpPos.Investment), Money(TmpPos.Price),
                                                      Money(TmpPos.Current), Percent(TmpPos.Share) });
                    TmpCurrent += TmpPos.Current;
                    TmpShare += TmpPos.Share;
                }
                else
                {
                    //no price on record - the derived figures are unknown, not zero
                    gvSummary.Rows.Add(new string[] { TmpPos.Ticker, TmpPos.Units.ToString("#,##0.0000"),
                                                      Money(TmpPos.Investment), "-", "-", "-" });
                    Unpriced++;
                }
                TmpInvestment += TmpPos.Investment;
            }
            gvSummary.ClearSelection();

            LblTotInv.Text = Money(TmpInvestment);
            LblTotCur.Text = Money(TmpCurrent);
            LblTotShare.Text = Percent(TmpShare);
            LblCurrency.Text = "All amounts are in Australian Dollar (" + PageCurr + "), at "
                             + DateTime.Now.ToString("MMM yyyy", new CultureInfo("en-AU")) + " rates";

            string TmpFlagCode = (CmbPortfolio.SelectedIndex > 0 && CmbPortfolio.SelectedIndex < FlagCodes.Count
                                  ? FlagCodes[CmbPortfolio.SelectedIndex] : null);
            string TmpNote = "Unsold holdings only"
                           + (TmpFlagCode == null ? "" : "  (portfolio " + TmpFlagCode + ")")
                           + (chkMainOnly.Checked ? "  (main portfolios only)" : "")
                           + (All_Tickers() ? "" : "  (" + CmbTicker.Text.Trim() + " only - its top holdings are of its own"
                                                   + " Total Current Amount)");
            if (Unpriced > 0)
            {
                TmpNote = TmpNote + "   -   " + Unpriced.ToString()
                        + " holding(s) have no price, so no current amount, and are not looked through";
            }
            LblNote.Text = TmpNote + Rate_Note();
        }

        //---- the top holdings ------------------------------------------------------

        private void Clear_Top_Grid()
        {
            gvTop.Rows.Clear();
            gvTop.Columns.Clear();
            gvTop.ColumnCount = 6;
            string[] names = new string[] { "Rank", "Symbol", "Company", "Allocation (%)",
                                            "Allocation (AUD)", "Held Through" };
            int[] weights = new int[] { 7, 12, 28, 12, 14, 50 };
            for (int i = 0; i < 6; i++)
            {
                gvTop.Columns[i].Name = names[i];
                gvTop.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                if (i == 0)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (i == 3 || i == 4)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleRight;
                }
                gvTop.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvTop.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
            LblTotTopPct.Text = Percent(0);
            LblTotTopAud.Text = Money(0);
            LblTopNote.Text = "Click Get Top 10 Holdings to look up the companies "
                            + (All_Tickers() ? "this portfolio" : CmbTicker.Text.Trim())
                            + " holds, through each fund.";
        }

        //what is being asked, shown while the page waits on the network
        private void Say(string parText)
        {
            LblTopNote.Text = parText;
            LblTopNote.Refresh();
        }

        private void Busy(bool parBusy)
        {
            System.Windows.Forms.Cursor.Current = (parBusy ? Cursors.WaitCursor : Cursors.Default);
            CmdTop.Enabled = !parBusy;
            CmdExcel.Enabled = !parBusy;
            CmdBack.Enabled = !parBusy;
            CmbPortfolio.Enabled = !parBusy;
            CmbTicker.Enabled = !parBusy;
            chkMainOnly.Enabled = !parBusy;
        }

        //Each priced holding in view goes to Holdings_Lookup with a share and its Total Current
        //Amount, so every company comes back with both - a percentage and the AUD it amounts to.
        //On All the share is the holding's part of the whole portfolio.  With one ticker chosen
        //the question is what that holding is made of, so it goes in as the whole - 100 % - and
        //each company's percentage is its weight in that ticker, of that ticker's own amount.
        private void CmdTop_Click(object sender, EventArgs e)
        {
            bool WholePortfolio = All_Tickers();
            List<Holdings_Lookup.Input> Items = new List<Holdings_Lookup.Input>();
            foreach (Position TmpPos in In_View())
            {
                //an unpriced holding has no current amount, so nothing to spread
                if (!TmpPos.Priced || TmpPos.Current <= 0)
                {
                    continue;
                }
                Holdings_Lookup.Input Item = new Holdings_Lookup.Input();
                Item.FullTicker = TmpPos.Ticker;
                Item.Allocation = (WholePortfolio ? TmpPos.Share : 100);
                Item.Amount = TmpPos.Current;
                Items.Add(Item);
            }
            if (Items.Count == 0)
            {
                MessageBox.Show("There is no priced holding in view to look through.", "Error Message");
                return;
            }

            Clear_Top_Grid();
            Busy(true);

            try
            {
                string TmpError;
                Holdings_Lookup.Result Outcome = new Holdings_Lookup().Run(Items, Say, out TmpError);
                if (Outcome == null)
                {
                    LblTopNote.Text = TmpError;
                    MessageBox.Show(TmpError, "Error Message");
                    return;
                }

                List<Holdings_Lookup.Company> Top = Outcome.Top();
                double TmpTopPct = 0;
                double TmpTopAud = 0;
                for (int i = 0; i < Top.Count; i++)
                {
                    //rounded before they are added, so each total is its column as shown, added up
                    double TmpPct = Math.Round(Top[i].Allocation, 2);
                    double TmpAud = Math.Round(Top[i].Amount, 2);
                    gvTop.Rows.Add(new string[] {
                        (i + 1).ToString(),
                        Top[i].Symbol,
                        Top[i].Name,
                        Percent(TmpPct),
                        Money(TmpAud),
                        String.Join(", ", Top[i].Via.ToArray()) });
                    TmpTopPct += TmpPct;
                    TmpTopAud += TmpAud;
                }
                gvTop.ClearSelection();
                LblTotTopPct.Text = Percent(Math.Round(TmpTopPct, 2));
                LblTotTopAud.Text = Money(Math.Round(TmpTopAud, 2));

                LblTopNote.Text = (WholePortfolio
                                   ? Outcome.Describe("the portfolio")
                                     + "  Allocation (AUD) is each holding's Total Current Amount spread by the same weights."
                                   : Outcome.Describe(CmbTicker.Text.Trim())
                                     + "  Allocation (%) and (AUD) are of " + CmbTicker.Text.Trim()
                                     + "'s own Total Current Amount, not the whole portfolio.");
            }
            catch (Exception ex)
            {
                LblTopNote.Text = "";
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                Busy(false);
            }
        }

        //---- the Excel export ------------------------------------------------------

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr parHwnd, out int parProcessId);

        private string Safe_Name(string parText)
        {
            string s = (parText == null ? "" : parText.Trim());
            if (s == "")
            {
                s = "none";
            }
            char[] bad = Path.GetInvalidFileNameChars();
            for (int i = 0; i < bad.Length; i++)
            {
                s = s.Replace(bad[i].ToString(), "");
            }
            return s;
        }

        private string[] Line(int parCols, string parA, string parB)
        {
            string[] r = new string[parCols];
            for (int i = 0; i < parCols; i++)
            {
                r[i] = "";
            }
            r[0] = parA;
            if (parCols > 1)
            {
                r[1] = parB;
            }
            return r;
        }

        private string[] Line(int parCols, string parA)
        {
            return Line(parCols, parA, "");
        }

        private string[] Line(int parCols)
        {
            return Line(parCols, "", "");
        }

        private string Cell(DataGridView parGrid, int parRow, int parCol)
        {
            object v = parGrid.Rows[parRow].Cells[parCol].Value;
            return (v == null ? "" : v.ToString());
        }

        //One row of a grid as a sheet line, padded out to the sheet's width.  Row -1 is the
        //column headings.
        private string[] Grid_Row(DataGridView parGrid, int parRow, int parCols)
        {
            string[] r = Line(parCols);
            for (int c = 0; c < parGrid.Columns.Count && c < parCols; c++)
            {
                r[c] = (parRow < 0 ? parGrid.Columns[c].Name : Cell(parGrid, parRow, c));
            }
            return r;
        }

        //Both tables go into the one sheet: the top holdings are only meaningful beside the
        //holdings they were worked out from.
        private void CmdExcel_Click(object sender, EventArgs e)
        {
            if (gvTop.Rows.Count == 0)
            {
                MessageBox.Show("Click Get Top 10 Holdings first - there is nothing to export yet.", "Error Message");
                return;
            }

            //The form's own Name leads the file name, so an export says which page it came from.
            string TmpName = Safe_Name(this.Name)
                           + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                           + "_" + Safe_Name(CmbPortfolio.Text)
                           + "_" + (chkMainOnly.Checked ? "Yes" : "No")
                           + "_" + Safe_Name(CmbTicker.Text) + ".xlsx";

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Generate to Excel";
            dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            dlg.FileName = TmpName;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //lay the whole sheet out first, so Excel is only asked to do one write
            int Cols = 6;
            List<string[]> Sheet = new List<string[]>();
            Sheet.Add(Line(Cols, "ETF/Stock Portfolio Top Holdings"));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Portfolio", CmbPortfolio.Text.Trim()));
            Sheet.Add(Line(Cols, "Main Only", (chkMainOnly.Checked ? "Yes" : "No")));
            Sheet.Add(Line(Cols, "Full Ticker", CmbTicker.Text.Trim()));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            Sheet.Add(Line(Cols, "Note", LblNote.Text.Trim()));
            Sheet.Add(Line(Cols, "Currency", LblCurrency.Text.Trim()));
            Sheet.Add(Line(Cols, "Basis", LblTopNote.Text.Trim()));
            Sheet.Add(Line(Cols));

            int TotalsFrom = Sheet.Count + 1;
            Sheet.Add(Line(Cols, LblTotInvCap.Text.Trim(), LblTotInv.Text.Trim()));
            Sheet.Add(Line(Cols, LblTotCurCap.Text.Trim(), LblTotCur.Text.Trim()));
            Sheet.Add(Line(Cols, LblTotShareCap.Text.Trim(), LblTotShare.Text.Trim()));
            int TotalsTo = Sheet.Count;
            Sheet.Add(Line(Cols));

            List<int> Heads = new List<int>();
            Heads.Add(Sheet.Count + 1);
            Sheet.Add(Grid_Row(gvSummary, -1, Cols));
            for (int r = 0; r < gvSummary.Rows.Count; r++)
            {
                Sheet.Add(Grid_Row(gvSummary, r, Cols));
            }
            Sheet.Add(Line(Cols));

            Heads.Add(Sheet.Count + 1);
            Sheet.Add(Grid_Row(gvTop, -1, Cols));
            for (int r = 0; r < gvTop.Rows.Count; r++)
            {
                Sheet.Add(Grid_Row(gvTop, r, Cols));
            }

            //each total under the column it adds up
            int TopTotalRow = Sheet.Count + 1;
            string[] TmpTopTotal = Line(Cols, "Total Allocation");
            TmpTopTotal[3] = LblTotTopPct.Text.Trim();
            TmpTopTotal[4] = LblTotTopAud.Text.Trim();
            Sheet.Add(TmpTopTotal);

            object[,] Data = new object[Sheet.Count, Cols];
            for (int r = 0; r < Sheet.Count; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Data[r, c] = Sheet[r][c];
                }
            }

            Busy(true);

            Excel.Application app = null;
            Excel.Workbooks books = null;
            Excel.Workbook wb = null;
            Excel.Sheets sheets = null;
            Excel.Worksheet ws = null;
            Excel.Range all = null;
            Excel.Range one = null;
            Excel.Range cols = null;
            int ExcelPid = 0;

            try
            {
                app = new Excel.Application();
                app.Visible = false;
                app.DisplayAlerts = false;
                GetWindowThreadProcessId(new IntPtr(app.Hwnd), out ExcelPid);

                books = app.Workbooks;
                wb = books.Add();
                sheets = wb.Worksheets;
                ws = (Excel.Worksheet)sheets[1];
                ws.Name = "Portfolio Top Holdings";

                all = ws.Range[ws.Cells[1, 1], ws.Cells[Sheet.Count, Cols]];
                //Written as text on purpose, so "$1,234.56" and "12.34 %" stay what the screen
                //shows rather than being re-read by Excel.
                all.NumberFormat = "@";
                all.Value2 = Data;

                one = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                one.Font.Bold = true;
                one.Font.Size = 14;
                Marshal.ReleaseComObject(one);
                one = null;

                one = ws.Range[ws.Cells[TotalsFrom, 1], ws.Cells[TotalsTo, 2]];
                one.Font.Bold = true;
                Marshal.ReleaseComObject(one);
                one = null;

                foreach (int HeadRow in Heads)
                {
                    one = ws.Range[ws.Cells[HeadRow, 1], ws.Cells[HeadRow, Cols]];
                    one.Font.Bold = true;
                    one.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                    Marshal.ReleaseComObject(one);
                    one = null;
                }

                one = ws.Range[ws.Cells[TopTotalRow, 1], ws.Cells[TopTotalRow, Cols]];
                one.Font.Bold = true;
                Marshal.ReleaseComObject(one);
                one = null;

                cols = ws.Columns;
                cols.AutoFit();

                wb.SaveAs(dlg.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook);
                wb.Close(false);
                app.Quit();

                MessageBox.Show("Excel file generated :" + Environment.NewLine + dlg.FileName, "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate the Excel file : " + ex.Message, "Error Message");
            }
            finally
            {
                if (one != null) { Marshal.ReleaseComObject(one); }
                if (cols != null) { Marshal.ReleaseComObject(cols); }
                if (all != null) { Marshal.ReleaseComObject(all); }
                if (ws != null) { Marshal.ReleaseComObject(ws); }
                if (sheets != null) { Marshal.ReleaseComObject(sheets); }
                if (wb != null) { Marshal.ReleaseComObject(wb); }
                if (books != null) { Marshal.ReleaseComObject(books); }
                if (app != null) { Marshal.ReleaseComObject(app); }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Kill_Excel(ExcelPid);
                Busy(false);
            }
        }

        //Quit does not always end the process; this is the backstop so exports cannot pile up
        //invisible copies of Excel.
        private void Kill_Excel(int parPid)
        {
            if (parPid <= 0)
            {
                return;
            }
            try
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessById(parPid);
                if (!proc.HasExited)
                {
                    proc.Kill();
                }
                proc.Dispose();
            }
            catch (Exception)
            {
                //already gone, which is the outcome we wanted anyway
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
