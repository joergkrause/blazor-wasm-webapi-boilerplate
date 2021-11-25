using Workshop.Blazor.DataTransferObjects;

namespace Workshop.Blazor.BusinessLogicLayer
{
  public interface IEventManager
  {
    Task<bool> AddOrUpdateEventAsync(EventDto evt);
    IEnumerable<EventDto> GetAllEvents();
    EventDto? GetEventById(int id);
    Task<bool> RemoveEventAsync(EventDto evt);
  }
}