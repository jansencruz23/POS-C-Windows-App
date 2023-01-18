using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS3.CustomControls;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using POS3.Helpers;


namespace POS3
{
    public partial class Payment : Form
    {
        private double Amount;
        public static FlowLayoutPanel payPanel = new FlowLayoutPanel();
        public double change;
        public static List<String> items = new List<String>();
        public static string id, name, price, pic, category, picked, stock;
        private int newStock;
        private string namee;
        private int quantity;

        myDBConnection conn = new myDBConnection();
        MySqlCommand cmd;
        MySqlDataReader reader;


        DbHelper db = new DbHelper();
        public string CashPay
        {
            get { return txtAmount.Text; }
            set { txtAmount.Text = value; }
        }
        public Payment()
        {
            InitializeComponent();
            payPanel.Dock = DockStyle.Fill;
            payPanel.FlowDirection = FlowDirection.LeftToRight;

            payPanel.AutoScroll = true;
            PayPanelContainer.Controls.Add(payPanel);
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            lblTotalPricePay.Text = "" + MainPOS.value;
            foreach (Control ctr in MainPOS.itemsPanel.Controls)
            {
                PayCart payCart = new PayCart();
                if (ctr.Name == "CartItem")
                {
                    namee = (((CartItem)ctr).ItemNamex);
                    quantity = (((CartItem)ctr).ItemQuantity);

                    lblitem.Text += "\n" + (((CartItem)ctr).ItemNamex);
                    //payCart.PayItemName += (((CartItem)ctr).ItemNamex);
                    lblQuantity.Text += "\n" + (((CartItem)ctr).ItemQuantity);
                    lblPricePerItem.Text += "\n@" + (((CartItem)ctr).ItemPerUnitPrice);
                    lblTotalPrice.Text += "\n" + (((CartItem)ctr).ItemPricex);

                    payPanel.Controls.Add(payCart);

                    getInfo2();
                }
            }
        }

        private void getInfo2()
        {
            string stck, nema;
            conn.Connect();
            conn.cn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT Name, Stock FROM tbl_items WHERE Name = '" + namee + "' ", conn.cn);
                MySqlDataAdapter da = new MySqlDataAdapter();

                MySqlDataReader reader = cmd.ExecuteReader();
            conn.Connect();
            conn.cn.Open();
            while (reader.Read())
                {

                //data2txt.Text += $"{reader.GetString("Name")};";
                nema = ($"{reader.GetString("Name")}");
                    stck = $"{reader.GetString("Stock")}";

                    newStock = Convert.ToInt32(stck) - quantity;
                conn.cn.Close();
                conn.Connect();
                conn.cn.Open();
                cmd = new MySqlCommand("UPDATE tbl_items SET Stock = '" + newStock + "' WHERE Name = '" + nema + "' ", conn.cn);
                cmd.ExecuteNonQuery();

                //MessageBox.Show(nema + newStock.ToString());
                }





            conn.cn.Close();
            conn.Connect();
            conn.cn.Open();




        }

        private void PayNa()
        {
            string stck, nema;
            conn.Connect();
            conn.cn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT Name, Stock FROM tbl_items WHERE Name = '" + namee + "' ", conn.cn);
            MySqlDataAdapter da = new MySqlDataAdapter();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //data2txt.Text += $"{reader.GetString("Name")};";
                nema = ($"{reader.GetString("Name")}");
                stck = $"{reader.GetString("Stock")}";

                newStock = Convert.ToInt32(stck) - quantity;

                //MessageBox.Show(nema + newStock.ToString());
            }





            conn.cn.Close();
            conn.Connect();
            conn.cn.Open();





        }

        private void getInfo()
        {
            string stck;
            conn.Connect(); 
            conn.cn.Open();
            foreach (Control ctr in MainPOS.itemsPanel.Controls)
            {
                PayCart payCart = new PayCart();
                if (ctr.Name == "CartItem")
                {

                }
                MySqlCommand cmd = new MySqlCommand("SELECT Name, Stock FROM tbl_items WHERE Name = '" + (((CartItem)ctr).ItemNamex) + "' ", conn.cn);
                MySqlDataAdapter da = new MySqlDataAdapter();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //data2txt.Text += $"{reader.GetString("Name")};";
                   // MessageBox.Show($"{reader.GetString("Name")}");
                    stck = $"{reader.GetString("Stock")}";

                    newStock = Convert.ToInt32(stck) - (((CartItem)ctr).ItemQuantity);

                   //MessageBox.Show((((CartItem)ctr).ItemNamex) + newStock.ToString());
                }

                
                


                conn.cn.Close();
                conn.Connect();
                conn.cn.Open();
            }




        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(txtAmount.Text == "")
            {
                MessageBox.Show("Please enter a valid amount", "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                Amount = Convert.ToDouble(txtAmount.Text);
                if (Amount >= MainPOS.value)
                {
                    change = Amount - MainPOS.value;

                    
                    /*string updateItem;
                    foreach (Control ctr in MainPOS.itemsPanel.Controls)
                    {
                        PayCart payCart = new PayCart();
                        if (ctr.Name == "CartItem")
                        {

                        }
                    }

                    foreach (String item in items)
                    {

                        cmd = new MySqlCommand("UPDATE tbl_items SET Stock = '" + newStock + "' WHERE Name = '" + item + "' ", conn.cn);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(item + "" + newStock);
                        
                    }
                    items.Clear();*/

                    //getInfo2();

                    if (cbReceipt.Checked == true)
                    {
                        MinusStock();
                        InsertData();
                        new frmReceipt(txtAmount.Text, change.ToString()).ShowDialog();
                        this.Hide();
                        MainPOS.ClearCart();

                    }
                    else
                    {
                        InsertData();
                        MessageBox.Show("Payment Successful! \nChange : ₱ " + change, "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        new MainPOS(MainPOS.username).Show();
                        MainPOS.ClearCart();
                    }
                }
                else
                {
                    MessageBox.Show("Insufficient Amount");
                }
                
            }
        }

        private void InsertData()
        {
            string addItem = "INSERT INTO tbl_record VALUES('" + lblID.Text + "', '" + DbHelper.name + "','" + lblitem.Text.Replace("Product", "").Trim() + "', '" + lblQuantity.Text.Replace("Qty", "").Trim() + "', '" + lblPricePerItem.Text.Replace("Price", "").Trim() + "', '" + lblTotalPrice.Text.Replace("Total Price", "").Trim() + "', '" + lblTotalPricePay.Text + "', '" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString() + "' )";
            cmd = new MySqlCommand(addItem, conn.cn);
            cmd.ExecuteNonQuery();
            conn.cn.Close();

            //MessageBox.Show("Item added successfully", "Add Item Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GetID()
        {
            conn.Connect();
            conn.cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_record", conn.cn);

            if (lblID.Text == "")
            {
                lblID.Text = "1";
            }

            using (MySqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    int itemID = Convert.ToInt32((read[0]));
                    itemID++;
                    lblID.Text = itemID.ToString();
                }
            }
            conn.cn.Close();
        }

        private void MinusStock()
        {
            /*btnProduct btn = new btnProduct();
                int newStock = Convert.ToInt32(btn.ItemStock) - Convert.ToInt32(lblQuantity.Text);
                conn.cn.Open();
                string updateItem = "UPDATE tbl_items SET Stock = '" + newStock + "' WHERE Name = '" + lblitem.Text + "' ";
                cmd = new MySqlCommand(updateItem, conn.cn);
                cmd.ExecuteNonQuery();
                conn.cn.Close();

                MessageBox.Show("napalitan na ata sheesh");*/

        }

        private void Payment_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as Guna2TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 22)
                e.Handled = true;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SetNumber(1);
            
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            SetNumber(2);

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            SetNumber(3);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            SetNumber(4);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SetNumber(5);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            SetNumber(6);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SetNumber(7);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SetNumber(8);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SetNumber(9);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text.Length <= 5)
            {
                txtAmount.Text += "00"; ;
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            SetNumber(0);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text.Length <= 5)
            {
                if (txtAmount.Text.Contains("."))
                {
                    txtAmount.Text.Replace(".", "");
                }
                else
                {
                    txtAmount.Text += ".";
                }
            } 
        }

        private void btnBS_Click(object sender, EventArgs e)
        {
            if (txtAmount.TextLength != 0)
            {
                txtAmount.Text = txtAmount.Text.Remove(txtAmount.Text.Length - 1, 1);
            }
        }

        private void SetNumber(int number)
        {
            if (txtAmount.Text.Length <= 5)
            {
                txtAmount.Text += number.ToString(); ;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPOS.ClearCart();
            new MainPOS(MainPOS.username).Show();
        }

        

    }
}
