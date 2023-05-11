using Data.Models;
using Infra.Services;
using Infra.UnitOfWork;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyBookAPI.Services.Book
{
    public class BookBase : IBook
    {
        private ApplicationDbContext _context;
        UnitOfWork _unitOfWork;
        public BookBase(ApplicationDbContext context)
        {
            _context = context;
            this._unitOfWork = new UnitOfWork(_context);
        }
        public int BookDelete(int id)
        {
            var result = _unitOfWork.bookRepo.GetAll().FirstOrDefault(b => b.Id == id);
            if(result != null)
            {
                _unitOfWork.bookRepo.Delete(result);
                return 1;
            }
            return 0;
        }

        //public async Task<List<tbBook>> GetAllBooks()
        //{
        //    var result = await _unitOfWork.bookRepo.GetAll().ToListAsync();
        //    return result;
        //}
        public async Task<Model<tbBook>> GetAllBooks(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc", string? q = "", string? category = "")
        {
            Expression<Func<tbBook, bool>> basicFilter = null;
            Expression<Func<tbBook, bool>> categoryFilter = null;
            IQueryable<tbBook> query = _unitOfWork.bookRepo.GetAll().AsQueryable();
            if (!String.IsNullOrEmpty(q))
            {
                basicFilter = PredicateBuilder.New<tbBook>();
                basicFilter = basicFilter.Or(a => a.Title.Contains(q));
                basicFilter = basicFilter.Or(a => a.Author.Contains(q));
                basicFilter = basicFilter.Or(a => a.Publisher.Contains(q));
                query = query.Where(basicFilter);
            }

            if (!String.IsNullOrEmpty(category))
            {
                categoryFilter = c => c.Category.Contains(category);
                query = query.Where(categoryFilter);
            }

            query = SORTLIT<tbBook>.Sort(query, sortVal, sortDir);
            var result = await PagingService<tbBook>.getPaging(page ?? 1, pageSize ?? 10, query);

            return result;
        }

        public tbBook GetBookById(int id)
        {
            var result = _unitOfWork.bookRepo.GetById(id);
            if(result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<tbBook> UpSert(tbBook book)
        {
            try
            {
                if (book.Id > 0)
                {
                    book = await _unitOfWork.bookRepo.UpdateAsync(book);
                }
                else
                {
                    book.UploadedDate = DateTime.Now;
                    book = await _unitOfWork.bookRepo.InsertReturnAsync(book);
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return book;
        }
    }
}
