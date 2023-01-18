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
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using Guna.UI2.WinForms.Suite;

namespace POS3
{
    public partial class frmCashierResetPW : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand cmd = new MySqlCommand();
        private string un, id;
        public frmCashierResetPW(string un, string id)
        {
            InitializeComponent();
            this.un = un;
            this.id = id;
        }

        private void frmCashierChangePW_Load(object sender, EventArgs e)
        {
            lblUN.Text = un;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new frmInactiveCashier().Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            NewPassword();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPW.Checked)
            {
                txtNewPW.PasswordChar = '\0';
                txtConPW.PasswordChar = '\0';
            }
            else
            {
                txtNewPW.PasswordChar = '•';
                txtConPW.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminCashier().Show();
        }

        private void NewPassword()
        {
            if (txtNewPW.Text == "" || txtConPW.Text == "")
            {
                MessageBox.Show("Please fill out all fields");
            }
            else
            {
                if(txtNewPW.Text == txtConPW.Text)
                {
                    con.Connect();
                    con.cn.Open();
                    string resetPW = "UPDATE tbl_cashier SET Password = '" + txtConPW.Text + "' WHERE UserID = '" + id + "' ";
                    cmd = new MySqlCommand(resetPW, con.cn);
                    cmd.ExecuteNonQuery();
                    con.cn.Close();
                    MessageBox.Show("Password reset successfully");
                    this.Hide();
                    frmAdminCashier frm = new frmAdminCashier();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Passwords don't match");
                }
                
            }
        }
    }
}
