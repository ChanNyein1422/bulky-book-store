using Data.Models;

namespace BulkyBookAPI.Services.User
{
    public interface IUser
    {
        List<tbUser> GetAllUsers();
        tbUser GetUserById(int id);
        Task<tbUser> UpSert(tbUser user);
        int UserDelete(int id);
        Task<tbUser> LoginUser(string email, string password);
    }
}
