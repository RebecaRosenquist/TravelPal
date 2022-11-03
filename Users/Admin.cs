using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Manager;
using TravelPal.Travels;

namespace TravelPal.Users
{
    public class Admin :IUser
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }
        public TravelManager travelManager { get; set; }

        public bool IsAdmin { get; set; } = true;
        public Admin(TravelManager tManager)
        {
            travelManager = tManager;
        }

        // Deklarerar props
        public void IUser(string username, string password, Countries location)
        {
            UserName = username;
            Password = password;
            Location = location;
        }

        // Hämtar listan med alla resor till admin
        public List<Travel> GetTravels()
        {
            return travelManager.Travels;
                
        }
    }
}
