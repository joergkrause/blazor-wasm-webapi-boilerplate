using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Blazor.Frontend.Store.State
{
  public class StateStore : IStateStore
  {

    private IDictionary<string, object> InnerState { get; } = new Dictionary<string, object>();

    public object this[string key]
    {
      get => InnerState[key];
      set
      {
        InnerState[key] = value;
        ValueChanged(value);
      }
    }

    public ICollection<string> Keys => InnerState.Keys;

    public ICollection<object> Values => InnerState.Values;

    public int Count => InnerState.Count;

    public bool IsReadOnly => true;

    public void Add(string key, object value)
    {
      InnerState.Add(key, value);
      ValueChanged(value);
    }

    public void Add(KeyValuePair<string, object> item)
    {
      InnerState.Add(item.Key, item.Value);
      ValueChanged(item.Value);
    }

    public void Clear()
    {
      InnerState.Clear();
    }

    public bool Contains(KeyValuePair<string, object> item)
    {
      return InnerState.Contains(item);
    }

    public bool ContainsKey(string key)
    {
      return InnerState.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    {
      InnerState.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      return InnerState.GetEnumerator();
    }

    public bool Remove(string key)
    {
      return InnerState.Remove(key);
    }

    public bool Remove(KeyValuePair<string, object> item)
    {
      return InnerState.Remove(item);
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out object value)
    {
      return InnerState.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return InnerState.GetEnumerator();
    }

    #region IStateStore

    private void ValueChanged(object value)
    {
      if (OnValueChanged != null)
      {
        OnValueChanged(value);
      }
    }

    public event OnValueChangedDelegate OnValueChanged;

    public T? GetValue<T>(string key)
    {
      if (TryGetValue(key, out var value))
      {
        return (T)value;
      }
      return default;
    }

    #endregion


  }
}
