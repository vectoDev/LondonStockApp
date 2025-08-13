using System;
using LondonStock.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace LondonStock.Application.Services
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<InMemoryCacheService> _logger;

        public InMemoryCacheService(IMemoryCache cache, ILogger<InMemoryCacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public T? Get<T>(string key)
        {
            if (_cache.TryGetValue(key, out var value) && value is T t)
            {
                _logger.LogDebug("Cache hit for key {Key}", key);
                return t;
            }

            _logger.LogDebug("Cache miss for key {Key}", key);
            return default;
        }

        public void Set<T>(string key, T value, TimeSpan expiry)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry
            };
            _cache.Set(key, value, options);
            _logger.LogDebug("Cache set for key {Key} with expiry {Expiry} seconds", key, expiry.TotalSeconds);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
            _logger.LogDebug("Cache removed for key {Key}", key);
        }
    }
}
