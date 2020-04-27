using PubSubDemo.DataProcessor.Data.Contract;
using PubSubDemo.DataProcessor.Data.Entities;
using PubSubDemo.Utils;
using System;
using System.Threading.Tasks;

namespace PubSubDemo.DataProcessor.Data
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
    }
}
