using Infestation.Infrastructure.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Services.Implementations
{
    public class EmailMessageService : IMessageService
    {
        public IConfiguration _configuration { get; set; }
        public EmailMessageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void SendMessage()
        {
            //add email message
            MimeMessage message = new MimeMessage();
            var from = new MailboxAddress("Admin", _configuration.GetValue<string>("EmailAddress"));
            message.From.Add(from);

            var to  = new MailboxAddress("User", "sober607@gmail.com");
            message.To.Add(to);

            message.Subject = "Email from Admin";

            // add email body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Hello from Admin";
            message.Body = bodyBuilder.ToMessageBody();

            // send message
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(_configuration.GetValue<string>("EmailAddress"), _configuration.GetValue<string>("EmailPassword"));

                client.Send(message);
                client.Disconnect(true);
            }

        }
    }
}
