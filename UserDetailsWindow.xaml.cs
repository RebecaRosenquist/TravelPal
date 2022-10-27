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

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        public UserDetailsWindow()
        {
            InitializeComponent();
        }

        private void cbUcountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Skapa ny enum eller koppla samman med registerwindow?

        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            //Kolla upp hur detta fungerar 
            ((TravelsWindow)Application.Current.TravelsWindow).Show();
            this.Close();

        }
    }
}
