using Data.Models;
using Data.ViewModel;
using Infra.Services;

namespace BulkyBookAPI.Services.WishList
{
    public interface IWishList
    {
        Task<List<UserWishListViewModel>> GetWishListByUser(int userId);
        Task<int> GetWishListCountByBook(int bookId);
        Task<tbWishList> GetWishListById(int id);
        Task<tbWishList> UpSert(tbWishList wishlist);
        Task<int> WishListDelete(int userId, int bookId);
    }
}
