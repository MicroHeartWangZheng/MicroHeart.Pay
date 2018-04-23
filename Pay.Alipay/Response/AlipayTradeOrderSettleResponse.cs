using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Alipay.Response
{
    public class AlipayTradeOrderSettleResponse : AlipayResponse
    {
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [JsonProperty("trade_no")]
        public string TradeNo { get; set; }
    }
}
