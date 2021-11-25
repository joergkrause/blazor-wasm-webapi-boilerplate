using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Blazor.DataAccessLayer
{
  public interface IUserContextProvider
  {
    string Identity { get; }

    void SetIdentity(string userName);
  }
}
