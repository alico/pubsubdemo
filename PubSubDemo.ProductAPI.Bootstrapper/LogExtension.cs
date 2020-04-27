using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Serilog;
using System.IO;

namespace PubSubDemo.ProductAPI.Bootstrapper
{
    public static class LogExtension
    {
        public static IServiceCollection RegisterLogging(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                                                 .SetBasePath(Directory.GetCurrentDirectory())
                                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                 .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                                                 .Build();

            try
            {
                Log.Logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(configuration)
                   .CreateLogger();

                services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

                Log.Information("WebApi Starting...");
            }
            catch (Exception ex)
            {

            }

            return services;
        }
    }
}
