using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.CategoryApiRequest
{
    public interface ICategoryApiRequest
    {
        Task<tbCategory> UpSert(tbCategory category);
        Task<int> Delete(int id);
        Task<List<tbCategory>> GetAll();

        Task<tbCategory> GetCategoryById(int id);
    }
}
