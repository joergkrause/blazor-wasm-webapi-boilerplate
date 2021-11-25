namespace Workshop.Blazor.DataTransferObjects;

public class FileDto
{

  public int Id { get; set; }

  public string FileName { get; set; } = String.Empty;

  public string MimeType { get; set; } = "application/octetstream";

  public long Size { get; set; }

  public string? Path { get; set; }

}
