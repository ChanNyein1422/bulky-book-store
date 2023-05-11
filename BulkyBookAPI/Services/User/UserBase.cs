﻿using Core.Extensions;
using Data.Models;
using Infra.Helper;
using Infra.Services;
using Infra.UnitOfWork;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyBookAPI.Services.User
{
    public class UserBase : IUser
    {
        private ApplicationDbContext _context;
        UnitOfWork _unitOfWork;

        public UserBase(ApplicationDbContext context)
        {
            _context = context;
            this._unitOfWork = new UnitOfWork(_context);
        }
        public async Task<Model<tbUser>> GetAllUsers(int? page = 1, int? pageSize = 10, string? sortVal = "Id", string? sortDir = "asc", string? q = "")
        {
            Expression<Func<tbUser, bool>> basicFilter = null;
            Expression<Func<tbUser, bool>> emailFilter = null;
            IQueryable<tbUser> query = _unitOfWork.userRepo.GetAll().AsQueryable();
            if (!String.IsNullOrEmpty(q))
            {
                basicFilter = PredicateBuilder.New<tbUser>();
                basicFilter = basicFilter.Or(a => a.Name.Contains(q));
                basicFilter = basicFilter.Or(a => a.Email.Contains(q));
                query = query.Where(basicFilter);
            }
            query = SORTLIT<tbUser>.Sort(query, sortVal,sortDir);
            var result = await PagingService<tbUser>.getPaging(page ?? 1, pageSize ?? 10, query);

            return result;
        }

        public tbUser GetUserById(int id)
        {
            return _unitOfWork.userRepo.GetById(id);

        }

        public async Task<tbUser> LoginUser(string email, string password)
        {
            tbUser user = await _unitOfWork.userRepo.GetAll().FirstOrDefaultAsync(u => u.Email == email && u.Password == password) ?? new tbUser();
            return user;
        }

        public async Task<tbUser> UpSert(tbUser user)
        {
            try
            {
                var checkEmail = _unitOfWork.userRepo.GetAll().Any(u => u.Email == user.Email && u.Id != user.Id);
                var checkUsername = _unitOfWork.userRepo.GetAll().Any(u => u.Name == user.Name && u.Id != user.Id);



                  
                   
                    if (user.ConfirmPassword != user.Password)
                    {
                        user = new tbUser();
                        user.ReturnMessage = "Unmatch Password";
                    }
                        else if (checkEmail)
                    {
                        user = new tbUser();
                        user.ReturnMessage = "Email Already Exists";
                    }
                        else if (checkUsername)
                    {
                        user = new tbUser();
                        user.ReturnMessage = "User Name Already Exists";
                    }
                    else if (!checkEmail & !checkUsername)
                    {
                        if (user.Id > 0)
                        {

                        user = await _unitOfWork.userRepo.UpdateAsync(user);
                        }
                        else
                        {
                        user.CreatedDate = MyExtensions.getLocalTime();
                        user = await _unitOfWork.userRepo.InsertReturnAsync(user);
                        }
                    }
                

            }catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public int UserDelete(int id)
        {
            var user = _unitOfWork.userRepo.GetAll().FirstOrDefault(data => data.Id == id);
            if(user != null)
            {
                _unitOfWork.userRepo.Delete(user);
                return 1;
            }
            return 0;
        }
    }
}
