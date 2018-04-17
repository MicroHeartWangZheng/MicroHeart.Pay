using Newtonsoft.Json;

namespace Pay.WeChatPay.Response
{
    public class WeChatPayRefundResponse : WeChatPayResponse
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
        /// 申请退款金额	
        /// </summary>
        [JsonProperty("refund_fee")]
        public string RefundFee { get; set; }

        /// <summary>
        /// 退款金额	
        /// </summary>
        [JsonProperty("settlement_refund_fee")]
        public string SettlementRefundFee { get; set; }

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
        /// 货币种类
        /// </summary>
        [JsonProperty("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额	
        /// </summary>
        [JsonProperty("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>
        /// 现金退款金额	
        /// </summary>
        [JsonProperty("cash_refund_fee")]
        public int CashRefundFee { get; set; }

        /// <summary>
        /// 代金券退款总金额	
        /// </summary>
        [JsonProperty("coupon_refund_fee")]
        public int RefundCount { get; set; }

        /// <summary>
        /// 退款代金券使用数量	
        /// </summary>
        [JsonProperty("coupon_refund_count")]
        public int CouponRefundCount { get; set; }

        // 代金券类型 coupon_type_$n

        /// <summary>
        /// 代金券类型 0 	
        /// </summary>
        [JsonProperty("coupon_type_0")]
        public int CouponType0 { get; set; }

        // 退款代金券ID coupon_refund_id_$n

        /// <summary>
        /// 退款代金券ID 0
        /// </summary>
        [JsonProperty("coupon_refund_id_0")]
        public int CouponRefund0 { get; set; }

        // 单个代金券退款金额 coupon_refund_fee_$n

        /// <summary>
        /// 单个代金券退款金额 0
        /// </summary>
        [JsonProperty("coupon_refund_fee_0")]
        public int CouponRefundFee0 { get; set; }
    }
}
