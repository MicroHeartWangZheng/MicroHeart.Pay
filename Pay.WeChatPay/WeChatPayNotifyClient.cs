using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pay.Common.Util;
using Pay.WeChatPay.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Pay.WeChatPay
{
    public class WeChatPayNotifyClient
    {
        public WeChatPayOptions Options { get; set; }

        public virtual ILogger<WeChatPayNotifyClient> Logger { get; set; }

        public WeChatPayNotifyClient(
            IOptions<WeChatPayOptions> optionsAccessor
            )
        {
            Options = optionsAccessor?.Value;
        }

        public async Task<WeChatPayNotifyResponse> AcceptNotice(HttpRequest request)
        {
            //验签
            var body = await new StreamReader(request.Body, Encoding.UTF8).ReadToEndAsync();

            var response = Tools.XmlToObject<WeChatPayRefundNotifyResponse>(body);

            var key = Tools.GetMD5(Options.Key).ToLower();

            var data = AES.Decrypt(response.ReqInfo, key, AESPaddingMode.PKCS7, AESCipherModeMode.ECB);

            var information = Tools.XmlToObject<EncryptedInformation>(data);


            //业务处理

            return new WeChatPayNotifyResponse()
            {
                ReturnCode = "SUCCESS"
            };
        }

        //private void CheckNotifySign(WeChatPayNotifyResponse response)
        //{
        //    if (response?.Parameters?.Count == 0)
        //    {
        //        throw new Exception("sign check fail: Body is Empty!");
        //    }

        //    if (!response.Parameters.TryGetValue("sign", out var sign))
        //    {
        //        throw new Exception("sign check fail: sign is Empty!");
        //    }

        //    var cal_sign = WeChatPaySignature.SignWithKey(response.Parameters, Options.Key);
        //    if (cal_sign != sign)
        //    {
        //        throw new Exception("sign check fail: check Sign and Data Fail!");
        //    }
        //}
    }
}