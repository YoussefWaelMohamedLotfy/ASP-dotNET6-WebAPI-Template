using ASP_dotNET6_WebAPI_Template.DataAccess;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers;

public class HealthCheckInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddSqlServer(
                configuration.GetConnectionString("SqlServerConnection"),
                name: "SQL Server Connection Check",
                failureStatus: HealthStatus.Degraded,
                tags: new[] { "ready" })
            .AddRedis(
                configuration.GetConnectionString("RedisConnection"),
                name: "Redis Cache Connection Check",
                failureStatus: HealthStatus.Degraded,
                tags: new[] { "ready" })
            .AddDbContextCheck<ApplicationDbContext>(
                "ApplicationDbContext EF Core Check",
                failureStatus: HealthStatus.Degraded,
                tags: new[] { "ready" })
            .AddUrlGroup(
                new Uri("https://www.google.com"),
                name: "External URL Check",
                failureStatus: HealthStatus.Degraded,
                timeout: TimeSpan.FromSeconds(5),
                tags: new[] { "live" });
            
    }
}
