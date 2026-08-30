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
    public partial class Yearly_Summary : Form
    {
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

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }        
    }
}
