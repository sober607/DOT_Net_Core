using Infestation.Infrastructure.Configuration;
using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.BackgroundServices
{
    public class LoadFileService: BackgroundService
    {
        private IMemoryCache _cache { get; }
        
        private IExampleRestClient _restClient { get; }

        private InfestationConfiguration _options { get; set; }


        public LoadFileService(IMemoryCache cache, IExampleRestClient restClient, IOptions<InfestationConfiguration> options)
        {
            _cache = cache;
            _restClient = restClient;
            _options = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var image = _restClient.GetFile();

                if (image != null)
                {
                    var cacheKey = CacheAssistant.GenerateImageCacheKey();

                    var entryOptions = new MemoryCacheEntryOptions();
                    entryOptions.SlidingExpiration = TimeSpan.FromMinutes(_options.UploadFileCacheExpirationTimeMinutes);

                    _cache.Set<byte[]>(cacheKey, image, entryOptions);
                }

                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }


    }
}
