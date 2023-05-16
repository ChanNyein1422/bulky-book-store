using Data.Models;

namespace BulkyBookAPI.Services.User
{
    public interface IValidate
    {
        bool CheckEmail(tbUser user);
        bool CheckUserName(tbUser user);
    }
}
