using ASP_dotNET6_WebAPI_Template.Services;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers;

public class MvcInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSignalR();

        services.AddControllers(options =>
        {
            options.UseNamespaceRouteToken();
        })
        .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>())
        .AddXmlDataContractSerializerFormatters()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        services.AddHttpContextAccessor();

        services.AddSingleton<IUriService>(provider =>
        {
            var accessor = provider.GetRequiredService<IHttpContextAccessor>();
            var request = accessor.HttpContext!.Request;
            var absoluteUri = $"{request.Scheme}://{request.Host.ToUriComponent()}{request.Path}/";
            return new UriService(absoluteUri);
        });

    }
}
