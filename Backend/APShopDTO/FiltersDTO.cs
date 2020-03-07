using System;
using System.Collections.Generic;
using System.Text;

namespace APShopDTO
{
    public class FiltersDTO
    {
        public string SerachText { get; set; }
        public int CategoryId { get; set; }
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public bool FreeShipping { get; set; }
    }
}
