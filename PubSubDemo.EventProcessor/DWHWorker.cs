using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.EventProcessor.Business.Service;
using PubSubDemo.EventProcessor.Data.Contract;

namespace PubSubDemo.EventProcessor
{
    public class DWHWorker : BackgroundService
    {
        private readonly ILogger<DWHWorker> _logger;
        private readonly IBusControl _busControl;
        private readonly IServiceProvider _serviceProvider;

        public DWHWorker(IServiceProvider serviceProvider, ILogger<DWHWorker> logger, IBusControl busControl)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _busControl = busControl;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var dbContextService = _serviceProvider.GetService<IDataContext>();
                dbContextService.EnsureDbCreated();

                _logger.LogInformation("DWHConsumer started");


                var hostReceiveEndpointHandler = _busControl.ConnectReceiveEndpoint("DWHProductQueue", x =>
                {
                    x.Consumer<DWHConsumer>(_serviceProvider);
                });

                await hostReceiveEndpointHandler.Ready;
            }
            catch (Exception ex)
            {
                _logger.LogError("DWHConsumer error", ex);
            }
        }
    }
}
