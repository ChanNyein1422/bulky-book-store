using Data.Models;
using Data.ViewModel;
using Infra.Services;
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

        public async Task<PagedListClient<UserOrderViewModel>> GetAllOrders(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc",
                                string? q = "")
        {
            var url = $"api/order/getallorders?page={page}&pageSize={pageSize}&sortVal={sortVal}&sortDir={sortDir}&q={q}";
            var data = await ApiRequest<Model<UserOrderViewModel>>.GetRequest(url.route(Request.bulkybookapi));
            PagedListClient<UserOrderViewModel> model = PagingService<UserOrderViewModel>.Convert(page ?? 1, pageSize ?? 10, data);
            return model;
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

        public async Task<List<BookOrderDetailViewModel>> GetOrderDetails(string id)
        {
            var url = $"api/order/getorderdetails?id={id}";
            var data = await ApiRequest<List<BookOrderDetailViewModel>>.GetRequest(url.route(Request.bulkybookapi));
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
