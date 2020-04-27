using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PubSubDemo.DataProcessor.Business.Service;
using PubSubDemo.Utils;
using RabbitMQ.Client;
using Serilog;
using System;

namespace PubSubDemo.DataProcessor.Bootstrapper
{
    public static class LogExtension
    {
        public static IServiceCollection RegisterLogging(this IServiceCollection services, HostBuilderContext context)
        {
            var section = context.Configuration.GetSection("Serilog");

            try
            {
                Log.Logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(section)
                   .CreateLogger();

                services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

                Log.Information("Data processor started.");
            }
            catch (Exception ex)
            {

            }

            return services;
        }
    }
}
