using Data.Models;
using Data.ViewModel;
using Infra.Services;

namespace BulkyBookAPI.Services.Book
{
    public interface IBook
    {
        Task<tbBook> UpSert(tbBook book);
        //Task<List<tbBook>> GetAllBooks();
        Task<Model<WishListViewModel>> GetAllBooks(int? page = 1, int? pageSize = 10, string? sortVal = "Id", 
                           string? sortDir = "asc", string? q = "", string? category = "", int? userid = 0);

        Task<List<tbBook>> GetBooksWithoutPagination();
        tbBook GetBookById(int id);
        Task<int> BookDelete(int id);

        Task<List<string>> GetBooksTitles();

    }
}
