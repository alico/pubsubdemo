using PubSubDemo.EventProcessor.Data.Contract;
using PubSubDemo.EventProcessor.Data.Entity;
using PubSubDemo.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PubSubDemo.EventProcessor.Data
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public ProductRepository(ConnectionStrings connectionSettings) : base(connectionSettings)
        {

        }

        public async Task<Product> Save(Product product)
        {
            await base.Add(product);
            return product;
        }

        public async Task<List<Product>> Save(List<Product> products)
        {
            await base.AddRange(products);
            return products;
        }
    }
}
