using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.BackgroundServices
{
    public static class CacheAssistant
    {
        public static string CacheKey { get; set; }

        public static Dictionary<String, DateTime> CacheFilesList { get; set; } = new Dictionary<String, DateTime>(); //String is File Name added to Cache, DateTime is UTC time when added


        public static string GenerateImageCacheKey()
        {
            CacheKey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";
            return CacheKey;
        }

        public static string GenerateImageCacheKey(string fileName)
        {
            CacheKey = $"image_{fileName}";
            return CacheKey;
        }
    }
}
