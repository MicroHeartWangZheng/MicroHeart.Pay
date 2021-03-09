using Newtonsoft.Json;

namespace MicroHeart.WeChatPay.Response
{
    public class PayBankResponse : WeChatPayResponse
    {
        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        [JsonProperty("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 代付金额
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        [JsonProperty("payment_no")]
        public string PaymentNo { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        [JsonProperty("cmms_amt")]
        public string CmmsAmt { get; set; }
    }
}
