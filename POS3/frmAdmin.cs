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
using System.IO;
using DGVPrinterHelper;

namespace POS3
{
    public partial class frmAdminItems : Form
    {
        public Guna2TextBox txtIDA
        {
            get { return txtID; }
            set { txtID = value; }
        }
        private string path;
        myDBConnection con = new myDBConnection();
        MySqlCommand cmd = new MySqlCommand();
        DbHelper db = new DbHelper();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string path2;
        public frmAdminItems()
        {
            InitializeComponent();
        }

        private void frmAdminItems_Load(object sender, EventArgs e)
        {
            con.Connect();
            con.cn.Open();
            {
                if (con.cn.State == ConnectionState.Closed)
                    con.cn.Open();
            }
            MySqlCommand cmd1 = new MySqlCommand("SELECT ID, Name, Price, Category, Pic_Path, Stock FROM tbl_items", con.cn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            
            da.SelectCommand = cmd1;
            dt.Clear();
            da.Fill(dt);
            dt.Columns.Add("Pic", Type.GetType("System.Byte[]"));
            foreach (DataRow drow in dt.Rows)
            {
                drow["Pic"] = File.ReadAllBytes(drow["Pic_Path"].ToString());
            }

            dgvItems.DataSource = dt;
            con.cn.Close();

            if(dgvItems.Rows.Count == 0)
            {
                dgvItems.Enabled = false;
            }
            else
            {
                dgvItems.Enabled = true;
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ofdPic.Filter = "Image files (*.jpg; *.jpeg; *.png;) | *.jpg; *.jpeg; *.png;";

            if (ofdPic.ShowDialog() == DialogResult.OK)
            {
                txtPicPath.Text = ofdPic.FileName;
                path = ofdPic.FileName.Replace(@"\", @"\\");
                pbItem.Image = new Bitmap(ofdPic.FileName);
            }
            else
            {
                if(txtPicPath.Text == "")
                {
                    path = "";
                }
                else if(path2 == null)
                {
                    path = "";
                    path2 = "";
                    txtPicPath.Text = "";
                }
                else
                {
                    path = path2.Replace(@"\", @"\\");
                }
            }
        }
    
        private void dgvItems_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txtID.Text = dgvItems.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvItems.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dgvItems.CurrentRow.Cells[2].Value.ToString();
            cbCatergory.Text = dgvItems.CurrentRow.Cells[3].Value.ToString();
            path2 = dgvItems.CurrentRow.Cells[4].Value.ToString();
            txtPicPath.Text = dgvItems.CurrentRow.Cells[4].Value.ToString();
            pbItem.Image = new Bitmap(dgvItems.CurrentRow.Cells[4].Value.ToString());
            txtStock.Text = dgvItems.CurrentRow.Cells[5].Value.ToString();

            path = txtPicPath.Text.Replace(@"\", @"\\");
            btnEdit.Enabled = true;
            btnSelectIMG.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            getNumberItem();
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSelectIMG.Enabled = true;
            btnAddItem.Checked = true;

        }

        private void getNumberItem()
        {
            con.Connect();
            con.cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_items", con.cn);

            if(txtID.Text == "")
            {
                txtID.Text = "1";
            }

            using (MySqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    int itemID = Convert.ToInt32((read[0]));
                    itemID++;
                    txtID.Text = itemID.ToString();
                    ResetTxt();
                }
            }
            con.cn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "@" || txtName.Text == "@" || txtPrice.Text == "@" || txtPicPath.Text == "@" || txtPicPath.Text == "@")
            {
                MessageBox.Show("Invalid characters", "Add Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtID.Text != "" || txtName.Text != "" || txtPrice.Text != "" || txtPicPath.Text != "" || txtPicPath.Text != "")
            {
                cmd = new MySqlCommand("SELECT * FROM tbl_items WHERE Name = '" + txtName.Text + "'  ", con.cn);
                MySqlDataAdapter oda = new MySqlDataAdapter(cmd);
                oda.Fill(ds);
                int existing = ds.Tables[0].Rows.Count;
                if (existing > 0)
                {
                    MessageBox.Show("Item already exists. Try again", "Item Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    new frmAdminItems().Show();
                }
                else
                {

                    AddItem();
                    this.Hide();
                    frmAdminItems frm = new frmAdminItems();
                    frm.Show();
                }

            }


            


        }

        private void AddItem()
        {
            if(txtID.Text == "" || txtName.Text == "" || txtPrice.Text == "" || txtPicPath.Text == "" || txtStock.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Add Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int Checked = 0;
                con.cn.Open();
                string addItem = "INSERT INTO tbl_items VALUES('" + txtID.Text + "', '" + txtName.Text + "', '" + txtPrice.Text + "', '" + cbCatergory.Text + "', '" + path + "', '" + Checked + "', '" + txtStock.Text + "')";
                cmd = new MySqlCommand(addItem, con.cn);
                cmd.ExecuteNonQuery();
                con.cn.Close();

                MessageBox.Show("Item added successfully", "Add Item Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as Guna2TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 22)
                e.Handled = true;
        }
        private void ResetTxt()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtPicPath.Text = "";
            cbCatergory.Text = "";
            pbItem.Image = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateItem();
            if (txtID.Text == "@" || txtName.Text == "@" || txtPrice.Text == "@" || txtPicPath.Text == "@" || txtStock.Text == "@")
            {
                MessageBox.Show("Invalid characters", "Edit Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateItem()
        {
            if (txtName.Text == "" || txtPrice.Text == "" || txtPicPath.Text == "" || cbCatergory.Text == "" || pbItem.Image == null || path == "" || txtStock.Text == "")
            {
                MessageBox.Show("Please fill out all fields", "Add Item Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.cn.Open();
                string updateItem = "UPDATE tbl_items SET Name = '" + txtName.Text + "', Price = '" + txtPrice.Text + "', Category = '" + cbCatergory.Text + "', Pic_Path = '" + path + "', Stock = '" + txtStock.Text + "' WHERE ID = '" + txtID.Text + "' ";
                cmd = new MySqlCommand(updateItem, con.cn);
                cmd.ExecuteNonQuery();
                con.cn.Close();
                MessageBox.Show("Item added successfully", "Add Item Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmAdminItems frm = new frmAdminItems();
                frm.Show();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this item?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteItem();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }

        private void DeleteItem()
        {
            con.cn.Open();
            string deleteItem = "DELETE FROM tbl_items WHERE ID = '" + txtID.Text + "' ";
            cmd = new MySqlCommand(deleteItem, con.cn);
            cmd.ExecuteNonQuery();
            con.cn.Close();
            this.Hide();
            frmAdminItems frm = new frmAdminItems();
            frm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminCashier().Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

        private void btnItems_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminItems().Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = string.Format("Name LIKE '%{0}%'", txtSearch.Text);
            dgvItems.DataSource = dv;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "INSTA BURGER";
            printer.SubTitle = string.Format("Item Information List", printer.SubTitleColor = Color.Black, printer);
            printer.SubTitleSpacing = 15;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.RowHeight = DGVPrinter.RowHeightSetting.CellHeight;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "INSTA BURGER";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvItems);
        }

        private void lblMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cbCatergory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdminRecords().Show();
        }
    }
}
