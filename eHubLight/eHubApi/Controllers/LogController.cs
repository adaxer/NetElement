using eHubApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eHubApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogController : Controller
{
    public LogController(LogContext context)
    {
        Context = context;
    }

    LogContext Context { get; }

    [HttpGet("[action]/{count}")]
    public async Task<IActionResult> List(int count)
    {
        var result = await Context.Logs.Take(count).ToListAsync();
        return Ok(result);
    }
}
