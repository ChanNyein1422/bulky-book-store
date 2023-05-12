using Data.Models;
using Data.ViewModel;
using Infra.UnitOfWork;

namespace BulkyBookAPI.Services.Dashboard
{
    public class CountBase : ICount
    {
        private ApplicationDbContext _context;
        UnitOfWork _unitOfWork;

        public CountBase(ApplicationDbContext context)
        {
            _context = context;
            this._unitOfWork = new UnitOfWork(_context);
        }

        public BookUserCount GetCount()
        {
            var bookCount =  _unitOfWork.bookRepo.GetAll().Count();
            var userCount =  _unitOfWork.userRepo.GetAll().Count();
            return new BookUserCount
            {
                BookCount = bookCount,
                UserCount = userCount
            };
        }
    }
}
