using Pay.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.WeChatPay.Request
{
    public class WeChatPayGetPublicKeyRequest : WeChatPayRequest<WeChatPayGetPublicKeyResponse>
    {
        public override bool NeedCertificate => true;

        public override string GetApiName()
        {
            return "https://fraud.mch.weixin.qq.com/risk/getpublickey";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

    }
}
