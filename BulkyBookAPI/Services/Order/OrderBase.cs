using BulkyBookAPI.Services.OrderDetail;
using Data.Models;
using Data.ViewModel;
using Infra.Services;
using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Services.Order
{
    public class OrderBase : IOrder
    {
        private ApplicationDbContext _context;
        UnitOfWork _unitOfWork;

        public OrderBase(ApplicationDbContext context)
        {
            _context = context;
            this._unitOfWork = new UnitOfWork(_context);
        }
        public async Task<int> DeleteOrder(string id)
        {
            var result = await _unitOfWork.orderRepo.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if(result != null)
            {
                var orderdetails = await _unitOfWork.orderDetailRepo.GetAll().Where(x => x.OrderId == id).ToListAsync();
                _unitOfWork.orderRepo.Delete(result);
                if(orderdetails != null)
                {
                    foreach(var item in orderdetails)
                    {
                        _unitOfWork.orderDetailRepo.Delete(item);
                    }
                }
                return 1;
            }
            return 0;
        }

        public async Task<List<UserOrderViewModel>> GetAllOrders()
        {
            IQueryable<UserOrderViewModel> result = from o in _unitOfWork.orderRepo.GetAll()
                                                    join u in _unitOfWork.userRepo.GetAll()
                                                    on o.UserId equals u.Id

                                                    select new UserOrderViewModel
                                                    { 
                                                        order = o,
                                                        user = u
                                                    };
            var data = await result.OrderBy(a => a.order.Id).ToListAsync();
            return data;
        }
        public async Task<List<BookOrderDetailViewModel>> GetOrderDetails(string id)
        {
            IQueryable<BookOrderDetailViewModel> result = from b in _unitOfWork.bookRepo.GetAll()
                                                          join od in _unitOfWork.orderDetailRepo.GetAll().Where(x => x.OrderId == id)
                                                          on b.Id equals od.BookId

                                                          select new BookOrderDetailViewModel
                                                          {
                                                              book = b,
                                                              orderDetail = od
                                                          };
            var data = await result.OrderBy(a => a.orderDetail.Id).ToListAsync();
            return data;
        }
        
        public async Task<tbOrder> GetOrderById(string id)
        {
            var result = await _unitOfWork.orderRepo.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<List<tbOrder>> GetOrderByUser(int userId)
        {
            var result = await _unitOfWork.orderRepo.GetAll().Where(x => x.UserId == userId).ToListAsync();
            return result;
        }

        public async Task<List<OrderViewModel>> UpSertList(List<OrderViewModel> orders)
        {
            var status = "Fail";
            try
            {
                if (orders.Count() > 0)
                {
                    Random generator = new Random();
                    var ordercode = generator.Next(0, 1000000).ToString("D6");
                    var orderid = Guid.NewGuid().ToString();
                    tbOrder order = new tbOrder();
                    order.Id = orderid;
                    order.OrderCode = ordercode;
                    order.TotalBooks = orders.Count();
                    order.UserId = orders[0].UserId;
                    

                    decimal? total = 0;

                    List<tbOrderDetail> details = new List<tbOrderDetail>();

                    foreach (var orderDetail in orders)
                    {
                        var bookDetail = _unitOfWork.bookRepo.GetAll().FirstOrDefault(x => x.Id == orderDetail.BookId);
                        var price = bookDetail.Price;
                        var name = bookDetail.Title;
                        total += price; // tbbook table 
                        tbOrderDetail detail = new tbOrderDetail();
                        detail.OrderId = orderid;
                        detail.BookId = orderDetail.BookId;
                        detail.BookName = name;
                        detail.OrderCode = ordercode;
                        detail.UserId = orderDetail.UserId; 
                        detail.Price = price;
                        details.Add(detail);
                    }

                    order.TotalAmount = total;

                    var addedorder = await _unitOfWork.orderRepo.InsertReturnAsync(order);
                    await _unitOfWork.orderDetailRepo.InsertListAsync(details);

                    status = "Success";

                }
            }
            catch(Exception ex)
            {
                status = ex.Message;
            }

            return orders;
        }


    }
}
