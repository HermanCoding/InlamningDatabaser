using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace InlamningDatabaser
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Painting updatePainting = new Painting();
        TextBox[] txtBoxes;
        MySqlConnection conn;
        int pID = 0;
        int aID = 0;
        int lID = 0;
        public AddWindow()
        {
            InitializeComponent();
            DBLogin dBLogin = new DBLogin();
            conn = new MySqlConnection(dBLogin.connString);
            txtBoxes = new TextBox[] { tboxTitle };
            popComboBox();
        }

        public AddWindow(Painting updatePainting)
        {
            //_ = new AddWindow(); Jag förstår inte varför jag måste köra om dessa kodavsnitt. Tänker att det  har att göra med att jag skapar två AddWindow. Du får gärna förklara detta. 
            InitializeComponent();
            DBLogin dBLogin = new DBLogin();
            conn = new MySqlConnection(dBLogin.connString);
            txtBoxes = new TextBox[] { tboxTitle };
            popComboBox();
            //----------------------------------------------------------

            this.updatePainting = updatePainting;
            pID = updatePainting.Id;
            tboxTitle.Text = Convert.ToString(updatePainting.Title);
            datePCreated.Text = Convert.ToString(updatePainting.Year);
            tboxDimension.Text = Convert.ToString(updatePainting.Dimension);
            tboxHisContext.Text = Convert.ToString(updatePainting.HistoricalContext);
            tboxImage.Text = Convert.ToString(updatePainting.Image);

            string SQLQuerry = $"CALL getArtistLocationFromPid({pID});";
            MySqlCommand cmd = new MySqlCommand(SQLQuerry, conn);

            try
            {
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    aID = Convert.ToInt32(dr["artist_id"]);
                    lID = Convert.ToInt32(dr["location_id"]);
                }

                for (int i = 0; i < cboxArtist.Items.Count; i++)
                {
                    if (((ArtistClass)cboxArtist.Items[i]).id == aID)
                    {
                        cboxArtist.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < cboxLocation.Items.Count; i++)
                {
                    if (((LocationClass)cboxLocation.Items[i]).id == lID)
                    {
                        cboxLocation.SelectedIndex = i;
                    }

                }
                btnSave.IsEnabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally { conn.Close(); }
        }

        public void popComboBox()
        {
            string SQLquerry;
            try
            {
                ArtistClass.artists.Clear();
                conn.Open();
                SQLquerry = $"SELECT * FROM artists;";
                MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["artist_id"]);
                    string firstName = dr["artist_firstName"].ToString();
                    string lastName = dr["artist_lastName"].ToString();
                    string education = dr["artist_education"].ToString();

                    ArtistClass.artists.Add(new ArtistClass(id, firstName, lastName, education));
                    cboxArtist.ItemsSource = ArtistClass.artists;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            //------------------------------------------------------------------------------------------
            try
            {
                LocationClass.locations.Clear();
                conn.Open();
                SQLquerry = $"SELECT * FROM locations;";
                MySqlCommand cmd = new MySqlCommand(SQLquerry, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["location_id"]);
                    string location = dr["location_lastLocation"].ToString();

                    LocationClass.locations.Add(new LocationClass(id, location));
                    cboxLocation.ItemsSource = LocationClass.locations;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string pTitle = tboxTitle.Text;
            string pYear = datePCreated.Text;
            string pDimension = tboxDimension.Text;
            string pHisContext = tboxHisContext.Text;
            string pImage = tboxImage.Text;

            Validate val = new Validate(txtBoxes);
            if (pYear == "") { val.valid = false; MessageBox.Show("Sätt ett datum."); }
            if (val.valid == true)
            {
                if (pID != 0)
                {
                    string SQLquerry = $"CALL updatePainting('{pID}', '{pTitle}', '{pYear}', '{pDimension}', '{pHisContext}', '{pImage}', '{aID}', '{lID}');";
                    _ = new InsertIntoDb(SQLquerry);
                }
                else
                {
                    string SQLquerry = $"CALL addPainting('{pTitle}', '{pYear}', '{pDimension}', '{pHisContext}', '{pImage}', '{aID}', '{lID}');";
                    _ = new InsertIntoDb(SQLquerry);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else return;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void addArtist_Click(object sender, RoutedEventArgs e)
        {
            Artist artist = new Artist();
            artist.Show();
        }

        private void addLocation_Click(object sender, RoutedEventArgs e)
        {
            Location location = new Location();
            location.Show();
        }

        private void cboxArtist_DropDownClosed(object sender, EventArgs e)
        {
            if (cboxArtist.SelectedItem != null)
            {
                try
                {
                    ArtistClass varAID = (ArtistClass)this.cboxArtist.SelectedItem;
                    aID = varAID.id;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            if (aID != 0 && lID != 0)
            {
                btnSave.IsEnabled = true;
                return;
            }
            else
            {
                return;
            }
        }

        private void cboxLocation_DropDownClosed(object sender, EventArgs e)
        {
            if (cboxLocation.SelectedItem != null)
            {
                try
                {
                    LocationClass varLID = (LocationClass)this.cboxLocation.SelectedItem;
                    lID = varLID.id;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            if (aID != 0 && lID != 0)
            {
                btnSave.IsEnabled = true;
                return;
            }
            else
            {
                return;
            }
        }

        private void cboxArtist_DropDownOpened(object sender, EventArgs e)
        {
            cboxArtist.Items.Refresh();
        }

        private void cboxLocation_DropDownOpened(object sender, EventArgs e)
        {
            cboxLocation.Items.Refresh();
        }
    }
}
