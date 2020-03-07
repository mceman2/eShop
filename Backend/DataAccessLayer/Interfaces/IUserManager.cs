using System;
using System.Collections.Generic;
using System.Text;
using APShopDTO;
using DataAccessLayer;
using EF = EfModels;


namespace DataAccessLayer
{
    public interface IUserManager
    {
        User GetUser(int id);
        User UserLogin(string username, string passwordHash);
        bool CheckIfUserExists(string username);
        bool CheckIfUserExists(int userId);
        int Register(User user, DateTime cartDate);
        Cart GetCartByUserId(int id);
        IEnumerable<CartItem> GetCartItems(int userId);
        void AddProductToCart(int userId, CartItem cartItem);
        int updateCartItem(int userId, string cartItemCode, int quantity);
        List<CartItem> deleteProductFromCart(int userId, string code, DateTime dateTime);


    }
}
