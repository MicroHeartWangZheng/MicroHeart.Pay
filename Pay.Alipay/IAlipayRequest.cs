using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Pay.Alipay
{

    public abstract class IAlipayRequest<T> where T : AlipayResponse
    {
        private IDictionary<string, object> _parameters = null;
        public abstract string GetApiName();

        public abstract HttpMethod GetHttpMethod();

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
    }
}
