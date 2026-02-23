using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças
{
    public class Authentication
    {
        private readonly UserRepository userRepository;
        private readonly HashService hashService;
        public bool Authenticate(string email, string password)
        {

            var user = userRepository.GetByEmail(email);
            
            if (user == null)
            {
                return false;
            }

            if(!hashService.Verify(password, user.HashPassword))
            {
                return false;
            }

            return true;

        }
        internal class InternalAuthentication
        {
        }
    }
}
