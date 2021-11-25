using System.ComponentModel.DataAnnotations;

namespace Workshop.Blazor.Frontend.Client.ViewModels
{
  public class MinDateValidationAttribute : ValidationAttribute
  {

    public MinDateValidationAttribute(MinDate behavior)
    {
      Behavior = behavior;
    }

    public MinDate Behavior { get; set; }

    public override bool IsValid(object? value)
    {
      if (Behavior == MinDate.Today)
      {
        return DateTime.Parse(value.ToString()) >= DateTime.Today;
      }
      return false;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      return base.IsValid(value, validationContext);
    }

  }
}
