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

namespace POS3
{
    public partial class frmChangePW : Form
    {
        public frmChangePW()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void btnChangePW_Click(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper();
            db.getUserProfile("SELECT * FROM tbl_cashier WHERE UserID = '" + MainPOS.userID + "' ", MainPOS.username);
            if(txtNewPWC.Text == "" || txtNewPWC.Text == null)
            {
                MessageBox.Show("Please enter a valid password", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtNewPWC.Text.Length < 6)
            {
                MessageBox.Show("Password too short", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtNewPWC.Text.Contains(" "))
            {
                MessageBox.Show("Password don't accept spaces", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtCurrPWC.Text == db.pw && txtNewPWC.Text == txtConPWC.Text)
            {
                db.UpdateUser("UPDATE tbl_cashier SET Password = '" + txtNewPWC.Text + "' WHERE UserID = '" + MainPOS.userID + "' ", MainPOS.userID.ToString());
                MessageBox.Show("Changed Password Successfully", "Changed Password Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Invalid or incorrect password", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmChangePW_Load(object sender, EventArgs e)
        {
            lblUN.Text = MainPOS.username;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbPW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPW.Checked)
            {
                txtCurrPWC.PasswordChar = '\0';
                txtNewPWC.PasswordChar = '\0';
                txtConPWC.PasswordChar = '\0';
            }
            else
            {
                txtCurrPWC.PasswordChar = '•';
                txtNewPWC.PasswordChar = '•';
                txtConPWC.PasswordChar = '•';
            }
        }
    }
}
