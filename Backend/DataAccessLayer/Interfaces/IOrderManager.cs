using APShopDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderManager
    {
        List<OrderInfo> GetOrdersByUserId(int userId);
        Order GetOrderItems(int orderId);
        void AddOrderWithItems(Order order);
    }
}
