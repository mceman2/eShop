using APShopDTO;
using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class OrderBusinessLogic: IOrderBusinessLogic
    {
        public void CheckIfHasOrderItem(Order order)
        {
            if (!order.Items.Any())
            {
                throw new Exception("You need at least one item in cart for checkout!");
            }
        }
    }
}
