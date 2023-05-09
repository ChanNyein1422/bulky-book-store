using Data.Models;
using Data.ViewModel;

namespace BulkyBookAPI.Services.Order
{
    public interface IOrder
    {
        Task<List<tbOrder>> GetAllOrders();
        Task<List<OrderViewModel>> UpSertList(List<OrderViewModel> orders);
        Task<List<tbOrderDetail>> GetOrderDetails(string id);
        Task<tbOrder> GetOrderById(string id);
        Task<List<tbOrder>> GetOrderByUser(int userId);
        Task<int> DeleteOrder(string id);
    }
}
