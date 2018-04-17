﻿using Newtonsoft.Json;

namespace Pay.WeChatPay.Response
{
    public class WeChatPayQueryBankResponse : WeChatPayResponse
    {
        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        [JsonProperty("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        [JsonProperty("payment_no")]
        public string PaymentNo { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [JsonProperty("bank_no_md5")]
        public string BankNoMd5 { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [JsonProperty("true_name_md5")]
        public string TrueNameMd5 { get; set; }

        /// <summary>
        /// 代付金额
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 代付单状态
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        [JsonProperty("cmms_amt")]
        public string CmmsAmt { get; set; }

        /// <summary>
        /// 商户下单时间
        /// </summary>
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// 成功付款时间
        /// </summary>
        [JsonProperty("pay_succ_time")]
        public string PaySuccTime { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
