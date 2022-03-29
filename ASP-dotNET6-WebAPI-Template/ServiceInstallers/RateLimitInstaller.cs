using AspNetCoreRateLimit;
using AspNetCoreRateLimit.Redis;
using StackExchange.Redis;

namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers;

public class RateLimitInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.AddDistributedMemoryCache();

        services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
        services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

        // Uncomment the below and Comment the above two lines if you want Client Rate Limiting
        //services.Configure<ClientRateLimitOptions>(configuration.GetSection("ClientRateLimiting"));
        //services.Configure<ClientRateLimitPolicies>(configuration.GetSection("ClientRateLimitPolicies"));

        services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"),c => c.AbortOnConnectFail = false));
        services.AddRedisRateLimiting();

        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

        // Uncomment the following and Comment the previous line for Custom Rate Limit Configuration
        //services.AddSingleton<IRateLimitConfiguration, CustomRateLimitConfiguration>();
    }
}
