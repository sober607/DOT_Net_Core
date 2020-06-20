using MailKit.Net.Smtp;
using MimeKit;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infestation.Infrastructure.Services.Implementations
{
    public class MessageService : IMessageService
    {
        public IConfiguration _configuration { get; set; }
        public MessageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public void SendMessage(string type)
        {
            if (type == "email")
            {
                this.SendEmail();
            }
            else if (type == "sms")
            {
                this.SendSms();
            }
        }

        public void SendEmail()
        {
            //add email message
            MimeMessage message = new MimeMessage();
            var from = new MailboxAddress("Admin", _configuration.GetValue<string>("EmailAddress"));
            message.From.Add(from);

            var to = new MailboxAddress("User", "sober607@gmail.com");
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


        public void SendSms()
        {

            TwilioClient.Init(_configuration.GetValue<string>("TwilioAccountSid"), _configuration.GetValue<string>("TwilioAccountAuthToken"));

            var message = MessageResource.Create(
                body: "Hi there!",
                from: new Twilio.Types.PhoneNumber("+12563914660"),
                to: new Twilio.Types.PhoneNumber("+380638578649")
            );

            Console.WriteLine(message.Sid);
        }

    }
}
