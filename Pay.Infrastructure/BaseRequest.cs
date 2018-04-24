using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Pay.Infrastructure
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse> where TResponse : BaseResponse, new()
    {
        /// <summary>
        /// 获取API名称
        /// </summary>
        /// <returns></returns>
        public abstract string GetApiName();

        /// <summary>
        /// 获取所有的Key-Value形式的文本请求参数字典。
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>();
           
            var properties = this.GetType().GetProperties().Where(m => m != null);

            parameters = properties.ToDictionary(m => ((JsonPropertyAttribute)m.GetCustomAttributes(typeof(JsonPropertyAttribute), false).First()).PropertyName, n => n.GetValue(this, null));

            return parameters;
        }

        /// <summary>
        /// 获取请求提交的方法
        /// </summary>
        /// <returns></returns>
        public abstract System.Net.Http.HttpMethod GetHttpMethod();

    }
}
