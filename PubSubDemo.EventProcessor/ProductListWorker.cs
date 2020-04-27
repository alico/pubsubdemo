using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PubSubDemo.EventProcessor.Business.Service;

namespace PubSubDemo.EventProcessor
{
    public class ProductListWorker : BackgroundService
    {
        private readonly ILogger<ProductListWorker> _logger;
        private readonly IBusControl _busControl;
        private readonly IServiceProvider _serviceProvider;

        public ProductListWorker(IServiceProvider serviceProvider, IBusControl busControl, ILogger<ProductListWorker> logger)
        {
            _logger = logger;
            _busControl = busControl;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var hostReceiveEndpointHandler = _busControl.ConnectReceiveEndpoint("ProductListQueue", x =>
                {
                    x.Consumer<ProductListConsumer>(_serviceProvider);
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
