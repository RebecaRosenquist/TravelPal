﻿using System;
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
            Countries country = (Countries)Enum.Parse(typeof(Countries), cbxCountry.Text.ToString());
            string destination = txtDestination.Text;
            int travlers = Convert.ToInt32(txtTravlers.Text);

            if (cbxType.SelectedItem.ToString() == "Vacation")
            {
                bool isAllinclusive = (bool) chbAllInclusive.IsChecked;
                Vacation vacation = new(isAllinclusive, destination, country, travlers);
                travelManager.AddTravel(vacation);
                currentUser.GetTravels().Add(vacation);
            }
            else
            {
                TripTypes tripType = (TripTypes)Enum.Parse(typeof(TripTypes), cbxTripType.SelectedItem.ToString());
                Trip trip = new(tripType, destination, country, travlers);
                travelManager.AddTravel(trip);
                currentUser.GetTravels().Add(trip);
            }
            

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
