using System;
using System.Collections.Generic;
using System.Text;
using EfModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace DbRepositories
{
    public class OrderRepository: Repository<Order>
    {
        private readonly APShopContext _context;
        public OrderRepository(APShopContext context)
            : base(context)
        {
            _context = context;
        }

        public override Order GetById(int id)
        {
            return _dbSet.SingleOrDefault(o => o.Id == id);
        }

        public void AddOrderWithItems(Order order)
        {
            _dbSet.Add(order);
        }
        public Order GetOrderIncludeOrderProductsIncludeProduct(int orderId)
        {
            return _dbSet.Include("OrderProduct.Product").Where(x => x.Id == orderId).SingleOrDefault();
        }
        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _dbSet.Where(x => x.UserId == userId);
        }
    }
}
