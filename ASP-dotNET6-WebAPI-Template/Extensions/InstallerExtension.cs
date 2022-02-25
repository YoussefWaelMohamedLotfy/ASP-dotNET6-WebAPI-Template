using ASP_dotNET6_WebAPI_Template.ServiceInstallers;

namespace ASP_dotNET6_WebAPI_Template.Extensions;

public static class InstallerExtension
{
    public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(Startup));

        var installers = typeof(Startup).Assembly.ExportedTypes
            .Where(t => typeof(IServiceInstaller).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IServiceInstaller>().ToList();

        installers.ForEach(installer => installer.InstallServices(services, configuration));
    }
}
