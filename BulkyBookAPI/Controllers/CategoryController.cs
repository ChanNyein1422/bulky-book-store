using BulkyBookAPI.Services.Category;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategory _icategory;
        public CategoryController(ICategory icategory)
        {
            _icategory = icategory;
        }
        [HttpGet("api/category/getcategories")]
        public async Task<IActionResult> GetAllCategories() { 
         var result = await _icategory.GetAllCategory();
            return Ok(result);
        }

        [HttpPost("api/category/upsert")]
        public async Task<IActionResult> UpSert(tbCategory category)
        {
            var result = await _icategory.UpSert(category);
            return Ok(result);
        }

        [HttpGet("api/category/getcategorybyid")]
        public IActionResult GetCategoryById(int id) { 
            var result = _icategory.GetCategoryById(id);
            return Ok(result);
        }
        [HttpGet("api/category/deletecategory")]
        public IActionResult DeleteCategory(int id) { 
            var result = _icategory.CategoryDelete(id);
            return Ok(result);
        }
    }
}
