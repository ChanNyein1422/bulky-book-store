using Data.Models;

namespace BulkyBookAPI.Services.Book
{
    public interface IBook
    {
        Task<tbBook> UpSert(tbBook book);
        Task<List<tbBook>> GetAllBooks();
        tbBook GetBookById(int id);

        int BookDelete(int id);

    }
}
