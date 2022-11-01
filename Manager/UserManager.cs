using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Users;

namespace TravelPal.Manager
{
    public class UserManager
    {
        public List<IUser> users { get; set; } = new();
        public IUser signedInUser { get; set; }
       

        //Om användarnamn+lösen uppfyller kraven läggs usern till i listan users
        public bool addUser(IUser user)
        {
            //Lägg till använndare i listan
            if (validateUsername(user.UserName))
            {
                users.Add(user);
                return true;
            }
            else
            {
                MessageBox.Show("Oh no, the username is alredy taken. Please try again! ♡", "Username taken", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

        }

        

        public bool updateUser(IUser user, string newName)
        {
        //Uppdatera användare i listan
            return true;
        }
        
        //Kontrollera om användarnamn är tillgängligt
        private bool validateUsername(string newName)
        {
        
            foreach (IUser user in users)
            {
                if(user.UserName == newName)
                {
                    return false;
                }
               
            }   
            return true;
        }

        //Kontrollera om användarnamn och lösenord är en inlagd användare och isåfall logga in personen->skicka till travelwindow
       //Om inte felmeddelande, cleara och be användaren skriva in uppgifter på nytt
        public bool signInUser(string username, string password)
        {
        
            foreach(IUser useriListan in users)
            {
                if(username == useriListan.UserName && password == useriListan.Password)
                {
                    signedInUser = useriListan;
                    return true;
                }
            }

            return  false;
        }
    }

    
}
