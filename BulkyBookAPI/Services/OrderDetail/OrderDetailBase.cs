using Data.Models;
using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Services.OrderDetail
{
    public class OrderDetailBase : IOrderDetail
    {
        private ApplicationDbContext _context;
        UnitOfWork _unitOfWork;

        public OrderDetailBase(ApplicationDbContext context)
        {
            _context = context;
            this._unitOfWork = new UnitOfWork(_context);
        }
        public async Task<int> DeleteOrderDetail(int id)
        {
            var result = await _unitOfWork.orderDetailRepo.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                _unitOfWork.orderDetailRepo.Delete(result);
                return 1;
            }
            return 0;
        }

        public async Task<List<tbOrderDetail>> GetAllOrderDetails()
        {
            var result = await _unitOfWork.orderDetailRepo.GetAll().ToListAsync();
            return result;
        }

        public async Task<tbOrderDetail> GetOrderDetailById(int id)
        {
            var result = await _unitOfWork.orderDetailRepo.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

    }
}
