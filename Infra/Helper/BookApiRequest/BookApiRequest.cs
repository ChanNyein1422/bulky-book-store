using Data.Models;
using Data.ViewModel;
using Infra.Services;
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

        public async Task<PagedListClient<WishListViewModel>> GetAllBooks(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc",
                string? q = "", string? category = "", int? userid = 0)
        {
            string url = $"api/book/getallbooks?page={page}&pageSize={pageSize}&sortVal={sortVal}&sortDir={sortDir}&q={q}&category={category}&userid={userid}";
            var data = await ApiRequest<Model<WishListViewModel>>.GetRequest(url.route(Request.bulkybookapi));
            //var data = await GetRequest<Model<tbUser>>(url.route(Request.firstapi));
            PagedListClient<WishListViewModel> model = PagingService<WishListViewModel>.Convert(page ?? 1, pageSize ?? 10, data);
            return model;
        }
        public async Task<tbBook> GetBookById(int id)
        {
            string url = $"api/book/getbookbyid?id={id}";
            var data = await ApiRequest<tbBook>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<string>> GetBooksTitles()
        {
            string url = $"api/book/gettitlearray";
            var data = await ApiRequest<List<string>>.GetRequest(url.route(Request.bulkybookapi));
            return data;
        }

        public async Task<List<tbBook>> GetBooksWithoutPagination()
        {
            string url = $"api/book/getbookswithoutpagination";
            var data = await ApiRequest<List<tbBook>>.GetRequest(url.route(Request.bulkybookapi));
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
