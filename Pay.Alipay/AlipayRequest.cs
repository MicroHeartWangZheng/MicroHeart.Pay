using Newtonsoft.Json;
using Pay.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Pay.Alipay
{

    public abstract class AlipayRequest<TResponse> : BaseRequest<TResponse>, IRequest<TResponse> where TResponse : AlipayResponse, new()
    {
        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

    }
}
