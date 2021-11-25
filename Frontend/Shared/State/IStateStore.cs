using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Blazor.Frontend.Store.State
{
  public interface IStateStore : IDictionary<string, object>
  {
    event OnValueChangedDelegate OnValueChanged;

    T GetValue<T>(string key);

  }
}
