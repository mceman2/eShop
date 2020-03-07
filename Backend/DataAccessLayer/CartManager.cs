using EF = EfModels;
using APShopDTO;
using System;
using System.Collections.Generic;
using System.Text;
using DbUnitOfWork;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class CartManager: ICartManager
    {
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
    }
}
