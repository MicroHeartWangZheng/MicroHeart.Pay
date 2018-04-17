using Newtonsoft.Json;

namespace Pay.WeChatPay.Response
{
    public class WeChatPayDownloadFundFlowResponse : WeChatPayResponse
    {
        /// <summary>
        /// 业务结果
        /// </summary>
        [JsonProperty("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [JsonProperty("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误描述	
        /// </summary>
        [JsonProperty("err_code_des")]
        public string ErrCodeDes { get; set; }
    }
}
