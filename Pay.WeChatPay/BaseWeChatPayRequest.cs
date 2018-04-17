using Pay.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.WeChatPay
{
    public abstract class BaseWeChatPayRequest<TResponse> : BaseRequest<TResponse> where TResponse : BaseResponse, new()
    {

    }
}
