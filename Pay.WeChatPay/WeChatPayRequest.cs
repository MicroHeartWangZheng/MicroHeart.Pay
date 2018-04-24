using Newtonsoft.Json;
using Pay.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Pay.WeChatPay
{
    public abstract class WeChatPayRequest<TResponse> : BaseRequest<TResponse> where TResponse : BaseResponse, new()
    {
        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = null;
            if (parameters != null)
                return parameters;

            //去除微信支付 Request中证书字段
            var properties = this.GetType().GetProperties().Where(m => m != null && m.Name != "NeedCertificate");

            parameters = properties.ToDictionary(m => ((JsonPropertyAttribute)m.GetCustomAttributes(typeof(JsonPropertyAttribute), false).First()).PropertyName, n => n.GetValue(this, null));

            return parameters;
        }

        /// <summary>
        /// 接口是否需要证书
        /// </summary>
        public abstract bool NeedCertificate { get; }
    }
}
