using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APShopDTO;
using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer.Interfaces;

namespace APShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailedProductController : ControllerBase
    {

        IProductBusinessLogic _productLogic;
        IProductManager _productManager;

        public DetailedProductController(IProductBusinessLogic productBL, IProductManager productM)
        {
            _productLogic = productBL;
            _productManager = productM;
        }

        [HttpGet("{productId}")]
        public ActionResult GetFullProduct(int productId)
        {
            ProductFull productFull = new ProductFull();
            productFull = _productManager.GetFullProduct(productId);
            return Ok(productFull);

        }

        [HttpPost]
        public ActionResult AddProduct([FromBody] ProductFull productFull)
        {
            productFull.Details.DatePublished = DateTime.Now;
            productFull.Product.Code = _productLogic.generateGUID();

            int productId = _productManager.AddProduct(productFull);

            return Ok(productId);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDetailedProduct(int id, [FromBody] ProductFull product)
        {
            return Ok(_productManager.Update(id, product));

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDetailedProduct(int id)
        {
            _productManager.DeleteProduct(id);
            return Ok("Product deleted");
        }
    }
}