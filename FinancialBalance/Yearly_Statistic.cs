using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancialBalance
{
    public partial class Yearly_Statistic : Form
    {
        private const string AllAsset = "ALL ASSET (as a whole)";
        private const string AllLiability = "ALL LIABILITY (as a whole)";
        private const string AllIncome = "ALL INCOME (as a whole)";
        private const string AllExpense = "ALL EXPENSE (as a whole)";

        private bool Filling;

        public Yearly_Statistic()
        {
            InitializeComponent();
        }

        private void Yearly_Statistic_Load(object sender, EventArgs e)
        {
            Filling = true;
            CmbCategory.Items.Clear();
            CmbCategory.Items.Add("Asset");
            CmbCategory.Items.Add("Liability");
            CmbCategory.Items.Add("Income");
            CmbCategory.Items.Add("Expense");
            CmbCategory.Text = "Asset";
            Fill_Account();
            Filling = false;

            Get_Data();
        }

        private void CmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Filling = true;
            Fill_Account();
            Filling = false;

            Get_Data();
        }

        private void CmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        //Asset and Liability are balances at a point in time; Income and Expense are amounts
        //accumulated over a year.  Everything below keys off these helpers.
        private string Cat_Type()
        {
            if (CmbCategory.Text == "Liability")
            {
                return "2";
            }
            if (CmbCategory.Text == "Income")
            {
                return "3";
            }
            if (CmbCategory.Text == "Expense")
            {
                return "4";
            }
            return "1";
        }

        private string Cat_Prefix()
        {
            string strType = Cat_Type();
            if (strType == "2")
            {
                return "L";
            }
            if (strType == "3")
            {
                return "I";
            }
            if (strType == "4")
            {
                return "E";
            }
            return "A";
        }

        //Income and Expense accumulate over the year; Asset and Liability are a closing balance
        private bool Cat_Is_Flow()
        {
            string strType = Cat_Type();
            return (strType == "3" || strType == "4");
        }

        //Where the live balance sits for the current year
        private string Cat_Balance_Table()
        {
            if (Cat_Type() == "2")
            {
                return "TblLiability";
            }
            return "TblAsset";
        }

        private string Cat_All_Item()
        {
            string strType = Cat_Type();
            if (strType == "2")
            {
                return AllLiability;
            }
            if (strType == "3")
            {
                return AllIncome;
            }
            if (strType == "4")
            {
                return AllExpense;
            }
            return AllAsset;
        }

        //Second drop down follows the category picked in the first one
        private void Fill_Account()
        {
            CmbAccount.Items.Clear();

            CmbAccount.Items.Add(Cat_All_Item());
            Mdl1.Ssql = "Select Acct_Code, Acct_Name from TblAcctRef where Acct_Type = '" + Cat_Type() + "' Order by Acct_Order";

            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CmbAccount.Items.Add(reader["Acct_Code"].ToString().Trim() + " - " + reader["Acct_Name"].ToString().Trim());
                }
            }
            reader.Close();

            CmbAccount.Text = CmbAccount.Items[0].ToString();
        }

        //Empty when the whole category is selected, otherwise the code in front of " - "
        private string Selected_Acct_Code()
        {
            string strItem = CmbAccount.Text.Trim();

            if (strItem == "" || strItem == AllAsset || strItem == AllLiability
                || strItem == AllIncome || strItem == AllExpense)
            {
                return "";
            }

            int idx = strItem.IndexOf(" - ");
            if (idx < 0)
            {
                return strItem;
            }
            return strItem.Substring(0, idx).Trim();
        }

        private void Clear_Grid()
        {
            gvStat.Columns.Clear();
            gvStat.Rows.Clear();
            gvStat.ColumnCount = 4;
            gvStat.Columns[0].Name = "Year";
            gvStat.Columns[0].FillWeight = 16;
            gvStat.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvStat.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvStat.Columns[1].Name = "Amount";
            gvStat.Columns[1].FillWeight = 28;
            gvStat.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvStat.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvStat.Columns[2].Name = "Changes";
            gvStat.Columns[2].FillWeight = 28;
            gvStat.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvStat.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvStat.Columns[3].Name = "Changes (%)";
            gvStat.Columns[3].FillWeight = 28;
            gvStat.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvStat.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Get_Data()
        {
            int EndYear;
            int StartYear;
            string strAcctCode;
            bool IsFlow;
            bool AsWhole;
            string strCurr;
            double TmpAmt;
            double PrevAmt;
            bool HasPrev;
            string[] row;

            Clear_Grid();
            chartYearly.Series["Amount"].Points.Clear();

            try
            {
                EndYear = DateTime.Now.Year;
                StartYear = EndYear - 9;
                strAcctCode = Selected_Acct_Code();
                IsFlow = Cat_Is_Flow();
                AsWhole = (strAcctCode == "");

                //A single account keeps its own currency, the whole category is converted to AUD
                if (AsWhole)
                {
                    strCurr = "AUD";
                }
                else
                {
                    strCurr = GetAcctCurr(strAcctCode);
                }

                PrevAmt = 0;
                HasPrev = false;

                for (int Yr = StartYear; Yr <= EndYear; Yr++)
                {
                    if (IsFlow)
                    {
                        if (AsWhole)
                        {
                            TmpAmt = Total_Flow_AUD(Yr);
                        }
                        else
                        {
                            TmpAmt = Acct_Flow(strAcctCode, Yr);
                        }
                    }
                    else
                    {
                        if (AsWhole)
                        {
                            TmpAmt = Total_Balance_AUD(Yr);
                        }
                        else
                        {
                            TmpAmt = Acct_Balance(strAcctCode, Yr);
                        }
                    }

                    int idx = chartYearly.Series["Amount"].Points.AddXY(Yr.ToString("0000"), TmpAmt);
                    DataPoint pt = chartYearly.Series["Amount"].Points[idx];
                    pt.ToolTip = Yr.ToString("0000") + " : " + Mdl1.FormatAmt(TmpAmt) + " " + strCurr;
                    if (TmpAmt >= 0)
                    {
                        pt.Color = System.Drawing.ColorTranslator.FromOle(0xFF8080);
                    }
                    else
                    {
                        pt.Color = System.Drawing.ColorTranslator.FromOle(0xFF);
                    }

                    if (HasPrev)
                    {
                        row = new string[] { Yr.ToString("0000"), Mdl1.FormatAmt(TmpAmt), Mdl1.FormatAmt(TmpAmt - PrevAmt), FormatPct(TmpAmt, PrevAmt) };
                    }
                    else
                    {
                        row = new string[] { Yr.ToString("0000"), Mdl1.FormatAmt(TmpAmt), "", "" };
                    }
                    gvStat.Rows.Add(row);
                    if (TmpAmt - PrevAmt < 0 && HasPrev)
                    {
                        gvStat.Rows[gvStat.Rows.Count - 1].Cells[2].Style.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                        gvStat.Rows[gvStat.Rows.Count - 1].Cells[3].Style.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                    }

                    PrevAmt = TmpAmt;
                    HasPrev = true;
                }

                gvStat.ClearSelection();

                chartYearly.ChartAreas["ChartArea1"].AxisY.Title = "Amount (" + strCurr + ")";
                chartYearly.Titles["MainTitle"].Text = Chart_Title(AsWhole, strCurr);
                lblNote.Text = Note_Text(AsWhole);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private string Chart_Title(bool parAsWhole, string parCurr)
        {
            string strWhat;

            if (parAsWhole)
            {
                strWhat = "Total " + CmbCategory.Text;
            }
            else
            {
                int idx = CmbAccount.Text.Trim().IndexOf(" - ");
                if (idx < 0)
                {
                    strWhat = CmbAccount.Text.Trim();
                }
                else
                {
                    strWhat = CmbAccount.Text.Trim().Substring(idx + 3).Trim();
                }
            }

            if (Cat_Is_Flow())
            {
                return strWhat + " - Yearly " + CmbCategory.Text + " in " + parCurr;
            }
            return strWhat + " - Closing Balance in " + parCurr;
        }

        private string Note_Text(bool parAsWhole)
        {
            string strNote;

            if (Cat_Is_Flow())
            {
                strNote = CmbCategory.Text + " is the total of all monthly transactions posted in each year.";
            }
            else
            {
                strNote = CmbCategory.Text + " is the closing balance at the end of each year. The current year uses the live balance.";
            }

            if (parAsWhole)
            {
                strNote = strNote + " Every account is converted to AUD using the currency rate of December of that year.";
            }
            else
            {
                strNote = strNote + " The amount is shown in the currency of the account, without any conversion.";
            }

            return strNote;
        }

        private string FormatPct(double parAmt, double parPrevAmt)
        {
            if (parPrevAmt == 0)
            {
                return "";
            }
            return Mdl1.FormatAmt(((parAmt - parPrevAmt) / Math.Abs(parPrevAmt)) * 100) + " %";
        }

        //Yearly Summary treats IDR as the base currency instead of reading a rate for it
        private double CurrRate(string parCurr, int parYear)
        {
            if (parCurr.Trim() == "IDR")
            {
                return 1;
            }
            return Mdl1.GetCurrRate(parCurr.Trim(), parYear.ToString("0000") + "12");
        }

        private string GetAcctCurr(string parAcctCode)
        {
            string strCurr = "";

            Mdl1.Ssql = "Select top 1 Curr_Code from TblAcctRef where Acct_Code = '" + parAcctCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                strCurr = reader["Curr_Code"].ToString().Trim();
            }
            reader.Close();

            return strCurr;
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

        //Reads a "Curr_Code / TotBalance" query and converts the whole result set to AUD
        private double Sum_To_AUD(int parYear)
        {
            List<string> Currs = new List<string>();
            List<double> Amts = new List<double>();
            double TotIDR;

            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["TotBalance"] != DBNull.Value)
                    {
                        Currs.Add(reader["Curr_Code"].ToString().Trim());
                        Amts.Add(double.Parse(reader["TotBalance"].ToString().Trim()));
                    }
                }
            }
            reader.Close();

            TotIDR = 0;
            for (int idx = 0; idx < Currs.Count; idx++)
            {
                TotIDR += Amts[idx] * CurrRate(Currs[idx], parYear);
            }

            return TotIDR / CurrRate("AUD", parYear);
        }

        private double Total_Flow_AUD(int parYear)
        {
            Mdl1.Ssql = "Select B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Trans_Month,4) = '" + parYear.ToString("0000") + "' and left(A.Acct_Code, 1) = '" + Cat_Prefix() + "' Group By B.Curr_Code";
            return Sum_To_AUD(parYear);
        }

        private double Total_Balance_AUD(int parYear)
        {
            if (parYear == DateTime.Now.Year)
            {
                Mdl1.Ssql = "Select B.Curr_Code, Sum(A.Balance) As TotBalance from " + Cat_Balance_Table() + " A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where B.Acct_Type = '" + Cat_Type() + "' Group By B.Curr_Code";
            }
            else
            {
                string strMonth = Closing_Month(parYear);
                if (strMonth == "")
                {
                    return 0;
                }
                Mdl1.Ssql = "Select B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + strMonth + "' and B.Acct_Type = '" + Cat_Type() + "' Group By B.Curr_Code";
            }

            return Sum_To_AUD(parYear);
        }

        private double Acct_Flow(string parAcctCode, int parYear)
        {
            Mdl1.Ssql = "Select Sum(Balance) As TotBalance from TblMonthlyTrans " + "where Acct_Code = '" + parAcctCode + "' and left(Trans_Month,4) = '" + parYear.ToString("0000") + "'";
            return Read_Amt();
        }

        private double Acct_Balance(string parAcctCode, int parYear)
        {
            if (parYear == DateTime.Now.Year)
            {
                Mdl1.Ssql = "Select Sum(Balance) As TotBalance from " + Cat_Balance_Table() + " where Acct_Code = '" + parAcctCode + "'";
            }
            else
            {
                string strMonth = Closing_Month(parYear);
                if (strMonth == "")
                {
                    return 0;
                }
                Mdl1.Ssql = "Select Sum(Balance) As TotBalance from TblMonthlyTrans " + "where Acct_Code = '" + parAcctCode + "' and Trans_Month = '" + strMonth + "'";
            }

            return Read_Amt();
        }

        private double Read_Amt()
        {
            double TmpAmt = 0;

            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (reader["TotBalance"] != DBNull.Value)
                {
                    TmpAmt = double.Parse(reader["TotBalance"].ToString().Trim());
                }
            }
            reader.Close();

            return TmpAmt;
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
