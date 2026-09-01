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
    public partial class Setup_ETF_Stocks_Div_Alloc : Form
    {
        bool Filling;

        //Allocation is set for one ticker and one diversification type at a time.  Every
        //value of that type is listed, so the percentages entered are the whole picture
        //and can be checked against 100 before anything is written.
        const int RequiredTotal = 100;

        public Setup_ETF_Stocks_Div_Alloc()
        {
            InitializeComponent();
        }

        private void Setup_ETF_Stocks_Div_Alloc_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Full_Ticker();
            Fill_Div_Type();
            Filling = false;

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

        private void Fill_Full_Ticker()
        {
            CmbFullTicker.Items.Clear();
            Mdl1.Ssql = "select Full_Ticker from TblETFStocks order by Full_Ticker";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbFullTicker.Items.Add(reader["Full_Ticker"].ToString().Trim());
            }
            reader.Close();
            if (CmbFullTicker.Items.Count > 0)
            {
                CmbFullTicker.Text = CmbFullTicker.Items[0].ToString();
            }
        }

        private void Fill_Div_Type()
        {
            CmbDivType.Items.Clear();
            Mdl1.Ssql = "select [Name] from TblETFStocksDiversificationType order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbDivType.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();
            if (CmbDivType.Items.Count > 0)
            {
                CmbDivType.Text = CmbDivType.Items[0].ToString();
            }
        }

        private void CmbFullTicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void CmbDivType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Get_Data();
        }

        private void Clear_Grid()
        {
            gvAlloc.Rows.Clear();
            gvAlloc.Columns.Clear();
            gvAlloc.ColumnCount = 2;
            gvAlloc.Columns[0].Name = "Diversification Name";
            gvAlloc.Columns[0].FillWeight = 70;
            gvAlloc.Columns[0].ReadOnly = true;
            gvAlloc.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvAlloc.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvAlloc.Columns[1].Name = "Percentage";
            gvAlloc.Columns[1].FillWeight = 30;
            gvAlloc.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvAlloc.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        //Every value of the chosen type, carrying whatever is already stored for this ticker
        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                string TmpTicker = CmbFullTicker.Text.Trim();
                string TmpType = CmbDivType.Text.Trim();

                if (TmpTicker == "" || TmpType == "")
                {
                    Filling = false;
                    Show_Total();
                    return;
                }

                List<string> Names = new List<string>();
                Mdl1.Ssql = "select [Name] from TblETFStocksDiversification where [Type] = '" + TmpType + "' order by [Name]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Names.Add(reader["Name"].ToString().Trim());
                }
                reader.Close();

                for (int i = 0; i < Names.Count; i++)
                {
                    int TmpPct = 0;
                    Mdl1.Ssql = "select [Percentage] from TblETFStocksDiversificationAllocation"
                              + " where [Full_Ticker] = '" + TmpTicker + "'"
                              + " and [Diversification_Type] = '" + TmpType + "'"
                              + " and [Diversification_Name] = '" + Names[i] + "'";
                    OleDbCommand c2 = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    OleDbDataReader r2 = c2.ExecuteReader();
                    if (r2.Read() && r2["Percentage"] != DBNull.Value)
                    {
                        int.TryParse(r2["Percentage"].ToString(), out TmpPct);
                    }
                    r2.Close();

                    gvAlloc.Rows.Add(new string[] { Names[i], TmpPct.ToString() });
                }

                gvAlloc.ClearSelection();
                Filling = false;
                Show_Total();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Whole numbers only; anything else is rejected as it is typed
        private bool Cell_Value(int parRow, out int parValue)
        {
            parValue = 0;
            object v = gvAlloc.Rows[parRow].Cells[1].Value;
            string s = (v == null ? "" : v.ToString().Trim());
            if (s == "")
            {
                return true;
            }
            if (!int.TryParse(s, out parValue))
            {
                return false;
            }
            return true;
        }

        private int Grid_Total()
        {
            int Tot = 0;
            for (int i = 0; i < gvAlloc.Rows.Count; i++)
            {
                int v;
                if (Cell_Value(i, out v))
                {
                    Tot += v;
                }
            }
            return Tot;
        }

        //Green once the type adds up to 100, red until then
        private void Show_Total()
        {
            int Tot = Grid_Total();
            LblTotal.Text = Tot.ToString();

            if (gvAlloc.Rows.Count == 0)
            {
                LblTotal.ForeColor = System.Drawing.Color.Black;
                LblNote.Text = "Nothing to allocate for this type";
                return;
            }
            if (Tot == RequiredTotal)
            {
                LblTotal.ForeColor = System.Drawing.Color.Green;
                LblNote.Text = "";
            }
            else
            {
                LblTotal.ForeColor = System.Drawing.Color.Red;
                LblNote.Text = "Must add up to " + RequiredTotal.ToString() + " before it can be saved";
            }
        }

        private void gvAlloc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Filling)
            {
                return;
            }

            int v;
            if (!Cell_Value(e.RowIndex, out v))
            {
                MessageBox.Show("Percentage must be a whole number !", "Error Message");
                gvAlloc.Rows[e.RowIndex].Cells[1].Value = "0";
            }
            else if (v < 0)
            {
                MessageBox.Show("Percentage cannot be negative !", "Error Message");
                gvAlloc.Rows[e.RowIndex].Cells[1].Value = "0";
            }
            else if (v > RequiredTotal)
            {
                MessageBox.Show("Percentage cannot be more than " + RequiredTotal.ToString() + " !", "Error Message");
                gvAlloc.Rows[e.RowIndex].Cells[1].Value = RequiredTotal.ToString();
            }
            else
            {
                gvAlloc.Rows[e.RowIndex].Cells[1].Value = v.ToString();
            }

            Show_Total();
        }

        //The whole type is rewritten in one go, so it can never be left part-saved at
        //some total other than 100.  Only non-zero rows are stored.
        private void CmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpTicker = CmbFullTicker.Text.Trim();
                string TmpType = CmbDivType.Text.Trim();

                if (TmpTicker == "")
                {
                    MessageBox.Show("Full Ticker must be selected ! Please set one up first in ETF/Stock Setup.", "Error Message");
                    return;
                }
                if (TmpType == "")
                {
                    MessageBox.Show("Diversification Type must be selected !", "Error Message");
                    return;
                }
                if (gvAlloc.Rows.Count == 0)
                {
                    MessageBox.Show("There is nothing to allocate for " + TmpType
                        + ". Please set the values up first in ETF/Stock Diversification Setup.", "Error Message");
                    return;
                }

                for (int i = 0; i < gvAlloc.Rows.Count; i++)
                {
                    int v;
                    if (!Cell_Value(i, out v) || v < 0)
                    {
                        MessageBox.Show("Percentage must be a whole number that is not negative !", "Error Message");
                        return;
                    }
                }

                int Tot = Grid_Total();
                if (Tot != RequiredTotal)
                {
                    MessageBox.Show("Total allocation for " + TmpType + " is " + Tot.ToString()
                        + ". It must add up to " + RequiredTotal.ToString() + " before it can be saved.", "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksDiversificationAllocation"
                          + " where [Full_Ticker] = '" + TmpTicker + "'"
                          + " and [Diversification_Type] = '" + TmpType + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                for (int i = 0; i < gvAlloc.Rows.Count; i++)
                {
                    int v;
                    Cell_Value(i, out v);
                    if (v <= 0)
                    {
                        continue;
                    }
                    string TmpName = gvAlloc.Rows[i].Cells[0].Value.ToString().Trim();
                    Mdl1.Ssql = "Insert into TblETFStocksDiversificationAllocation"
                              + " ([Full_Ticker], [Diversification_Type], [Diversification_Name], [Percentage]) values ('"
                              + TmpTicker + "', '" + TmpType + "', '" + TmpName + "', " + v.ToString() + ")";
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Allocation saved for " + TmpTicker + " / " + TmpType + ".", "Success");

                Get_Data();
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
                string TmpTicker = CmbFullTicker.Text.Trim();
                string TmpType = CmbDivType.Text.Trim();

                if (TmpTicker == "" || TmpType == "")
                {
                    MessageBox.Show("Full Ticker and Diversification Type must be selected !", "Error Message");
                    return;
                }

                DialogResult Response = MessageBox.Show("Clear the whole " + TmpType + " allocation for "
                    + TmpTicker + " ?", "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblETFStocksDiversificationAllocation"
                          + " where [Full_Ticker] = '" + TmpTicker + "'"
                          + " and [Diversification_Type] = '" + TmpType + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                int n = cmd.ExecuteNonQuery();

                MessageBox.Show("Cleared " + n.ToString() + " allocation row(s) for " + TmpTicker + " / " + TmpType + ".", "Success");

                Get_Data();
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
