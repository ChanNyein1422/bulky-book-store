using Data.Models;
using Infra.Helper.BookApiRequest;
using Infra.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace BulkyBookWeb.Controllers
{
    public class BookController : Controller
    {
        IBookApiRequest _ibook;
        public BookController(IBookApiRequest ibook)
        {
            this._ibook = ibook;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> _BookList(int? page = 1, int? pageSize = 5, string? sortVal = "Id", string? sortDir = "asc", string? q = "", string? category = "", int? userid = 0)
        {
            var data = await this._ibook.GetAllBooks(page, pageSize, sortVal, sortDir, q, category, userid);
           return PartialView(data);
            
        }
        public async Task<IActionResult> _BookListScroll(int? page = 1, int? pageSize = 5, string? sortVal = "Id", string? sortDir = "asc", string? q = "", string? category = "", int? userid = 0)
        {
            var data = await this._ibook.GetAllBooks(page, pageSize, sortVal, sortDir, q, category, userid);



            if (data.Results.Count != 0)
            {

                return PartialView(data);
            }
            else
            {
                if (page == 1)
                {
                    return Ok("Book Not Found");
                }
                else
                {
                  return Ok("NoResult");
                }


            }

        }
        public async Task<IActionResult> _BookListWithoutPagination()
        {
            var data = await this._ibook.GetBooksWithoutPagination();
            return PartialView(data);
        }
        //to be fixed
        public async Task<IActionResult> GetBooksTitles()
        {
            var data = await this._ibook.GetBooksTitles();
            return Ok(data);
        }
        public IActionResult _AddBook()
        {
            tbBook book = new tbBook();
            return PartialView(book);
        }
        public async Task<IActionResult> _BookDetail(int id)
        {
            var data = await this._ibook.GetBookById(id);
            return PartialView(data);
        }
        public static string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "/9J/4":
                    return "jpg";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                default:
                    return string.Empty;
            }
        }
        [HttpPost]
        [DisableRequestSizeLimit]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> UpSert(tbBook book)
        {
            if (book.BookUpload != null)
            {

                var ext = GetFileExtension(book.BookUpload);

                string bookName = Guid.NewGuid() + "." + ext;

                //set the image path
                string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\BookUpload", bookName);

                byte[] pdfBytes = Convert.FromBase64String(book.BookUpload);

                System.IO.File.WriteAllBytes(pdfPath, pdfBytes);

                book.BookUpload = bookName;
            }
            if(book.Thumbnail != null)
            {
                var ext = GetFileExtension(book.Thumbnail);

                string imageName = Guid.NewGuid() + "." + ext;

                //set the image path
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Thumbnails", imageName);

                byte[] imageBytes = Convert.FromBase64String(book.Thumbnail);

                System.IO.File.WriteAllBytes(imgPath, imageBytes);

                book.Thumbnail = imageName;
            }
            var data = await this._ibook.UpSert(book);
            return Ok(data);
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            var data = await this._ibook.GetBookById(id);

            if (data.BookUpload != null)
            {
                string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\BookUpload", data.BookUpload);
                System.IO.File.Delete(pdfPath);
            }
            if(data.Thumbnail != null)
            {
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Thumbnails", data.Thumbnail);
                System.IO.File.Delete(imgPath);
            }
            var result = await this._ibook.DeleteBook(id);


            if (result == 1)
            {
                return Json("Success");
               
            }
            else
            {
                return Json("Failed");
            }
        }
    }
}
