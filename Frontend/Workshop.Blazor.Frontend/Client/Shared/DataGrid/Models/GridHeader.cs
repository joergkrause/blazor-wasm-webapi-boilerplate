using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Workshop.Blazor.Frontend.Client.ViewModels;

namespace Workshop.Blazor.Frontend.Client
{
  public class GridHeader
  {
    public GridHeader(PropertyInfo prop)
    {
      Name = prop.Name;
      var da = prop.GetCustomAttribute<DisplayAttribute>();
      Text = da?.Name ?? Name;
      Description = da?.Description ?? String.Empty;
      Order = da?.Order ?? default;
      IsSortable = prop.GetCustomAttribute<SortableAttribute>()?.Behavior ?? false;
    }

    public string Text { get; set; }

    public string Description { get; set; }

    public string Name { get; set; }

    public bool IsSortable { get; set; }

    public int Order { get; internal set; }
  }
}
