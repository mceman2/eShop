using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APShopDTO;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer.Interfaces;

namespace APShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IOrderBusinessLogic _orderLogic;
        public OrderController(IOrderManager orderManager, IOrderBusinessLogic orderLogic)
        {
            _orderManager = orderManager;
            _orderLogic = orderLogic;
        }

        [HttpGet("{id}")]
        public Order GetOrderItems(int id)
        {
            return _orderManager.GetOrderItems(id);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Order order)
        {
            _orderLogic.CheckIfHasOrderItem(order);
            _orderManager.AddOrderWithItems(order);
            return Ok("Proslo");
        }
    }
}