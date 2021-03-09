using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.Client
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
        /// 获取请求提交的方法
        /// </summary>
        /// <returns></returns>
        HttpMethod GetHttpMethod();
    }

    public interface IRequest<TResponse> : IRequest where TResponse : BaseResponse, new()
    {

    }
}
