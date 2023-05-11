using Data.Models;
using Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.UserApiRequest
{
    public interface IUserApiRequest
    {
        Task<tbUser> UpSert(tbUser user);
        Task<tbUser> GetUserByID(int id);
        Task<int> Delete(int id);
        Task<PagedListClient<tbUser>> GetAllUsers(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc",
                         string? q = "");
        Task<tbUser> Login(string email, string password);
    }
}
