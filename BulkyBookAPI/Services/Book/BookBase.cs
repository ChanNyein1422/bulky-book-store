using Data.Models;
using Infra.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<tbBook>> GetAllBooks()
        {
            var result = await _unitOfWork.bookRepo.GetAll().ToListAsync();
            return result;
        }

        public  tbBook GetBookById(int id)
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
