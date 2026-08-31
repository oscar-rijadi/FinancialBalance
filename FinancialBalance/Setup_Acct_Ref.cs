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
    public partial class Setup_Acct_Ref : Form
    {
        public Setup_Acct_Ref()
        {
            InitializeComponent();
        }

        private void Setup_Acct_Ref_Load(object sender, EventArgs e)
        {
            Mdl1.Fill_Acct_Type(CmbAcctType);
		    Mdl1.Fill_Curr(CmbCurr);
		    Mdl1.Fill_Acct_Code(CmbAcctCode);
            Mdl1.Fill_Current_Asset(CmbCurrentAsset);
            Get_Data();
        }

        private void MnAcctTypeRefSetup_Click(object sender, EventArgs e)
        {
            Setup_Acct_Type_Ref Setup_Acct_Type_Ref = new Setup_Acct_Type_Ref();
            Setup_Acct_Type_Ref.Show();
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

        private void Clear_Grid()
        {
            gvAcctRef.Columns.Clear();
            gvAcctRef.ColumnCount = 5;
            gvAcctRef.Columns[0].Name = "Acct Code";
            gvAcctRef.Columns[0].FillWeight = 19;
            gvAcctRef.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctRef.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctRef.Columns[1].Name = "Acct Name";
            gvAcctRef.Columns[1].FillWeight = 50;
            gvAcctRef.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvAcctRef.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gvAcctRef.Columns[2].Name = "Acct Type";
            gvAcctRef.Columns[2].FillWeight = 19;
            gvAcctRef.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctRef.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctRef.Columns[3].Name = "Curr Code";
            gvAcctRef.Columns[3].FillWeight = 12;
            gvAcctRef.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctRef.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctRef.Columns[4].Name = "Current Asset";
            gvAcctRef.Columns[4].FillWeight = 12;
            gvAcctRef.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvAcctRef.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Get_Data()
        {
            Clear_Grid();

            string[] row;
            string strCurrentAsset = "";

            Mdl1.Ssql = "Select A.*, B.Acct_Type_Name from TblAcctRef A left join TblAcctTypeRef B on B.Acct_Type = A.Acct_Type order by A.Acct_Type, A.Acct_Order";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["Acct_Code"].ToString().Trim().Substring(0, 1) == "A")
                    {
                        if (reader["Current_Asset"].ToString().Trim() == "True")
                        {
                            strCurrentAsset = "Y";
                        }
                        else
                        {
                            strCurrentAsset = "N";
                        }
                    }
                    else
                    {
                        strCurrentAsset = "";
                    }
                    row = new string[] { reader["Acct_Code"].ToString().Trim(), reader["Acct_Name"].ToString().Trim(), reader["Acct_Type_Name"].ToString().Trim(), reader["Curr_Code"].ToString().Trim(), strCurrentAsset };
                    gvAcctRef.Rows.Add(row);
                }
            }
            reader.Close();
        }

        private void CmbAcctCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Detail();
        }

        private void Get_Detail()
        {
            Mdl1.Ssql = "Select A.*, B.Acct_Type_Name from TblAcctRef A left join TblAcctTypeRef B on B.Acct_Type = A.Acct_Type where A.Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtAcctName.Text = reader["Acct_Name"].ToString().Trim();
                    CmbAcctType.Text = reader["Acct_Type"].ToString().Trim() + " - " + reader["Acct_Type_Name"].ToString().Trim();
                    CmbCurr.Text = reader["Curr_Code"].ToString().Trim();
                    txtAcctOrder.Text = reader["Acct_Order"].ToString().Trim();

                    if (reader["Acct_Code"].ToString().Trim().Substring(0, 1) == "A")
                    {
                        if (reader["Current_Asset"].ToString().Trim() == "True")
                        {
                            CmbCurrentAsset.Text = "Y";
                        }
                        else
                        {
                            CmbCurrentAsset.Text = "N";
                        }
                        CmbCurrentAsset.Enabled = true;
                    }
                    else
                    {
                        CmbCurrentAsset.Text = "N";
                        CmbCurrentAsset.Enabled = false;
                    }
                }
            }
            reader.Close();
        }

        private void txtAcctOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            short KeyAscii = (short)e.KeyChar;
            KeyAscii = Mdl1.NumericKeyPress(KeyAscii);
            e.KeyChar = (char)KeyAscii;
            if (KeyAscii == 0)
            {
                e.Handled = true;
            }
        }

        private void CmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int TmpSeq;
                string TmpNewAcctCode;

                string strCurrentAsset = "";
                if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
                {
                    if (CmbCurrentAsset.Text.Trim() == "Y")
                    {
                        strCurrentAsset = "1";
                    }
                    else
                    {
                        strCurrentAsset = "0";
                    }
                }
                else
                {
                    strCurrentAsset = "0";
                }

                Mdl1.Ssql = "Select top 1 Acct_Code from TblAcctRef where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' order by Acct_Code Desc";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    TmpSeq = int.Parse(reader["Acct_Code"].ToString().Trim().Substring(1, 4)) + 1;
                }
                else
                {
                    TmpSeq = 1;
                }
                reader.Close();
                TmpNewAcctCode = CmbAcctType.Text.Trim().Substring(4, 1) + TmpSeq.ToString("0000");

                if (txtAcctOrder.Text.Trim() == "" || txtAcctOrder.Text.Trim() == "0")
                {
                    Mdl1.Ssql = "Select top 1 Acct_Order from TblAcctRef where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' order by Acct_Order Desc";
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtAcctOrder.Text = (int.Parse(reader["Acct_Order"].ToString().Trim()) + 1).ToString();
                    }
                    else
                    {
                        txtAcctOrder.Text = "1";
                    }
                    reader.Close();
                }

                Mdl1.Ssql = "Update TblAcctRef set Acct_Order = Acct_Order + 1 where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' And Acct_Order >= " + txtAcctOrder.Text.Trim();
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                Mdl1.Ssql = "Insert into TblAcctRef values ('" + TmpNewAcctCode + "', '" + txtAcctName.Text.Trim() + "', '" + CmbAcctType.Text.Trim().Substring(0, 1) + "', '" + CmbCurr.Text + "', " + txtAcctOrder.Text.Trim() + ", " + strCurrentAsset + ")";
                cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Create successfully for Acct Code : " + TmpNewAcctCode, "Success");

                Mdl1.Fill_Acct_Code(CmbAcctCode);
                Get_Data();
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
                bool FlagRecNotExist;
		        string OldAcctType = "";
                string OldAcctOrder = "";
                int TmpSeq;
                string TmpNewAcctCode = "";

                string strCurrentAsset = "";
                if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
                {
                    if (CmbCurrentAsset.Text.Trim() == "Y")
                    {
                        strCurrentAsset = "1";
                    }
                    else
                    {
                        strCurrentAsset = "0";
                    }
                }
                else
                {
                    strCurrentAsset = "0";
                }

                Mdl1.Ssql = "Select top 1 Acct_Type, Acct_Order from TblAcctRef where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    OldAcctType = reader["Acct_Type"].ToString().Trim();
                    OldAcctOrder = reader["Acct_Order"].ToString().Trim();
                    FlagRecNotExist = false;
                }
                else
                {
                    FlagRecNotExist = true;
                }
                reader.Close();

                if (FlagRecNotExist)
                {
                    MessageBox.Show("Data not found for Acct Code : " + CmbAcctCode.Text.Trim().Substring(0, 5), "Error Message");
                    return;
                }
                else
                {
                    if (OldAcctType != CmbAcctType.Text.Trim().Substring(0, 1))
                    {
                        Mdl1.Ssql = "Update TblAcctRef set Acct_Order = Acct_Order - 1 where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' And Acct_Order > " + OldAcctOrder.Trim();
                        cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        cmd.ExecuteNonQuery();

                        Mdl1.Ssql = "Delete from TblAcctRef where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0,5) + "'";
                        cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        cmd.ExecuteNonQuery();

                        Mdl1.Ssql = "Select top 1 Acct_Code from TblAcctRef where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' order by Acct_Code Desc";
                        cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            TmpSeq = int.Parse(reader["Acct_Code"].ToString().Trim().Substring(1, 4)) + 1;
                        }
                        else
                        {
                            TmpSeq = 1;
                        }
                        reader.Close();
                        TmpNewAcctCode = CmbAcctType.Text.Trim().Substring(4, 1) + TmpSeq.ToString("0000");

                        Mdl1.Ssql = "Update TblAcctRef set Acct_Order = Acct_Order + 1 where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' And Acct_Order >= " + txtAcctOrder.Text.Trim();
                        cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        cmd.ExecuteNonQuery();

                        Mdl1.Ssql = "Insert into TblAcctRef values ('" + TmpNewAcctCode + "', '" + txtAcctName.Text.Trim() + "', '" + CmbAcctType.Text.Trim().Substring(0, 1) + "', '" + CmbCurr.Text + "', " + txtAcctOrder.Text.Trim() + ", " + strCurrentAsset + ")";
                        cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Update successfully for Acct Code : " + TmpNewAcctCode, "Success");
                    }
                    else
                    {
                        if (txtAcctOrder.Text.Trim() != OldAcctOrder.Trim())
                        {
                            Mdl1.Ssql = "Update TblAcctRef set Acct_Order = Acct_Order - 1 where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' And Acct_Order > " + OldAcctOrder.Trim();
                            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            cmd.ExecuteNonQuery();

                            Mdl1.Ssql = "Update TblAcctRef set Acct_Order = Acct_Order + 1 where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' And Acct_Order >= " + txtAcctOrder.Text.Trim();
                            cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                            cmd.ExecuteNonQuery();
                        }

                        Mdl1.Ssql = "Update TblAcctRef set Acct_Name = '" + txtAcctName.Text.Trim() + "', Curr_Code = '" + CmbCurr.Text + "', Acct_Order = " + txtAcctOrder.Text.Trim() + ", Current_Asset = " + strCurrentAsset + " where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
                        cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Update successfully for Acct Code : " + CmbAcctCode.Text.Trim().Substring(0, 5), "Success");
                    }
                }                

                Mdl1.Fill_Acct_Code(CmbAcctCode);
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
                bool FlagRecNotExist;
                string OldAcctOrder = "";

                Mdl1.Ssql = "Select * from TblAcctRef where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring (0, 5) + "'";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    OldAcctOrder = reader["Acct_Order"].ToString().Trim();
                    FlagRecNotExist = false;
                }
                else
                {
                    FlagRecNotExist = true;
                }
                reader.Close();

                if (FlagRecNotExist)
                {
                    MessageBox.Show("Data not found for Acct Code : " + CmbAcctCode.Text.Trim().Substring(0, 5), "Error Message");
                    return;
                }
                else
                {
                    Mdl1.Ssql = "Update TblAcctRef set Acct_Order = Acct_Order - 1 where left(Acct_Code,1) = '" + CmbAcctType.Text.Trim().Substring(4, 1) + "' And Acct_Order > " + OldAcctOrder.Trim();
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();

                    Mdl1.Ssql = "Delete from TblAcctRef where Acct_Code = '" + CmbAcctCode.Text.Trim().Substring(0, 5) + "'";
                    cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                    cmd.ExecuteNonQuery();                        
                }

                MessageBox.Show("Delete successfully for Acct Code : " + CmbAcctCode.Text.Trim().Substring(0, 5), "Success");                    

                Mdl1.Fill_Acct_Code(CmbAcctCode);
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

        private void CmbAcctType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCurrentAsset.Enabled = true;
            if (CmbAcctType.Text.Trim().Substring(0, 1) == "1")
            {
                CmbCurrentAsset.Enabled = true;
            }
            else
            {
                CmbCurrentAsset.Enabled = false;
            }
        }
    }
}
