using DbUnitOfWork;
using EF = EfModels;
using System;
using APShopDTO;
using System.Linq;
using AutoMapper;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class UserManager : IUserManager
    {
        private IMapper _mapper;

        public UserManager(IMapper mapper)
        {
            _mapper = mapper;
        }
        public User UserLogin(string username, string passwordHash)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                EF.User efUser = uow.Users.GetByUsernameAndPassword(username, passwordHash);
                if (efUser is null)
                    return null;

                User user = _mapper.Map<User>(efUser);

                return user;
            }
        }
        public User GetUserByUsername(string username)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                var dbUser = uow.Users.GetUserByUsername(username);

                if (dbUser == null)
                {
                    throw new ArgumentNullException("User not found");
                }

                return _mapper.Map<User>(dbUser);
            }

        }

        public bool CheckIfUserExists(string username)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                return uow.Users.CheckIfUserExists(username);
            }
        }
        public bool CheckIfUserExists(int userId)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                return uow.Users.CheckIfUserExists(userId);
            }
        }

        public User GetUser(int id)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                //EF.User efUser = uow.Users.GetAll().FirstOrDefault();

                EF.User efUser = uow.Users.GetById(id);
                if (efUser is null)
                    return null;

                User user = new User()
                {
                    Id = efUser.Id,
                    Username = efUser.Username,
                    Password = efUser.Password,
                    Role = efUser.Role
                };

                return user;
            }
        }

        public static void PostUser(User userDBO)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                EF.User efUser = new EF.User()
                {
                    Username = userDBO.Username,
                    Password = userDBO.Password,
                    Role = userDBO.Role
                };

                uow.Users.Add(efUser);
                context.SaveChanges();
            }
        }

        public int Register(User user, DateTime cartDate)
        {
            if (user == null)
                throw new ArgumentNullException("User info not supplied");

            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                EF.User dboUser = _mapper.Map<EF.User>(user);
                uow.Users.CreateUser(dboUser);

                EF.Cart dbCart = new EF.Cart()
                {
                    DateLastUpdated = cartDate
                };
                dboUser.Cart.Add(dbCart); //virtuelni clan
                uow.Commit();
                return dboUser.Id;
            }
        }
        public Cart GetCartByUserId(int userId)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                EF.Cart efUserCart = uow.Carts.GetByUserId(userId);

                if (efUserCart is null)
                    return null;

                Cart cart = new Cart()
                {
                    Id = efUserCart.Id,
                    UserId = efUserCart.UserId,
                    DateLastUpdated = efUserCart.DateLastUpdated
                };

                return cart;
            }
        }
        public IEnumerable<CartItem> GetCartItems(int userId)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                List<EF.CartProduct> cartDBContent = context.CartProduct.Where(x => x.Cart.UserId == userId).ToList();

                if (cartDBContent == null)
                    throw new ArgumentNullException("Couldn't find requested resource");
                if (cartDBContent.Count() == 0)
                    //throw new Exception("No products in your cart, add something you like");
                    return new List<CartItem>();

                List<string> codes = new List<string>();
                foreach (var item in cartDBContent)
                {
                    codes.Add(item.Code);
                }

                List<EF.Product> cartdbProducts = uow.Products.GetProductsByCode(codes).ToList();
                if (cartdbProducts == null || cartdbProducts.Count() == 0)
                    throw new ArgumentNullException("Couldn't find requested resource");


                List<CartItem> cartDTOItems = new List<CartItem>();

                cartDTOItems = _mapper.Map<List<CartItem>>(cartDBContent);

                for (int i = 0; i < cartDTOItems.Count(); i++)
                {
                    cartDTOItems[i].Product = _mapper.Map<Product>(cartdbProducts[i]);
                }
                return cartDTOItems;
            }
        }


        public void AddProductToCart(int userId, CartItem cartItem)
        {// ovde moras provjeriti da li se dodaje postojeci item, ako dodaje povecaj mu samo quantity
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                List<CartItem> userCartItems = GetCartItems(userId).ToList();
                foreach(CartItem item in userCartItems)
                {
                    if(item.Code == cartItem.Code)
                    {
                        EF.CartProduct dboCartProduct1 = new EF.CartProduct();
                        dboCartProduct1 = _mapper.Map<EF.CartProduct>(item);
                        dboCartProduct1.Quantity += cartItem.Quantity;

                        context.CartProduct.Update(dboCartProduct1);
                        context.SaveChanges();

                        return;
                    }
                }
               // EF.Cart cart = context.Cart.Where(c => c.UserId == userId).SingleOrDefault();
                EF.CartProduct dboCartProduct = new EF.CartProduct();
                //dboCartProduct.CartId = cart.Id;
                dboCartProduct.Code = cartItem.Code;
                dboCartProduct.Quantity = cartItem.Quantity;
                
                uow.Carts.GetByUserId(userId).CartProduct.Add(dboCartProduct);
                //uow.Users.addCartProduct(dboCartProduct);

                uow.Commit();

            }
        }
        public int updateCartItem(int userId, string cartItemCode, int quantity)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                EF.CartProduct cartItem = context.CartProduct.Where(p => p.Cart.UserId == userId && p.Code == cartItemCode).SingleOrDefault();
                cartItem.Quantity = quantity;
                uow.Users.updateCartItem(cartItem);
                uow.Commit();
                return cartItem.Quantity;

            }
        }

        public List<CartItem> deleteProductFromCart(int userId, string code, DateTime dateTime)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                EF.CartProduct productToDelete = context.CartProduct.Include(c => c.Cart).
                    Where(p => p.Cart.UserId == userId && p.Code == code).SingleOrDefault();
               // EF.CartProduct productToDelete = uow.Users.GetById(userId).Cart.SingleOrDefault().CartProduct.Where(p => p.Code == code && p.Cart.UserId ==userId).SingleOrDefault();

                if (productToDelete == null)
                    throw new ArgumentNullException("Couldn't find requested resource");

                productToDelete.Cart.DateLastUpdated = dateTime;
                uow.Users.deleteCartProduct(productToDelete);
                
                uow.Commit();

                return GetCartItems(userId).ToList();

            }
        }
    }
}
