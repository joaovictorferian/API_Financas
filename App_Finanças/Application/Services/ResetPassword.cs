using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App_Finanças
{

    public class ResetPassword
    {
        private readonly TokenService _tokenService;
        private readonly EmailService _emailService;
        private readonly HashService _hashService;

        public void RequestPasswordReset(string email)
        {
            string token = _tokenService.GenerateToken(email);

            string resetLink = $"https://localhost:5001/reset-password?token={token}";

            string emailBody = $"Clique no link para redefinir sua senha: <a href='{resetLink}'>Redefinir Senha</a>";

            _emailService.SendEmail(email, "Redefinição de Senha", emailBody);
        }

        public void ResetPasswordByToken(string token, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                throw new Exception("As senhas não coincidem!");
            }
            if (newPassword.Length < 8)
            {
                throw new Exception("As senhas não podem ter menos de 8 caracteres");
            }

            string email = _tokenService.GetEmailFromToken(token);

            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Não foi possível identificar o usuário");
            }

            _hashService.Hash(newPassword);
        }

    }
}
