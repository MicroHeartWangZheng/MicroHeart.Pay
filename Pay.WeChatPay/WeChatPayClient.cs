using Microsoft.Extensions.Options;
using Pay.Common.Util;
using Pay.Infrastructure;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Pay.WeChatPay
{
    public class WeChatPayClient : BaseApiClient
    {
        protected static HttpClient httpCertificateClient;

        private WeChatPayOptions weChatPayOptions { get; set; }

        public override string Name => "微信";

        public WeChatPayClient(IOptions<WeChatPayOptions> optionsAccessor)
        {
            weChatPayOptions = optionsAccessor?.Value ?? new WeChatPayOptions();

            httpClient = httpClient ?? new HttpClient();

            if (httpCertificateClient == null)
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.ClientCertificates.Add(new X509Certificate2(weChatPayOptions.CertificatePath, weChatPayOptions.MchId, X509KeyStorageFlags.MachineKeySet));
                httpCertificateClient = new HttpClient(clientHandler);
            }
        }

        public override string GetRequestUri(IRequest request)
        {
            return request.GetApiName();
        }

        public override string GetRequestBody(IRequest request)
        {
            var dic = request.GetParameters();
            if (!dic.ContainsKey("appid"))
            {
                dic.Add("appid", weChatPayOptions.AppId);
            }
            if (!dic.ContainsKey("mch_id"))
            {
                dic.Add("mch_id", weChatPayOptions.MchId);
            }
            if (!dic.ContainsKey("nonce_str"))
            {
                dic.Add("nonce_str", RandomString);
            }
            if (!dic.ContainsKey("sign_type"))
            {
                dic.Add("sign_type", "MD5");
            }
            if (!dic.ContainsKey("sign"))
            {
                dic.Add("sign", GetSign(request));
            }
            return dic.CleanupDictionary().ToXmlString();
        }

        public override string GetSign(IRequest request)
        {
            try
            {
                var dic = request.GetParameters();
                if (!dic.ContainsKey("appid"))
                {
                    dic.Add("appid", weChatPayOptions.AppId);
                }
                if (!dic.ContainsKey("mch_id"))
                {
                    dic.Add("mch_id", weChatPayOptions.MchId);
                }
                if (!dic.ContainsKey("nonce_str"))
                {
                    dic.Add("nonce_str", RandomString);
                }
                if (!dic.ContainsKey("sign_type"))
                {
                    dic.Add("sign_type", "MD5");
                }

                var str = dic.CleanupDictionary().ToSortQueryParameters() + "&key=" + weChatPayOptions.Key;

                return Tools.GetMD5(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string MediaType => "text/xml";

        public async Task<TResponse> Execute<TResponse>(WeChatPayRequest<TResponse> request) where TResponse : WeChatPayResponse, new()
        {
            TResponse response;
            try
            {
                var requestUri = GetRequestUri(request);

                var requestMessage = new HttpRequestMessage(request.GetHttpMethod(), requestUri)
                {
                    Content = GetRequestContent(request)
                };

                HttpResponseMessage responseMessage;
                string responseXml;
                if (request.NeedCertificate)
                {
                    responseMessage = await httpCertificateClient.SendAsync(requestMessage).ConfigureAwait(false);
                }
                else
                {
                    responseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                }
                responseXml = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

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

                DownloadFile(response as IFileDownloadResponse);
                response.RequestUri = requestUri;
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
            {
                return false;
            }
            var sign = dic["sign"].ToString();
            var signStr = dic.ToSortQueryParameters(false, "sign") + "&key=" + weChatPayOptions.Key;
            if (Tools.GetMD5(signStr).ToUpper() == sign)
            {
                return true;
            }
            return false;
        }
    }
}
