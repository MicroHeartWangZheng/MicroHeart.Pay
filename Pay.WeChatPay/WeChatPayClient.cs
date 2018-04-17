using Essensoft.AspNetCore.Payment.Security;
using Pay.WeChatPay.Parser;
using Pay.WeChatPay.Request;
using Pay.WeChatPay.Utility;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Crypto;
using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Pay.Infrastructure;

namespace Pay.WeChatPay
{
    public class WeChatPayClient : BaseApiClient
    {
        private AsymmetricKeyParameter PublicKey;

        public WeChatPayOptions Options { get; set; }

        public override string Name => "wx";

        public WeChatPayClient(IOptions<WeChatPayOptions> optionsAccessor)
        {
            Options = optionsAccessor?.Value ?? new WeChatPayOptions();
           
            if (string.IsNullOrEmpty(Options.AppId))
            {
                throw new ArgumentNullException(nameof(Options.AppId));
            }

            if (string.IsNullOrEmpty(Options.MchId))
            {
                throw new ArgumentNullException(nameof(Options.MchId));
            }

            if (string.IsNullOrEmpty(Options.Key))
            {
                throw new ArgumentNullException(nameof(Options.Key));
            }

            if (!string.IsNullOrEmpty(Options.Certificate))
            {
                var clientHandler = new HttpClientHandler();
                var certificate = Convert.FromBase64String(Options.Certificate);
                clientHandler.ClientCertificates.Add(new X509Certificate2(certificate, Options.MchId, X509KeyStorageFlags.MachineKeySet));
                CertificateClient = new HttpClientEx(clientHandler);
            }

            if (!string.IsNullOrEmpty(Options.RsaPublicKey))
            {
                PublicKey = RSAUtilities.GetPublicKeyParameterFormAsn1PublicKey(Options.RsaPublicKey);
            }
        }

        public override string GetRequestUri(IRequest request)
        {
            return string.Empty;
        }

        public override string GetRequestBody(IRequest request)
        {
            throw new NotImplementedException();
        }

        public override string GetSign(IRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
