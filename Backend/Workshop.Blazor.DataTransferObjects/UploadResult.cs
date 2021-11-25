using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop.Blazor.DataTransferObjects;

public class UploadResult
{
  public bool Uploaded { get; set; }
  public string FileName { get; set; }
  public string StoredFileName { get; set; }
  public int ErrorCode { get; set; }
}
