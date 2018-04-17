﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Pay.Alipay.Response
{
    public class AlipayTradePrecreateResponse : AlipayResponse
    {
        /// <summary>
        /// 商户的订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 当前预下单请求生成的二维码码串，可以用二维码生成工具根据该码串值生成对应的二维码
        /// </summary>
        [XmlElement("qr_code")]
        public string QrCode { get; set; }
    }
}