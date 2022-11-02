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
using TravelPal.Enums;
using TravelPal.Manager;
using TravelPal.Users;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        UserManager userManager;
        TravelsWindow travelsWindow;
        public UserDetailsWindow(UserManager userManager, TravelsWindow travelsWindow)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.travelsWindow = travelsWindow;
            SetUserDetails();
            cbUcountries.ItemsSource = Enum.GetValues(typeof(Countries));
        }

        private void SetUserDetails()
        {
            txtUusername.Text = userManager.SignedInUser.UserName;
            txtUpassword.Text = userManager.SignedInUser.Password;
            cbUcountries.SelectedIndex = (int)userManager.SignedInUser.Location;

            lblUsernamePrint.Content = userManager.SignedInUser.UserName;
        }

        private void cbUcountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Skapa ny enum eller koppla samman med registerwindow?

        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {

            //Kolla upp hur detta fungerar 
            //((TravelsWindow)Application.Current.TravelsWindow).Show();
            //this.Close();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string uUsername = txtUusername.Text;
            string uPassword = txtUpassword.Text;
            Countries uCountry = (Countries)cbUcountries.SelectedItem;


            if (txtUpassword.Text == "" || txtUpassword.Text == "" || txtUCpassword.Text == "")
            {
                MessageBox.Show("All fields are not fieled in", "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtUpassword.Text != txtUCpassword.Text)
            {
                MessageBox.Show("The passwords do not match", "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (uUsername.Length > 2 && uUsername.Length < 20 && uPassword.Length > 4 && uPassword.Length < 20)
            {
                User user = new();
                user.IUser(uUsername, uPassword, uCountry);
                if (userManager.updateUser(user))
                {
                    travelsWindow.UpdateUserNamePrint();
                    MessageBox.Show("Changes saved! ❀");
                }
                

                this.Close();
            }
            else
            {
                MessageBox.Show("Register demand:\n❀ The username most contains minimum 3 caracters \n❀ The password most contains minimum 5 caracters \n❀ Maximum caracters allowed on username or password is 20", "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUCpassword.Clear();
                txtUpassword.Clear();
            }



            
        } 
    }
}
