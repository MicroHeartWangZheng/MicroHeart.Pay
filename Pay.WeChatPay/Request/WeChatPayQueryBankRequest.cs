using Pay.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.WeChatPay.Request
{
    public class WeChatPayQueryBankRequest : WeChatPayRequest<WeChatPayQueryBankResponse>
    {
        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        public string PartnerTradeNo { get; set; }

        public override bool NeedCertificate => true;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/mmpaysptrans/query_bank";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
