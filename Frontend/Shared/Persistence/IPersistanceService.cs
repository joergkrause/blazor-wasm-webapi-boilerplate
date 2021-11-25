using Workshop.Blazor.Frontend.Store.State;

namespace Workshop.Blazor.Frontend.Store.Persistence;

public interface IPersistanceService
{
  void Persist(IStateStore state);
  IStateStore Restore();
  Task PersistAsync(IStateStore state);
  Task<IStateStore> RestoreAsync();
}
