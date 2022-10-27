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



namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();
        }

        private void btnAppInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to TravelPal, here you can:\n❀ CLick on » Add Traval «  to add a vacation or trip\n❀ Mark one of your travels and click on » Details « to show details of the specific travel\n❀ Mark one off your specific travel an click on » Remove « to unbook it", "Information how to use TravelPal", MessageBoxButton.OK, MessageBoxImage.Information);
             
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Show();
           
            this.Close();
        }

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            new UserDetailsWindow().Show();
            this.Hide();
        }
    }
}
