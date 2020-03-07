using EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbRepositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(APShopContext context)
            : base(context)
        {
        }

        public override User GetById(int id)
        {
            return _dbSet.SingleOrDefault(u => u.Id == (int)id);
        }

        public User GetByUsernameAndPassword(string username, string passwordHash)
        {
            return _dbSet.SingleOrDefault(u => u.Username == username && u.Password == passwordHash);
        }
        public User GetUserByUsername(string username)
        {
            return _dbSet.Where(x => x.Username == username).SingleOrDefault();
        }
        public bool CheckIfUserExists(string username) 
        {
            return _dbSet.Any(u => u.Username == username);
        }
        public bool CheckIfUserExists(int userId)
        {
            return _dbSet.Any(u => u.Id == userId);
        }
        public void CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("There is no user!");

            _dbSet.Add(user);
        }
        public void addCartProduct(CartProduct cartProduct) 
        {
            _context.CartProduct.Add(cartProduct);
        }
        public void updateCartItem(CartProduct cartProduct)
        {
            _context.CartProduct.Update(cartProduct);
        }
        public void deleteCartProduct(CartProduct cartProduct)
        {
            _context.CartProduct.Remove(cartProduct);
        }
    }
}
