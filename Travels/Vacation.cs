using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Travels
{
    public class Vacation : Travel
    {
        public bool IsAllInclusive { get; set; }

        public Vacation(bool isAllInclusive, string destination, Countries country, int travellers) : base(destination, country, travellers)
        {
            IsAllInclusive = isAllInclusive;
        }

        public string GetInfo()
        {
            return "";
        }
    }
}
