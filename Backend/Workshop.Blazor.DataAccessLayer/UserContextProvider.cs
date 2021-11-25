using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Blazor.DataAccessLayer
{
  public class UserContextProvider : IUserContextProvider
  {

    private string _userName;

    public string Identity => _userName;

    public void SetIdentity(string userName)
    {
      _userName = userName;
    }
  }
}
