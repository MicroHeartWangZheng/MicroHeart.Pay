using Pay.Alipay.Models;
using Pay.Alipay.Response;
using System.Collections.Generic;
using System.Net.Http;

namespace Pay.Alipay.Request
{
    /// <summary>
    /// 商户通过该接口进行交易的创建下单
    /// </summary>
    public class AlipayTradeCreateRequest : AlipayRequest<AlipayTradeCreateResponse>
    {
        /// <summary>
        /// 商户订单号,64个字符以内、只能包含字母、数字、下划线；需保证在商户端不重复
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 卖家支付宝用户ID。 如果该值为空，则默认为商户签约账号对应的支付宝用户ID
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>
        /// 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000] 如果同时传入了【打折金额】，【不可打折金额】，【订单总金额】三者，则必须满足如下条件：【订单总金额】=【打折金额】+【不可打折金额】
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 可打折金额. 参与优惠计算的金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000] 如果该值未传入，但传入了【订单总金额】，【不可打折金额】则该值默认为【订单总金额】-【不可打折金额】
        /// </summary>
        public decimal DiscountableAmount { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 对交易或商品的描述
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 买家的支付宝唯一用户号（2088开头的16位纯数字）,和buyer_logon_id不能同时为空
        /// </summary>
        public string BuyerId { get; set; }

        /// <summary>
        /// 订单包含的商品列表信息.Json格式. 其它说明详见：“商品明细说明”
        /// </summary>
        public List<GoodsDetail> GetGoodsDetails { get; set; }
       
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
        /// 业务扩展参数
        /// </summary>
        public List<ExtendParams> ExtendParams { get; set; }

        /// <summary>
        /// 该笔订单允许的最晚付款时间，逾期将关闭交易。取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。 该参数数值不接受小数点， 如 1.5h，可转换为 90m。
        /// </summary>
        public string TimeoutExpress { get; set; }

        /// <summary>
        /// 商户传入业务信息，具体值要和支付宝约定，应用于安全，营销等参数直传场景，格式为json格式
        /// </summary>
        public string BusinessParams { get; set; }

        public override string GetApiName()
        {
            return "alipay.trade.create";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
