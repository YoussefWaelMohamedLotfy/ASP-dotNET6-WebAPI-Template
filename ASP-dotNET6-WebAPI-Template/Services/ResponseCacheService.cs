using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace ASP_dotNET6_WebAPI_Template.Services;

public class ResponseCacheService : IResponseCacheService
{
    private readonly IDistributedCache _distributedCache;

    public ResponseCacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
    }

    public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
    {
        if (response is null)
            return;

        var serializedResponse = JsonSerializer.Serialize(response);
        await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = timeToLive,
        });
    }

    public async Task<string> GetCachedResponseAsync(string cacheKey)
    {
        string cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
        return cachedResponse ?? null!;
    }
}
