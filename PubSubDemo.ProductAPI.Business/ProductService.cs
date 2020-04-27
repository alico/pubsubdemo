using System;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit.Logging;
using PubSubDemo.ProductAPI.Entities;
using PubSubDemo.ProductAPI.Business.Contract;
using PubSubDemo.DataProcessor.Business.Entities;

namespace PubSubDemo.ProductAPI.Business
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IPublishEndpoint _endpoint;
        private readonly Appsettings _appsettings;


        public ProductService(ILogger<ProductService> logger, IPublishEndpoint endpoint, Appsettings appsettings)
        {
            _logger = logger;
            _endpoint = endpoint;
            _appsettings = appsettings;
        }

        public async Task Put(ProductDTO request, CancellationToken cancellationToken)
        {
            try
            {
                await _endpoint.Publish<IProductChangedMessage>(new ProductChangedMessage()
                {
                    MessageId = new Guid(),
                    Product = request,
                    CreationDate = DateTime.Now

                }, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
