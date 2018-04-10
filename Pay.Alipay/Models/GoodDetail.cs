using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Alipay.Models
{
    public class GoodsDetail
    {
        public string GoodsId { get; set; }

        public string GoodsName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string GoodsCategory { get; set; }

        public string Body { get; set; }

        public string ShowUrl { get; set; }
    }
}
