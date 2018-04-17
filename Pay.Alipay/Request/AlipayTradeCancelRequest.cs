
using Pay.Alipay.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Pay.Alipay.Request
{
    public class AlipayTradeCancelRequest : IAlipayRequest<AlipayTradeCancelResponse>
    {
        /// <summary>
        /// 原支付请求的商户订单号,和支付宝交易号不能同时为空
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        public string TradeNo { get; set; }

        public override string GetApiName()
        {
            return "alipay.trade.cancel";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
