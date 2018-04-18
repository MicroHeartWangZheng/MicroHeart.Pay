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
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            WeChatPayClient weChatPayClient = new WeChatPayClient(new myWeChatPayOptions());
            var a = await weChatPayClient.ExecuteAsync(new WeChatPayMicroPayRequest()
            {
                Body = "商品描述",
                OutTradeNo = "1234567",
                TotalFee = 100,
                SpbillCreateIp = "127.0.0.1",
                AuthCode = "授权码"
            });
            var b = a;

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
                    AppId = "1111",
                    Certificate = "2222",
                    Key = "3333",
                    MchId = "4444",
                    RsaPublicKey = "5555"
                };
            }
        }
    }
}
