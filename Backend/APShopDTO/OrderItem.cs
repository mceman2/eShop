﻿using System;
using System.Collections.Generic;
using System.Text;

namespace APShopDTO
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
