using Newtonsoft.Json;
using Pay.WeChatPay.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Pay.WeChatPay.Request
{
    public class WeChatPayReverseRequest : WeChatPayRequest<WeChatPayReverseResponse>
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        [JsonProperty("transaction_id")]
        public string Transaction_Id { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        public override bool NeedCertificate => true;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/secapi/pay/reverse";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
