using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using APShopDTO;

namespace BusinessLogicLayer
{
    public class ProductBusinessLogic: IProductBusinessLogic
    {
        private readonly IProductManager _productManager;

        public ProductBusinessLogic(IProductManager IProductManager)
        {
            _productManager = IProductManager;

        }

        public string generateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        public void CheckProductId(int porductId)
        {
            if (porductId <= 0)
            {
                throw new ArgumentException("Product ID is invalid");
            }
        }
        public FiltersDTO GetFiltersInObj(int CategoryId, bool FreeShipping, double PriceFrom, double PriceTo, string SerachText)
        {
            return new FiltersDTO
            {
                SerachText = SerachText,
                CategoryId = CategoryId,
                FreeShipping = FreeShipping,
                PriceFrom = PriceFrom,
                PriceTo = PriceTo
            };
        }
    }
}
