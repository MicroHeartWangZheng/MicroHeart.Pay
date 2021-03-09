namespace MicroHeart.AliPay
{
    //阿里配置
    public class AlipayOptions
    {
        /// <summary>
        /// appid
        /// </summary>
        public string AppId { set; get; }
        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { set; get; }
        /// <summary>
        /// 接口
        /// </summary>
        public string ApiUrl { set; get; }

        /// <summary>
        /// 编码格式
        /// </summary>
        public string Charset { get; set; }
    }
}
