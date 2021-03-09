﻿using Newtonsoft.Json;

namespace MicroHeart.AliPay.Response
{
    public class AlipayTradeCloseResponse : AlipayResponse
    {
        /// <summary>
        /// 创建交易传入的商户订单号
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
