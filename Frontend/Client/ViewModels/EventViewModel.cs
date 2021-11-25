using System.ComponentModel.DataAnnotations;

namespace Workshop.Blazor.Frontend.Client.ViewModels
{

  public record IntData(int data);

  public class EventViewModel
  {
    [Hidden]
    public int Id { get; set; }

    [Display(Name = "Beginn", Order = 30, Description = "Beginn der Veranstaltung")]
    [Sortable(true)]    
    public DateTime Begin { get; set; }

    [Display(Name = "Ende", Order = 40, Description = "Ende der Veranstaltung")]
    [Sortable(false)]
    public DateTime End { get; set; }

    [Display(Name="Veranstaltung", Order = 10, Description = "Name der Veranstaltung")]
    [Sortable(true)]
    public string Name { get; set; } = String.Empty;

    [Display(Name = "Plätze", Order = 50, Description = "Anzahl der Plätze")]
    [UIHint(nameof(IntData))]
    public int NumberOfSeats { get; set; }
  }
}
