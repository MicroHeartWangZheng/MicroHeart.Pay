using Pay.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.WeChatPay.Request
{
    public class WeChatPayRefundQueryRequest : IWeChatPayRequest<WeChatPayRefundQueryResponse>
    {
        #region 属性
        /// <summary>
        /// 微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string RefundId { get; set; }

        /// <summary>
        /// 偏移量
        /// </summary>
        public string Offset { get; set; } 
        #endregion

        public override bool NeedCertificate => false;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/pay/refundquery";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }


    }
}
