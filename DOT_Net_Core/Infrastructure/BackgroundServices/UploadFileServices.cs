using Infestation.Infrastructure.Services.Implementations;
using Infestation.Infrastructure.Services.Interfaces;
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
        private FileProcessingChannel _channel { get; }
        private IExampleRestClient _restClient { get; }


        public UploadFileService(FileProcessingChannel channel, IExampleRestClient restClient)
        {
            _channel = channel;
            _restClient = restClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var file in _channel.GetAllAsync())
            {
                _restClient.UploadFile(file);
            }
        }
    }
}
