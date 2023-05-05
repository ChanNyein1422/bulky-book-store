using Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BulkyBookWeb.AuthServices
{
    public class Auth : IAuth
    {
        public void AuthorizeUser(tbUser user, HttpContext context)
        {
            if(user != null)
            {
                var identity = new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.UserRole),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(identity, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal();
                principle.AddIdentity(claimsIdentity);

                context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);  

            }
        }

        public void Logout(HttpContext context)
        {
            context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public struct AuthDataIndex
        {
            public const int Email = 0;
            public const int Name = 1;
            public const int Role = 2;
            public const int Id = 3;
        }
    }
}
