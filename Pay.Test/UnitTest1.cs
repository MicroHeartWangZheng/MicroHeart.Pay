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
                OutTradeNo = Guid.NewGuid().ToString("N"),
                TotalFee = 1,
                SpbillCreateIp = "127.0.0.1",
                AuthCode = "135063193470436536"
            });
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
                    Certificate = "2222",
                    Key = "A8D81FB5957DFB506D59E6535F493847",
                    MchId = "1487015352",
                    RsaPublicKey = "5555"
                };
            }
        }
    }
}
