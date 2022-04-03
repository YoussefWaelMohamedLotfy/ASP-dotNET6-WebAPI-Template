using ASP_dotNET6_WebAPI_Template.Models;
using ASP_dotNET6_WebAPI_Template.Services;

namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers;

public class RedisCacheInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        RedisCacheSettings cacheSettings = new();
        configuration.GetSection(nameof(RedisCacheSettings)).Bind(cacheSettings);
        services.AddSingleton(cacheSettings);

        if (!cacheSettings.IsEnabled)
            return;

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = cacheSettings.ConnectionString;
        });

        services.AddHttpCacheHeaders(
            validationModelOptions =>
            {
                validationModelOptions.MustRevalidate = true;
            });

        services.AddSingleton<IResponseCacheService, ResponseCacheService>();
    }
}

