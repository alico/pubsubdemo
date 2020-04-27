using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PubSubDemo.Utils;
using System;

namespace PubSubDemo.DataProcessor.Bootstrapper
{
    public static class ConfigurationServiceExtension
    {
        public static IServiceCollection RegisterConfigurationServices(this IServiceCollection service, HostBuilderContext context)
        {
            var connectionStrings = new ConnectionStrings();
            var queueSettings = new QueueSettings();

            context.Configuration.GetSection("ConnectionStrings").Bind(connectionStrings);
            context.Configuration.GetSection("QueueSettings").Bind(queueSettings);

            service.AddSingleton(connectionStrings);
            service.AddSingleton(queueSettings);

            return service;
        }
    }
}
