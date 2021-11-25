using System.ComponentModel.DataAnnotations;

namespace Workshop.Blazor.DataTransferObjects;

public class DownloadFileDto
{

  public int Id { get; set; }

  public string FileName { get; set; }

  public string MimeType { get; set; }

  public byte[] Data { get; set; }

}
