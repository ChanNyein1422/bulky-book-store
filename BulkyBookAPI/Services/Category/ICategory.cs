using Data.Models;

namespace BulkyBookAPI.Services.Category
{
    public interface ICategory
    {
        Task<List<tbCategory>> GetAllCategory();
        Task<tbCategory> UpSert(tbCategory category);
        tbCategory GetCategoryById(int id);
        int CategoryDelete(int id);
    }
}
