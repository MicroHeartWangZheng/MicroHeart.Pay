using System;
using Alipay.Models;
using System.Collections.Generic;
using Pay.Alipay.Response;

namespace Pay.Alipay.Request
{
    /// <summary>
    /// Alipay API: alipay.trade.pay
    /// </summary>
    public class AlipayTradePayRequest : IAlipayRequest<AlipayTradePayResponse>
    {
        public string OutTradeNo { get; set; }

        public string Scene { get; set; }

        public string AuthCode { get; set; }

        public string ProductCode { get; set; }

        public string Subject { get; set; }

        public string BuyerId { get; set; }

        public string SellerId { get; set; }

        public decimal TotalAmount { get; set; }

        public string TransCurrency { get; set; }

        public string SettleCurrency { get; set; }

        public decimal DiscountableAmount { get; set; }

        public string Body { get; set; }

        public List<GoodsDetail> GoodsDetailList { get; set; }

        public string OperatorId { get; set; }

        public string StoreId { get; set; }

        public string TerminalId { get; set; }

        public string TimeoutExpress { get; set; }

        public string AuthConfirmMode { get; set; }

        public string TerminalParams { get; set; }

        public 
    }
}
