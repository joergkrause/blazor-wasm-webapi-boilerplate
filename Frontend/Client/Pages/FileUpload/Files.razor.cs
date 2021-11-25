using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Workshop.Blazor.Frontend.Client.ServiceProxy;
using Workshop.Blazor.Frontend.Client.Services;
using Workshop.Blazor.Frontend.Client.ViewModels;

namespace Workshop.Blazor.Frontend.Client.Pages.FileUpload;

public class FilesModel : ComponentBase
{

  [Inject]
  public DataService DataService { get; set; }


  protected IEnumerable<UploadFileViewModel> files = new List<UploadFileViewModel>();
  protected override async Task OnInitializedAsync()
  {
    files = await DataService.GetFileFilesAsync();
  }
}
