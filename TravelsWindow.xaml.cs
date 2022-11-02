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
        //note to myself: Rad 23-32 lägger till listan som finns i TM i detta fönster så vi kommer åt den även här
        //Listan är ej kopierad utan den är direktkopplad till originalet 

        UserManager userManager;
        TravelManager travelManager;
        IUser currentUser;

        public TravelsWindow(UserManager uManager, TravelManager tManager)
        {
            InitializeComponent();
            userManager = uManager;
            travelManager = tManager;
            currentUser = userManager.SignedInUser;
            UpdateUserNamePrint();
            UpdateTravelList();

        }
        
        //En metod som uppdaterar travellisten efter att en resa lagts till
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

        //Infoknapp som visar en messagebox med kosrtfattad info kring hur man använder TravelPal 
        private void btnAppInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to TravelPal, here you can:\n❀ Click on » Add Traval «  to add a vacation or trip\n❀ Mark one of your travels and click on » Details « to show details of the specific travel\n❀ Mark one off your specific travel an click on » Remove « to unbook it", "How to - TravelPal", MessageBoxButton.OK, MessageBoxImage.Information);
             
        }

        //Sign outknapp som loggar ut användaren och tar den till mainwindow igen
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Show();
            this.Close();
        }

        //Knapp som öppnar upp fönster UserDetailsWindow
        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            new UserDetailsWindow(userManager, this).Show();
            

        } 

        //Knapp som sparar informationen som usern fylllt i, i AddTravelWindow. Knapptryck genererar att resan sparas på userns inlogg samt öppnar upp travelwindow på nytt
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            
            
                AddTravelWindow travelWindow = new(userManager, travelManager, currentUser);
                travelWindow.Owner = this;
                travelWindow.Show(); 
           
            
            
        }

        private void RemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            if(lvTravelList.SelectedItem != null)
            {
                ListViewItem selectedItem = lvTravelList.SelectedItem as ListViewItem;

                Travel selectedTravel = selectedItem.Tag as Travel;

                travelManager.RemoveTravel(selectedTravel);

                userManager.RemoveTravelFromUser(selectedTravel);

                UpdateTravelList();
            }
            else
            {
                MessageBox.Show("You have to select the travel you want to remove from the list");
            }

        }

        private void btnTravelDetails_Click(object sender, RoutedEventArgs e)
        {
            if(lvTravelList.SelectedItem != null)
            {
                ListViewItem selectedItem = lvTravelList.SelectedItem as ListViewItem;

                Travel selectedTravel = selectedItem.Tag as Travel;

                new TravelDetailsWindow(selectedTravel).Show();
            }
            else
            {
                MessageBox.Show("You have to select the travel you want to se from the list");
            }
            


        }

        public void UpdateUserNamePrint()
        {
            lblUsernamePrint.Content = $"{userManager.SignedInUser.UserName}";
        }
    }
}
