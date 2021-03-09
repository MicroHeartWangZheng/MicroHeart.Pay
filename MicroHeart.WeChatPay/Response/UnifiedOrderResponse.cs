using Newtonsoft.Json;

namespace MicroHeart.WeChatPay.Response
{
    public class UnifiedOrderResponse : WeChatPayResponse
    {
        /// <summary>
        /// 设备号
        /// </summary>
        [JsonProperty("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        [JsonProperty("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// 预支付交易会话标识	
        /// </summary>
        [JsonProperty("prepay_id")]
        public string PrepayId { get; set; }

        /// <summary>
        /// 二维码链接	
        /// </summary>
        [JsonProperty("code_url")]
        public string CodeUrl { get; set; }
    }
}
