using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Linq;

namespace InlamningDatabaser
{
    class InsertIntoDb
    {
        MySqlConnection conn;
        public InsertIntoDb(string SQLquerry)
        {
            DBLogin dBLogin = new DBLogin();
            conn = new MySqlConnection(dBLogin.connString);
            MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);
            try
            {
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            MessageBox.Show("Insert finished successfully!");
        }
    }
}
