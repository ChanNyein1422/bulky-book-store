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
    public interface IBookApiRequest
    {
        Task<tbBook> UpSert(tbBook book);
        Task<tbBook> GetBookById(int id);
        Task<List<tbBook>> GetBooksWithoutPagination();
        Task<int> DeleteBook(int id);
        Task<PagedListClient<WishListViewModel>> GetAllBooks(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc",
                        string? q = "", string? category = "", int? userid = 0);
        Task<List<string>> GetBooksTitles();

    }
}
