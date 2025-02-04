using Microsoft.Extensions.Caching.Memory;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedKernel.Main.Infrastructure.Services;

public class Cache : ICacheService
{
    const int DEFAULT_CACHE_DURATION_MINUTES = 20; //minutes
    private readonly IMemoryCache _cache;

    public Cache(IMemoryCache cache)
    {
        _cache = cache;
    }
    public void Set<T>(string key, T value, TimeSpan? expirationTime = null)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions();

        if (expirationTime.HasValue)
        {
            cacheEntryOptions.SetAbsoluteExpiration(expirationTime.Value);
        }
        else
        {
            cacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(DEFAULT_CACHE_DURATION_MINUTES));
        }

        _cache.Set(key, value, cacheEntryOptions);
    }

    public T? Get<T>(string key)
    {
        if (_cache.TryGetValue(key, out T? value))
        {
            return value;
        }

        return default(T);
    }

    public void Remove(string key)
    {
        _cache.Remove(key);
    }

    public bool Has(string key)
    {
        return _cache.TryGetValue(key, out _);
    }
}