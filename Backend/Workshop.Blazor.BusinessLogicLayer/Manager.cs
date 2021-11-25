using AutoMapper;
using Workshop.Blazor.DataAccessLayer;

namespace Workshop.Blazor.BusinessLogicLayer
{
  public abstract class Manager
  {

    public Manager(EventDatabaseContext context, IMapper mapper)
    {
      Context = context;
      Mapper = mapper;
    }

    protected EventDatabaseContext Context { get; }

    protected IMapper Mapper { get; }

  }
}
