using MassTransit;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PubSubDemo.DataProcessor.Business.Entities;
using PubSubDemo.EventProcessor.Business.Entities;
using PubSubDemo.EventProcessor.Business.Contract;
using PubSubDemo.DataProcessor.Data.Entities;
using System.Collections.Generic;

namespace PubSubDemo.EventProcessor.Business.Service
{
    public class DWHConsumer : IConsumer<IProductDetailedMessage>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DWHConsumer> _logger;
        public DWHConsumer(IServiceProvider serviceProvider, ILogger<DWHConsumer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<IProductDetailedMessage> context)
        {
            try
            {
                var productService = _serviceProvider.GetService<IProductService>();
                await productService.Save(new List<Product>() { context.Message.Product });

                await context.RespondAsync<ProductSavedMessageAcceptedFromDWH>(new
                {
                    Value = $"Received: {context.Message.MessageId}"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("DWHConsumer error", ex);
            }

        }
    }
}
