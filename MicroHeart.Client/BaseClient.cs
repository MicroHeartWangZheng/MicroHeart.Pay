using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroHeart.Client
{
    public abstract class BaseClient : IBaseClient
    {
        public virtual string Name { get; set; }

        public HttpClient httpClient;

        protected BaseClient(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public virtual async Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request) where TResponse : BaseResponse, new()
        {
            TResponse result;
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = request.GetHttpMethod(),
                    RequestUri = new Uri(GetRequestUri(request)),
                    Content = GetRequestContent(request)
                };
                var responseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                var responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<TResponse>(responseContent);
                result.RequestUri = requestMessage.RequestUri.AbsoluteUri;
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

        public virtual TResponse Execute<TResponse>(IRequest<TResponse> request) where TResponse : BaseResponse, new()
        {
            TResponse result = null;
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = request.GetHttpMethod(),
                    RequestUri = new Uri(GetRequestUri(request)),
                    Content = GetRequestContent(request)
                };

                var responseMessage = httpClient.SendAsync(requestMessage).Result;
                var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<TResponse>(responseContent);
                result.RequestUri = requestMessage.RequestUri.AbsoluteUri;
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

        /// <summary>
        /// 获取请求地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public abstract string GetRequestUri(IRequest request);

        /// <summary>
        /// 获取请求发送数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public abstract string GetRequestBody(IRequest request);

        /// <summary>
        /// 获取请求发送的HttpContent.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual HttpContent GetRequestContent(IRequest request)
        {
            return (string.IsNullOrWhiteSpace(MediaType) || request.GetHttpMethod() == HttpMethod.Get)
                ? new StringContent(string.Empty)
                : new StringContent(GetRequestBody(request), Encoding.UTF8, MediaType);
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public abstract string GetSign(IRequest request);

        /// <summary>
        /// 获取数据提交的MediaType
        /// </summary>
        public virtual string MediaType => "";

    }
}
