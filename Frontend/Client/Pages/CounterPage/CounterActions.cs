using Workshop.Blazor.Frontend.Shared.Action;

namespace Workshop.Blazor.Frontend.Client.Pages.CounterPage
{
  public class CounterActions
  {
    public static readonly IAction COUNTER_INC = StoreAction<object>.Create();
    public static readonly IAction COUNTER_DEC = StoreAction<object>.Create();
  }
}
