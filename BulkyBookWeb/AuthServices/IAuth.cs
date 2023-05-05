using Data.Models;

namespace BulkyBookWeb.AuthServices
{
    public interface IAuth
    {
        void AuthorizeUser(tbUser user, HttpContext context);
        void Logout(HttpContext context);
    }
}
