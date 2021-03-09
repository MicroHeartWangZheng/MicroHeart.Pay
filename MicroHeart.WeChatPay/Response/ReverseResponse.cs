using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroHeart.WeChatPay.Response
{
    public class ReverseResponse:WeChatPayResponse
    {
        /// <summary>
        /// 是否需要继续调用撤销，Y-需要，N-不需要
        /// </summary>
        [JsonProperty("recall")]
        public string Recall { get; set; }
    }
}
