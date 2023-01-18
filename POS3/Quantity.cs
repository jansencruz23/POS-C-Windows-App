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
using POS3.Helpers;
using MySql.Data.MySqlClient;


namespace POS3
{
    public partial class Quantity : Form
    {
        btnProduct prod = new btnProduct();
        public string itemidq;
        public string itemnameq;
        public string itempriceq;
        public string itemstockq;
        private int quantt;
        private int ttttt;
        private string nema, stck;

        myDBConnection conn = new myDBConnection();
        public Quantity()
        {
            InitializeComponent();
            
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (txtquantity.Text == "")
            {
                MessageBox.Show("Enter a valid quantity");
            }
            else if (txtquantity.Text == "0")
            {
                this.Hide();
            }
            else if (Convert.ToInt32(stck) == Convert.ToInt32(txtquantity.Text))
            {
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }
            else if(Convert.ToInt32(stck) < Convert.ToInt32(txtquantity.Text))
            {
                MessageBox.Show("Not enough stocks");
                //MessageBox.Show(stck + "asd" + ttttt.ToString());
            }

            else
            {
                //MessageBox.Show(stck + "asd" + ttttt.ToString());
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }


        }
        private void btn2Quantity_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stck) == 3)
            {
                txtquantity.Text = "3";
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }
            else if(Convert.ToInt32(stck) < 4 )
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                txtquantity.Text = "3";
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }


        }

        public void setQuantity(string itemid, string itemname, string itemprice)
        {
            itemidq = itemid;
            itemnameq = itemname;
            itempriceq = itemprice;
            
            int quantity = Convert.ToInt32(txtquantity.Text);
            MainPOS.getItems(itemid, itemname, itemprice, quantity);
            
        }

        private void btn1Quantity_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stck) == 2)
            {
                txtquantity.Text = "2";
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }
            else if (Convert.ToInt32(stck) < 3)
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                txtquantity.Text = "2";
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }
            
        }

        private void btn5Quantity_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stck) == 5)
            {
                txtquantity.Text = "5";
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }
            else if (Convert.ToInt32(stck) < 6)
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                txtquantity.Text = "5";
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }

        }

        private void btn10Quantity_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stck) == 10)
            {
                txtquantity.Text = "10";
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }
            else if (Convert.ToInt32(stck) < 11)
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                txtquantity.Text = "10";
                quantt = Convert.ToInt32(txtquantity.Text);
                setQuantity(itemidq, itemnameq, itempriceq);
                this.Hide();
            }

        }

        

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            // only allow one decimal point

            if (e.KeyChar == 22)
                e.Handled = true;
        }

        private void txtquantity_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == 22)
                e.Handled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtquantity.Text == "")
            {
                txtquantity.Text = "0";
            }
            if (Convert.ToInt32(txtquantity.Text) <= 0) return;
            if(txtquantity.Text == "1")
            {
                txtquantity.Text = "0";
                quantt = 0;

                return;
            }
            else
            {
                quantt--;
                txtquantity.Text = quantt.ToString();
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(txtquantity.Text == "")
            {
                txtquantity.Text = "1";
            }
            else
            {
                int q = Convert.ToInt32(txtquantity.Text);
                q++;
                txtquantity.Text = q.ToString();
                quantt = q;
            }
            
        }

        private void Quantity_Load(object sender, EventArgs e)
        {
            txtquantity.Text = "1";

            conn.Connect();
            conn.cn.Open();

            ttttt = Convert.ToInt32(txtquantity.Text) + 1;

            MySqlCommand cmd = new MySqlCommand("SELECT Name, Stock FROM tbl_items WHERE Name = '" + itemnameq + "' ", conn.cn);
            MySqlDataAdapter da = new MySqlDataAdapter();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //data2txt.Text += $"{reader.GetString("Name")};";
                nema = ($"{reader.GetString("Name")}");
                stck = $"{reader.GetString("Stock")}";
               
            }
        }

        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Quantity_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            txtquantity.Text = "0";
            quantt = 0;
            this.Hide();
        }

        private void txtquantity_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 22)
                e.Handled = true;
        }
    }
}
