using Infestation.Infrastructure.Configuration;
using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.Middlewares
{
    public class SendRequestNotificationMiddleWare
    {

        private RequestDelegate _next { get; set; }
        private IMessageService _messageServices { get; }

        public IConfiguration _configuration { get; set; }

        public InfestationConfiguration _options { get; set; }

        public SendRequestNotificationMiddleWare(RequestDelegate next, IMessageService messageService, IConfiguration configuration, IOptions<InfestationConfiguration> options)
        {
            this._next = next;
            this._messageServices = messageService;
            this._configuration = configuration;
            this._options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_options.Notification.IsEmailRequestLoggingEnabled)
            { 
            var hostOfRequest = context.Request.Host;
            string table = "";
            foreach (var header in context.Request.Headers)
            {
                table += $"{header.Key}: {header.Value}\n";
            }

            var queryOfRequest = "";
            foreach (var query in context.Request.Query)
            {
                queryOfRequest += $"{query.Key}: {query.Value}\n";
            }

            var contentTypeOfRequest = "";
            foreach (var contenttype in contentTypeOfRequest)
            {
                contentTypeOfRequest += contenttype.ToString() + "\n";
            }

            var protocolOfRequest = context.Request.Protocol;
            var date = DateTime.Now;

            var message = (new StringBuilder($"Host is {context.Request.Host}\n Headers: {table},\n Query: {queryOfRequest},\n Content Type:  {contentTypeOfRequest},\n  Protocol: {protocolOfRequest},\n Date: {date}")).ToString();
            _messageServices.SendMessage("email", message);
            }
            await _next(context);

        }

    }
}
