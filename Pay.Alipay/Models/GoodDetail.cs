using Newtonsoft.Json;
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
        [JsonProperty("goods_id")]
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("goods_name")]
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 商品单价，单位为元
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// 商品类目
        /// </summary>
        [JsonProperty("goods_category")]
        public string GoodsCategory { get; set; }

        /// <summary>
        /// 商品描述信息
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// 商品的展示地址
        /// </summary>
        [JsonProperty("show_url")]
        public string ShowUrl { get; set; }
    }
}
