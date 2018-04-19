using Pay.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Pay.WeChatPay
{
    public abstract class WeChatPayRequest<TResponse> : BaseRequest<TResponse> where TResponse : BaseResponse, new()
    {
        
    }
}
