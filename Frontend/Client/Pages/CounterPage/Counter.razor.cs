using Microsoft.AspNetCore.Components;
using Workshop.Blazor.Frontend.Store.Action;
using Workshop.Blazor.Frontend.Store.Services;
using Workshop.Blazor.Frontend.Store.State;

namespace Workshop.Blazor.Frontend.Client.Pages;

public class CounterModel : ComponentBase
{

  [Inject]
  public StoreService Store { get; set; }

  [Parameter]
  public int T { get; set; }

  protected override void OnInitialized()
  {
    Store.OnChange += Store_OnChange;
  }

  private void Store_OnChange(IStateStore state)
  {
    currentCount = state.GetValue<int>("counter");
  }

  protected int currentCount = 0;

  protected void Count(IAction action)
  {
    Store.Dispatch(action);
  }

}
