using Microsoft.Extensions.Logging;
using Nest;
using PubSubDemo.DataProcessor.Data.Entities;
using PubSubDemo.EventProcessor.Business.Contract;
using PubSubDemo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubSubDemo.EventProcessor.Business.Service
{
    public class ProductIndexService : IProductIndexService
    {
        private readonly IServiceProvider _serviceProvider;
        protected readonly ElasticSearchSettings _configurationSettings;
        private readonly ILogger<ProductIndexService> _logger;

        public ProductIndexService(IServiceProvider serviceProvider, ILogger<ProductIndexService> logger, ElasticSearchSettings configurationSettings)
        {
            _serviceProvider = serviceProvider;
            _configurationSettings = configurationSettings;
            _logger = logger;
        }

        public async Task IndexProduct(List<Product> products)
        {
            if (products != null)
            {
                var _ElasticClient = ConnectionHelper.GetClientSingleton(_configurationSettings);

                List<Product> items = products;

                var descriptor = new BulkDescriptor();

                if (items != null && items.Count > 0)
                    for (int index = 0; index < items.Count; index++)
                    {
                        var indexingItem = items[index];

                        if (indexingItem != null)
                            descriptor.Index<Product>(o => o.Document(indexingItem)
                                .Routing(indexingItem.Id)
                                .Id(indexingItem.Id)
                                .Index(_configurationSettings.AliasName)).Refresh(Elasticsearch.Net.Refresh.True);
                    }

                var response = await _ElasticClient.BulkAsync(descriptor);

                if (!response.IsValid || response.ItemsWithErrors.Any())
                {
                    _logger.LogError(string.Format("Error on IndexItem. isValid : {0} , errorItems : {1} {2}", response.IsValid, response.ItemsWithErrors.Count(), response.ServerError.Error));

                }
            }
        }
    }
}
