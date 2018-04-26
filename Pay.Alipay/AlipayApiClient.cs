using Newtonsoft.Json;
using Pay.Common.Util;
using Pay.Infrastructure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Pay.Alipay
{
    public class AlipayClient : BaseApiClient
    {
        private static AlipayConfig AlipayConfig { get; set; }

        private string TimeStamp;
        public AlipayClient()
        {
            TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            AlipayConfig = AlipayConfig ?? new AlipayConfig()
            {
                ApiUrl = "https://openapi.alipay.com/gateway.do",
                AppId = "2017071807795666",
                Charset = "utf-8",
                PrivateKey = "MIIEowIBAAKCAQEAx4VNQ1JxYdGZy6Ix+1bbX3bTTli90ubBkqCd4W06DcRbl/onKMjUOZsebHrLoRgLcGT6qWRQfIruyLhZU7Km1f6mFiQ07hcHY+QN3IWdNS91AMyMq4pd9dE2EvPmCPSz6Likf5/HAkh8QK8RVrEsnqML1lnaBnusma3csFNvYNzPKbovAdJJWibmTBHy0LRhbEPxLgzV5cmvoqr7ZkWx04iaVFiCgZBtD8DHzLmIOVUBLSXVC2nhQ7696YytLRJv329565Ogw8GiHKDqv8JlINWkZAW3It8cUjQonNf4qHPWNC5wc0+/KhVFYTyCIKSAkFwv64vCBv7uato+xk3VkwIDAQABAoIBAQCjUdyy9PNWzQoFhFlBkhG0jUHe6glIcBeX/N3/vzc8ObV4LA6N9gayuOUoi0PQNCx47k+5BSJVMCzSJQUJ3D1xAifWDAE/u54TCITINJ9A//3Yj5e+e176byzCSt/MCPKT10DgL1vp5IfBMw0QV6tcl76C0b4EfIwGqCj0NPgA4oxWrsvb91OD/v/L185H0Symb9ABbsI7U6dGwjfs9AqW6AzVDieM50mxzFYlcjEIKWLatg7o98ba6mxYduT0EH1IpuYUBYwzdz0gnm0FHhozkP+zuAJSL//PyAWauytMIDq4k33g3oyvshSETXcWUjmEBPQwegQHCu8oOVpzk+8hAoGBAOyQoYlxcaQN12FWqh9niBMBML4qQDrvflR9G8TnXUybcVKl4Kb0W1kinH6Wxl5RlQULYuM0KcqiNftzaFm6yQC8x3641x6zrro5Qq+pwd3EWUywZTxe5mDO4P7IbxNNd7uM6K1B0MHn5aWCAFbVEsNOZc7CWMsiASAWBmu38feZAoGBANfpkPdJOJKdNBmt84CbxMehKK5KE/VOPkmQioORYCzlKN71fYOsq4kkImf0Aie1XWstKYuGEy87dFujpFpEDuJue5agz0VFm+1H/j0N3+32HEt2eFFpA+sIqmE9JuiCII7vKrPzJIrfOFs11nruhxRROwxHZT11SIZ/UKq6YQILAoGAL1Nz7aIzYOWf/AoxeJzmvR6U2MZtGR1GgbKRtp+uq5/BWQ50VhI2oCtrcWvKfZ4GmP7BJsENx0sST56z9peGlM4vfuuNpce+oeTIsYndjfc1AkGbzysRHbbljjMc/ZiW5n93IQo0sEYrTCQo2zY/TbFGbsm0p9bCsN+XIz+meakCgYAW4IibqwZzgnSiw+upFNgkzs6gqPi0ZTX0VXxXtG+cUiuidCB4czM5tLpwiUoxKuZbFM3yGqKtvn71tsETT2LEWzB9JUzQ6i87VQV7Mp0neYxF8qeM+LORk7l51CDrQd5xRqYfqwOUM1KlV28CV4O4g2LeSjJP8L1egt7pOBZPQQKBgDWFSDrjwFiJU38Q6GE2rz/M91oCE1leKbR8iSuSoo4ZLnCvMAnC5bu3/1UJT3LkQZcDnPXfnW1T6HUVf5T34LsYQe0OCCE6SNbyBXeA5hIGFfThh5MIMU2Rlz3gGICLwfsxaJMM7n41a7ABB4C9+j2lSbS/jYoHuanOIdNM3Eq6"
            };
        }

        public override string Name => "zfb";

        public override string GetRequestUri(IRequest request)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("app_id", AlipayConfig.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", AlipayConfig.Charset);
            dic.Add("sign_type", "RSA2");
            dic.Add("sign", GetSign(request));
            dic.Add("timestamp", TimeStamp);
            dic.Add("version", "1.0");

            dic.Add("biz_content", JsonConvert.SerializeObject(request.GetParameters().CleanupDictionary(), Formatting.None));

            return AlipayConfig.ApiUrl + "?" + dic.ToSortQueryParameters(true);
        }

        public override string GetRequestBody(IRequest request)
        {
            return string.Empty;
        }

        public override string GetSign(IRequest request)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("app_id", AlipayConfig.AppId);
            dic.Add("method", request.GetApiName());
            dic.Add("charset", AlipayConfig.Charset);
            dic.Add("sign_type", "RSA2");
            dic.Add("timestamp", TimeStamp);
            dic.Add("version", "1.0");

            dic.Add("biz_content", JsonConvert.SerializeObject(request.GetParameters().CleanupDictionary(), Formatting.None));

            return Signature.RSASign(dic, AlipayConfig.PrivateKey, AlipayConfig.Charset, false, "RSA2");
        }

        public override string MediaType => "application/x-www-form-urlencoded";
    }
}
