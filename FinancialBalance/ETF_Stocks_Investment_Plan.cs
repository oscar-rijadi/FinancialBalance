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
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinancialBalance
{
    public partial class ETF_Stocks_Investment_Plan : Form
    {
        bool Filling;

        //One pie per diversification type, drawn in this order - the same three the setup page
        //draws, from the same rows.
        static readonly string[] ChartTypes = new string[] { "Asset Class", "Geographic", "Investment Style" };

        public ETF_Stocks_Investment_Plan()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Investment_Plan_Load(object sender, EventArgs e)
        {
            Filling = true;
            Clear_Alloc_Grid();
            Clear_Amount_Grid();
            txtAmount.Text = "0.00";
            Fill_Plan();
            Filling = false;

            Get_Data();
        }

        //---- helpers ---------------------------------------------------------------

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

        //An allocation is a percentage, so it is shown with the sign after it
        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00") + " %";
        }

        //The investment amount is entered without a currency, so the amounts are shown as plain
        //two-decimal figures rather than being labelled with a sign the page cannot know.
        private string Amount(double parValue)
        {
            return Mdl1.FormatAmt(Math.Round(parValue, 2));
        }

        private string Quote(string parValue)
        {
            if (parValue == null)
            {
                return "";
            }
            return parValue.Replace("'", "''");
        }

        private double Box(TextBox parBox)
        {
            double TmpValue;
            double.TryParse(parBox.Text.Trim(), out TmpValue);
            return TmpValue;
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

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr parHwnd, out int parProcessId);

        //---- the plan --------------------------------------------------------------

        private void Fill_Plan()
        {
            CmbPlan.Items.Clear();
            Mdl1.Ssql = "select [Name] from TblETFStocksInvestmentPlan order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbPlan.Items.Add(Read_Text(reader["Name"]));
            }
            reader.Close();
            if (CmbPlan.Items.Count > 0)
            {
                CmbPlan.SelectedIndex = 0;
            }
        }

        private void CmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        //The plan's allocations, read once and used by the table, the amounts and the charts
        private List<KeyValuePair<string, double>> Read_Plan_Allocations(string parPlan)
        {
            List<KeyValuePair<string, double>> Rows = new List<KeyValuePair<string, double>>();
            if (parPlan == "")
            {
                return Rows;
            }
            Mdl1.Ssql = "select [Full_Ticker], [Allocation] from TblETFStocksInvestmentPlanAllocation"
                      + " where [Investment_Plan_Name] = '" + Quote(parPlan) + "'"
                      + " order by [Full_Ticker]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Rows.Add(new KeyValuePair<string, double>(
                    Read_Text(reader["Full_Ticker"]), Read_Double(reader["Allocation"])));
            }
            reader.Close();
            return Rows;
        }

        //---- the allocation table --------------------------------------------------

        private void Clear_Alloc_Grid()
        {
            gvAlloc.Rows.Clear();
            gvAlloc.Columns.Clear();
            gvAlloc.ColumnCount = 2;
            string[] names = new string[] { "Full Ticker", "Allocation" };
            int[] weights = new int[] { 60, 40 };
            for (int i = 0; i < 2; i++)
            {
                gvAlloc.Columns[i].Name = names[i];
                gvAlloc.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign =
                    (i == 0 ? DataGridViewContentAlignment.MiddleLeft : DataGridViewContentAlignment.MiddleRight);
                gvAlloc.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvAlloc.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        //---- the amount table ------------------------------------------------------

        private void Clear_Amount_Grid()
        {
            gvAmount.Rows.Clear();
            gvAmount.Columns.Clear();
            gvAmount.ColumnCount = 3;
            string[] names = new string[] { "Full Ticker", "Allocation", "Amount" };
            int[] weights = new int[] { 40, 27, 33 };
            for (int i = 0; i < 3; i++)
            {
                gvAmount.Columns[i].Name = names[i];
                gvAmount.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign =
                    (i == 0 ? DataGridViewContentAlignment.MiddleLeft : DataGridViewContentAlignment.MiddleRight);
                gvAmount.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvAmount.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //only the amounts depend on it; the allocations and the charts do not
            Show_Amounts();
        }

        //Each ticker's share of the investment:  (Allocation * Investment Amount) / 100
        private void Show_Amounts()
        {
            try
            {
                Filling = true;
                Clear_Amount_Grid();
                double TmpInvest = Box(txtAmount);
                double TmpTotal = 0;

                foreach (KeyValuePair<string, double> Alloc in Read_Plan_Allocations(CmbPlan.Text.Trim()))
                {
                    double TmpAmount = Math.Round(Alloc.Value * TmpInvest / 100, 2);
                    TmpTotal = TmpTotal + TmpAmount;
                    gvAmount.Rows.Add(new string[] {
                        Alloc.Key, Percent(Alloc.Value), Amount(TmpAmount) });
                }

                gvAmount.ClearSelection();
                Filling = false;

                //the total is the sum of the rows as shown, not the investment amount itself:
                //rounding each row to the cent can leave the two a cent or so apart, and the
                //figure under the column should be the column added up
                LblTotal.Text = Amount(Math.Round(TmpTotal, 2));
                if (gvAmount.Rows.Count == 0)
                {
                    LblNote2.Text = "Nothing to apportion.";
                }
                else
                {
                    LblNote2.Text = gvAmount.Rows.Count.ToString() + " row(s)";
                }
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- everything the plan drives --------------------------------------------

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Alloc_Grid();
                double TmpTotal = 0;

                foreach (KeyValuePair<string, double> Alloc in Read_Plan_Allocations(CmbPlan.Text.Trim()))
                {
                    TmpTotal = TmpTotal + Alloc.Value;
                    gvAlloc.Rows.Add(new string[] { Alloc.Key, Percent(Alloc.Value) });
                }

                gvAlloc.ClearSelection();
                Filling = false;

                TmpTotal = Math.Round(TmpTotal, 2);
                if (CmbPlan.Items.Count == 0)
                {
                    LblNote.Text = "No investment plans set up yet - add one in ETF/Stock Investment Plan Setup.";
                }
                else if (gvAlloc.Rows.Count == 0)
                {
                    LblNote.Text = "This investment plan has no allocations yet.";
                }
                else
                {
                    LblNote.Text = gvAlloc.Rows.Count.ToString() + " allocation(s), totalling "
                                 + Percent(TmpTotal);
                }

                Show_Chart(TmpTotal);
                Show_Amounts();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the diversification charts --------------------------------------------
        //
        //The same three pies the setup page draws, by the same calculation: each ticker's share
        //of the plan is split across that type's values in the proportions recorded against the
        //ticker, and the contributions are summed per name.
        //
        //    contribution = (Percentage / 100) * Allocation

        private Dictionary<string, Dictionary<string, List<KeyValuePair<string, double>>>> Read_Diversification()
        {
            Dictionary<string, Dictionary<string, List<KeyValuePair<string, double>>>> ByType =
                new Dictionary<string, Dictionary<string, List<KeyValuePair<string, double>>>>();
            foreach (string TmpType in ChartTypes)
            {
                ByType.Add(TmpType, new Dictionary<string, List<KeyValuePair<string, double>>>());
            }

            Mdl1.Ssql = "select [Full_Ticker], [Diversification_Type], [Diversification_Name], [Percentage]"
                      + " from TblETFStocksDiversificationAllocation"
                      + " order by [Full_Ticker], [Diversification_Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpTicker = Read_Text(reader["Full_Ticker"]);
                string TmpType = Read_Text(reader["Diversification_Type"]);
                //a type nothing is charted for is read past rather than kept
                if (TmpTicker == "" || !ByType.ContainsKey(TmpType))
                {
                    continue;
                }
                Dictionary<string, List<KeyValuePair<string, double>>> ByTicker = ByType[TmpType];
                if (!ByTicker.ContainsKey(TmpTicker))
                {
                    ByTicker.Add(TmpTicker, new List<KeyValuePair<string, double>>());
                }
                ByTicker[TmpTicker].Add(new KeyValuePair<string, double>(
                    Read_Text(reader["Diversification_Name"]), Read_Double(reader["Percentage"])));
            }
            reader.Close();
            return ByType;
        }

        //Names come back in the order they were first met, so the slices keep a stable order
        //rather than jumping about between refreshes.
        private void Slices_For(Dictionary<string, List<KeyValuePair<string, double>>> parByTicker,
                                List<KeyValuePair<string, double>> parAllocations,
                                out List<string> parNames, out List<double> parValues)
        {
            parNames = new List<string>();
            parValues = new List<double>();

            List<string> Order = new List<string>();
            Dictionary<string, double> Totals = new Dictionary<string, double>();
            double Covered = 0;

            foreach (KeyValuePair<string, double> Alloc in parAllocations)
            {
                if (!parByTicker.ContainsKey(Alloc.Key))
                {
                    continue;
                }
                foreach (KeyValuePair<string, double> Div in parByTicker[Alloc.Key])
                {
                    double Share = Div.Value / 100 * Alloc.Value;
                    if (!Totals.ContainsKey(Div.Key))
                    {
                        Totals.Add(Div.Key, 0);
                        Order.Add(Div.Key);
                    }
                    Totals[Div.Key] = Totals[Div.Key] + Share;
                    Covered = Covered + Share;
                }
            }

            foreach (string Name in Order)
            {
                parNames.Add(Name);
                parValues.Add(Math.Round(Totals[Name], 2));
            }

            //A ticker with no rows of this type, or one whose own percentages do not reach 100,
            //leaves part of the plan unaccounted for. Showing that as a slice is the same thing
            //ETF/Stock Portfolio Diversification does - a pie quietly totalling less than 100
            //would look complete when it is not.
            double Rest = Math.Round(100 - Covered, 2);
            if (Rest > 0)
            {
                parNames.Add("(unallocated)");
                parValues.Add(Rest);
            }
        }

        //Only drawn for a plan that has allocations and whose allocations total exactly 100 -
        //below that the picture would be of a plan that is not finished, and the shares would
        //not be out of a whole. The same rule the setup page applies.
        private void Show_Chart(double parTotal)
        {
            pnlChart.Controls.Clear();
            string TmpPlan = CmbPlan.Text.Trim();
            bool Wanted = (TmpPlan != "" && gvAlloc.Rows.Count > 0 && parTotal == 100);

            pnlChart.Visible = Wanted;
            LblChartNote.Visible = !Wanted;
            if (!Wanted)
            {
                LblChartNote.Text = "The charts appear once this plan's allocations total 100 %.";
                return;
            }

            //both tables are read once and then reused for all three charts
            Dictionary<string, Dictionary<string, List<KeyValuePair<string, double>>>> ByType =
                Read_Diversification();
            List<KeyValuePair<string, double>> Allocations = Read_Plan_Allocations(TmpPlan);

            foreach (string TmpType in ChartTypes)
            {
                List<string> Names;
                List<double> Values;
                Slices_For(ByType[TmpType], Allocations, out Names, out Values);
                pnlChart.Controls.Add(Build_Chart(TmpType, Names, Values));
            }
        }

        private Chart Build_Chart(string parTitle, List<string> parNames, List<double> parValues)
        {
            Chart ch = new Chart();
            //narrower than the 440 the Portfolio Diversification pies use: three of these stack
            //in a 460-wide column, so they have to clear its vertical scrollbar or the panel
            //grows a horizontal one as well
            ch.Width = 410;
            ch.Height = 300;
            ch.Margin = new Padding(8);
            ch.BackColor = System.Drawing.Color.Transparent;

            ChartArea ca = new ChartArea("ChartArea1");
            ca.BackColor = System.Drawing.Color.Transparent;
            ch.ChartAreas.Add(ca);

            Title ti = new Title(parTitle);
            ti.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            ti.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            ch.Titles.Add(ti);

            Legend le = new Legend("Legend1");
            le.Docking = Docking.Bottom;
            le.Font = new System.Drawing.Font("Arial", 8F);
            ch.Legends.Add(le);

            Series se = new Series("Allocation");
            se.ChartType = SeriesChartType.Pie;
            se.Legend = "Legend1";
            se.Font = new System.Drawing.Font("Arial", 8F);
            ch.Series.Add(se);

            for (int i = 0; i < parNames.Count; i++)
            {
                if (parValues[i] <= 0)
                {
                    continue;
                }
                int idx = se.Points.AddXY(parNames[i], Math.Round(parValues[i], 2));
                DataPoint pt = se.Points[idx];
                pt.LegendText = parNames[i] + "  " + parValues[i].ToString("#,##0.00") + " %";
                pt.Label = parValues[i].ToString("#,##0.0") + " %";
                pt.ToolTip = parNames[i] + " : " + parValues[i].ToString("#,##0.00") + " % of the plan";
                if (parNames[i] == "(unallocated)")
                {
                    pt.Color = System.Drawing.Color.Gainsboro;
                }
            }

            if (se.Points.Count == 0)
            {
                Title none = new Title("nothing allocated");
                none.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic);
                none.ForeColor = System.Drawing.Color.DimGray;
                none.Docking = Docking.Bottom;
                ch.Titles.Add(none);
            }

            return ch;
        }

        //---- the Excel export ------------------------------------------------------

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

        //Both tables go into the one sheet, since the second is the first applied to an amount
        //and they are read together.
        private void CmdExcel_Click(object sender, EventArgs e)
        {
            if (gvAmount.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing on screen to export.", "Error Message");
                return;
            }

            //The form's own Name leads the file name, so an export says which page it came from
            //before anything else. Taken from this.Name rather than typed out, so it cannot
            //drift from the form it belongs to.
            string TmpName = Safe_Name(this.Name)
                           + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
                           + "_" + Safe_Name(CmbPlan.Text)
                           + "_" + Safe_Name(txtAmount.Text) + ".xlsx";

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
            int Cols = 3;
            List<string[]> Sheet = new List<string[]>();
            Sheet.Add(Line(Cols, "ETF/Stock Investment Plan"));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Investment Plan", CmbPlan.Text.Trim()));
            Sheet.Add(Line(Cols, "Investment Amount", txtAmount.Text.Trim()));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            if (LblNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Note", LblNote.Text.Trim()));
            }
            Sheet.Add(Line(Cols));

            int Head1 = Sheet.Count + 1;
            Sheet.Add(new string[] { gvAlloc.Columns[0].Name, gvAlloc.Columns[1].Name, "" });
            for (int r = 0; r < gvAlloc.Rows.Count; r++)
            {
                Sheet.Add(new string[] { Cell(gvAlloc, r, 0), Cell(gvAlloc, r, 1), "" });
            }
            Sheet.Add(Line(Cols));

            int Head2 = Sheet.Count + 1;
            Sheet.Add(new string[] { gvAmount.Columns[0].Name, gvAmount.Columns[1].Name,
                                     gvAmount.Columns[2].Name });
            for (int r = 0; r < gvAmount.Rows.Count; r++)
            {
                Sheet.Add(new string[] { Cell(gvAmount, r, 0), Cell(gvAmount, r, 1), Cell(gvAmount, r, 2) });
            }

            int TotalRow = Sheet.Count + 1;
            Sheet.Add(new string[] { "Total Investment Amount", "", LblTotal.Text.Trim() });

            object[,] Data = new object[Sheet.Count, Cols];
            for (int r = 0; r < Sheet.Count; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Data[r, c] = Sheet[r][c];
                }
            }

            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            CmdExcel.Enabled = false;

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
                ws.Name = "Investment Plan";

                all = ws.Range[ws.Cells[1, 1], ws.Cells[Sheet.Count, Cols]];
                //Written as text on purpose. Left to itself Excel re-reads every value and
                //throws away the formatting the screen is showing : "12.34 %" turns into a
                //fraction, and what is recognised as a number at all depends on the machine's
                //locale. The export is meant to be what the user is looking at.
                all.NumberFormat = "@";
                all.Value2 = Data;

                one = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                one.Font.Bold = true;
                one.Font.Size = 14;
                Marshal.ReleaseComObject(one);
                one = null;

                foreach (int HeadRow in new int[] { Head1, Head2 })
                {
                    one = ws.Range[ws.Cells[HeadRow, 1], ws.Cells[HeadRow, Cols]];
                    one.Font.Bold = true;
                    one.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                    Marshal.ReleaseComObject(one);
                    one = null;
                }

                one = ws.Range[ws.Cells[TotalRow, 1], ws.Cells[TotalRow, Cols]];
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
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                CmdExcel.Enabled = true;
            }
        }

        private string Cell(DataGridView parGrid, int parRow, int parCol)
        {
            object v = parGrid.Rows[parRow].Cells[parCol].Value;
            return (v == null ? "" : v.ToString());
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
