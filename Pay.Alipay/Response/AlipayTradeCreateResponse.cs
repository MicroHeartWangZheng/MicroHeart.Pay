﻿using Newtonsoft.Json;

namespace Pay.Alipay.Response
{
    public class AlipayTradeCreateResponse:AlipayResponse
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [JsonProperty("trade_no")]
        public string TradeNo { get; set; }

    }
}
