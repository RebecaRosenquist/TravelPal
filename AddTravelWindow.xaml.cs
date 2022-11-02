using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using TravelPal.Travels;
using TravelPal.Users;


namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        UserManager userManager;
        TravelManager travelManager;
        IUser currentUser;
        public AddTravelWindow(UserManager uManager, TravelManager tManager, IUser user)
        {
            InitializeComponent();

            FeedComoBoxes();

            currentUser = user;
            travelManager = tManager;
            userManager = uManager;


            
        }

        private void FeedComoBoxes()
        {
            cbxType.Items.Add("Vacation");
            cbxType.Items.Add("Trip");
          
            string[] tripTypes = Enum.GetNames(typeof(TripTypes));
            cbxTripType.ItemsSource = tripTypes;

            string[] country = Enum.GetNames(typeof(Countries));
            cbxCountry.ItemsSource = country;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtDestination.Text != "" && txtTravlers.Text != "" && cbxCountry.SelectedItem != null && cbxType.SelectedItem != null)
            {
                if(txtTravlers.Text.Length < 2)
                {
                    try
                    {
                        Countries country = (Countries)Enum.Parse(typeof(Countries), cbxCountry.Text.ToString());
                        string destination = txtDestination.Text;
                        int travlers = Convert.ToInt32(txtTravlers.Text);

                        if (cbxType.SelectedItem.ToString() == "Vacation")
                        {

                            bool isAllinclusive = (bool)chbAllInclusive.IsChecked;
                            Vacation vacation = new(isAllinclusive, destination, country, travlers);
                            travelManager.AddTravel(vacation);
                            currentUser.GetTravels().Add(vacation);
                        }
                        else
                        {
                            if (cbxTripType.SelectedItem != null)
                            {
                                TripTypes tripType = (TripTypes)Enum.Parse(typeof(TripTypes), cbxTripType.SelectedItem.ToString());
                                Trip trip = new(tripType, destination, country, travlers);
                                travelManager.AddTravel(trip);
                                currentUser.GetTravels().Add(trip);
                            }
                            else
                            {
                                MessageBox.Show("All fields are net field in ", "Adding travel failed", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("You most fill in alla the fields \n The amount of travlers most be in numbers ONLY", "Adding travel failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Travels over 9 persons have to be booked through phone \n🕿 : 0708-143965   🕓 : Mon-Fri 8-20", "Travel info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            else
            {
                MessageBox.Show("All fields are not field in ", "Adding travel failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
               

                
                   
                //    {
                //        MessageBox.Show("All fields are not fieled in ETT", "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
                //    }
                //}
            //if(txtTravlers.Text.Length == 1)
            //{ 
            //    try
            //    {
            //            Countries country = (Countries)Enum.Parse(typeof(Countries), cbxCountry.Text.ToString());
            //            string destination = txtDestination.Text;
            //            int travlers = Convert.ToInt32(txtTravlers.Text);

            //            if (cbxType.SelectedItem.ToString() == "Vacation")
            //            {
            //                try
            //                {

            //                    bool isAllinclusive = (bool)chbAllInclusive.IsChecked;
            //                    Vacation vacation = new(isAllinclusive, destination, country, travlers);
            //                    travelManager.AddTravel(vacation);
            //                    currentUser.GetTravels().Add(vacation);
            //                }
            //                catch
            //                {
            //                MessageBox.Show("All fields are not fieled in ETT", "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
            //                }

            //            }
            //            else
            //            {
            //                if((cbxTripType.SelectedItem != null))
            //                {
            //                    TripTypes tripType = (TripTypes)Enum.Parse(typeof(TripTypes), cbxTripType.SelectedItem.ToString());
            //                    Trip trip = new(tripType, destination, country, travlers);
            //                    travelManager.AddTravel(trip);
            //                    currentUser.GetTravels().Add(trip);
            //                }
            //                else
            //                {
            //                    MessageBox.Show("All fields are not fieled in TVÅ", "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
            //                }
            //            }

            //    }
            //    catch
            //    {
            //        MessageBox.Show("All fields are not fieled in TRE" , "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Something is worng with the travel input. You have to fill in this box with only numbers and if you are more then 10 persons in your trips you have to call us.", "Registrering failed", MessageBoxButton.OK, MessageBoxImage.Error);
            //}





            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType().Name == "TravelsWindow")
                {
                    window.Show();
                    
                }
                
            }
            ((TravelsWindow)this.Owner).UpdateTravelList();
            this.Close();

            
        }

        private void cbxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbxType.SelectedItem.ToString() == "Vacation")
            {
                chbAllInclusive.Visibility = Visibility.Visible;
                lblTripOrAllinclusive.Visibility = Visibility.Visible;
                lblTripOrAllinclusive.Content = "All inclusive";
                cbxTripType.Visibility = Visibility.Hidden;

            }
            else
            {
                cbxTripType.Visibility = Visibility.Visible;
                lblTripOrAllinclusive.Visibility = Visibility.Visible;
                lblTripOrAllinclusive.Content = "Trip";
                chbAllInclusive.Visibility = Visibility.Hidden;

            }


        }

    }
}
