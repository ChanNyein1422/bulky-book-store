using BulkyBookAPI.Services.Book;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAPI.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        IBook _ibook;

        public BookController(IBook ibook)
        {
            _ibook = ibook;
        }

        [HttpGet("api/book/getallbooks")]
        public async Task<IActionResult> GetBooks(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc",
                                string? q = "", string? category = "")
        {
            var result = await this._ibook.GetAllBooks(page, pageSize, sortVal, sortDir, q, category);
            return Ok(result);
        }

        [HttpGet("api/book/getbookbyid")]
        public IActionResult GetBookById(int id) { 
            var result = this._ibook.GetBookById(id);
            return Ok(result);
        }

        [HttpGet("api/book/deletebook")]
        public IActionResult DeleteBook(int id) { 
            var result = this._ibook.BookDelete(id);
            return Ok(result);
        }

        [HttpPost("api/book/uploadbook")]
        public async Task<IActionResult> UpSert(tbBook book) {
            var result = await _ibook.UpSert(book);
            return Ok(result);
        }
    }
}
