using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Workshop.Blazor.Frontend.Shared.Action;
using Workshop.Blazor.Frontend.Shared.Reducer;
using Workshop.Blazor.Frontend.Shared.State;

namespace Workshop.Blazor.Frontend.Shared.Services
{
  public class StoreService
  {
    public StoreService(IServiceProvider provider)
    {
      var reducers = Assembly.GetEntryAssembly().DefinedTypes.Where(t => t.ImplementedInterfaces.Contains(typeof(IReducer))).ToList();

      foreach (var reducer in reducers)
      {
        var ctor = reducer.GetConstructors().Single();
        var injectableServices = new List<object>();
        foreach (var param in ctor.GetParameters())
        {
          var injectableService = provider.GetService(param.ParameterType);
          if (injectableService != null)
          {
            injectableServices.Add(injectableService);
          }
        }
        var reducerInstance = (IReducer)Activator.CreateInstance(reducer, injectableServices.ToArray())!;
        Reducers.Add(reducerInstance);
      }
      StateStore.OnValueChanged += State_OnChanged;
    }

    private IStateStore StateStore { get; set; } = new StateStore();

    private IList<IReducer> Reducers { get; } = new List<IReducer>();

    public void Dispatch(IAction action)
    {
      Parallel.ForEach<IReducer>(Reducers, async red => await red.InvokeAsync(StateStore, action));
    }

    private void State_OnChanged(object value)
    {
      if (OnChange != null)
      {
        OnChange(StateStore);
      }
    }

    public event OnChangeDelegate? OnChange;

  }
}
