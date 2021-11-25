
namespace Workshop.Blazor.Frontend.Client.ViewModels
{
  internal class SortableAttribute : Attribute
  {
    private bool v;

    public SortableAttribute(bool v)
    {
      this.Behavior = v;
    }

    public bool Behavior { get => v; set => v = value; }
  }
}
