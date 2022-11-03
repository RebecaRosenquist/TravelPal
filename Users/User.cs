using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Travels;

namespace TravelPal.Users
{
    public class User : IUser
    {
        public List<Travel> travels { get; set; } = new();
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;

        public Countries Location { get; set; }

        //deklarerar props
        public void IUser(string username, string password, Countries location)
        {
            UserName = username;
            Password = password;
            Location = location;
        }

        //hämtar listan med userns resor
        public List<Travel> GetTravels()
        {
            return travels;
        }
    }

    

    
}
