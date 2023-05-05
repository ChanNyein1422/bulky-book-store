using Data.Models;
using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Services.Category
{
    public class CategoryBase : ICategory
    {
        private ApplicationDbContext _context;
        UnitOfWork _unitOfWork;

        public CategoryBase(ApplicationDbContext context)
        {
            _context = context;
            this._unitOfWork = new UnitOfWork(_context);
        }

        public int CategoryDelete(int id)
        {
            var result = _unitOfWork.categoryRepo.GetAll().FirstOrDefault(c => c.Id == id);
            if (result != null)
            {
                _unitOfWork.categoryRepo.Delete(result);
                return 1;
            }
            return 0;
        }

        public async Task<List<tbCategory>> GetAllCategory()
        {
            var result = await _unitOfWork.categoryRepo.GetAll().ToListAsync();
            return result;
        }

        public tbCategory GetCategoryById(int id)
        {
            var result = _unitOfWork.categoryRepo.GetById(id);
            return result;
        }

        public async Task<tbCategory> UpSert(tbCategory category)
        {
            if(category.Id>0){
                category = await _unitOfWork.categoryRepo.UpdateAsync(category);
            }
            else
            {
                category = await _unitOfWork.categoryRepo.InsertReturnAsync(category); 
            }
            return category;
        }
    }
}
