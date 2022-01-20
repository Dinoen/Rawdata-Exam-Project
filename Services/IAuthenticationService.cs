using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Services
{
    public interface IAuthenticationService
    {
        UserAccountViewModel Authenticate(string userName, string password);
    }
}