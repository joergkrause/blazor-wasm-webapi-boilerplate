using AutoMapper;
using Workshop.Blazor.DataTransferObjects;
using Workshop.Blazor.DomainModels;

namespace Workshop.Blazor.BusinessLogicLayer.Mappings;

public class EventMappingProfile : Profile
{
  public EventMappingProfile()
  {
    CreateMap<Event, EventDto>()
        .ForMember(evt => evt.NumberOfSeats, opt => opt.MapFrom(s => s.Seats.Count));
  }
}
