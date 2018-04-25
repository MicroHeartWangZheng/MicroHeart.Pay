using Newtonsoft.Json;
using Pay.Common.Util;
using Pay.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.Alipay
{
    public class AlipayClient : BaseApiClient
    {
        private static AlipayConfig AlipayConfig { get; set; }

        private string TimeStamp;
        public AlipayClient()
        {
            TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            AlipayConfig = AlipayConfig ?? new AlipayConfig()
            {
                ApiUrl = "https://openapi.alipay.com/gateway.do",
                AppId = "2018042460038158",
                Charset = "utf-8",
                PrivateKey = @"C:\Users\Administrator\Desktop\myPrivateKey.pem"
            };
        }

        public override string Name => "zfb";

        public override string GetRequestUri(IRequest request)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("app_id", AlipayConfig.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", AlipayConfig.Charset);
            dic.Add("sign_type", "RSA2");
            dic.Add("sign", GetSign(request));
            dic.Add("timestamp", TimeStamp);
            dic.Add("version", "1.0");
            var a = JsonConvert.SerializeObject(request.GetParameters().CleanupDictionary(), Formatting.None);

            dic.Add("biz_content", a);

            var c = dic.ToSortQueryParameters();
            return AlipayConfig.ApiUrl + "?" + c;
        }

        public override string GetRequestBody(IRequest request)
        {
            return string.Empty;
            //if (request.GetHttpMethod() == HttpMethod.Get)
            //{
            //    return string.Empty;
            //}

        }

        public override string GetSign(IRequest request)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("app_id", AlipayConfig.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", AlipayConfig.Charset);
            dic.Add("sign_type", "RSA2");
            dic.Add("timestamp", TimeStamp);
            dic.Add("version", "1.0");
            var a = JsonConvert.SerializeObject(request.GetParameters().CleanupDictionary(),Formatting.None);

            dic.Add("biz_content", a);

            return Signature.RSASign(dic, AlipayConfig.PrivateKey, AlipayConfig.Charset, "RSA2");
        }

        public override string MediaType => "application/x-www-form-urlencoded";
    }
}
