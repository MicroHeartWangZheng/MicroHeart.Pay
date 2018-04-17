﻿using Pay.Alipay.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Pay.Alipay.Request
{
    public class AlipayTradeQueryRequest : IAlipayRequest<AlipayTradeQueryResponse>
    {
        /// <summary>
        /// 订单支付时传入的商户订单号,和支付宝交易号不能同时为空。  trade_no,out_trade_no如果同时存在优先取trade_no
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝交易号，和商户订单号不能同时为空
        /// </summary>
        public string TradeNo { get; set; }

        public override string GetApiName()
        {
            return "alipay.trade.query";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}