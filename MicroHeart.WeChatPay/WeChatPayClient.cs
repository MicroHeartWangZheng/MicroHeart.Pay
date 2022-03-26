using MicroHeart.Client;
using MicroHeart.Client.Util;
using Microsoft.Extensions.Options;
using Pay.WeChatPay.Options;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pay.WeChatPay
{
    public class WeChatPayClient : BaseClient
    {
        public IHttpClientFactory httpClientFactory;
        public override string Name => "微信";

        private WeChatPayOptions weChatPayOptions { get; set; }

        private string RandomString { get; set; }

        public WeChatPayClient(IOptions<WeChatPayOptions> optionsAccessor,
            IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            weChatPayOptions = optionsAccessor?.Value ?? new WeChatPayOptions();
            httpClient = httpClientFactory.CreateClient();
            RandomString = Guid.NewGuid().ToString("N");
        }

        public override string GetRequestUri(IRequest request)
        {
            return request.GetApiName();
        }

        public override string GetRequestBody(IRequest request)
        {
            var dic = request.GetParameters();
            dic.Add("appid", weChatPayOptions.AppId);
            dic.Add("mch_id", weChatPayOptions.MchId);
            dic.Add("nonce_str", RandomString);
            dic.Add("sign_type", "MD5");
            dic.Add("sign", GetSign(request));
            return dic.CleanupDictionary().ToXmlString();
        }

        public override string GetSign(IRequest request)
        {
            var dic = request.GetParameters();
            dic.Add("appid", weChatPayOptions.AppId);
            dic.Add("mch_id", weChatPayOptions.MchId);
            dic.Add("nonce_str", RandomString);
            dic.Add("sign_type", "MD5");

            var str = dic.CleanupDictionary().ToSortQueryParameters() + "&key=" + weChatPayOptions.Key;

            return str.ToMD5();
        }

        public override async Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request)
        {
            TResponse response;
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = request.GetHttpMethod(),
                    RequestUri = new Uri(GetRequestUri(request)),
                    Content = GetRequestContent(request)
                };

                var responseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                var responseXml = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!CheckSign(responseXml))
                {
                    response = new TResponse
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        ResponseBody = "验签失败"
                    };
                    return response;
                }

                response = Tools.XmlToObject<TResponse>(responseXml);
                response.RequestUri = requestMessage.RequestUri.AbsoluteUri;
                response.RequestBody = GetRequestBody(request);
                response.StatusCode = responseMessage.StatusCode;
                response.Headers = responseMessage.Headers;
                response.ResponseBody = responseXml;
                return response;
            }
            catch (Exception ex)
            {
                response = new TResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ResponseBody = ex.Message
                };
                return response;
            }
        }

        public bool CheckSign(string responseXml)
        {
            var dic = Tools.XmlToDictionary(responseXml);
            if (dic["return_code"].ToString() != "SUCCESS")
                return false;
            var sign = dic["sign"].ToString();
            var signStr = dic.ToSortQueryParameters(false, "sign") + "&key=" + weChatPayOptions.Key;
            if (signStr.ToMD5().ToUpper() == sign)
                return true;
            return false;
        }

        public override string MediaType => "text/xml";
    }
}
