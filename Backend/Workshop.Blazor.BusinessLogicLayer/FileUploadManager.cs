using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Workshop.Blazor.DataAccessLayer;
using Workshop.Blazor.DataTransferObjects;
using Workshop.Blazor.DomainModels;

namespace Workshop.Blazor.BusinessLogicLayer;

public class FileUploadManager : Manager, IFileUploadManager
{

  public FileUploadManager(EventDatabaseContext context, IMapper mapper) : base(context, mapper)
  {
  }

  public IEnumerable<UploadFileDto> GetAllFiles()
  {
    return Mapper.Map<IEnumerable<UploadFileDto>>(Context.Files.ToList());
  }

  public UploadFileDto GetById(int id)
  {
    return Mapper.Map<UploadFileDto>(Context.Files.Find(id));
  }

  public async Task<bool> AddFileAsync(UploadFileDto file)
  {
    var model = Mapper.Map<UploadFile>(file);
    model.Size = file.Data.Length; // Simulated business logic
    Context.Files.Add(model);
    return await Context.SaveChangesAsync() == 1;
  }

  public async Task<bool> UpdateFileAsync(int id, UploadFileDto file)
  {
    var model = Mapper.Map<UploadFile>(file);
    Context.Entry(model).State = EntityState.Modified;
    return await Context.SaveChangesAsync() == 1;
  }

  public async Task<bool> DeleteFileAsync(int id)
  {
    var file = new UploadFile { Id = id };
    Context.Entry(file).State = EntityState.Deleted;
    return await Context.SaveChangesAsync() == 1;
  }

  public IEnumerable<FileDto> SearchFile(string name)
  {
    // SELECT * FROM WHERE
    var query = Context.Files
        .Where(u => u.FileName.Contains(name));
    // IEnumerable
    var result = query.ToList(); //.Where(u => u.FileName[8] == 'e');
    return Mapper.Map<IEnumerable<FileDto>>(result);
  }

  public async Task<DownloadFileDto> GetDataByIdAsync(int id)
  {
    return Mapper.Map<DownloadFileDto>(await Context.Files.FindAsync(id));
  }
}
