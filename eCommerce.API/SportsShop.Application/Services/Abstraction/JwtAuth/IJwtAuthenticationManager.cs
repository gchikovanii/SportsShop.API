using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Services.Abstraction.JwtAuth
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(bool status, string email, List<string> roles);
    }
}
