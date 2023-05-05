using Data.Models;
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
        Task<List<tbBook>> GetAllBooks();

    }
}
