using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Infestation.Infrastructure.Services.Implementations
{
    public class SmsMessageService : IMessageService
    {
        IConfiguration _configuration { get; set; }
        public SmsMessageService (IConfiguration configuration)
        {
            _configuration = configuration;


        }

        public void SendMessage()
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
