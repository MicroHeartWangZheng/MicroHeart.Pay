using MicroHeart.WeChatPay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroHeart.WeChatPay.Request
{
    public class PayBankRequest : WeChatPayRequest<PayBankResponse>
    {
        #region 属性
        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 收款方银行卡号
        /// </summary>
        public string EncBankNo { get; set; }

        /// <summary>
        /// 收款方用户名
        /// </summary>
        public string EncTrueName { get; set; }

        /// <summary>
        /// 收款方开户行
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 付款说明
        /// </summary>
        public string Desc { get; set; }
        #endregion

        public override bool NeedCertificate => true;

        public override string GetApiName()
        {
            return "https://api.mch.weixin.qq.com/mmpaysptrans/pay_bank";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
