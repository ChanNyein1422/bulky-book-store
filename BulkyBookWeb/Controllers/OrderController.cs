using Data.Models;
using Data.ViewModel;
using Infra.Helper.OrderApiRequest;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class OrderController : Controller
    {
        IOrderApiRequest _iorder;

        public OrderController(IOrderApiRequest iorder)
        {
            this._iorder = iorder;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UserOrderView(int userId)
        {
            var data = await this._iorder.GetOrderByUser(userId);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpSertList(List<OrderViewModel> orders)
        {
            var data = await this._iorder.UpSertList(orders);
            return Ok(data);
        }

      
    }
}
