using Newtonsoft.Json;

namespace Pay.WeChatPay.Response
{
    public class WeChatPayOrderQueryResponse : WeChatPayResponse
    {
        /// <summary>
        /// 设备号
        /// </summary>
        [JsonProperty("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 用户标识	
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 是否关注公众账号
        /// </summary>
        [JsonProperty("is_subscribe")]
        public string IsSubscribe { get; set; }

        /// <summary>
        /// 交易类型	
        /// </summary>
        [JsonProperty("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// 交易状态
        /// </summary>
        [JsonProperty("trade_state")]
        public string TradeState { get; set; }

        /// <summary>
        /// 付款银行
        /// </summary>
        [JsonProperty("bank_type")]
        public string BankType { get; set; }

        /// <summary>
        /// 标价金额
        /// </summary>
        [JsonProperty("total_fee")]
        public int TotalFee { get; set; }

        /// <summary>
        /// 应结订单金额
        /// </summary>
        [JsonProperty("settlement_total_fee")]
        public int SettlementTotalFee { get; set; }

        /// <summary>
        /// 标价币种
        /// </summary>
        [JsonProperty("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额	
        /// </summary>
        [JsonProperty("cash_fee")]
        public int CashFee { get; set; }

        /// <summary>
        /// 现金支付货币类型
        /// </summary>
        [JsonProperty("cash_fee_type")]
        public string CashFeeType { get; set; }

        /// <summary>
        /// 代金券金额	
        /// </summary>
        [JsonProperty("coupon_type")]
        public int CouponFee { get; set; }

        /// <summary>
        /// 代金券使用数量	
        /// </summary>
        [JsonProperty("coupon_count")]
        public int CouponCount { get; set; }

        // 代金券类型	 coupon_type_$n

        /// <summary>
        /// 代金券类型 0
        /// </summary>
        [JsonProperty("coupon_type_0")]
        public int CouponType0 { get; set; }

        // 代金券ID coupon_id_$n

        /// <summary>
        /// 代金券ID	0
        /// </summary>
        [JsonProperty("coupon_id_0")]
        public int CouponId0 { get; set; }

        /// <summary>
        /// 单个代金券金额 0
        /// </summary>
        [JsonProperty("coupon_fee_0")]
        public int CouponFee0 { get; set; }

        /// <summary>
        /// 微信支付订单号	
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号	
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 附加数据	
        /// </summary>
        [JsonProperty("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间	
        /// </summary>
        [JsonProperty("time_end")]
        public string TimeEnd { get; set; }

        /// <summary>
        /// 交易状态描述
        /// </summary>
        [JsonProperty("trade_state_desc")]
        public string TradeStateDesc { get; set; }
    }
}
