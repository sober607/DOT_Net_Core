using Infestation.Infrastructure.Configuration;
using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
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

        //private IExampleRestClient _restClient { get; }
        private IServiceScopeFactory _scopeFactory { get; }

        private InfestationConfiguration _options { get; set; }


        public LoadFileService(IMemoryCache cache, IOptions<InfestationConfiguration> options, IServiceScopeFactory scopeFactory)
        {
            _cache = cache;
            _scopeFactory = scopeFactory;
            _options = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<IExampleRestClient>();
                    var image = context.GetFile();

                    if (image != null)
                    {
                        var cacheKey = CacheAssistant.GenerateImageCacheKey(context.FileName);

                        if (CacheAssistant.CacheFilesList != null) // check for expired elements in _cacheFilesList
                        {
                            foreach (var file in CacheAssistant.CacheFilesList)
                            {
                                if (DateTime.UtcNow.Subtract(file.Value).TotalMinutes > _options.UploadFileCacheExpirationTimeMinutes)
                                {
                                    CacheAssistant.CacheFilesList.Remove(file.Key);
                                }
                            }
                        }

                        if (!CacheAssistant.CacheFilesList.ContainsKey(cacheKey)) // adds image to cache if image is not present in cache
                        {
                            var entryOptions = new MemoryCacheEntryOptions();
                            entryOptions.SlidingExpiration = TimeSpan.FromMinutes(_options.UploadFileCacheExpirationTimeMinutes);
                            CacheAssistant.CacheFilesList.Add(cacheKey, DateTime.UtcNow);
                            _cache.Set<byte[]>(cacheKey, image, entryOptions);
                        }
                    }

                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
            }
        }


    }
}
