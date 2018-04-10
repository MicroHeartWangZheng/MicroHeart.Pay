using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Infrastructure
{
    public interface IRequest
    {
        /// <summary>
        /// 获取API名称。
        /// </summary>
        string GetApiName();
        /// <summary>
        /// 获取所有的Key-Value形式的文本请求参数字典。
        /// </summary>
        IDictionary<string, object> GetParameters();
        /// <summary>
        /// 客户端参数检查，减少服务端无效调用。
        /// </summary>
        void Validate();
        /// <summary>
        /// 获取请求提交的方法
        /// </summary>
        /// <returns></returns>
        System.Net.Http.HttpMethod GetMethod();
    }

    public interface IRequest<out TResponse> : IRequest where TResponse : BaseResponse, new()
    {

    }
}
