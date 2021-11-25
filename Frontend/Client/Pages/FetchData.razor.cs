using Microsoft.AspNetCore.Components;
using Workshop.Blazor.Frontend.Client.Services;
using Workshop.Blazor.Frontend.Client.ViewModels;

namespace Workshop.Blazor.Frontend.Client.Pages
{
  public partial class FetchData
  {

    [Inject]
    public DataService DataService { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }

    protected override async Task OnParametersSetAsync()
    {
      var data = await DataService.GetAllEvents();
      DataSource = data;
    }

    public IEnumerable<EventViewModel> DataSource { get; set; }

    public EventViewModel CurrentItem { get; set; }

    private async Task GridAction((string, EventViewModel) action)
    {
      if (action.Item1 == "edit")
      {
        var editId = action.Item2.Id;
        // Frische Daten holen!
        var item = await DataService.GetEventById(editId);
        if (item == null)
        {
          DataService.CurrentEditItem = null;
          CurrentItem = null;
        }
        else
        {
          CurrentItem = item;
          DataService.CurrentEditItem = item;
          Navigation.NavigateTo("editevent");
        }
      }
    }


  }
}
