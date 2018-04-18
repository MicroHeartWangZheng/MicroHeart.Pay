using Microsoft.Extensions.Options;
using Pay.Common.Util;
using Pay.Infrastructure;
using Pay.WeChatPay.Utility;

namespace Pay.WeChatPay
{
    public class WeChatPayClient : BaseApiClient
    {
        private WeChatPayOptions Options { get; set; }

        protected internal HttpClientEx CertificateClient { get; set; }

        //private AsymmetricKeyParameter PublicKey;

        public override string Name => "wx";

        public WeChatPayClient(IOptions<WeChatPayOptions> optionsAccessor) : base()
        {
            Options = optionsAccessor?.Value ?? new WeChatPayOptions();

            //if (string.IsNullOrEmpty(Options.AppId))
            //{
            //    throw new ArgumentNullException(nameof(Options.AppId));
            //}

            //if (string.IsNullOrEmpty(Options.MchId))
            //{
            //    throw new ArgumentNullException(nameof(Options.MchId));
            //}

            //if (string.IsNullOrEmpty(Options.Key))
            //{
            //    throw new ArgumentNullException(nameof(Options.Key));
            //}

            //if (!string.IsNullOrEmpty(Options.Certificate))
            //{
            //    var clientHandler = new HttpClientHandler();
            //    var certificate = Convert.FromBase64String(Options.Certificate);
            //    clientHandler.ClientCertificates.Add(new X509Certificate2(certificate, Options.MchId, X509KeyStorageFlags.MachineKeySet));
            //    CertificateClient = new HttpClientEx(clientHandler);
            //}

            //if (!string.IsNullOrEmpty(Options.RsaPublicKey))
            //{
            //    //PublicKey = RSAUtilities.GetPublicKeyParameterFormAsn1PublicKey(Options.RsaPublicKey);
            //}
        }

        public override string GetRequestUri(IRequest request)
        {
            return request.GetApiName();
        }

        public override string GetRequestBody(IRequest request)
        {
            var dic = request.GetParameters();
            dic.Add("appid", Options.AppId);
            dic.Add("mch_id", Options.MchId);
            dic.Add("nonce_str", RandomString);
            dic.Add("sign_type", "MD5");
            dic.Add("sign", GetSign(request));

            return dic.ToXmlString();
        }

        public override string GetSign(IRequest request)
        {
            var dic = request.GetParameters();
            dic.Add("appid", Options.AppId);
            dic.Add("mch_id", Options.MchId);
            dic.Add("nonce_str", RandomString);
            dic.Add("sign_type", "MD5");
            var str = dic.ToSortQueryParameters() + "&key=" + Options.Key;

            return Tools.GetMD5(str);
        }

        public override string MediaType => "application/xml";
    }
}
