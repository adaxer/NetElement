

namespace eHubApi;

public class CleanupDataBaseService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Run();
        return Task.CompletedTask;
    }

    private async void Run()
    {
        while(true)
        {
            await Task.Delay(5000);
            //   if(Uhrzeit, aktiv-flag setzen usw...)
            Console.WriteLine($"CleanupDatabase aktive: {DateTime.UtcNow}");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}