using ASP_dotNET6_WebAPI_Template;
using ASP_dotNET6_WebAPI_Template.DataAccess;
using ASP_dotNET6_WebAPI_Template.Extensions;
using ASP_dotNET6_WebAPI_Template.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

if (builder.Environment.IsDevelopment())
    builder.Services.AddHostedService<TunnelService>();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

app.MigrateDatabase<ApplicationDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<ApplicationDbContextSeeder>>();
    ApplicationDbContextSeeder.SeedAsync(context, logger!).Wait();
});

startup.Configure(app, app.Environment);

app.Run();
