using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinancialBalance
{
    public partial class Yearly_Summary : Form
    {
        //Set while the export moves the Year dropdown itself.  Without it, assigning Text fires
        //the dropdown's handler and the page is fetched twice for every tab - and this page's
        //Get_Data is the most expensive one in the application.
        bool Filling;

        public Yearly_Summary()
        {
            InitializeComponent();
        }

        private void Yearly_Summary_Load(object sender, EventArgs e)
        {
            Mdl1.Fill_Year(CmbYear);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void Clear_Grid()
        {
            gvIncome.Columns.Clear();
            gvIncome.ColumnCount = 5;
            gvIncome.Columns[0].Name = "Account Name";
            gvIncome.Columns[0].FillWeight = 34;
            gvIncome.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvIncome.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvIncome.Columns[1].Name = "USD";
            gvIncome.Columns[1].FillWeight = 17;
            gvIncome.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvIncome.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvIncome.Columns[2].Name = "AUD";
            gvIncome.Columns[2].FillWeight = 17;
            gvIncome.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvIncome.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvIncome.Columns[3].Name = "Other Curr";
            gvIncome.Columns[3].FillWeight = 9;
            gvIncome.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvIncome.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvIncome.Columns[4].Name = "IDR";
            gvIncome.Columns[4].FillWeight = 23;
            gvIncome.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvIncome.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvExpense.Columns.Clear();
            gvExpense.ColumnCount = 5;
            gvExpense.Columns[0].Name = "Account Name";
            gvExpense.Columns[0].FillWeight = 34;
            gvExpense.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvExpense.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvExpense.Columns[1].Name = "USD";
            gvExpense.Columns[1].FillWeight = 17;
            gvExpense.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvExpense.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvExpense.Columns[2].Name = "AUD";
            gvExpense.Columns[2].FillWeight = 17;
            gvExpense.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvExpense.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvExpense.Columns[3].Name = "Other Curr";
            gvExpense.Columns[3].FillWeight = 9;
            gvExpense.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvExpense.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvExpense.Columns[4].Name = "IDR";
            gvExpense.Columns[4].FillWeight = 23;
            gvExpense.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvExpense.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvActiva.Columns.Clear();
            gvActiva.ColumnCount = 10;
            gvActiva.Columns[0].Name = "Account Name";
            gvActiva.Columns[0].FillWeight = 18;
            gvActiva.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvActiva.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvActiva.Columns[1].Name = "Opening USD";
            gvActiva.Columns[1].FillWeight = 9;
            gvActiva.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[2].Name = "Opening AUD";
            gvActiva.Columns[2].FillWeight = 9;
            gvActiva.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[3].Name = "Opening Other Curr";
            gvActiva.Columns[3].FillWeight = 5;
            gvActiva.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[4].Name = "Opening IDR";
            gvActiva.Columns[4].FillWeight = 12;
            gvActiva.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[5].Name = "Closing USD";
            gvActiva.Columns[5].FillWeight = 9;
            gvActiva.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[6].Name = "Closing AUD";
            gvActiva.Columns[6].FillWeight = 9;
            gvActiva.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[7].Name = "Closing Other Curr";
            gvActiva.Columns[7].FillWeight = 5;
            gvActiva.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[8].Name = "Closing IDR";
            gvActiva.Columns[8].FillWeight = 12;
            gvActiva.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[9].Name = "Differences (Curr)";
            gvActiva.Columns[9].FillWeight = 12;
            gvActiva.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvPassiva.Columns.Clear();
            gvPassiva.ColumnCount = 10;
            gvPassiva.Columns[0].Name = "Account Name";
            gvPassiva.Columns[0].FillWeight = 18;
            gvPassiva.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPassiva.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPassiva.Columns[1].Name = "Opening USD";
            gvPassiva.Columns[1].FillWeight = 9;
            gvPassiva.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[2].Name = "Opening AUD";
            gvPassiva.Columns[2].FillWeight = 9;
            gvPassiva.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[3].Name = "Opening Other Curr";
            gvPassiva.Columns[3].FillWeight = 5;
            gvPassiva.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[4].Name = "Opening IDR";
            gvPassiva.Columns[4].FillWeight = 12;
            gvPassiva.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[5].Name = "Closing USD";
            gvPassiva.Columns[5].FillWeight = 9;
            gvPassiva.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[6].Name = "Closing AUD";
            gvPassiva.Columns[6].FillWeight = 9;
            gvPassiva.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[7].Name = "Closing Other Curr";
            gvPassiva.Columns[7].FillWeight = 5;
            gvPassiva.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[8].Name = "Closing IDR";
            gvPassiva.Columns[8].FillWeight = 12;
            gvPassiva.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[9].Name = "Differences (Curr)";
            gvPassiva.Columns[9].FillWeight = 12;
            gvPassiva.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Get_Data()
        {
            double TotUSD;
            double TotAUD;
            double TotOtherCurr;
            double TotIDR;
            double TotIncome;
            double TotExpense;
            double TmpIDR;
            bool RecNotFound;
            double TmpRate;
            double TmpAUDRate;

            double TotOpenUSD;
            double TotOpenAUD;
            double TotOpenOtherCurr;
            double TotOpenIDR;
            double TotCloseUSD;
            double TotCloseAUD;
            double TotCloseOtherCurr;
            double TotCloseIDR;
            double TmpOpenUSD;
            double TmpOpenAUD;
            double TmpOpenOtherCurr;
            double TmpOpenIDR;
            double TmpCloseUSD;
            double TmpCloseAUD;
            double TmpCloseOtherCurr;
            double TmpCloseIDR;
            double TmpDiff;
            double TotOpenActivaIDR;
            double TotCloseActivaIDR;
            double TotOpenPassivaIDR;
            double TotClosePassivaIDR;

            string strMonth;

            Clear_Grid();

            try
            {
                if (CmbYear.Text == "All")
                {
                    lblUSD.Text = Mdl1.FormatAmt(Mdl1.GetCurrRate("USD", String.Format("{0:yyyy}", DateTime.Now) + "12"));
                    lblAUD.Text = Mdl1.FormatAmt(Mdl1.GetCurrRate("AUD", String.Format("{0:yyyy}", DateTime.Now) + "12"));
                }
                else
                {
                    lblUSD.Text = Mdl1.FormatAmt(Mdl1.GetCurrRate("USD", CmbYear.Text + "12"));
                    lblAUD.Text = Mdl1.FormatAmt(Mdl1.GetCurrRate("AUD", CmbYear.Text + "12"));
                }

                TotIncome = 0;
                TotExpense = 0;

                string[] row;

                TmpAUDRate = 1;
                if (CmbYear.Text == "All")
                {
                    TmpAUDRate = Mdl1.GetCurrRate("AUD", String.Format("{0:yyyy}", DateTime.Now) + "12");
                }
                else
                {
                    TmpAUDRate = Mdl1.GetCurrRate("AUD", CmbYear.Text + "12");
                }

                //Income
                TotUSD = 0;
                TotAUD = 0;
                TotOtherCurr = 0;
                TotIDR = 0;
                if (CmbYear.Text == "All")
                {
                    Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Acct_Code, 1) = 'I' Group By A.Acct_Code, B.Acct_Name, B.Curr_Code, B.Acct_Order Order by B.Acct_Order";
                }
                else
                {
                    Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Trans_Month,4) = '" + CmbYear.Text + "' and left(A.Acct_Code, 1) = 'I' Group By A.Acct_Code, B.Acct_Name, B.Curr_Code, B.Acct_Order Order by B.Acct_Order";
                }
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TmpRate = 1;
                        if (CmbYear.Text == "All")
                        {
                            TmpRate = Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), String.Format("{0:yyyy}", DateTime.Now) + "12");
                        }
                        else
                        {
                            TmpRate = Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + "12");
                        }
                        switch (reader["Curr_Code"].ToString().Trim())
                        {
                            case "USD":
                                TotUSD += double.Parse(reader["TotBalance"].ToString().Trim());
                                TmpIDR = double.Parse(reader["TotBalance"].ToString().Trim()) * TmpRate;
                                TotIncome += TmpIDR;
                                row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["TotBalance"].ToString().Trim())), "", "", "" };
                                gvIncome.Rows.Add(row);
                                break;
                            case "AUD":
                                TotAUD += double.Parse(reader["TotBalance"].ToString().Trim());
                                TmpIDR = double.Parse(reader["TotBalance"].ToString().Trim()) * TmpRate;
                                TotIncome += TmpIDR;
                                row = new string[] { reader["Acct_Name"].ToString().Trim(), "", Mdl1.FormatAmt(double.Parse(reader["TotBalance"].ToString().Trim())), "", "" };
                                gvIncome.Rows.Add(row);
                                break;
                            case "IDR":
                                TotIDR += double.Parse(reader["TotBalance"].ToString().Trim());
                                TmpIDR = double.Parse(reader["TotBalance"].ToString().Trim());
                                TotIncome += TmpIDR;
                                row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", "", Mdl1.FormatAmt(double.Parse(reader["TotBalance"].ToString().Trim())) };
                                gvIncome.Rows.Add(row);
                                break;
                            default:
                                TotOtherCurr += double.Parse(reader["TotBalance"].ToString().Trim());
                                TmpIDR = double.Parse(reader["TotBalance"].ToString().Trim()) * TmpRate;
                                TotIncome += TmpIDR;
                                row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", Mdl1.FormatAmt(double.Parse(reader["TotBalance"].ToString().Trim())), "" };
                                gvIncome.Rows.Add(row);
                                break;
                        }
                    }
                }
                reader.Close();
                row = new string[] { "TOTAL", Mdl1.FormatAmt(TotUSD), Mdl1.FormatAmt(TotAUD), Mdl1.FormatAmt(TotOtherCurr), Mdl1.FormatAmt(TotIDR) };
                gvIncome.Rows.Add(row);
                lblTotIncomeAUD.Text = Mdl1.FormatAmt((TotIncome / TmpAUDRate));
                if ((TotIncome / TmpAUDRate) >= 0)
                {
                    lblTotIncomeAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
                }
                else
                {
                    lblTotIncomeAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                }

                //Expense
                TotUSD = 0;
                TotAUD = 0;
                TotOtherCurr = 0;
                TotIDR = 0;
                if (CmbYear.Text == "All")
                {
                    Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Acct_Code, 1) = 'E' Group By A.Acct_Code, B.Acct_Name, B.Curr_Code, B.Acct_Order Order by B.Acct_Order";
                }
                else
                {
                    Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, Sum(A.Balance) As TotBalance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Trans_Month,4) = '" + CmbYear.Text + "' and left(A.Acct_Code, 1) = 'E' Group By A.Acct_Code, B.Acct_Name, B.Curr_Code, B.Acct_Order Order by B.Acct_Order";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TmpRate = 1;
                        if (CmbYear.Text == "All")
                        {
                            TmpRate = Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), String.Format("{0:yyyy}", DateTime.Now) + "12");
                        }
                        else
                        {
                            TmpRate = Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + "12");
                        }
                        switch (reader["Curr_Code"].ToString().Trim())
                        {
                            case "USD":
                                TotUSD += double.Parse(reader["TotBalance"].ToString().Trim());
                                TmpIDR = double.Parse(reader["TotBalance"].ToString().Trim()) * TmpRate;
                                TotExpense += TmpIDR;
                                row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["TotBalance"].ToString().Trim())), "", "", "" };
                                gvExpense.Rows.Add(row);
                                break;
                            case "AUD":
                                TotAUD += double.Parse(reader["TotBalance"].ToString().Trim());
                                TmpIDR = double.Parse(reader["TotBalance"].ToString().Trim()) * TmpRate;
                                TotExpense += TmpIDR;
                                row = new string[] { reader["Acct_Name"].ToString().Trim(), "", Mdl1.FormatAmt(double.Parse(reader["TotBalance"].ToString().Trim())), "", "" };
                                gvExpense.Rows.Add(row);
                                break;
                            case "IDR":
                                TotIDR += double.Parse(reader["TotBalance"].ToString().Trim());
                                TmpIDR = double.Parse(reader["TotBalance"].ToString().Trim());
                                TotExpense += TmpIDR;
                                row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", "", Mdl1.FormatAmt(double.Parse(reader["TotBalance"].ToString().Trim())) };
                                gvExpense.Rows.Add(row);
                                break;
                            default:
                                TotOtherCurr += double.Parse(reader["TotBalance"].ToString().Trim());
                                TmpIDR = double.Parse(reader["TotBalance"].ToString().Trim()) * TmpRate;
                                TotExpense += TmpIDR;
                                row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", Mdl1.FormatAmt(double.Parse(reader["TotBalance"].ToString().Trim())), "" };
                                gvExpense.Rows.Add(row);
                                break;
                        }
                    }
                }
                reader.Close();
                row = new string[] { "TOTAL", Mdl1.FormatAmt(TotUSD), Mdl1.FormatAmt(TotAUD), Mdl1.FormatAmt(TotOtherCurr), Mdl1.FormatAmt(TotIDR) };
                gvExpense.Rows.Add(row);
                lblTotExpenseAUD.Text = Mdl1.FormatAmt((TotExpense / TmpAUDRate));
                if ((TotExpense / TmpAUDRate) >= 0)
                {
                    lblTotExpenseAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
                }
                else
                {
                    lblTotExpenseAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                }

                lblTotNetIncomeAUD.Text = Mdl1.FormatAmt(((TotIncome - TotExpense) / TmpAUDRate));
                if (((TotIncome - TotExpense) / TmpAUDRate) >= 0)
                {
                    lblTotNetIncomeAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
                }
                else
                {
                    lblTotNetIncomeAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                }

                //Activa
                TotOpenUSD = 0;
                TotOpenAUD = 0;
                TotOpenOtherCurr = 0;
                TotOpenIDR = 0;
                TotCloseUSD = 0;
                TotCloseAUD = 0;
                TotCloseOtherCurr = 0;
                TotCloseIDR = 0;
                TotOpenActivaIDR = 0;
                TotCloseActivaIDR = 0;
                Mdl1.Ssql = "Select Acct_Code, Acct_Name from TblAcctRef where Acct_Type = '1' Order by Acct_Order";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TmpOpenUSD = 0;
                        TmpOpenAUD = 0;
                        TmpOpenOtherCurr = 0;
                        TmpOpenIDR = 0;
                        TmpCloseUSD = 0;
                        TmpCloseAUD = 0;
                        TmpCloseOtherCurr = 0;
                        TmpCloseIDR = 0;
                        TmpDiff = 0;

                        //Opening Balance
                        if (CmbYear.Text == "All")
                        {
                            strMonth = "";
                            Mdl1.Ssql = "Select top 1 Trans_Month from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "Order by Trans_Month";
                            OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Read();
                                strMonth = reader2["Trans_Month"].ToString().Trim();
                            }
                            reader2.Close();

                            if (strMonth.Trim() != "")
                            {
                                Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "' AND A.Trans_Month = '" + strMonth + "'";
                                cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                reader2 = cmd2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    switch (reader2["Curr_Code"].ToString().Trim())
                                    {
                                        case "USD":
                                            TmpOpenUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "AUD":
                                            TmpOpenAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "IDR":
                                            TmpOpenIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenIDR += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        default:
                                            TmpOpenOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                    }
                                }
                                reader2.Close();
                            }
                        }
                        else
                        {
                            Mdl1.Ssql = "Select top 1 A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + (int.Parse(CmbYear.Text.Trim()) - 1) + "12" + "'";
                            OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                RecNotFound = false;
                            }
                            else
                            {
                                RecNotFound = true;
                            }
                            reader2.Close();

                            if (!RecNotFound)
                            {
                                Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "' AND A.Trans_Month = '" + (int.Parse(CmbYear.Text.Trim()) - 1) + "12" + "'";
                                cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                reader2 = cmd2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    switch (reader2["Curr_Code"].ToString().Trim())
                                    {
                                        case "USD":
                                            TmpOpenUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "AUD":
                                            TmpOpenAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "IDR":
                                            TmpOpenIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenIDR += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        default:
                                            TmpOpenOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                    }
                                }
                                reader2.Close();
                            }
                            else
                            {
                                strMonth = "";
                                Mdl1.Ssql = "Select top 1 Trans_Month from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Trans_Month,4) = '" + CmbYear.Text.Trim() + "' Order by Trans_Month";
                                cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                reader2 = cmd2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    strMonth = reader2["Trans_Month"].ToString().Trim();
                                }
                                reader2.Close();

                                if (strMonth.Trim() != "")
                                {
                                    Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "' AND A.Trans_Month = '" + strMonth + "'";
                                    cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                    reader2 = cmd2.ExecuteReader();
                                    if (reader2.HasRows)
                                    {
                                        reader2.Read();
                                        switch (reader2["Curr_Code"].ToString().Trim())
                                        {
                                            case "USD":
                                                TmpOpenUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                                TotOpenUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                                break;
                                            case "AUD":
                                                TmpOpenAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                                TotOpenAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                                break;
                                            case "IDR":
                                                TmpOpenIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                                TotOpenIDR += double.Parse(reader2["Balance"].ToString().Trim());
                                                break;
                                            default:
                                                TmpOpenOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                                TotOpenOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                                break;
                                        }
                                    }
                                    reader2.Close();
                                }
                            }
                        }

                        //Closing Balance
                        if (CmbYear.Text == "All" || CmbYear.Text.Trim() == String.Format("{0:yyyy}", DateTime.Now))
                        {
                            //Current Year
                            Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblAsset A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "'";
                            OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Read();
                                switch (reader2["Curr_Code"].ToString().Trim())
                                {
                                    case "USD":
                                        TmpCloseUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                        TotCloseUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                        break;
                                    case "AUD":
                                        TmpCloseAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                        TotCloseAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                        break;
                                    case "IDR":
                                        TmpCloseIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                        TotCloseIDR += double.Parse(reader2["Balance"].ToString().Trim());

                                        break;
                                    default:
                                        TmpCloseOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                        TotCloseOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                        break;
                                }
                            }
                            reader2.Close();
                        }
                        else
                        {
                            //Not Current Year
                            strMonth = "";
                            Mdl1.Ssql = "Select top 1 Trans_Month from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Trans_Month,4) = '" + CmbYear.Text.Trim() + "' Order by Trans_Month Desc";
                            OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Read();
                                strMonth = reader2["Trans_Month"].ToString().Trim();
                            }
                            reader2.Close();

                            if (strMonth.Trim() != "")
                            {
                                Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "' AND A.Trans_Month = '" + strMonth + "'";
                                cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                reader2 = cmd2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    switch (reader2["Curr_Code"].ToString().Trim())
                                    {
                                        case "USD":
                                            TmpCloseUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotCloseUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "AUD":
                                            TmpCloseAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotCloseAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "IDR":
                                            TmpCloseIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotCloseIDR += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        default:
                                            TmpCloseOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotCloseOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                    }
                                }
                                reader2.Close();
                            }
                        }

                        //Differences
                        Mdl1.Ssql = "Select top 1 Curr_Code from TblAcctRef where Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "'";
                        OleDbCommand cmd3 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        OleDbDataReader reader3 = cmd3.ExecuteReader();
                        if (reader3.HasRows)
                        {
                            reader3.Read();
                            if (CmbYear.Text == "All")
                            {
                                TmpRate = Mdl1.GetCurrRate(reader3["Curr_Code"].ToString().Trim(), String.Format("{0:yyyy}", DateTime.Now) + "12");
                            }
                            else
                            {
                                TmpRate = Mdl1.GetCurrRate(reader3["Curr_Code"].ToString().Trim(), CmbYear.Text + "12");
                            }
                            switch (reader3["Curr_Code"].ToString().Trim())
                            {
                                case "USD":
                                    TmpDiff = TmpCloseUSD - TmpOpenUSD;
                                    TotOpenActivaIDR += TmpOpenUSD * TmpRate;
                                    TotCloseActivaIDR += TmpCloseUSD * TmpRate;
                                    break;
                                case "AUD":
                                    TmpDiff = TmpCloseAUD - TmpOpenAUD;
                                    TotOpenActivaIDR += TmpOpenAUD * TmpRate;
                                    TotCloseActivaIDR += TmpCloseAUD * TmpRate;
                                    break;
                                case "IDR":
                                    TmpDiff = TmpCloseIDR - TmpOpenIDR;
                                    TotOpenActivaIDR += TmpOpenIDR * TmpRate;
                                    TotCloseActivaIDR += TmpCloseIDR * TmpRate;
                                    break;
                                default:
                                    TmpDiff = TmpCloseOtherCurr - TmpOpenOtherCurr;
                                    TotOpenActivaIDR += TmpOpenOtherCurr * TmpRate;
                                    TotCloseActivaIDR += TmpCloseOtherCurr * TmpRate;
                                    break;
                            }
                        }
                        reader3.Close();

                        row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(TmpOpenUSD), Mdl1.FormatAmt(TmpOpenAUD), Mdl1.FormatAmt(TmpOpenOtherCurr), Mdl1.FormatAmt(TmpOpenIDR), Mdl1.FormatAmt(TmpCloseUSD), Mdl1.FormatAmt(TmpCloseAUD), Mdl1.FormatAmt(TmpCloseOtherCurr), Mdl1.FormatAmt(TmpCloseIDR), Mdl1.FormatAmt(TmpDiff) };
                        gvActiva.Rows.Add(row);
                    }
                }
                reader.Close();

                row = new string[] { "TOTAL", Mdl1.FormatAmt(TotOpenUSD), Mdl1.FormatAmt(TotOpenAUD), Mdl1.FormatAmt(TotOpenOtherCurr), Mdl1.FormatAmt(TotOpenIDR), Mdl1.FormatAmt(TotCloseUSD), Mdl1.FormatAmt(TotCloseAUD), Mdl1.FormatAmt(TotCloseOtherCurr), Mdl1.FormatAmt(TotCloseIDR), Mdl1.FormatAmt(0) };
                gvActiva.Rows.Add(row);

                lblTotOpenAssetAUD.Text = Mdl1.FormatAmt((TotOpenActivaIDR / TmpAUDRate));
                lblTotOpenAssetAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
                lblTotCloseAssetAUD.Text = Mdl1.FormatAmt((TotCloseActivaIDR / TmpAUDRate));
                lblTotCloseAssetAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);

                lblTotAssetDifferencesAUD.Text = Mdl1.FormatAmt(((TotCloseActivaIDR - TotOpenActivaIDR) / TmpAUDRate));
                if (((TotCloseActivaIDR - TotOpenActivaIDR) / TmpAUDRate) >= 0)
                {
                    lblTotAssetDifferencesAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
                }
                else
                {
                    lblTotAssetDifferencesAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                }

                //Passiva
                TotOpenUSD = 0;
                TotOpenAUD = 0;
                TotOpenOtherCurr = 0;
                TotOpenIDR = 0;
                TotCloseUSD = 0;
                TotCloseAUD = 0;
                TotCloseOtherCurr = 0;
                TotCloseIDR = 0;
                TotOpenPassivaIDR = 0;
                TotClosePassivaIDR = 0;
                Mdl1.Ssql = "Select Acct_Code, Acct_Name from TblAcctRef where Acct_Type = '2' Order by Acct_Order";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TmpOpenUSD = 0;
                        TmpOpenAUD = 0;
                        TmpOpenOtherCurr = 0;
                        TmpOpenIDR = 0;
                        TmpCloseUSD = 0;
                        TmpCloseAUD = 0;
                        TmpCloseOtherCurr = 0;
                        TmpCloseIDR = 0;
                        TmpDiff = 0;

                        //Opening Balance
                        if (CmbYear.Text == "All")
                        {
                            strMonth = "";
                            Mdl1.Ssql = "Select top 1 Trans_Month from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "Order by Trans_Month";
                            OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Read();
                                strMonth = reader2["Trans_Month"].ToString().Trim();
                            }
                            reader2.Close();

                            if (strMonth.Trim() != "")
                            {
                                Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "' AND A.Trans_Month = '" + strMonth + "'";
                                cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                reader2 = cmd2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    switch (reader2["Curr_Code"].ToString().Trim())
                                    {
                                        case "USD":
                                            TmpOpenUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "AUD":
                                            TmpOpenAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "IDR":
                                            TmpOpenIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenIDR += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        default:
                                            TmpOpenOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                    }
                                }
                                reader2.Close();
                            }
                        }
                        else
                        {
                            Mdl1.Ssql = "Select top 1 A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + (int.Parse(CmbYear.Text.Trim()) - 1) + "12" + "'";
                            OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                RecNotFound = false;
                            }
                            else
                            {
                                RecNotFound = true;
                            }
                            reader2.Close();

                            if (!RecNotFound)
                            {
                                Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "' AND A.Trans_Month = '" + (int.Parse(CmbYear.Text.Trim()) - 1) + "12" + "'";
                                cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                reader2 = cmd2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    switch (reader2["Curr_Code"].ToString().Trim())
                                    {
                                        case "USD":
                                            TmpOpenUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "AUD":
                                            TmpOpenAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "IDR":
                                            TmpOpenIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenIDR += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        default:
                                            TmpOpenOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotOpenOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                    }
                                }
                                reader2.Close();
                            }
                            else
                            {
                                strMonth = "";
                                Mdl1.Ssql = "Select top 1 Trans_Month from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Trans_Month,4) = '" + CmbYear.Text.Trim() + "' Order by Trans_Month";
                                cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                reader2 = cmd2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    strMonth = reader2["Trans_Month"].ToString().Trim();
                                }
                                reader2.Close();

                                if (strMonth.Trim() != "")
                                {
                                    Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "' AND A.Trans_Month = '" + strMonth + "'";
                                    cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                    reader2 = cmd2.ExecuteReader();
                                    if (reader2.HasRows)
                                    {
                                        reader2.Read();
                                        switch (reader2["Curr_Code"].ToString().Trim())
                                        {
                                            case "USD":
                                                TmpOpenUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                                TotOpenUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                                break;
                                            case "AUD":
                                                TmpOpenAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                                TotOpenAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                                break;
                                            case "IDR":
                                                TmpOpenIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                                TotOpenIDR += double.Parse(reader2["Balance"].ToString().Trim());
                                                break;
                                            default:
                                                TmpOpenOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                                TotOpenOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                                break;
                                        }
                                    }
                                    reader2.Close();
                                }
                            }
                        }

                        //Closing Balance
                        if (CmbYear.Text == "All" || CmbYear.Text.Trim() == String.Format("{0:yyyy}", DateTime.Now))
                        {
                            //Current Year
                            Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblLiability A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "'";
                            OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Read();
                                switch (reader2["Curr_Code"].ToString().Trim())
                                {
                                    case "USD":
                                        TmpCloseUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                        TotCloseUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                        break;
                                    case "AUD":
                                        TmpCloseAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                        TotCloseAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                        break;
                                    case "IDR":
                                        TmpCloseIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                        TotCloseIDR += double.Parse(reader2["Balance"].ToString().Trim());

                                        break;
                                    default:
                                        TmpCloseOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                        TotCloseOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                        break;
                                }
                            }
                            reader2.Close();
                        }
                        else
                        {
                            //Not Current Year
                            strMonth = "";
                            Mdl1.Ssql = "Select top 1 Trans_Month from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Trans_Month,4) = '" + CmbYear.Text.Trim() + "' Order by Trans_Month Desc";
                            OleDbCommand cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Read();
                                strMonth = reader2["Trans_Month"].ToString().Trim();
                            }
                            reader2.Close();

                            if (strMonth.Trim() != "")
                            {
                                Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "' AND A.Trans_Month = '" + strMonth + "'";
                                cmd2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                                reader2 = cmd2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    switch (reader2["Curr_Code"].ToString().Trim())
                                    {
                                        case "USD":
                                            TmpCloseUSD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotCloseUSD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "AUD":
                                            TmpCloseAUD = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotCloseAUD += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        case "IDR":
                                            TmpCloseIDR = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotCloseIDR += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                        default:
                                            TmpCloseOtherCurr = double.Parse(reader2["Balance"].ToString().Trim());
                                            TotCloseOtherCurr += double.Parse(reader2["Balance"].ToString().Trim());
                                            break;
                                    }
                                }
                                reader2.Close();
                            }
                        }

                        //Differences
                        Mdl1.Ssql = "Select top 1 Curr_Code from TblAcctRef where Acct_Code = '" + reader["Acct_Code"].ToString().Trim() + "'";
                        OleDbCommand cmd3 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        OleDbDataReader reader3 = cmd3.ExecuteReader();
                        if (reader3.HasRows)
                        {
                            reader3.Read();
                            if (CmbYear.Text == "All")
                            {
                                TmpRate = Mdl1.GetCurrRate(reader3["Curr_Code"].ToString().Trim(), String.Format("{0:yyyy}", DateTime.Now) + "12");
                            }
                            else
                            {
                                TmpRate = Mdl1.GetCurrRate(reader3["Curr_Code"].ToString().Trim(), CmbYear.Text + "12");
                            }
                            switch (reader3["Curr_Code"].ToString().Trim())
                            {
                                case "USD":
                                    TmpDiff = TmpCloseUSD - TmpOpenUSD;
                                    TotOpenPassivaIDR += TmpOpenUSD * TmpRate;
                                    TotClosePassivaIDR += TmpCloseUSD * TmpRate;
                                    break;
                                case "AUD":
                                    TmpDiff = TmpCloseAUD - TmpOpenAUD;
                                    TotOpenPassivaIDR += TmpOpenAUD * TmpRate;
                                    TotClosePassivaIDR += TmpCloseAUD * TmpRate;
                                    break;
                                case "IDR":
                                    TmpDiff = TmpCloseIDR - TmpOpenIDR;
                                    TotOpenPassivaIDR += TmpOpenIDR * TmpRate;
                                    TotClosePassivaIDR += TmpCloseIDR * TmpRate;
                                    break;
                                default:
                                    TmpDiff = TmpCloseOtherCurr - TmpOpenOtherCurr;
                                    TotOpenPassivaIDR += TmpOpenOtherCurr * TmpRate;
                                    TotClosePassivaIDR += TmpCloseOtherCurr * TmpRate;
                                    break;
                            }
                        }
                        reader3.Close();

                        row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(TmpOpenUSD), Mdl1.FormatAmt(TmpOpenAUD), Mdl1.FormatAmt(TmpOpenOtherCurr), Mdl1.FormatAmt(TmpOpenIDR), Mdl1.FormatAmt(TmpCloseUSD), Mdl1.FormatAmt(TmpCloseAUD), Mdl1.FormatAmt(TmpCloseOtherCurr), Mdl1.FormatAmt(TmpCloseIDR), Mdl1.FormatAmt(TmpDiff) };
                        gvPassiva.Rows.Add(row);
                    }
                }
                reader.Close();

                row = new string[] { "TOTAL", Mdl1.FormatAmt(TotOpenUSD), Mdl1.FormatAmt(TotOpenAUD), Mdl1.FormatAmt(TotOpenOtherCurr), Mdl1.FormatAmt(TotOpenIDR), Mdl1.FormatAmt(TotCloseUSD), Mdl1.FormatAmt(TotCloseAUD), Mdl1.FormatAmt(TotCloseOtherCurr), Mdl1.FormatAmt(TotCloseIDR), Mdl1.FormatAmt(0) };
                gvPassiva.Rows.Add(row);

                lblTotOpenLiabilityAUD.Text = Mdl1.FormatAmt((TotOpenPassivaIDR / TmpAUDRate));
                lblTotOpenLiabilityAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                lblTotCloseLiabilityAUD.Text = Mdl1.FormatAmt((TotClosePassivaIDR / TmpAUDRate));
                lblTotCloseLiabilityAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);

                lblTotLiabilityDifferencesAUD.Text = Mdl1.FormatAmt(((TotClosePassivaIDR - TotOpenPassivaIDR) / TmpAUDRate));
                if (((TotClosePassivaIDR - TotOpenPassivaIDR) / TmpAUDRate) >= 0)
                {
                    lblTotLiabilityDifferencesAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                }
                else
                {
                    lblTotLiabilityDifferencesAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
                }

                lblGrandTotalDifferencesAUD.Text = Mdl1.FormatAmt((((TotCloseActivaIDR - TotOpenActivaIDR) - (TotClosePassivaIDR - TotOpenPassivaIDR)) / TmpAUDRate));
                if ((((TotCloseActivaIDR - TotOpenActivaIDR) - (TotClosePassivaIDR - TotOpenPassivaIDR)) / TmpAUDRate) >= 0)
                {
                    lblGrandTotalDifferencesAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
                }
                else
                {
                    lblGrandTotalDifferencesAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }


        //---- the exports ---------------------------------------------------------
        //
        //This page has four tables and three sets of totals, and the export is every year on the
        //dropdown rather than the one on screen - so unlike the other export pages there is no
        //"what is showing" to read. Each tab is produced by putting the page into that year and
        //reading it back, and the page is put back as it was found before the workbook is
        //written.

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

        //A row of the sheet, padded out to the full width so every line is the same length -
        //the tables here are 5 and 10 columns wide, and Excel is handed one rectangle.
        private string[] Line(int parCols, params string[] parCells)
        {
            string[] r = new string[parCols];
            for (int i = 0; i < parCols; i++)
            {
                r[i] = ((parCells != null && i < parCells.Length && parCells[i] != null)
                        ? parCells[i] : "");
            }
            return r;
        }

        //The form's own Name leads the file name, so an export says which page it came from
        //before anything else.  Taken from this.Name rather than typed out, so it cannot drift
        //from the form it belongs to.  No year in it - every year is in the one workbook.
        private string Export_Name(string parExtension)
        {
            return Safe_Name(this.Name)
                 + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + parExtension;
        }

        //One laid-out sheet and the tab it belongs on.  Which rows are bold is carried with it
        //rather than worked out as three fixed indexes: this page has four tables and several
        //blocks of totals, so there is no single "the totals are here".
        private class Tab
        {
            public string Name;
            public List<string[]> Rows;
            public int Cols;
            public List<int> BoldRows;   //1-based, as Excel counts
            public List<int> HeadRows;   //1-based, a table's column headings
        }

        //One table: its headings, then its rows.
        private void Add_Grid(List<string[]> parSheet, int parCols, DataGridView parGrid,
                              List<int> parHeadRows)
        {
            string[] head = new string[parCols];
            for (int c = 0; c < parCols; c++)
            {
                head[c] = (c < parGrid.Columns.Count ? parGrid.Columns[c].Name : "");
            }
            parSheet.Add(head);
            parHeadRows.Add(parSheet.Count);

            for (int r = 0; r < parGrid.Rows.Count; r++)
            {
                string[] line = new string[parCols];
                for (int c = 0; c < parCols; c++)
                {
                    object v = (c < parGrid.Columns.Count ? parGrid.Rows[r].Cells[c].Value : null);
                    line[c] = (v == null ? "" : v.ToString());
                }
                parSheet.Add(line);
            }
        }

        //The whole sheet as a rectangle of strings, laid out before anything is asked to write
        //it.  parYear is what the sheet says it is for; it is passed in rather than read off the
        //dropdown so a tab is headed with its own year whatever the dropdown says by the time
        //the workbook is written.
        //
        //Income and Expense sit side by side on screen but are stacked here, each with its own
        //headings.  Side by side would mean offsetting one table into columns 7 onwards and
        //leaving the two wider tables below it straddling both - a spreadsheet reads them as
        //sections far better than as a picture of the form.
        private Tab Build_Sheet(string parName, string parYear)
        {
            Tab Made = new Tab();
            Made.Name = parName;
            Made.Cols = 10;             //the Asset and Liability tables are the widest
            Made.BoldRows = new List<int>();
            Made.HeadRows = new List<int>();

            int Cols = Made.Cols;
            List<string[]> Sheet = new List<string[]>();

            Sheet.Add(Line(Cols, "Yearly Summary"));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Year", parYear));
            Sheet.Add(Line(Cols, "Generated", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss")));
            Sheet.Add(Line(Cols));
            Sheet.Add(Line(Cols, "Exchange Rate " + Label5.Text.Trim(), lblUSD.Text.Trim()));
            Sheet.Add(Line(Cols, "Exchange Rate " + Label8.Text.Trim(), lblAUD.Text.Trim()));
            Sheet.Add(Line(Cols));

            //---- Income
            Sheet.Add(Line(Cols, Label11.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Add_Grid(Sheet, Cols, gvIncome, Made.HeadRows);
            Sheet.Add(Line(Cols, Label12.Text.Trim(), lblTotIncomeAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols));

            //---- Expense
            Sheet.Add(Line(Cols, Label14.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Add_Grid(Sheet, Cols, gvExpense, Made.HeadRows);
            Sheet.Add(Line(Cols, Label15.Text.Trim(), lblTotExpenseAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols));

            Sheet.Add(Line(Cols, Label17.Text.Trim(), lblTotNetIncomeAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols));

            //---- Asset
            Sheet.Add(Line(Cols, Label2.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Add_Grid(Sheet, Cols, gvActiva, Made.HeadRows);
            Sheet.Add(Line(Cols, label4.Text.Trim(), lblTotOpenAssetAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols, label7.Text.Trim(), lblTotCloseAssetAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols, label19.Text.Trim(), lblTotAssetDifferencesAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols));

            //---- Liability
            Sheet.Add(Line(Cols, label6.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Add_Grid(Sheet, Cols, gvPassiva, Made.HeadRows);
            Sheet.Add(Line(Cols, label9.Text.Trim(), lblTotOpenLiabilityAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols, label13.Text.Trim(), lblTotCloseLiabilityAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols, label10.Text.Trim(), lblTotLiabilityDifferencesAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);
            Sheet.Add(Line(Cols));

            Sheet.Add(Line(Cols, label16.Text.Trim(), lblGrandTotalDifferencesAUD.Text.Trim()));
            Made.BoldRows.Add(Sheet.Count);

            Made.Rows = Sheet;
            return Made;
        }

        //Excel will not take a tab name longer than 31 characters, and refuses : \ / ? * [ ]
        //outright.  A year is four digits and All is three, so nothing here is near either
        //limit - it is done anyway because the dropdown is filled from code that could change.
        private string Tab_Name(string parWanted, List<string> parTaken)
        {
            string TmpName = (parWanted == null ? "" : parWanted.Trim());
            foreach (char Bad in new char[] { ':', '\\', '/', '?', '*', '[', ']' })
            {
                TmpName = TmpName.Replace(Bad, '-');
            }
            if (TmpName.Length > 31)
            {
                TmpName = TmpName.Substring(0, 31);
            }
            if (TmpName == "")
            {
                TmpName = "Sheet";
            }

            string TmpTry = TmpName;
            int TmpNext = 2;
            while (parTaken.Contains(TmpTry.ToUpper()))
            {
                string TmpSuffix = " (" + TmpNext.ToString() + ")";
                int TmpRoom = 31 - TmpSuffix.Length;
                TmpTry = (TmpName.Length > TmpRoom ? TmpName.Substring(0, TmpRoom) : TmpName) + TmpSuffix;
                TmpNext = TmpNext + 1;
            }
            parTaken.Add(TmpTry.ToUpper());
            return TmpTry;
        }

        //Every year on the dropdown : All first, then the years newest to oldest.
        //
        //The order is sorted here rather than taken from the dropdown's own.  Mdl1.Fill_Year
        //happens to add them in that order already, but the workbook was asked for in it, and a
        //later change to how the list is filled should not quietly reorder the tabs.
        private List<string> Years_To_Export()
        {
            List<string> Years = new List<string>();
            foreach (object Item in CmbYear.Items)
            {
                string TmpYear = (Item == null ? "" : Item.ToString().Trim());
                if (TmpYear != "" && TmpYear != "All")
                {
                    Years.Add(TmpYear);
                }
            }
            Years.Sort(StringComparer.Ordinal);
            Years.Reverse();

            //All leads, whether or not the dropdown happens to carry it
            Years.Insert(0, "All");
            return Years;
        }

        //Each tab is the page put into that year and read back, rather than a second set of
        //queries written for the purpose - so a tab shows exactly what the user would see having
        //chosen that year, and there is no second copy of nine hundred lines of totalling to
        //drift.  The page is put back as it was found before this returns.
        private List<Tab> Build_Tabs()
        {
            List<Tab> Tabs = new List<Tab>();
            List<string> Taken = new List<string>();
            string TmpWas = CmbYear.Text;

            try
            {
                foreach (string Year in Years_To_Export())
                {
                    //Filling keeps the dropdown's own handler out of it, so the page is
                    //refreshed once here rather than twice.
                    Filling = true;
                    CmbYear.Text = Year;
                    Filling = false;

                    //Assigning Text on a DropDownList does nothing at all when the value is not
                    //among its items, and it fails silently - which would leave a tab headed
                    //with one year sitting over another year's figures.  The years came from
                    //the items, so this cannot happen; it is checked because the cost of being
                    //wrong is a plausible-looking sheet of the wrong numbers.
                    if (CmbYear.Text.Trim() != Year)
                    {
                        throw new Exception("The page could not be put into year " + Year + ".");
                    }

                    Get_Data();
                    Tabs.Add(Build_Sheet(Tab_Name(Year, Taken), Year));
                }
            }
            finally
            {
                Filling = true;
                CmbYear.Text = TmpWas;
                Filling = false;
                Get_Data();
            }
            return Tabs;
        }

        private void Write_Workbook(List<Tab> parTabs, string parPath)
        {
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

                for (int i = 0; i < parTabs.Count; i++)
                {
                    Tab This = parTabs[i];
                    List<string[]> Sheet = This.Rows;
                    int Cols = This.Cols;

                    object[,] Data = new object[Sheet.Count, Cols];
                    for (int r = 0; r < Sheet.Count; r++)
                    {
                        for (int c = 0; c < Cols; c++)
                        {
                            Data[r, c] = Sheet[r][c];
                        }
                    }

                    //a new workbook opens with one sheet; the rest are added after it, in order
                    if (i == 0)
                    {
                        ws = (Excel.Worksheet)sheets[1];
                    }
                    else
                    {
                        ws = (Excel.Worksheet)sheets.Add(Type.Missing, sheets[sheets.Count],
                                                         Type.Missing, Type.Missing);
                    }
                    ws.Name = This.Name;

                    all = ws.Range[ws.Cells[1, 1], ws.Cells[Sheet.Count, Cols]];
                    //Written as text on purpose.  Left to itself Excel re-reads every value and
                    //throws away the formatting the screen is showing : a negative comes back as
                    //a red bracketed figure, and what is recognised as a number at all depends
                    //on the machine's locale.  The export is meant to be what the user is
                    //looking at, so the cells are kept exactly as displayed.
                    all.NumberFormat = "@";
                    all.Value2 = Data;

                    one = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                    one.Font.Bold = true;
                    one.Font.Size = 14;
                    Marshal.ReleaseComObject(one);
                    one = null;

                    foreach (int RowAt in This.BoldRows)
                    {
                        one = ws.Range[ws.Cells[RowAt, 1], ws.Cells[RowAt, 2]];
                        one.Font.Bold = true;
                        Marshal.ReleaseComObject(one);
                        one = null;
                    }

                    foreach (int RowAt in This.HeadRows)
                    {
                        one = ws.Range[ws.Cells[RowAt, 1], ws.Cells[RowAt, Cols]];
                        one.Font.Bold = true;
                        one.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                        Marshal.ReleaseComObject(one);
                        one = null;
                    }

                    cols = ws.Columns;
                    cols.AutoFit();

                    //every tab creates its own COM objects, and one left behind keeps an
                    //invisible EXCEL.EXE alive - so they are released here rather than only
                    //at the end
                    Marshal.ReleaseComObject(cols);
                    cols = null;
                    Marshal.ReleaseComObject(all);
                    all = null;
                    Marshal.ReleaseComObject(ws);
                    ws = null;
                }

                //the first tab is the one showing when it opens
                ws = (Excel.Worksheet)sheets[1];
                ws.Activate();

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

        //Both buttons build the same tabs. Excel asks where to put the workbook and stops
        //there; Drive writes it to a temporary file and sends that on. Busy state is handled by
        //the callers rather than inside Write_Workbook because it covers the sign-in too.

        private void Busy(bool parBusy)
        {
            Cursor.Current = (parBusy ? Cursors.WaitCursor : Cursors.Default);
            CmdExcel.Enabled = !parBusy;
            CmdDrive.Enabled = !parBusy;
            CmdBack.Enabled = !parBusy;
            CmbYear.Enabled = !parBusy;
        }

        private void CmdExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Generate Excel";
            dlg.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            dlg.FileName = Export_Name(".xlsx");
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //Nothing is refused for being empty here.  The other export pages send one view and
            //stop if it has no rows; this one sends every year, and a year with nothing in it is
            //a fact about that year rather than a reason to withhold the other ten.
            Busy(true);
            List<Tab> Tabs = null;
            try
            {
                Tabs = Build_Tabs();
                Write_Workbook(Tabs, dlg.FileName);
                MessageBox.Show("Excel file generated :" + Environment.NewLine + dlg.FileName
                    + Environment.NewLine + Environment.NewLine
                    + Tabs.Count.ToString() + " tabs : "
                    + string.Join(", ", Tabs.Select(x => x.Name).ToArray()), "Success");
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

        //Names the tabs in the success dialog, so it is obvious what went in without having to
        //open the Sheet to find out.  Eleven of them, so they are counted rather than listed in
        //full when there are more than a handful.
        private string Tabs_Said(List<Tab> parTabs)
        {
            if (parTabs == null || parTabs.Count == 0)
            {
                return "";
            }
            if (parTabs.Count == 1)
            {
                return "One tab : " + parTabs[0].Name;
            }
            List<string> Names = new List<string>();
            foreach (Tab One in parTabs)
            {
                Names.Add(One.Name);
            }
            return parTabs.Count.ToString() + " tabs : " + string.Join(", ", Names.ToArray());
        }

        //Builds the same workbook into a temporary file, signs in, uploads it as a Google Sheet
        //and throws the temporary file away. The user is never asked where to put it - that is
        //what the Excel button is for.
        private void CmdDrive_Click(object sender, EventArgs e)
        {
            if (!Google_Drive.Configured)
            {
                MessageBox.Show("Google Drive is not set up yet." + Environment.NewLine
                    + Environment.NewLine + Google_Drive.Setup_Hint(), "Error Message");
                return;
            }

            //The same file every time, so the link keeps working and whoever it is shared with
            //sees the latest figures rather than collecting a new file per export.  One name for
            //the page rather than one per year : every year is in this workbook already, a tab
            //each, so there is nothing for the name to vary by.
            string TmpTitle = Google_Drive.Yearly_Summary_Sheet_Name();
            string TmpPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(),
                                                    Export_Name("") + ".xlsx");

            //This page has no note line to report progress on, unlike the other three that
            //export to Drive. The title bar stands in for it: building eleven tabs takes a
            //moment, and the sign-in waits on a browser window that opens behind this one, so a
            //wait cursor on its own leaves the user with nothing to read.
            string TmpOldTitle = this.Text;

            List<Tab> Tabs = null;
            Busy(true);
            try
            {
                this.Text = TmpOldTitle + "  -  building the workbook ...";
                this.Refresh();
                Tabs = Build_Tabs();
                Write_Workbook(Tabs, TmpPath);

                this.Text = TmpOldTitle + "  -  waiting for you to sign in to Google in your browser ...";
                this.Refresh();
                string TmpWhy;
                string TmpToken = Google_Drive.Sign_In(out TmpWhy);
                if (TmpToken == null)
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                this.Text = TmpOldTitle + "  -  uploading to Google Drive ...";
                this.Refresh();
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
                    + Environment.NewLine + Environment.NewLine
                    + Tabs_Said(Tabs)
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
                this.Text = TmpOldTitle;
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
