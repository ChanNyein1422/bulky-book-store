using BulkyBookAPI.Services.Book;
using BulkyBookAPI.Services.WishList;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    public class WishListController : ControllerBase
    {
        IWishList _iwishList;
        public WishListController(IWishList wishList)
        {
            _iwishList = wishList;
        }

        [HttpGet("api/wishlist/getwishlistbyuser")]
        public async Task<IActionResult> GetWishListByUser(int userId)
        {
            var result = await this._iwishList.GetWishListByUser(userId);
            return Ok(result);
        }
        [HttpGet("api/wishlist/getwishlistcountbybook")]
        public async Task<IActionResult> GetWishListCountByBook(int bookId)
        {
            var result = await this._iwishList.GetWishListCountByBook(bookId);
            return Ok(result);
        }

        [HttpGet("api/wishlist/getwishlistbyid")]
        public async Task<IActionResult> GetWishListById(int Id)
        {
            var result = await this._iwishList.GetWishListById(Id);
            return Ok(result);
        }

        [HttpGet("api/wishlist/deletewishlist")]
        public async Task<IActionResult> WishListDelete(int userId, int bookId)
        {
            var result = await this._iwishList.WishListDelete(userId, bookId);
            return Ok(result);
        }

        [HttpPost("api/wishlist/addtowishlist")]
        public async Task<IActionResult> UpSert(tbWishList wishlist)
        {
            var result = await this._iwishList.UpSert(wishlist);
            return Ok(result);
        }

    }
}
