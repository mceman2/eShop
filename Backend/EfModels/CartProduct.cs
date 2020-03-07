using System;
using System.Collections.Generic;

namespace EfModels
{
    public partial class CartProduct
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
