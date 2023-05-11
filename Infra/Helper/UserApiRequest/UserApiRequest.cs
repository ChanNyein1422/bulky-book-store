using Data.Models;
using Infra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.UserApiRequest
{
    public class UserApiRequest : IUserApiRequest
    {

        public async Task<PagedListClient<tbUser>> GetAllUsers(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc",
                        string? q = "")
        {
            string url = $"api/user/getallusers?page={page}&pageSize={pageSize}&sortVal={sortVal}&sortDir={sortDir}&q={q}";
            var data = await ApiRequest<Model<tbUser>>.GetRequest(url.route(Request.bulkybookapi));
            //var data = await GetRequest<Model<tbUser>>(url.route(Request.firstapi));
            PagedListClient<tbUser> model = PagingService<tbUser>.Convert(page ?? 1, pageSize ?? 10, data);
            
            return model;
        }
        public async Task<tbUser> GetUserByID(int id)
        {
            string url = $"api/user/getuserbyid?id={id}";
            var data = await ApiRequest<tbUser>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<tbUser> Login(string email, string password)
        {
            tbUser user = new tbUser();
            user.Email = email;
            user.Password = password;
            string url = $"api/user/login";
            var data = await ApiRequest<tbUser>.PostRequest(url.route(Request.bulkybookapi), user);
            return data;
        }

        public async Task<tbUser> UpSert(tbUser user)
        {
            string url = $"api/user/upsert";
            var data = await ApiRequest<tbUser>.PostRequest(url.route(Request.bulkybookapi), user);
            return data;
        }

        public async Task<int> Delete(int id)
        {
            string url = $"api/user/delete?id={id}";
            var data = await ApiRequest<int>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

       
    }
}
