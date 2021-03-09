using Newtonsoft.Json;

namespace MicroHeart.WeChatPay.Models
{
    /// <summary>
    /// 微信通知服务器的加密信息
    /// </summary>
    public class EncryptedInformation
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

        /// <summary>
        /// 微信退款单号
        /// </summary>
        [JsonProperty("refund_id")]
        public string RefundId { get; set; }

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
        /// 应结订单金额
        /// </summary>
        [JsonProperty("settlement_total_fee")]
        public int SettlementTotalFee { get; set; }

        /// <summary>
        /// 申请退款金额
        /// </summary>
        [JsonProperty("refund_fee")]
        public int RefundFee { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        [JsonProperty("settlement_refund_fee")]
        public int SettlementRefundFee { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        [JsonProperty("refund_status")]
        public string RefundStatus { get; set; }

        /// <summary>
        /// 退款成功时间
        /// </summary>
        [JsonProperty("success_time")]
        public string SuccessTime { get; set; }

        /// <summary>
        /// 退款入账账户
        /// </summary>
        [JsonProperty("refund_recv_accout")]
        public string RefundRecvAccout { get; set; }

        /// <summary>
        /// 退款资金来源
        /// </summary>
        [JsonProperty("refund_account")]
        public string RefundAccount { get; set; }

        /// <summary>
        /// 退款发起来源
        /// </summary>
        [JsonProperty("refund_request_source")]
        public string RefundRequestSource { get; set; }
    }
}
