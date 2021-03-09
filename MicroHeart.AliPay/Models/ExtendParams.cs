using Newtonsoft.Json;

namespace MicroHeart.AliPay.Models
{
    public class ExtendParams
    {
        /// <summary>
        /// 系统商编号 该参数作为系统商返佣数据提取的依据，请填写系统商签约协议的PID
        /// </summary>
        [JsonProperty("sys_service_provider_id")]
        public string SysServiceProviderId { get; set; }

    }
}
