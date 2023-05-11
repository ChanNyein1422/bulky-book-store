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
        public async Task<IActionResult> _AdminOrderView()
        {
            var data = await this._iorder.GetAllOrders();
            return PartialView(data);
        }
        public async Task<IActionResult> _AdminDetailView(string id)
        {
            var data = await this._iorder.GetOrderDetails(id);
            return PartialView(data);
        }

        public async Task<IActionResult> _OrderDetailView(string id)
        {
            var data = await this._iorder.GetOrderDetails(id);
            return PartialView(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpSertList(List<OrderViewModel> orders)
        {
            var data = await this._iorder.UpSertList(orders);
            return Ok(data);
        }

      
    }
}
