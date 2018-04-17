using Newtonsoft.Json;

namespace Pay.WeChatPay.Response
{
    public class WeChatPayGetTransferInfoResponse : WeChatPayResponse
    {
        /// <summary>
        /// 商户单号
        /// </summary>
        [JsonProperty("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 付款单号
        /// </summary>
        [JsonProperty("detail_id")]
        public string DetailId { get; set; }

        /// <summary>
        /// 转账状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// 用户openid
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        [JsonProperty("transfer_name")]
        public string TransferName { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        [JsonProperty("payment_amount")]
        public int PaymentAmount { get; set; }

        /// <summary>
        /// 转账时间
        /// </summary>
        [JsonProperty("transfer_time")]
        public string TransferTime { get; set; }

        /// <summary>
        /// 付款描述
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; }
    }
}
