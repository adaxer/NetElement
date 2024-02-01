

using eHubApi.Data;
using eHubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eHubApi;

public class CleanupDataBaseService : IHostedService
{
    private readonly ILogger<CleanupDataBaseService> _logger;
    private readonly IServiceProvider _provider;
    private bool _isRunning;

    public CleanupDataBaseService(ILogger<CleanupDataBaseService> logger, IServiceProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Run();
        return Task.CompletedTask;
    }

    private async void Run()
    {
        while (true)
        {
            await Task.Delay(5000);
            //   if(Uhrzeit, aktiv-flag setzen usw...)
            try
            {
                await CleanupDatabase();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Job failed: {ex}");
            }
            finally
            {
                _isRunning = false;
            }
        }
    }

    private async Task CleanupDatabase()
    {
        if(_isRunning)
        {
            return;
        }
        _isRunning = true;

        using var scope = _provider.CreateScope();
        var db = scope.ServiceProvider.GetService<LogContext>()!;
        db.Logs.Add(new LogEntry { Message = "Cleanup active" });
        await db.SaveChangesAsync();
        List<LogEntry> logs = new();
        int readCount = 0;
        if (File.Exists("Logs.txt"))
        {
            File.Delete("Logs.txt");
        }

        do
        {
            logs = await db.Logs.Skip(readCount).Take(20).ToListAsync();
            await File.AppendAllLinesAsync("Logs.txt", logs.Select(l => $"{l.Created}: {l.Message}"));
            readCount += logs.Count;
        } while (logs.Count() > 0);
        _isRunning = false;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}