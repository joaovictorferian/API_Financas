using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças
{
    public class Users
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string HashPassword { get; private set; }
        public string Phone { get; private set; }

        public Users(string name, string email, string hashPassword, string phone)
        {
            Name = name;
            Email = email;
            HashPassword = hashPassword;
            Phone = phone;
        }

        internal class User
        {
            static void Main(string[] args)
            {
            }
        }
    }
}
