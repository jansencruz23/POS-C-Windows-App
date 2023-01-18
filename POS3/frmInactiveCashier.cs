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
using DGVPrinterHelper;

namespace POS3
{
    public partial class frmInactiveCashier : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand cmd = new MySqlCommand();
        DataTable dt = new DataTable();
        public frmInactiveCashier()
        {
            InitializeComponent();
        }

        private void frmInactiveCashier_Load(object sender, EventArgs e)
        {
            con.Connect();
            con.cn.Open();
            {
                if (con.cn.State == ConnectionState.Closed)
                    con.cn.Open();
            }
            MySqlCommand cmd1 = new MySqlCommand("SELECT UserID, Username, FirstName, MiddleName, LastName, Gender, Age, Bday, Pic_Path FROM tbl_cashier WHERE Status = 0 ", con.cn);
            MySqlDataAdapter da = new MySqlDataAdapter();

            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);
            dt.Columns.Add("Pic", Type.GetType("System.Byte[]"));
            foreach (DataRow drow in dt.Rows)
            {
                drow["Pic"] = File.ReadAllBytes(drow["Pic_Path"].ToString());
            }

            dgvCashierInactive.DataSource = dt;
            con.cn.Close();

            if (dgvCashierInactive.Rows.Count == 0)
            {
                dgvCashierInactive.Enabled = false;
            }
            else
            {
                dgvCashierInactive.Enabled = true;
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("LastName LIKE '%{0}%'", txtSearch.Text);
            dgvCashierInactive.DataSource = dv;
        }

        private void btnInactive_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmInactiveCashier().Show();
        }

        private void btnActiveCashier_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminCashier().Show();
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "INSTA BURGER";
            printer.SubTitle = string.Format("Inactive Cashier Information List", printer.SubTitleColor = Color.Black, printer);
            printer.SubTitleSpacing = 15;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "INSTA BURGER";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvCashierInactive);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminRecords().Show();
        }
    }
}
