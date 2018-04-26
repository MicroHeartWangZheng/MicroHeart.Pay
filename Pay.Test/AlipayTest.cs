using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pay.Alipay;
using Pay.Alipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay.Test
{
    [TestClass]
    public class AlipayTest
    {
        AlipayClient alipayClient = new AlipayClient();

        //支付
        [TestMethod]
        public async Task PayTest()
        {
            var guid = Guid.NewGuid().ToString("N");

            var a = await alipayClient.ExecuteAsync(new AlipayTradePayRequest()
            {
                AuthCode = "284340783975593459",
                OutTradeNo = guid,
                Scene = "bar_code",
                Subject = "biaoti",
                TotalAmount = 0.01m
            });

        }
    }
}
