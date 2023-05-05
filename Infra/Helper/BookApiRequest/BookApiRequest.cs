using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper.BookApiRequest
{
    public class BookApiRequest : IBookApiRequest
    {
        public async Task<int> DeleteBook(int id)
        {
            string url = $"api/book/deletebook?id={id}";
            var data = await ApiRequest<int>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<tbBook>> GetAllBooks()
        {
            string url = $"api/book/getallbooks";
            var data = await ApiRequest<List<tbBook>>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<tbBook> GetBookById(int id)
        {
            string url = $"api/book/getbookbyid?={id}";
            var data = await ApiRequest<tbBook>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<tbBook> UpSert(tbBook book)
        {
            string url = $"api/book/uploadbook";
            var data = await ApiRequest<tbBook>.PostRequest(url.route(Request.bulkybookapi), book);
            return data;
        }
    }
}
