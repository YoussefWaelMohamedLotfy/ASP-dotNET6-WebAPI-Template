namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers;

public interface IServiceInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}
