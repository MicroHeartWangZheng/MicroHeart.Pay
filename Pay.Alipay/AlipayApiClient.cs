using Pay.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace Pay.Alipay
{
    public class AlipayClient : BaseApiClient
    {
        public AlipayClient()
        {
            this.InterfaceConfiguration = new InterfaceConfiguration()
            {
                ApiUrl = "https://openapi.alipay.com/gateway.do",
                AppId = "xxxx",
                MediaType = "application/json",
                Charset="utf-8"
            };
        }

        public override string Name => "zfb";

        public override string GetRequestUri(IRequest request)
        {
            return this.InterfaceConfiguration.ApiUrl;
        }

        public override string GetRequestBody(IRequest request)
        {
            throw new NotImplementedException();
        }

        public override string GetSign(IRequest request)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("app_id", this.InterfaceConfiguration.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", this.InterfaceConfiguration.Charset);
            dic.Add("sign_type", "RSA2");
        }
    }
}
