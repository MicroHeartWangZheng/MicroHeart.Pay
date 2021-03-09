using MicroHeart.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.WeChatPay.Request
{
    public class GetTransferInfoRequest : WeChatPayRequest<GetTransferInfoResponse>
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string PartnerTradeNo { get; set; }

        public override bool NeedCertificate => true;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/mmpaymkttransfers/gettransferinfo";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
