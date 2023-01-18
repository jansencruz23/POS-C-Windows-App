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
using POS3.Helpers;
using MySql.Data.MySqlClient;

namespace POS3
{
    public partial class EditQuantity : Form
    {
        public string itemideq;
        public string itemnameeq;
        public string itempriceeq;
        public string itemquantityeq;
        private int quantt;

        private int ttttt;
        private string nema, stck;

        myDBConnection conn = new myDBConnection();
        public EditQuantity()
        {
            InitializeComponent();
        }

        private void btnEditQuantity_Click(object sender, EventArgs e)
        {
            if (txtEditQuantity.Text == "")
            {
                MessageBox.Show("Enter a valid quantity");
            }
            else if (txtEditQuantity.Text == "0")
            {
                DbHelper db = new DbHelper();
                int unpicked = 0;
                db.PickedItem("UPDATE tbl_items SET Checked = '" + unpicked + "' WHERE ID = '" + itemideq + "'");
                MainPOS.GetPrice();
                this.Hide();
            }
            else if (Convert.ToInt32(stck) == Convert.ToInt32(txtEditQuantity.Text))
            {
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);
                this.Hide();
            }
            else if (Convert.ToInt32(stck) < Convert.ToInt32(txtEditQuantity.Text))
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);
                
                this.Hide();

            }
        }

        public void editQuantity2(string itemid, string itemname, string itemprice)
        {
            itemideq = itemid;
            itemnameeq = itemname;
            itempriceeq = itemprice;

            string quantityeq = txtEditQuantity.Text;
            MainPOS.changeQuantity(itemid, itemname, itemprice, quantityeq);
            
        }

        private void btn2Quantity_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stck) == 3)
            {
                txtEditQuantity.Text = "3";
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);
                this.Hide();
            }
            else if (Convert.ToInt32(stck) < 4)
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                txtEditQuantity.Text = "3";
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);

                this.Hide();
            }

        }

        private void EditQuantity_Load(object sender, EventArgs e)
        {
            txtEditQuantity.Text = itemquantityeq;

            conn.Connect();
            conn.cn.Open();

            ttttt = Convert.ToInt32(txtEditQuantity.Text) + 1;

            MySqlCommand cmd = new MySqlCommand("SELECT Name, Stock FROM tbl_items WHERE Name = '" + itemnameeq + "' ", conn.cn);
            MySqlDataAdapter da = new MySqlDataAdapter();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //data2txt.Text += $"{reader.GetString("Name")};";
                nema = ($"{reader.GetString("Name")}");
                stck = $"{reader.GetString("Stock")}";
                //MessageBox.Show(stck + "asd" + ttttt.ToString()) ;
            }
        }

        private void btn1Quantity_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stck) == 2)
            {
                txtEditQuantity.Text = "2";
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);
                this.Hide();
            }
            else if (Convert.ToInt32(stck) < 3)
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                txtEditQuantity.Text = "2";
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);

                this.Hide();
            }

        }

        private void btn5Quantity_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stck) == 5)
            {
                txtEditQuantity.Text = "5";
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);
                this.Hide();
            }
            else if (Convert.ToInt32(stck) < 6)
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                txtEditQuantity.Text = "5";
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);

                this.Hide();
            }

        }

        private void btn10Quantity_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(stck) == 10)
            {
                txtEditQuantity.Text = "10";
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);
                this.Hide();
            }
            else if (Convert.ToInt32(stck) < 11)
            {
                MessageBox.Show("Not enough stocks");
            }
            else
            {
                txtEditQuantity.Text = "10";
                quantt = Convert.ToInt32(txtEditQuantity.Text);
                editQuantity2(itemideq, itemnameeq, itempriceeq);

                this.Hide();
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtEditQuantity.Text == "")
            {
                txtEditQuantity.Text = "0";
            }
            if (Convert.ToInt32(txtEditQuantity.Text) <= 0) return;
            if (txtEditQuantity.Text == "1")
            {
                txtEditQuantity.Text = "0";
                quantt = 0;

                return;
            }
            else
            {
                int q = Convert.ToInt32(txtEditQuantity.Text);
                q--;
                quantt = q;
                txtEditQuantity.Text = quantt.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtEditQuantity.Text == "")
            {
                txtEditQuantity.Text = "1";
            }
            else
            {
                int q = Convert.ToInt32(txtEditQuantity.Text);
                q++;
                txtEditQuantity.Text = q.ToString();
                quantt = q;
            }
        }

        private void txtEditQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
