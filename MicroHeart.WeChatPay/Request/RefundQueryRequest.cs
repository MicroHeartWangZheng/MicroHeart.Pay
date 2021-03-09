using Newtonsoft.Json;
using MicroHeart.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.WeChatPay.Request
{
    public class RefundQueryRequest : WeChatPayRequest<RefundQueryResponse>
    {
        #region 属性
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

        /// <summary>
        /// 商户退款单号
        /// </summary>
        [JsonProperty("out_refund_no")]
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [JsonProperty("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 偏移量
        /// </summary>
        [JsonProperty("offset")]
        public string Offset { get; set; } 
        #endregion

        public override bool NeedCertificate => false;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/pay/refundquery";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }


    }
}
