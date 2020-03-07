using EfModels;
using System;
using System.Collections.Generic;
using System.Text;
using APShopDTO;

namespace DataAccessLayer.Interfaces
{
    public interface ICartManager
    {
        APShopDTO.Cart GetCartByUserId(int userId);
    }
}
