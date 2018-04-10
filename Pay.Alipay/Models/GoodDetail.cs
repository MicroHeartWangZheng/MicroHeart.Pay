using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Alipay.Models
{
    public class GoodsDetail
    {
        /// <summary>
        /// 商品的编号
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 商品单价，单位为元
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品类目
        /// </summary>
        public string GoodsCategory { get; set; }

        /// <summary>
        /// 商品描述信息
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 商品的展示地址
        /// </summary>
        public string ShowUrl { get; set; }
    }
}
