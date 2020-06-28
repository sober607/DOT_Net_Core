using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Configuration
{
    public class InfestationConfiguration
    {
        public Notification Notification { get; set; }

        public double DownloadFileCacheExpirationTimeMinutes { get; set;}

        public double UploadFileCacheExpirationTimeMinutes { get; set; }

        public double DownloadFileExecuteTaskDelaySeconds { get; set; }

    }

    public class Notification
    {
        public Sms Sms { get; set; }

        public Email Email { get; set; }
        public bool IsEmailRequestLoggingEnabled { get; set; }
    }

    public class Sms
    {
        public string TwilioSenderNumber { get; set; }

        public string TwilioAccountSid { get; set; }

        public string TwilioAccountAuthToken { get; set; }

        public string DefaultReceiverNumber { get; set; }


    }

    public class Email
    {
        public string GoogleSmptServer { get; set; }

        public string SenderEmail { get; set; }

        public string AuthenticationEmail { get; set; }

        public string AuthenticationEmailPassword { get; set; }

        public string DefaultEmailSubject { get; set; }

    }
}
