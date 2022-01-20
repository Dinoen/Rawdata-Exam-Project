using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raw5MovieDb_WebApi.ViewModels
{
    public class UserAccountViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public string Uconst { get; set; }

        #nullable enable
        public string? Token { get; set; } = "";
        
    }
}