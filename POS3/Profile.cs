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
    public partial class frmProfile : Form
    {
        
        public frmProfile()
        {
            InitializeComponent();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper();
            db.getUserProfile("SELECT * FROM tbl_cashier WHERE Username = '" + MainPOS.username + "' ", MainPOS.username);
            lblUsername.Text = db.uname;
            lblFName.Text = db.fname + " " + db.mname + " " + db.lname;
            lblGender.Text = db.gender;
            lblAge.Text = db.age;
            string bday = db.bday;

            DateTime date = DateTime.Parse(bday);
            lblBday.Text = date.ToString("MMM dd, yyyy");

            picUserProfile.Image = new Bitmap(DbHelper.picture);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper();
            db.getUserProfile("SELECT * FROM tbl_cashier WHERE UserID = '" + MainPOS.userID + "' ", MainPOS.username);
            Registration registration = new Registration();
            registration.UserIDR = MainPOS.userID.ToString();
            registration.UserUNR = db.uname;
            registration.UserFNR = db.fname;
            registration.UserMNR = db.mname;
            registration.UserLNR = db.lname;
            registration.pbUserR.Image = new Bitmap(db.pic);
            registration.path = db.pic.Replace(@"\", @"\\");
            registration.dtpBdayR.Value = DateTime.Parse(db.bday);


            if (db.gender == "Female")
            {
                registration.rbFemaleR.Checked = true;
            }

            registration.txtCPW.Visible = false;
            registration.lblCPW.Visible = false;
            registration.btnLoginR.Visible = false;
            registration.btnUpdateR.Visible = true;
            registration.btnChangePWR.Visible = true;
            registration.cbPWR1.Visible = true;
            registration.cbPWR.Visible = false;
            registration.lblgack.Visible = true;
            registration.lblgack2.Visible = false;
            registration.btnCancel1R.Visible = false;
            registration.btnCancel2R.Visible = true;
            registration.lblxtraR.Visible = false;
            registration.lblloginR.Visible = false;
            registration.lblEditR.Visible = true;
            registration.lblregR.Visible = false;
            registration.lblmini.Visible = false;
            registration.lblcloseR.Visible = false;
            registration.ShowDialog();
        }
         
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to Log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Restart();  
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
