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
                OutTradeNo = guid,
                Scene = "bar_code",
                AuthCode = "283143982778473779",
                Subject = "biaoti",
                TotalAmount = 0.01m
            });

        }
    }
}
