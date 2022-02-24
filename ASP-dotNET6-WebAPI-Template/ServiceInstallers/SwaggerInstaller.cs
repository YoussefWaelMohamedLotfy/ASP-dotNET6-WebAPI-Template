using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers
{
    public class SwaggerInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(swaggerOptions =>
            {
                swaggerOptions.ExampleFilters();

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerOptions.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }
    }
}
