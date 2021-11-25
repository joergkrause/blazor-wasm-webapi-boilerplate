using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Workshop.Blazor.Frontend.Client.ViewModels;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace Workshop.Blazor.Frontend.Client.Shared.DataGrid
{
  public class GridModel<T> : ComponentBase
  {

    public GridModel()
    {
      Headers = new List<GridHeader>();
      foreach (var prop in typeof(T).GetProperties())
      {
        var header = new GridHeader(prop);
        if (!prop.GetCustomAttributes(typeof(HiddenAttribute), true).Any())
        {
          Headers.Add(header);
        }
      }
      Headers = Headers.OrderBy(header => header.Order).ToList();
    }

    protected IList<GridHeader> Headers { get; set; }

    [Parameter]
    public IEnumerable<T>? Data { get; set; }

    [Parameter]
    public RenderFragment<int>? IntegerTemplate { get; set; }

    [Parameter]
    public EventCallback<(string, T)> Action { get; set; }

    protected RenderFragment GetData(T item, string propName)
    {
      var prop = typeof(T).GetProperty(propName)!;
      var value = prop.GetValue(item);
      var type = prop.PropertyType.Name;
      var needsTemplate = prop
        .GetCustomAttributes(typeof(UIHintAttribute), true)
        .OfType<UIHintAttribute>()
        .Any(attr => attr.UIHint == nameof(IntData));
      if (needsTemplate)
      {
        if (value is int i)
        {
          return IntegerTemplate?.Invoke(i)!;
        }
      }
      if (value == null)
      {
        return AnyValue("NULL");
      }
      return AnyValue(value.ToString()!);
    }

    private RenderFragment<string> AnyValue = value => builder => builder.AddContent(1, value);

    protected void Sort(string dir, string name)
    {
      // enumerable.OrderBy(d => d.Prop)
      var parameter = Expression.Parameter(typeof(T));                                   // d
      var property = Expression.Property(parameter, name);                               // d.Prop
      var propAsObj = Expression.Convert(property, typeof(object));                      // (object) d.Prop
      var lambda = Expression.Lambda<Func<T, object>>(propAsObj, parameter).Compile();   // d => d.Prop
      Data = dir switch
      {
        "asc" => Data.OrderBy(lambda),
        "desc" => Data.OrderByDescending(lambda),
        _ => Data
      };
    }

    protected async Task Edit(T item)
    {
      if (Action.HasDelegate)
      {
        await Action.InvokeAsync(("edit", item));
      }
    }

  }
}
