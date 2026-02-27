using App_Finanças.Infrastructure.Database;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças
{
    public class Registers
    {
        private readonly UserRepository userRepository;
        private readonly HashService hashService;
        public void RegisterUser(string name, string email, string password, string phone)
        {
            if (userRepository.GetByEmail(email) != null)
            {
                throw new Exception("Email já cadastrado!");
            }

            string hashPassword = hashService.Hash(password);

            Users newUser = new Users(name, email, hashPassword, phone);

            userRepository.AddUser(newUser);
        }
    }
}
