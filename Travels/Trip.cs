using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Travels
{
    public class Trip : Travel
    {
        public TripTypes Type { get; set; }

        public Trip(TripTypes types, string destination, Countries country, int travellers) : base(destination, country, travellers)
        {

            Type = types;

        }

        //Har inte haft användning av denna?
        public string GetInfo()
        {
            return "";
        }
    }
}
