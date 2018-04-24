using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pay.WeChatPay;
using Pay.WeChatPay.Request;
using Pay.WeChatPay.Response;

namespace Pay.Test
{
    [TestClass]
    public class WeChatPayTest
    {
        WeChatPayClient weChatPayClient = new WeChatPayClient(new myWeChatPayOptions());

        //支付
        [TestMethod]
        public async Task PayTest()
        {
            var guid = Guid.NewGuid().ToString("N");

            var a = await weChatPayClient.ExecuteAsync(new WeChatPayMicroPayRequest()
            {
                Body = "商品描述",
                OutTradeNo = guid,
                TotalFee = 1,
                SpbillCreateIp = "127.0.0.1",
                AuthCode = "134938243023394152"
            });

        }

        //查询订单
        [TestMethod]
        public async Task QueryTest()
        {
            WeChatPayOrderQueryRequest orderQueryRequest = new WeChatPayOrderQueryRequest()
            {
                OutTradeNo = "93a2b447ea5342f7b75eae58f8d8fa2d"
            };

            var a = await weChatPayClient.ExecuteAsync(orderQueryRequest);
        }

        //撤销订单
        [TestMethod]
        public async Task ReverseTest()
        {
            WeChatPayReverseRequest orderQueryRequest = new WeChatPayReverseRequest()
            {
                OutTradeNo = "93a2b447ea5342f7b75eae58f8d8fa2d"
            };

            var a = await weChatPayClient.ExecuteAsync(orderQueryRequest);
        }

        //申请退款
        [TestMethod]
        public async Task RefundTest()
        {
            var guid = Guid.NewGuid().ToString("N");
            WeChatPayRefundRequest refundRequest = new WeChatPayRefundRequest()
            {
                OutRefundNo = guid,
                OutTradeNo = "266778c7bf2c4d6da223bb1cc4ab6143",
                TotalFee = 1,
                RefundFee = 1

            };

            var a = await weChatPayClient.ExecuteAsync(refundRequest);
        }

        //查询退款
        [TestMethod]
        public async Task RefundQueryTest()
        {
            var guid = Guid.NewGuid().ToString("N");
            WeChatPayRefundQueryRequest refundRequest = new WeChatPayRefundQueryRequest()
            {
                OutTradeNo = "93a2b447ea5342f7b75eae58f8d8fa2d",
            };

            var a = await weChatPayClient.ExecuteAsync(refundRequest);
        }

    }

    public class myWeChatPayOptions : IOptions<WeChatPayOptions>
    {
        public WeChatPayOptions Value
        {
            get
            {
                return new WeChatPayOptions()
                {
                    AppId = "wx5c078b6e0964e202",
                    CertificatePath = @"C:\Users\Administrator\Desktop\微信支付文件\certs\apiclient_cert.p12",
                    Key = "A8D81FB5957DFB506D59E6535F493847",
                    MchId = "1487015352",
                    RsaPublicKey = "5555"
                };
            }
        }
    }
}
