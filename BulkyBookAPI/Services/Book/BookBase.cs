using Data.Models;
using Data.ViewModel;
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
        public async Task<int> BookDelete(int id)
        {
            var result = await _unitOfWork.bookRepo.GetAll().FirstOrDefaultAsync(b => b.Id == id);
            if(result != null)
            {
                var categoryArray = result.Category.Split(", ");
                foreach (var i in categoryArray)
                {
                    var category = _unitOfWork.categoryRepo.GetAll().Where(a => a.Category == i).FirstOrDefault();
                    if (category != null)
                    {
                        category.BookCount -= 1;
                        category = await _unitOfWork.categoryRepo.UpdateAsync(category);
                    }
                }
                _unitOfWork.bookRepo.Delete(result);
              
                return 1;
            }
            return 0;
        }

        public async Task<Model<WishListViewModel>> GetAllBooks(int? page = 1, int? pageSize = 10, string? sortVal = "Id",
            string? sortDir = "asc", string? q = "", string? category = "", int? userid = 0)
        {
            Expression<Func<tbBook, bool>> basicFilter = null;
            Expression<Func<tbBook, bool>> categoryFilter = null;
            IQueryable<tbBook> query = _unitOfWork.bookRepo.GetAll().AsQueryable();
            if (!String.IsNullOrEmpty(q))
            {
                basicFilter = PredicateBuilder.New<tbBook>();
                basicFilter = basicFilter.Or(a => a.Title.StartsWith(q));
                basicFilter = basicFilter.Or(a => a.Author.StartsWith(q));
                basicFilter = basicFilter.Or(a => a.Publisher.StartsWith(q));
                query = query.Where(basicFilter);
            }

            if (!String.IsNullOrEmpty(category))
            {
                categoryFilter = c => c.Category.Contains(category);
                query = query.Where(categoryFilter);
            }

            var wishlist = _unitOfWork.wishListRepo.GetAll().Where(a => a.UserId == userid).AsQueryable();

            query = SORTLIT<tbBook>.Sort(query, sortVal, sortDir);

            var bookModel = (from book in query
                          select new WishListViewModel
                          {
                              book = book,
                              isWishListed = wishlist.Where(a => a.BookId == book.Id).FirstOrDefault() != null ? true : false,
                              WishListCount = wishlist.Where(a => a.BookId == book.Id).Count()
                          });;

            var result = await PagingService<WishListViewModel>.getPaging(page ?? 1, pageSize ?? 10, bookModel);

            return result;
        }

        public async Task<List<string>> GetBooksTitles()
        {
            var data = await _unitOfWork.bookRepo.GetAll().Select(a=>a.Title).ToListAsync(); //.Select(a=>a.Title).
            return data;
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
                    if(book.Category == "")
                    {
                        book.Category = "N/A";
                    }
                    book = await _unitOfWork.bookRepo.InsertReturnAsync(book);
                    var categoryArray = book.Category.Split(", ");
                    foreach(var i in categoryArray)
                    {
                        var category = _unitOfWork.categoryRepo.GetAll().Where(a => a.Category == i).FirstOrDefault();
                        if (category != null)
                        {
                            category.BookCount += 1;
                            category = await _unitOfWork.categoryRepo.UpdateAsync(category);
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return book;
        }

        public async Task<List<tbBook>> GetBooksWithoutPagination()
        {
            var data = await _unitOfWork.bookRepo.GetAll().ToListAsync();
            return data;
        }
    }
}
