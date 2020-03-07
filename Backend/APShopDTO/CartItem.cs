using System;
using System.Collections.Generic;
using System.Text;

namespace APShopDTO
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
