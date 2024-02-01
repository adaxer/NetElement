using eHubApi.Data;
using eHubApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace eHubApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DebugController : Controller
{
    private readonly ILogger<DebugController> _logger;
    private readonly LogContext _db;

    public DebugController(ILogger<DebugController> logger, LogContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Log()
    {
        var body = await GetRawBodyAsync(Request);
        var entry = new LogEntry { Id=Guid.NewGuid(), Message=$"Log with Body: {body}" };
        _db.Logs.Add(entry);
        await _db.SaveChangesAsync();
        return Ok();
    }

    async Task<string> GetRawBodyAsync(HttpRequest request)
    {
        if (!request.Body.CanSeek)
        {
            // We only do this if the stream isn't *already* seekable,
            // as EnableBuffering will create a new stream instance
            // each time it's called
            request.EnableBuffering();
        }

        request.Body.Position = 0;

        var reader = new StreamReader(request.Body, Encoding.UTF8);

        var body = await reader.ReadToEndAsync().ConfigureAwait(false);

        request.Body.Position = 0;

        return body;
    }

}
