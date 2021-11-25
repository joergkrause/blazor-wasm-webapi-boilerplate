using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Blazor.Frontend.Shared.Action
{
  public class StoreAction<T> : IAction
  {
    public object? Payload { get; init; }
    public Guid Action { get; init; }

    public static IAction Create()
    {
      return new StoreAction<T> { Action = Guid.NewGuid(), Payload = null };
    }

    public static IAction Create(object payload)
    {
      return new StoreAction<T> { Action = Guid.NewGuid(), Payload = payload };
    }

    public override bool Equals(object? obj)
    {
      var toCompare = (obj as StoreAction<T>);
      if (toCompare == null) return false;
      return Action.Equals(toCompare.Action);
    }

    public override int GetHashCode()
    {
      return default;
    }

  }
}
