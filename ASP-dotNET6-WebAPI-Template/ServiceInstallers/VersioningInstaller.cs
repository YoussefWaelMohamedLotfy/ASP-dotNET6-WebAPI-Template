using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers;

public class VersioningInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = ApiVersion.Default;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new MediaTypeApiVersionReader("version"),
                new HeaderApiVersionReader("X-Version")    
            );
            options.ReportApiVersions = true;
        });
    }
}
