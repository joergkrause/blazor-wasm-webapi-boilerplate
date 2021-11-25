using Workshop.Blazor.Frontend.Client.Services;
using Workshop.Blazor.Frontend.Store.Action;
using Workshop.Blazor.Frontend.Store.Reducer;
using Workshop.Blazor.Frontend.Store.State;

namespace Workshop.Blazor.Frontend.Client.Pages.CounterPage
{
  public class ListEventsReducer : IReducer
  {

    public ListEventsReducer(DataService dataService)
    {

    }

    public Task<IStateStore> InvokeAsync(IStateStore state, IAction action)
    {
      _ = action switch
      {
        var a when a.Equals(ListEventsActions.EDIT_EVENT) => true,
        var a when a.Equals(ListEventsActions.LOAD_EVENTS) => true,
        var a when a.Equals(ListEventsActions.LOAD_EVENT) => true,
        _ => default
      };
      return Task.FromResult(state);
    }
  }
}
