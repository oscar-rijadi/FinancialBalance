using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace FinancialBalance
{
    class Mdl1
    {
        public static OleDbConnection conn;
        public static OleDbDataReader reader;
        public static OleDbDataReader reader2;
        public static string Ssql;
        public static string StrYear;
        public static bool SetupTable;
        public static string errMsg;

        public static string DB_Connect()
        {
            try
            {
                conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                        @"Data source=" + Application.StartupPath + @"\Financial Balance.mdb;Jet OLEDB:Database Password=01121980";
                conn.Open();

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
	    public static void DB_Disconnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }    
        }
        public static void Fill_Date(ComboBox Combodd, ComboBox Combomm, ComboBox Comboyy)
        {
            for (int idx = 1; idx <= 31;idx++)
            {
                Combodd.Items.Add(idx.ToString("00"));
            }
            for (int idx = 1; idx <= 12; idx++)
            {
                Combomm.Items.Add(idx.ToString("00"));
            }
            for (int idx = (DateTime.Now.Year - 2); idx <= DateTime.Now.Year; idx++)
            {
                Comboyy.Items.Add(idx.ToString("0000"));
            }
        }
        public static void Fill_Month(ComboBox Combomm, ComboBox Comboyy)
        {
            for (int idx = 1; idx <= 12; idx++)
            {
                Combomm.Items.Add(idx.ToString("00"));
            }
            for (int idx = (DateTime.Now.Year - 2); idx <= DateTime.Now.Year; idx++)
            {
                Comboyy.Items.Add(idx.ToString("0000"));
            }
        }
        public static void Fill_Year(ComboBox Comboyy)
        {
            Comboyy.Items.Add("All");
            for (int idx = DateTime.Now.Year; idx >= (DateTime.Now.Year - 9); idx--)
            {
                Comboyy.Items.Add(idx.ToString("0000"));
            }
        }
        public static void Fill_Curr(ComboBox ComboCurr)
        {
            bool DataExist;
            ComboCurr.Items.Clear();
            Ssql = "Select Curr_Code, Curr_Name from TblCurrCode order by Curr_Code";
            OleDbCommand cmd = new OleDbCommand(Ssql, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ComboCurr.Items.Add(reader["Curr_Code"]);
                }
                DataExist = true;
            }
            else
            {
                DataExist = false;
            }
            reader.Close();
            if (DataExist)
            {
                ComboCurr.Text = "IDR";
            }
        }
        public static void Fill_Acct_Type(ComboBox ComboAcctType)
        {
            bool DataExist;
            ComboAcctType.Items.Clear();
            Ssql = "Select Acct_Type, Acct_Type_Name from TblAcctTypeRef order by Acct_Type";
            OleDbCommand cmd = new OleDbCommand(Ssql, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ComboAcctType.Items.Add(reader["Acct_Type"].ToString().Trim() + " - " + reader["Acct_Type_Name"].ToString().Trim());
                }
                DataExist = true;
            }
            else
            {
                DataExist = false;
            }
            reader.Close();
            if (DataExist)
            {
                ComboAcctType.Text = ComboAcctType.Items[0].ToString();
            }
        }
        public static void Fill_Acct_Type_Trans(ComboBox ComboAcctType, string parSelection)
        {
            bool DataExist;
            ComboAcctType.Items.Clear();
            Ssql = "Select Acct_Type, Acct_Type_Name from TblAcctTypeRef ";
            if (parSelection == "*")
            {
			    Ssql += "";
            }
		    else
            {
			    if (parSelection == "1,2")
                {
				    Ssql += "where Acct_Type = '1' or Acct_Type = '2'";
                }
			    else
                {
				    if (int.Parse(parSelection) >= 1 && int.Parse(parSelection) <= 4)
                    {
					    Ssql += "where Acct_Type = '" + parSelection + "'";
                    }
			    }
		    }
            Ssql += " order by Acct_Type";
            OleDbCommand cmd = new OleDbCommand(Ssql, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ComboAcctType.Items.Add(reader["Acct_Type"].ToString().Trim() + " - " + reader["Acct_Type_Name"].ToString().Trim());
                }
                DataExist = true;
            }
            else
            {
                DataExist = false;
            }
            reader.Close();
            if (DataExist)
            {
                ComboAcctType.Text = ComboAcctType.Items[0].ToString();
            }
        }
        public static void Fill_Acct_Code(ComboBox ComboAcctCode)
        {
            bool DataExist;
            ComboAcctCode.Items.Clear();
            Ssql = "Select Acct_Code, Acct_Name from TblAcctRef order by Acct_Type, Acct_Order";
            OleDbCommand cmd = new OleDbCommand(Ssql, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ComboAcctCode.Items.Add(reader["Acct_Code"].ToString().Trim() + " - " + reader["Acct_Name"].ToString().Trim());
                }
                DataExist = true;
            }
            else
            {
                DataExist = false;
            }
            reader.Close();
            if (DataExist)
            {
                ComboAcctCode.Text = ComboAcctCode.Items[0].ToString();
            }
        }
        public static void Fill_Acct_Code_Trans(ComboBox ComboAcctCode, string parAcctType)
        {
            bool DataExist;
            ComboAcctCode.Items.Clear();
            ComboAcctCode.Items.Add(" ");
            Ssql = "Select Acct_Code, Acct_Name from TblAcctRef where Acct_Type = '" + parAcctType + "' order by Acct_Order";
            OleDbCommand cmd = new OleDbCommand(Ssql, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ComboAcctCode.Items.Add(reader["Acct_Code"].ToString().Trim() + " - " + reader["Acct_Name"].ToString().Trim());
                }
                DataExist = true;
            }
            else
            {
                DataExist = false;
            }
            reader.Close();
            if (DataExist)
            {
                ComboAcctCode.Text = ComboAcctCode.Items[0].ToString();
            }
        }
        public static void Fill_Current_Asset(ComboBox ComboCurrentAsset)
        {
            ComboCurrentAsset.Items.Clear();
            ComboCurrentAsset.Items.Add("Y");
            ComboCurrentAsset.Items.Add("N");
            ComboCurrentAsset.Text = ComboCurrentAsset.Items[0].ToString();
        }
        public static void Fill_ETF_Stocks_Exchange_Suffix(ComboBox ComboSuffix)
        {
            bool DataExist;
            bool NoneExist = false;
            ComboSuffix.Items.Clear();
            Ssql = "Select Suffix from TblETFStocksExchangeSuffix order by Suffix";
            OleDbCommand cmd = new OleDbCommand(Ssql, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string TmpSuffix = reader["Suffix"].ToString().Trim();
                    ComboSuffix.Items.Add(TmpSuffix);
                    if (TmpSuffix == "None")
                    {
                        NoneExist = true;
                    }
                }
                DataExist = true;
            }
            else
            {
                DataExist = false;
            }
            reader.Close();
            if (DataExist)
            {
                if (NoneExist)
                {
                    ComboSuffix.Text = "None";
                }
                else
                {
                    ComboSuffix.Text = ComboSuffix.Items[0].ToString();
                }
            }
        }
        public static void Fill_ETF_Stocks_Purchase_Flag(ComboBox ComboFlag)
        {
            bool DataExist;
            bool DefaultExist = false;
            ComboFlag.Items.Clear();
            Ssql = "Select Portfolio_Code from TblETFStocksPortfolioCode order by Portfolio_Code";
            OleDbCommand cmd = new OleDbCommand(Ssql, conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string TmpFlag = reader["Portfolio_Code"].ToString().Trim();
                    ComboFlag.Items.Add(TmpFlag);
                    if (TmpFlag == "OB")
                    {
                        DefaultExist = true;
                    }
                }
                DataExist = true;
            }
            else
            {
                DataExist = false;
            }
            reader.Close();
            if (DataExist)
            {
                if (DefaultExist)
                {
                    ComboFlag.Text = "OB";
                }
                else
                {
                    ComboFlag.Text = ComboFlag.Items[0].ToString();
                }
            }
        }
        public static void Fill_Yes_No(ComboBox ComboYesNo)
        {
            ComboYesNo.Items.Clear();
            ComboYesNo.Items.Add("Y");
            ComboYesNo.Items.Add("N");
            ComboYesNo.Text = ComboYesNo.Items[0].ToString();
        }
        public static string FormatAmt(double parAmt)
        {
            return parAmt.ToString("##,###,###,###,###,###,##0.00");
        }
        public static bool k_Numeric(string txt)
        {         
            string ch;
            int tmpresult;
		    if (txt.Length == 0)
            {
                return false;
            }
            for (int i = 0; i <= (txt.Length - 1); i++)
            {
                ch = txt.Substring(i, 1);
                if (!int.TryParse(ch, out tmpresult))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool k_Date(string txt)
        {
            DateTime tmpResult;
            if (DateTime.TryParseExact(txt, "ddMMyyyy", new CultureInfo("en-AU"), System.Globalization.DateTimeStyles.None, out tmpResult))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string toLongDate(string txt)
        {
            DateTime tmpResult;
            if (DateTime.TryParseExact(txt, "yyyyMMdd", new CultureInfo("en-AU"), System.Globalization.DateTimeStyles.None, out tmpResult))
            {
                return String.Format("{0:dd MMMM yyyy}", tmpResult);
            }
            else
            {
                return "";
            }
        }
        public static string toLongMonth(string txt)
        {
            DateTime tmpResult;
            if (DateTime.TryParseExact(txt, "yyyyMM", new CultureInfo("en-AU"), System.Globalization.DateTimeStyles.None, out tmpResult))
            {
                return String.Format("{0:MMMM yyyy}", tmpResult);
            }
            else
            {
                return "";
            }
        }
        public static short NumericKeyPress(short KeyAscii)
        {
            if ((KeyAscii >= 48 && KeyAscii <= 57) || KeyAscii == 46 || KeyAscii == 8)
            {
			    return KeyAscii;
            }
		    else
            {
			    return 0;
		    }
        }
        public static double checkNumeric(string parNumeric)
        {
            double tmpResult;
            if (double.TryParse(parNumeric, out tmpResult))
            {
                return Math.Round(tmpResult, 2);
            }
            else
            {
                return 0;
            }
        }
        public static string GetAcctType(string parAcctCode)
        {            
            try
            {
                string GetAcctType = "";
		        Ssql = "Select Acct_Type from TblAcctRef where Acct_Code = '" + parAcctCode + "'";
                OleDbCommand cmd = new OleDbCommand(Ssql, conn);
                reader2 = cmd.ExecuteReader();

                if (reader2.HasRows)
                {
                    reader2.Read();
                    GetAcctType = reader2["Acct_Type"].ToString().Trim();
                }

                reader2.Close();

                return GetAcctType;
            }
            catch (Exception ex)
            {                
                errMsg = ex.Message;
                return "";
            }
        }
        public static string GetAcctTypeName(string parAcctType)
        {
            try
            {
                string GetAcctTypeName = "";
                Ssql = "Select Acct_Type_Name from TblAcctTypeRef where Acct_Type = '" + parAcctType + "'";
                OleDbCommand cmd = new OleDbCommand(Ssql, conn);
                reader2 = cmd.ExecuteReader();

                if (reader2.HasRows)
                {
                    reader2.Read();
                    GetAcctTypeName = reader2["Acct_Type_Name"].ToString().Trim();
                }

                reader2.Close();

                return GetAcctTypeName;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return "";
            }
        }
        public static string GetNextMonth(string parMonth)
        {
            try
            {
                int TmpMM;
		        int TmpYY;		        
		
		        if (parMonth.Trim().Substring(4, 2) == "12")
                {                
			        TmpMM = 1;
			        TmpYY = int.Parse(parMonth.Trim().Substring(0, 4)) + 1;
                }
		        else
                {
			        TmpMM = int.Parse(parMonth.Trim().Substring(4, 2)) + 1;
			        TmpYY = int.Parse(parMonth.Trim().Substring(0, 4));
		        }

                return TmpYY.ToString("0000") + TmpMM.ToString("00");
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return "";
            }
        }
        public static double GetCurrRate(string parCurr, string parMonth)
        {
            double GetCurrRate = 1;

            try
            {
                bool RecNotFound = true;

                Ssql = "Select top 1 Curr_Rate from TblCurrRate where Curr_Code = '" + parCurr + "' And left(Curr_Date,6) = '" + parMonth + "' order by Curr_Date Desc";
                OleDbCommand cmd = new OleDbCommand(Ssql, conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    RecNotFound = false;
                    reader.Read();
                    GetCurrRate = double.Parse(reader["Curr_Rate"].ToString().Trim());
                }
                reader.Close();

                if (RecNotFound)
                {
                    Ssql = "Select top 1 Curr_Rate from TblCurrRate where Curr_Code = '" + parCurr + "' And Curr_Date <= '" + parMonth + "01' order by Curr_Date Desc";
                    cmd = new OleDbCommand(Ssql, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        RecNotFound = false;
                        reader.Read();
                        GetCurrRate = double.Parse(reader["Curr_Rate"].ToString().Trim());
                    }
                    reader.Close();
                    if (RecNotFound)
                    {
                        Ssql = "Select top 1 Curr_Rate from TblCurrRate where Curr_Code = '" + parCurr + "' And Curr_Date >= '" + parMonth + "31' order by Curr_Date";
                        cmd = new OleDbCommand(Ssql, conn);
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            RecNotFound = false;
                            reader.Read();
                            GetCurrRate = double.Parse(reader["Curr_Rate"].ToString().Trim());
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return GetCurrRate;
        }
        public static bool CreUpdActivaPassivaMonthlyTrans(string parDate, string parSeq, string parTransType, string parAcctType, string parAcctCode, double parBalanceCurr, double parRate, double parBalance)
        {
            OleDbCommand cmd;
            bool FlagRecNotExist;		
		    double TmpBalanceCurr = 0;		    		    

            try
            {
                //Activa
                if (parAcctType.Trim() == "1")
                {
                    if (parTransType.Trim() == "D")
                    {
                        TmpBalanceCurr = 1 * parBalanceCurr;
                    }
                    if (parTransType.Trim() == "C")
                    {
                        TmpBalanceCurr = -1 * parBalanceCurr;
                    }

                    Ssql = "select * from TblAsset where Acct_Code = '" + parAcctCode.Trim().Substring(0, 5) + "'";
                    cmd = new OleDbCommand(Ssql, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        FlagRecNotExist = false;
                    }
                    else
                    {
                        FlagRecNotExist = true;
                    }
                    reader.Close();

                    if (FlagRecNotExist)
                    {
                        Ssql = "Insert into TblAsset values ('" + parAcctCode.Trim().Substring(0, 5) + "', " + TmpBalanceCurr + ")";
                    }
                    else
                    {
                        Ssql = "Update TblAsset set Balance = Balance + " + TmpBalanceCurr + " where Acct_Code = '" + parAcctCode.Trim().Substring(0, 5) + "'";
                    }
                    cmd = new OleDbCommand(Ssql, conn);
                    cmd.ExecuteNonQuery();
                }

                //Passiva
                if (parAcctType.Trim() == "2")
                {
                    if (parTransType.Trim() == "D")
                    {
                        TmpBalanceCurr = -1 * parBalanceCurr;
                    }
                    if (parTransType.Trim() == "C")
                    {
                        TmpBalanceCurr = 1 * parBalanceCurr;
                    }

                    Ssql = "select * from TblLiability where Acct_Code = '" + parAcctCode.Trim().Substring(0, 5) + "'";
                    cmd = new OleDbCommand(Ssql, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        FlagRecNotExist = false;
                    }
                    else
                    {
                        FlagRecNotExist = true;
                    }
                    reader.Close();

                    if (FlagRecNotExist)
                    {
                        Ssql = "Insert into TblLiability values ('" + parAcctCode.Trim().Substring(0, 5) + "', " + TmpBalanceCurr + ")";
                    }
                    else
                    {
                        Ssql = "Update TblLiability set Balance = Balance + " + TmpBalanceCurr + " where Acct_Code = '" + parAcctCode.Trim().Substring(0, 5) + "'";
                    }
                    cmd = new OleDbCommand(Ssql, conn);
                    cmd.ExecuteNonQuery();
                }

                //Income or Expense
                if (parAcctType.Trim() == "3" || parAcctType.Trim() == "4")
                {
                    //Income
                    if (parAcctType.Trim() == "3")
                    {
                        if (parTransType.Trim() == "D")
                        {
                            TmpBalanceCurr = -1 * parBalanceCurr;
                        }
                        if (parTransType.Trim() == "C")
                        {
                            TmpBalanceCurr = 1 * parBalanceCurr;
                        }
                    }

                    //Expense
                    if (parAcctType.Trim() == "4")
                    {
                        if (parTransType.Trim() == "D")
                        {
                            TmpBalanceCurr = 1 * parBalanceCurr;
                        }
                        if (parTransType.Trim() == "C")
                        {
                            TmpBalanceCurr = -1 * parBalanceCurr;
                        }
                    }

                    Ssql = "select * from TblMonthlyTrans where Trans_Month = '" + parDate.Substring(0, 6) + "' and Acct_Code = '" + parAcctCode.Trim().Substring(0, 5) + "'";
                    cmd = new OleDbCommand(Ssql, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        FlagRecNotExist = false;
                    }
                    else
                    {
                        FlagRecNotExist = true;
                    }
                    reader.Close();

                    if (FlagRecNotExist)
                    {
                        Ssql = "Insert into TblMonthlyTrans values ('" + parDate.Substring(0, 6) + "', '" + parAcctCode.Trim().Substring(0, 5) + "', " + TmpBalanceCurr + ")";
                    }
                    else
                    {
                        Ssql = "Update TblMonthlyTrans set Balance = Balance + " + TmpBalanceCurr + " where Trans_Month = '" + parDate.Substring(0, 6) + "' and Acct_Code = '" + parAcctCode.Trim().Substring(0, 5) + "'";
                    }
                    cmd = new OleDbCommand(Ssql, conn);
                    cmd.ExecuteNonQuery();
                }

                //Daily Transaction
                Ssql = "Insert into TblDailyTrans values ('" + parDate + "', '" + parSeq + "', '" + parTransType + "', '" + parAcctCode.Trim().Substring(0, 5) + "', " + parBalanceCurr + ", " + parRate + ", " + parBalance + ")";
                cmd = new OleDbCommand(Ssql, conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        public static bool DelActivaPassivaMonthlyTrans(string parDate, string parSeq)
        {
            OleDbCommand cmd;
            OleDbCommand cmd2;
            bool FlagRecNotExist;
            string TmpAcctType;
            string TmpTransType;
            string TmpAcctCode;
            double TmpBalanceCurr = 0;
            bool DeleteMonthlyTrans;

            try
            {
                Ssql = "Select * from TblDailyTrans where Trans_Date = '" + parDate + "' and Trans_Seq = '" + parSeq + "'";
                cmd = new OleDbCommand(Ssql, conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TmpAcctCode = reader["Acct_Code"].ToString().Trim();
                        TmpAcctType = GetAcctType(TmpAcctCode);
                        TmpTransType = reader["Trans_Type"].ToString().Trim();
                        TmpAcctCode = reader["Acct_Code"].ToString().Trim();

                        //Activa
                        if (TmpAcctType.Trim() == "1")
                        {
                            if (TmpTransType.Trim() == "D")
                            {
                                TmpBalanceCurr = -1 * double.Parse(reader["Balance_Curr"].ToString().Trim());
                            }
                            if (TmpTransType.Trim() == "C")
                            {
                                TmpBalanceCurr = 1 * double.Parse(reader["Balance_Curr"].ToString().Trim());
                            }

                            Ssql = "Select * from TblAsset where Acct_Code = '" + TmpAcctCode.Trim().Substring(0, 5) + "'";
                            cmd2 = new OleDbCommand(Ssql, conn);
                            reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                FlagRecNotExist = false;
                            }
                            else
                            {
                                FlagRecNotExist = true;
                            }
                            reader2.Close();

                            if (FlagRecNotExist)
                            {
                                Ssql = "Insert into TblAsset values ('" + TmpAcctCode.Trim().Substring(0, 5) + "', " + TmpBalanceCurr + ")";
                            }
                            else
                            {
                                Ssql = "Update TblAsset set Balance = Balance + " + TmpBalanceCurr + " where Acct_Code = '" + TmpAcctCode.Trim().Substring(0, 5) + "'";
                            }
                            cmd2 = new OleDbCommand(Ssql, conn);
                            cmd2.ExecuteNonQuery();
                        }

                        //Passiva
                        if (TmpAcctType.Trim() == "2")
                        {
                            if (TmpTransType.Trim() == "D")
                            {
                                TmpBalanceCurr = 1 * double.Parse(reader["Balance_Curr"].ToString().Trim());
                            }
                            if (TmpTransType.Trim() == "C")
                            {
                                TmpBalanceCurr = -1 * double.Parse(reader["Balance_Curr"].ToString().Trim());
                            }

                            Ssql = "Select * from TblLiability where Acct_Code = '" + TmpAcctCode.Trim().Substring(0, 5) + "'";
                            cmd2 = new OleDbCommand(Ssql, conn);
                            reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                FlagRecNotExist = false;
                            }
                            else
                            {
                                FlagRecNotExist = true;
                            }
                            reader2.Close();

                            if (FlagRecNotExist)
                            {
                                Ssql = "Insert into TblLiability values ('" + TmpAcctCode.Trim().Substring(0, 5) + "', " + TmpBalanceCurr + ")";
                            }
                            else
                            {
                                Ssql = "Update TblLiability set Balance = Balance + " + TmpBalanceCurr + " where Acct_Code = '" + TmpAcctCode.Trim().Substring(0, 5) + "'";
                            }
                            cmd2 = new OleDbCommand(Ssql, conn);
                            cmd2.ExecuteNonQuery();
                        }

                        //Income or Expense
                        if (TmpAcctType.Trim() == "3" || TmpAcctType.Trim() == "4")
                        {
                            //Income
                            if (TmpAcctType.Trim() == "3")
                            {
                                if (TmpTransType.Trim() == "D")
                                {
                                    TmpBalanceCurr = 1 * double.Parse(reader["Balance_Curr"].ToString().Trim());
                                }
                                if (TmpTransType.Trim() == "C")
                                {
                                    TmpBalanceCurr = -1 * double.Parse(reader["Balance_Curr"].ToString().Trim());
                                }
                            }

                            //Expense
                            if (TmpAcctType.Trim() == "4")
                            {
                                if (TmpTransType.Trim() == "D")
                                {
                                    TmpBalanceCurr = -1 * double.Parse(reader["Balance_Curr"].ToString().Trim());
                                }
                                if (TmpTransType.Trim() == "C")
                                {
                                    TmpBalanceCurr = 1 * double.Parse(reader["Balance_Curr"].ToString().Trim());
                                }
                            }

                            Ssql = "Select * from TblMonthlyTrans where Trans_Month = '" + parDate.Trim().Substring(0, 6) + "' and Acct_Code = '" + TmpAcctCode.Trim().Substring(0, 5) + "'";
                            cmd2 = new OleDbCommand(Ssql, conn);
                            reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                FlagRecNotExist = false;
                            }
                            else
                            {
                                FlagRecNotExist = true;
                            }
                            reader2.Close();

                            if (FlagRecNotExist)
                            {
                                Ssql = "Insert into TblMonthlyTrans values ('" + parDate.Trim().Substring(0, 6) + "', '" + TmpAcctCode.Trim().Substring(0, 5) + "', " + TmpBalanceCurr + ")";
                            }
                            else
                            {
                                Ssql = "Update TblMonthlyTrans set Balance = Balance + " + TmpBalanceCurr + " where Trans_Month = '" + parDate.Trim().Substring(0, 6) + "' and Acct_Code = '" + TmpAcctCode.Trim().Substring(0, 5) + "'";
                            }
                            cmd2 = new OleDbCommand(Ssql, conn);
                            cmd2.ExecuteNonQuery();

                            DeleteMonthlyTrans = false;
                            Ssql = "Select * from TblMonthlyTrans where Trans_Month = '" + parDate.Trim().Substring(0, 6) + "' and Acct_Code = '" + TmpAcctCode.Trim().Substring(0, 5) + "'";
                            cmd2 = new OleDbCommand(Ssql, conn);
                            reader2 = cmd2.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Read();
                                if (double.Parse(reader2["Balance"].ToString().Trim()) == 0)
                                {
                                    DeleteMonthlyTrans = true;
                                }
                            }
                            reader2.Close();

                            if (DeleteMonthlyTrans)
                            {
                                Ssql = "Delete from TblMonthlyTrans where Trans_Month = '" + parDate.Trim().Substring(0, 6) + "' and Acct_Code = '" + TmpAcctCode.Trim().Substring(0, 5) + "'";
                                cmd2 = new OleDbCommand(Ssql, conn);
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                }
                reader.Close();

                //Daily Transaction
                Ssql = "Delete from TblDailyTrans where Trans_Date = '" + parDate + "' and Trans_Seq = '" + parSeq + "'";
                cmd = new OleDbCommand(Ssql, conn);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
    }
}
