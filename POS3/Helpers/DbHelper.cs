using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Data;
using POS3.CustomControls;
using POS3;

namespace POS3.Helpers
{

    class DbHelper
    {
        public static string name;
        public static string picture;
        public string uname, fname, mname, lname, gender, age, pic, pw, bday;
        public int uid;
        myDBConnection conn = new myDBConnection();
        MySqlCommand cmd;
        MySqlDataReader reader;

        public DbHelper()
        {
            cmd = new MySqlCommand();
            conn.Connect();
        }

        public bool connect()
        {
            try
            {
                conn.cn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        public bool disconnect()
        {
            try
            {
                conn.cn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public string getButtons(string query, FlowLayoutPanel panel)
        {
            string ret = "";
            try
            {
                cmd.Connection = conn.cn;
                cmd.CommandText = query.ToLower();
                connect();

                reader = cmd.ExecuteReader();

                string id, name, price, pic, category, picked, stock;


                while (reader.Read())
                {
                    id = reader[0].ToString();
                    name = reader[1].ToString();
                    price = reader[2].ToString();
                    category = reader[3].ToString();
                    pic = reader[4].ToString();
                    picked = reader[5].ToString();
                    stock = reader[6].ToString();

                    btnProduct btn = new btnProduct();

                    btn.ItemId = id;
                    btn.ItemName = name;
                    btn.ItemPrice = price;
                    btn.ItemCategory = category;
                    btn.ItemPic.Image = new Bitmap(pic);
                    btn.lblPicked = picked;
                    btn.ItemStock = stock;

                    if (name != string.Empty)
                    {
                        panel.Controls.Add(btn);
                    }

                    if (stock ==  "0")
                    {
                       btn.Enabled = false;
                       // btn.pbChecked.Visible = true;
                    }
                    else
                    {
                       btn.Enabled = true;
                    }

                    ret = "GUMANA!!!!!!!!!";
                }
            }
            catch (Exception ex)
            {

                ret = ex.Message;
                throw;
            }
            finally
            {

                disconnect();
            }

            return ret;

        }

        public string getBtn(string query)
        {
            string ret = "";
            try
            {
                cmd.Connection = conn.cn;
                cmd.CommandText = query.ToLower();
                connect();

                reader = cmd.ExecuteReader();

                string id, name, price, pic, category, picked, stock;


                while (reader.Read())
                {
                    id = reader[0].ToString();
                    name = reader[1].ToString();
                    price = reader[2].ToString();
                    category = reader[3].ToString();
                    pic = reader[4].ToString();
                    picked = reader[5].ToString();
                    stock = reader[6].ToString();

                    btnProduct btn = new btnProduct();

                    Payment.id = id;
                    Payment.name = name;
                    Payment.price = price;
                    Payment.category = category;

                    Payment.picked = picked;
                    Payment.stock = stock;

                    ret = "GUMANA!!!!!!!!!";
                }
            }
            catch (Exception ex)
            {

                ret = ex.Message;
                throw;
            }
            finally
            {

                disconnect();
            }

            return ret;

        }

        public void getUser(string query, string username)
        {
            try
            {
                cmd.Connection = conn.cn;
                cmd.CommandText = query.ToLower();
                connect();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    name = reader[3].ToString() + " " + reader[4].ToString().Substring(0, 1) + ". " + reader[5].ToString();
                    picture = @reader[8].ToString();

                }
                disconnect();
            }
            catch (Exception ex)
            {

            }
        }

        public void getUserProfile(string query, string username)
        {
            try
            {
                cmd.Connection = conn.cn;
                cmd.CommandText = query.ToLower();
                connect();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    uid = Convert.ToInt32(reader[0]);
                    uname = reader[1].ToString();
                    pw = reader[2].ToString();
                    fname = reader[3].ToString();
                    mname = reader[4].ToString();
                    lname = reader[5].ToString();
                    gender = reader[7].ToString();
                    age = reader[6].ToString();
                    pic = reader[8].ToString();
                    bday = reader[9].ToString();
                }
                disconnect();
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateUser(string query, string id)
        {
            try
            {
                cmd.Connection = conn.cn;
                cmd.CommandText = query;
                connect();
                
                cmd.ExecuteNonQuery();
                disconnect();
            }
            catch (Exception ex)
            {

            }
        }

        public void GetNumberItem(string query)
        {
            cmd.Connection = conn.cn;
            cmd.CommandText = query;
            connect();

            using (MySqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    frmAdminItems frmadminI = new frmAdminItems();
                    int itemID = Convert.ToInt32((read[0]));
                    itemID++;
                    frmadminI.txtIDA.Text = itemID.ToString();

                }
            }
            conn.cn.Close();
        }

        public void PickedItem(string query)
        {
            try
            {
                cmd.Connection = conn.cn;
                cmd.CommandText = query;
                connect();

                cmd.ExecuteNonQuery();
                disconnect();
            }
            catch (Exception ex)
            {

            }
        }

        
    }
}
