using Workshop.Blazor.DataTransferObjects;
using Workshop.Blazor.DomainModels;

namespace Workshop.Blazor.BusinessLogicLayer
{
  public interface IFileUploadManager
  {
    Task<bool> AddFileAsync(UploadFileDto file);
    Task<bool> DeleteFileAsync(int id);
    IEnumerable<UploadFileDto> GetAllFiles();
    UploadFileDto GetById(int id);
    Task<DownloadFileDto> GetDataByIdAsync(int id);
    IEnumerable<FileDto> SearchFile(string name);
    Task<bool> UpdateFileAsync(int id, UploadFileDto file);
  }
}
