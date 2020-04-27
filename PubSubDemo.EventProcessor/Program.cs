using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PubSubDemo.EventProcessor.Bootstrapper;
using Serilog;

namespace PubSubDemo.EventProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureLogging(loggingBuilder =>
              {
                     var configuration = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json")
                      .Build();
                  var logger = new LoggerConfiguration()
                      .ReadFrom.Configuration(configuration)
                      .CreateLogger();
                  loggingBuilder.AddSerilog(logger, dispose: true);
              })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<DWHWorker>();
                    services.AddHostedService<ProductIndexWorker>();
                    services.RegisterConfigurationServices(hostContext);
                    services.RegisterQueueServices(hostContext);
                    services.RegisterRepositoryServices();
                    services.RegisterLogging(hostContext);
                });
    }
}
