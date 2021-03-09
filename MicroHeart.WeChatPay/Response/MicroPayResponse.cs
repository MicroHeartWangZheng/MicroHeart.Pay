using Newtonsoft.Json;

namespace MicroHeart.WeChatPay.Response
{
    public class MicroPayResponse : WeChatPayResponse
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
        /// 用户子标识	
        /// </summary>
        [JsonProperty("sub_openid")]
        public string SubOpenId { get; set; }

        /// <summary>
        /// 是否关注子公众账号	
        /// </summary>
        [JsonProperty("sub_is_subscribe")]
        public string SubIsSubscribe { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        [JsonProperty("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// 付款银行	
        /// </summary>
        [JsonProperty("bank_type")]
        public string BankType { get; set; }

        /// <summary>
        /// 标价币种	
        /// </summary>
        [JsonProperty("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 标价金额		
        /// </summary>
        [JsonProperty("total_fee")]
        public string TotalFee { get; set; }

        /// <summary>
        /// 现金支付币种	
        /// </summary>
        [JsonProperty("cash_fee_type")]
        public string CashFeeType { get; set; }

        /// <summary>
        /// 现金支付金额	
        /// </summary>
        [JsonProperty("cash_fee")]
        public string CashFee { get; set; }

        /// <summary>
        /// 应结订单金额	
        /// </summary>
        [JsonProperty("settlement_total_fee")]
        public string SettlementTotalFee { get; set; }

        /// <summary>
        /// 代金券金额	
        /// </summary>
        [JsonProperty("coupon_fee")]
        public string CouponFee { get; set; }

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
        /// 商家数据包	
        /// </summary>
        [JsonProperty("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间	
        /// </summary>
        [JsonProperty("time_end")]
        public string TimeEnd { get; set; }
    }
}
