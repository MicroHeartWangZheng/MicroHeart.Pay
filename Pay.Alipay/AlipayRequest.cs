using Pay.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Pay.Alipay
{

    public abstract class AlipayRequest<TResponse> : BaseRequest<TResponse> where TResponse : BaseResponse, new()
    {
        public override bool NeedCertificate => false;
    }
}
