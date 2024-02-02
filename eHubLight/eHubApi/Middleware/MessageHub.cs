using Microsoft.AspNetCore.SignalR;

namespace eHubApi.Middleware;

public class MessageHub : Hub
{
    public async Task Send(string message)
    {
        await Clients.All.SendAsync("send", message);
    }
}
