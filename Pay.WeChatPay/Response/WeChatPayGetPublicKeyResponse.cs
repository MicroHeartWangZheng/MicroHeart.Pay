using Newtonsoft.Json;

namespace Pay.WeChatPay.Response
{
    public class WeChatPayGetPublicKeyResponse : WeChatPayResponse
    {
        /// <summary>
        /// 密钥	
        /// </summary>
        [JsonProperty("pub_key")]
        public string PubKey { get; set; }
    }
}
