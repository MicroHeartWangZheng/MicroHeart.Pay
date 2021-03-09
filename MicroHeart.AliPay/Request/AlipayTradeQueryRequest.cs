using Newtonsoft.Json;
using MicroHeart.AliPay.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MicroHeart.AliPay.Request
{
    public class AlipayTradeQueryRequest : AlipayRequest<AlipayTradeQueryResponse>
    {
        /// <summary>
        /// 订单支付时传入的商户订单号,和支付宝交易号不能同时为空。  trade_no,out_trade_no如果同时存在优先取trade_no
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        [JsonProperty("trade_no")]
        public string TradeNo { get; set; }

        public override string GetApiName()
        {
            return "alipay.trade.query";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
