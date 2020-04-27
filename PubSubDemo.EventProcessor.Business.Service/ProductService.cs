using Microsoft.Extensions.Logging;
using PubSubDemo.EventProcessor.Business.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.EventProcessor.Data.Contract;
using PubSubDemo.EventProcessor.Data.Entity;
using System.Linq;

namespace PubSubDemo.EventProcessor.Business.Service
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

        public async Task Save(List<PubSubDemo.DataProcessor.Data.Entities.Product> products)
        {
            var productEntities = products.Select(x => new Product() {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                CreationDate = x.CreationDate,
                LastModifyDate = x.LastModifyDate
            }).ToList();

            var repository = _serviceProvider.GetService<IProductRepository>();
            await repository.AddRange(productEntities);
        }
    }
}
