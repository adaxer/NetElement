using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Http.Logging;
using System.Text;
using System.Xml.Serialization;

namespace eHubApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PickListController : ControllerBase
{
    private readonly ILogger<PickListController> _logger;
    private readonly IPickListService _pickListService;
    private readonly IHttpClientFactory _clientFactory;

    public PickListController(ILogger<PickListController> logger, IPickListService pickListService, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _pickListService = pickListService;
        _clientFactory = clientFactory;
    }

    [HttpPost("[action]/{id}")]
    public Task<IActionResult> PickErrorDemo([FromQuery] bool sort, [FromHeader] string lang, [FromRoute] int id, [FromBody] PickListComplete pickList)
    {
        string info = $"Params: id: {id}, sort: {sort}, lang: {lang}, pickList: {pickList}";
        _logger.LogWarning(info);
        IActionResult result = Ok();
        return Task.FromResult(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> PickError([FromBody] PickListComplete pickList)
    {
        var error = _pickListService.GetPickError(pickList);
        if (error.PICK_ERR_SEG.Any())
        {
            var serializer = new XmlSerializer(typeof(PICK_ERROR));
            StringBuilder sb = new StringBuilder();
            var writer = new StringWriter(sb);
            serializer.Serialize(writer, error);
            using var client = _clientFactory.CreateClient("Debug");
            try
            {
                await client.PostAsync("Log", new StringContent(sb.ToString()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cant post");
            }
        }
        return Ok(error);
    }

    //public Task<IActionResult> Umbau()
    //{
    //    Job innertask = new Job(Method);
    //    Job.OnCompleted +=
    //    {
    //        Job nextJob = new Job(Method2);
    //        nextJob.OnCompleted +=
    //        {
    //            return Ok();
    //        }
    //    }
    //    innertask.Start();
    //    return innertask;
    //}
}
