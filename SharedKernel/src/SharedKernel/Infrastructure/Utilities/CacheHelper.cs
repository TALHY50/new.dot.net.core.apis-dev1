
using Microsoft.Extensions.Caching.Memory;

namespace SharedKernel.Infrastructure.Utilities
{
#pragma warning disable CS8603 // Possible null reference argument.
    public static class CacheHelper
    {
        private static readonly  MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        public static void Set(string key, object value, int time_in_sec)
        {
            _cache.Set(key, value, DateTimeOffset.Now.AddMinutes(time_in_sec));
        }
        public static object Get(string key)
        {
            return _cache.Get(key);
        }
        public static bool Exist(string uniqueKey)
        {
            return _cache.TryGetValue(uniqueKey, out _);
        }
        public static void Remove(string key)
        {
            _cache.Remove(key); 
        }

    }
}
