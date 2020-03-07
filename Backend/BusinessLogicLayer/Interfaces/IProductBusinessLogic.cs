using APShopDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IProductBusinessLogic
    {
        string generateGUID();
        void CheckProductId(int porductId);
        FiltersDTO GetFiltersInObj(int CategoryId, bool FreeShipping, double PriceFrom, double PriceTo, string SerachText);
    }
}
