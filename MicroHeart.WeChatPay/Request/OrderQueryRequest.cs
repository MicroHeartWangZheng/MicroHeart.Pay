using Newtonsoft.Json;
using MicroHeart.WeChatPay.Response;
using System.Net.Http;

namespace MicroHeart.WeChatPay.Request
{
    public class OrderQueryRequest : WeChatPayRequest<OrderQueryResponse>
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
