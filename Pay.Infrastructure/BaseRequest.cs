using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Pay.Infrastructure
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse> where TResponse : BaseResponse, new()
    {
        private IDictionary<string, object> Parameters = null;
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
            if (Parameters != null)
                return Parameters;
            var properties = this.GetType().GetProperties().Where(m => m != null);

            Parameters = properties.ToDictionary(m => ((JsonPropertyAttribute)m.GetCustomAttributes(typeof(JsonPropertyAttribute),false).First()).PropertyName, n => n.GetValue(this, null));

            return Parameters;
        }
        /// <summary>
        /// 客户端参数检查，减少服务端无效调用
        /// </summary>
        public abstract void Validate();
        /// <summary>
        /// 获取请求提交的方法
        /// </summary>
        /// <returns></returns>
        public abstract System.Net.Http.HttpMethod GetHttpMethod();
    }
}
