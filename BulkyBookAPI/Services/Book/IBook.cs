using Data.Models;
using Infra.Services;

namespace BulkyBookAPI.Services.Book
{
    public interface IBook
    {
        Task<tbBook> UpSert(tbBook book);
        //Task<List<tbBook>> GetAllBooks();
        Task<Model<tbBook>> GetAllBooks(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc", string? q = "", string? category = "");
        tbBook GetBookById(int id);

        int BookDelete(int id);

    }
}
