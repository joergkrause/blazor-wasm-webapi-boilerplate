using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Workshop.Blazor.Frontend.Client.ViewModels;

namespace Workshop.Blazor.Frontend.Client.Pages
{
  public partial class Index
    {
        [Inject]
        private IJSRuntime _js { get; set; }

        [Parameter()]
        public int T { get; set; }

        public async Task SetTenant(int id)
        {
            await SetBaseHref("BlazorHRef", $"/t/{id}/");
        }

        public async ValueTask<bool> SetBaseHref(string elementId, string hRef)
        {
            var result = await _js.InvokeAsync<bool>("SetBaseHref", elementId, hRef);
            NavMan.NavigateTo(hRef, false);
            return result;
        }
    }
}
