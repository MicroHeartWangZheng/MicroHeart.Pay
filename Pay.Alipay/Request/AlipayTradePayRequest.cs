using Pay.Alipay.Models;
using Pay.Alipay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.Alipay.Request
{
    /// <summary>
    /// Alipay API: alipay.trade.pay
    /// </summary>
    public class AlipayTradePayRequest : AlipayRequest<AlipayTradePayResponse>
    {
        #region 参数
        /// <summary>
        /// 商户订单号,64个字符以内、可包含字母、数字、下划线；需保证在商户端不重复 
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付场景 
        /// 条码支付，取值：bar_code
        /// 声波支付，取值：wave_code
        /// </summary>
        public string Scene { get; set; }

        /// <summary>
        /// 支付授权码，25~30开头的长度为16~24位的数字，实际字符串长度以开发者获取的付款码长度为准
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// 销售产品码
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 买家的支付宝用户id，如果为空，会从传入了码值信息中获取买家ID
        /// </summary>
        public string BuyerId { get; set; }

        /// <summary>
        /// 如果该值为空，则默认为商户签约账号对应的支付宝用户ID
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>
        /// 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000] 
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 标价币种, total_amount 对应的币种单位。支持英镑：GBP、港币：HKD、美元：USD、新加坡元：SGD、日元：JPY、加拿大元：CAD、澳元：AUD、欧元：EUR、新西兰元：NZD、韩元：KRW
        /// </summary>
        public string TransCurrency { get; set; }

        /// <summary>
        /// 商户指定的结算币种，支持英镑：GBP、港币：HKD、美元：USD、新加坡元：SGD、日元：JPY、加拿大元：CAD、澳元：AUD、欧元：EUR、新西兰元：NZD、韩元：KRW、泰铢：THB
        /// </summary>
        public string SettleCurrency { get; set; }

        /// <summary>
        /// 参与优惠计算的金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]。 
        /// 如果该值未传入，但传入了【订单总金额】和【不可打折金额】，则该值默认为【订单总金额】-【不可打折金额】
        /// </summary>
        public decimal DiscountableAmount { get; set; }
        /// <summary>
        /// 订单描述
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 订单包含的商品列表信息，json格式，其它说明详见商品明细说明
        /// </summary>
        public List<GoodsDetail> GoodsDetailList { get; set; }

        /// <summary>
        /// 商户操作员编号
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 商户门店编号
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// 商户机具终端编号
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// 该笔订单允许的最晚付款时间，逾期将关闭交易。取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。 该参数数值不接受小数点， 如 1.5h，可转换为 90m
        /// </summary>
        public string TimeoutExpress { get; set; }

        /// <summary>
        /// 预授权确认模式，授权转交易请求中传入，适用于预授权转交易业务使用，目前只支持PRE_AUTH(预授权产品码) 
        /// COMPLETE：转交易支付完成结束预授权，解冻剩余金额; NOT_COMPLETE：转交易支付完成不结束预授权，不解冻剩余金额
        /// </summary>
        public string AuthConfirmMode { get; set; }

        /// <summary>
        /// 商户传入终端设备相关信息，具体值要和支付宝约定
        /// </summary>
        public string TerminalParams { get; set; } 
        #endregion

        public override string GetApiName()
        {
            return "alipay.trade.pay";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
