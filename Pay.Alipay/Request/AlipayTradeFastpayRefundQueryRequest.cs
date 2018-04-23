using Newtonsoft.Json;
using Pay.Alipay;
using Pay.Alipay.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Aop.Api.Request
{
    /// <summary>
    /// 交易退款查询
    /// </summary>
    public class AlipayTradeFastpayRefundQueryRequest : IAlipayRequest<AlipayTradeFastpayRefundQueryResponse>
    {
        /// <summary>
        /// 支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        [JsonProperty("trade_no")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 订单支付时传入的商户订单号,和支付宝交易号不能同时为空。 trade_no,out_trade_no如果同时存在优先取trade_no
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 请求退款接口时，传入的退款请求号，如果在退款请求时未传入，则该值为创建交易时的外部交易号
        /// </summary>
        [JsonProperty("out_request_no")]
        public string OutRequestNo { get; set; }

        public override string GetApiName()
        {
            return "alipay.trade.fastpay.refund.query";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
