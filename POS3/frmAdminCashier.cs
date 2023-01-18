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
using System.IO;
using System.Globalization;
using DGVPrinterHelper;

namespace POS3
{
    public partial class frmAdminCashier : Form
    {

        myDBConnection con = new myDBConnection();
        MySqlCommand cmd = new MySqlCommand();
        DataTable dt = new DataTable();
        public frmAdminCashier()
        {
            InitializeComponent();
        }

        private void frmAdminCashier_Load(object sender, EventArgs e)
        {
            con.Connect();
            con.cn.Open();
            {
                if (con.cn.State == ConnectionState.Closed)
                    con.cn.Open();
            }
            MySqlCommand cmd1 = new MySqlCommand("SELECT UserID, Username, FirstName, MiddleName, LastName, Gender, Age, Bday, Pic_Path FROM tbl_cashier WHERE Status = 1 ", con.cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);
            dt.Columns.Add("Pic", Type.GetType("System.Byte[]"));
            foreach (DataRow drow in dt.Rows)
            {
                drow["Pic"] = File.ReadAllBytes(drow["Pic_Path"].ToString());
            }

            dgvCashier.DataSource = dt;
            con.cn.Close();

            if (dgvCashier.Rows.Count == 0)
            {
                dgvCashier.Enabled = false;
            }
            else
            {
                dgvCashier.Enabled = true;
            }
        }

        private void dgvCashier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblUsername.Text = dgvCashier.CurrentRow.Cells[1].Value.ToString();
            lblName.Text = dgvCashier.CurrentRow.Cells[2].Value.ToString() + " " + dgvCashier.CurrentRow.Cells[3].Value.ToString() + " " + dgvCashier.CurrentRow.Cells[4].Value.ToString();
            lblID.Text = dgvCashier.CurrentRow.Cells[0].Value.ToString();
            lblGender.Text = dgvCashier.CurrentRow.Cells[5].Value.ToString();
            lblAge.Text = dgvCashier.CurrentRow.Cells[6].Value.ToString();
            string bday = dgvCashier.CurrentRow.Cells[7].Value.ToString();


            DateTime date = DateTime.Parse(bday);
            lblBday.Text = date.ToString("MMM dd, yyyy");

            pbCashier.Image = new Bitmap(dgvCashier.CurrentRow.Cells[8].Value.ToString());

            btnDeactivate.Enabled = true;
            btnResetPW.Enabled = true;
            lblyrs.Visible = true;
        }

        private void btnResetPW_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmCashierResetPW(lblUsername.Text, lblID.Text).Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmInactiveCashier().Show();
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminItems().Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to Log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                new frmLogin().Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminCashier().Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("LastName LIKE '%{0}%'", txtSearch.Text);
            dgvCashier.DataSource = dv;
        }


        private void btnDeactivate_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to deactivate this cashier?", "Deactivate Cashier", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int deactivate = 0;
                con.cn.Open();
                string deactCashier = "UPDATE tbl_cashier SET Status = '" + deactivate + "' WHERE UserID = '" + lblID.Text + "' ";
                cmd = new MySqlCommand(deactCashier, con.cn);
                cmd.ExecuteNonQuery();
                con.cn.Close();
                MessageBox.Show("Cashier deactivated successfully", "Deactivated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new frmAdminCashier().Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "INSTA BURGER";
            printer.SubTitle = string.Format("Cashier Information List", printer.SubTitleColor = Color.Black, printer);
            printer.SubTitleSpacing = 15;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "INSTA BURGER";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvCashier);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminRecords().Show();
        }
    }
}
