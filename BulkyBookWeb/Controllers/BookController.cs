using Data.Models;
using Infra.Helper.BookApiRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

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
        public async Task<IActionResult> _BookList()
        {
            var data = await this._ibook.GetAllBooks();
            return PartialView(data);
        }
        public IActionResult _AddBook()
        {
            tbBook book = new tbBook();
            return PartialView(book);
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
            var data = await this._ibook.DeleteBook(id);
            if (data == 1)
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
