using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Blazor.Frontend.Store.Action;
using Workshop.Blazor.Frontend.Store.State;

namespace Workshop.Blazor.Frontend.Store.Reducer
{
  public interface IReducer
  {
    Task<IStateStore> InvokeAsync(IStateStore state, IAction action);
  }
}
