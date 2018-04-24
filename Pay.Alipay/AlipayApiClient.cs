using Newtonsoft.Json;
using Pay.Common.Util;
using Pay.Infrastructure;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.Alipay
{
    public class AlipayClient : BaseApiClient
    {
        private static AlipayConfig alipayConfig { get; set; }
        public AlipayClient()
        {
            alipayConfig = alipayConfig ?? new AlipayConfig()
            {
                ApiUrl = "https://openapi.alipay.com/gateway.do",
                AppId = "2018042460038158",
                MediaType = "application/json",
                Charset = "utf-8",
                PrivateKeyPath = @"C:\Users\Administrator\Desktop\myPrivateKey.pem"
            };
        }

        public override string Name => "zfb";

        public override string GetRequestUri(IRequest request)
        {
            return alipayConfig.ApiUrl;
        }

        public override string GetRequestBody(IRequest request)
        {
            if (request.GetHttpMethod() == HttpMethod.Get)
            {
                return string.Empty;
            }
            var dic = new Dictionary<string, object>();
            dic.Add("app_id", alipayConfig.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", alipayConfig.Charset);
            dic.Add("sign_type", "RSA2");
            dic.Add("sign", GetSign(request));
            dic.Add("timestamp", RandomString);
            dic.Add("version", "1.0");
            var a = JsonConvert.SerializeObject(request.GetParameters().CleanupDictionary());
            dic.Add("biz_content", JsonConvert.SerializeObject(a));

            return JsonConvert.SerializeObject(dic);
        }

        public override string GetSign(IRequest request)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("app_id", alipayConfig.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", alipayConfig.Charset);
            dic.Add("sign_type", "RSA2");
            dic.Add("timestamp", RandomString);
            dic.Add("version", "1.0");
            var a = JsonConvert.SerializeObject(request.GetParameters().CleanupDictionary());
            dic.Add("biz_content", JsonConvert.SerializeObject(a));

            return Signature.RSASign(dic, alipayConfig.PrivateKeyPath, alipayConfig.Charset, "RSA2");
        }

        //public override string MediaType => "application/json";
    }
}
