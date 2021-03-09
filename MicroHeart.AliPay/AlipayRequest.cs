using MicroHeart.Client;
using System.Net.Http;

namespace MicroHeart.AliPay
{

    public abstract class AlipayRequest<TResponse> : BaseRequest<TResponse>, IRequest<TResponse> where TResponse : AlipayResponse, new()
    {
        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

    }
}
