using Data.Models;
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
        Task<int> DeleteBook(int id);
        Task<PagedListClient<tbBook>> GetAllBooks(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc",
                        string? q = "", string? category = "");
        Task<List<string>> GetBooksTitles();

    }
}
