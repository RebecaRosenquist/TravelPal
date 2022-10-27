using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Users
{
    public class Admin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Countries Location { get; set; }

        public void IUser(string username, string password, Countries location)
        {
            UserName = username;
            Password = password;
            Location = location;
        }
    }
}
