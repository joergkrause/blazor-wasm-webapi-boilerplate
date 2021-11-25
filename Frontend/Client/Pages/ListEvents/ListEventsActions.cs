using Workshop.Blazor.Frontend.Client.ViewModels;
using Workshop.Blazor.Frontend.Shared.Action;

namespace Workshop.Blazor.Frontend.Client.Pages.CounterPage
{
  public class ListEventsActions
  {
    public static readonly IAction LOAD_EVENTS = StoreAction<object>.Create();
    public static readonly IAction LOAD_EVENT = StoreAction<int>.Create();
    public static readonly IAction EDIT_EVENT = StoreAction<EventFormViewModel>.Create();
  }
}
