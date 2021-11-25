using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop.Blazor.DataTransferObjects;


public class UploadFileDto
{

  public int Id { get; set; }

  public string FileName { get; set; } = String.Empty;

  public string MimeType { get; set; } = "application/octet-stream";

  public long Size { get; set; }

  public string? Path { get; set; }

  public byte[]? Data { get; set; }

}
