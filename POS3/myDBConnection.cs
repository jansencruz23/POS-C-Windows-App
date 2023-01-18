using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace POS3
{
    class myDBConnection
    {
        public MySqlConnection cn;
        public void Connect()
        {
            cn = new MySqlConnection("Datasource = 127.0.0.1;username=root;password=;database=db_pos");
        }
    }
}
