using Data.Models;
using Infra.Services;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookAPI.Services.User
{
    public interface IUser
    {
        Task<Model<tbUser>> GetAllUsers(int? page=1, int? pageSize= 10, string? sortVal = "Id", string? sortDir = "asc", string? q = "");
        tbUser GetUserById(int id);
        Task<tbUser> UpSert(tbUser user);
        int UserDelete(int id);
        Task<tbUser> LoginUser(string email, string password);
    }
}
