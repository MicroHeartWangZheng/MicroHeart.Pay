using Newtonsoft.Json;
using Pay.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.WeChatPay.Request
{
    /// <summary>
    /// 申请退款
    /// </summary>
    public class WeChatPayRefundRequest : WeChatPayRequest<WeChatPayRefundResponse>
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
        /// 订单金额
        /// </summary>
        [JsonProperty("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 申请退款金额
        /// </summary>
        [JsonProperty("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>
        /// 退款货币种类
        /// </summary>
        [JsonProperty("refund_fee_type")]
        public string RefundFeeType { get; set; }

        /// <summary>
        /// 退款原因
        /// </summary>
        [JsonProperty("refund_desc")]
        public string RefundDesc { get; set; }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        [JsonProperty("refund_account")]
        public string RefundAccount { get; set; }

        /// <summary>
        /// 退款结果通知url
        /// </summary>
        [JsonProperty("notify_url")]
        public string NotifyUrl { get; set; }

        #endregion

        public override bool NeedCertificate { get => true; }

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/secapi/pay/refund";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
