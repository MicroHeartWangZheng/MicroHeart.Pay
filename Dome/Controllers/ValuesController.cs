using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pay.Common.Util;
using Pay.WeChatPay;
using Pay.WeChatPay.Models;

namespace Dome.Controllers
{
    [Route("api/[Controller]")]
    public class ValuesController : Controller
    {
        private WeChatPayOptions weChatPayOptions;

        Dictionary<string, object> resultDictionary;

        private IHostingEnvironment _env;

        public ValuesController(WeChatPayOptions weChatPayOptions)
        {
            this.weChatPayOptions = weChatPayOptions;
            //this._env = env;
        }

        [HttpPost]
        [Route("AcceptNotice")]
        public async Task<string> AcceptNotice()
        {
            //验签
            var body = await new StreamReader(this.HttpContext.Request.Body, Encoding.UTF8).ReadToEndAsync();

            Write(body);

            resultDictionary = new Dictionary<string, object>();

            if (!CheckSign(body))
            {
                resultDictionary.Add("return_code", "FAIL");
                resultDictionary.Add("return_msg", "验签失败");

                Write(resultDictionary.ToXmlString());
                return resultDictionary.ToXmlString();
            }
            var key = Tools.GetMD5(weChatPayOptions.Key).ToLower();

            var weChatPayRefundNotifyResponse = Tools.XmlToObject<WeChatPayRefundNotifyResponse>(body);

            var data = AES.Decrypt(weChatPayRefundNotifyResponse.ReqInfo, key, AESPaddingMode.PKCS7, AESCipherModeMode.ECB);

            Write(data);

            var info = Tools.XmlToObject<EncryptedInformation>(data);

            //处理info

            resultDictionary.Add("return_code", "SUCCESS");
            Write(resultDictionary.ToXmlString());
            return resultDictionary.ToXmlString();
        }

        private bool CheckSign(string responseXml)
        {
            var dic = Tools.XmlToDictionary(responseXml);
            if (dic["return_code"].ToString() != "SUCCESS")
            {
                return false;
            }
            var sign = dic["sign"].ToString();
            var signStr = dic.ToSortQueryParameters(false, "sign") + "&key=" + weChatPayOptions.Key;
            if (Tools.GetMD5(signStr).ToUpper() == sign)
            {
                return true;
            }
            return false;
        }

        private void Write(string data)
        {
            //using (StreamWriter sw = new StreamWriter(_env.WebRootPath + "/log.txt"))
            //{
            //    sw.WriteLine(data);
            //}
        }
    }
}
