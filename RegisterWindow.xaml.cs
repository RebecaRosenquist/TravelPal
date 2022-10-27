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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        UserManager userManager;
        public RegisterWindow(UserManager uManager)
        {
            InitializeComponent();
            userManager = uManager;

            //skapar alla länder
            string[] countries = Enum.GetNames(typeof(Countries));

            ////Lägger arrrayn med länder i ComboBoxen
            cbRCountries.ItemsSource = countries;
        }

        public void txtRusername_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        public void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
               
        }

        private void cbRCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Lägger in UI:s värde i variablar
            string rUsername = txtRusername.Text;
            string rPassword = txtRPassword.Text;
            Countries rCountry = (Countries)Enum.Parse(typeof(Countries), cbRCountries.SelectedItem.ToString());

            if(rUsername.Length >2 && rUsername.Length <20 && rPassword.Length >4 && rPassword.Length <20)
            { 
                User user = new();
                user.IUser(rUsername, rPassword, rCountry);
                userManager.addUser(user);

                ((MainWindow)Application.Current.MainWindow).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Register demand:\n❀ The username most contains minimum 3 caracters \n❀ The password most contains minimum 5 caracters \n❀ Maximum caracters allowed on username or password is 20", "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRPassword.Clear();
                txtRusername.Clear();
            }

           


        }
    }
    
}
