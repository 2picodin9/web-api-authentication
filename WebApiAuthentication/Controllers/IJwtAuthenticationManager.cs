using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAuthentication.Controllers
{
    public interface IJwtAuthenticationManager
    {
        string Authentication(string username, string password);
    }
}
