using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.ProductAPI.Business;
using RabbitMQ.Client;
using System;

namespace PubSubDemo.ProductAPI.Bootstrapper
{
    public static class QueueExtension
    {
        public static IServiceCollection RegisterQueueServices(this IServiceCollection services, IConfiguration section)
        {
            var appSettingsSection = section.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<Appsettings>();

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {                
                var host = cfg.Host(appSettings.QueueSettings.HostName, appSettings.QueueSettings.VirtualHost, 
                    h => {
                        h.Username(appSettings.QueueSettings.UserName);
                        h.Password(appSettings.QueueSettings.Password);
                    });

                cfg.ExchangeType = ExchangeType.Direct;
            }));

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());

            return services;
        }
    }
}
