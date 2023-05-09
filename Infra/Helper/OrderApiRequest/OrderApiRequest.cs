using Data.Models;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.OrderApiRequest
{
    public class OrderApiRequest : IOrderApiRequest
    {
        public async Task<int> DeleteOrder(string id)
        {
            var url = $"api/order/deleteorder?id={id}";
            var data = await ApiRequest<int>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<tbOrder>> GetAllOrders()
        {
            var url = $"api/order/getallorders";
            var data = await ApiRequest<List<tbOrder>>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<tbOrder> GetOrderById(string id)
        {
            var url = $"api/order/getorderbyid?id={id}";
            var data = await ApiRequest<tbOrder>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<tbOrder>> GetOrderByUser(int userId)
        {
            var url = $"api/order/getorderbyuser?userId={userId}";
            var data = await ApiRequest<List<tbOrder>>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<tbOrderDetail>> GetOrderDetails(string id)
        {
            var url = $"api/order/getorderdetails?id={id}";
            var data = await ApiRequest<List<tbOrderDetail>>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<OrderViewModel>> UpSertList(List<OrderViewModel> orders)
        {
            var url = $"api/order/upsert";
            var data = await ApiRequest<List<OrderViewModel>>.PostRequest(url.route(Request.bulkybookapi), orders);
            return data;
        }
    }
}
