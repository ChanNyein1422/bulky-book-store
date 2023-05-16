using Data.Models;
using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookAPI.Services.User
{
    public class ValidateBase : IValidate
    {
        private ApplicationDbContext _context;
        UnitOfWork _uow;
        public ValidateBase(ApplicationDbContext context) {
            _context = context;
            this._uow = new UnitOfWork(_context);
        }
        public bool CheckEmail(tbUser user)
        {
            var result =  _uow.userRepo.GetAll().Any(u => u.Email == user.Email && u.Id != user.Id);
           return result;
        }

        public bool CheckUserName(tbUser user)
        {
            var result =  _uow.userRepo.GetAll().Any(u => u.Name == user.Name && u.Id != user.Id);
            return result;
        }
    }
}
