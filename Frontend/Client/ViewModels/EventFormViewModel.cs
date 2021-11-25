using System.ComponentModel.DataAnnotations;

namespace Workshop.Blazor.Frontend.Client.ViewModels
{

  
  public class EventFormViewModel
  {
    [Hidden]
    public int Id { get; set; }

    [Display(Name = "Beginn", Order = 30, Description = "Beginn der Veranstaltung")]
    [MinDateValidation(MinDate.Today)]
    public DateTime Begin { get; set; }

    [Display(Name = "Ende", Order = 40, Description = "Ende der Veranstaltung")]
    public DateTime End { get; set; }

    [Display(Name="Veranstaltung", Order = 10, Description = "Name der Veranstaltung")]
    [Placeholder("Name")]
    [Required, StringLength(80)]
    public string Name { get; set; } = String.Empty;

    [Display(Name = "Beschreibung", Order = 10, Description = "Beschreibung der Veranstaltung")]
    [StringLength(1024), UIHint("textarea")]
    public string Description { get; set; } = String.Empty;

    [Display(Name = "Plätze", Order = 50, Description = "Anzahl der Plätze")]
    [Placeholder("10")]
    public int NumberOfSeats { get; set; }
  }
}
