using MicroHeart.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.WeChatPay.Request
{
    public class TransfersRequest : WeChatPayRequest<TransfersResponse>
    {
        #region 属性
        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 用户openid
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 校验用户姓名选项
        /// </summary>
        public string CheckName { get; set; }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        public string ReUserName { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 企业付款描述信息
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Ip地址
        /// </summary>
        public string SpbillCreateIp { get; set; }

        #endregion

        public override bool NeedCertificate => true;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
