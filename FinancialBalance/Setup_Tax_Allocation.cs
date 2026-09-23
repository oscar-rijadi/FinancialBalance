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
    public partial class Setup_Tax_Allocation : Form
    {
        //true while Get_Data is refilling the grid, so the rows it adds do not fire the selection
        //handler and type themselves back into the boxes
        bool Filling;

        //The code of the row picked out of the grid, so Update knows which row it is changing -
        //without it a changed code would be indistinguishable from a new one. Null until a row is
        //picked, which is what makes Update refuse before Add has anything to work on.
        string OrgCode;

        //The state codes are the official Australian abbreviations, so three characters is the
        //widest of them rather than a fixed width: NT, SA and WA are two.
        public Setup_Tax_Allocation()
        {
            InitializeComponent();
        }

        private void Setup_Tax_Allocation_Load(object sender, EventArgs e)
        {
            Get_Data();
        }

        private void MnAcctTypeRefSetup_Click(object sender, EventArgs e)
        {
            Setup_Acct_Type_Ref Setup_Acct_Type_Ref = new Setup_Acct_Type_Ref();
            Setup_Acct_Type_Ref.Show();
            this.Close();
        }

        private void MnAcctRefSetup_Click(object sender, EventArgs e)
        {
            Setup_Acct_Ref Setup_Acct_Ref = new Setup_Acct_Ref();
            Setup_Acct_Ref.Show();
            this.Close();
        }

        private void MnCurrSetup_Click(object sender, EventArgs e)
        {
            Setup_Curr Setup_Curr = new Setup_Curr();
            Setup_Curr.Show();
            this.Close();
        }

        private void MnCurrRateSetup_Click(object sender, EventArgs e)
        {
            Setup_Curr_Rate Setup_Curr_Rate = new Setup_Curr_Rate();
            Setup_Curr_Rate.Show();
            this.Close();
        }

        private void MnActivaPassivaSetup_Click(object sender, EventArgs e)
        {
            Setup_Activa_Passiva Setup_Activa_Passiva = new Setup_Activa_Passiva();
            Setup_Activa_Passiva.Show();
            this.Close();
        }

        private void MnIntervalSetup_Click(object sender, EventArgs e)
        {
            Setup_Interval Setup_Interval = new Setup_Interval();
            Setup_Interval.Show();
            this.Close();
        }

        private void MnFinancialYearSetup_Click(object sender, EventArgs e)
        {
            Setup_Financial_Year Setup_Financial_Year = new Setup_Financial_Year();
            Setup_Financial_Year.Show();
            this.Close();
        }

        private void MnETFStocksSuffixSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Suffix Setup_ETF_Stocks_Suffix = new Setup_ETF_Stocks_Suffix();
            Setup_ETF_Stocks_Suffix.Show();
            this.Close();
        }

        private void MnETFStocksSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks Setup_ETF_Stocks = new Setup_ETF_Stocks();
            Setup_ETF_Stocks.Show();
            this.Close();
        }

        private void MnETFStocksFlagSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Flag Setup_ETF_Stocks_Flag = new Setup_ETF_Stocks_Flag();
            Setup_ETF_Stocks_Flag.Show();
            this.Close();
        }

        private void MnETFStocksDivTypeSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Div_Type Setup_ETF_Stocks_Div_Type = new Setup_ETF_Stocks_Div_Type();
            Setup_ETF_Stocks_Div_Type.Show();
            this.Close();
        }

        private void MnETFStocksDivSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Div Setup_ETF_Stocks_Div = new Setup_ETF_Stocks_Div();
            Setup_ETF_Stocks_Div.Show();
            this.Close();
        }

        private void MnETFStocksDivAllocSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Div_Alloc Setup_ETF_Stocks_Div_Alloc = new Setup_ETF_Stocks_Div_Alloc();
            Setup_ETF_Stocks_Div_Alloc.Show();
            this.Close();
        }

        private void MnETFStocksInvPlanSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Investment_Plan Setup_ETF_Stocks_Investment_Plan = new Setup_ETF_Stocks_Investment_Plan();
            Setup_ETF_Stocks_Investment_Plan.Show();
            this.Close();
        }

        private void MnStateSetup_Click(object sender, EventArgs e)
        {
            Setup_State Setup_State = new Setup_State();
            Setup_State.Show();
            this.Close();
        }

        private void MnPropertyRentalExpTypeSetup_Click(object sender, EventArgs e)
        {
            Setup_Property_Rental_Expense_Type Setup_Property_Rental_Expense_Type = new Setup_Property_Rental_Expense_Type();
            Setup_Property_Rental_Expense_Type.Show();
            this.Close();
        }

        private void MnSuperFundSetup_Click(object sender, EventArgs e)
        {
            Setup_Super_Fund Setup_Super_Fund = new Setup_Super_Fund();
            Setup_Super_Fund.Show();
            this.Close();
        }

        private void MnSuperSetup_Click(object sender, EventArgs e)
        {
            Setup_Super Setup_Super = new Setup_Super();
            Setup_Super.Show();
            this.Close();
        }

        //---- reading and showing the two figures ----------------------------------

        //Digits and a decimal point only, as everywhere else a figure is typed. Neither a rate
        //nor a share of one can be negative, so no minus sign is let through.
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

        private double Read_Box(TextBox parBox)
        {
            string TmpText = parBox.Text.Trim().Replace(",", "").Replace("%", "");
            double TmpValue;
            if (!double.TryParse(TmpText, NumberStyles.Any, CultureInfo.InvariantCulture, out TmpValue))
            {
                return 0;
            }
            return Math.Round(TmpValue, 2);
        }

        private double Read_Double(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return 0;
            }
            double TmpValue;
            if (double.TryParse(parValue.ToString(), NumberStyles.Any,
                                CultureInfo.InvariantCulture, out TmpValue))
            {
                return TmpValue;
            }
            return 0;
        }

        private string Percent(double parValue)
        {
            return parValue.ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
        }

        //Both figures go into the statement as bare numbers rather than quoted text, so they are
        //written from the parsed value with an invariant format - a machine set to a comma
        //decimal separator would otherwise send "32,50" and Access would read two arguments.
        private string Num(double parValue)
        {
            return parValue.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void Clear_Grid()
        {
            gvTaxAlloc.Columns.Clear();
            gvTaxAlloc.ColumnCount = 2;
            gvTaxAlloc.Columns[0].Name = "Tax Rate";
            gvTaxAlloc.Columns[0].FillWeight = 50;
            gvTaxAlloc.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvTaxAlloc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvTaxAlloc.Columns[1].Name = "Allocation";
            gvTaxAlloc.Columns[1].FillWeight = 50;
            gvTaxAlloc.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvTaxAlloc.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();
                OrgCode = null;

                double TmpTotal = 0;
                string[] row;

                Mdl1.Ssql = "select [Tax_Rate], [Allocation] from TblTaxAllocation order by [Tax_Rate]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    double TmpRate = Read_Double(reader["Tax_Rate"]);
                    double TmpAlloc = Read_Double(reader["Allocation"]);
                    TmpTotal += TmpAlloc;
                    row = new string[] { Percent(TmpRate), Percent(TmpAlloc) };
                    gvTaxAlloc.Rows.Add(row);
                }
                reader.Close();

                gvTaxAlloc.ClearSelection();
                Filling = false;

                Show_Total(Math.Round(TmpTotal, 2));
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //The rows divide up one lot of interest, so what they come to is worth saying - and
        //saying loudly when it is short, because a part-allocated table is not an error but it is
        //not finished either.
        private void Show_Total(double parTotal)
        {
            LblTotal.Text = Percent(parTotal);
            if (parTotal < 100)
            {
                LblTotal.Text = LblTotal.Text + "   -   " + Percent(Math.Round(100 - parTotal, 2))
                              + " still to allocate";
                LblTotal.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LblTotal.ForeColor = System.Drawing.Color.Green;
            }
        }

        //Clicking a row copies it into the boxes, so an existing rate can be changed or removed
        //without it having to be typed back in by hand.
        private void gvTaxAlloc_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvTaxAlloc.SelectedRows.Count > 0)
            {
                Row = gvTaxAlloc.SelectedRows[0];
            }
            else
            {
                Row = gvTaxAlloc.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }
            //the cells carry a per-cent sign for reading; the boxes hold bare figures, since that
            //is what may be typed back into them
            double TmpRate = Read_Double(Row.Cells[0].Value.ToString().Replace("%", "").Replace(",", "").Trim());
            double TmpAlloc = (Row.Cells[1].Value == null ? 0
                : Read_Double(Row.Cells[1].Value.ToString().Replace("%", "").Replace(",", "").Trim()));
            OrgCode = Num(TmpRate);
            Tax_Rate.Text = Num(TmpRate);
            Allocation.Text = Num(TmpAlloc);
        }

        //---- add, update, delete --------------------------------------------------
        //
        //Add and Update are separate, as on State Setup: one insists the rate is new, the other
        //insists a row has been picked out of the grid. The rate identifies the row - the table
        //has no id of its own, and two rows at the same rate would only ever be one row at the
        //sum of their allocations.

        private bool Exists(double parRate)
        {
            Mdl1.Ssql = "select [Tax_Rate] from TblTaxAllocation where [Tax_Rate] = " + Num(parRate);
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        //Everything allocated apart from one rate, which is what lets a row be changed to a
        //larger share without its own old share counting against it.
        private double Allocated_Except(string parRate)
        {
            double TmpTotal = 0;
            Mdl1.Ssql = "select [Tax_Rate], [Allocation] from TblTaxAllocation";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (parRate != null && Num(Read_Double(reader["Tax_Rate"])) == parRate)
                {
                    continue;
                }
                TmpTotal += Read_Double(reader["Allocation"]);
            }
            reader.Close();
            return Math.Round(TmpTotal, 2);
        }

        //Both figures are percentages, so both have to sit between 0 and 100 - and the
        //allocations together cannot come to more than the whole they divide up.
        private bool Checked_Out(double parRate, double parAlloc, string parExcept)
        {
            if (Tax_Rate.Text.Trim() == "" || parRate < 0 || parRate > 100)
            {
                MessageBox.Show("Tax Rate must be between 0 and 100.", "Error Message");
                return false;
            }
            if (parAlloc <= 0 || parAlloc > 100)
            {
                MessageBox.Show("Allocation must be more than 0 and at most 100 %.", "Error Message");
                return false;
            }

            double TmpRest = Allocated_Except(parExcept);
            if (Math.Round(TmpRest + parAlloc, 2) > 100)
            {
                MessageBox.Show("That would allocate "
                    + Percent(Math.Round(TmpRest + parAlloc, 2)) + " in total."
                    + Environment.NewLine
                    + "The allocations cannot come to more than 100 % - there is "
                    + Percent(Math.Round(100 - TmpRest, 2)) + " left to allocate.",
                    "Error Message");
                return false;
            }
            return true;
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                double TmpRate = Read_Box(Tax_Rate);
                double TmpAlloc = Read_Box(Allocation);
                if (!Checked_Out(TmpRate, TmpAlloc, null))
                {
                    return;
                }
                if (Exists(TmpRate))
                {
                    MessageBox.Show("Tax Rate already exists : " + Percent(TmpRate), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblTaxAllocation ([Tax_Rate], [Allocation]) values ("
                          + Num(TmpRate) + ", " + Num(TmpAlloc) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Tax Rate : " + Percent(TmpRate), "Success");
                Get_Data();
                Tax_Rate.Text = "";
                Allocation.Text = "";
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
                if (OrgCode == null)
                {
                    MessageBox.Show("Please select a tax rate from the list first !", "Error Message");
                    return;
                }
                double TmpRate = Read_Box(Tax_Rate);
                double TmpAlloc = Read_Box(Allocation);
                if (!Checked_Out(TmpRate, TmpAlloc, OrgCode))
                {
                    return;
                }

                //The row is found by the rate it was picked under, so a changed rate is that row
                //moving rather than a new one - which is the difference between this button and
                //Add. A rate already in use would collide.
                if (Num(TmpRate) != OrgCode && Exists(TmpRate))
                {
                    MessageBox.Show("Tax Rate already exists : " + Percent(TmpRate), "Error Message");
                    return;
                }
                if (Num(TmpRate) == OrgCode && Num(TmpAlloc) == Num(Org_Allocation()))
                {
                    MessageBox.Show("Nothing has been changed.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblTaxAllocation set [Tax_Rate] = " + Num(TmpRate) + ","
                          + " [Allocation] = " + Num(TmpAlloc)
                          + " where [Tax_Rate] = " + OrgCode;
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for Tax Rate : " + Percent(TmpRate), "Success");
                Get_Data();
                Tax_Rate.Text = "";
                Allocation.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //What the picked row's allocation was, read back so an update that changes nothing can be
        //told apart from one that changes only the allocation.
        private double Org_Allocation()
        {
            double TmpAlloc = 0;
            Mdl1.Ssql = "select [Allocation] from TblTaxAllocation where [Tax_Rate] = " + OrgCode;
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                TmpAlloc = Read_Double(reader["Allocation"]);
            }
            reader.Close();
            return TmpAlloc;
        }

        private void CmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tax_Rate.Text.Trim() == "")
                {
                    MessageBox.Show("Please select a tax rate from the list first !", "Error Message");
                    return;
                }
                double TmpRate = Read_Box(Tax_Rate);
                if (!Exists(TmpRate))
                {
                    MessageBox.Show("Data not found for Tax Rate : " + Percent(TmpRate), "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblTaxAllocation where [Tax_Rate] = " + Num(TmpRate);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Tax Rate : " + Percent(TmpRate), "Success");
                Get_Data();
                Tax_Rate.Text = "";
                Allocation.Text = "";
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
