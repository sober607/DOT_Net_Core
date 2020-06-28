using Infestation.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Channels;
using Infestation.Infrastructure.Services.Implementations;
using Infestation.ViewModels;
using Infestation.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Infestation.Infrastructure.BackgroundServices;

namespace Infestation.Controllers
{
    public class TerrainController:Controller
    {
        private IMemoryCache _cache { get; }
        
        private IExampleRestClient _restClient { get; }

        private FileProcessingChannel _channel { get;  }

        private InfestationConfiguration _options { get; set; }

        public TerrainController(IMemoryCache cache, IExampleRestClient restClient, FileProcessingChannel channel, IOptions<InfestationConfiguration> options)
        {
            _cache = cache;
            _restClient = restClient;
            _channel = channel;
            _options = options.Value;
        }

        [AllowAnonymous]
        public FileContentResult Image()
        {
            var cacheKey = CacheAssistant.GenerateImageCacheKey();
            var image = _cache.Get<byte[]>(cacheKey);
            if (image == null)
            {
                var entryOptions = new MemoryCacheEntryOptions();
                entryOptions.SlidingExpiration = TimeSpan.FromMinutes(_options.DownloadFileCacheExpirationTimeMinutes);
                image = _restClient.GetFile();
                _cache.Set<byte[]>(cacheKey, image, entryOptions);
            }

            return new FileContentResult(image, "image/jpeg");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Upload(TerrainUploadViewModel uploadfile)
        {
            if (uploadfile.File?.Length > 0)
            {
                await _channel.SetAsync(uploadfile.File);

                uploadfile.Stage = UploadStage.Completed;
                uploadfile.File = null;
            }

            return View(uploadfile);
        }
    }
}