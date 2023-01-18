using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS3.Helpers;
using POS3.CustomControls;
using Guna.UI2.WinForms;

namespace POS3.CustomControls
{
  
    public partial class btnProduct : UserControl 
    {
        public FlowLayoutPanel panely { get; set; }
        public string ItemId {
            get { return lblItemID.Text; }
            set { lblItemID.Text = value; }
        }
        public string ItemName
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }
        public string ItemCategory
        {
            get { return lblCategory.Text; }
            set { lblCategory.Text = value; }
        }
        public string ItemPrice
        {
            get { return lblPrice.Text; }
            set { lblPrice.Text = value; }
        }
        public string ItemStock
        {
            get { return lblStock.Text; }
            set { lblStock.Text = value; }
        }
        public Guna2PictureBox ItemPic
        {
            get { return picProd; }
            set { picProd = value; }
        }
        public string lblPicked
        {
            get { return lblChecked.Text; }
            set { lblChecked.Text = value; }
        }
        public Guna2PictureBox pbChecked
        {
            get { return pbCheck; }
            set { pbCheck = value; }
        }

        public btnProduct()
        {
            InitializeComponent();
            WireAllControls(this);
        }

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {         
            Quantity quantity = new Quantity();
            quantity.itemidq = ItemId;
            quantity.itemnameq = ItemName;
            quantity.itempriceq = ItemPrice;


            //Enabled = false;
            //pbCheck.Visible = true;

            quantity.ShowDialog();  
        }
    }
}
