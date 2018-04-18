using Microsoft.Extensions.Options;
using Pay.Common.Util;
using Pay.Infrastructure;
using Pay.WeChatPay.Utility;
using System;
using System.Collections.Generic;

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
            if (!dic.ContainsKey("appid"))
            {
                dic.Add("appid", Options.AppId);
            }
            if (!dic.ContainsKey("mch_id"))
            {
                dic.Add("mch_id", Options.MchId);
            }
            if (!dic.ContainsKey("nonce_str"))
            {
                dic.Add("nonce_str", RandomString);
            }
            if (!dic.ContainsKey("sign_type"))
            {
                dic.Add("sign_type", "MD5");
            }
            if (!dic.ContainsKey("sign"))
            {
                dic.Add("sign", GetSign(request));
            }
            return dic.CleanupDictionary().ToXmlString();
        }

        public override string GetSign(IRequest request)
        {
            try
            {
                var dic = request.GetParameters();
                if (!dic.ContainsKey("appid"))
                {
                    dic.Add("appid", Options.AppId);
                }
                if (!dic.ContainsKey("mch_id"))
                {
                    dic.Add("mch_id", Options.MchId);
                }
                if (!dic.ContainsKey("nonce_str"))
                {
                    dic.Add("nonce_str", RandomString);
                }
                if (!dic.ContainsKey("sign_type"))
                {
                    dic.Add("sign_type", "MD5");
                }
                
                var str = dic.CleanupDictionary().ToSortQueryParameters() + "&key=" + Options.Key;

                return Tools.GetMD5(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string MediaType => "application/xml";
    }
}
