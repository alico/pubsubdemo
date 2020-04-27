using MassTransit;
using Microsoft.Extensions.Logging;
using PubSubDemo.DataProcessor.Business.Entities;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.DataProcessor.Business.Service.Contract;

namespace PubSubDemo.DataProcessor.Business.Service
{
    public class ProductChangedConsumer : IConsumer<IProductChangedMessage>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ProductChangedConsumer> _logger;
        public ProductChangedConsumer(IServiceProvider serviceProvider, ILogger<ProductChangedConsumer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<IProductChangedMessage> context)
        {
            try
            {
                var productService = _serviceProvider.GetService<IProductService>();
                var product = await productService.Save(context.Message);

                await productService.Publish(product);

                await context.RespondAsync<ProductAccepted>(new
                {
                    Value = $"Received: {context.Message.MessageId}"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductChangedConsumerError", ex);
            }

        }
    }
}
