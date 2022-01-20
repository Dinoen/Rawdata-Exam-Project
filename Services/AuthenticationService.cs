using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AppSettings _appSettings;
        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserAccountViewModel Authenticate(string userName, string password)
        {
            //Check if the user exist in the database and if the password matches
            var ctx = new MovieDbContext();
            var user = ctx.userAccounts.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            // if user is not found return null
            if (user == null)
            {
                return null;
            }

            // Token Descriptor
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Uconst.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Generate Token
            var token = tokenHandler.CreateToken(tokenDescriptor);


            UserAccountViewModel newUser = new UserAccountViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Birthdate = user.Birthdate,
                Password = user.Password,
                Token = tokenHandler.WriteToken(token),
                Uconst = user.Uconst
            };

            return newUser;
        }
    }
}
