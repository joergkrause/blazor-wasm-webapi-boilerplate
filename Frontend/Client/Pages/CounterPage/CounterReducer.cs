using Workshop.Blazor.Frontend.Client.Services;
using Workshop.Blazor.Frontend.Shared.Action;
using Workshop.Blazor.Frontend.Shared.Reducer;
using Workshop.Blazor.Frontend.Shared.State;

namespace Workshop.Blazor.Frontend.Client.Pages.CounterPage
{
  public class CounterReducer : IReducer
  {

    public CounterReducer(DataService dataService)
    {

    }

    public Task<IStateStore> InvokeAsync(IStateStore state, IAction action)
    {
      var current = state.GetValue<int>("counter");
      state["counter"] = action switch
      {
        var a when a.Equals(CounterActions.COUNTER_INC) => current + 1,
        var a when a.Equals(CounterActions.COUNTER_DEC) => current - 1,
        _ => current
      };
      return Task.FromResult(state);
    }
  }
}
