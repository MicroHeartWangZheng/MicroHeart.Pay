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
            var guid = Guid.NewGuid().ToString("N");
            WeChatPayClient weChatPayClient = new WeChatPayClient(new myWeChatPayOptions());
            var a = await weChatPayClient.ExecuteAsync(new WeChatPayMicroPayRequest()
            {
                Body = "商品描述",
                OutTradeNo = guid,
                TotalFee = 1,
                SpbillCreateIp = "127.0.0.1",
                AuthCode = "134914855872912166"
            });




        }


        public void QueryTest()

    }

    public class myWeChatPayOptions : IOptions<WeChatPayOptions>
    {
        public WeChatPayOptions Value
        {
            get
            {
                return new WeChatPayOptions()
                {
                   
                };
            }
        }
    }
}
