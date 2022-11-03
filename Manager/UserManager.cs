using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Travels;
using TravelPal.Users;

namespace TravelPal.Manager
{
    public class UserManager
    {
        public List<IUser> users { get; set; } = new();
        public IUser SignedInUser { get; set; }
       

        //Kontroll om användarnamnet är tillgängligt (validateUsername) -> lägger till användare i listan
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
                MessageBox.Show("Oh no, the username is alredy taken. Please try again! ♡", "Username taken", MessageBoxButton.OK);
                return false;
            }

        }

        
        //Uppdaterar nya uppgifter på användaren (tillagda i userwindow)
        public bool updateUser(IUser user)
        {
            //Uppdatera användare i listan
            if (validateUsername(user.UserName) || user.UserName == SignedInUser.UserName)
            {
                SignedInUser.UserName = user.UserName;
                SignedInUser.Password = user.Password;
                SignedInUser.Location = user.Location;
                return true;
            }
            return false;
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

        //Kontrollera om användarnamn och lösenord är en användare från listan -> logga in personen->skicka till travelwindow
        public bool SignInUser(string username, string password)
        {
        
            foreach(IUser useriListan in users)
            {
                if(username == useriListan.UserName && password == useriListan.Password)
                {
                    SignedInUser = useriListan;
                    return true;
                }
            }

            return  false;
        }

        //Tar bort resa ifrån användarens lista samt listview (user+admin)
        public void RemoveTravelFromUser(Travel travelToRemove)
        {
            
            if (SignedInUser is User)
            {
                User user = SignedInUser as User;
                user.travels.Remove(travelToRemove);
            }
           
            else if (SignedInUser is Admin)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i] is User)
                    {
                        User selectedUser = users[i] as User;



                        for (int j = 0; j < selectedUser.travels.Count; j++)
                        {
                            if (selectedUser.travels[j].Equals(travelToRemove))
                            {
                                selectedUser.travels.Remove(travelToRemove);
                            }
                        }
                    }
                }

            }
        }
    }


    
}
