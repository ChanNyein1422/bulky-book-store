using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.CategoryApiRequest
{
    public class CategoryApiRequest : ICategoryApiRequest
    {
        public async Task<int> Delete(int id)
        {
            var url = $"api/category/deletecategory?id={id}";
            var data = await ApiRequest<int>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<tbCategory>> GetAll()
        {
            var url = $"api/category/getcategories";
            var data = await ApiRequest<List<tbCategory>>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<tbCategory> GetCategoryById(int id)
        {
            var url = $"api/category/getcategorybyid?id={id}";
            var data = await ApiRequest<tbCategory>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<tbCategory> UpSert(tbCategory category)
        {
            var url = $"api/category/upsert";
            var data = await ApiRequest<tbCategory>.PostRequest(url.route(Request.bulkybookapi), category);
            return data;
        }
    }
}
