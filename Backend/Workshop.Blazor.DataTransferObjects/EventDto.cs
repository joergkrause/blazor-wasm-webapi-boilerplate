namespace Workshop.Blazor.DataTransferObjects;

public class EventDto
{
  public int Id { get; set; }

  public DateTime Begin { get; set; }

  public DateTime End { get; set; }

  public string Name { get; set; } = String.Empty;

  public int NumberOfSeats { get; set; }

}
