using System;
using System.Collections.Generic;
using System.Text;

namespace APShopDTO
{
    public class Product
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public double ShippingPrice { get; set; }

    }
}
