using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace FinancialBalance
{
    public partial class ETF_Stocks_Investment : Form
    {
        bool FirstLoad;
        bool Filling;

        //TblETFStocksPortfolio holds one running row per portfolio code; every movement that
        //produced it is kept in TblETFStocksPortfolioInvestment, so the balance can always be
        //traced back to the entries that made it.
        string EditCode;

        public ETF_Stocks_Investment()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Investment_Load(object sender, EventArgs e)
        {
            FirstLoad = true;
            Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

            Filling = true;
            Fill_Portfolio_Code();
            Fill_Investment_Type();
            Mdl1.Fill_Curr(CmbCurrency);
            Mdl1.Fill_Curr(CmbEditCurrency);
            Set_Default_Currency(CmbCurrency);
            Filling = false;

            //Fill_Portfolio_Code selects the first code while Filling suppresses events,
            //so the description is resolved once here for whatever it landed on.
            Show_Portfolio_Description();

            txtAmount.Text = "0.00";
            ChangeLblDay();
            Clear_Grid();
            Get_Data();
            End_Edit();
            FirstLoad = false;

            monthCalendar1.Hide();
        }

        private void MnDaily_Click(object sender, EventArgs e)
        {
            Daily_Input Daily_Input = new Daily_Input();
            Daily_Input.Show();
            this.Close();
        }

        private void MnMonthlyClosing_Click(object sender, EventArgs e)
        {
            Monthly_Closing Monthly_Closing = new Monthly_Closing();
            Monthly_Closing.Show();
            this.Close();
        }

        private void MnETFStocksTrans_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Transaction ETF_Stocks_Transaction = new ETF_Stocks_Transaction();
            ETF_Stocks_Transaction.Show();
            this.Close();
        }

        private void MnETFStocksPrice_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Price ETF_Stocks_Price = new ETF_Stocks_Price();
            ETF_Stocks_Price.Show();
            this.Close();
        }

        //Fill_Curr defaults to IDR for the accounting pages; ETF money defaults to AUD
        private void Set_Default_Currency(ComboBox parCombo)
        {
            if (parCombo.Items.Contains("AUD"))
            {
                parCombo.Text = "AUD";
            }
        }

        //A stored currency need not still be one of the codes in Currency Setup.  It is what
        //the row actually holds, so it is added to the list rather than dropped, which keeps
        //the dropdown from disagreeing with the record being edited.
        private void Select_Currency(ComboBox parCombo, string parCurrency)
        {
            string TmpCurrency = parCurrency.Trim();
            if (TmpCurrency == "")
            {
                return;
            }
            if (!parCombo.Items.Contains(TmpCurrency))
            {
                parCombo.Items.Add(TmpCurrency);
            }
            parCombo.Text = TmpCurrency;
        }

        private void Fill_Portfolio_Code()
        {
            CmbPortfolioCode.Items.Clear();
            Mdl1.Ssql = "Select Portfolio_Code from TblETFStocksPortfolioCode order by Portfolio_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbPortfolioCode.Items.Add(reader["Portfolio_Code"].ToString().Trim());
            }
            reader.Close();
            if (CmbPortfolioCode.Items.Count > 0)
            {
                CmbPortfolioCode.SelectedIndex = 0;
            }
        }

        private void CmbPortfolioCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Portfolio_Description();
        }

        //The code is what gets stored, but it is only five characters; the description is
        //shown beside it so the right portfolio is obvious without opening the setup page.
        private void Show_Portfolio_Description()
        {
            string TmpCode = CmbPortfolioCode.Text.Trim();
            if (TmpCode == "")
            {
                LblPortfolioDesc.Text = "";
                return;
            }

            string TmpDesc = Description_For(TmpCode);
            LblPortfolioDesc.Text = (TmpDesc == "" ? "-" : TmpDesc);
        }

        //"+" pays money in, "-" takes it out; the sign lives here rather than on the amount
        private void Fill_Investment_Type()
        {
            CmbInvType.Items.Clear();
            CmbInvType.Items.Add("+");
            CmbInvType.Items.Add("-");
            CmbInvType.SelectedIndex = 0;
        }

        private string Get_Investment_Date()
        {
            return CmbYear.Text + CmbMM.Text + CmbDD.Text;
        }

        private void ChangeLblDay()
        {
            switch (DateTime.Parse(Mdl1.toLongDate(Get_Investment_Date())).DayOfWeek)
            {
                case DayOfWeek.Monday:
                    LblDay.Text = "Monday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Tuesday:
                    LblDay.Text = "Tuesday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Wednesday:
                    LblDay.Text = "Wednesday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Thursday:
                    LblDay.Text = "Thursday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Friday:
                    LblDay.Text = "Friday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Saturday:
                    LblDay.Text = "Saturday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(12582912);
                    break;
                case DayOfWeek.Sunday:
                    LblDay.Text = "Sunday";
                    LblDay.ForeColor = System.Drawing.ColorTranslator.FromOle(255);
                    break;
            }
        }

        private void DateChanged()
        {
            if (FirstLoad)
            {
                return;
            }
            if (Mdl1.k_Date(CmbDD.Text + CmbMM.Text + CmbYear.Text))
            {
                ChangeLblDay();
            }
            else
            {
                MessageBox.Show("Invalid Date !", "Error Message");
            }
        }

        private void CmbDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmbMM_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateChanged();
        }

        private void CmdCal_Click(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(new System.DateTime(int.Parse(CmbYear.Text), int.Parse(CmbMM.Text), int.Parse(CmbDD.Text), 0, 0, 0, 0));
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            FirstLoad = true;
            CmbDD.Text = e.Start.Day.ToString("00");
            CmbMM.Text = e.Start.Month.ToString("00");
            CmbYear.Text = e.Start.Year.ToString("0000");
            FirstLoad = false;
            monthCalendar1.Hide();
            DateChanged();
        }

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

        private void Clear_Grid()
        {
            gvPortfolio.Columns.Clear();
            gvPortfolio.ColumnCount = 5;
            gvPortfolio.Columns[0].Name = "Portfolio Code";
            gvPortfolio.Columns[0].FillWeight = 18;
            gvPortfolio.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPortfolio.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPortfolio.Columns[1].Name = "Portfolio";
            gvPortfolio.Columns[1].FillWeight = 32;
            gvPortfolio.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPortfolio.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPortfolio.Columns[2].Name = "Currency";
            gvPortfolio.Columns[2].FillWeight = 14;
            gvPortfolio.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPortfolio.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvPortfolio.Columns[3].Name = "Cash";
            gvPortfolio.Columns[3].FillWeight = 18;
            gvPortfolio.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPortfolio.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPortfolio.Columns[4].Name = "Investment Amount";
            gvPortfolio.Columns[4].FillWeight = 18;
            gvPortfolio.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvPortfolio.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        //The description is looked up per row rather than joined, matching the rest of the
        //app and keeping the reserved word Currency out of a join clause.
        private string Description_For(string parCode)
        {
            string Result = "";
            Mdl1.Ssql = "select Description from TblETFStocksPortfolioCode where Portfolio_Code = '" + parCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Result = Read_Text(reader["Description"]);
            }
            reader.Close();
            return Result;
        }

        private void Get_Data()
        {
            Filling = true;

            gvPortfolio.Rows.Clear();

            Mdl1.Ssql = "select Portfolio_Code, [Currency], [Cash], Investment_Amount from TblETFStocksPortfolio order by Portfolio_Code";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpCode = Read_Text(reader["Portfolio_Code"]);
                string TmpCurrency = Read_Text(reader["Currency"]);
                double TmpCash = Read_Double(reader["Cash"]);
                double TmpInvAmt = Read_Double(reader["Investment_Amount"]);
                string TmpDesc = Description_For(TmpCode);

                gvPortfolio.Rows.Add(new string[] {
                    TmpCode,
                    (TmpDesc == "" ? "-" : TmpDesc),
                    (TmpCurrency == "" ? "-" : TmpCurrency),
                    Money(TmpCash, TmpCurrency),
                    Money(TmpInvAmt, TmpCurrency) });
                gvPortfolio.Rows[gvPortfolio.Rows.Count - 1].Tag = TmpCode;
            }
            reader.Close();

            gvPortfolio.ClearSelection();

            Filling = false;
        }

        private bool Portfolio_Exists(string parCode, out string parCurrency, out double parCash, out double parInvAmt)
        {
            parCurrency = "";
            parCash = 0;
            parInvAmt = 0;
            bool Found = false;

            Mdl1.Ssql = "select [Currency], [Cash], Investment_Amount from TblETFStocksPortfolio where Portfolio_Code = '" + parCode + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                parCurrency = Read_Text(reader["Currency"]);
                parCash = Read_Double(reader["Cash"]);
                parInvAmt = Read_Double(reader["Investment_Amount"]);
                Found = true;
            }
            reader.Close();
            return Found;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        //Mdl1.NumericKeyPress rejects a minus sign, which is right for Amount - the sign is
        //carried by Investment Type.  Cash and Investment Amount are running balances that
        //can genuinely be negative, so those two also accept a leading minus.
        private void Signed_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox Box = sender as TextBox;

            if (e.KeyChar == '-')
            {
                if (Box != null && Box.SelectionStart == 0 && !Box.Text.Contains("-"))
                {
                    return;
                }
                e.Handled = true;
                return;
            }

            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        //Numeric, at most 2 decimal places.  parAllowNegative covers the running balances.
        private bool Valid_Amount(string parText, string parLabel, bool parAllowNegative, out double parValue)
        {
            parValue = 0;

            string TmpText = parText.Trim();
            if (TmpText == "")
            {
                MessageBox.Show(parLabel + " cannot be empty !", "Error Message");
                return false;
            }
            if (!double.TryParse(TmpText, NumberStyles.Number, CultureInfo.CurrentCulture, out parValue))
            {
                MessageBox.Show(parLabel + " must be a number !", "Error Message");
                return false;
            }
            if (!parAllowNegative && parValue <= 0)
            {
                MessageBox.Show(parLabel + " must be greater than zero !", "Error Message");
                return false;
            }

            string TmpPlain = TmpText.Replace(",", "");
            int TmpDot = TmpPlain.IndexOf('.');
            if (TmpDot >= 0 && (TmpPlain.Length - TmpDot - 1) > 2)
            {
                MessageBox.Show(parLabel + " can have a maximum of 2 decimal points !", "Error Message");
                return false;
            }
            return true;
        }

        private string Db_Number(double parValue)
        {
            return Math.Round(parValue, 2).ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                double TmpAmount;

                string TmpCode = CmbPortfolioCode.Text.Trim();
                string TmpType = CmbInvType.Text.Trim();
                string TmpCurrency = CmbCurrency.Text.Trim();

                if (TmpCode == "")
                {
                    MessageBox.Show("Portfolio Code must be selected ! Please set one up first in ETF/Stock Portfolio Code Setup.", "Error Message");
                    return;
                }
                if (TmpType != "+" && TmpType != "-")
                {
                    MessageBox.Show("Investment Type must be selected !", "Error Message");
                    return;
                }
                if (TmpCurrency == "")
                {
                    MessageBox.Show("Currency must be selected !", "Error Message");
                    return;
                }
                if (!Valid_Amount(txtAmount.Text, "Amount", false, out TmpAmount))
                {
                    return;
                }

                string TmpExistCurrency;
                double TmpCash;
                double TmpInvAmt;
                bool Exists = Portfolio_Exists(TmpCode, out TmpExistCurrency, out TmpCash, out TmpInvAmt);

                //Adding a USD movement to an AUD balance would quietly corrupt the running
                //total, so a currency that disagrees with the portfolio is refused outright.
                if (Exists && TmpExistCurrency != "" && TmpExistCurrency != TmpCurrency)
                {
                    MessageBox.Show("Portfolio " + TmpCode + " is held in " + TmpExistCurrency
                        + " but this entry is in " + TmpCurrency + "."
                        + Environment.NewLine + Environment.NewLine
                        + "Amounts in different currencies cannot be added together. Change the currency, or edit the portfolio first.",
                        "Error Message");
                    return;
                }

                string TmpDate = Get_Investment_Date();

                //the movement itself is always kept, whether or not the portfolio existed
                Mdl1.Ssql = "Insert into TblETFStocksPortfolioInvestment (Investment_Date, Portfolio_Code, Investment_Type, [Currency], [Amount]) values ("
                          + "'" + TmpDate + "', '" + TmpCode + "', '" + TmpType + "', '" + TmpCurrency + "', " + Db_Number(TmpAmount) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                double TmpSigned = (TmpType == "+" ? TmpAmount : -TmpAmount);

                if (Exists)
                {
                    Mdl1.Ssql = "Update TblETFStocksPortfolio set [Cash] = " + Db_Number(TmpCash + TmpSigned)
                              + " where Portfolio_Code = '" + TmpCode + "'";
                }
                else
                {
                    //a brand new portfolio starts from nothing, so its cash is just this movement
                    Mdl1.Ssql = "Insert into TblETFStocksPortfolio (Portfolio_Code, [Currency], [Cash], Investment_Amount) values ("
                              + "'" + TmpCode + "', '" + TmpCurrency + "', " + Db_Number(TmpSigned) + ", 0.00)";
                }
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Investment " + TmpType + Money(TmpAmount, TmpCurrency) + " recorded for " + TmpCode
                    + " on " + Mdl1.toLongDate(TmpDate) + "."
                    + Environment.NewLine + "Cash is now " + Money((Exists ? TmpCash : 0) + TmpSigned, TmpCurrency) + ".",
                    "Success");

                txtAmount.Text = "0.00";
                Get_Data();
                End_Edit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //The edit inputs only appear once a portfolio is picked out of the grid
        private void Begin_Edit(string parCode, string parCurrency, string parCash, string parInvAmt)
        {
            EditCode = parCode;
            LblEditCaption.Text = "Edit portfolio : " + parCode;

            Select_Currency(CmbEditCurrency, parCurrency);
            txtEditCash.Text = Strip_Money(parCash);
            txtEditInvAmt.Text = Strip_Money(parInvAmt);

            Show_Edit(true);
        }

        private void End_Edit()
        {
            EditCode = "";
            LblEditCaption.Text = "Edit portfolio";
            Show_Edit(false);
        }

        private void Show_Edit(bool parShow)
        {
            LblEditCaption.Visible = parShow;
            Label7.Visible = parShow;
            CmbEditCurrency.Visible = parShow;
            Label8.Visible = parShow;
            txtEditCash.Visible = parShow;
            Label9.Visible = parShow;
            txtEditInvAmt.Visible = parShow;
            CmdUpdate.Visible = parShow;
            CmdCancelEdit.Visible = parShow;
        }

        //Grid cells carry the display form, so the dollar sign and separators come back off
        private string Strip_Money(string parText)
        {
            if (parText == null)
            {
                return "0.00";
            }
            string s = parText.Replace("$", "").Replace(",", "").Trim();
            if (s == "" || s == "-")
            {
                return "0.00";
            }
            return s;
        }

        //SelectionChanged fires while CurrentRow can still be pointing at the row being left,
        //so the selection itself is asked which row it is - reading CurrentRow here loads the
        //previous portfolio into the edit boxes.
        private void gvPortfolio_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }

            DataGridViewRow Row = null;
            if (gvPortfolio.SelectedRows.Count > 0)
            {
                Row = gvPortfolio.SelectedRows[0];
            }
            else
            {
                Row = gvPortfolio.CurrentRow;
            }

            if (Row == null || Row.Tag == null)
            {
                return;
            }

            Begin_Edit(Row.Tag.ToString(),
                       Row.Cells[2].Value.ToString().Replace("-", ""),
                       Row.Cells[3].Value.ToString(),
                       Row.Cells[4].Value.ToString());
        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                double TmpCash;
                double TmpInvAmt;

                if (EditCode == null || EditCode == "")
                {
                    MessageBox.Show("Please select a portfolio in the table first !", "Error Message");
                    return;
                }

                string TmpCurrency = CmbEditCurrency.Text.Trim();
                if (TmpCurrency == "")
                {
                    MessageBox.Show("Currency must be selected !", "Error Message");
                    return;
                }
                if (!Valid_Amount(txtEditCash.Text, "Cash", true, out TmpCash))
                {
                    return;
                }
                if (!Valid_Amount(txtEditInvAmt.Text, "Investment Amount", true, out TmpInvAmt))
                {
                    return;
                }

                Mdl1.Ssql = "Update TblETFStocksPortfolio set [Currency] = '" + TmpCurrency + "'"
                          + ", [Cash] = " + Db_Number(TmpCash)
                          + ", Investment_Amount = " + Db_Number(TmpInvAmt)
                          + " where Portfolio_Code = '" + EditCode + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                int Affected = cmd.ExecuteNonQuery();

                if (Affected == 0)
                {
                    MessageBox.Show("Data not found for Portfolio Code : " + EditCode, "Error Message");
                    return;
                }

                MessageBox.Show("Update successfully for Portfolio Code : " + EditCode, "Success");

                Get_Data();
                End_Edit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdCancelEdit_Click(object sender, EventArgs e)
        {
            Filling = true;
            gvPortfolio.ClearSelection();
            Filling = false;
            End_Edit();
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
