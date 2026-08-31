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
    public partial class ETF_Stocks_Transaction : Form
    {
        bool FirstLoad;
        bool Filling;

        //TblETFStocksTrans has no primary key, so a row is identified by the values it
        //held when it was picked out of the grid.  A null entry means the column was Null.
        bool RowSelected;
        string OrgTransDate;
        string OrgTransType;
        string OrgFullTicker;
        string OrgCurrency;
        string OrgUnit;
        string OrgCostBase;
        string OrgFee;
        string OrgTotalCostBase;
        string OrgRealTotalCostBase;
        string OrgIsSold;
        string OrgSellingPricePerUnit;
        string OrgSellingTotalAmount;

        public ETF_Stocks_Transaction()
        {
            InitializeComponent();
        }

        private void ETF_Stocks_Transaction_Load(object sender, EventArgs e)
        {
            FirstLoad = true;
            Mdl1.Fill_Date(CmbDD, CmbMM, CmbYear);
            CmbDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbYear.Text = String.Format("{0:yyyy}", DateTime.Now);

            Filling = true;
            CmbTransType.Items.Clear();
            CmbTransType.Items.Add("Buy");
            CmbTransType.Items.Add("Sell");
            CmbTransType.Text = "Buy";
            Fill_Full_Ticker();
            Mdl1.Fill_Curr(CmbCurrency);
            Set_Default_Currency();
            Filling = false;

            ChangeLblDay();
            Clear_Entry();
            Get_Data();
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

        //A Buy captures cost; a Sell captures proceeds.  Only one set applies at a time.
        private bool Is_Sell()
        {
            return (CmbTransType.Text.Trim() == "Sell");
        }

        private void Show_Fields_For_Type()
        {
            bool Sell = Is_Sell();

            //Buy-only inputs
            Label5.Visible = !Sell;
            txtCostBase.Visible = !Sell;
            Label6.Visible = !Sell;
            txtFee.Visible = !Sell;
            Label7.Visible = !Sell;
            txtTotalCostBase.Visible = !Sell;
            Label8.Visible = !Sell;
            txtRealTotalCostBase.Visible = !Sell;
            chkDRIP.Visible = !Sell;
            chkSold.Visible = !Sell;

            //Sell-only inputs
            Label9.Visible = Sell;
            txtSellingPricePerUnit.Visible = Sell;
            Label10.Visible = Sell;
            txtSellingTotalAmount.Visible = Sell;
        }

        private void Apply_Trans_Type_Rules()
        {
            Show_Fields_For_Type();

            //whatever is hidden is not captured, so reset it rather than carry it over
            if (Is_Sell())
            {
                chkDRIP.Checked = false;
                chkSold.Checked = false;
                txtCostBase.Text = "0.00";
                txtFee.Text = "0.00";
            }
            else
            {
                txtSellingPricePerUnit.Text = "0.00";
            }
        }

        private void CmbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Apply_Trans_Type_Rules();
            //the reset above changes what the derived boxes should read
            Calculate_Totals();
        }

        //Fill_Curr defaults to IDR for the accounting pages; ETF trades default to AUD
        private void Set_Default_Currency()
        {
            if (CmbCurrency.Items.Contains("AUD"))
            {
                CmbCurrency.Text = "AUD";
            }
        }

        //Date in the same yyyyMMdd form every other table uses
        private string Get_Trans_Date()
        {
            return CmbYear.Text + CmbMM.Text + CmbDD.Text;
        }

        private void Fill_Full_Ticker()
        {
            CmbFullTicker.Items.Clear();
            Mdl1.Ssql = "Select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CmbFullTicker.Items.Add(reader["Full_Ticker"].ToString().Trim());
                }
            }
            reader.Close();
            if (CmbFullTicker.Items.Count > 0)
            {
                CmbFullTicker.Text = CmbFullTicker.Items[0].ToString();
            }
        }

        private void ChangeLblDay()
        {
            switch (DateTime.Parse(Mdl1.toLongDate(Get_Trans_Date())).DayOfWeek)
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
                Clear_Entry();
                Get_Data();
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

        private void Clear_Grid()
        {
            gvTrans.Columns.Clear();
            gvTrans.ColumnCount = 12;
            string[] names = new string[] { "Type", "Full Ticker", "Currency", "Unit", "Cost Base", "Fee", "Total Cost Base", "Real Total Cost Base", "DRIP", "Sold", "Selling Price/Unit", "Selling Total Amount" };
            int[] weights = new int[] { 6, 10, 7, 9, 9, 6, 10, 11, 5, 5, 10, 12 };
            for (int i = 0; i < 12; i++)
            {
                gvTrans.Columns[i].Name = names[i];
                gvTrans.Columns[i].FillWeight = weights[i];
                if ((i >= 3 && i <= 7) || i >= 10)
                {
                    gvTrans.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gvTrans.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else
                {
                    gvTrans.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gvTrans.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private string Select_Cols()
        {
            return "select Trans_Date, Trans_Type, Full_Ticker, [Currency], Unit, Cost_Base, Fee, Total_Cost_Base, Real_Total_Cost_Base, Is_Sold, [Selling_Price_Per_Unit], [Selling_Total_Amount] from TblETFStocksTrans"
                 + " where Trans_Date = '" + Get_Trans_Date() + "' order by Full_Ticker, Trans_Type";
        }

        private void Get_Data()
        {
            Filling = true;
            RowSelected = false;

            Clear_Grid();

            string[] row;

            Mdl1.Ssql = Select_Cols();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bool Sell = (reader["Trans_Type"].ToString().Trim() == "-");
                    double TmpRealTotal = Read_Double(reader["Real_Total_Cost_Base"]);

                    //columns that do not apply to this transaction type read as "-"
                    row = new string[] {
                        From_Db_Trans_Type(reader["Trans_Type"].ToString().Trim()),
                        reader["Full_Ticker"].ToString().Trim(),
                        reader["Currency"].ToString().Trim(),
                        Format_Unit(reader["Unit"]),
                        (Sell ? "-" : Mdl1.FormatAmt(Read_Double(reader["Cost_Base"]))),
                        (Sell ? "-" : Mdl1.FormatAmt(Read_Double(reader["Fee"]))),
                        (Sell ? "-" : Mdl1.FormatAmt(Read_Double(reader["Total_Cost_Base"]))),
                        (Sell ? "-" : Mdl1.FormatAmt(TmpRealTotal)),
                        (Sell ? "-" : (TmpRealTotal == 0 ? "Y" : "N")),
                        (Sell ? "-" : (reader["Is_Sold"].ToString().Trim() == "True" ? "Y" : "N")),
                        (Sell ? Mdl1.FormatAmt(Read_Double(reader["Selling_Price_Per_Unit"])) : "-"),
                        (Sell ? Mdl1.FormatAmt(Read_Double(reader["Selling_Total_Amount"])) : "-")
                    };
                    gvTrans.Rows.Add(row);
                }
            }
            reader.Close();

            gvTrans.ClearSelection();

            Filling = false;
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

        private string Format_Unit(object parValue)
        {
            return Read_Double(parValue).ToString("#,##0.0000");
        }

        //Buy is stored as "+", Sell as "-"
        private string To_Db_Trans_Type(string parDisplay)
        {
            if (parDisplay.Trim() == "Sell")
            {
                return "-";
            }
            return "+";
        }

        private string From_Db_Trans_Type(string parStored)
        {
            if (parStored.Trim() == "-")
            {
                return "Sell";
            }
            return "Buy";
        }

        private void Clear_Entry()
        {
            Filling = true;
            RowSelected = false;
            CmbTransType.Text = "Buy";
            Set_Default_Currency();
            if (CmbFullTicker.Items.Count > 0)
            {
                CmbFullTicker.Text = CmbFullTicker.Items[0].ToString();
            }
            txtUnit.Text = "0.0000";
            txtCostBase.Text = "0.00";
            txtFee.Text = "0.00";
            txtSellingPricePerUnit.Text = "0.00";
            chkDRIP.Checked = false;
            chkSold.Checked = false;
            Filling = false;
            Apply_Trans_Type_Rules();
            Calculate_Totals();
        }

        //Buy  : Total = round(Unit x Cost Base, 2) + Fee, and DRIP zeroes the real total
        //Sell : Selling Total Amount = round(Unit x Selling Price/Unit, 2)
        private void Calculate_Totals()
        {
            double TmpUnit;
            double TmpCostBase;
            double TmpFee;
            double TmpSellingPrice;

            double.TryParse(txtUnit.Text.Trim(), out TmpUnit);
            double.TryParse(txtCostBase.Text.Trim(), out TmpCostBase);
            double.TryParse(txtFee.Text.Trim(), out TmpFee);
            double.TryParse(txtSellingPricePerUnit.Text.Trim(), out TmpSellingPrice);

            double TmpTotal = Math.Round(Math.Round(TmpUnit * TmpCostBase, 2) + TmpFee, 2);
            txtTotalCostBase.Text = Mdl1.FormatAmt(TmpTotal);
            if (chkDRIP.Checked)
            {
                txtRealTotalCostBase.Text = Mdl1.FormatAmt(0);
            }
            else
            {
                txtRealTotalCostBase.Text = Mdl1.FormatAmt(TmpTotal);
            }

            txtSellingTotalAmount.Text = Mdl1.FormatAmt(Math.Round(TmpUnit * TmpSellingPrice, 2));
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Calculate_Totals();
        }

        private void chkDRIP_CheckedChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Calculate_Totals();
        }

        private void CheckKeyPress(KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtCostBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void txtSellingPricePerUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyPress(e);
        }

        private void gvTrans_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            if (gvTrans.CurrentRow == null || gvTrans.CurrentRow.Cells[0].Value == null)
            {
                return;
            }

            //Re-read the row from the database so the originals are exact, not display-rounded
            int idx = gvTrans.CurrentRow.Index;

            Mdl1.Ssql = Select_Cols();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            int i = 0;
            bool Found = false;
            while (reader.Read())
            {
                if (i == idx)
                {
                    OrgTransDate = reader["Trans_Date"].ToString().Trim();
                    OrgTransType = reader["Trans_Type"].ToString().Trim();
                    OrgFullTicker = reader["Full_Ticker"].ToString().Trim();
                    OrgCurrency = reader["Currency"].ToString().Trim();
                    OrgUnit = Sql_Num(reader["Unit"], 4);
                    OrgCostBase = Sql_Num(reader["Cost_Base"], 2);
                    OrgFee = Sql_Num(reader["Fee"], 2);
                    OrgTotalCostBase = Sql_Num(reader["Total_Cost_Base"], 2);
                    OrgRealTotalCostBase = Sql_Num(reader["Real_Total_Cost_Base"], 2);
                    OrgIsSold = (reader["Is_Sold"].ToString().Trim() == "True" ? "True" : "False");
                    OrgSellingPricePerUnit = Sql_Num(reader["Selling_Price_Per_Unit"], 2);
                    OrgSellingTotalAmount = Sql_Num(reader["Selling_Total_Amount"], 2);
                    Found = true;
                    break;
                }
                i++;
            }
            reader.Close();

            if (!Found)
            {
                return;
            }

            Filling = true;
            CmbTransType.Text = From_Db_Trans_Type(OrgTransType);
            CmbFullTicker.Text = OrgFullTicker;
            CmbCurrency.Text = OrgCurrency;
            txtUnit.Text = (OrgUnit == null ? "0.0000" : OrgUnit);
            txtCostBase.Text = (OrgCostBase == null ? "0.00" : OrgCostBase);
            txtFee.Text = (OrgFee == null ? "0.00" : OrgFee);
            txtSellingPricePerUnit.Text = (OrgSellingPricePerUnit == null ? "0.00" : OrgSellingPricePerUnit);
            chkDRIP.Checked = (Read_Double(OrgRealTotalCostBase) == 0);
            chkSold.Checked = (OrgIsSold == "True");
            Filling = false;

            //show the half of the form this row's type uses, without wiping what was just loaded
            Show_Fields_For_Type();

            RowSelected = true;
            Calculate_Totals();
        }

        //Culture-independent literal for SQL, at the scale the column stores.
        //Returns null when the stored value is Null.
        private string Sql_Num(object parValue, int parDecimals)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return null;
            }
            decimal TmpValue;
            if (!decimal.TryParse(parValue.ToString(), out TmpValue))
            {
                TmpValue = 0;
            }
            return TmpValue.ToString("0." + new string('0', parDecimals), CultureInfo.InvariantCulture);
        }

        //Numeric, not negative, and no more than parDecimals decimal places
        private bool Valid_Amount(string parText, int parDecimals, string parField, out decimal parValue)
        {
            parValue = 0;

            string TmpText = parText.Trim();
            if (TmpText == "")
            {
                MessageBox.Show(parField + " cannot be empty !", "Error Message");
                return false;
            }
            if (!decimal.TryParse(TmpText, NumberStyles.Number, CultureInfo.CurrentCulture, out parValue))
            {
                MessageBox.Show(parField + " must be a number !", "Error Message");
                return false;
            }
            if (parValue < 0)
            {
                MessageBox.Show(parField + " cannot be negative !", "Error Message");
                return false;
            }

            string TmpPlain = TmpText.Replace(",", "");
            int TmpDot = TmpPlain.IndexOf('.');
            if (TmpDot >= 0 && (TmpPlain.Length - TmpDot - 1) > parDecimals)
            {
                MessageBox.Show(parField + " can have a maximum of " + parDecimals.ToString() + " decimal points !", "Error Message");
                return false;
            }
            return true;
        }

        //Only the fields on show for the current type are captured; the rest are stored as zero
        private bool Validate_Entry(out decimal parUnit, out decimal parCostBase, out decimal parFee,
                                    out decimal parTotal, out decimal parRealTotal,
                                    out decimal parSellingPrice, out decimal parSellingTotal)
        {
            parUnit = 0;
            parCostBase = 0;
            parFee = 0;
            parTotal = 0;
            parRealTotal = 0;
            parSellingPrice = 0;
            parSellingTotal = 0;

            if (CmbFullTicker.Text.Trim() == "")
            {
                MessageBox.Show("Full Ticker must be selected ! Please set one up first in ETF/Stock Setup.", "Error Message");
                return false;
            }
            if (CmbCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Currency must be selected !", "Error Message");
                return false;
            }
            if (!Valid_Amount(txtUnit.Text, 4, "Unit", out parUnit))
            {
                return false;
            }

            if (Is_Sell())
            {
                if (!Valid_Amount(txtSellingPricePerUnit.Text, 2, "Selling Price/Unit", out parSellingPrice))
                {
                    return false;
                }
                parSellingTotal = Math.Round(parUnit * parSellingPrice, 2);
            }
            else
            {
                if (!Valid_Amount(txtCostBase.Text, 2, "Cost Base", out parCostBase))
                {
                    return false;
                }
                if (!Valid_Amount(txtFee.Text, 2, "Fee", out parFee))
                {
                    return false;
                }
                parTotal = Math.Round(Math.Round(parUnit * parCostBase, 2) + parFee, 2);
                parRealTotal = (chkDRIP.Checked ? 0 : parTotal);
            }
            return true;
        }

        private string Num(decimal parValue, int parDecimals)
        {
            return parValue.ToString("0." + new string('0', parDecimals), CultureInfo.InvariantCulture);
        }

        private string Where_Col(string parCol, string parValue)
        {
            if (parValue == null)
            {
                return " and " + parCol + " Is Null";
            }
            return " and " + parCol + " = " + parValue;
        }

        //Access stores Yes/No True as -1, so a WHERE must compare against True/False,
        //never 1/0 - "Is_Sold = 1" silently matches nothing
        private string Where_Original()
        {
            return " where Trans_Date = '" + OrgTransDate + "'"
                 + " and Trans_Type = '" + OrgTransType + "'"
                 + " and Full_Ticker = '" + OrgFullTicker + "'"
                 + " and [Currency] = '" + OrgCurrency + "'"
                 + Where_Col("Unit", OrgUnit)
                 + Where_Col("Cost_Base", OrgCostBase)
                 + Where_Col("Fee", OrgFee)
                 + Where_Col("Total_Cost_Base", OrgTotalCostBase)
                 + Where_Col("Real_Total_Cost_Base", OrgRealTotalCostBase)
                 + " and Is_Sold = " + OrgIsSold
                 + Where_Col("[Selling_Price_Per_Unit]", OrgSellingPricePerUnit)
                 + Where_Col("[Selling_Total_Amount]", OrgSellingTotalAmount);
        }

        //Without a key, identical rows are indistinguishable - warn before touching them all
        private bool Confirm_Affected(string parAction)
        {
            int TmpCount = 0;
            Mdl1.Ssql = "select count(*) as N from TblETFStocksTrans" + Where_Original();
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpCount = int.Parse(reader["N"].ToString());
            }
            reader.Close();

            if (TmpCount == 0)
            {
                MessageBox.Show("The selected transaction could no longer be found.", "Error Message");
                return false;
            }
            if (TmpCount > 1)
            {
                DialogResult Response = MessageBox.Show(TmpCount.ToString() + " identical transactions exist for this date. " + parAction + " will affect all " + TmpCount.ToString() + " of them. Continue ?", "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpUnit;
                decimal TmpCostBase;
                decimal TmpFee;
                decimal TmpTotal;
                decimal TmpRealTotal;
                decimal TmpSellingPrice;
                decimal TmpSellingTotal;

                if (!Validate_Entry(out TmpUnit, out TmpCostBase, out TmpFee, out TmpTotal, out TmpRealTotal, out TmpSellingPrice, out TmpSellingTotal))
                {
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksTrans (Trans_Date, Trans_Type, Full_Ticker, [Currency], Unit, Cost_Base, Fee, Total_Cost_Base, Real_Total_Cost_Base, Is_Sold, [Selling_Price_Per_Unit], [Selling_Total_Amount]) values ("
                    + "'" + Get_Trans_Date() + "', "
                    + "'" + To_Db_Trans_Type(CmbTransType.Text) + "', "
                    + "'" + CmbFullTicker.Text.Trim() + "', "
                    + "'" + CmbCurrency.Text.Trim() + "', "
                    + Num(TmpUnit, 4) + ", "
                    + Num(TmpCostBase, 2) + ", "
                    + Num(TmpFee, 2) + ", "
                    + Num(TmpTotal, 2) + ", "
                    + Num(TmpRealTotal, 2) + ", "
                    + (chkSold.Checked ? "True" : "False") + ", "
                    + Num(TmpSellingPrice, 2) + ", "
                    + Num(TmpSellingTotal, 2) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + CmbFullTicker.Text.Trim() + " on " + Mdl1.toLongDate(Get_Trans_Date()), "Success");

                Get_Data();
                Clear_Entry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal TmpUnit;
                decimal TmpCostBase;
                decimal TmpFee;
                decimal TmpTotal;
                decimal TmpRealTotal;
                decimal TmpSellingPrice;
                decimal TmpSellingTotal;

                if (!RowSelected)
                {
                    MessageBox.Show("Please select a transaction from the list first !", "Error Message");
                    return;
                }
                if (!Validate_Entry(out TmpUnit, out TmpCostBase, out TmpFee, out TmpTotal, out TmpRealTotal, out TmpSellingPrice, out TmpSellingTotal))
                {
                    return;
                }
                if (!Confirm_Affected("Update"))
                {
                    return;
                }

                Mdl1.Ssql = "Update TblETFStocksTrans set "
                    + "Trans_Type = '" + To_Db_Trans_Type(CmbTransType.Text) + "', "
                    + "Full_Ticker = '" + CmbFullTicker.Text.Trim() + "', "
                    + "[Currency] = '" + CmbCurrency.Text.Trim() + "', "
                    + "Unit = " + Num(TmpUnit, 4) + ", "
                    + "Cost_Base = " + Num(TmpCostBase, 2) + ", "
                    + "Fee = " + Num(TmpFee, 2) + ", "
                    + "Total_Cost_Base = " + Num(TmpTotal, 2) + ", "
                    + "Real_Total_Cost_Base = " + Num(TmpRealTotal, 2) + ", "
                    + "Is_Sold = " + (chkSold.Checked ? "True" : "False") + ", "
                    + "[Selling_Price_Per_Unit] = " + Num(TmpSellingPrice, 2) + ", "
                    + "[Selling_Total_Amount] = " + Num(TmpSellingTotal, 2)
                    + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + CmbFullTicker.Text.Trim() + " on " + Mdl1.toLongDate(Get_Trans_Date()), "Success");

                Get_Data();
                Clear_Entry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!RowSelected)
                {
                    MessageBox.Show("Please select a transaction from the list first !", "Error Message");
                    return;
                }
                if (!Confirm_Affected("Delete"))
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksTrans" + Where_Original();
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + OrgFullTicker + " on " + Mdl1.toLongDate(Get_Trans_Date()), "Success");

                Get_Data();
                Clear_Entry();
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
