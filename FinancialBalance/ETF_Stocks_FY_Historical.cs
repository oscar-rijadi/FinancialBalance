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
    public partial class ETF_Stocks_FY_Historical : Form
    {
        bool Filling;

        //the portfolio code behind each entry of CmbPortfolio; null in the "All" slot
        List<string> PortfolioCodes = new List<string>();

        //The twelve aggregates, in the order they were asked for.  Kept as a table rather than
        //twelve variables so the labels, the colouring and the Excel sheet all walk the same
        //list and cannot drift apart.
        List<string> AggCaps = new List<string>();
        List<string> AggVals = new List<string>();
        List<double> AggNums = new List<double>();
        List<bool> AggColour = new List<bool>();

        public ETF_Stocks_FY_Historical()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_FY_Historical_Load(object sender, EventArgs e)
        {
            Filling = true;
            Clear_Grid();
            Fill_Financial_Year();
            Fill_Portfolio();
            Filling = false;

            Get_Data();
        }

        //---- the filters ---------------------------------------------------------

        //Most recently closed year first, which is the one usually being looked at.  There is
        //no "All" here: a row is a portfolio's result for one year, and stacking several years
        //into one table would put the same portfolio in it more than once.
        private void Fill_Financial_Year()
        {
            CmbFinYear.Items.Clear();

            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFinYear.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();

            if (CmbFinYear.Items.Count > 0)
            {
                CmbFinYear.SelectedIndex = 0;
            }
        }

        //Main Only narrows the list itself, so a non-main portfolio cannot be chosen while it
        //is ticked - otherwise the page would show an empty table with no explanation.
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

        private void CmbFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void CmbPortfolio_SelectedIndexChanged(object sender, EventArgs e)
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

        private string Selected_Portfolio_Code()
        {
            int idx = CmbPortfolio.SelectedIndex;
            if (idx < 0 || idx >= PortfolioCodes.Count)
            {
                return null;
            }
            return PortfolioCodes[idx];
        }

        private string Portfolio_Filter()
        {
            string TmpCode = Selected_Portfolio_Code();
            if (TmpCode != null)
            {
                return " and [Portfolio_Code] = '" + TmpCode + "'";
            }
            //"All" still respects Main Only, and a row carrying no code at all belongs to no
            //main portfolio, so it drops out with the rest.
            if (chkMainOnly.Checked)
            {
                return " and [Portfolio_Code] In (select Portfolio_Code from TblETFStocksPortfolioCode where [Is_Main] = True)";
            }
            return "";
        }

        //---- formatting ----------------------------------------------------------

        //AUD and USD are shown with a dollar sign; any other currency stays bare.
        //A negative reads -$12.34 rather than $-12.34.
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

        //---- the table -----------------------------------------------------------

        //The same sixteen columns as ETF/Stock Financial Year Reconciliation, so the two pages
        //read alike.  This one is an inquiry: it only ever reads.
        private void Clear_Grid()
        {
            gvHist.Rows.Clear();
            gvHist.Columns.Clear();

            string[] names = new string[] {
                "Financial Year", "Portfolio Code", "Currency",
                "Previous Investment", "Ending Investment", "On Paper Ending Value",
                "On Paper Profit/Loss", "Percentage On Paper Profit/Loss",
                "Distribution/Dividend", "Distribution/Dividend Yield",
                "Distribution/Dividend Reinvested", "Distribution/Dividend Not Reinvested",
                "Capital Gains On Paper", "Real Capital Gains",
                "Real Profit/Loss", "Percentage Real Profit/Loss" };
            int[] weights = new int[] { 8, 7, 5, 9, 9, 10, 10, 11, 9, 10, 11, 12, 10, 9, 9, 10 };

            gvHist.ColumnCount = names.Length;
            for (int i = 0; i < names.Length; i++)
            {
                gvHist.Columns[i].Name = names[i];
                gvHist.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign;
                if (i == 0)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                }
                else if (i <= 2)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleRight;
                }
                gvHist.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvHist.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                gvHist.Rows.Clear();

                //the running totals behind the aggregate labels
                double TotEndInv = 0;
                double TotOnPaperVal = 0;
                double TotOnPaperPL = 0;
                double TotDD = 0;
                double TotDDYes = 0;
                double TotDDNo = 0;
                double TotCapPaper = 0;
                double TotCapReal = 0;
                double TotRealPL = 0;
                List<string> Currencies = new List<string>();

                string TmpYear = CmbFinYear.Text.Trim();
                if (TmpYear != "")
                {
                    Mdl1.Ssql = "select [Financial_Year], [Portfolio_Code], [Currency], [Previous_Investment],"
                              + " [Ending_Investment], [On_Paper_Ending_Value], [On_Paper_Profit_Or_Loss],"
                              + " [Percentage_On_Paper_Profit_Or_Loss], [Total_DistributionDividend],"
                              + " [Total_DistributionDividend_Yield], [Total_DistributionDividend_Reinvested],"
                              + " [Total_DistributionDividend_Not_Reinvested], [Capital_Gains_On_Paper],"
                              + " [Real_Capital_Gains], [Real_Profit_Or_Loss], [Percentage_Real_Profit_Or_Loss]"
                              + " from TblETFStocksFinancialYear"
                              + " where [Financial_Year] = '" + TmpYear + "'"
                              + Portfolio_Filter()
                              + " order by [Portfolio_Code]";
                    OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string TmpCode = Read_Text(reader["Portfolio_Code"]);
                        //the row carries its own currency, so nothing has to be inferred
                        string TmpCurr = Read_Text(reader["Currency"]);

                        double TmpEndInv = Read_Double(reader["Ending_Investment"]);
                        double TmpOnPaperVal = Read_Double(reader["On_Paper_Ending_Value"]);
                        double TmpOnPaperPL = Read_Double(reader["On_Paper_Profit_Or_Loss"]);
                        double TmpOnPaperPct = Read_Double(reader["Percentage_On_Paper_Profit_Or_Loss"]);
                        double TmpDD = Read_Double(reader["Total_DistributionDividend"]);
                        double TmpDDYes = Read_Double(reader["Total_DistributionDividend_Reinvested"]);
                        double TmpDDNo = Read_Double(reader["Total_DistributionDividend_Not_Reinvested"]);
                        double TmpCapPaper = Read_Double(reader["Capital_Gains_On_Paper"]);
                        double TmpCapReal = Read_Double(reader["Real_Capital_Gains"]);
                        double TmpRealPL = Read_Double(reader["Real_Profit_Or_Loss"]);
                        double TmpRealPct = Read_Double(reader["Percentage_Real_Profit_Or_Loss"]);

                        gvHist.Rows.Add(new string[] {
                            Read_Text(reader["Financial_Year"]),
                            TmpCode,
                            (TmpCurr == "" ? "-" : TmpCurr),
                            Money(Read_Double(reader["Previous_Investment"]), TmpCurr),
                            Money(TmpEndInv, TmpCurr),
                            Money(TmpOnPaperVal, TmpCurr),
                            Money(TmpOnPaperPL, TmpCurr),
                            Percent(TmpOnPaperPct),
                            Money(TmpDD, TmpCurr),
                            Percent(Read_Double(reader["Total_DistributionDividend_Yield"])),
                            Money(TmpDDYes, TmpCurr),
                            Money(TmpDDNo, TmpCurr),
                            Money(TmpCapPaper, TmpCurr),
                            Money(TmpCapReal, TmpCurr),
                            Money(TmpRealPL, TmpCurr),
                            Percent(TmpRealPct) });

                        DataGridViewRow Row = gvHist.Rows[gvHist.Rows.Count - 1];
                        Colour_Cell(Row.Cells[6], TmpOnPaperPL);
                        Colour_Cell(Row.Cells[7], TmpOnPaperPct);
                        Colour_Cell(Row.Cells[12], TmpCapPaper);
                        Colour_Cell(Row.Cells[13], TmpCapReal);
                        Colour_Cell(Row.Cells[14], TmpRealPL);
                        Colour_Cell(Row.Cells[15], TmpRealPct);

                        TotEndInv += TmpEndInv;
                        TotOnPaperVal += TmpOnPaperVal;
                        TotOnPaperPL += TmpOnPaperPL;
                        TotDD += TmpDD;
                        TotDDYes += TmpDDYes;
                        TotDDNo += TmpDDNo;
                        TotCapPaper += TmpCapPaper;
                        TotCapReal += TmpCapReal;
                        TotRealPL += TmpRealPL;
                        if (TmpCurr != "" && !Currencies.Contains(TmpCurr))
                        {
                            Currencies.Add(TmpCurr);
                        }
                    }
                    reader.Close();
                }

                gvHist.ClearSelection();
                Filling = false;

                Build_Totals(TotEndInv, TotOnPaperVal, TotOnPaperPL, TotDD, TotDDYes, TotDDNo,
                             TotCapPaper, TotCapReal, TotRealPL, Currencies);
                Show_Totals();
                Show_Note();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the aggregates ------------------------------------------------------

        //A dollar sign is only put on a total when every row that fed it shares one dollar
        //currency.  Adding AUD to USD does not produce an amount in either, so a mixed
        //selection is left bare rather than labelled with a currency it is not in.
        private string One_Currency(List<string> parCurrencies)
        {
            return (parCurrencies.Count == 1 ? parCurrencies[0] : "");
        }

        private double Percent_Of_Ending(double parValue, double parEnding)
        {
            if (parEnding > 0)
            {
                return Math.Round(parValue / parEnding * 100, 2);
            }
            return 0;
        }

        private void Add_Money(string parCaption, double parValue, string parCurr, bool parColour)
        {
            AggCaps.Add(parCaption);
            AggVals.Add(Money(parValue, parCurr));
            AggNums.Add(parValue);
            AggColour.Add(parColour);
        }

        private void Add_Percent(string parCaption, double parValue, bool parColour)
        {
            AggCaps.Add(parCaption);
            AggVals.Add(Percent(parValue));
            AggNums.Add(parValue);
            AggColour.Add(parColour);
        }

        private void Build_Totals(double parEndInv, double parOnPaperVal, double parOnPaperPL,
                                  double parDD, double parDDYes, double parDDNo,
                                  double parCapPaper, double parCapReal, double parRealPL,
                                  List<string> parCurrencies)
        {
            AggCaps.Clear();
            AggVals.Clear();
            AggNums.Clear();
            AggColour.Clear();

            string TmpCurr = One_Currency(parCurrencies);

            Add_Money("Total Ending Investment", parEndInv, TmpCurr, false);
            Add_Money("Total On Paper Ending Value", parOnPaperVal, TmpCurr, false);
            Add_Money("Total On Paper Profit/Loss", parOnPaperPL, TmpCurr, true);
            Add_Percent("Percentage Total On Paper Profit/Loss",
                        Percent_Of_Ending(parOnPaperPL, parEndInv), true);
            Add_Money("Total Distribution/Dividend", parDD, TmpCurr, false);
            Add_Percent("Total Distribution/Dividend Yield",
                        Percent_Of_Ending(parDD, parEndInv), false);
            Add_Money("Total Distribution/Dividend Reinvested", parDDYes, TmpCurr, false);
            Add_Money("Total Distribution/Dividend Not Reinvested", parDDNo, TmpCurr, false);
            Add_Money("Total Capital Gains On Paper", parCapPaper, TmpCurr, false);
            Add_Money("Total Real Capital Gains", parCapReal, TmpCurr, false);
            Add_Money("Total Real Profit/Loss", parRealPL, TmpCurr, true);
            Add_Percent("Percentage Real Profit/Loss",
                        Percent_Of_Ending(parRealPL, parEndInv), true);
        }

        private Label[] Agg_Caps()
        {
            return new Label[] { LblAgg1Cap, LblAgg2Cap, LblAgg3Cap, LblAgg4Cap, LblAgg5Cap,
                                 LblAgg6Cap, LblAgg7Cap, LblAgg8Cap, LblAgg9Cap, LblAgg10Cap,
                                 LblAgg11Cap, LblAgg12Cap };
        }

        private Label[] Agg_Vals()
        {
            return new Label[] { LblAgg1, LblAgg2, LblAgg3, LblAgg4, LblAgg5, LblAgg6,
                                 LblAgg7, LblAgg8, LblAgg9, LblAgg10, LblAgg11, LblAgg12 };
        }

        //The figures were asked for on the "All" view only.  Picking one portfolio puts them
        //away rather than repeating that portfolio's own row back at the user.
        private bool Totals_Wanted()
        {
            return (Selected_Portfolio_Code() == null);
        }

        private void Show_Totals()
        {
            Label[] Caps = Agg_Caps();
            Label[] Vals = Agg_Vals();
            bool Wanted = Totals_Wanted();

            for (int i = 0; i < Caps.Length; i++)
            {
                bool Used = (Wanted && i < AggCaps.Count);
                Caps[i].Visible = Used;
                Vals[i].Visible = Used;
                if (!Used)
                {
                    continue;
                }
                Caps[i].Text = AggCaps[i];
                Vals[i].Text = AggVals[i];
                if (AggColour[i])
                {
                    Colour_Label(Vals[i], AggNums[i]);
                }
                else
                {
                    Vals[i].ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        //Says what is narrowing the table, so an empty one is explainable
        private void Show_Note()
        {
            string TmpText = gvHist.Rows.Count.ToString() + " row(s)";
            if (CmbFinYear.Items.Count == 0)
            {
                TmpText = "No financial year has been set up yet - see Financial Year Setup.";
            }
            else if (chkMainOnly.Checked)
            {
                TmpText = TmpText + "   -   main portfolios only";
            }
            LblNote.Text = TmpText;
        }

        //---- Excel ---------------------------------------------------------------

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

        //The form's own Name leads the file name, so an export says which page it came from
        //before anything else.  Taken from this.Name rather than typed out, so it cannot drift
        //from the form it belongs to.  parExtension carries the dot.
        private string Export_Name(string parExtension)
        {
            return Safe_Name(this.Name)
                 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                 + "_" + Safe_Name(CmbFinYear.Text)
                 + "_" + Safe_Name(CmbPortfolio.Text)
                 + "_" + (chkMainOnly.Checked ? "Yes" : "No") + parExtension;
        }

        //The whole sheet as a rectangle of strings, laid out before anything is asked to write
        //it.  Both exports go through here, so the workbook and the Google Sheet are the same
        //sheet by construction rather than by two lots of layout code agreeing.
        private List<string[]> Build_Sheet(out int parCols, out int parTotalsFrom,
                                           out int parTotalsTo, out int parHeadRow)
        {
            int Cols = gvHist.Columns.Count;
            if (Cols < 2)
            {
                Cols = 2;
            }

            List<string[]> Sheet = new List<string[]>();
            Sheet.Add(Line(Cols, "ETF/Stock Financial Year Historical"));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Financial Year", CmbFinYear.Text.Trim()));
            Sheet.Add(Line(Cols, "Portfolio", CmbPortfolio.Text.Trim()));
            Sheet.Add(Line(Cols, "Main Only", (chkMainOnly.Checked ? "Yes" : "No")));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            if (LblNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Note", LblNote.Text.Trim()));
            }
            Sheet.Add(Line(Cols));

            //the aggregates sit above the table, and only when they are on screen
            parTotalsFrom = Sheet.Count + 1;
            parTotalsTo = Sheet.Count;
            if (Totals_Wanted())
            {
                for (int i = 0; i < AggCaps.Count; i++)
                {
                    Sheet.Add(Line(Cols, AggCaps[i], AggVals[i]));
                }
                parTotalsTo = Sheet.Count;
                Sheet.Add(Line(Cols));
            }

            parHeadRow = Sheet.Count + 1;
            string[] head = new string[Cols];
            for (int c = 0; c < gvHist.Columns.Count; c++)
            {
                head[c] = gvHist.Columns[c].Name;
            }
            Sheet.Add(head);

            for (int r = 0; r < gvHist.Rows.Count; r++)
            {
                string[] line = new string[Cols];
                for (int c = 0; c < gvHist.Columns.Count; c++)
                {
                    object v = gvHist.Rows[r].Cells[c].Value;
                    line[c] = (v == null ? "" : v.ToString());
                }
                Sheet.Add(line);
            }

            parCols = Cols;
            return Sheet;
        }

        //Everything from here down is the Excel half, taking where to write as a parameter so the
        //Drive button can send it to a temporary file instead of one the user chose.  Throws
        //rather than reporting: the callers differ in what they say afterwards.
        //
        //One sheet, not a list of them.  This page shows one financial year at a time and there
        //is no second view of it to put on a tab of its own.
        private void Write_Workbook(List<string[]> parSheet, int parCols, int parTotalsFrom,
                                    int parTotalsTo, int parHeadRow, string parPath)
        {
            object[,] Data = new object[parSheet.Count, parCols];
            for (int r = 0; r < parSheet.Count; r++)
            {
                for (int c = 0; c < parCols; c++)
                {
                    Data[r, c] = parSheet[r][c];
                }
            }

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
                ws.Name = "FY Historical";

                all = ws.Range[ws.Cells[1, 1], ws.Cells[parSheet.Count, parCols]];
                //Written as text on purpose.  Left to itself Excel re-reads every value and
                //throws away the formatting the screen is showing : "-$76.05" comes back as
                //red "($76.05)", "12.34 %" turns into a fraction, and what is recognised as a
                //number at all depends on the machine's locale.  The export is meant to be
                //what the user is looking at, so the cells are kept exactly as displayed.
                all.NumberFormat = "@";
                all.Value2 = Data;

                one = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                one.Font.Bold = true;
                one.Font.Size = 14;
                Marshal.ReleaseComObject(one);
                one = null;

                if (parTotalsTo >= parTotalsFrom)
                {
                    one = ws.Range[ws.Cells[parTotalsFrom, 1], ws.Cells[parTotalsTo, 2]];
                    one.Font.Bold = true;
                    Marshal.ReleaseComObject(one);
                    one = null;
                }

                one = ws.Range[ws.Cells[parHeadRow, 1], ws.Cells[parHeadRow, parCols]];
                one.Font.Bold = true;
                one.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                Marshal.ReleaseComObject(one);
                one = null;

                cols = ws.Columns;
                cols.AutoFit();

                wb.SaveAs(parPath, Excel.XlFileFormat.xlOpenXMLWorkbook);
                wb.Close(false);
                app.Quit();
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
            }
        }

        //---- the two export buttons -----------------------------------------------
        //
        //Both build the same sheet. Excel asks where to put it and stops there; Drive writes it
        //to a temporary file and sends that on. Busy state is handled here rather than in
        //Write_Workbook because the two buttons disable different things.

        private void Busy(bool parBusy)
        {
            Cursor.Current = (parBusy ? Cursors.WaitCursor : Cursors.Default);
            CmdExcel.Enabled = !parBusy;
            CmdDrive.Enabled = !parBusy;
            CmdBack.Enabled = !parBusy;
        }

        private bool Anything_To_Export()
        {
            if (gvHist.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing on screen to export.", "Error Message");
                return false;
            }
            return true;
        }

        private void CmdExcel_Click(object sender, EventArgs e)
        {
            if (!Anything_To_Export())
            {
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Generate Excel";
            dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            dlg.FileName = Export_Name(".xlsx");
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            int TmpCols;
            int TmpFrom;
            int TmpTo;
            int TmpHead;
            List<string[]> TmpSheet = Build_Sheet(out TmpCols, out TmpFrom, out TmpTo, out TmpHead);

            Busy(true);
            try
            {
                Write_Workbook(TmpSheet, TmpCols, TmpFrom, TmpTo, TmpHead, dlg.FileName);
                MessageBox.Show("Excel file generated :" + Environment.NewLine + dlg.FileName, "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate the Excel file : " + ex.Message, "Error Message");
            }
            finally
            {
                Busy(false);
            }
        }

        //Builds the same workbook into a temporary file, signs in, uploads it as a Google Sheet
        //and throws the temporary file away. The user is never asked where to put it - that is
        //what the Excel button is for.
        private void CmdDrive_Click(object sender, EventArgs e)
        {
            if (!Anything_To_Export())
            {
                return;
            }
            if (!Google_Drive.Configured)
            {
                MessageBox.Show("Google Drive is not set up yet." + Environment.NewLine
                    + Environment.NewLine + Google_Drive.Setup_Hint(), "Error Message");
                return;
            }

            //The year is half the Sheet's name, so without one there is nothing to name the file
            //after.  Uploading anyway would put every year into a single Sheet called after the
            //prefix alone, each run overwriting the last.
            string TmpYear = CmbFinYear.Text.Trim();
            if (TmpYear == "")
            {
                MessageBox.Show("Choose a financial year first - it names the Google Sheet.",
                                "Error Message");
                return;
            }

            //One Sheet per financial year, reused: the prefix with the year on the end.  The
            //other two pages keep a single file each because what they show changes as figures
            //are entered; a closed year is a record, and rewriting last year's Sheet with this
            //year's figures would destroy it.
            string TmpTitle = Google_Drive.FY_Historical_Sheet_Name(TmpYear);
            string TmpPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(),
                                                    Export_Name("") + ".xlsx");
            string TmpOldNote = LblNote.Text;

            Busy(true);
            try
            {
                LblNote.Text = "Building the workbook ...";
                LblNote.Refresh();
                int TmpCols;
                int TmpFrom;
                int TmpTo;
                int TmpHead;
                List<string[]> TmpSheet = Build_Sheet(out TmpCols, out TmpFrom, out TmpTo,
                                                      out TmpHead);
                Write_Workbook(TmpSheet, TmpCols, TmpFrom, TmpTo, TmpHead, TmpPath);

                LblNote.Text = "Waiting for you to sign in to Google in your browser ...";
                LblNote.Refresh();
                string TmpWhy;
                string TmpToken = Google_Drive.Sign_In(out TmpWhy);
                if (TmpToken == null)
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                LblNote.Text = "Uploading to Google Drive ...";
                LblNote.Refresh();
                string TmpLink;
                bool TmpReplaced;
                int TmpDuplicates;
                string TmpHow;
                if (!Google_Drive.Upload(TmpToken, TmpPath, TmpTitle, out TmpLink, out TmpReplaced,
                                         out TmpDuplicates, out TmpHow, out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                //only one of a set of same-named Sheets is being kept up to date; saying so
                //beats letting the others quietly go stale
                string TmpWarning = "";
                if (TmpDuplicates > 1)
                {
                    TmpWarning = Environment.NewLine + Environment.NewLine
                               + TmpDuplicates.ToString() + " Sheets carry this name."
                               + Environment.NewLine
                               + "The most recently changed one was updated; the rest were left"
                               + " alone and will now be out of date.";
                }

                DialogResult Response = MessageBox.Show(
                    (TmpReplaced ? "Google Sheet updated :" : "Google Sheet created :")
                    + Environment.NewLine + TmpTitle
                    + Environment.NewLine + "(" + TmpHow + ")"
                    + TmpWarning
                    + Environment.NewLine + Environment.NewLine + TmpLink
                    + Environment.NewLine + Environment.NewLine + "Open it now ?",
                    "Success", MessageBoxButtons.YesNo);
                if (Response == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(TmpLink);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate to Google Drive : " + ex.Message, "Error Message");
            }
            finally
            {
                //the workbook was only ever a carrier for the upload
                try
                {
                    if (System.IO.File.Exists(TmpPath))
                    {
                        System.IO.File.Delete(TmpPath);
                    }
                }
                catch
                {
                    //a temp file left behind is not worth a second error on top of the first
                }
                LblNote.Text = TmpOldNote;
                Busy(false);
            }
        }

        //Quit does not always end the process; this is the backstop so exports cannot
        //pile up invisible copies of Excel.
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
