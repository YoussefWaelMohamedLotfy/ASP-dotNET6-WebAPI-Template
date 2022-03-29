namespace ASP_dotNET6_WebAPI_Template.Services;

public interface IResponseCacheService
{
    Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);

    Task<string> GetCachedResponseAsync(string cacheKey);
}
