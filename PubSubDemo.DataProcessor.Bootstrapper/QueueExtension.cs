using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PubSubDemo.DataProcessor.Business.Service;
using PubSubDemo.Utils;
using RabbitMQ.Client;
using System;

namespace PubSubDemo.DataProcessor.Bootstrapper
{
    public static class QueueExtension
    {
        public static IServiceCollection RegisterQueueServices(this IServiceCollection services, HostBuilderContext context)
        {
            var queueSettings = new QueueSettings();
            context.Configuration.GetSection("QueueSettings").Bind(queueSettings);
            
            services.AddMassTransit(c =>
            {
                c.AddConsumer<ProductChangedConsumer>();
            });

            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(queueSettings.HostName, queueSettings.VirtualHost, h => {
                    h.Username(queueSettings.UserName);
                    h.Password(queueSettings.Password);
                });
                cfg.SetLoggerFactory(provider.GetService<ILoggerFactory>());

            }));

            return services;
        }
    }
}
