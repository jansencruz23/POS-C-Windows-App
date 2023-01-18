using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Guna.UI2.WinForms;
using POS3.Helpers;

namespace POS3
{
    public partial class Registration : Form
    {
        public string UserIDR
        {
            get { return guna2TextBox1.Text; }
            set { guna2TextBox1.Text = value; }
        }
        public string UserUNR
        {
            get { return txt_UN.Text; }
            set { txt_UN.Text = value; }
        }
        public string UserFNR
        {
            get { return txt_FN.Text; }
            set { txt_FN.Text = value; }
        }
        public string UserMNR
        {
            get { return txt_MN.Text; }
            set { txt_MN.Text = value; }
        }
        public string UserLNR
        {
            get { return txt_LN.Text; }
            set { txt_LN.Text = value; }
        }
        public Guna2GradientButton btnLoginR
        {
            get { return btnLogin; }
            set { btnLogin = value; }
        }
        public Guna2GradientButton btnUpdateR
        {
            get { return btnUpdate; }
            set { btnUpdate = value; }
        }
        public Guna2Button btnChangePWR
        {
            get { return btnChangePW; }
            set { btnChangePW = value; }
        }
        public Guna2CirclePictureBox pbUserR
        {
            get { return pbpic; }
            set { pbpic = value; }
        }
        public Label lblCPW
        {
            get { return lblConPW; }
            set { lblConPW = value; }
        }
        public Guna2TextBox txtCPW
        {
            get { return txt_conpw; }
            set { txt_conpw = value; }
        }
        public Guna2ImageRadioButton rbMaleR
        {
            get { return rbMale; }
            set { rbMale = value; }
        }

        public Guna2ImageRadioButton rbFemaleR
        {
            get { return rbFemale; }
            set { rbFemale = value; }
        }
        public DateTimePicker dtpBdayR
        {
            get { return dtpBday; }
            set { dtpBday = value; }
        }
        public CheckBox cbPWR1
        {
            get { return cbPW1; }
            set { cbPW1 = value; }
        }

            public CheckBox cbPWR
        {
            get { return cbPW; }
            set { cbPW = value; }
        }
        public Label lblgack
        {
            get { return lblgoback; }
            set { lblgoback = value; }
        }
        public Label lblmini
        {
            get { return lblMinimize; }
            set { lblMinimize = value; }
        }
        public Label lblgack2
        {
            get { return lblBack; }
            set { lblBack = value; }
        }
        public Label lblcloseR
        {
            get { return lblClose; }
            set { lblClose = value; }
        }
        public Guna2Button btnCancel1R
        {
            get { return btnCancel; }
            set { btnCancel = value; }
        }
        public Guna2Button btnCancel2R
        {
            get { return btnCancel2; }
            set { btnCancel2 = value; }
        }
        public Label lblloginR
        {
            get { return lbl_login; }
            set { lbl_login = value; }
        }
        public Label lblxtraR
        {
            get { return lblxtra; }
            set { lblxtra = value; }
        }
        public Label lblEditR
        {
            get { return lblEdit; }
            set { lblEdit = value; }
        }
        public Label lblregR
        {
            get { return lblreg; }
            set { lblreg = value; }
        }

        myDBConnection con = new myDBConnection();
        MySqlCommand cmd = new MySqlCommand();
        DataSet ds = new DataSet();
        private string gender = "Male";
        public int age;
        public string bday;
        public string path = "";
        public Registration()
        {
            InitializeComponent();


            con.Connect();
            con.cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_cashier", con.cn);

            using (MySqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    int userID = Convert.ToInt32((read["UserID"]));
                    userID++;
                    guna2TextBox1.Text = userID.ToString();

                }
            }
            con.cn.Close();
        }


        private void Registration_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txt_FN;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            txt_FN.Focus();
        }

        private void lbl_login_Click_1(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            ofdPic.Filter = "Image files (*.jpg; *.jpeg; *.png;) | *.jpg; *.jpeg; *.png;";

            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                path = ofdPic.FileName.Replace(@"\", @"\\");
                pbpic.Image = new Bitmap(ofdPic.FileName);
            }
            else
            {
                path = "";
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
            lblMale.ForeColor = Color.Black;
            lblFemale.ForeColor = Color.FromArgb(1, 48, 48, 48);
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
            lblFemale.ForeColor = Color.Black;
            lblMale.ForeColor = Color.FromArgb(1, 48, 48, 48);
        }

        private void dtpBday_ValueChanged(object sender, EventArgs e)
        {
            age = DateTime.Now.Year - dtpBday.Value.Year - (DateTime.Now.DayOfYear < dtpBday.Value.DayOfYear ? 1 : 0);
            bday = dtpBday.Value.ToShortDateString();
        }

        private void btnChangePW_Click_1(object sender, EventArgs e)
        {
            new frmChangePW().ShowDialog();
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to cancel registration?", "Cancel Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                new frmLogin().Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txt_UN.Text == "" || txt_PW.Text == "" || txt_FN.Text == "" || txt_MN.Text == "" || txt_LN.Text == "" || gender == "" || age.ToString() == "" || path == "")
            {
                MessageBox.Show("Please fill out all fields", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txt_UN.Text.Trim() == "" || txt_FN.Text.Trim() == "" || txt_MN.Text.Trim() == "" || txt_LN.Text.Trim() == "" || txt_PW.Text.Trim() == "" || txt_conpw.Text.Trim() == "")
            {
                MessageBox.Show("Invalid credentials", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txt_PW.Text.Length < 6 || txt_UN.Text.Length < 6 )
            {
                MessageBox.Show("Username or Password is too short");
            }
            else if (txt_PW.Text.Contains(" ") || txt_UN.Text.Contains(" ") || txt_FN.Text.Contains("@") || txt_MN.Text.Contains("@") || txt_LN.Text.Contains("@") || txt_UN.Text.Contains("@") || txt_PW.Text.Contains("@"))
            {
                MessageBox.Show("Password and Username don't accept spaces or @ character", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_PW.Text == txt_conpw.Text)
            {
                int Inactive = 1;
                cmd = new MySqlCommand("SELECT * FROM tbl_cashier WHERE Username = '" + txt_UN.Text + "' AND Status = '" + Inactive + "' ", con.cn);
                MySqlDataAdapter oda = new MySqlDataAdapter(cmd);
                oda.Fill(ds);
                int existing = ds.Tables[0].Rows.Count;
                if (existing > 0)
                {
                    MessageBox.Show("Username already exists. Try again", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    new Registration().Show();
                }
                else
                {
                    if (age < 18)
                    {
                        MessageBox.Show("You are underaged", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        con.cn.Open();
                        int Status = 1;
                        string register = "INSERT INTO tbl_cashier VALUES ('" + guna2TextBox1.Text + "', '" + txt_UN.Text + "', '" + txt_PW.Text + "', '" + txt_FN.Text + "', '" + txt_MN.Text + "', '" + txt_LN.Text + "', '" + age + "', '" + gender + "', '" + path + "', '" + bday + "', '" + Status + "')";
                        cmd = new MySqlCommand(register, con.cn);
                        cmd.ExecuteNonQuery();
                        con.cn.Close();
                        MessageBox.Show("Registration Succesful", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLogin login = new frmLogin();
                        login.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match, Try again", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper();
            db.getUserProfile("SELECT * FROM tbl_cashier WHERE UserID = '" + MainPOS.userID + "' ", MainPOS.username);
            if (txt_UN.Text == "" || txt_PW.Text == "" || txt_FN.Text == "" || txt_MN.Text == "" || txt_LN.Text == "" || gender == "" || age.ToString() == "" || path == "")
            {
                MessageBox.Show("Please fill out all fields", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_PW.Text.Length < 6 || txt_UN.Text.Length < 6)
            {
                MessageBox.Show("Username or Password is too short");
            }
            else if (txt_PW.Text.Contains(" ") || txt_UN.Text.Contains(" ") || txt_FN.Text.Contains("@") || txt_MN.Text.Contains("@")|| txt_LN.Text.Contains("@")||txt_UN.Text.Contains("@")|| txt_PW.Text.Contains("@"))
            {
                MessageBox.Show("Password and Username don't accept space or @ character", "Change Password Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_PW.Text == db.pw)
            {
                if (age < 18)
                {
                    MessageBox.Show("You are underaged", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    db.UpdateUser("UPDATE tbl_cashier SET UserID = '" + guna2TextBox1.Text + "' , Username = '" + txt_UN.Text + "', FirstName = '" + txt_FN.Text + "', MiddleName = '" + txt_MN.Text + "', LastName = '" + txt_LN.Text + "', Gender = '" + gender + "', Age = '" + age + "', Pic_Path = '" + path + "', Bday = '" + bday + "' WHERE UserID = '" + guna2TextBox1.Text + "'", guna2TextBox1.Text);
                    MessageBox.Show("Changes have been saved! \nLog in again to see changes", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Restart();
                    Environment.Exit(1);
                }
            }
            else
            {
                MessageBox.Show("Incorrect Password", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
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
            Application.Exit();
        }

        private void cbPW_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPW.Checked)
            {
                txt_PW.PasswordChar = '\0';
                txt_conpw.PasswordChar = '\0';
            }
            else
            {
                txt_PW.PasswordChar = '•';
                txt_conpw.PasswordChar = '•';
            }
        }

        private void cbPW1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPW1.Checked)
            {
                txt_PW.PasswordChar = '\0';
            }
            else
            {
                txt_PW.PasswordChar = '•';
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to cancel profile edit?", "Cancel Profile Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
    }

