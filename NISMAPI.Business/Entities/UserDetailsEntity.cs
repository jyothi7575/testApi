using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticWebAPI.Business.Entities
{
  public class UserDetailsEntity
  {
    public string UserName { get; set; }
    public string Password { get; set; }
    public string access_token { get; set; }
  }
}
