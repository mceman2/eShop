using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APShopDTO;
using DataAccessLayer;
using Microsoft.AspNetCore.Cors;
using BusinessLogicLayer;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer.Interfaces;

namespace APShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserManager _userManager;
        IUserBusinessLogic _userLogic;
        ICartManager _cartManager;
        ICartBusinessLogic _cartLogic;


        public UserController(IUserManager um, IUserBusinessLogic IUBL, ICartBusinessLogic ICBL, ICartManager icm)
        {
            _userManager = um;
            _userLogic = IUBL;
            _cartLogic = ICBL;
            _cartManager = icm;
        }
        
        [HttpGet]
        public ActionResult LogIn(string username, string password)
        {
            User user = _userManager.UserLogin(username, password);
            if(user == null)
                return BadRequest();
            return Ok(user.Id);
        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            //return Ok($"USER userId={userId}, a={a}, b={b}" +
            //    Environment.NewLine + $"myAuth={myAuth}");

            User user = _userManager.GetUser(userId);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("{id}/cart")]
        public ActionResult LoadUserCart(int id)
        {
            Cart cart = _userManager.GetCartByUserId(id);
            return Ok(cart);
        }




        [HttpGet("{id}/cart/cartItem")]
        public ActionResult GetCartItem(int id)
        {
            List<CartItem> cartItems;
            try
            {
                cartItems = _userManager.GetCartItems(id).ToList();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(cartItems);
        }


        [HttpPost]
        public ActionResult Register([FromBody] User user)
        {
            if (_userLogic.CheckIfUserExists(user.Username))
                return BadRequest("User already exists");

            int id = _userManager.Register(user, _cartLogic.SetDate());
            return Ok(id);
        }


        [HttpPost("{userId}/cart")]
        public ActionResult PostCartItem(int userId, [FromBody] CartItem cartItem)
        {
            if (!_userLogic.CheckIfUserExists(userId))
                return BadRequest("User not found!");

            try
            {
                _userManager.AddProductToCart(userId, cartItem);
                
            }
            catch(ArgumentNullException ex) {
                return BadRequest(ex.Message);            
            }
            return Ok("OK");

        }


        [HttpPut("{userId}/cart/cartItem/{code}")]
        public ActionResult UpdateCartItem(int userId, string code, [FromBody] CartItem item)
        {
            int newQuantity =_userManager.updateCartItem(userId, code, item.Quantity);
            return Ok(newQuantity);
            
        }


        [HttpDelete("{userId}/cart/cartitem/{code}")]
        public ActionResult DeleteCartItem(int userId, string code)
        {
            List<CartItem> cartContent;
            try
            {
                 cartContent = _userManager.deleteProductFromCart(userId, code, _cartLogic.SetDate());
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(cartContent);
        }


        [HttpGet("{id}/OrderHistory")]
        public ActionResult GetOrderHistory()
        {
            return Ok("proslo");
        }

    }
}