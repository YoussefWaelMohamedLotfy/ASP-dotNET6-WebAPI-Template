using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Xml;

namespace ASP_dotNET6_WebAPI_Template.Extensions;

public static class HealthCheckExtension
{
    public static void MapCustomHealthChecks(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
        {
            ResultStatusCodes = {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status503ServiceUnavailable,
                    [HealthStatus.Unhealthy] = StatusCodes.Status500InternalServerError,
                },
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            Predicate = (check) => check.Tags.Contains("ready"),
            AllowCachingResponses = false
        });

        endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
        {
            Predicate = (check) => !check.Tags.Contains("ready"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            AllowCachingResponses = false
        });

    }
}
