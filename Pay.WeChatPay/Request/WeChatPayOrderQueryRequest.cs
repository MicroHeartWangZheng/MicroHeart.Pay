using Newtonsoft.Json;
using Pay.WeChatPay.Response;
using System.Net.Http;

namespace Pay.WeChatPay.Request
{
    public class WeChatPayOrderQueryRequest : WeChatPayRequest<WeChatPayOrderQueryResponse>
    {
        /// <summary>
        /// 微信订单号
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        public override bool NeedCertificate => false;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/pay/orderquery";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
