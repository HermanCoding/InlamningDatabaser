using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace InlamningDatabaser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            DBLogin dBLogin = new DBLogin();
            conn = new MySqlConnection(dBLogin.connString);
            selectPaintingFromDB();
        }
        private void selectPaintingFromDB(string keyword = "")
        {
            string SQLquerry;
            if (keyword == "")
            { SQLquerry = $"CALL selectPaintings();"; }
            else
            { SQLquerry = $"CALL searchPainting('{keyword}');"; }
            MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                Painting.paintings.Clear();
                
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["painting_id"]);
                    string title = reader["painting_title"].ToString();
                    DateTime year = Convert.ToDateTime(reader["painting_year"]);
                    string dimension = reader["painting_dimension"].ToString();
                    string historicalContext = reader["painting_historical_context"].ToString();
                    string image = reader["painting_image"].ToString();
                    Painting.paintings.Add(new Painting(id, title, year, dimension, historicalContext, image));
                    dg.ItemsSource = Painting.paintings;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally { conn.Close(); }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            selectPaintingFromDB(tboxSearch.Text);
            dg.Items.Refresh();
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            string SQLquerry;
            Painting delpaint = (Painting)dg.SelectedItem;
            int delid = delpaint.Id;
            SQLquerry = $"CALL deletePainting('{delid}');";
            MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);

            try
            {
                conn.Open();
                cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
            dg.Items.Refresh();
            selectPaintingFromDB();
            btnDelet.IsEnabled = false;
            btnUpdate.IsEnabled = false;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addPainting = new((Painting)dg.SelectedItem);
            addPainting.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addPainting = new AddWindow();
            addPainting.Show();
            this.Close();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelet.IsEnabled = dg.SelectedItems.Count > 0;
            btnUpdate.IsEnabled = dg.SelectedItems.Count > 0;
            btnInfo.IsEnabled = dg.SelectedItems.Count > 0;
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            List<string> motif = new List<string>();
            string SQLquerry;
            Painting infopaint = (Painting)dg.SelectedItem;
            int infoid = infopaint.Id;
            SQLquerry = $"CALL getMotifFromPid('{infoid}');";
            MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);

            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    motif.Add(dr["motif_type"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
            if (motif.Count > 0)
            {
                var message = string.Join(Environment.NewLine, motif);
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Inget motiv är specifiserat.");
            }
        }
    }
}
