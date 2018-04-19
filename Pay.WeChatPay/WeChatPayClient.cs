using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pay.Common.Util;
using Pay.Infrastructure;
using Pay.WeChatPay.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pay.WeChatPay
{
    public class WeChatPayClient : BaseApiClient
    {
        protected static HttpClient httpCertificateClient;

        private WeChatPayOptions Options { get; set; }

        protected internal HttpClientEx CertificateClient { get; set; }

        public override string Name => "wx";

        public WeChatPayClient(IOptions<WeChatPayOptions> optionsAccessor)
        {
            Options = optionsAccessor?.Value ?? new WeChatPayOptions();

            httpClient = httpClient ?? new HttpClient();

            if (httpCertificateClient == null)
            {
                var clientHandler = new HttpClientHandler();
                var certificate = Convert.FromBase64String(Options.Certificate);
                clientHandler.ClientCertificates.Add(new X509Certificate2(certificate, Options.MchId, X509KeyStorageFlags.MachineKeySet));
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
                dic.Add("appid", Options.AppId);
            }
            if (!dic.ContainsKey("mch_id"))
            {
                dic.Add("mch_id", Options.MchId);
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
                    dic.Add("appid", Options.AppId);
                }
                if (!dic.ContainsKey("mch_id"))
                {
                    dic.Add("mch_id", Options.MchId);
                }
                if (!dic.ContainsKey("nonce_str"))
                {
                    dic.Add("nonce_str", RandomString);
                }
                if (!dic.ContainsKey("sign_type"))
                {
                    dic.Add("sign_type", "MD5");
                }

                var str = dic.CleanupDictionary().ToSortQueryParameters() + "&key=" + Options.Key;

                return Tools.GetMD5(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string MediaType => "application/xml";

        public override async Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request)
        {
            TResponse result;
            try
            {
                var requestUri = GetRequestUri(request);

                var requestMessage = new HttpRequestMessage(request.GetHttpMethod(), requestUri)
                {
                    Content = GetRequestContent(request)
                };

                HttpResponseMessage responseMessage;
                string responseContent;
                if (request.NeedCertificate)
                {
                    responseMessage = await httpCertificateClient.SendAsync(requestMessage).ConfigureAwait(false);
                }
                else
                {
                    responseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                }
                responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                result = Tools.DeserializeToObject<TResponse>(responseContent);

                //result = JsonConvert.DeserializeObject<TResponse>(responseContent);
                DownloadFile(result as IFileDownloadResponse);
                result.RequestUri = requestUri;
                result.RequestBody = GetRequestBody(request);
                result.StatusCode = responseMessage.StatusCode;
                result.Headers = responseMessage.Headers;
                result.ResponseBody = responseContent;
                return result;
            }
            catch (Exception ex)
            {
                result = new TResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ResponseBody = ex.Message
                };
                return result;
            }
        }
    }
}
