using APShopDTO;
using EF = EfModels;
using AutoMapper;
using DataAccessLayer.Interfaces;
using DbUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class OrderManager: IOrderManager
    {
        private readonly IMapper _mapper;

        public OrderManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddOrderWithItems(Order order)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                var orderDB = _mapper.Map<EF.Order>(order);

                uow.Orders.AddOrderWithItems(orderDB);
            }
        }
        public Order GetOrderItems(int orderId)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                var orderItemsDB = uow.Orders.GetOrderIncludeOrderProductsIncludeProduct(orderId);

                var result = _mapper.Map<Order>(orderItemsDB);
                result.Items = _mapper.Map<List<OrderItem>>(orderItemsDB.OrderProduct);
                return result;
            }
        }

        public List<OrderInfo> GetOrdersByUserId(int userId)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                var orders = uow.Orders.GetOrdersByUserId(userId);

                return _mapper.Map<List<OrderInfo>>(orders);
            }
        }
    }
}
