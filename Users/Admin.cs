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

        //public Admin(TravelManager tManager)
        //{
        //    travelManager = tManager;
        //}

        //
        public void IUser(string username, string password, Countries location)
        {
            UserName = username;
            Password = password;
            Location = location;
        }

        // 
        public List<Travel> GetTravels()
        {
            return travelManager.Travels;
                
        }
    }
}
