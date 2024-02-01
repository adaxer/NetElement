using Microsoft.AspNetCore.Mvc;

namespace eHubApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PickListController : ControllerBase
{
    private readonly ILogger<PickListController> _logger;

    public PickListController(ILogger<PickListController> logger)
    {
        _logger = logger;
    }

    [HttpPost("[action]/{id}")]
    public Task<IActionResult> PickError([FromQuery] bool sort, [FromHeader] string lang, [FromRoute] int id, [FromBody] PickListComplete pickList)
    {
        string info = $"Params: id: {id}, sort: {sort}, lang: {lang}, pickList: {pickList}";
        _logger.LogWarning(info);
        IActionResult result = Ok();
        return Task.FromResult(result);
    }
}
