using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialBalance
{
    public partial class Yearly_Summary_Graph : Form
    {
        //The four lines the page can draw, in the order of the checkboxes, the legend and the
        //grid.  The prefix is the first character of Acct_Code, which is how every page here
        //tells the four categories apart.
        private static readonly string[] Prefixes = { "A", "L", "I", "E" };
        private static readonly string[] Names = { "Asset", "Liability", "Income", "Expense" };

        //True until Load has filled the Year dropdown.  The designer ticks all four checkboxes
        //while InitializeComponent runs, which fires CheckedChanged before there is a year to
        //draw, so every handler has to keep out of the way until the page is really up.
        private bool Filling = true;

        public Yearly_Summary_Graph()
        {
            InitializeComponent();
        }

        private void Yearly_Summary_Graph_Load(object sender, EventArgs e)
        {
            Mdl1.Fill_Year(CmbYear);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);
            Filling = false;

            Get_Data();
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        //All four checkboxes share this - which one moved does not matter, the page is redrawn
        //from whatever is ticked at the time.
        private void chkCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private CheckBox Box(int parIdx)
        {
            if (parIdx == 1)
            {
                return chkLiability;
            }
            if (parIdx == 2)
            {
                return chkIncome;
            }
            if (parIdx == 3)
            {
                return chkExpense;
            }
            return chkAsset;
        }

        //Income and Expense accumulate over the period; Asset and Liability are a balance at the
        //end of it.  Everything below keys off this.
        private bool Is_Flow(string parPrefix)
        {
            return (parPrefix == "I" || parPrefix == "E");
        }

        private string Acct_Type(string parPrefix)
        {
            if (parPrefix == "L")
            {
                return "2";
            }
            if (parPrefix == "I")
            {
                return "3";
            }
            if (parPrefix == "E")
            {
                return "4";
            }
            return "1";
        }

        //Where the live balance sits, for a period that was never closed
        private string Balance_Table(string parPrefix)
        {
            if (parPrefix == "L")
            {
                return "TblLiability";
            }
            return "TblAsset";
        }

        private bool By_Year()
        {
            return (CmbYear.Text.Trim() == "All");
        }

        //The x axis.  "All" gives the last ten years, oldest first, the same ten the Year
        //dropdown itself offers; a year gives its twelve months.
        private List<string> Periods()
        {
            List<string> Keys = new List<string>();

            if (By_Year())
            {
                for (int Yr = DateTime.Now.Year - 9; Yr <= DateTime.Now.Year; Yr++)
                {
                    Keys.Add(Yr.ToString("0000"));
                }
            }
            else
            {
                for (int Mn = 1; Mn <= 12; Mn++)
                {
                    Keys.Add(CmbYear.Text.Trim() + Mn.ToString("00"));
                }
            }

            return Keys;
        }

        private string Axis_Label(string parKey)
        {
            if (By_Year())
            {
                return parKey;
            }
            return Month_Date(parKey).ToString("MMM", CultureInfo.InvariantCulture);
        }

        private string Row_Label(string parKey)
        {
            if (By_Year())
            {
                return parKey;
            }
            return Month_Date(parKey).ToString("MMM yyyy", CultureInfo.InvariantCulture);
        }

        private DateTime Month_Date(string parKey)
        {
            return new DateTime(int.Parse(parKey.Substring(0, 4)), int.Parse(parKey.Substring(4, 2)), 1);
        }

        private void Clear_Grid()
        {
            gvGraph.Columns.Clear();
            gvGraph.Rows.Clear();

            int Cols = 1;
            for (int idx = 0; idx < Prefixes.Length; idx++)
            {
                if (Box(idx).Checked)
                {
                    Cols++;
                }
            }

            //The table shows exactly what the chart shows, so an unticked category is not a
            //blank column - it is not there at all.
            gvGraph.ColumnCount = Cols;
            gvGraph.Columns[0].Name = (By_Year() ? "Year" : "Month");
            gvGraph.Columns[0].FillWeight = 20;
            gvGraph.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvGraph.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int Col = 1;
            for (int idx = 0; idx < Prefixes.Length; idx++)
            {
                if (!Box(idx).Checked)
                {
                    continue;
                }
                gvGraph.Columns[Col].Name = Names[idx] + " (AUD)";
                gvGraph.Columns[Col].FillWeight = 80F / (Cols - 1);
                gvGraph.Columns[Col].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gvGraph.Columns[Col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Col++;
            }
        }

        private void Get_Data()
        {
            List<string> Keys;
            string[] row;
            double TmpAmt;
            int Col;

            try
            {
                Clear_Grid();

                for (int idx = 0; idx < Prefixes.Length; idx++)
                {
                    chartGraph.Series[Names[idx]].Points.Clear();
                    //A disabled series is drawn nowhere and listed nowhere, which is what an
                    //unticked box should mean
                    chartGraph.Series[Names[idx]].Enabled = Box(idx).Checked;
                }

                Keys = Periods();

                foreach (string strKey in Keys)
                {
                    row = new string[gvGraph.ColumnCount];
                    row[0] = Row_Label(strKey);
                    Col = 1;

                    for (int idx = 0; idx < Prefixes.Length; idx++)
                    {
                        if (!Box(idx).Checked)
                        {
                            continue;
                        }

                        if (By_Year())
                        {
                            TmpAmt = Year_Total(Prefixes[idx], int.Parse(strKey));
                        }
                        else
                        {
                            TmpAmt = Month_Total(Prefixes[idx], strKey);
                        }

                        int pt = chartGraph.Series[Names[idx]].Points.AddXY(Axis_Label(strKey), TmpAmt);
                        chartGraph.Series[Names[idx]].Points[pt].ToolTip =
                            Names[idx] + " - " + Row_Label(strKey) + " : " + Mdl1.FormatAmt(TmpAmt) + " AUD";

                        row[Col] = Mdl1.FormatAmt(TmpAmt);
                        Col++;
                    }

                    gvGraph.Rows.Add(row);
                }

                gvGraph.ClearSelection();

                chartGraph.ChartAreas["ChartArea1"].AxisX.Title = (By_Year() ? "Year" : "Month");
                chartGraph.ChartAreas["ChartArea1"].AxisY.Title = "Amount (AUD)";
                chartGraph.Titles["MainTitle"].Text = Chart_Title();
                lblNote.Text = Note_Text();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private string Picked()
        {
            List<string> Wanted = new List<string>();

            for (int idx = 0; idx < Prefixes.Length; idx++)
            {
                if (Box(idx).Checked)
                {
                    Wanted.Add(Names[idx]);
                }
            }

            if (Wanted.Count == 0)
            {
                return "";
            }
            if (Wanted.Count == 1)
            {
                return Wanted[0];
            }
            return String.Join(", ", Wanted.GetRange(0, Wanted.Count - 1).ToArray()) + " and " + Wanted[Wanted.Count - 1];
        }

        private string Chart_Title()
        {
            string strWhat = Picked();

            if (strWhat == "")
            {
                return "Nothing selected";
            }

            if (By_Year())
            {
                return "Total " + strWhat + " - the last 10 years, in AUD";
            }
            return "Total " + strWhat + " - " + CmbYear.Text.Trim() + " month by month, in AUD";
        }

        private string Note_Text()
        {
            if (Picked() == "")
            {
                return "Tick Asset, Liability, Income or Expense to draw it.";
            }

            if (By_Year())
            {
                return "Each year is the figure Yearly Summary shows for it: Income and Expense are every monthly transaction posted in the year, Asset and Liability the closing balance at the end of it, and the current year uses the live balance."
                     + Environment.NewLine
                     + "Every account is converted to AUD at the currency rate of December of that year.";
            }

            return "Each month is the figure Monthly Inquiry shows for it: Income and Expense are the transactions posted in the month, Asset and Liability the balance at the end of it. A month that was never closed falls back to the live balance, so months still to come repeat today's Asset and Liability while Income and Expense read nothing."
                 + Environment.NewLine
                 + "Every account is converted to AUD at the currency rate of that month.";
        }

        //Yearly Summary's arithmetic: one figure for a whole year, in AUD.
        private double Year_Total(string parPrefix, int parYear)
        {
            string strRateMonth = parYear.ToString("0000") + "12";
            bool Found;

            if (Is_Flow(parPrefix))
            {
                Mdl1.Ssql = "Select B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Trans_Month,4) = '" + parYear.ToString("0000") + "' and left(A.Acct_Code, 1) = '" + parPrefix + "' Group By B.Curr_Code";
                return Sum_To_AUD(strRateMonth, out Found);
            }

            if (parYear == DateTime.Now.Year)
            {
                Mdl1.Ssql = "Select B.Curr_Code, Sum(A.Balance) As TotBalance from " + Balance_Table(parPrefix) + " A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where B.Acct_Type = '" + Acct_Type(parPrefix) + "' Group By B.Curr_Code";
                return Sum_To_AUD(strRateMonth, out Found);
            }

            string strMonth = Closing_Month(parYear);
            if (strMonth == "")
            {
                return 0;
            }
            Mdl1.Ssql = "Select B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + strMonth + "' and B.Acct_Type = '" + Acct_Type(parPrefix) + "' Group By B.Curr_Code";
            return Sum_To_AUD(strRateMonth, out Found);
        }

        //Monthly Inquiry's arithmetic: one figure for one month, in AUD.
        private double Month_Total(string parPrefix, string parMonth)
        {
            bool Found;
            double TmpAmt;

            Mdl1.Ssql = "Select B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + parMonth + "' and left(A.Acct_Code, 1) = '" + parPrefix + "' Group By B.Curr_Code";
            TmpAmt = Sum_To_AUD(parMonth, out Found);

            //A month with nothing posted has never been closed, and Monthly Inquiry shows the
            //live balance for it instead - but only for Asset and Liability, since Income and
            //Expense have no running balance to fall back to.  The 201002 floor is Monthly
            //Inquiry's own: before it there is no live balance worth showing.
            if (!Found && !Is_Flow(parPrefix) && int.Parse(parMonth) >= 201002)
            {
                Mdl1.Ssql = "Select B.Curr_Code, Sum(A.Balance) As TotBalance from " + Balance_Table(parPrefix) + " A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Acct_Code,1) = '" + parPrefix + "' Group By B.Curr_Code";
                TmpAmt = Sum_To_AUD(parMonth, out Found);
            }

            return TmpAmt;
        }

        //Last month of the year that carries any monthly transaction, same as Yearly Summary
        private string Closing_Month(int parYear)
        {
            string strMonth = "";

            Mdl1.Ssql = "Select top 1 Trans_Month from TblMonthlyTrans where left(Trans_Month,4) = '" + parYear.ToString("0000") + "' Order by Trans_Month Desc";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                strMonth = reader["Trans_Month"].ToString().Trim();
            }
            reader.Close();

            return strMonth;
        }

        //Reads a "Curr_Code / TotBalance" query and converts the whole result set to AUD, the
        //way both pages do it: every currency into IDR at that period's rate, then the one
        //division into AUD.  parFound says whether the query returned anything at all, which is
        //what tells a month that was never closed from one that closed at nothing.
        private double Sum_To_AUD(string parRateMonth, out bool parFound)
        {
            List<string> Currs = new List<string>();
            List<double> Amts = new List<double>();
            double TotIDR;

            parFound = false;

            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["TotBalance"] != DBNull.Value)
                    {
                        parFound = true;
                        Currs.Add(reader["Curr_Code"].ToString().Trim());
                        Amts.Add(double.Parse(reader["TotBalance"].ToString().Trim()));
                    }
                }
            }
            reader.Close();

            TotIDR = 0;
            for (int idx = 0; idx < Currs.Count; idx++)
            {
                TotIDR += Amts[idx] * CurrRate(Currs[idx], parRateMonth);
            }

            return TotIDR / CurrRate("AUD", parRateMonth);
        }

        //Yearly Summary treats IDR as the base currency instead of reading a rate for it.  A
        //stored rate of zero is guarded because this one is divided by, and an infinity would
        //take the whole chart's axis with it.
        private double CurrRate(string parCurr, string parMonth)
        {
            double TmpRate;

            if (parCurr.Trim() == "IDR")
            {
                return 1;
            }

            TmpRate = Mdl1.GetCurrRate(parCurr.Trim(), parMonth);
            if (TmpRate == 0)
            {
                return 1;
            }
            return TmpRate;
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
