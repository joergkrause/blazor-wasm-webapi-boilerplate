using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop.Blazor.Frontend.Server.ServiceProxy;

namespace Workshop.Blazor.Frontend.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FileController : ControllerBase
  {
    private readonly IWebHostEnvironment _env;
    private readonly IBackendService _service;
    private readonly ILogger<FileController> _logger;
    private readonly IMapper _mapper;

    public FileController(
        IWebHostEnvironment env,
        IBackendService service,
        IMapper mapper,
        ILogger<FileController> logger)
    {
      _env = env;
      _service = service;
      _mapper = mapper;
      _logger = logger;
    }

    [HttpGet()]
    public async Task<IEnumerable<UploadFileDto>> Get()
    {
      return await _service.FilemanagerAllAsync();
    }

    [HttpPost(Name = "PostFile")]
    public async Task<ActionResult<IList<UploadResult>>> PostFile(
        [FromForm] IEnumerable<IFormFile> files)
    {
      var maxAllowedFiles = 3;
      long maxFileSize = 1024 * 1024 * 15;
      var filesProcessed = 0;
      var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
      List<UploadResult> uploadResults = new();

      foreach (var file in files)
      {
        var uploadResult = new UploadResult();
        string trustedFileNameForFileStorage;
        var untrustedFileName = file.FileName;
        uploadResult.FileName = untrustedFileName;
        var trustedFileNameForDisplay =
            WebUtility.HtmlEncode(untrustedFileName);

        if (filesProcessed < maxAllowedFiles)
        {
          if (file.Length == 0)
          {
            _logger.LogInformation("{FileName} length is 0 (Err: 1)",
                trustedFileNameForDisplay);
            uploadResult.ErrorCode = 1;
          }
          else if (file.Length > maxFileSize)
          {
            _logger.LogInformation("{FileName} of {Length} bytes is " +
                "larger than the limit of {Limit} bytes (Err: 2)",
                trustedFileNameForDisplay, file.Length, maxFileSize);
            uploadResult.ErrorCode = 2;
          }
          else
          {
            try
            {
              trustedFileNameForFileStorage = Path.GetRandomFileName();
              var path = Path.Combine(_env.ContentRootPath, "unsafe_uploads",
                  trustedFileNameForFileStorage);

              await using FileStream fs = new(path, FileMode.Create);
              await file.CopyToAsync(fs);

              _logger.LogInformation("{FileName} saved at {Path}",
                  trustedFileNameForDisplay, path);

              // forward to real backend
              var fileParameter = new FileParameter(fs, path);
              // may handle multiple files
              await _service.UploadAsync(new FileParameter[] { fileParameter });

              uploadResult.Uploaded = true;
              uploadResult.StoredFileName = trustedFileNameForFileStorage;
            }
            catch (IOException ex)
            {
              _logger.LogError("{FileName} error on upload (Err: 3): {Message}",
                  trustedFileNameForDisplay, ex.Message);
              uploadResult.ErrorCode = 3;
            }
          }

          filesProcessed++;
        }
        else
        {
          _logger.LogInformation("{FileName} not uploaded because the " +
              "request exceeded the allowed {Count} of files (Err: 4)",
              trustedFileNameForDisplay, maxAllowedFiles);
          uploadResult.ErrorCode = 4;
        }

        uploadResults.Add(uploadResult);
      }

      return new CreatedResult(resourcePath, uploadResults);
    }
  }
}
