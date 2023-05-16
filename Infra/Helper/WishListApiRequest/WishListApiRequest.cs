using Data.Models;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.WishListApiRequest
{
    public class WishListApiRequest : IWishListApiRequest
    {
        public async Task<int> Delete(int userId, int bookId)
        {
            var url = $"api/wishlist/deletewishlist?userId={userId}&bookId={bookId}";
            var data = await ApiRequest<int>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<int> GetByBook(int bookId)
        {
            var url = $"api/wishlist/getwishlistcountbybook?bookId={bookId}";
            var data = await ApiRequest<int>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<tbWishList> GetById(int id)
        {
            var url = $"api/wishlist/getwishlistbyid?id={id}";
            var data = await ApiRequest<tbWishList>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<UserWishListViewModel>> GetByUser(int userId)
        {
            var url = $"api/wishlist/getwishlistbyuser?userId={userId}";
            var data = await ApiRequest<List<UserWishListViewModel>>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<tbWishList> UpSert(tbWishList wishList)
        {
            var url = $"api/wishlist/addtowishlist";
            var result = await ApiRequest<tbWishList>.PostRequest(url.route(Request.bulkybookapi), wishList);
            return result;
        }
    }
}
