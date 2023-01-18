using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS3.Helpers;
using POS3.CustomControls;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace POS3
{
    public partial class MainPOS : Form
    {
        public string itemID, itemName, itemPrice;
        public static double value;
        public static int userID;
        public static string username;
        public static string namee;

        DbHelper db;
        public static Label lblTotalPrice = new Label();
        public static FlowLayoutPanel itemsPanel = new FlowLayoutPanel();

        public static CircularPictureBox userPic = new CircularPictureBox();
        public FlowLayoutPanel palaa;
        int unpicked = 0;
        int picked = 1;
        public static List<CartItem> items = new List<CartItem>();


        public MainPOS(string user)
        {
            InitializeComponent();
            db = new DbHelper();

            itemsPanel.Dock = DockStyle.Fill;
            itemsPanel.FlowDirection = FlowDirection.LeftToRight;

            itemsPanel.AutoScroll = true;
            itemsPanelContainer.Controls.Add(itemsPanel);

            lblTotal.Controls.Add(lblTotalPrice);

            username = user;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            GetPrice();
            if (lblTotalPrice.Text == "0" || lblTotalPrice.Text == "")
            {
                MessageBox.Show("Please add order first before placing order", "Placing Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                Payment payment = new Payment();
                payment.ShowDialog();
            }
        }

        public static void GetPrice()
        {
            value = 0;
            /*foreach (Control ctr in itemsPanel.Controls)
            {
                double val = Convert.ToDouble(((CartItem)ctr).ItemPricex);
                value += val;
            }*/

            foreach(CartItem item in items)
            {
                value += item.ItemPricex;
            }
            lblTotalPrice.Text = value.ToString();
        }
        private void MainPOS_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString();
            timer1.Start();

            panelItems.Controls.Clear();
            db.PickedItem("UPDATE tbl_items SET Checked = '" + unpicked + "'");
            db.getButtons("SELECT * FROM tbl_items", panelItems);

            int Active = 1;
            db.getUser("SELECT * FROM tbl_cashier WHERE Username = '" + username + "' AND Status = '" + Active + "' ", username);
            lblUser.Text = DbHelper.name;
            pbUser.Image = new Bitmap(DbHelper.picture);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            ClearCart();
            btnMeal.Checked = false;
            btnDrinks.Checked = false;
            btnDessert.Checked = false;
            btnAll.Checked = true;
            btnOthers.Checked = false;
            RefreshForm();
        }

        public void RefreshForm()
        {
            panelItems.Controls.Clear();
            db.getButtons("SELECT * FROM tbl_items", panelItems);
        }

        public static void ClearCart()
        {
            items.Clear();
            itemsPanel.Controls.Clear();
            GetPrice();
            DbHelper db = new DbHelper();
            int unpicked = 0;
            db.PickedItem("UPDATE tbl_items SET Checked = '" + unpicked + "'");

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panelItems.Controls.Clear();
            btnMeal.Checked = true;
            btnDrinks.Checked = false;
            btnDessert.Checked = false;
            btnOthers.Checked = false;
            btnAll.Checked = false;
            db.getButtons("SELECT * FROM tbl_items WHERE Category = 'Meal'", panelItems);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            btnMeal.Checked = false;
            btnDrinks.Checked = false;
            btnDessert.Checked = false;
            btnAll.Checked = true;
            btnOthers.Checked = false;
            panelItems.Controls.Clear();
            db.getButtons("SELECT * FROM tbl_items", panelItems);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            btnMeal.Checked = false;
            btnDrinks.Checked = true;
            btnDessert.Checked = false;
            btnAll.Checked = false;
            btnOthers.Checked = false;
            panelItems.Controls.Clear();
            db.getButtons("SELECT * FROM tbl_items WHERE Category = 'Drinks'", panelItems);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            btnMeal.Checked = false;
            btnDrinks.Checked = false;
            btnDessert.Checked = true;
            btnAll.Checked = false;
            btnOthers.Checked = false;
            panelItems.Controls.Clear();
            db.getButtons("SELECT * FROM tbl_items WHERE Category = 'Dessert'", panelItems);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new frmProfile().ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString() + " | " + DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to logout and exit?", "Exit POS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            btnMeal.Checked = false;
            btnDrinks.Checked = false;
            btnOthers.Checked = true;
            btnDessert.Checked = false;
            btnAll.Checked = false;
            panelItems.Controls.Clear();
            db.getButtons("SELECT * FROM tbl_items WHERE NOT Category = 'Meal' AND NOT Category = 'Drinks' AND NOT Category = 'Dessert'", panelItems);
        }

        public static void getItems(string id, string itemName, string itemPrice, int itemQuantity)
        {
            //kung mag-add ka ng items sa panel, dito na siya, then add values doon sa btnProduct na click event


            if (items.Any(c => c.ItemIdx == id))
            {
                var item = items.Find(c => c.ItemIdx == id);
                item.ItemQuantity += itemQuantity;
                item.ItemPricex += (Convert.ToDouble(itemPrice) * itemQuantity);

            }
            else
            {
                CartItem cartItem = new CartItem();
                cartItem.ItemIdx = id;
                cartItem.ItemNamex = itemName;
                cartItem.ItemPerUnitPrice = itemPrice;
                int quantt = Convert.ToInt32(itemQuantity);
                cartItem.ItemQuantity = itemQuantity;

                double price = Convert.ToDouble(itemPrice);
                double totalItemPrice = price * quantt;
                cartItem.ItemPricex = totalItemPrice;

                items.Add(cartItem);
            }

            int picked = 1;
            int unpicked = 0;
            DbHelper db = new DbHelper();
            db.PickedItem("UPDATE tbl_items SET Checked = '" + picked + "' WHERE ID = '" + id + "' ");

            itemsPanel.Controls.Clear();

            foreach (CartItem item in items)
            {
                itemsPanel.Controls.Add(item);
            }

            GetPrice();
            
        }
        public static void changeQuantity(string ideq, string nameeq, string priceeq, string quantityeq)
        {
            if (items.Any(c => c.ItemIdx == ideq))
            {
                var item = items.Find(c => c.ItemIdx == ideq);
                item.ItemQuantity = Convert.ToInt32(quantityeq);
                item.ItemPricex = (Convert.ToDouble(priceeq) * Convert.ToDouble(quantityeq));
            }

            /*CartItem cartitem = new CartItem();

            cartitem.ItemIdx = ideq;
            cartitem.ItemNamex = nameeq;
            cartitem.ItemPerUnitPrice = priceeq;
            int quantt = Convert.ToInt32(quantityeq);
            cartitem.ItemQuantity = Convert.ToInt32(quantityeq);
            double pricePerItem = Convert.ToDouble(priceeq);
            double totalItemPrice = pricePerItem * quantt;
            cartitem.ItemPricex = totalItemPrice;*/

            //itemsPanel.Controls.Add(cartitem);
            itemsPanel.Controls.Clear();

            foreach (CartItem item in items)
            {
                itemsPanel.Controls.Add(item);
            }
            GetPrice();
            //lblTotalPrice.Text = value.ToString();


        }

        private static void GetPriceEdit()
        {
            
            

            
        }
    } 
}
