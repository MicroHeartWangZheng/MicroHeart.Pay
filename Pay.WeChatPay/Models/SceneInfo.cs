using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.WeChatPay.Models
{
    public class SceneInfo
    {
        /// <summary>
        /// 门店唯一标识
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 门店所在地行政区划码，详细见《最新县及县以上行政区划代码》
        /// </summary>
        [JsonProperty("area_code")]
        public string AreaCode { get; set; }

        /// <summary>
        /// 门店详细地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
