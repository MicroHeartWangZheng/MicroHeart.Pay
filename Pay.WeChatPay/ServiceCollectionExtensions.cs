using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.WeChatPay
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWeChatPay(
            this IServiceCollection services)
        {
            services.AddWeChatPay(setupAction: null);
        }

        public static void AddWeChatPay(
            this IServiceCollection services,
            Action<WeChatPayOptions> setupAction)
        {
            services.AddSingleton<WeChatPayClient>();
            services.AddSingleton<WeChatPayNotifyClient>();
            if (setupAction != null)
            {
                services.Configure(setupAction);
            }
        }
    }
}
