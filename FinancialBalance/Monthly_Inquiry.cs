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
    public partial class Monthly_Inquiry : Form
    {
        public Monthly_Inquiry()
        {
            InitializeComponent();
        }

        private void Monthly_Inquiry_Load(object sender, EventArgs e)
        {
            Mdl1.Fill_Month(CmbMM, CmbYear);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);
        }

        private void CmbMM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Data();
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Data();
        }

        private void Clear_Grid()
        {
            gvActiva.Columns.Clear();
            gvActiva.ColumnCount = 5;
            gvActiva.Columns[0].Name = "Account Name";
            gvActiva.Columns[0].FillWeight = 34;
            gvActiva.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvActiva.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvActiva.Columns[1].Name = "USD";
            gvActiva.Columns[1].FillWeight = 17;
            gvActiva.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[2].Name = "AUD";
            gvActiva.Columns[2].FillWeight = 17;
            gvActiva.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[3].Name = "Other Curr";
            gvActiva.Columns[3].FillWeight = 9;
            gvActiva.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvActiva.Columns[4].Name = "IDR";
            gvActiva.Columns[4].FillWeight = 23;
            gvActiva.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvActiva.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gvPassiva.Columns.Clear();
            gvPassiva.ColumnCount = 5;
            gvPassiva.Columns[0].Name = "Account Name";
            gvPassiva.Columns[0].FillWeight = 34;
            gvPassiva.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPassiva.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPassiva.Columns[1].Name = "USD";
            gvPassiva.Columns[1].FillWeight = 17;
            gvPassiva.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[2].Name = "AUD";
            gvPassiva.Columns[2].FillWeight = 17;
            gvPassiva.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[3].Name = "Other Curr";
            gvPassiva.Columns[3].FillWeight = 9;
            gvPassiva.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPassiva.Columns[4].Name = "IDR";
            gvPassiva.Columns[4].FillWeight = 23;
            gvPassiva.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPassiva.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
        }

        private void Get_Data()
        {
            double TotUSD;
		    double TotAUD;
		    double TotOtherCurr;
		    double TotIDR;
            double TotCurrentAssetIDR;
            double TotCurrentAssetAUD;
            double TotNonCurrentAssetIDR;
            double TotNonCurrentAssetAUD;
            double TotAssetIDR;
            double TotAssetAUD;
            double TotLiabilityIDR;
            double TotLiabilityAUD;
            double TotIncomeIDR;
            double TotIncomeAUD;
		    double TotExpenseIDR;
            double TotExpenseAUD;
            double TmpIDR;
            bool RecNotFound;

            Clear_Grid();

            lblUSD.Text = Mdl1.FormatAmt(Mdl1.GetCurrRate("USD", CmbYear.Text + CmbMM.Text));
		    lblAUD.Text = Mdl1.FormatAmt(Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text));

            TotCurrentAssetIDR = 0;
            TotCurrentAssetAUD = 0;
            TotNonCurrentAssetIDR = 0;
            TotNonCurrentAssetAUD = 0;
            TotAssetIDR = 0;
            TotAssetAUD = 0;
		    TotLiabilityIDR = 0;
            TotLiabilityAUD = 0;
		    TotIncomeIDR = 0;
            TotIncomeAUD = 0;
		    TotExpenseIDR = 0;
            TotExpenseAUD = 0;

            string[] row;

            //Activa
            TotUSD = 0;
		    TotAUD = 0;
		    TotOtherCurr = 0;
		    TotIDR = 0;
            Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance, B.Current_Asset from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + CmbYear.Text + CmbMM.Text + "' and left(A.Acct_Code, 1) = 'A' order by B.Acct_order";            
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    switch (reader["Curr_Code"].ToString().Trim())
                    {
                        case "USD":
                            TotUSD += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotAssetIDR += TmpIDR;
                            if (reader["Current_Asset"].ToString().Trim() == "True")
                            {
                                TotCurrentAssetIDR += TmpIDR;
                            }
                            else
                            {
                                TotNonCurrentAssetIDR += TmpIDR;
                            }
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "", "" };
                            gvActiva.Rows.Add(row);
                            break;
                        case "AUD":
                            TotAUD += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotAssetIDR += TmpIDR;
                            if (reader["Current_Asset"].ToString().Trim() == "True")
                            {
                                TotCurrentAssetIDR += TmpIDR;
                            }
                            else
                            {
                                TotNonCurrentAssetIDR += TmpIDR;
                            }
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "" };
                            gvActiva.Rows.Add(row);
                            break;
                        case "IDR":
                            TotIDR += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim());
                            TotAssetIDR += TmpIDR;
                            if (reader["Current_Asset"].ToString().Trim() == "True")
                            {
                                TotCurrentAssetIDR += TmpIDR;
                            }
                            else
                            {
                                TotNonCurrentAssetIDR += TmpIDR;
                            }
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())) };
                            gvActiva.Rows.Add(row);
                            break;
                        default:
                            TotOtherCurr += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotAssetIDR += TmpIDR;
                            if (reader["Current_Asset"].ToString().Trim() == "True")
                            {
                                TotCurrentAssetIDR += TmpIDR;
                            }
                            else
                            {
                                TotNonCurrentAssetIDR += TmpIDR;
                            }
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "" };
                            gvActiva.Rows.Add(row);
                            break;
                    }
                }
                RecNotFound = false;
            }
            else
            {
                RecNotFound = true;
            }
            reader.Close();
            if (int.Parse(CmbYear.Text + CmbMM.Text) >= 201002)
            {
                if (RecNotFound)
                {
                    Mdl1.Ssql = "Select A.Acct_Code, B.Acct_Name, B.Curr_Code, A.Balance, B.Current_Asset from TblAsset A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Acct_Code,1) = 'A' order by B.Acct_order";
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            switch (reader["Curr_Code"].ToString().Trim())
                            {
                                case "USD":
                                    TotUSD += double.Parse(reader["Balance"].ToString().Trim());
                                    TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                                    TotAssetIDR += TmpIDR;
                                    if (reader["Current_Asset"].ToString().Trim() == "True")
                                    {
                                        TotCurrentAssetIDR += TmpIDR;
                                    }
                                    else
                                    {
                                        TotNonCurrentAssetIDR += TmpIDR;
                                    }
                                    row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "", "" };
                                    gvActiva.Rows.Add(row);
                                    break;
                                case "AUD":
                                    TotAUD += double.Parse(reader["Balance"].ToString().Trim());
                                    TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                                    TotAssetIDR += TmpIDR;
                                    if (reader["Current_Asset"].ToString().Trim() == "True")
                                    {
                                        TotCurrentAssetIDR += TmpIDR;
                                    }
                                    else
                                    {
                                        TotNonCurrentAssetIDR += TmpIDR;
                                    }
                                    row = new string[] { reader["Acct_Name"].ToString().Trim(), "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "" };
                                    gvActiva.Rows.Add(row);
                                    break;
                                case "IDR":
                                    TotIDR += double.Parse(reader["Balance"].ToString().Trim());
                                    TmpIDR = double.Parse(reader["Balance"].ToString().Trim());
                                    TotAssetIDR += TmpIDR;
                                    if (reader["Current_Asset"].ToString().Trim() == "True")
                                    {
                                        TotCurrentAssetIDR += TmpIDR;
                                    }
                                    else
                                    {
                                        TotNonCurrentAssetIDR += TmpIDR;
                                    }
                                    row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())) };
                                    gvActiva.Rows.Add(row);
                                    break;
                                default:
                                    TotOtherCurr += double.Parse(reader["Balance"].ToString().Trim());
                                    TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                                    TotAssetIDR += TmpIDR;
                                    if (reader["Current_Asset"].ToString().Trim() == "True")
                                    {
                                        TotCurrentAssetIDR += TmpIDR;
                                    }
                                    else
                                    {
                                        TotNonCurrentAssetIDR += TmpIDR;
                                    }
                                    row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "" };
                                    gvActiva.Rows.Add(row);
                                    break;
                            }
                        }
                    }
                    reader.Close();
                }
            }
            row = new string[] { "TOTAL", Mdl1.FormatAmt(TotUSD), Mdl1.FormatAmt(TotAUD), Mdl1.FormatAmt(TotOtherCurr), Mdl1.FormatAmt(TotIDR) };
            gvActiva.Rows.Add(row);
            lblTotAssetIDR.Text = Mdl1.FormatAmt(TotAssetIDR);
		    if (TotAssetIDR >= 0)
            {
                lblTotAssetIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
		    else
            {
                lblTotAssetIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
		    }
            TotAssetAUD = TotAssetIDR / (Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text));
            lblTotAssetAUD.Text = Mdl1.FormatAmt(TotAssetAUD);
            if (TotAssetAUD >= 0)
            {
                lblTotAssetAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
		    else
            {
                lblTotAssetAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
		    }
            TotCurrentAssetAUD = TotCurrentAssetIDR / (Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text));
            lblTotCurrentAssetAUD.Text = Mdl1.FormatAmt(TotCurrentAssetAUD);
            if (TotCurrentAssetAUD >= 0)
            {
                lblTotCurrentAssetAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
            else
            {
                lblTotCurrentAssetAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
            }
            TotNonCurrentAssetAUD = TotNonCurrentAssetIDR / (Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text));
            lblTotNonCurrentAssetAUD.Text = Mdl1.FormatAmt(TotNonCurrentAssetAUD);
            if (TotNonCurrentAssetAUD >= 0)
            {
                lblTotNonCurrentAssetAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
            else
            {
                lblTotNonCurrentAssetAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
            }

            //Passiva
            TotUSD = 0;
            TotAUD = 0;
            TotOtherCurr = 0;
            TotIDR = 0;
            Mdl1.Ssql = "Select B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + CmbYear.Text + CmbMM.Text + "' and left(A.Acct_Code, 1) = 'L' order by B.Acct_order";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    switch (reader["Curr_Code"].ToString().Trim())
                    {
                        case "USD":
                            TotUSD += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotLiabilityIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "", "" };
                            gvPassiva.Rows.Add(row);
                            break;
                        case "AUD":
                            TotAUD += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotLiabilityIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "" };
                            gvPassiva.Rows.Add(row);
                            break;
                        case "IDR":
                            TotIDR += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim());
                            TotLiabilityIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())) };
                            gvPassiva.Rows.Add(row);
                            break;
                        default:
                            TotOtherCurr += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotLiabilityIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "" };
                            gvPassiva.Rows.Add(row);
                            break;
                    }
                }
                RecNotFound = false;
            }
            else
            {
                RecNotFound = true;
            }
            reader.Close();
            if (int.Parse(CmbYear.Text + CmbMM.Text) >= 201002)
            {
                if (RecNotFound)
                {
                    Mdl1.Ssql = "Select B.Acct_Name, B.Curr_Code, A.Balance from TblLiability A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where left(A.Acct_Code,1) = 'L' order by B.Acct_order";
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            switch (reader["Curr_Code"].ToString().Trim())
                            {
                                case "USD":
                                    TotUSD += double.Parse(reader["Balance"].ToString().Trim());
                                    TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                                    TotLiabilityIDR += TmpIDR;
                                    row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "", "" };
                                    gvPassiva.Rows.Add(row);
                                    break;
                                case "AUD":
                                    TotAUD += double.Parse(reader["Balance"].ToString().Trim());
                                    TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                                    TotLiabilityIDR += TmpIDR;
                                    row = new string[] { reader["Acct_Name"].ToString().Trim(), "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "" };
                                    gvPassiva.Rows.Add(row);
                                    break;
                                case "IDR":
                                    TotIDR += double.Parse(reader["Balance"].ToString().Trim());
                                    TmpIDR = double.Parse(reader["Balance"].ToString().Trim());
                                    TotLiabilityIDR += TmpIDR;
                                    row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())) };
                                    gvPassiva.Rows.Add(row);
                                    break;
                                default:
                                    TotOtherCurr += double.Parse(reader["Balance"].ToString().Trim());
                                    TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                                    TotLiabilityIDR += TmpIDR;
                                    row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "" };
                                    gvPassiva.Rows.Add(row);
                                    break;
                            }
                        }
                    }
                    reader.Close();
                }
            }
            row = new string[] { "TOTAL", Mdl1.FormatAmt(TotUSD), Mdl1.FormatAmt(TotAUD), Mdl1.FormatAmt(TotOtherCurr), Mdl1.FormatAmt(TotIDR) };
            gvPassiva.Rows.Add(row);
            lblTotLiabilityIDR.Text = Mdl1.FormatAmt(TotLiabilityIDR);
            if (TotLiabilityIDR >= 0)
            {
                lblTotLiabilityIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
            }
            else
            {
                lblTotLiabilityIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
            TotLiabilityAUD = TotLiabilityIDR / (Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text));
            lblTotLiabilityAUD.Text = Mdl1.FormatAmt(TotLiabilityAUD);
            if (TotLiabilityAUD >= 0)
            {
                lblTotLiabilityAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
            }
		    else
            {
                lblTotLiabilityAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
		    }

            lblTotAssetLiabilityIDR.Text = Mdl1.FormatAmt(TotAssetIDR - TotLiabilityIDR);
		    if ((TotAssetIDR - TotLiabilityIDR) >= 0)
            {
                lblTotAssetLiabilityIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
		    }
            else
            {
			    lblTotAssetLiabilityIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
		    }
            lblTotAssetLiabilityAUD.Text = Mdl1.FormatAmt((TotAssetIDR - TotLiabilityIDR) / (Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text)));
            if ((TotAssetIDR - TotLiabilityIDR) / (Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text)) >= 0)
            {
                lblTotAssetLiabilityAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
            else
            {
                lblTotAssetLiabilityAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
            }

            //Income
            TotUSD = 0;
            TotAUD = 0;
            TotOtherCurr = 0;
            TotIDR = 0;
            Mdl1.Ssql = "Select B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + CmbYear.Text + CmbMM.Text + "' and left(A.Acct_Code, 1) = 'I' order by B.Acct_order";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    switch (reader["Curr_Code"].ToString().Trim())
                    {
                        case "USD":
                            TotUSD += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotIncomeIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "", "" };
                            gvIncome.Rows.Add(row);
                            break;
                        case "AUD":
                            TotAUD += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotIncomeIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "" };
                            gvIncome.Rows.Add(row);
                            break;
                        case "IDR":
                            TotIDR += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim());
                            TotIncomeIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())) };
                            gvIncome.Rows.Add(row);
                            break;
                        default:
                            TotOtherCurr += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotIncomeIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "" };
                            gvIncome.Rows.Add(row);
                            break;
                    }
                }
            }
            reader.Close();
            row = new string[] { "TOTAL", Mdl1.FormatAmt(TotUSD), Mdl1.FormatAmt(TotAUD), Mdl1.FormatAmt(TotOtherCurr), Mdl1.FormatAmt(TotIDR) };
            gvIncome.Rows.Add(row);
            lblTotIncomeIDR.Text = Mdl1.FormatAmt(TotIncomeIDR);
            if (TotIncomeIDR >= 0)
            {
                lblTotIncomeIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
            else
            {
                lblTotIncomeIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
            }
            TotIncomeAUD = TotIncomeIDR / (Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text));
            lblTotIncomeAUD.Text = Mdl1.FormatAmt(TotIncomeAUD);
            if (TotIncomeAUD >= 0)
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
            Mdl1.Ssql = "Select B.Acct_Name, B.Curr_Code, A.Balance from TblMonthlyTrans A left join TblAcctRef B on B.Acct_Code = A.Acct_Code " + "where A.Trans_Month = '" + CmbYear.Text + CmbMM.Text + "' and left(A.Acct_Code, 1) = 'E' order by B.Acct_order";
            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    switch (reader["Curr_Code"].ToString().Trim())
                    {
                        case "USD":
                            TotUSD += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotExpenseIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "", "" };
                            gvExpense.Rows.Add(row);
                            break;
                        case "AUD":
                            TotAUD += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotExpenseIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "", "" };
                            gvExpense.Rows.Add(row);
                            break;
                        case "IDR":
                            TotIDR += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim());
                            TotExpenseIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())) };
                            gvExpense.Rows.Add(row);
                            break;
                        default:
                            TotOtherCurr += double.Parse(reader["Balance"].ToString().Trim());
                            TmpIDR = double.Parse(reader["Balance"].ToString().Trim()) * Mdl1.GetCurrRate(reader["Curr_Code"].ToString().Trim(), CmbYear.Text + CmbMM.Text);
                            TotExpenseIDR += TmpIDR;
                            row = new string[] { reader["Acct_Name"].ToString().Trim(), "", "", Mdl1.FormatAmt(double.Parse(reader["Balance"].ToString().Trim())), "" };
                            gvExpense.Rows.Add(row);
                            break;
                    }
                }
            }
            reader.Close();
            row = new string[] { "TOTAL", Mdl1.FormatAmt(TotUSD), Mdl1.FormatAmt(TotAUD), Mdl1.FormatAmt(TotOtherCurr), Mdl1.FormatAmt(TotIDR) };
            gvExpense.Rows.Add(row);
            lblTotExpenseIDR.Text = Mdl1.FormatAmt(TotExpenseIDR);
            if (TotExpenseIDR >= 0)
            {
                lblTotExpenseIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
            }
            else
            {
                lblTotExpenseIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
            TotExpenseAUD = TotExpenseIDR / (Mdl1.GetCurrRate("AUD", CmbYear.Text + CmbMM.Text));
            lblTotExpenseAUD.Text = Mdl1.FormatAmt(TotExpenseAUD);
            if (TotExpenseAUD >= 0)
            {
                lblTotExpenseAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
            }
            else
            {
                lblTotExpenseAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }

            lblTotNetIncomeIDR.Text = Mdl1.FormatAmt(TotIncomeIDR - TotExpenseIDR);
		    if ((TotIncomeIDR - TotExpenseIDR) >= 0)
            {
                lblTotNetIncomeIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
		    }
            else
            {
			    lblTotNetIncomeIDR.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
		    }
            lblTotNetIncomeAUD.Text = Mdl1.FormatAmt(TotIncomeAUD - TotExpenseAUD);
            if ((TotIncomeAUD - TotExpenseAUD) >= 0)
            {
                lblTotNetIncomeAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF8080);
            }
            else
            {
                lblTotNetIncomeAUD.ForeColor = System.Drawing.ColorTranslator.FromOle(0xFF);
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
