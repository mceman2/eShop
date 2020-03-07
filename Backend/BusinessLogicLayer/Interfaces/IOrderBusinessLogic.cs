using APShopDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IOrderBusinessLogic
    {
        void CheckIfHasOrderItem(Order order);
    }
}
