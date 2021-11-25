using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using Workshop.Blazor.Frontend.Client.Services;
using Workshop.Blazor.Frontend.Client.ViewModels;

namespace Workshop.Blazor.Frontend.Client.Pages
{
  public partial class EditEvent
  {

    [Inject]
    public DataService DataService { get; set; }

    protected override void OnParametersSet()
    {
      EventModel = DataService.GetCurrentEditItem();
    }

    public EventFormViewModel EventModel { get; set; } = new();

    public string GetLabel(string propName)
    {
      var beginAttr = typeof(EventFormViewModel).GetProperty(propName)?.GetCustomAttributes(typeof(DisplayAttribute), true).OfType<DisplayAttribute>().Single();
      return beginAttr?.Name ?? propName;
    }

    public async Task SaveData()
    {
      await DataService.SaveEvent(EventModel);
    }

  }
}
