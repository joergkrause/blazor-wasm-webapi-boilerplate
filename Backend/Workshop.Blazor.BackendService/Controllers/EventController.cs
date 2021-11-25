using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop.Blazor.BusinessLogicLayer;
using Workshop.Blazor.DataTransferObjects;

namespace Workshop.Blazor.BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Produces("application/json")]
    public class EventController : ControllerBase
    {

        private readonly EventManager _manager;

        public EventController(EventManager manager) {
            _manager = manager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EventDto>))]
        public IActionResult Get() {
            var dto = _manager.GetAllEvents();
            return Ok(dto);
        }

        [HttpGet]
        [Route("{id:int}")] // api/event/23
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EventDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id) {
            var dto = _manager.GetEventById(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

    }
}
