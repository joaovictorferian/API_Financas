using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças
{
    public class Registers
    {
        public void RegisterUser(string name, string email, string password, string phone)
        {

            var repository = new UserRepository();
            var hashService = new HashService();
            if (repository.GetByEmail(email) != null)
            {
                throw new Exception("Email já cadastrado!");
            }

            string hashPassword = hashService.Hash(password);

            Users newUser = new Users(name, email, hashPassword, phone);

            repository.AddUser(newUser);
        }

        internal class Register
        {
        }
    }
}
