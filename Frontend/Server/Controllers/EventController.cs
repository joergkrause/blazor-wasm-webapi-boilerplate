using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop.Blazor.Frontend.Server.ServiceProxy;

namespace Workshop.Blazor.Frontend.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EventController : ControllerBase
  {

    private readonly IBackendService _serviceProxy;
    private readonly ILogger<EventController> _logger;

    public EventController(IBackendService serviceProxy, ILogger<EventController> logger)
    {
      _serviceProxy = serviceProxy;
      _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EventDto>))]
    public async Task<IActionResult> Get()
    {
      var dto = await _serviceProxy.EventAllAsync();
      return Ok(dto);
    }

    [HttpGet]
    [Route("{id:int}")] // api/event/23
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
      var dto = await _serviceProxy.EventAsync(id);
      if (dto == null)
      {
        return NotFound();
      }
      return Ok(dto);
    }

  }
}
