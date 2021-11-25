using Microsoft.AspNetCore.Components;
using Workshop.Blazor.Frontend.Client.Services;
using Workshop.Blazor.Frontend.Client.ViewModels;

namespace Workshop.Blazor.Frontend.Client.Pages
{
  public class ListEventsModel : ComponentBase
  {

    [Inject]
    protected DataService DataService { get; set; }

    [Inject]
    protected NavigationManager Navigation { get; set; }

    protected override async Task OnParametersSetAsync()
    {
      var data = await DataService.GetAllEvents();
      DataSource = data;
    }

    protected IEnumerable<EventViewModel> DataSource { get; set; }

    protected EventViewModel CurrentItem { get; set; }

    protected async Task GridAction((string Action, EventViewModel Payload) action)
    {
      if (action.Action == "edit")
      {
        var editId = action.Payload.Id;
        // Frische Daten holen!
        var item = await DataService.GetEventById(editId);
        if (item == null)
        {
          DataService.CurrentEditItem = CurrentItem = null;
        }
        else
        {
          CurrentItem = DataService.CurrentEditItem = item;
          Navigation.NavigateTo("editevent");
        }
      }
    }


  }
}
