using Newtonsoft.Json;
using MicroHeart.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.WeChatPay.Request
{
    public class CloseOrderRequest : WeChatPayRequest<CloseOrderResponse>
    {
        #region 属性
        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        public override bool NeedCertificate => false; 
        #endregion

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/pay/closeorder";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
