using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças
{
    public class UserRepository
    {
        List<Users> usersList = new List<Users>();


        public Users GetByEmail(string email)
        {
            return usersList.FirstOrDefault(u => u.Email == email); 
        }

        public void AddUser(Users user)
        {
            usersList.Add(user);
        }   
    }   

}
