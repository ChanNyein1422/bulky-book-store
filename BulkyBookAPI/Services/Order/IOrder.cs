using Data.Models;
using Data.ViewModel;
using Infra.Services;

namespace BulkyBookAPI.Services.Order
{
    public interface IOrder
    {
        Task<List<UserOrderViewModel>> GetAllOrders();
        Task<List<OrderViewModel>> UpSertList(List<OrderViewModel> orders);
        Task<List<BookOrderDetailViewModel>> GetOrderDetails(string id);
        Task<tbOrder> GetOrderById(string id);
        Task<List<tbOrder>> GetOrderByUser(int userId);
        Task<int> DeleteOrder(string id);
    }
}
