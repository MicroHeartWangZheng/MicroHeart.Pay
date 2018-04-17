using Newtonsoft.Json;

namespace Pay.WeChatPay.Response
{
    public class WeChatPayTransfersResponse : WeChatPayResponse
    {
        /// <summary>
        /// 设备号
        /// </summary>
        [JsonProperty("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonProperty("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [JsonProperty("payment_no")]
        public string PaymentNo { get; set; }

        /// <summary>
        /// 微信支付成功时间	
        /// </summary>
        [JsonProperty("payment_time")]
        public string PaymentTime { get; set; }
    }
}
