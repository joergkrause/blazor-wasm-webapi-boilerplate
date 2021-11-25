using AutoMapper;
using Workshop.Blazor.Frontend.Client.ViewModels;
using Workshop.Blazor.ServiceProxy;

namespace Workshop.Blazor.Frontend.Client.Services
{

  /// <summary>
  /// TODO: Cache / Error Handling / Update via Socket / ...
  /// </summary>
  public class DataService
  {

    private readonly IClientService _clientService;
    private readonly IMapper _mapper;

    public DataService(IClientService clientService)
    {
      _clientService = clientService;
      var mapperConfiguration = new MapperConfiguration(conf =>
      {
        conf.CreateMap<EventDto, EventViewModel>().ReverseMap();
        conf.CreateMap<EventFormViewModel, EventDto>();
        conf.CreateMap<EventViewModel, EventFormViewModel>();
      });
      _mapper = mapperConfiguration.CreateMapper();
    }

    public async Task<IEnumerable<EventViewModel>> GetAllEvents()
    {
      var dtos = await _clientService.EventAllAsync();
      return _mapper.Map<IEnumerable<EventViewModel>>(dtos);
    }

    public async Task<EventViewModel> GetEventById(int id)
    {
      var dto = await _clientService.EventAsync(id);
      return _mapper.Map<EventViewModel>(dto);
    }

    public async Task SaveEvent(EventFormViewModel eventModel)
    {
      var dto = _mapper.Map<EventDto>(eventModel);
      // await _clientService.SaveEvent(dto); // TODO: 
    }

    public EventViewModel CurrentEditItem { get; set; }

    public EventFormViewModel GetCurrentEditItem()
    {
      return _mapper.Map<EventFormViewModel>(CurrentEditItem);
    }

  }
}
