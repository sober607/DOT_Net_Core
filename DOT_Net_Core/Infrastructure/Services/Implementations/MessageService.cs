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
using Microsoft.Extensions.Options;
using Infestation.Infrastructure.Configuration;

namespace Infestation.Infrastructure.Services.Implementations
{
    public class MessageService : IMessageService
    {
        public IConfiguration _configuration { get; set; }
        public InfestationConfiguration _options { get; set; }
        public MessageService(IConfiguration configuration, IOptions<InfestationConfiguration> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }



        public void SendMessage(string type, string text)
        {
            if (type == "email")
            {
                this.SendEmail(text);
            }
            else if (type == "sms")
            {
                this.SendSms(text);
            }
        }

        public void SendEmail(string text)
        {
            //add email message
            MimeMessage message = new MimeMessage();
            var from = new MailboxAddress("Admin", _options.Notification.Email.SenderEmail);
            message.From.Add(from);

            var to = new MailboxAddress("User", _options.Notification.Email.SenderEmail);
            message.To.Add(to);

            message.Subject = _options.Notification.Email.DefaultEmailSubject;

            // add email body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = text;
            message.Body = bodyBuilder.ToMessageBody();

            // send message
            using (SmtpClient client = new SmtpClient())
            {
                Console.WriteLine($"Email {_options.Notification.Email.SenderEmail}, smtp {_options.Notification.Email.GoogleSmptServer}, login {_options.Notification.Email.AuthenticationEmail}, password {_options.Notification.Email.AuthenticationEmailPassword}");
                client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                client.Connect(_options.Notification.Email.GoogleSmptServer, 465, true);
                client.Authenticate(_options.Notification.Email.AuthenticationEmail, _options.Notification.Email.AuthenticationEmailPassword);

                client.Send(message);
                client.Disconnect(true);
            }



        }


        public void SendSms(string text)
        {

            TwilioClient.Init(_options.Notification.Sms.TwilioAccountSid, _options.Notification.Sms.TwilioAccountAuthToken);

            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber(_options.Notification.Sms.TwilioSenderNumber),
                to: new Twilio.Types.PhoneNumber(_options.Notification.Sms.DefaultReceiverNumber)
            );

            Console.WriteLine(message.Sid);
        }

    }
}
