using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças
{
    public class Login
    {
        private readonly Authentication authentication;
        private readonly TokenService tokenService;


        public string UserLogin(string email, string password)
        {
            var isValid = authentication.Authenticate(email, password);

            if (!isValid)
                return "Email ou senha incorretos";

            var token = tokenService.GenerateToken(email);

            return token;
        }

    }
    internal class InternalLogin
    {
    }
}
