using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Pay.Alipay.Response
{
    public class AlipayTradeCloseResponse : AlipayResponse
    {
        /// <summary>
        /// 创建交易传入的商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [XmlElement("trade_no")]
        public string TradeNo { get; set; }
    }
}
