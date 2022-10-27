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

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserManager userManager = new();
      
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void btnSingIn_Click(object sender, RoutedEventArgs e)
        {
            //Kontrollerar om det finns någon text inskriven i rutorna för användarnamn och lösenord
            if(txtUsername.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Some field/fields are empty.", "Logging in failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Användarnamnet och lösenordet är kontrollerat i metoden signInUser och om det är true så
                if(userManager.signInUser(txtUsername.Text, txtPassword.Text))
                {
                    new TravelsWindow().Show();
                    this.Hide();
                }
                //Om användarnamnet eller lösenordet blev false i signInUser
                else
                {
                    //inloggning misslyckad
                    MessageBox.Show("The password or username is not a match", "Logging in failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow(userManager).Show();
            this.Hide();
        }
    }
}
