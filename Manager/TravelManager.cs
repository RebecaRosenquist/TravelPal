using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Travels;

namespace TravelPal.Manager
{
    public class TravelManager
    {
        public List<Travel> Travels { get; set; } = new();

        //Informationen från den nya resan läggs till i travel-listan kopplad till specifik user
        public void AddTravel(Travel travel)
        {
            Travels.Add(travel);
        }

        //Tar bort en resa ifrån listan Travels
        public void RemoveTravel(Travel travel)
        {
            Travels.Remove(travel);
        }
    }
}
