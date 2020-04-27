using MassTransit;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PubSubDemo.DataProcessor.Business.Entities;
using PubSubDemo.EventProcessor.Business.Entities;
using PubSubDemo.EventProcessor.Business.Contract;
using System.Collections.Generic;
using PubSubDemo.DataProcessor.Data.Entities;

namespace PubSubDemo.EventProcessor.Business.Service
{
    public class ProductIndexConsumer : IConsumer<IProductDetailedMessage>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ProductIndexConsumer> _logger;
        public ProductIndexConsumer(IServiceProvider serviceProvider, ILogger<ProductIndexConsumer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<IProductDetailedMessage> context)
        {
            try
            {
                var indexService = _serviceProvider.GetService<IProductIndexService>();
                await indexService.IndexProduct(new List<Product>() { context.Message.Product });

                await context.RespondAsync<ProductSavedMessageAcceptedFromSearchIndex>(new
                {
                    Value = $"Received: {context.Message.MessageId}"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductListConsumer error", ex);
            }

        }
    }
}
