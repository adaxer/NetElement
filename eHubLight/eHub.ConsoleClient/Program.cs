
using Microsoft.AspNetCore.SignalR.Client;
using System.Data.Common;

namespace eHub.ConsoleClient;

internal class Program
{
    private static HubConnection? _connection;

    static async Task Main(string[] args)
    {
        await Console.Out.WriteLineAsync("<Enter> startet die Verbindung");
        Console.ReadLine();
        await InitSignalR();

        string input = "Hello SignalR";
        while (true)
        {
            await _connection!.SendAsync("send", input);
            input = Console.ReadLine()!;
        }
    }

    private static async Task InitSignalR()
    {
        _connection = new HubConnectionBuilder()
         .WithUrl("https://localhost:7021/messages")
         .WithAutomaticReconnect()
        .Build();

        _connection.On<string>("send", s =>
        {
            Console.WriteLine($"Server sends: {s}");
        });
        try
        {
            await _connection.StartAsync();
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync($"{ex}");
        }

    }
}
