
using Data.Models;
using Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private IRepository<tbUser>? _userRepo;
        private IRepository<tbBook>? _bookRepo;
        private IRepository<tbCategory>? _categoryRepo;
        private IRepository<tbOrder>? _orderRepo;
        private IRepository<tbOrderDetail>? _orderDetailRepo;
        private IRepository<tbWishList>? _wishListRepo;

        private ApplicationDbContext _ctx;
        private bool m_IsDisposed;
        public UnitOfWork(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        ~UnitOfWork()
        {
            _ctx.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!m_IsDisposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
                _ctx = null;
                m_IsDisposed = true;
            }
        }

        public IRepository<tbUser> userRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new Repository<tbUser>(_ctx);
                }
                return _userRepo;
            }
        }
        public IRepository<tbBook> bookRepo
        {
            get
            {
                if(_bookRepo == null)
                {
                    _bookRepo = new Repository<tbBook>(_ctx);
                }
                return _bookRepo;
            }
        }
        public IRepository<tbCategory> categoryRepo
        {
            get
            {
                if(_categoryRepo == null)
                {
                    _categoryRepo = new Repository<tbCategory>(_ctx);
                }
                return _categoryRepo;
            }
        }
        public IRepository<tbOrder> orderRepo
        {
            get
            {
                if(_orderRepo == null)
                {
                    _orderRepo = new Repository<tbOrder>(_ctx);
                }
                return _orderRepo;
            }
        }
        public IRepository<tbOrderDetail> orderDetailRepo
        {
            get
            {
                if (_orderDetailRepo == null)
                {
                    _orderDetailRepo = new Repository<tbOrderDetail>(_ctx);
                }
                return _orderDetailRepo;
            }
        }
        public IRepository<tbWishList> wishListRepo
        {
            get
            {
                if (_wishListRepo == null)
                {
                    _wishListRepo = new Repository<tbWishList>(_ctx);
                }
                return _wishListRepo;
            }
        }
    }
}
