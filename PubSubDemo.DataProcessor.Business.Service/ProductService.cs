using MassTransit;
using Microsoft.Extensions.Logging;
using PubSubDemo.DataProcessor.Business.Entities;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.DataProcessor.Business.Service.Contract;
using PubSubDemo.DataProcessor.Data.Contract;
using PubSubDemo.DataProcessor.Data.Entities;
using PubSubDemo.DataProcessor.Business.Entities.Events;

namespace PubSubDemo.DataProcessor.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IServiceProvider serviceProvider, ILogger<ProductService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task<Product> Save(IProductChangedMessage product)
        {
            var entity = new Product()
            {
                Name = product.Product.Name,
                Price = product.Product.Price,
                Quantity = product.Product.Quantity,
                LastModifyDate = DateTime.Now,
                CreationDate = DateTime.Now
            };

            var productRepository = _serviceProvider.GetService<IProductRepository>();
            await productRepository.Save(entity);

            return entity;
        }

        public async Task Publish(Product product)
        {
            try
            {
                var publisher = _serviceProvider.GetService<IPublishEndpoint>();

                var productSavedMessage = new ProductDetailedMessage()
                {
                    MessageId = new Guid(),
                    Product = product,
                    CreationDate = DateTime.Now
                };

                await publisher.Publish(productSavedMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductServiceProducerError", ex);
            }
        }
    }
}
