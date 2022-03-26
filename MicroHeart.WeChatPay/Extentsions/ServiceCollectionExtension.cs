using MicroHeart.Client;
using Microsoft.Extensions.DependencyInjection;
using Pay.WeChatPay;
using Pay.WeChatPay.Options;
using System;

namespace MicroHeart.WeChatPay.Extentsions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddWeChatPayService(this IServiceCollection services, Action<WeChatPayOptions> configAction)
             => AddWeChatPayService(services, (serviceProvider, options) => configAction.Invoke(options));


        public static IServiceCollection AddWeChatPayService(this IServiceCollection services, Action<IServiceProvider, WeChatPayOptions> configAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (configAction == null)
                throw new ArgumentNullException(nameof(configAction));

            services.AddOptions<WeChatPayOptions>()
                    .Configure<IServiceProvider>((options, sp) => configAction(sp, options));
            services.AddHttpClient();
            services.AddScoped<IBaseClient,WeChatPayClient>();
            return services;
        }
    }
}
