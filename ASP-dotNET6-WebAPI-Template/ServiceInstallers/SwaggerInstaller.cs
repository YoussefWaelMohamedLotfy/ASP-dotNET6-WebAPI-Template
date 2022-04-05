using ASP_dotNET6_WebAPI_Template.Swagger.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace ASP_dotNET6_WebAPI_Template.ServiceInstallers;

public class SwaggerInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swaggerOptions =>
        {
            swaggerOptions.ExampleFilters();

            swaggerOptions.AddSecurityDefinition("APIKey", new OpenApiSecurityScheme()
            {
                Name = "X-ApiKey",
                Description = "API Key Authorization header.",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
            });

            swaggerOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "APIKey" }
                    },
                    Array.Empty<string>()
                }
            });

            swaggerOptions.SwaggerDoc("v1.0",
                new OpenApiInfo
                {
                    Title = "API v1.0",
                    Description = "Demo for ASP.NET 6 Web API",
                    Version = "v1.0",
                    Contact = new OpenApiContact
                    {
                        Name = "Youssef Wael",
                        Email = "youssefwael8@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache 2.0",
                        Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                    }
                });

            swaggerOptions.SwaggerDoc("v2.0",
                    new OpenApiInfo
                    {
                        Title = "API v2.0",
                        Description = "Demo for ASP.NET 6 Web API. Use `MyAppSuperSecretKey` for Authorization",
                        Version = "v2.0",
                        Contact = new OpenApiContact
                        {
                            Name = "Youssef Wael",
                            Email = "youssefwael8@gmail.com",
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Apache 2.0",
                            Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                        }
                    });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            swaggerOptions.IncludeXmlComments(xmlPath);

            swaggerOptions.OperationFilter<AddVersionHeaderParameter>();

            swaggerOptions.UseApiEndpoints();
        });

        services.AddSwaggerExamplesFromAssemblyOf<Startup>();
    }
}
