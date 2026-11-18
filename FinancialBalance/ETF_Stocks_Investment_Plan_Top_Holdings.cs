using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinancialBalance
{
    //What an investment plan actually ends up owning once each fund is looked through.  The
    //plan supplies the tickers and their allocations; Holdings_Lookup does the looking, and
    //each company comes back with its share of the plan.
    //
    //Read-only: nothing on this page writes to the database.
    public partial class ETF_Stocks_Investment_Plan_Top_Holdings : Form
    {
        bool Filling;

        public ETF_Stocks_Investment_Plan_Top_Holdings()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Investment_Plan_Top_Holdings_Load(object sender, EventArgs e)
        {
            Filling = true;
            Clear_Alloc_Grid();
            Clear_Top_Grid();
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

        private string Quote(string parValue)
        {
            if (parValue == null)
            {
                return "";
            }
            return parValue.Replace("'", "''");
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

        //The plan's allocations, read once and used by the table and by the look-through
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

                //the holdings were looked up for whichever plan was showing then, so they go
                //rather than sit beside a plan they do not belong to
                Clear_Top_Grid();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the top holdings table ------------------------------------------------

        private void Clear_Top_Grid()
        {
            gvTop.Rows.Clear();
            gvTop.Columns.Clear();
            gvTop.ColumnCount = 5;
            string[] names = new string[] { "Rank", "Symbol", "Company", "Allocation", "Held Through" };
            int[] weights = new int[] { 8, 14, 30, 13, 55 };
            for (int i = 0; i < 5; i++)
            {
                gvTop.Columns[i].Name = names[i];
                gvTop.Columns[i].FillWeight = weights[i];
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleLeft;
                if (i == 0)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (i == 3)
                {
                    TmpAlign = DataGridViewContentAlignment.MiddleRight;
                }
                gvTop.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvTop.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
            LblTopNote.Text = "Click Get Top 10 Holding to look up the companies this plan holds, through"
                            + " each fund, on Yahoo Finance.";
        }

        private void Busy(bool parBusy)
        {
            System.Windows.Forms.Cursor.Current = (parBusy ? Cursors.WaitCursor : Cursors.Default);
            CmdTop.Enabled = !parBusy;
            CmdExcel.Enabled = !parBusy;
            CmdBack.Enabled = !parBusy;
            CmbPlan.Enabled = !parBusy;
        }

        //what is being asked, shown while the page waits on the network
        private void Say(string parText)
        {
            LblTopNote.Text = parText;
            LblTopNote.Refresh();
        }

        private void CmdTop_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, double>> Allocs = Read_Plan_Allocations(CmbPlan.Text.Trim());
            if (Allocs.Count == 0)
            {
                MessageBox.Show("This investment plan has no allocations to look through.", "Error Message");
                return;
            }

            Clear_Top_Grid();
            Busy(true);
            LblTopNote.Text = "Asking Yahoo Finance ...";
            LblTopNote.Refresh();

            try
            {
                List<Holdings_Lookup.Input> Items = new List<Holdings_Lookup.Input>();
                foreach (KeyValuePair<string, double> Alloc in Allocs)
                {
                    Holdings_Lookup.Input Item = new Holdings_Lookup.Input();
                    Item.FullTicker = Alloc.Key;
                    Item.Allocation = Alloc.Value;
                    Items.Add(Item);
                }

                string TmpError;
                Holdings_Lookup.Result Outcome = new Holdings_Lookup().Run(Items, Say, out TmpError);
                if (Outcome == null)
                {
                    LblTopNote.Text = TmpError;
                    MessageBox.Show(TmpError, "Error Message");
                    return;
                }

                List<Holdings_Lookup.Company> Top = Outcome.Top();
                for (int i = 0; i < Top.Count; i++)
                {
                    gvTop.Rows.Add(new string[] {
                        (i + 1).ToString(),
                        Top[i].Symbol,
                        Top[i].Name,
                        Percent(Top[i].Allocation),
                        String.Join(", ", Top[i].Via.ToArray()) });
                }
                gvTop.ClearSelection();

                LblTopNote.Text = Outcome.Describe("the plan");
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
        //allocations they were worked out from.
        private void CmdExcel_Click(object sender, EventArgs e)
        {
            if (gvTop.Rows.Count == 0)
            {
                MessageBox.Show("Click Get Top 10 Holding first - there is nothing to export yet.", "Error Message");
                return;
            }

            //The form's own Name leads the file name, so an export says which page it came from
            //before anything else. Taken from this.Name rather than typed out, so it cannot
            //drift from the form it belongs to.
            string TmpName = Safe_Name(this.Name)
                           + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                           + "_" + Safe_Name(CmbPlan.Text) + ".xlsx";

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
            int Cols = 5;
            List<string[]> Sheet = new List<string[]>();
            Sheet.Add(Line(Cols, "ETF/Stock Investment Plan Top Holdings"));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Investment Plan", CmbPlan.Text.Trim()));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            if (LblNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Note", LblNote.Text.Trim()));
            }
            if (LblTopNote.Text.Trim() != "")
            {
                Sheet.Add(Line(Cols, "Basis", LblTopNote.Text.Trim()));
            }
            Sheet.Add(Line(Cols));

            List<int> Heads = new List<int>();
            Heads.Add(Sheet.Count + 1);
            Sheet.Add(Grid_Row(gvAlloc, -1, Cols));
            for (int r = 0; r < gvAlloc.Rows.Count; r++)
            {
                Sheet.Add(Grid_Row(gvAlloc, r, Cols));
            }
            Sheet.Add(Line(Cols));

            Heads.Add(Sheet.Count + 1);
            Sheet.Add(Grid_Row(gvTop, -1, Cols));
            for (int r = 0; r < gvTop.Rows.Count; r++)
            {
                Sheet.Add(Grid_Row(gvTop, r, Cols));
            }

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
                ws.Name = "Top Holdings";

                all = ws.Range[ws.Cells[1, 1], ws.Cells[Sheet.Count, Cols]];
                //Written as text on purpose, so "12.34 %" stays what the screen shows rather
                //than being re-read by Excel as a fraction.
                all.NumberFormat = "@";
                all.Value2 = Data;

                one = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                one.Font.Bold = true;
                one.Font.Size = 14;
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
