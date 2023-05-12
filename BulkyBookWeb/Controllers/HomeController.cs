using BulkyBookWeb.Models;
using Infra.Helper.CategoryApiRequest;
using Infra.Helper.CountApiRequest;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyBookWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICountApiRequest _icount;

        public HomeController(ILogger<HomeController> logger, ICountApiRequest icount)
        {
            _logger = logger;
            this._icount = icount;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> GetCount()
        {
            var count = await _icount.GetCount();
            return Ok(count);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}