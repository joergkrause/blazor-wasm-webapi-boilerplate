using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Workshop.Blazor.Frontend.Client.ServiceProxy;
using Workshop.Blazor.Frontend.Client.Services;

namespace Workshop.Blazor.Frontend.Client.Pages.FileUpload;


public class FileUploadModel : ComponentBase
{


  [Inject]
  public DataService DataService { get; set; }

  protected List<FileParameter> files = new();
  protected List<UploadResult> uploadResults = new();
  protected int maxAllowedFiles = 3;
  protected bool shouldRender;
  protected override bool ShouldRender() => shouldRender;
  protected async Task OnInputFileChange(InputFileChangeEventArgs e)
  {
    shouldRender = false;
    long maxFileSize = 1024 * 1024 * 1500;
    var upload = false;
    using var content = new MultipartFormDataContent();
    foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
    {
      if (uploadResults.SingleOrDefault(f => f.FileName == file.Name) is null)
      {
        try
        {
          var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
          fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
          files.Add(new FileParameter(fileContent.ReadAsStream(), file.Name, file.ContentType));
          content.Add(content: fileContent, name: "\"files\"", fileName: file.Name);
          upload = true;
        }
        catch (Exception ex)
        {
          Console.WriteLine("{FileName} not uploaded (Err: 6): {Message}", file.Name, ex.Message);
          uploadResults.Add(new()
          { FileName = file.Name, ErrorCode = 6, Uploaded = false });
        }
      }
    }

    if (upload)
    {
      var response = await DataService.PostFileAsync(files);
      uploadResults = uploadResults.Concat(response).ToList();
    }

    shouldRender = true;
  }

  protected static bool Upload(IList<UploadResult> uploadResults, string fileName, out UploadResult result)
  {
    result = uploadResults.SingleOrDefault(f => f.FileName == fileName);
    if (result is null)
    {
      Console.WriteLine("{FileName} not uploaded (Err: 5)", fileName);
      result = new();
      result.ErrorCode = 5;
    }

    return result.Uploaded;
  }

}
