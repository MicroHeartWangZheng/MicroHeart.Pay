using System.Net;
using System.Net.Http.Headers;

namespace MicroHeart.Client
{
    public abstract class BaseResponse
    {
        /// <summary>
        /// 设置或获取响应的内容
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string ResponseBody { set; get; }
        /// <summary>
        /// 设置或获取HttpStatusCode
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public HttpStatusCode StatusCode { set; get; }
        /// <summary>
        /// 设置或获取请求地址
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string RequestUri { set; get; }
        /// <summary>
        /// 设置或获取请求内容
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string RequestBody { set; get; }

        /// <summary>
        /// 设置或获取响应头
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public HttpResponseHeaders Headers { set; get; }

        public override string ToString()
        {
            var headers = Headers?.ToString();
            return $"{this.GetType().Name}" +
                   $"{System.Environment.NewLine}" +
                   $"{headers}" +
                   $"{System.Environment.NewLine}" +
                   $"{RequestUri}:{StatusCode}" +
                   $"{System.Environment.NewLine}" +
                   $"Request:{RequestBody}" +
                   $"{System.Environment.NewLine}" +
                   $"Response:{ResponseBody}";
        }
    }
}
