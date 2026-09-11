using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FinancialBalance
{
    public partial class Setup_Property : Form
    {
        //true while Get_Data is refilling the grid, so the rows it adds do not fire the
        //selection handler and type themselves back into the boxes
        bool Filling;

        //The id of the row picked out of the grid, so Update and Delete know which one they are
        //working on. Zero until a row is picked, which is what makes Update refuse before there
        //is anything to update.
        int OrgId;

        //What a property is, and nothing about what happened to it: the purchase date lives on
        //TblPropertyPurchase and whether and when it sold on TblPropertySale, each alongside the
        //costs that belong with it. Holding those here as well meant the same fact written in
        //two places with nothing keeping them in step.
        //
        //Name, Address and State are all reserved or awkward enough in Access that every column
        //is bracketed rather than only the ones that have to be.
        const string Fields = "[Property_Id], [Name], [Address], [Suburb], [State], [Post_Code]";

        public Setup_Property()
        {
            InitializeComponent();
        }

        private void Setup_Property_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_State();
            Filling = false;

            Get_Data();
            Clear_Entry();
        }

        private void MnDailyInput_Click(object sender, EventArgs e)
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

        private void MnETFStocksPrice_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Price ETF_Stocks_Price = new ETF_Stocks_Price();
            ETF_Stocks_Price.Show();
            this.Close();
        }

        private void MnETFStocksInvestment_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Investment ETF_Stocks_Investment = new ETF_Stocks_Investment();
            ETF_Stocks_Investment.Show();
            this.Close();
        }

        private void MnETFStocksPurchase_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Purchase ETF_Stocks_Purchase = new ETF_Stocks_Purchase();
            ETF_Stocks_Purchase.Show();
            this.Close();
        }

        private void MnETFStocksSale_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Sale ETF_Stocks_Sale = new ETF_Stocks_Sale();
            ETF_Stocks_Sale.Show();
            this.Close();
        }

        private void MnETFStocksDistribution_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Distribution ETF_Stocks_Distribution = new ETF_Stocks_Distribution();
            ETF_Stocks_Distribution.Show();
            this.Close();
        }

        private void MnETFStocksCostBase_Click(object sender, EventArgs e)
        {
            ETF_Stocks_Cost_Base_Adjustment ETF_Stocks_Cost_Base_Adjustment = new ETF_Stocks_Cost_Base_Adjustment();
            ETF_Stocks_Cost_Base_Adjustment.Show();
            this.Close();
        }

        private void MnETFStocksFYRecon_Click(object sender, EventArgs e)
        {
            ETF_Stocks_FY_Reconciliation ETF_Stocks_FY_Reconciliation = new ETF_Stocks_FY_Reconciliation();
            ETF_Stocks_FY_Reconciliation.Show();
            this.Close();
        }

        private void MnPropertyPurchase_Click(object sender, EventArgs e)
        {
            Property_Purchase Property_Purchase = new Property_Purchase();
            Property_Purchase.Show();
            this.Close();
        }

        private void MnPropertySale_Click(object sender, EventArgs e)
        {
            Property_Sale Property_Sale = new Property_Sale();
            Property_Sale.Show();
            this.Close();
        }

        private void MnSuperProcess_Click(object sender, EventArgs e)
        {
            Super_Financial_Year Super_Financial_Year = new Super_Financial_Year();
            Super_Financial_Year.Show();
            this.Close();
        }

        //---- the dropdowns ----------------------------------------------------------

        private void Fill_State()
        {
            CmbState.Items.Clear();
            CmbState.Items.Add("");
            Mdl1.Ssql = "select [Name] from TblState order by [Name]";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CmbState.Items.Add(reader["Name"].ToString().Trim());
            }
            reader.Close();
        }

        //---- the list ---------------------------------------------------------------

        private void Clear_Grid()
        {
            gvProperty.Rows.Clear();
            gvProperty.Columns.Clear();
            gvProperty.ColumnCount = 3;
            string[] names = new string[] { "Property Id", "Name", "Full Address" };
            int[] weights = new int[] { 10, 28, 62 };
            for (int i = 0; i < 3; i++)
            {
                gvProperty.Columns[i].Name = names[i];
                gvProperty.Columns[i].FillWeight = weights[i];
                //the id reads centred, the words read left
                DataGridViewContentAlignment TmpAlign =
                    (i == 0 ? DataGridViewContentAlignment.MiddleCenter
                            : DataGridViewContentAlignment.MiddleLeft);
                gvProperty.Columns[i].HeaderCell.Style.Alignment = TmpAlign;
                gvProperty.Columns[i].DefaultCellStyle.Alignment = TmpAlign;
            }
        }

        private string Read_Text(object parValue)
        {
            return (parValue == null || parValue == DBNull.Value
                    ? "" : parValue.ToString().Trim());
        }

        private void Get_Data()
        {
            try
            {
                Filling = true;
                Clear_Grid();

                Mdl1.Ssql = "select " + Fields + " from TblProperty order by [Property_Id]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //the address is four fields on screen and one column here
                    string TmpFull = string.Join(" ", new string[] {
                        Read_Text(reader["Address"]), Read_Text(reader["Suburb"]),
                        Read_Text(reader["State"]), Read_Text(reader["Post_Code"]) }
                        .Where(x => x != "").ToArray());

                    gvProperty.Rows.Add(new string[] {
                        Read_Text(reader["Property_Id"]),
                        Read_Text(reader["Name"]),
                        TmpFull });
                }
                reader.Close();

                gvProperty.ClearSelection();
                Filling = false;
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //Clicking a row loads it back into the entry area, so it can be changed or removed
        //without any of it being typed again.
        private void gvProperty_SelectionChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            DataGridViewRow Row = null;
            if (gvProperty.SelectedRows.Count > 0)
            {
                Row = gvProperty.SelectedRows[0];
            }
            else
            {
                Row = gvProperty.CurrentRow;
            }
            if (Row == null || Row.Cells[0].Value == null)
            {
                return;
            }

            int TmpId;
            if (!int.TryParse(Row.Cells[0].Value.ToString().Trim(), out TmpId))
            {
                return;
            }
            Load_Record(TmpId);
        }

        //Read back from the table rather than off the grid: the grid shows the address as one
        //column, which cannot be taken apart again.
        private void Load_Record(int parId)
        {
            try
            {
                Mdl1.Ssql = "select " + Fields + " from TblProperty where [Property_Id] = "
                          + parId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    reader.Close();
                    return;
                }

                Filling = true;
                OrgId = parId;
                LblPropertyId.Text = parId.ToString(CultureInfo.InvariantCulture);
                Show_Id(true);
                txtName.Text = Read_Text(reader["Name"]);
                txtAddress.Text = Read_Text(reader["Address"]);
                txtSuburb.Text = Read_Text(reader["Suburb"]);
                CmbState.Text = Read_Text(reader["State"]);
                txtPostCode.Text = Read_Text(reader["Post_Code"]);
                Filling = false;
                reader.Close();
            }
            catch (Exception ex)
            {
                Filling = false;
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //---- the entry area ---------------------------------------------------------

        //The id is the table's own, not something anyone types, so it is only worth showing once
        //there is a record it belongs to.
        private void Show_Id(bool parShow)
        {
            Lbl_PropertyId.Visible = parShow;
            LblPropertyId.Visible = parShow;
        }

        private void Clear_Entry()
        {
            Filling = true;
            OrgId = 0;
            LblPropertyId.Text = "";
            Show_Id(false);
            txtName.Text = "";
            txtAddress.Text = "";
            txtSuburb.Text = "";
            CmbState.Text = "";
            txtPostCode.Text = "";
            //ClearSelection fires SelectionChanged, and the handler falls back to CurrentRow
            //when nothing is selected - so clearing outside the guard loads straight back the
            //record it was clearing, leaving OrgId set.
            gvProperty.ClearSelection();
            Filling = false;

            LblNote.Text = "";
        }

        private void CmdClear_Click(object sender, EventArgs e)
        {
            Clear_Entry();
        }

        //---- what may be saved ------------------------------------------------------

        private string Quoted(string parText)
        {
            //a quote typed into an address would otherwise end the literal and break the
            //statement, so it is doubled the way SQL expects
            return "'" + (parText == null ? "" : parText.Trim()).Replace("'", "''") + "'";
        }

        private bool Read_Entry(out string parWhy)
        {
            parWhy = "";

            if (txtName.Text.Trim() == "")
            {
                parWhy = "Name cannot be empty !";
                return false;
            }
            string TmpPost = txtPostCode.Text.Trim();
            if (TmpPost != "" && !Mdl1.k_Numeric(TmpPost))
            {
                parWhy = "Post Code must be digits only.";
                return false;
            }
            return true;
        }

        private string Values()
        {
            return Quoted(txtName.Text) + ", "
                 + Quoted(txtAddress.Text) + ", "
                 + Quoted(txtSuburb.Text) + ", "
                 + Quoted(CmbState.Text) + ", "
                 + Quoted(txtPostCode.Text);
        }

        //Property_Id is a plain number rather than an AutoNumber, so the next one is worked out
        //here. Max + 1 rather than count + 1, which would repeat an id after a deletion.
        private int Next_Id()
        {
            int TmpNext = 1;
            Mdl1.Ssql = "select Max([Property_Id]) as N from TblProperty";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read() && reader["N"] != DBNull.Value)
            {
                TmpNext = Convert.ToInt32(reader["N"]) + 1;
            }
            reader.Close();
            return TmpNext;
        }

        private bool Exists(int parId)
        {
            Mdl1.Ssql = "select [Property_Id] from TblProperty where [Property_Id] = "
                      + parId.ToString(CultureInfo.InvariantCulture);
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            bool Found = reader.HasRows;
            reader.Close();
            return Found;
        }

        //How many rows elsewhere hang off this property. Now that the purchase and the sale live
        //in tables of their own, deleting the property would leave them pointing at nothing.
        private int Depends_On(int parId)
        {
            int TmpCount = 0;
            foreach (string Table in new string[] { "TblPropertyPurchase", "TblPropertySale" })
            {
                Mdl1.Ssql = "select Count(*) as N from " + Table + " where [Property_Id] = "
                          + parId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && reader["N"] != DBNull.Value)
                {
                    TmpCount = TmpCount + Convert.ToInt32(reader["N"]);
                }
                reader.Close();
            }
            return TmpCount;
        }

        //---- add, update, delete ----------------------------------------------------

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string TmpWhy;
                if (!Read_Entry(out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                int TmpId = Next_Id();
                Mdl1.Ssql = "Insert into TblProperty (" + Fields + ") values ("
                          + TmpId.ToString(CultureInfo.InvariantCulture) + ", " + Values() + ")";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Property Id : "
                    + TmpId.ToString(CultureInfo.InvariantCulture), "Success");
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
                if (OrgId == 0)
                {
                    MessageBox.Show("Please select a property from the list first !", "Error Message");
                    return;
                }
                if (!Exists(OrgId))
                {
                    MessageBox.Show("Data not found for Property Id : "
                        + OrgId.ToString(CultureInfo.InvariantCulture), "Error Message");
                    return;
                }

                string TmpWhy;
                if (!Read_Entry(out TmpWhy))
                {
                    MessageBox.Show(TmpWhy, "Error Message");
                    return;
                }

                //the id itself is never changed - it is the key the row is found by, and what the
                //purchase and sale records point at
                Mdl1.Ssql = "Update TblProperty set"
                          + " [Name] = " + Quoted(txtName.Text) + ","
                          + " [Address] = " + Quoted(txtAddress.Text) + ","
                          + " [Suburb] = " + Quoted(txtSuburb.Text) + ","
                          + " [State] = " + Quoted(CmbState.Text) + ","
                          + " [Post_Code] = " + Quoted(txtPostCode.Text)
                          + " where [Property_Id] = " + OrgId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Update successfully for Property Id : "
                    + OrgId.ToString(CultureInfo.InvariantCulture), "Success");
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
                if (OrgId == 0)
                {
                    MessageBox.Show("Please select a property from the list first !", "Error Message");
                    return;
                }
                if (!Exists(OrgId))
                {
                    MessageBox.Show("Data not found for Property Id : "
                        + OrgId.ToString(CultureInfo.InvariantCulture), "Error Message");
                    return;
                }

                //a purchase or sale record left behind would point at a property that is gone
                int TmpHanging = Depends_On(OrgId);
                if (TmpHanging > 0)
                {
                    MessageBox.Show(TmpHanging.ToString(CultureInfo.InvariantCulture)
                        + " purchase or sale record(s) belong to this property, so it cannot be"
                        + " deleted." + Environment.NewLine
                        + "Remove those first, in Property Purchase and Property Sale.",
                        "Error Message");
                    return;
                }

                DialogResult Response = MessageBox.Show(
                    "Delete property " + OrgId.ToString(CultureInfo.InvariantCulture)
                    + ", " + txtName.Text.Trim() + " ?", "Confirmation", MessageBoxButtons.OKCancel);
                if (Response != DialogResult.OK)
                {
                    return;
                }

                Mdl1.Ssql = "Delete from TblProperty where [Property_Id] = "
                          + OrgId.ToString(CultureInfo.InvariantCulture);
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Delete successfully for Property Id : "
                    + OrgId.ToString(CultureInfo.InvariantCulture), "Success");
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
