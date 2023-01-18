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
using System.Windows.Markup;
using POS3.Helpers;
using POS3.CustomControls;
using System.Reflection;
using System.Drawing.Printing;
using System.Threading;

namespace POS3
{
    public partial class frmReceipt : Form
    {
        string cash;
        string change;
        Bitmap memoryImage;
        public frmReceipt(string cash, string change)
        {
            InitializeComponent();
            this.cash = cash;
            this.change = change;
            
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "my printer";
        }

        private void frmReceipt_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Payment payment = new Payment();

            lblDate.Text = DateTime.Now.ToString();
            lblTotalPriceReceipt.Text = "" + MainPOS.value;
            lblCash.Text = cash;
            lblChange.Text = change;
            lblName.Text = DbHelper.name;
            foreach (Control ctr in MainPOS.itemsPanel.Controls)
            {
                if (ctr.Name == "CartItem")
                {
                    lblItemName.Text += "\n" + (((CartItem)ctr).ItemNamex);
                    lblQty.Text += "\n" + (((CartItem)ctr).ItemQuantity);
                    lblPrice.Text += "\n@" + (((CartItem)ctr).ItemPerUnitPrice);
                    lblTotalPrice.Text += "\n" + (((CartItem)ctr).ItemPricex);
                }
            }
            lblItemName.Text += "\n\n\n\n\n\n\n\n\n";
            lblQty.Text += "\n\n\n\n\n\n\n\n\n";
            lblPrice.Text += "\n\n\n\n\n\n\n\n\n";
            lblTotalPrice.Text += "\n\n\n\n\n\n\n\n\n";
        }

        private void PrintForm()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

            printDocument1.Print();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintForm();
            this.Hide();
            new MainPOS(MainPOS.username).Show();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
