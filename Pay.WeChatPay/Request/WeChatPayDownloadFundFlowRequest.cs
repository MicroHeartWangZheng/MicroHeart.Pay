using Newtonsoft.Json;
using Pay.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.WeChatPay.Request
{
    public class WeChatPayDownloadFundFlowRequest : WeChatPayRequest<WeChatPayDownloadFundFlowResponse>
    {
        #region 属性
        // <summary>
        /// 资金账单日期
        /// 下载对账单的日期，格式：20140603
        /// </summary>
        [JsonProperty("bill_date")]
        public string BillDate { get; set; }

        /// <summary>
        /// 资金账户类型
        /// 账单的资金来源账户：
        /// Basic 基本账户
        /// Operation 运营账户
        /// Fees 手续费账户
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        /// <summary>
        /// 压缩账单
        /// 非必传参数，固定值：GZIP，返回格式为.gzip的压缩包账单。不传则默认为数据流形式。
        /// </summary>
        [JsonProperty("tar_type")]
        public string TarType { get; set; } 
        #endregion

        public override bool NeedCertificate => true;


        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/pay/downloadfundflow";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
