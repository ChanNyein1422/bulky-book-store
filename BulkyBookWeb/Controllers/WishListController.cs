using Data.Models;
using Infra.Helper.WishListApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class WishListController : Controller
    {
        IWishListApiRequest _wishlist;
        public WishListController(IWishListApiRequest wishlist)
        {
            this._wishlist = wishlist;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> _UserWishListView(int userId)
        {
            var data = await _wishlist.GetByUser(userId);
            return PartialView(data);
        }
        public async Task<IActionResult> UpSert(tbWishList wishList)
        {
            wishList = await _wishlist.UpSert(wishList);
            return Ok(wishList);
        }
        public async Task<IActionResult> Delete(int userId, int bookId)
        {
            var result = await _wishlist.Delete(userId, bookId);
            return Ok(result);
        }
        public async Task<IActionResult> GetCount(int bookId)
        {
            var count = await _wishlist.GetByBook(bookId);
            return Ok(count);
        }
    }
}
