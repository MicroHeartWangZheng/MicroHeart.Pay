﻿using Newtonsoft.Json;
using Pay.Alipay.Models;
using Pay.Alipay.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Pay.Alipay.Request
{
    /// <summary>
    /// 收银员通过收银台或商户后台调用支付宝接口，生成二维码后，展示给用户，由用户扫描二维码完成订单支付。
    /// </summary>
    public class AlipayTradePrecreateRequest : AlipayRequest<AlipayTradePrecreateResponse>
    {
        /// <summary>
        /// 商户订单号,64个字符以内、只能包含字母、数字、下划线；需保证在商户端不重复
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 卖家支付宝用户ID。 如果该值为空，则默认为商户签约账号对应的支付宝用户ID
        /// </summary>
        [JsonProperty("seller_id")]
        public string SellerId { get; set; }

        /// <summary>
        /// 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000] 如果同时传入了【打折金额】，【不可打折金额】，【订单总金额】三者，则必须满足如下条件：【订单总金额】=【打折金额】+【不可打折金额】
        /// </summary>
        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 可打折金额. 参与优惠计算的金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000] 如果该值未传入，但传入了【订单总金额】，【不可打折金额】则该值默认为【订单总金额】-【不可打折金额】
        /// </summary>
        [JsonProperty("discountable_amount")]
        public decimal DiscountableAmount { get; set; }

        /// <summary>
        /// 订单标题
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// 订单包含的商品列表信息.Json格式. 其它说明详见：“商品明细说明”
        /// </summary>
        [JsonProperty("goods_detail")]
        public List<GoodsDetail> GoodsDetail { get; set; }

        /// <summary>
        /// 对交易或商品的描述
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// 商户操作员编号
        /// </summary>
        [JsonProperty("operator_id")]
        public string OperatorId { get; set; }

        /// <summary>
        /// 商户门店编号
        /// </summary>
        [JsonProperty("store_id")]
        public string StoreId { get; set; }

        /// <summary>
        /// 禁用渠道，用户不可用指定渠道支付 当有多个渠道时用“,”分隔注，与enable_pay_channels互斥
        /// </summary>
        [JsonProperty("disable_pay_channels")]
        public string DisablePayChannels { get; set; }

        /// <summary>
        /// 可用渠道，用户只能在指定渠道范围内支付 当有多个渠道时用“,”分隔注，与disable_pay_channels互斥
        /// </summary>
        [JsonProperty("enable_pay_channels")]
        public string EnablePayChannels { get; set; }

        /// <summary>
        /// 商户机具终端编号
        /// </summary>
        [JsonProperty("terminal_id")]
        public string TerminalId { get; set; }

        /// <summary>
        /// 业务扩展参数
        /// </summary>
        [JsonProperty("terminal_params")]
        public List<ExtendParams> ExtendParams { get; set; }

        /// <summary>
        /// 该笔订单允许的最晚付款时间，逾期将关闭交易。取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。 该参数数值不接受小数点， 如 1.5h，可转换为 90m。
        /// </summary>
        [JsonProperty("timeout_express")]
        public string TimeoutExpress { get; set; }

        /// <summary>
        /// 商户传入业务信息，具体值要和支付宝约定，应用于安全，营销等参数直传场景，格式为json格式
        /// </summary>
        [JsonProperty("business_params")]
        public string BusinessParams { get; set; }

        public override string GetApiName()
        {
            return "alipay.trade.precreate";
        }

        public override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
