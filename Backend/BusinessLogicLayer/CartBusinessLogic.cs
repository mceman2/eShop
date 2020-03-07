using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public class CartBusinessLogic: ICartBusinessLogic
    {
        public DateTime SetDate()
        {
            return DateTime.Now;
        }
    }
}
