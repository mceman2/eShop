using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfModels;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories
{
    public class ProductRepository : Repository<Product>
    {
        private readonly APShopContext _context;


        public ProductRepository(APShopContext context)
            : base(context)
        {
            _context = context;
        }

        public override Product GetById(int id)
        {
            return _dbSet.SingleOrDefault(p => p.Id == id);
        }
        public Product GetProductById(int productId)
        {
            return _dbSet.Where(x => x.Id == productId).SingleOrDefault();
        }
        public IEnumerable<Product> GetProductsByCode(List<string> codes)
        {
            return _dbSet.Where(x => codes.Contains(x.Code) && x.IsActive == true);
        }
        public void AddProduct(Product product)
        {
            _dbSet.Add(product);
        }
        public Product GetFullProduct(int productId)
        {
            return _dbSet.Include("ProductDetails.Product").SingleOrDefault(p => p.Id == productId);
        }
        public void AddProductDetails(ProductDetails productDetails)
        {
            _context.ProductDetails.Add(productDetails);
        }
        public void DeleteProduct(int productId)
        {
            _dbSet.Where(x => x.Id == productId).SingleOrDefault().IsActive = false;
        }
        public List<Product> GetListOfProducts(int CategoryId, bool FreeShipping, double PriceFrom, double PriceTo, string SerachText)
        {
            var query = _context.Product.AsQueryable();

            //if (CategoryId > 0)
            //{
            //    query = query.Where(x => x.ProductDetails.SingleOrDefault().Category == CategoryId);
            //}
            if (FreeShipping == true)
            {
                query = query.Where(x => x.ShippingPrice == 0);
            }
            if (PriceFrom > 0)
            {
                query = query.Where(x => x.Price >= (decimal)PriceFrom);
            }
            if (PriceTo > 0)
            {
                query = query.Where(x => x.Price <= (decimal)PriceTo);
            }
            if (SerachText != null)
            {
                query = query.Where(x => x.Name.Contains(SerachText));
            }

            return query.AsNoTracking().OrderBy(x => x.Name).ToList();
        }
    }
}
