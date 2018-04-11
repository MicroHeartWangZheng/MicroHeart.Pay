using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pay.Infrastructure
{
    public interface IApiClient
    {
        InterfaceConfiguration InterfaceConfiguration { set; get; }

        /// <summary>
        /// 获取第三方接口的名称
        /// </summary>
        string Name { get; }
        

        Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request) where TResponse : BaseResponse, new();

        /// <summary>
        /// 执行请求命令.
        /// </summary>
        /// <typeparam name="TResponse">请求类型对应的 响应类型</typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        TResponse Execute<TResponse>(IRequest<TResponse> request) where TResponse : BaseResponse, new();
    }
}
