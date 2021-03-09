using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroHeart.AliPay.Response
{
    /// <summary>
    /// 统一收单交易撤销接口
    /// </summary>
    public class AlipayTradeCancelResponse : AlipayResponse
    {
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [JsonProperty("trade_no")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 是否需要重试
        /// </summary>
        [JsonProperty("retry_flag")]
        public string RetryFlag { get; set; }

        /// <summary>
        /// 本次撤销触发的交易动作 close：关闭交易，无退款 refund：产生了退款
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
