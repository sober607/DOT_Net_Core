using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.BackgroundServices
{
    public static class CacheAssistant
    {
        public static string CacheKey { get; set; }

        public static string GenerateImageCacheKey()
        {
            CacheKey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";
            return CacheKey;
        }
    }
}
