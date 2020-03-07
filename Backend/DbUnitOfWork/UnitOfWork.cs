using DbRepositories;
using EfModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APShopContext _context;
        private UserRepository _users;
        private CartRepository _cart;
        private ProductRepository _product;
        private OrderRepository _order;

        public UnitOfWork(APShopContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }
            _context = context;
        }
        #region IUnitOfWork Members      

        //public IRepository<User> Users
        public UserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public CartRepository Carts
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new CartRepository(_context);
                }
                return _cart;
            }
        }

        public ProductRepository Products
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_context);
                }
                return _product;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_context);
                }
                return _order;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
