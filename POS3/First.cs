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
    public partial class First : Form
    {
        public First()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmLogin().Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminItems().Show();
        }
    }
}
