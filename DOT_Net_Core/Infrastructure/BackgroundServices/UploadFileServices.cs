using Infestation.Infrastructure.Services.Implementations;
using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.BackgroundServices
{
    public class UploadFileService : BackgroundService
    {
        private IFileProcessingChannel _channel { get; }
        //private IExampleRestClient _restClient { get; }

        private IServiceScopeFactory _scopeFactory { get; }

        public UploadFileService(IFileProcessingChannel channel, IServiceScopeFactory scopeFactory)
        {
            _channel = channel;
            //_restClient = restClient;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IExampleRestClient>();

                await foreach (var file in _channel.GetAllAsync())
            {
                    context.UploadFile(file);
            }

            
            }

        }


    }
}
