using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Blazor.Frontend.Store.Action
{
  public interface IAction
  {
    object? Payload { get; init; }

    Guid Action { get; init; }

  }
}
