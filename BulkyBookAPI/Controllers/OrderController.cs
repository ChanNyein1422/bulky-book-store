using BulkyBookAPI.Services.Category;
using BulkyBookAPI.Services.Order;
using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrder _iOrder;
        public OrderController(IOrder order)
        {
            _iOrder = order;
        }
        [HttpGet("api/order/getallorders")]
        public async Task<IActionResult> GetAllOrders(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc",
                                string? q = "")
        {
            var result = await _iOrder.GetAllOrders(page, pageSize, sortVal, sortDir, q);
            return Ok(result);
        }

        [HttpPost("api/order/upsert")]
        public async Task<IActionResult> UpSertList(List<OrderViewModel> orders)
        {
            var result = await _iOrder.UpSertList(orders);
            return Ok(result);
        }
        [HttpGet("api/order/getorderdetails")]
        public async Task<IActionResult> GetOrderDetails(string id)
        {
            var result = await _iOrder.GetOrderDetails(id);
            return Ok(result);
        }

        [HttpGet("api/order/getorderbyid")]
        public async Task<IActionResult> GetOrderById(string id)
        {
            var result = await _iOrder.GetOrderById(id);
            return Ok(result);
        }
        [HttpGet("api/order/getorderbyuser")]
        public async Task<IActionResult> GetOrderByUser(int userId)
        {
            var result = await _iOrder.GetOrderByUser(userId);
            return Ok(result);
        }

        [HttpGet("api/order/deleteorder")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            var result = await _iOrder.DeleteOrder(id);
            return Ok(result);
        }
    }
}
