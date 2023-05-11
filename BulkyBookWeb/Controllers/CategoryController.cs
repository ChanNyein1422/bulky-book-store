using Data.Models;
using Infra.Helper.CategoryApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryApiRequest _icategory;
        public CategoryController(ICategoryApiRequest icategory)
        {
            this._icategory = icategory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> _AddCategory(int id)
        {
            tbCategory category = new tbCategory();
            if (id == 0)
            {
                return PartialView(category);
            }
            else
            {
                category = await _icategory.GetCategoryById(id);
                return PartialView(category);
            }
        }
        public async Task<IActionResult> _CategoryView()
        {
            var data = await this._icategory.GetAll();
            return PartialView(data);
        }
        public async Task<IActionResult> _CategoryFilterView()
        {
            var data = await this._icategory.GetAll();
            return PartialView(data);  
        }
        public async Task<IActionResult> CategoryList()
        {
            var data = await this._icategory.GetAll();
            return Ok(data);
        }
        public async Task<IActionResult> UpSert(tbCategory cat)
        {
            var data = await this._icategory.UpSert(cat);
            return Ok(data);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this._icategory.Delete(id);
            return Ok(result);
        }
    }
}
