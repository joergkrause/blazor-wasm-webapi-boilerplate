using AutoMapper;
using Workshop.Blazor.DataTransferObjects;
using Workshop.Blazor.DomainModels;

namespace Workshop.Blazor.BusinessLogicLayer.Mappings;

public class FileMappingProfile : Profile
{
  public FileMappingProfile()
  {
    CreateMap<UploadFile, UploadFileDto>().ReverseMap();
    CreateMap<UploadFile, FileDto>();
  }
}
