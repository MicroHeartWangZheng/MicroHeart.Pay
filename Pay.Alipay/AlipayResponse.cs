using Pay.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Pay.Alipay
{
    public abstract class AlipayResponse:BaseResponse
    {
        public string Code { get; set; }

        public string Msg { get; set; }

        public string Sub_Code { get; set; }
        public string Sub_Msg { get; set; }
        public string Sign { get; set; }

    }
}
