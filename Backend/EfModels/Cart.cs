using System;
using System.Collections.Generic;

namespace EfModels
{
    public partial class Cart
    {
        public Cart()
        {
            CartProduct = new HashSet<CartProduct>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateLastUpdated { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartProduct> CartProduct { get; set; }
    }
}
