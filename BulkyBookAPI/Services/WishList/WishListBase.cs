using Data.Models;
using Data.ViewModel;
using Infra.Services;
using Infra.UnitOfWork;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq.Expressions;
using System.Net;

namespace BulkyBookAPI.Services.WishList
{
    public class WishListBase : IWishList
    {
        ApplicationDbContext _context;
        UnitOfWork _uow;
        public WishListBase(ApplicationDbContext context)
        {
            _context = context;
            this._uow = new UnitOfWork(_context);
        }
        public async Task<int> GetWishListCountByBook(int bookId)
        {
            var data = await _uow.wishListRepo.GetAll().Where(a => a.BookId == bookId).CountAsync();
            return data;
        }

        public async Task<tbWishList> GetWishListById(int id)
        {
            var data = await _uow.wishListRepo.GetAll().FirstOrDefaultAsync(a => a.Id == id);
            return data;
        }
        public async Task<List<UserWishListViewModel>> GetWishListByUser(int userId)
        {

            IQueryable<UserWishListViewModel> query = from w in _uow.wishListRepo.GetAll().Where(a => a.UserId == userId)
                                                   join b in _uow.bookRepo.GetAll()
                                                   on w.BookId equals b.Id

                                                   select new UserWishListViewModel
                                                   {
                                                      book = b,
                                                      wishList = w
                                                   };
            
            var data = await query.OrderByDescending(a => a.wishList.Id).ToListAsync();
            return data;
        }

        public async Task<tbWishList> UpSert(tbWishList wishlist)
        {
            wishlist.AccessedTime = DateTime.Now;
            wishlist = await _uow.wishListRepo.InsertReturnAsync(wishlist);
            return wishlist;
        }

        public async Task<int> WishListDelete(int userId, int bookId)
        {
           var result = await _uow.wishListRepo.GetAll().FirstOrDefaultAsync(a => a.UserId == userId && a.BookId == bookId);
           if(result != null)
            {
                _uow.wishListRepo.Delete(result);
                return 1;
            }
           return 0;
        }
    }
}
