using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatabaser
{
    internal class DBLogin
    {
        static string server = "localhost";
        static string database = "paintings";
        static string user = "root";
        static string pass = "";
        public string connString = $"SERVER={server};DATABASE={database};UID={user};PASSWORD={pass};";
    }
}
