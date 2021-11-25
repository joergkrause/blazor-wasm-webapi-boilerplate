using Workshop.Blazor.Frontend.Store.State;

namespace Workshop.Blazor.Frontend.Store.Persistence;

public class PersistanceService : IPersistanceService
{
  public void Persist(IStateStore state)
  {
    throw new NotImplementedException();
  }

  public Task PersistAsync(IStateStore state)
  {
    throw new NotImplementedException();
  }

  public IStateStore Restore()
  {
    throw new NotImplementedException();
  }

  public Task<IStateStore> RestoreAsync()
  {
    throw new NotImplementedException();
  }
}

