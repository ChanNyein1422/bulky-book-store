using BulkyBookAPI.Services.Category;
using BulkyBookAPI.Services.Dashboard;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        ICount _icount;
        public HomeController(ICount icount)
        {
            _icount = icount;
        }

        [HttpGet("api/home/getcount")]
        public IActionResult GetCount()
        {
            var result = _icount.GetCount();
            return Ok(result);
        }
    }
}
