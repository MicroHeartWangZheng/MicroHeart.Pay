using Newtonsoft.Json;

namespace MicroHeart.WeChatPay.Response
{
    public class RefundQueryResponse : WeChatPayResponse
    {
        /// <summary>
        /// 订单总退款次数
        /// </summary>
        [JsonProperty("total_refund_count")]
        public int TotalRefundCount { get; set; }

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
        /// 退款笔数
        /// </summary>
        [JsonProperty("refund_count")]
        public int RefundCount { get; set; }

        // 商户退款单号 out_refund_no_$n

        /// <summary>
        /// 商户退款单号 0
        /// </summary>
        [JsonProperty("out_refund_no_0")]
        public string OutRefundNo0 { get; set; }

        // 微信退款单号 refund_id_$n

        /// <summary>
        /// 微信退款单号 0
        /// </summary>
        [JsonProperty("refund_id_0")]
        public string RefundId0 { get; set; }

        // 退款渠道 refund_channel_$n

        /// <summary>
        /// 退款渠道 0
        /// </summary>
        [JsonProperty("refund_channel_0")]
        public string RefundChannel0 { get; set; }


        // 申请退款金额 refund_fee_$n

        /// <summary>
        /// 申请退款金额 0
        /// </summary>
        [JsonProperty("refund_fee_0")]
        public int RefundFee0 { get; set; }

        // 退款金额 settlement_refund_fee_$n

        /// <summary>
        /// 退款金额 0
        /// </summary>
        [JsonProperty("settlement_refund_fee_0")]
        public int SettlementRefundFee0 { get; set; }

        // 代金券类型 coupon_type_$n_$m

        /// <summary>
        /// 代金券类型 0 0
        /// </summary>
        [JsonProperty("coupon_type_0_0")]
        public string CouponType00 { get; set; }

        // 总代金券退款金额 coupon_refund_fee_$n

        /// <summary>
        /// 总代金券退款金额 0
        /// </summary>
        [JsonProperty("coupon_refund_fee_0")]
        public int CouponRefundFee0 { get; set; }

        // 退款代金券使用数量 coupon_refund_count_$n

        /// <summary>
        /// 退款代金券使用数量 0
        /// </summary>
        [JsonProperty("coupon_refund_count_0")]
        public int CouponRefundCount0 { get; set; }

        // 退款代金券ID coupon_refund_id_$n_$m

        /// <summary>
        /// 退款代金券ID 0 0
        /// </summary>
        [JsonProperty("coupon_refund_id_0_0")]
        public string CouponRefundId00 { get; set; }

        // 单个代金券退款金额 coupon_refund_fee_$n_$m

        /// <summary>
        /// 单个代金券退款金额 0 0
        /// </summary>
        [JsonProperty("coupon_refund_fee_0_0")]
        public int CouponRefundFee00 { get; set; }


        // 退款状态 refund_status_$n

        /// <summary>
        /// 退款状态 0
        /// </summary>
        [JsonProperty("refund_status_0")]
        public string RefundStatus0 { get; set; }

        // 退款资金来源 refund_account_$n

        /// <summary>
        /// 退款资金来源 0
        /// </summary>
        [JsonProperty("refund_account_0")]
        public string RefundAccount0 { get; set; }

        // 退款入账账户 refund_recv_accout_$n

        /// <summary>
        /// 退款入账账户 0
        /// </summary>
        [JsonProperty("refund_recv_accout_0")]
        public string RefundRecvAccout0 { get; set; }

        // 退款成功时间 refund_success_time_$n

        /// <summary>
        /// 退款成功时间 0
        /// </summary>
        [JsonProperty("refund_success_time_0")]
        public string RefundSuccessTime0 { get; set; }
    }
}
