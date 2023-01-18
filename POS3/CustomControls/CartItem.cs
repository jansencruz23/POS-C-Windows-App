using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using POS3.Helpers;

namespace POS3.CustomControls
{
    public partial class CartItem : UserControl
    {
        public string ItemIdx {
            get { return lblItemID.Text; }
            set { lblItemID.Text = value; }
        }
        public string ItemPerUnitPrice
        {
            get { return lblPerItemPrice.Text; }
            set { lblPerItemPrice.Text = value; }
        }
        public string ItemNamex
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }
        public double ItemPricex
        {
            get { return Convert.ToDouble(lblItemPrice.Text); }
            set { lblItemPrice.Text = value.ToString(); }
        }
        public int ItemQuantity
        {
            get { return Convert.ToInt32(btnQuantity.Text); }
            set { btnQuantity.Text = value.ToString(); }
        }
        public Guna2Button RemoveItem
        {
            get { return btnRemove; }
            set { btnRemove = value; }
        }
        public CartItem()
        {
            InitializeComponent();
        }

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            EditQuantity editQuantity = new EditQuantity();
            editQuantity.itemideq = ItemIdx;
            editQuantity.itemnameeq = ItemNamex;
            editQuantity.itempriceeq = ItemPerUnitPrice;
            editQuantity.itemquantityeq = ItemQuantity.ToString();

            editQuantity.ShowDialog();
            //MainPOS.itemsPanel.Controls.Remove(this);
        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper();
            int unpicked = 0;
            db.PickedItem("UPDATE tbl_items SET Checked = '" + unpicked + "' WHERE ID = '" + ItemIdx + "'");

            MainPOS.itemsPanel.Controls.Remove(this);
            MainPOS.items.Remove(this);
            MainPOS.GetPrice();
 
        }
    }
}
