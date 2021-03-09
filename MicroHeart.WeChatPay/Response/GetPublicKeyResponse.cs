using Newtonsoft.Json;

namespace MicroHeart.WeChatPay.Response
{
    public class GetPublicKeyResponse : WeChatPayResponse
    {
        /// <summary>
        /// 密钥	
        /// </summary>
        [JsonProperty("pub_key")]
        public string PubKey { get; set; }
    }
}
