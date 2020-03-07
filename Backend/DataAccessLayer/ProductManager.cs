using AutoMapper;
using DataAccessLayer.Interfaces;
using APShopDTO;
using EF = EfModels;
using System;
using System.Collections.Generic;
using System.Text;
using DbUnitOfWork;
using System.Linq;

namespace DataAccessLayer
{
    public class ProductManager: IProductManager
    {
        private IMapper _mapper;

        public ProductManager(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Product GetProductById(int productId)
        {

            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                var dbProduct = uow.Products.GetProductById(productId);

                return _mapper.Map<Product>(dbProduct);
            }
        }

        public int AddProduct(ProductFull fullProduct)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                EF.Product dbProduct = _mapper.Map<EF.Product>(fullProduct.Product);
                EF.ProductDetails dbProductDetails = _mapper.Map<EF.ProductDetails>(fullProduct.Details);
                dbProduct.IsActive = true;

                dbProduct.ProductDetails.Add(dbProductDetails);
                uow.Products.AddProduct(dbProduct);

                uow.Commit();

                return dbProduct.Id;
            }
        }
        public ProductFull GetFullProduct(int productId)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                EF.Product EfProduct= uow.Products.GetFullProduct(productId);
                ProductFull productFull = new ProductFull();

                var productDetailEntity = EfProduct.ProductDetails.SingleOrDefault();
                productFull.Details = _mapper.Map<ProductDetails>(productDetailEntity);
                productFull.Product = _mapper.Map<Product>(EfProduct);

                return productFull;
            }
        }

        public ProductFull Update(int productId, ProductFull product)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                var dbProductOld = uow.Products.GetById(productId);

                if (dbProductOld == null)
                {
                    throw new ArgumentNullException("Internal server error");
                }
                dbProductOld.IsActive = false;


                var dbProductDetailForAdd = _mapper.Map<EF.ProductDetails>(product.Details);
                dbProductDetailForAdd.Product = _mapper.Map<EF.Product>(product.Product);

                dbProductDetailForAdd.Product.IsActive = true;
                dbProductDetailForAdd.Product.Code = dbProductOld.Code;

                uow.Products.AddProductDetails(dbProductDetailForAdd);

                uow.Commit();

                var dtop = _mapper.Map<Product>(dbProductDetailForAdd.Product);

                var dtopd = _mapper.Map<ProductDetails>(dbProductDetailForAdd);

                return new ProductFull
                {
                    Product = dtop,
                    Details = dtopd
                };
            }
        }
        public void DeleteProduct(int productId)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                uow.Products.DeleteProduct(productId);

                uow.Commit();
            }
        }
        public List<Product> GetProductsByFilters(FiltersDTO filters)
        {
            using (EF.APShopContext context = new EF.APShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                var dbProducts = uow.Products.GetListOfProducts(filters.CategoryId, filters.FreeShipping, filters.PriceFrom, filters.PriceTo, filters.SerachText);

                return _mapper.Map<List<Product>>(dbProducts);
            }
        }
    }
}
