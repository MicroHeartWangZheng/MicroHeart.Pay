using Pay.Alipay.Models;
using Pay.Alipay.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Pay.Alipay.Request
{
    public class AlipayTradeRefundRequest : AlipayRequest<AlipayTradeRefundResponse>
    {
        #region 请求参数
        /// <summary>
        /// 订单支付时传入的商户订单号,不能和 trade_no同时为空。
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 需要退款的金额，该金额不能大于订单金额,单位为元，支持两位小数
        /// </summary>
        public decimal RefundAmount { get; set; }


        /// <summary>
        /// 订单退款币种信息，非外币交易，不能传入退款币种信息
        /// </summary>
        public string RefundCurrency { get; set; }

        /// <summary>
        /// 退款的原因说明
        /// </summary>
        public string RefundReason { get; set; }

        /// <summary>
        /// 标识一次退款请求，同一笔交易多次退款需要保证唯一，如需部分退款，则此参数必传。
        /// </summary>
        public string OutRequestNo { get; set; }

        /// <summary>
        /// 商户的操作员编号
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 商户的门店编号
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// 商户的终端编号
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// 退款包含的商品列表信息，Json格式。 其它说明详见：“商品明细说明”
        /// </summary>
        public List<GoodsDetail> GoodsDetail { get; set; }


        #endregion

        public override string GetApiName()
        {
            return "alipay.trade.refund";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
