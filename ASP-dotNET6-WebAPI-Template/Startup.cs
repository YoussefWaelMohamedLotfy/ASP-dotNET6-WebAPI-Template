using ASP_dotNET6_WebAPI_Template.Extensions;
using ASP_dotNET6_WebAPI_Template.Hubs;
using AspNetCoreRateLimit;
using Hangfire;

namespace ASP_dotNET6_WebAPI_Template;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Add services to the DI container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.InstallServicesInAssembly(Configuration);
    }

    /// <summary>
    /// Configure the middleware pipeline
    /// </summary>
    /// <param name="app">The Application Builder</param>
    /// <param name="env">The Host Environment</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseIpRateLimiting();
        //app.UseClientRateLimiting();

        if (env.IsDevelopment() || env.IsStaging())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Demo Swagger UI";

                c.SwaggerEndpoint("/swagger/v2.0/swagger.json", "v2.0 Docs");
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "v1.0 Docs");
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseHttpCacheHeaders();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<MessageHub>("/message");

            endpoints.MapControllers();
            endpoints.MapCustomHealthChecks();
            endpoints.MapHangfireDashboard();
        });
    }

}
