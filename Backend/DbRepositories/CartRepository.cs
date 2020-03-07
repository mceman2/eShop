using EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbRepositories
{
    public class CartRepository : Repository<Cart>
    {
        public CartRepository(APShopContext context)
            : base(context)
        {
        }

        public override Cart GetById(int id)
        {
            return _dbSet.SingleOrDefault(u => u.Id == (int)id);
        }

        //public user getbyusernameandpassword(string username, string passwordhash)
        //{
        //    return _dbset.singleordefault(u => u.username == username && u.password == passwordhash);
        //}
        public Cart GetByUserId(int userId)
        {
            return _dbSet.SingleOrDefault(c => c.UserId == userId);
        }


    }
}
