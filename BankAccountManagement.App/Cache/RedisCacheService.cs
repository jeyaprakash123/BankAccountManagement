using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace BankAccountManagement.Application.Cache
{
    public class RedisCacheService
    {
        private readonly IDistributedCache _cache;
        public RedisCacheService(IDistributedCache cache)
        { 
            _cache = cache;
        }
        
        public async Task SendDataAsync<T>(string key, T value,TimeSpan expiration)
        {
            var jsonData = JsonSerializer.Serialize(value);
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(expiration);

            await _cache.SetStringAsync(key, jsonData, options);
        }
        public async Task<T> GetDataAsync<T>(string key)
        {
            var jsonData = await _cache.GetStringAsync(key);
            return jsonData!=null ? JsonSerializer.Deserialize<T>(jsonData) : default;
        }

        public async Task RemoveDataAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

    }
}
