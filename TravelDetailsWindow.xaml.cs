using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
using TravelPal.Travels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {

        public TravelDetailsWindow(Travel selectedTravel)
        {
            InitializeComponent();

            txtDestination.Text = selectedTravel.Destination;
            txtCountry.Text = selectedTravel.Country.ToString();
            txtTravlers.Text = selectedTravel.Travellers.ToString();
            txtType.Text = selectedTravel.GetType().Name;
            txtTripType.Text = selectedTravel.GetType().Name;
            lblTripOrAllinclusive.Visibility = Visibility.Visible;



            if (selectedTravel is Trip)
            {
                Trip trip = selectedTravel as Trip;


                lblTripOrAllinclusive.Content = "Trip";
                txtType.Visibility = Visibility.Visible;
                chbAllinclusive.Visibility = Visibility.Hidden;
                txtType.Text = trip.Type.ToString();
                
            }
            else if (selectedTravel is Vacation)
            {
                Vacation vacation = selectedTravel as Vacation;

                chbAllinclusive.Visibility = Visibility.Visible;
                txtTripType.Visibility = Visibility.Hidden;
                lblTripOrAllinclusive.Content = "Allinclusive";



                if (vacation.IsAllInclusive)
                {
                    chbAllinclusive.IsChecked = true;
                }
                else
                {
                    chbAllinclusive.IsChecked = false;
                }
            }

        }
        //Stänger Detailswindow så användaren kommer tillbaka till travelswindow
        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}

      