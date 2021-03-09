using System.Net.Http;
using Newtonsoft.Json;
using MicroHeart.AliPay.Response;

namespace MicroHeart.AliPay.Request
{
    /// <summary>
    /// 统一收单交易结算接口
    /// </summary>
    public class AlipayTradeOrderSettleRequest : AlipayRequest<AlipayTradeOrderSettleResponse>
    {
        /// <summary>
        /// 结算请求流水号 开发者自行生成并保证唯一性
        /// </summary>
        [JsonProperty("out_request_no")]
        public string OutRequestNo { get; set; }

        /// <summary>
        /// 支付宝订单号
        /// </summary>
        [JsonProperty("trade_no")]
        public string TradeNo { get; set; }

        /// <summary>
        /// 分账明细信息
        /// </summary>
        [JsonProperty("royalty_parameters")]
        public string RoyaltyParameters { get; set; }

        /// <summary>
        /// 操作员id
        /// </summary>
        [JsonProperty("operator_id")]
        public string OperatorId { get; set; }

        public override string GetApiName()
        {
            return "alipay.trade.order.settle";
        }
    }
}
