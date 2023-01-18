using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS3
{
    public partial class PayCart : UserControl
    {
        public string PayItemName
        {
            get { return lblItemName.Text; }
            set { lblItemName.Text = value; }
        }
        public PayCart()
        {
            InitializeComponent();
        }
    }
}
