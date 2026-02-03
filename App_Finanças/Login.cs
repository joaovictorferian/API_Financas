using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças
{
    public class Login : Registers
    {
        private readonly Authentication authentication;
        public string UserLogin(string email, string password)
        {
            if(!authentication.Authenticate(email, password))
            {
                return "Falha no login: Email ou senha incorretos.";
            }

            return "Login realizado com sucesso!";
        }

    }
    internal class InternalLogin
    {
    }
}
