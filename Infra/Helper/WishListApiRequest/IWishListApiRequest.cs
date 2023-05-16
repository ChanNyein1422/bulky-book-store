using Data.Models;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.WishListApiRequest
{
    public interface IWishListApiRequest
    {
        Task<tbWishList> UpSert(tbWishList wishList);
        Task<int> Delete(int userId, int bookId);
        Task<int> GetByBook(int bookId);
        Task<List<UserWishListViewModel>> GetByUser(int userId);


        Task<tbWishList> GetById(int id);
    }
}
