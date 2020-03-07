using System;
using System.Collections.Generic;
using System.Text;
using APShopDTO;
using EF = EfModels;

namespace DataAccessLayer.Interfaces
{
    public interface IProductManager
    {
        int AddProduct(ProductFull fullProduct);
        ProductFull GetFullProduct(int productId);
        ProductFull Update(int productId, ProductFull product);
        void DeleteProduct(int productId);
        List<Product> GetProductsByFilters(FiltersDTO filters);
        Product GetProductById(int productId);
    }
}
