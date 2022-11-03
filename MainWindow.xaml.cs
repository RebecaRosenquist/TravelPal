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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal.Enums;
using TravelPal.Manager;
using TravelPal.Travels;
using TravelPal.Users;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserManager userManager = new();
        TravelManager travelManager = new();
      
        public MainWindow()
        {
            InitializeComponent();

            Admin admin = new(travelManager);
            admin.IUser("admin", "password", Countries.Afghanistan);
            userManager.addUser(admin);

            User user = new();
            user.IUser("Gandalf", "password", Countries.Bahamas);
            userManager.addUser(user);
            Vacation vacation = new(true, "Växjö", Countries.Switzerland, 4);
            user.travels.Add(vacation);
            travelManager.AddTravel(vacation);
            Trip trip = new(TripTypes.Work, "Paris", Countries.Bahamas, 4);
            user.travels.Add(trip);
            travelManager.AddTravel(trip);

            User user1 = new();
            user1.IUser("asd", "asd", Countries.Bahamas);
            userManager.addUser(user1);

            

        }
        //Loggar in användaren om den uppfyller villkoren
        private void btnSingIn_Click(object sender, RoutedEventArgs e)
        {
            
            if(txtUsername.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("The fields are empty.", "Logging in failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("One field are empty.", "Logging in failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                
                if(userManager.SignInUser(txtUsername.Text, txtPassword.Text))
                {
                    new TravelsWindow(userManager, travelManager).Show();
                    txtPassword.Clear();
                    txtUsername.Clear();
                    this.Hide();
                }
                
                else
                {
                    
                    MessageBox.Show("The password or username is not a match", "Logging in failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        //Skickar användaren till registerwindow
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow(userManager).Show();
            this.Hide();
        }
    }
}
