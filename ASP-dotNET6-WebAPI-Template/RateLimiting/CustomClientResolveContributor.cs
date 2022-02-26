using AspNetCoreRateLimit;

namespace ASP_dotNET6_WebAPI_Template.RateLimiting;

public class CustomClientResolveContributor : IClientResolveContributor
{
    public Task<string> ResolveClientAsync(HttpContext httpContext)
    {
        var customHeaderValue = string.Empty;

        if (httpContext.Request.Headers.TryGetValue("Custom-Header", out var values))
        {
            customHeaderValue = values.First();
        }

        return Task.FromResult(customHeaderValue);
    }
}
