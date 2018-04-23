using Newtonsoft.Json;
using Pay.Infrastructure;
using System;
using System.Xml.Serialization;

namespace Pay.Alipay
{
    public abstract class AlipayResponse : BaseResponse
    {
        /// <summary>
        /// 网关返回码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 网关返回码描述
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 业务返回码，参见具体的API接口文档
        /// </summary>
        [JsonProperty("sub_code")]
        public string Sub_Code { get; set; }

        /// <summary>
        /// 业务返回码描述，参见具体的API接口文档
        /// </summary>
        [JsonProperty("sub_msg")]
        public string Sub_Msg { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [JsonProperty("sign")]
        public string Sign { get; set; }

    }
}
