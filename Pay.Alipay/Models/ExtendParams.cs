using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Alipay.Models
{
    public class ExtendParams
    {
        /// <summary>
        /// 系统商编号 该参数作为系统商返佣数据提取的依据，请填写系统商签约协议的PID
        /// </summary>
        public string SysServiceProviderId { get; set; }

        /// <summary>
        /// 行业数据回流信息, 详见：地铁支付接口参数补充说明
        /// </summary>
        public string IndustryRefluxInfo { get; set; }

        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }

    }
}
