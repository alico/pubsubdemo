using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PubSubDemo.DataProcessor.Business.Service;
using PubSubDemo.DataProcessor.Data.Contract;
using PubSubDemo.Utils;


namespace PubSubDemo.DataProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBusControl _busControl;
        private readonly IServiceProvider _serviceProvider;
        private readonly QueueSettings _queueSettings;
        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger, IBusControl busControl, QueueSettings queueSettings)
        {
            _logger = logger;
            _busControl = busControl;
            _serviceProvider = serviceProvider;
            _queueSettings = queueSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var dbContextService = _serviceProvider.GetService<IDataContext>();
                dbContextService.EnsureDbCreated();

                _logger.LogInformation("DataProcessor started!");


                var productChangeHandler = _busControl.ConnectReceiveEndpoint(_queueSettings.QueueName, x =>
                {
                    x.Consumer<ProductChangedConsumer>(_serviceProvider);
                });

                await productChangeHandler.Ready;
            }
            catch (Exception ex)
            {
                _logger.LogError("DataProcessor cannot be started.", ex);
            }
        }
    }
}
