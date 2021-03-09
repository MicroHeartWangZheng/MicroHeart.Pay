namespace Pay.WeChatPay
{
    public class WeChatPayOptions
    {
        /// <summary>
        /// 应用账号(公众账号ID/小程序ID/企业号CorpId)
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// API秘钥
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// API证书
        /// </summary>
        public string Certificate { get; set; }
    }
}
