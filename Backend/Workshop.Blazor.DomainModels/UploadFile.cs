using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Workshop.Blazor.DomainModels
{

  public static class ModelExtension
  {
    public static bool Gt128(this String file)
    {
      return file.Length > 128;
    }
  }


  [Table("UploadFiles")]
  public class UploadFile : EntityBase
  {

    [Required]
    [StringLength(128)]
    public string FileName { get; set; } = String.Empty;

    [Required]
    [MaxLength(128), Unicode(false)]
    public string MimeType { get; set; } = "application/octetstream";

    public long Size { get; set; }

    [StringLength(512)]
    public string? Path { get; set; }

    public byte[]? Data { get; set; }

    #region Just for testing model enhancements
    public bool TestFilename()
    {
      return ModelExtension.Gt128(FileName);
    }
    #endregion

  }
}
