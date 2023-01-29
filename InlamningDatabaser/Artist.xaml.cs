using System;
using System.Collections.Generic;
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
    /// Interaction logic for Artist.xaml
    /// </summary>
    public partial class Artist : Window
    {
        TextBox[] txtBoxes;
        public Artist()
        {
            InitializeComponent();
            txtBoxes = new TextBox[] { tboxFirstName, tboxLastName };
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string firstName = tboxFirstName.Text;
            string lastName = tboxLastName.Text;
            string education = tboxEducation.Text;
            Validate val = new Validate(txtBoxes);
            if (val.valid == true)
            {
                string SQLquerry = $"CALL addArtist('{firstName}', '{lastName}', '{education}');";
                _ = new InsertIntoDb(SQLquerry);
                this.Close();
            }
            else return;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.popComboBox();
        }
    }
}
