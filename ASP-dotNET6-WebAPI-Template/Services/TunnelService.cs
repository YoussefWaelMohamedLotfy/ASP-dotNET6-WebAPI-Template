using CliWrap;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System.Text.Json.Nodes;

namespace ASP_dotNET6_WebAPI_Template.Services;

public class TunnelService : BackgroundService
{
    private readonly IServer server;
    private readonly IHostApplicationLifetime hostApplicationLifetime;
    private readonly ILogger<TunnelService> logger;

    public TunnelService(
        IServer server,
        IHostApplicationLifetime hostApplicationLifetime,
        ILogger<TunnelService> logger
    )
    {
        this.server = server;
        this.hostApplicationLifetime = hostApplicationLifetime;
        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await WaitForApplicationStarted();

        var urls = server.Features.Get<IServerAddressesFeature>()!.Addresses;

        // Use https:// if you authenticated ngrok, otherwise, you can only use http://
        var localUrl = urls.Single(u => u.StartsWith("https://"));

        logger.LogInformation("Starting ngrok tunnel for {LocalUrl}", localUrl);
        var ngrokTask = StartNgrokTunnel(localUrl, stoppingToken);

        var publicUrl = await GetNgrokPublicUrl();
        logger.LogInformation("Public ngrok URL for API: {NgrokPublicUrl}", publicUrl);

        await ngrokTask;

        logger.LogInformation("Ngrok tunnel stopped");
    }

    private Task WaitForApplicationStarted()
    {
        var completionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        hostApplicationLifetime.ApplicationStarted.Register(() => completionSource.TrySetResult());
        return completionSource.Task;
    }

    private CommandTask<CommandResult> StartNgrokTunnel(string localUrl, CancellationToken stoppingToken)
    {
        var ngrokTask = Cli.Wrap("ngrok")
            .WithArguments(args => args
                .Add("http")
                .Add(localUrl)
                .Add("--log")
                .Add("stdout"))
            .WithStandardOutputPipe(PipeTarget.ToDelegate(s => logger.LogDebug(s)))
            .WithStandardErrorPipe(PipeTarget.ToDelegate(s => logger.LogError(s)))
            .ExecuteAsync(stoppingToken);

        return ngrokTask;
    }

    private async Task<string> GetNgrokPublicUrl()
    {
        using var httpClient = new HttpClient();

        for (var ngrokRetryCount = 0; ngrokRetryCount < 10; ngrokRetryCount++)
        {
            logger.LogDebug("Get ngrok tunnels attempt: {RetryCount}", ngrokRetryCount + 1);

            try
            {
                var json = await httpClient.GetFromJsonAsync<JsonNode>("http://127.0.0.1:4040/api/tunnels");
                var publicUrl = json!["tunnels"]!.AsArray()
                    .Select(node => node!["public_url"]!.GetValue<string>())
                    .SingleOrDefault(u => u.StartsWith("https://"));

                if (!string.IsNullOrEmpty(publicUrl))
                    return $"{publicUrl}/swagger";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Cannot open ngrok tunnel. Retrying...");
            }

            await Task.Delay(200);
        }

        throw new Exception("ngrok dashboard did not start in 10 tries");
    }
}
