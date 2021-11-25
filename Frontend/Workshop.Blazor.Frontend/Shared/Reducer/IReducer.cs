using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Blazor.Frontend.Shared.Action;
using Workshop.Blazor.Frontend.Shared.State;

namespace Workshop.Blazor.Frontend.Shared.Reducer
{
  public interface IReducer
  {
    Task<IStateStore> InvokeAsync(IStateStore state, IAction action);
  }
}
