using MicroHeart.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.WeChatPay.Request
{
    public class GetPublicKeyRequest : WeChatPayRequest<GetPublicKeyResponse>
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
