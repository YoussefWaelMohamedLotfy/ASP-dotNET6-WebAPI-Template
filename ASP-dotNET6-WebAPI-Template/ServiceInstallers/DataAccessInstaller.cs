using ASP_dotNET6_WebAPI_Template.DataAccess;
using ASP_dotNET6_WebAPI_Template.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers;

public class DataAccessInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
