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
    public partial class Setup_ETF_Stocks_Investment_Plan : Form
    {
        bool Filling;

        //Neither table has a key. A plan is identified by its Name, and an allocation by the
        //plan and ticker together, so those are what an update or delete matches on.
        bool PlanSelected;
        string OrgPlanName;

        bool AllocSelected;
        string OrgAllocPlan;
        string OrgAllocTicker;
        string OrgAllocAmount;

        public Setup_ETF_Stocks_Investment_Plan()
        {
            InitializeComponent();
        }

        private void Setup_ETF_Stocks_Investment_Plan_Load(object sender, EventArgs e)
        {
            Filling = true;
            Clear_Plan_Grid();
            Clear_Alloc_Grid();
            Fill_Full_Ticker();
            Filling = false;

            Get_Plans();
            Fill_Plan_Dropdowns();
            Get_Allocations();
        }

        //---- the menu -------------------------------------------------------------

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

        private string Num(double parValue)
        {
            return Math.Round(parValue, 2).ToString("0.00", CultureInfo.InvariantCulture);
        }

        //The allocation is a percentage, so it is shown with the sign after it
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

        private double Box(TextBox parBox)
        {
            double TmpValue;
            double.TryParse(parBox.Text.Trim(), out TmpValue);
            return TmpValue;
        }

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

        private bool Valid_Amount(TextBox parBox, string parField, out double parValue)
        {
            parValue = 0;
            string TmpText = parBox.Text.Trim();
            if (TmpText == "")
            {
                MessageBox.Show(parField + " must be filled !", "Error Message");
                return false;
            }
            if (!double.TryParse(TmpText, out parValue))
            {
                MessageBox.Show(parField + " must be a number !", "Error Message");
                return false;
            }
            string TmpPlain = TmpText.Replace(",", "");
            int TmpDot = TmpPlain.IndexOf('.');
            if (TmpDot >= 0 && TmpPlain.Length - TmpDot - 1 > 2)
            {
                MessageBox.Show(parField + " cannot have more than 2 decimal places !", "Error Message");
                return false;
            }
            return true;
        }

        //---- the plans -------------------------------------------------------------

        private void Clear_Plan_Grid()
        {
            gvPlan.Rows.Clear();
            gvPlan.Columns.Clear();
            gvPlan.ColumnCount = 1;
            gvPlan.Columns[0].Name = "Name";
            gvPlan.Columns[0].FillWeight = 100;
            gvPlan.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvPlan.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Get_Plans()
        {
            try
            {
                Filling = true;
                Clear_Plan_Grid();
                PlanSelected = false;

                Mdl1.Ssql = "select [Name] from TblETFStocksInvestmentPlan order by [Name]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gvPlan.Rows.Add(new string[] { Read_Text(reader["Name"]) });
                }
                reader.Close();

                gvPlan.ClearSelection();
                Filling = false;
                LblNote.Text = gvPlan.Rows.Count.ToString() + " investment plan(s)";
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void gvPlan_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            //SelectionChanged fires while CurrentRow can still be pointing at the row being left
            DataGridViewRow Row = null;
            if (gvPlan.SelectedRows.Count > 0)
            {
                Row = gvPlan.SelectedRows[0];
            }
            else
            {
                Row = gvPlan.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            OrgPlanName = Row.Cells[0].Value.ToString().Trim();
            txtName.Text = OrgPlanName;
            PlanSelected = true;
        }

        private bool Plan_Exists(string parName)
        {
            bool Found = false;
            Mdl1.Ssql = "select [Name] from TblETFStocksInvestmentPlan where [Name] = '" + Quote(parName) + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        private int Allocation_Count(string parPlan)
        {
            int Result = 0;
            Mdl1.Ssql = "select Count(*) as N from TblETFStocksInvestmentPlanAllocation"
                      + " where [Investment_Plan_Name] = '" + Quote(parPlan) + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Result = Convert.ToInt32(Read_Double(reader["N"]));
            }
            reader.Close();
            return Result;
        }

        private bool Valid_Plan_Name(out string parName)
        {
            parName = txtName.Text.Trim();
            if (parName == "")
            {
                MessageBox.Show("Name must be filled !", "Error Message");
                return false;
            }
            return true;
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpName;
                if (!Valid_Plan_Name(out TmpName))
                {
                    return;
                }
                if (Plan_Exists(TmpName))
                {
                    MessageBox.Show("Investment plan " + TmpName + " already exists !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksInvestmentPlan ([Name]) values ('" + Quote(TmpName) + "')";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + TmpName, "Success");
                Refresh_All(TmpName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //A plan's name is what its allocations point at - there are no foreign keys anywhere in
        //this database - so renaming one has to carry them with it, or they would be left naming
        //a plan that no longer exists.
        private void CmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PlanSelected)
                {
                    MessageBox.Show("Please select an investment plan from the list first !", "Error Message");
                    return;
                }
                string TmpName;
                if (!Valid_Plan_Name(out TmpName))
                {
                    return;
                }
                if (TmpName == OrgPlanName)
                {
                    MessageBox.Show("Nothing has changed for " + TmpName, "Error Message");
                    return;
                }
                if (Plan_Exists(TmpName))
                {
                    MessageBox.Show("Investment plan " + TmpName + " already exists !", "Error Message");
                    return;
                }

                int TmpUsed = Allocation_Count(OrgPlanName);
                if (TmpUsed > 0)
                {
                    DialogResult Response = MessageBox.Show(
                        "Investment plan " + OrgPlanName + " has " + TmpUsed.ToString()
                        + " allocation(s). Renaming it to " + TmpName + " will move them as well. Continue ?",
                        "Confirmation", MessageBoxButtons.OKCancel);
                    if (Response != DialogResult.OK)
                    {
                        return;
                    }
                }

                Mdl1.Ssql = "Update TblETFStocksInvestmentPlan set [Name] = '" + Quote(TmpName) + "'"
                          + " where [Name] = '" + Quote(OrgPlanName) + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                if (TmpUsed > 0)
                {
                    Mdl1.Ssql = "Update TblETFStocksInvestmentPlanAllocation"
                              + " set [Investment_Plan_Name] = '" + Quote(TmpName) + "'"
                              + " where [Investment_Plan_Name] = '" + Quote(OrgPlanName) + "'";
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Update successfully for " + TmpName
                    + (TmpUsed > 0 ? ", with " + TmpUsed.ToString() + " allocation(s) moved" : ""), "Success");
                Refresh_All(TmpName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Deleting a plan that still has allocations would leave them orphaned, so it is refused
        //and the allocations are named. Removing them first is the deliberate way through.
        private void CmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PlanSelected)
                {
                    MessageBox.Show("Please select an investment plan from the list first !", "Error Message");
                    return;
                }

                int TmpUsed = Allocation_Count(OrgPlanName);
                if (TmpUsed > 0)
                {
                    MessageBox.Show("Investment plan " + OrgPlanName + " still has " + TmpUsed.ToString()
                        + " allocation(s). Please remove them below first.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksInvestmentPlan where [Name] = '" + Quote(OrgPlanName) + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + OrgPlanName, "Success");
                txtName.Text = "";
                Refresh_All(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the allocations -------------------------------------------------------

        private void Fill_Full_Ticker()
        {
            CmbFullTicker.Items.Clear();
            Mdl1.Ssql = "select [Full_Ticker] from TblETFStocks order by [Full_Ticker]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFullTicker.Items.Add(Read_Text(reader["Full_Ticker"]));
            }
            reader.Close();
            if (CmbFullTicker.Items.Count > 0)
            {
                CmbFullTicker.SelectedIndex = 0;
            }
        }

        //Both plan dropdowns list every plan. parKeep is the plan to stay on where it still
        //exists, so adding or renaming a plan does not throw the selection back to the first one.
        private void Fill_Plan_Dropdowns(string parKeep)
        {
            Filling = true;
            string TmpWanted = (parKeep != null ? parKeep : CmbPlan.Text.Trim());

            CmbPlan.Items.Clear();
            CmbAllocPlan.Items.Clear();
            Mdl1.Ssql = "select [Name] from TblETFStocksInvestmentPlan order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpName = Read_Text(reader["Name"]);
                CmbPlan.Items.Add(TmpName);
                CmbAllocPlan.Items.Add(TmpName);
            }
            reader.Close();

            if (CmbPlan.Items.Contains(TmpWanted))
            {
                CmbPlan.Text = TmpWanted;
            }
            else if (CmbPlan.Items.Count > 0)
            {
                CmbPlan.SelectedIndex = 0;
            }
            Sync_Alloc_Plan();
            Filling = false;
        }

        private void Fill_Plan_Dropdowns()
        {
            Fill_Plan_Dropdowns(null);
        }

        //The entry dropdown follows the one above the table, so an allocation is added to the
        //plan being looked at rather than to whichever plan happened to be left selected.
        private void Sync_Alloc_Plan()
        {
            if (CmbAllocPlan.Items.Contains(CmbPlan.Text.Trim()))
            {
                CmbAllocPlan.Text = CmbPlan.Text.Trim();
            }
            else if (CmbAllocPlan.Items.Count > 0)
            {
                CmbAllocPlan.SelectedIndex = 0;
            }
        }

        private void CmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Sync_Alloc_Plan();
            Get_Allocations();
        }

        private void Clear_Alloc_Grid()
        {
            gvAlloc.Rows.Clear();
            gvAlloc.Columns.Clear();
            gvAlloc.ColumnCount = 3;
            string[] names = new string[] { "Investment Plan", "Full Ticker", "Allocation" };
            int[] weights = new int[] { 45, 30, 25 };
            for (int i = 0; i < 3; i++)
            {
                gvAlloc.Columns[i].Name = names[i];
                gvAlloc.Columns[i].FillWeight = weights[i];
                //the two names read left, the percentage reads right
                DataGridViewContentAlignment TmpAlign =
                    (i == 2 ? DataGridViewContentAlignment.MiddleRight : DataGridViewContentAlignment.MiddleLeft);
                gvAlloc.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvAlloc.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private void Get_Allocations()
        {
            try
            {
                Filling = true;
                Clear_Alloc_Grid();
                AllocSelected = false;
                double TmpTotal = 0;

                string TmpPlan = CmbPlan.Text.Trim();
                if (TmpPlan != "")
                {
                    Mdl1.Ssql = "select [Investment_Plan_Name], [Full_Ticker], [Allocation]"
                              + " from TblETFStocksInvestmentPlanAllocation"
                              + " where [Investment_Plan_Name] = '" + Quote(TmpPlan) + "'"
                              + " order by [Full_Ticker]";
                    OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        double TmpAlloc = Read_Double(reader["Allocation"]);
                        TmpTotal = TmpTotal + TmpAlloc;
                        gvAlloc.Rows.Add(new string[] {
                            Read_Text(reader["Investment_Plan_Name"]),
                            Read_Text(reader["Full_Ticker"]),
                            Percent(TmpAlloc) });
                    }
                    reader.Close();
                }

                gvAlloc.ClearSelection();
                Filling = false;

                TmpTotal = Math.Round(TmpTotal, 2);
                Show_Total(TmpTotal);
                if (CmbPlan.Items.Count == 0)
                {
                    LblNote2.Text = "No investment plans yet - add one above first.";
                }
                else if (gvAlloc.Rows.Count == 0)
                {
                    LblNote2.Text = "No allocations for this investment plan yet.";
                }
                else
                {
                    LblNote2.Text = gvAlloc.Rows.Count.ToString() + " allocation(s)";
                }
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //A plan only makes sense once its allocations account for the whole of it, so the total
        //is green at exactly 100 and red anywhere else - including at 0, where there is nothing
        //allocated yet.
        private void Show_Total(double parTotal)
        {
            LblTotal.Text = Percent(parTotal);
            if (parTotal == 100)
            {
                LblTotal.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LblTotal.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void gvAlloc_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvAlloc.SelectedRows.Count > 0)
            {
                Row = gvAlloc.SelectedRows[0];
            }
            else
            {
                Row = gvAlloc.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            //the grid shows the allocation with a per-cent sign, so the stored figure is read
            //back from the database rather than parsed off the screen
            OrgAllocPlan = Row.Cells[0].Value.ToString().Trim();
            OrgAllocTicker = Row.Cells[1].Value.ToString().Trim();

            Filling = true;
            if (CmbAllocPlan.Items.Contains(OrgAllocPlan)) { CmbAllocPlan.Text = OrgAllocPlan; }
            if (CmbFullTicker.Items.Contains(OrgAllocTicker)) { CmbFullTicker.Text = OrgAllocTicker; }
            OrgAllocAmount = Num(Read_Allocation(OrgAllocPlan, OrgAllocTicker));
            txtAllocation.Text = OrgAllocAmount;
            Filling = false;

            AllocSelected = true;
        }

        private double Read_Allocation(string parPlan, string parTicker)
        {
            double Result = 0;
            Mdl1.Ssql = "select [Allocation] from TblETFStocksInvestmentPlanAllocation"
                      + " where [Investment_Plan_Name] = '" + Quote(parPlan) + "'"
                      + " and [Full_Ticker] = '" + Quote(parTicker) + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Result = Read_Double(reader["Allocation"]);
            }
            reader.Close();
            return Result;
        }

        private bool Allocation_Exists(string parPlan, string parTicker)
        {
            bool Found = false;
            Mdl1.Ssql = "select [Full_Ticker] from TblETFStocksInvestmentPlanAllocation"
                      + " where [Investment_Plan_Name] = '" + Quote(parPlan) + "'"
                      + " and [Full_Ticker] = '" + Quote(parTicker) + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        private bool Valid_Allocation(out string parPlan, out string parTicker, out double parAmount)
        {
            parPlan = CmbAllocPlan.Text.Trim();
            parTicker = CmbFullTicker.Text.Trim();
            parAmount = 0;

            if (parPlan == "")
            {
                MessageBox.Show("Investment Plan must be selected ! Please add one above first.", "Error Message");
                return false;
            }
            if (parTicker == "")
            {
                MessageBox.Show("Full Ticker must be selected ! Please set one up first in ETF/Stock Setup.", "Error Message");
                return false;
            }
            return Valid_Amount(txtAllocation, "Allocation", out parAmount);
        }

        private void CmdAllocCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpPlan, TmpTicker;
                double TmpAmount;
                if (!Valid_Allocation(out TmpPlan, out TmpTicker, out TmpAmount))
                {
                    return;
                }
                //the same ticker twice in one plan would make the total meaningless
                if (Allocation_Exists(TmpPlan, TmpTicker))
                {
                    MessageBox.Show(TmpTicker + " is already allocated in " + TmpPlan
                        + ". Select it from the list and update it instead.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Insert into TblETFStocksInvestmentPlanAllocation ([Investment_Plan_Name],"
                          + " [Full_Ticker], [Allocation]) values ('" + Quote(TmpPlan) + "', '"
                          + Quote(TmpTicker) + "', " + Num(TmpAmount) + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for " + TmpTicker + " in " + TmpPlan, "Success");
                Show_Plan(TmpPlan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdAllocUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AllocSelected)
                {
                    MessageBox.Show("Please select an allocation from the list first !", "Error Message");
                    return;
                }
                string TmpPlan, TmpTicker;
                double TmpAmount;
                if (!Valid_Allocation(out TmpPlan, out TmpTicker, out TmpAmount))
                {
                    return;
                }
                //moving a row onto a plan and ticker that already has one would make two
                if ((TmpPlan != OrgAllocPlan || TmpTicker != OrgAllocTicker)
                    && Allocation_Exists(TmpPlan, TmpTicker))
                {
                    MessageBox.Show(TmpTicker + " is already allocated in " + TmpPlan + " !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Update TblETFStocksInvestmentPlanAllocation set"
                          + " [Investment_Plan_Name] = '" + Quote(TmpPlan) + "',"
                          + " [Full_Ticker] = '" + Quote(TmpTicker) + "',"
                          + " [Allocation] = " + Num(TmpAmount)
                          + " where [Investment_Plan_Name] = '" + Quote(OrgAllocPlan) + "'"
                          + " and [Full_Ticker] = '" + Quote(OrgAllocTicker) + "'"
                          + " and [Allocation] = " + OrgAllocAmount;
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for " + TmpTicker + " in " + TmpPlan, "Success");
                Show_Plan(TmpPlan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void CmdAllocDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AllocSelected)
                {
                    MessageBox.Show("Please select an allocation from the list first !", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksInvestmentPlanAllocation"
                          + " where [Investment_Plan_Name] = '" + Quote(OrgAllocPlan) + "'"
                          + " and [Full_Ticker] = '" + Quote(OrgAllocTicker) + "'"
                          + " and [Allocation] = " + OrgAllocAmount;
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for " + OrgAllocTicker + " in " + OrgAllocPlan, "Success");
                Show_Plan(OrgAllocPlan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- refreshing ------------------------------------------------------------

        private void Show_Plan(string parPlan)
        {
            Filling = true;
            if (parPlan != null && CmbPlan.Items.Contains(parPlan))
            {
                CmbPlan.Text = parPlan;
                Sync_Alloc_Plan();
            }
            Filling = false;
            Get_Allocations();
        }

        private void Refresh_All(string parKeep)
        {
            Get_Plans();
            Fill_Plan_Dropdowns(parKeep);
            Get_Allocations();
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
