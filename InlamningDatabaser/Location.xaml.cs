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

namespace InlamningDatabaser
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : Window
    {
        TextBox[] txtBoxes;
        public Location()
        {
            InitializeComponent();
            txtBoxes = new TextBox[] { tboxTown};
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string location = tboxTown.Text;
            Validate val = new Validate(txtBoxes);
            if (val.valid == true)
            {
                string SQLquerry = $"CALL addLocation('{location}');";
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
