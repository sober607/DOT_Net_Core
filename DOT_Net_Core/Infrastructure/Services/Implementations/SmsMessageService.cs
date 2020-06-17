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

        
        const string accountSid = "AC633e5a38123583d447c7a12328a23392";
        const string authToken = "64934dc444254a8db94737c820c9bfce";

        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            body: "Hi there!",
            from: new Twilio.Types.PhoneNumber("+12563914660"),
            to: new Twilio.Types.PhoneNumber("+380638578649")
        );

        Console.WriteLine(message.Sid);
        }
    }
}
