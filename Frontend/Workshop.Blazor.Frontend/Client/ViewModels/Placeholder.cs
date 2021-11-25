
namespace Workshop.Blazor.Frontend.Client
{
  public class PlaceholderAttribute : Attribute
  {

    public PlaceholderAttribute(string text)
    {
      Text = text;
    }
    public string Text { get; set; }
  }
}
