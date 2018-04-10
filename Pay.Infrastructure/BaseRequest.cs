using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pay.Infrastructure
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse> where TResponse : BaseResponse, new()
    {
        private IDictionary<string, object> _parameters = null;
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
            if (_parameters != null)
                return _parameters;
            var properties = this.GetType().GetProperties().Where(m => m != null);
            _parameters = properties.ToDictionary(m => m.Name, n => n.GetValue(this, null));
            return _parameters;
        }
        /// <summary>
        /// 客户端参数检查，减少服务端无效调用
        /// </summary>
        public abstract void Validate();
        /// <summary>
        /// 获取请求提交的方法
        /// </summary>
        /// <returns></returns>
        public abstract System.Net.Http.HttpMethod GetMethod();
    }
}
