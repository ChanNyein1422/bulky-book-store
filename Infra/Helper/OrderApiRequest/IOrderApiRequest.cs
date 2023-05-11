using Data.Models;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.OrderApiRequest
{
    public interface IOrderApiRequest
    {
        Task<List<UserOrderViewModel>> GetAllOrders();
        Task<List<OrderViewModel>> UpSertList(List<OrderViewModel> orders);
        Task<List<BookOrderDetailViewModel>> GetOrderDetails(string id);
        Task<tbOrder> GetOrderById(string id);
        Task<List<tbOrder>> GetOrderByUser(int userId);
        Task<int> DeleteOrder(string id);
    }
}
