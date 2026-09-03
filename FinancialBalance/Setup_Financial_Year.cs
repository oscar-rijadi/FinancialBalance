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
    public partial class Setup_Financial_Year : Form
    {
        bool Filling;

        //Name is the natural key here, the same way Full_Ticker is on ETF/Stock Setup: Add is
        //an upsert on it, and Delete matches on it.  OrgName remembers which row is being
        //edited so renaming a year updates that row rather than creating a second one.
        string OrgName;

        //one MonthCalendar serves both date pickers
        string CalTarget = "START";

        public Setup_Financial_Year()
        {
            InitializeComponent();
        }

        private void Setup_Financial_Year_Load(object sender, EventArgs e)
        {
            Filling = true;
            Mdl1.Fill_Date(CmbSDD, CmbSMM, CmbSYear);
            Mdl1.Fill_Date(CmbEDD, CmbEMM, CmbEYear);
            Add_Future_Years(CmbSYear);
            Add_Future_Years(CmbEYear);
            Filling = false;

            Clear_Grid();
            Clear_Entry();
            Get_Data();

            monthCalendar1.Hide();
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

        private void MnETFStocksDivAllocSetup_Click(object sender, EventArgs e)
        {
            Setup_ETF_Stocks_Div_Alloc Setup_ETF_Stocks_Div_Alloc = new Setup_ETF_Stocks_Div_Alloc();
            Setup_ETF_Stocks_Div_Alloc.Show();
            this.Close();
        }

        //Stored as yyyyMMdd like every other date in the database
        private string Get_Start_Date()
        {
            return CmbSYear.Text + CmbSMM.Text + CmbSDD.Text;
        }

        private string Get_End_Date()
        {
            return CmbEYear.Text + CmbEMM.Text + CmbEDD.Text;
        }

        //dd-MMM-yyyy for display; Mdl1.toLongDate spells the month out in full, which is
        //too wide for three columns side by side.
        private string Format_Date(string parYyyyMMdd)
        {
            DateTime TmpDate;
            if (parYyyyMMdd != null && DateTime.TryParseExact(parYyyyMMdd.Trim(), "yyyyMMdd",
                    new CultureInfo("en-AU"), DateTimeStyles.None, out TmpDate))
            {
                return TmpDate.ToString("dd-MMM-yyyy", new CultureInfo("en-AU"));
            }
            return (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
        }

        //Mdl1.Fill_Date offers the current year and the two before it, which suits entering
        //transactions that have already happened.  A financial year is normally set up before
        //it begins, so this page carries two years ahead as well.
        const int FutureYears = 2;

        private void Add_Future_Years(ComboBox parYear)
        {
            for (int idx = DateTime.Now.Year + 1; idx <= DateTime.Now.Year + FutureYears; idx++)
            {
                Add_Year(parYear, idx.ToString("0000"));
            }
        }

        private void Add_Year(ComboBox parYear, string parYyyy)
        {
            if (!parYear.Items.Contains(parYyyy))
            {
                parYear.Items.Add(parYyyy);
            }
        }

        private void Set_Date(ComboBox parDD, ComboBox parMM, ComboBox parYear, string parYyyyMMdd)
        {
            if (parYyyyMMdd == null || parYyyyMMdd.Trim().Length != 8)
            {
                return;
            }
            string s = parYyyyMMdd.Trim();
            //these are DropDownLists, so a year the list does not carry cannot be selected and
            //the box would silently keep the year it already showed.  A stored year is a fact,
            //so it is added rather than dropped.
            Add_Year(parYear, s.Substring(0, 4));
            parYear.Text = s.Substring(0, 4);
            parMM.Text = s.Substring(4, 2);
            parDD.Text = s.Substring(6, 2);
        }

        private void CmdSCal_Click(object sender, EventArgs e)
        {
            CalTarget = "START";
            Show_Calendar(CmbSDD, CmbSMM, CmbSYear);
        }

        private void CmdECal_Click(object sender, EventArgs e)
        {
            CalTarget = "END";
            Show_Calendar(CmbEDD, CmbEMM, CmbEYear);
        }

        private void Show_Calendar(ComboBox parDD, ComboBox parMM, ComboBox parYear)
        {
            monthCalendar1.SetDate(new System.DateTime(int.Parse(parYear.Text), int.Parse(parMM.Text), int.Parse(parDD.Text), 0, 0, 0, 0));
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Filling = true;
            if (CalTarget == "END")
            {
                CmbEDD.Text = e.Start.Day.ToString("00");
                CmbEMM.Text = e.Start.Month.ToString("00");
                CmbEYear.Text = e.Start.Year.ToString("0000");
            }
            else
            {
                CmbSDD.Text = e.Start.Day.ToString("00");
                CmbSMM.Text = e.Start.Month.ToString("00");
                CmbSYear.Text = e.Start.Year.ToString("0000");
            }
            Filling = false;
            monthCalendar1.Hide();
        }

        private void Clear_Grid()
        {
            gvFY.Columns.Clear();
            gvFY.ColumnCount = 3;
            string[] names = new string[] { "Name", "Start Date", "End Date" };
            int[] weights = new int[] { 34, 33, 33 };
            for (int i = 0; i < 3; i++)
            {
                gvFY.Columns[i].Name = names[i];
                gvFY.Columns[i].FillWeight = weights[i];
                if (i == 0)
                {
                    gvFY.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    gvFY.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    gvFY.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    gvFY.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        //Ordered by the date the year opens, so the list reads chronologically
        private void Get_Data()
        {
            Filling = true;

            gvFY.Rows.Clear();

            Mdl1.Ssql = "select [Name], [Start_Date], [End_Date] from TblFinancialYear order by [Start_Date], [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string TmpName = Read_Text(reader["Name"]);
                string TmpStart = Read_Text(reader["Start_Date"]);
                string TmpEnd = Read_Text(reader["End_Date"]);

                gvFY.Rows.Add(new string[] { TmpName, Format_Date(TmpStart), Format_Date(TmpEnd) });
                //the stored forms travel with the row so the entry boxes get the exact values
                gvFY.Rows[gvFY.Rows.Count - 1].Tag = new string[] { TmpName, TmpStart, TmpEnd };
            }
            reader.Close();

            gvFY.ClearSelection();

            Filling = false;
        }

        private string Read_Text(object parValue)
        {
            if (parValue == null || parValue == DBNull.Value)
            {
                return "";
            }
            return parValue.ToString().Trim();
        }

        //Clicking a row loads it back into the entry area for editing
        private void gvFY_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }

            DataGridViewRow Row = null;
            if (gvFY.SelectedRows.Count > 0)
            {
                Row = gvFY.SelectedRows[0];
            }
            else
            {
                Row = gvFY.CurrentRow;
            }
            if (Row == null || Row.Tag == null)
            {
                return;
            }

            string[] o = (string[])Row.Tag;

            Filling = true;
            txtName.Text = o[0];
            Set_Date(CmbSDD, CmbSMM, CmbSYear, o[1]);
            Set_Date(CmbEDD, CmbEMM, CmbEYear, o[2]);
            Filling = false;

            OrgName = o[0];
        }

        private void Clear_Entry()
        {
            Filling = true;
            txtName.Text = "";
            CmbSDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbSMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbSYear.Text = String.Format("{0:yyyy}", DateTime.Now);
            CmbEDD.Text = String.Format("{0:dd}", DateTime.Now);
            CmbEMM.Text = String.Format("{0:MM}", DateTime.Now);
            CmbEYear.Text = String.Format("{0:yyyy}", DateTime.Now);
            Filling = false;

            OrgName = null;
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Filling = true;
            gvFY.ClearSelection();
            Filling = false;
            Clear_Entry();
        }

        private bool Validate_Entry()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Name cannot be empty !", "Error Message");
                return false;
            }
            if (!Mdl1.k_Date(CmbSDD.Text + CmbSMM.Text + CmbSYear.Text))
            {
                MessageBox.Show("Invalid Start Date !", "Error Message");
                return false;
            }
            if (!Mdl1.k_Date(CmbEDD.Text + CmbEMM.Text + CmbEYear.Text))
            {
                MessageBox.Show("Invalid End Date !", "Error Message");
                return false;
            }
            //a year that ends before it starts is a typo, not a financial year
            if (String.Compare(Get_End_Date(), Get_Start_Date(), StringComparison.Ordinal) < 0)
            {
                MessageBox.Show("End Date cannot be earlier than Start Date !", "Error Message");
                return false;
            }
            return true;
        }

        private bool Name_Exists(string parName)
        {
            Mdl1.Ssql = "select [Name] from TblFinancialYear where [Name] = '" + parName + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        private void CmdSetup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate_Entry())
                {
                    return;
                }

                string TmpName = txtName.Text.Trim();
                bool Renaming = (OrgName != null && OrgName != "" && OrgName != TmpName);

                //renaming onto a name that is already taken would merge two years into one
                if (Renaming && Name_Exists(TmpName))
                {
                    MessageBox.Show("Another financial year is already called " + TmpName + " !", "Error Message");
                    return;
                }

                bool Exists = (Renaming ? true : Name_Exists(TmpName));

                if (Renaming)
                {
                    Mdl1.Ssql = "Update TblFinancialYear set [Name] = '" + TmpName + "'"
                              + ", [Start_Date] = '" + Get_Start_Date() + "'"
                              + ", [End_Date] = '" + Get_End_Date() + "'"
                              + " where [Name] = '" + OrgName + "'";
                }
                else if (Exists)
                {
                    Mdl1.Ssql = "Update TblFinancialYear set [Start_Date] = '" + Get_Start_Date() + "'"
                              + ", [End_Date] = '" + Get_End_Date() + "'"
                              + " where [Name] = '" + TmpName + "'";
                }
                else
                {
                    Mdl1.Ssql = "Insert into TblFinancialYear ([Name], [Start_Date], [End_Date]) values ("
                              + "'" + TmpName + "', '" + Get_Start_Date() + "', '" + Get_End_Date() + "')";
                }
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show((Exists ? "Update" : "Create") + " successfully for Financial Year : " + TmpName, "Success");

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
                string TmpName = txtName.Text.Trim();
                if (TmpName == "")
                {
                    MessageBox.Show("Name cannot be empty !", "Error Message");
                    return;
                }
                if (!Name_Exists(TmpName))
                {
                    MessageBox.Show("Data not found for Financial Year : " + TmpName, "Error Message");
                    return;
                }

                Mdl1.Ssql = "Delete from TblFinancialYear where [Name] = '" + TmpName + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Financial Year : " + TmpName, "Success");

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
