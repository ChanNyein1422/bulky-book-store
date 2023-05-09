using Data.Models;

namespace BulkyBookAPI.Services.OrderDetail
{
    public interface IOrderDetail
    {
        Task<List<tbOrderDetail>> GetAllOrderDetails();
        Task<List<tbOrderDetail>> UpSert(List<tbOrderDetail> orderDetails);
        Task<tbOrderDetail> GetOrderDetailById(int id);
        Task<int> DeleteOrderDetail(int id);
    }
}
