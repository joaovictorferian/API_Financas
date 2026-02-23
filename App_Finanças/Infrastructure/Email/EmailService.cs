using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Org.BouncyCastle.Security;

namespace App_Finanças
{
    public class EmailService
    {
        private readonly TokenService tokenService;
        public void SendEmail(string to, string subject, string body)
        {
            string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            string email = ConfigurationManager.AppSettings["SenderEmail"];
            string portString = ConfigurationManager.AppSettings["Port"];
            string password = ConfigurationManager.AppSettings["Password"];

            if (!int.TryParse(portString, out int port))
            {
                port = 587;
            }

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(smtpServer));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect(smtpServer, port, SecureSocketOptions.StartTls);

                client.Authenticate(email, password);

                client.Send(message);

                client.Disconnect(true);
            }




        }
    }

}
