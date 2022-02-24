namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers
{
    public class MvcInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                options.UseNamespaceRouteToken();
            });
        }
    }
}
