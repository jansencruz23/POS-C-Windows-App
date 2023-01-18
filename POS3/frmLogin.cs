using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using POS3.Helpers;


namespace POS3
{
    public partial class frmLogin : Form
    {
        public string un;
        public string pw;

        myDBConnection con = new myDBConnection();
        MySqlCommand command;
        MySqlDataAdapter da;

        public frmLogin()

        {
            InitializeComponent();
            con.Connect();
        }

        private void lblMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int Active = 1;
            string query = "SELECT * FROM tbl_cashier WHERE Username = '" + txt_username.Text + "' AND Password = '" + txt_password.Text + "' AND Status = '" + Active + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, con.cn);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(txt_password.Text.Contains(" ") || txt_username.Text.Contains(" ") || txt_password.Text.Contains("-") || txt_username.Text.Contains("-") || txt_password.Text.Contains("@") || txt_username.Text.Contains("@"))
            {
                MessageBox.Show("Invalid credentials or has spaces or @ characters", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dtbl.Rows.Count == 1)
            {

                DbHelper db = new DbHelper();
                db.getUserProfile("SELECT UserID FROM tbl_cashier WHERE Username = '" + txt_username.Text + "' AND Status = '" + Active + "' ", txt_username.Text);
                MainPOS.userID = db.uid;
                new MainPOS(txt_username.Text).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect credentials or inactive user. Please try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminLogin().Show();
        }

        private void lbl_register_Click_1(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }

        private void cbPW_CheckedChanged_1(object sender, EventArgs e)
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

        private void frmLogin_Load(object sender, EventArgs e)
        {
           // for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
          //  {
         //       if (Application.OpenForms[i].Name != "frmLogin")
          //          Application.OpenForms[i].Close();
         //   }
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

