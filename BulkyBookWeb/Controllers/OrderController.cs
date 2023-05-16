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
        public async Task<IActionResult> _AdminOrderView(int? page = 1, int? pageSize = 5, string? sortVal = "Id", string? sortDir = "asc", string? q = "")
        {
            var data = await this._iorder.GetAllOrders(page, pageSize, sortVal, sortDir, q);
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
        public IActionResult _PaymentView()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> UpSertList(List<OrderViewModel> orders)
        {
            var data = await this._iorder.UpSertList(orders);
            return Ok(data);
        }

        public async Task<IActionResult> DeleteOrder(string id)
        {
            var data = await this._iorder.DeleteOrder(id); 
            return Ok(data);
        }
      
    }
}
