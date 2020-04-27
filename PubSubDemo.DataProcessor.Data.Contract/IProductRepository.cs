using PubSubDemo.DataProcessor.Data.Entities;
using System;
using System.Threading.Tasks;

namespace PubSubDemo.DataProcessor.Data.Contract
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> Save(Product product);
    }
}
