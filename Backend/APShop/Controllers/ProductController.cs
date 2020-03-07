using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APShopDTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace APShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IProductBusinessLogic _productLogic;
        IProductManager _productManager;

        public ProductController(IProductBusinessLogic productBL, IProductManager productM)
        {
            _productLogic = productBL;
            _productManager = productM;
        }

        [HttpGet]
        public List<Product> Get(int CategoryId, bool FreeShipping, double PriceFrom, double PriceTo, string SearchText)
        {
            var filters = _productLogic.GetFiltersInObj(CategoryId, FreeShipping, PriceFrom, PriceTo, SearchText);

            return _productManager.GetProductsByFilters(filters);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _productLogic.CheckProductId(id);

            _productManager.GetProductById(id);

            return Ok();
        }
    }
}