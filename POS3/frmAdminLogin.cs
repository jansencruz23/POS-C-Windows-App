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
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "admin" && txt_password.Text == "admin")
            {
                this.Hide();
                new frmAdminItems().Show();
            }
            else
            {
                MessageBox.Show("Incorrect credentials. Please try again", "Admin Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbPW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPW.Checked)
            {
                txt_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '•';
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmLogin().Show();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}

