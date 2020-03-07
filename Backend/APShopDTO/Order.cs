using System;
using System.Collections.Generic;
using System.Text;

namespace APShopDTO
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderItem> Items { get; set; }

    }
}
