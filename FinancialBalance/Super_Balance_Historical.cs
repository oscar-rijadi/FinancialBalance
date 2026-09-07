using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FinancialBalance
{
    public partial class Super_Balance_Historical : Form
    {
        //One row per super account: the balance from the most recent financial year that account
        //has a record for. Different accounts can therefore be showing different years, which is
        //why the year each balance comes from is a column of its own.
        private class Entry
        {
            public string Code;
            public string Caption;
            public string Year;
            public int Rank;            //where that year sits in TblFinancialYear, latest highest
            public string Currency;     //not shown, but it decides how the balance is formatted
            public double Ending;
        }

        //Guards the filters while they are being populated, so filling one does not run the
        //query once per item added.
        bool Filling;

        //The Super filter shows "name - fund" but the table stores a code, so the codes run
        //alongside the items. A null entry is the "All" row.
        List<string> FilterSuperCodes = new List<string>();

        public Super_Balance_Historical()
        {
            InitializeComponent();
        }

        private void Super_Balance_Historical_Load(object sender, EventArgs e)
        {
            Filling = true;
            Clear_Grid();
            Clear_Hist_Grid();
            Fill_Financial_Year();
            Fill_Super();
            Filling = false;

            Get_Data();
            Get_History();
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

        //---- where each account stands ---------------------------------------------

        private void Clear_Grid()
        {
            gvSuper.Rows.Clear();
            gvSuper.Columns.Clear();
            gvSuper.ColumnCount = 3;
            string[] names = new string[] { "Super", "Financial Year", "Balance" };
            int[] weights = new int[] { 48, 22, 30 };
            for (int i = 0; i < 3; i++)
            {
                gvSuper.Columns[i].Name = names[i];
                gvSuper.Columns[i].FillWeight = weights[i];
                //the account's name reads left, the year sits centred, the balance reads right
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleRight;
                if (i == 0) { TmpAlign = DataGridViewContentAlignment.MiddleLeft; }
                else if (i == 1) { TmpAlign = DataGridViewContentAlignment.MiddleCenter; }
                gvSuper.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvSuper.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        //Reads as "name - fund", the same caption the Super page uses
        private string Super_Caption(string parName, string parFund)
        {
            return parName + " - " + parFund;
        }

        //A super account named on a financial-year row but missing from TblSuper has no caption
        //to show. Falling back to the bare code keeps the row visible rather than blank - the
        //figures are real either way, and a blank line would hide the inconsistency.
        private Dictionary<string, string> Read_Captions()
        {
            Dictionary<string, string> Captions = new Dictionary<string, string>();
            Mdl1.Ssql = "select [Super_Code], [Name], [Super_Fund_Name] from TblSuper";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = Read_Text(reader["Super_Code"]);
                if (TmpCode != "" && !Captions.ContainsKey(TmpCode))
                {
                    Captions.Add(TmpCode, Super_Caption(Read_Text(reader["Name"]),
                                                        Read_Text(reader["Super_Fund_Name"])));
                }
            }
            reader.Close();
            return Captions;
        }

        //Financial years are ordered by End_Date, as everywhere else in the app - the names are
        //text and cannot be relied on to sort chronologically. The position in that order is what
        //decides which of an account's rows is the latest.
        private Dictionary<string, int> Read_Year_Order()
        {
            Dictionary<string, int> Ranks = new Dictionary<string, int>();
            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                string TmpName = Read_Text(reader["Name"]);
                if (TmpName != "" && !Ranks.ContainsKey(TmpName))
                {
                    Ranks.Add(TmpName, i);
                    i++;
                }
            }
            reader.Close();
            return Ranks;
        }

        //Every stored row, reduced to the latest one per account. A row whose Financial_Year is
        //not in TblFinancialYear ranks below every real year, so it is only shown when the
        //account has nothing else - otherwise an orphaned year could outrank a genuine one.
        private List<Entry> Latest_Per_Account()
        {
            Dictionary<string, string> Captions = Read_Captions();
            Dictionary<string, int> Ranks = Read_Year_Order();
            Dictionary<string, Entry> Latest = new Dictionary<string, Entry>();

            Mdl1.Ssql = "select [Financial_Year], [Super_Code], [Currency], [Ending_Balance]"
                      + " from TblSuperFinancialYear";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = Read_Text(reader["Super_Code"]);
                if (TmpCode == "")
                {
                    continue;
                }
                string TmpYear = Read_Text(reader["Financial_Year"]);
                int TmpRank = (Ranks.ContainsKey(TmpYear) ? Ranks[TmpYear] : -1);

                if (Latest.ContainsKey(TmpCode) && Latest[TmpCode].Rank >= TmpRank)
                {
                    continue;
                }

                Entry Row = new Entry();
                Row.Code = TmpCode;
                Row.Caption = (Captions.ContainsKey(TmpCode) ? Captions[TmpCode] : TmpCode);
                Row.Year = TmpYear;
                Row.Rank = TmpRank;
                Row.Currency = Read_Text(reader["Currency"]);
                Row.Ending = Read_Double(reader["Ending_Balance"]);
                Latest[TmpCode] = Row;
            }
            reader.Close();

            List<Entry> Rows = new List<Entry>(Latest.Values);
            Rows.Sort(delegate(Entry a, Entry b) { return string.Compare(a.Code, b.Code); });
            return Rows;
        }

        //The financial year each row comes from is a column of its own now, so the note no
        //longer has to name it.
        private string Note_For(List<Entry> parRows)
        {
            if (parRows.Count == 0)
            {
                return "No super records yet.";
            }
            return parRows.Count.ToString() + " super account(s), latest record each";
        }

        private void Get_Data()
        {
            try
            {
                Clear_Grid();
                List<Entry> Rows = Latest_Per_Account();

                foreach (Entry Row in Rows)
                {
                    gvSuper.Rows.Add(new string[] {
                        Row.Caption,
                        Row.Year,
                        Money(Row.Ending, Row.Currency) });
                }

                gvSuper.ClearSelection();
                LblNote.Text = Note_For(Rows);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- one account's history -------------------------------------------------

        private void Fill_Financial_Year()
        {
            CmbFinYear.Items.Clear();
            CmbFinYear.Items.Add("All");
            Mdl1.Ssql = "select [Name] from TblFinancialYear order by [End_Date] Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFinYear.Items.Add(Read_Text(reader["Name"]));
            }
            reader.Close();
            CmbFinYear.Text = "All";
        }

        private void Fill_Super()
        {
            CmbSuper.Items.Clear();
            FilterSuperCodes.Clear();
            CmbSuper.Items.Add("All");
            FilterSuperCodes.Add(null);
            Mdl1.Ssql = "select [Super_Code], [Name], [Super_Fund_Name] from TblSuper order by [Super_Code]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbSuper.Items.Add(Super_Caption(Read_Text(reader["Name"]),
                                                 Read_Text(reader["Super_Fund_Name"])));
                FilterSuperCodes.Add(Read_Text(reader["Super_Code"]));
            }
            reader.Close();
            CmbSuper.Text = "All";
        }

        //Null means every account. All sits at index 0 and is always present, so a null can only
        //come from that row - there is no invalid selection to confuse it with.
        private string Filter_Super_Code()
        {
            int idx = CmbSuper.SelectedIndex;
            if (idx < 0 || idx >= FilterSuperCodes.Count)
            {
                return null;
            }
            return FilterSuperCodes[idx];
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_History();
        }

        private void Clear_Hist_Grid()
        {
            gvHist.Rows.Clear();
            gvHist.Columns.Clear();
            gvHist.ColumnCount = 11;
            string[] names = new string[] {
                "Super", "Financial Year", "Opening Balance", "Contribution", "Transfer In",
                "Investment Returns", "Percentage Investment Returns", "Investment Profit/Loss",
                "Percentage Investment Profit/Loss", "Transfer Out", "Ending Balance" };
            int[] weights = new int[] { 14, 8, 9, 8, 7, 8, 10, 9, 11, 7, 9 };
            for (int i = 0; i < 11; i++)
            {
                gvHist.Columns[i].Name = names[i];
                gvHist.Columns[i].FillWeight = weights[i];
                //the account's name reads left, the year sits centred, every amount reads right
                DataGridViewContentAlignment TmpAlign = DataGridViewContentAlignment.MiddleRight;
                if (i == 0) { TmpAlign = DataGridViewContentAlignment.MiddleLeft; }
                else if (i == 1) { TmpAlign = DataGridViewContentAlignment.MiddleCenter; }
                gvHist.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvHist.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        //One stored row, as the history table shows it
        private class HistRow
        {
            public string Code;
            public string Year;
            public int Rank;            //where that year sits in TblFinancialYear, latest highest
            public string[] Cells;
            public double ProfitOrLoss;
            public double PctProfitOrLoss;
        }

        //Super_Code ascending, then financial year descending. The year order comes from
        //End_Date in TblFinancialYear rather than from the name, for the same reason the summary
        //table above uses it: Financial_Year is text and nothing forces those names to sort
        //chronologically. A year missing from TblFinancialYear ranks below every real one, so it
        //sorts to the bottom of its account rather than to an arbitrary place in the middle.
        private List<HistRow> Read_History()
        {
            Dictionary<string, string> Captions = Read_Captions();
            Dictionary<string, int> Ranks = Read_Year_Order();
            List<HistRow> Rows = new List<HistRow>();

            string TmpCode = Filter_Super_Code();
            string TmpYear = CmbFinYear.Text.Trim();

            Mdl1.Ssql = "select [Financial_Year], [Super_Code], [Currency], [Opening_Balance],"
                      + " [Contribution], [Transfer_In], [Investment_Returns],"
                      + " [Percentage_Investment_Returns], [Investment_Profit_Or_Loss],"
                      + " [Percentage_Investment_Profit_Or_Loss], [Transfer_Out], [Ending_Balance]"
                      + " from TblSuperFinancialYear where 1 = 1"
                      + (TmpCode == null ? "" : " and [Super_Code] = '" + TmpCode + "'")
                      + (TmpYear == "" || TmpYear == "All" ? "" : " and [Financial_Year] = '" + TmpYear + "'");
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string RowCode = Read_Text(reader["Super_Code"]);
                string RowYear = Read_Text(reader["Financial_Year"]);
                string Curr = Read_Text(reader["Currency"]);
                double TmpInvPL = Read_Double(reader["Investment_Profit_Or_Loss"]);
                double TmpPctInvPL = Read_Double(reader["Percentage_Investment_Profit_Or_Loss"]);

                HistRow Row = new HistRow();
                Row.Code = RowCode;
                Row.Year = RowYear;
                Row.Rank = (Ranks.ContainsKey(RowYear) ? Ranks[RowYear] : -1);
                Row.ProfitOrLoss = TmpInvPL;
                Row.PctProfitOrLoss = TmpPctInvPL;
                Row.Cells = new string[] {
                    (Captions.ContainsKey(RowCode) ? Captions[RowCode] : RowCode),
                    RowYear,
                    Money(Read_Double(reader["Opening_Balance"]), Curr),
                    Money(Read_Double(reader["Contribution"]), Curr),
                    Money(Read_Double(reader["Transfer_In"]), Curr),
                    Money(Read_Double(reader["Investment_Returns"]), Curr),
                    Percent(Read_Double(reader["Percentage_Investment_Returns"])),
                    Money(TmpInvPL, Curr),
                    Percent(TmpPctInvPL),
                    Money(Read_Double(reader["Transfer_Out"]), Curr),
                    Money(Read_Double(reader["Ending_Balance"]), Curr) };
                Rows.Add(Row);
            }
            reader.Close();

            Rows.Sort(delegate(HistRow a, HistRow b)
            {
                int c = string.Compare(a.Code, b.Code);
                if (c != 0) { return c; }
                c = b.Rank.CompareTo(a.Rank);
                if (c != 0) { return c; }
                //two years of equal rank can only be the same year, or two the year table does
                //not know; the name keeps the order stable either way
                return string.Compare(b.Year, a.Year);
            });
            return Rows;
        }

        private void Get_History()
        {
            try
            {
                Clear_Hist_Grid();
                List<HistRow> Rows = Read_History();

                foreach (HistRow Row in Rows)
                {
                    gvHist.Rows.Add(Row.Cells);
                    DataGridViewRow Line = gvHist.Rows[gvHist.Rows.Count - 1];
                    Colour_Cell(Line.Cells[7], Row.ProfitOrLoss);
                    Colour_Cell(Line.Cells[8], Row.PctProfitOrLoss);
                }

                gvHist.ClearSelection();
                if (Rows.Count == 0)
                {
                    LblNote2.Text = "No records for this selection.";
                }
                else
                {
                    LblNote2.Text = Rows.Count.ToString() + " record(s)";
                }
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
