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
    public partial class Property_Summary : Form
    {
        //What one property's purchase looks like once it has been read. Held together rather
        //than passed around as a dozen doubles, because the sale's profit needs most of them
        //back again.
        private class Purchase
        {
            public string PurchaseDate;
            public string SettlementDate;
            public double Percentage;
            public double Price;
            public double StampDuty;
            public double Conveyancing;
            public double BuyersAgent;
            public double OtherCost;        //inspection + settlement + other, added up
            public double DownPayment;
            public double InitialLoan;

            //What the purchase cost on top of the price itself.
            public double TotalCost
            {
                get { return StampDuty + Conveyancing + BuyersAgent + OtherCost; }
            }
        }

        private class Sale
        {
            public string SoldDate;
            public string SettlementDate;
            public double Price;
            public double Conveyancing;
            public double AgentCost;
            public double OtherCost;        //settlement + other, added up

            //What selling cost, the price it fetched aside.
            public double TotalCost
            {
                get { return Conveyancing + AgentCost + OtherCost; }
            }
        }

        //Guards the dropdown while it is being populated, so adding the items does not run the
        //whole summary once per item.
        bool Filling;

        //index-aligned with CmbPropertyId: the name behind each id, so the label beside the
        //dropdown does not need a query every time the choice changes
        List<string> PropertyNames = new List<string>();

        const string Property_Fields = "[Name], [Address], [Suburb], [State], [Post_Code]";

        const string Purchase_Fields = "[Purchase_Date], [Settlement_Date], [Purchase_Price],"
                            + " [Stamp_Duty], [Conveyancing_Cost],"
                            + " [Building_Pest_Inspection_Cost], [Buyers_Agent_Cost],"
                            + " [Settlement_Cost], [Other_Cost], [Down_Payment],"
                            + " [Initial_Loan], [Percentage_Ownership]";

        const string Sale_Fields = "[Sold_Date], [Settlement_Date], [Sold_Price],"
                            + " [Conveyancing_Cost], [Sale_Agent_Cost],"
                            + " [Settlement_Cost], [Other_Cost]";

        public Property_Summary()
        {
            InitializeComponent();
        }

        private void Property_Summary_Load(object sender, EventArgs e)
        {
            Filling = true;
            Fill_Property();
            Filling = false;

            Clear_Details();
            Show_Summary();
        }

        //---- the dropdown -----------------------------------------------------------

        private void Fill_Property()
        {
            try
            {
                CmbPropertyId.Items.Clear();
                PropertyNames.Clear();
                CmbPropertyId.Items.Add("");
                PropertyNames.Add("");

                Mdl1.Ssql = "select [Property_Id], [Name] from TblProperty order by [Property_Id]";
                OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CmbPropertyId.Items.Add(Read_Text(reader["Property_Id"]));
                    PropertyNames.Add(Read_Text(reader["Name"]));
                }
                reader.Close();

                //Straight to the first property, so the page opens with something on it
                //rather than an empty form. The blank stays at the top of the list for a
                //deliberate nothing-selected, and is all there is to pick when no property
                //has been set up yet.
                CmbPropertyId.SelectedIndex = (CmbPropertyId.Items.Count > 1 ? 1 : 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        //The name beside the dropdown, so an id on its own never has to be recognised. Taken
        //from the list filled above rather than looked up again.
        private void Show_Property_Name()
        {
            int TmpAt = CmbPropertyId.SelectedIndex;
            LblPropertyName.Text = (TmpAt >= 0 && TmpAt < PropertyNames.Count
                                    ? PropertyNames[TmpAt] : "");
        }

        private void CmbPropertyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Filling)
            {
                return;
            }
            Show_Summary();
        }

        //---- reading what comes back ------------------------------------------------

        private string Read_Text(object parValue)
        {
            return (parValue == null || parValue == DBNull.Value ? "" : parValue.ToString().Trim());
        }

        private double Read_Number(object parValue)
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

        //---- formatting -------------------------------------------------------------

        //Every amount on this page is in dollars, so the sign is not conditional the way it is
        //on the multi-currency pages. FormatAmt already groups thousands and shows two places.
        private string Money(double parValue)
        {
            if (parValue < 0)
            {
                return "-$" + Mdl1.FormatAmt(Math.Abs(parValue));
            }
            return "$" + Mdl1.FormatAmt(parValue);
        }

        //A share of a property, not an amount - so two places and a per-cent sign rather
        //than a dollar one. The same shape as Percent() on Property Purchase.
        private string Percent(double parValue)
        {
            return Math.Round(parValue, 2).ToString("#,##0.00", CultureInfo.InvariantCulture) + " %";
        }

        private string Long_Date(string parYyyyMMdd)
        {
            string TmpText = (parYyyyMMdd == null ? "" : parYyyyMMdd.Trim());
            if (TmpText.Length != 8)
            {
                return "";
            }
            DateTime TmpDate;
            if (!DateTime.TryParseExact(TmpText, "yyyyMMdd", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out TmpDate))
            {
                return "";
            }
            return TmpDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
        }

        //A loss in red, a gain in green; breaking even is left alone
        private void Colour_Label(Label parLabel, double parValue)
        {
            if (parValue < 0)
            {
                parLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (parValue > 0)
            {
                parLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                parLabel.ForeColor = System.Drawing.Color.Black;
            }
        }

        //---- the page ---------------------------------------------------------------

        //The sale half is only meaningful once the property has been sold, so it is shown and
        //hidden as a block rather than left standing empty.
        private void Show_Sale_Block(bool parVisible)
        {
            Label[] TmpLabels = new Label[] {
                LblSaleHeader,
                Lbl_LblSoldDate, LblSoldDate,
                Lbl_LblSaleSettlementDate, LblSaleSettlementDate,
                Lbl_LblSoldPrice, LblSoldPrice,
                Lbl_LblSaleConveyancing, LblSaleConveyancing,
                Lbl_LblSaleAgentCost, LblSaleAgentCost,
                Lbl_LblSaleOtherCost, LblSaleOtherCost,
                Lbl_LblTotalSaleCost, LblTotalSaleCost,
                Lbl_LblProfitLoss, LblProfitLoss,
                Lbl_LblPctProfitLoss, LblPctProfitLoss };
            foreach (Label TmpLabel in TmpLabels)
            {
                TmpLabel.Visible = parVisible;
            }
        }

        private void Clear_Purchase()
        {
            LblPurchaseDate.Text = "";
            LblPurchaseSettlementDate.Text = "";
            LblPctOwnership.Text = "";
            LblPurchasePrice.Text = "";
            LblStampDuty.Text = "";
            LblPurchaseConveyancing.Text = "";
            LblBACost.Text = "";
            LblPurchaseOtherCost.Text = "";
            LblTotalPurchaseCost.Text = "";
            LblDownPayment.Text = "";
            LblInitialLoan.Text = "";
        }

        private void Clear_Details()
        {
            LblNote.Text = "";
            LblNote.ForeColor = System.Drawing.Color.Black;
            LblName.Text = "";
            LblAddress.Text = "";
            Clear_Purchase();
            Show_Sale_Block(false);
        }

        private void Show_Summary()
        {
            try
            {
                Show_Property_Name();
                Clear_Details();

                int TmpId;
                if (!int.TryParse(CmbPropertyId.Text.Trim(), NumberStyles.Integer,
                                  CultureInfo.InvariantCulture, out TmpId))
                {
                    //nothing picked yet - the blank first item
                    return;
                }

                if (!Show_Property(TmpId))
                {
                    Note("Property " + TmpId.ToString(CultureInfo.InvariantCulture)
                         + " is no longer in the property list.", true);
                    return;
                }

                Purchase TmpPurchase = Get_Purchase(TmpId);
                if (TmpPurchase != null)
                {
                    Show_Purchase(TmpPurchase);
                }
                else
                {
                    Note("No purchase record for this property.", true);
                }

                Sale TmpSale = Get_Sale(TmpId);
                if (TmpSale == null)
                {
                    //not sold, so the sale half stays out of the way
                    return;
                }

                Show_Sale(TmpSale, TmpPurchase);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Note(string parText, bool parWarn)
        {
            LblNote.Text = parText;
            LblNote.ForeColor = (parWarn ? System.Drawing.Color.Red : System.Drawing.Color.Black);
        }

        //The name and the address, which are the property's own rather than the purchase's.
        //The address is the four parts run together, with any missing part left out so the
        //spacing does not go ragged.
        private bool Show_Property(int parId)
        {
            Mdl1.Ssql = "select " + Property_Fields + " from TblProperty"
                      + " where [Property_Id] = " + parId.ToString(CultureInfo.InvariantCulture);
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                return false;
            }

            LblName.Text = Read_Text(reader["Name"]);

            string[] TmpParts = new string[] { Read_Text(reader["Address"]),
                                               Read_Text(reader["Suburb"]),
                                               Read_Text(reader["State"]),
                                               Read_Text(reader["Post_Code"]) };
            reader.Close();

            List<string> TmpKept = new List<string>();
            foreach (string TmpPart in TmpParts)
            {
                if (TmpPart != "")
                {
                    TmpKept.Add(TmpPart);
                }
            }
            LblAddress.Text = string.Join(" ", TmpKept.ToArray());
            return true;
        }

        //One purchase per property, so the id is enough to find it. Null when the property has
        //been set up but not yet bought.
        private Purchase Get_Purchase(int parId)
        {
            Mdl1.Ssql = "select " + Purchase_Fields + " from TblPropertyPurchase"
                      + " where [Property_Id] = " + parId.ToString(CultureInfo.InvariantCulture);
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                return null;
            }

            Purchase TmpPurchase = new Purchase();
            TmpPurchase.PurchaseDate = Read_Text(reader["Purchase_Date"]);
            TmpPurchase.SettlementDate = Read_Text(reader["Settlement_Date"]);
            TmpPurchase.Percentage = Read_Number(reader["Percentage_Ownership"]);
            TmpPurchase.Price = Read_Number(reader["Purchase_Price"]);
            TmpPurchase.StampDuty = Read_Number(reader["Stamp_Duty"]);
            TmpPurchase.Conveyancing = Read_Number(reader["Conveyancing_Cost"]);
            TmpPurchase.BuyersAgent = Read_Number(reader["Buyers_Agent_Cost"]);
            //the three small ones are only ever shown added together
            TmpPurchase.OtherCost = Read_Number(reader["Building_Pest_Inspection_Cost"])
                                  + Read_Number(reader["Settlement_Cost"])
                                  + Read_Number(reader["Other_Cost"]);
            TmpPurchase.DownPayment = Read_Number(reader["Down_Payment"]);
            TmpPurchase.InitialLoan = Read_Number(reader["Initial_Loan"]);
            reader.Close();
            return TmpPurchase;
        }

        private Sale Get_Sale(int parId)
        {
            Mdl1.Ssql = "select " + Sale_Fields + " from TblPropertySale"
                      + " where [Property_Id] = " + parId.ToString(CultureInfo.InvariantCulture);
            OleDbCommand cmd = new OleDbCommand(Mdl1.Ssql, Mdl1.conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                return null;
            }

            Sale TmpSale = new Sale();
            TmpSale.SoldDate = Read_Text(reader["Sold_Date"]);
            TmpSale.SettlementDate = Read_Text(reader["Settlement_Date"]);
            TmpSale.Price = Read_Number(reader["Sold_Price"]);
            TmpSale.Conveyancing = Read_Number(reader["Conveyancing_Cost"]);
            TmpSale.AgentCost = Read_Number(reader["Sale_Agent_Cost"]);
            TmpSale.OtherCost = Read_Number(reader["Settlement_Cost"])
                              + Read_Number(reader["Other_Cost"]);
            reader.Close();
            return TmpSale;
        }

        private void Show_Purchase(Purchase parPurchase)
        {
            LblPurchaseDate.Text = Long_Date(parPurchase.PurchaseDate);
            LblPurchaseSettlementDate.Text = Long_Date(parPurchase.SettlementDate);
            LblPctOwnership.Text = Percent(parPurchase.Percentage);
            LblPurchasePrice.Text = Money(parPurchase.Price);
            LblStampDuty.Text = Money(parPurchase.StampDuty);
            LblPurchaseConveyancing.Text = Money(parPurchase.Conveyancing);
            LblBACost.Text = Money(parPurchase.BuyersAgent);
            LblPurchaseOtherCost.Text = Money(parPurchase.OtherCost);
            LblTotalPurchaseCost.Text = Money(parPurchase.TotalCost);
            LblDownPayment.Text = Money(parPurchase.DownPayment);
            LblInitialLoan.Text = Money(parPurchase.InitialLoan);
        }

        //The profit is what the sale brought in less what getting out of it cost and less what
        //getting into it cost, so it needs the purchase as well. Without a purchase record
        //there is nothing to subtract and a figure would only mislead, so it is left blank.
        private void Show_Sale(Sale parSale, Purchase parPurchase)
        {
            Show_Sale_Block(true);

            LblSoldDate.Text = Long_Date(parSale.SoldDate);
            LblSaleSettlementDate.Text = Long_Date(parSale.SettlementDate);
            LblSoldPrice.Text = Money(parSale.Price);
            LblSaleConveyancing.Text = Money(parSale.Conveyancing);
            LblSaleAgentCost.Text = Money(parSale.AgentCost);
            LblSaleOtherCost.Text = Money(parSale.OtherCost);
            LblTotalSaleCost.Text = Money(parSale.TotalCost);

            if (parPurchase == null)
            {
                LblProfitLoss.Text = "-";
                LblProfitLoss.ForeColor = System.Drawing.Color.Black;
                LblPctProfitLoss.Text = "-";
                LblPctProfitLoss.ForeColor = System.Drawing.Color.Black;
                Note("No purchase record for this property, so the profit-loss cannot be worked out.",
                     true);
                return;
            }

            double TmpProfit = parSale.Price
                             - parSale.TotalCost
                             - parPurchase.Price
                             - parPurchase.TotalCost;
            LblProfitLoss.Text = Money(TmpProfit);
            Colour_Label(LblProfitLoss, TmpProfit);

            //Against the price paid for the property rather than the whole outlay, so it
            //reads as the return on the purchase itself. Nothing can be divided by a
            //purchase price of zero, so that case is shown as flat.
            double TmpPercent = 0;
            if (parPurchase.Price > 0)
            {
                TmpPercent = (TmpProfit / parPurchase.Price) * 100;
            }
            LblPctProfitLoss.Text = Percent(TmpPercent);
            Colour_Label(LblPctProfitLoss, TmpPercent);
        }

        private void CmdBack_Click(object sender, EventArgs e)
        {
            Main_Form Main_Form = new Main_Form();
            Main_Form.Show();
            this.Close();
        }
    }
}
