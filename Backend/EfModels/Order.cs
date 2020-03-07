using System;
using System.Collections.Generic;

namespace EfModels
{
    public partial class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
