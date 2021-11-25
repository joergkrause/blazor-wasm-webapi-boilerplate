using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Workshop.Blazor.BusinessLogicLayer;
using Workshop.Blazor.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Workshop.Blazor.BackendService.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Produces("application/json")]
  public class FilemanagerController : ControllerBase
  {

    private readonly IFileUploadManager _fileUploadManager;

    public FilemanagerController(IFileUploadManager fileUploadManager)
    {
      _fileUploadManager = fileUploadManager;
    }

    [HttpGet]
    public IEnumerable<UploadFileDto> Get()
    {
      return _fileUploadManager.GetAllFiles();
    }

    [HttpGet, Route("{id}", Name = "GetById")]
    public UploadFileDto Get(int id)   // 200 OK + Daten
    {
      return _fileUploadManager.GetById(id);
    }

    [HttpGet, Route("search/{name:alpha:maxlength(128)}", Name = "SearchFile")]
    public IEnumerable<FileDto> Search(string name)
    {
      return _fileUploadManager.SearchFile(name);
    }

    [HttpPost, Route("", Name = "Add")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(UploadResult))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Accepted, Type = typeof(string))]
    public async Task<IActionResult> Post([FromBody] UploadFileDto uploadFile)
    {
      if (ModelState.IsValid)
      {
        if (await _fileUploadManager.AddFileAsync(uploadFile))
        {
          return Ok(new UploadResult { ErrorCode = 0, FileName = uploadFile.FileName, Uploaded = true });
        }
        else
        {
          return Accepted(new UploadResult { ErrorCode = 0, FileName = String.Empty, Uploaded = false }); // 202
        }
      }
      else
      {
        return BadRequest(new UploadResult { ErrorCode = 100, FileName = uploadFile.FileName, Uploaded = false});
      }
    }

    [HttpPut, Route("{id:int}", Name = "Edit")]
    public async Task Put(int id, [FromBody] UploadFileDto uploadFile)
    {
      await _fileUploadManager.UpdateFileAsync(id, uploadFile);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _fileUploadManager.DeleteFileAsync(id);
    }

    [HttpPost, Route("upload")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    public async Task<IActionResult> UploadBinary([FromForm] IFormFileCollection files)
    {
      var filePath = Path.GetTempFileName();
      foreach (var formFile in files)
      {
        if (formFile.Length > 0)
        {
          using var stream = formFile.OpenReadStream();
          using var mem = new MemoryStream();
          await stream.CopyToAsync(mem);
          await _fileUploadManager.AddFileAsync(new UploadFileDto
          {
            FileName = formFile.FileName,
            Path = filePath,
            MimeType = formFile.ContentType,
            Data = mem.ToArray()
          });
          // parallel writing to file is for demonstration purpose only
          await System.IO.File.WriteAllBytesAsync(filePath, mem.ToArray());

        }
      }

      return Ok(files.Count);
    }

    [HttpGet, Route("download/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileResult))]
    public async Task<IActionResult> DownloadBinary(int id)
    {
      var fileData = await _fileUploadManager.GetDataByIdAsync(id);
      return File(fileData.Data, fileData.MimeType, true);
    }

  }
}
