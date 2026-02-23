using System;
using System.Configuration;

namespace App_Finanças
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting basic tests...");

            var repo = new UserRepository();
            var hash = new HashService();

            string name = "Test User";
            string email = "test@example.com";
            string password = "Password123!";
            string phone = "123456";

            string hashed = hash.Hash(password);
            var user = new Users(name, email, hashed, phone);
            repo.AddUser(user);

            var fetched = repo.GetByEmail(email);
            Console.WriteLine(fetched != null ? "User found in repo" : "User not found");

            bool verified = hash.Verify(password, fetched.HashPassword);
            Console.WriteLine("Password verification: " + verified);

            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(email);
            Console.WriteLine("Generated token: " + token);
            
            try
            {
                var auth = new Authentication();
                bool authResult = auth.Authenticate(email, password);
                Console.WriteLine("Authentication.Authenticate result: " + authResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Authentication.Authenticate threw: " + ex.GetType().Name + " - " + ex.Message);
            }
            
            try
            {
                var emailService = new EmailService();
                emailService.SendEmail("destino@exemplo.com", "Test", "Body");
                Console.WriteLine("EmailService.SendEmail executed. SmtpServer: " + ConfigurationManager.AppSettings["SmtpServer"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("EmailService.SendEmail threw: " + ex.GetType().Name + " - " + ex.Message);
            }

            Console.WriteLine("Tests finished. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
