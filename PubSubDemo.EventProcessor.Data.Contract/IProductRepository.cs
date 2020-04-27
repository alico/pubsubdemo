using PubSubDemo.EventProcessor.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PubSubDemo.EventProcessor.Data.Contract
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> Save(Product product);
        Task<List<Product>> Save(List<Product> products);
    }
}
