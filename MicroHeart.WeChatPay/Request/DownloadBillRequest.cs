using Newtonsoft.Json;
using MicroHeart.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.WeChatPay.Request
{
    public class DownloadBillRequest : WeChatPayRequest<DownloadBillResponse>
    {
        #region 属性
        /// <summary>
        /// 对账单日期
        /// </summary>
        [JsonProperty("bill_date")]
        public string BillDate { get; set; }

        /// <summary>
        /// 账单类型
        /// </summary>
        [JsonProperty("bill_type")]
        public string BillType { get; set; }

        /// <summary>
        /// 压缩账单
        /// </summary>
        [JsonProperty("tar_type")]
        public string TarType { get; set; }

        #endregion

        public override bool NeedCertificate => false;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/pay/downloadbill";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
