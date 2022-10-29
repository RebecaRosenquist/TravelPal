using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TravelPal.Manager;
using TravelPal.Travels;
using TravelPal.Users;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        //Rad 23-32 lägger till listan som finns i TM i detta fönster så vi kommer åt den även här
        //Listan är ej kopierad utan den är direktkopplad till originalet 

        UserManager userManager;
        TravelManager travelManager;
        IUser currentUser;

        public TravelsWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();
            userManager = uManager;
            travelManager = tManager;
            currentUser = userManager.signedInUser;

            UpdateTravelList();

        }

        public void UpdateTravelList()
        {
            lvTravelList.Items.Clear();
            foreach(Travel travel in currentUser.GetTravels())
            {
                ListViewItem newItem = new();
                newItem.Content = travel.Country;
                newItem.Tag = travel;
                lvTravelList.Items.Add(newItem);

            }
            
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

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow travelWindow = new(userManager, travelManager, currentUser);
            travelWindow.Owner = this;
            travelWindow.Show();    
            this.Hide();
        }

       
    }
}
