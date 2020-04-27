using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PubSubDemo.Utils;
using System;

namespace PubSubDemo.EventProcessor.Bootstrapper
{
    public static class ConfigurationServiceExtension
    {
        public static IServiceCollection RegisterConfigurationServices(this IServiceCollection service, HostBuilderContext context)
        {
            var connectionStrings = new ConnectionStrings();
            var elasticsearchSettings = new ElasticSearchSettings();
            var queueSettings = new QueueSettings();

            context.Configuration.GetSection("ConnectionStrings").Bind(connectionStrings);
            context.Configuration.GetSection("Elastic").Bind(elasticsearchSettings);
            context.Configuration.GetSection("QueueSettings").Bind(queueSettings);

            service.AddSingleton(elasticsearchSettings);
            service.AddSingleton(queueSettings);
            service.AddSingleton(connectionStrings);

            return service;
        }
    }
}
