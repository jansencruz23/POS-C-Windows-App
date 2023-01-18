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
using POS3.Helpers;
using DGVPrinterHelper;

namespace POS3
{
    public partial class frmAdminRecords : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand cmd = new MySqlCommand();
        DbHelper db = new DbHelper();
        DataTable dt = new DataTable();
        public frmAdminRecords()
        {
            InitializeComponent();
        }

        private void frmAdminRecords_Load(object sender, EventArgs e)
        {
            con.Connect();
            con.cn.Open();
            {
                if (con.cn.State == ConnectionState.Closed)
                    con.cn.Open();
            }
            MySqlCommand cmd1 = new MySqlCommand("SELECT ID, Cashier, Product, Quantity, Price, TotalPrice, Total, Date FROM tbl_record", con.cn);
            MySqlDataAdapter da = new MySqlDataAdapter();

            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);



            dgvRecord.DataSource = dt;
            con.cn.Close();
        }

        private void dgvRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminItems().Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminCashier().Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "INSTA BURGER";
            printer.SubTitle = string.Format("Transaction Record", printer.SubTitleColor = Color.Black, printer);
            printer.SubTitleSpacing = 15;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "INSTA BURGER";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvRecord);
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

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Cashier LIKE '%{0}%'", txtSearch.Text);
            dgvRecord.DataSource = dv;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            con.Connect();
            con.cn.Open();
            {
                if (con.cn.State == ConnectionState.Closed)
                    con.cn.Open();
            }
            MySqlCommand cmd1 = new MySqlCommand("SELECT ID, Cashier, Product, Quantity, Price, TotalPrice, Total, Date FROM tbl_record WHERE Date= '" + DateTime.Now.ToShortTimeString() + "' ", con.cn);
            MySqlDataAdapter da = new MySqlDataAdapter();

            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);



            dgvRecord.DataSource = dt;
            con.cn.Close();
        }
    }
}
