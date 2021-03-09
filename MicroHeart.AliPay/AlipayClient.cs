using MicroHeart.Client;
using MicroHeart.Client.Util;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.AliPay
{
    public class AlipayClient : BaseClient
    {
        private static AlipayOptions alipayOptions { get; set; }

        private string timeStamp;
        public AlipayClient(IOptions<AlipayOptions> optionsAccessor,
            IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            alipayOptions = optionsAccessor?.Value ?? new AlipayOptions();
            httpClient = httpClientFactory.CreateClient();
            timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public override string Name => "支付宝";

        public override string GetRequestUri(IRequest request)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("app_id", alipayOptions.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", alipayOptions.Charset);
            dic.Add("sign_type", "RSA2");
            dic.Add("sign", GetSign(request));
            dic.Add("timestamp", timeStamp);
            dic.Add("version", "1.0");

            dic.Add("biz_content", JsonConvert.SerializeObject(request.GetParameters().CleanupDictionary(), Formatting.None));

            return alipayOptions.ApiUrl + "?" + dic.ToSortQueryParameters(true);
        }

        public override string GetRequestBody(IRequest request)
        {
            return string.Empty;
        }

        public override string GetSign(IRequest request)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("app_id", alipayOptions.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", alipayOptions.Charset);
            dic.Add("sign_type", "RSA2");
            dic.Add("timestamp", timeStamp);
            dic.Add("version", "1.0");

            dic.Add("biz_content", JsonConvert.SerializeObject(request.GetParameters().CleanupDictionary(), Formatting.None));

            return Signature.RSASign(dic, alipayOptions.PrivateKey, alipayOptions.Charset, false, "RSA2");
        }

        public override string MediaType => "application/x-www-form-urlencoded";
    }
}
