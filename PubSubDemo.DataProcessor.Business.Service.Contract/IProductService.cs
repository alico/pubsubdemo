using PubSubDemo.DataProcessor.Business.Entities;
using PubSubDemo.DataProcessor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PubSubDemo.DataProcessor.Business.Service.Contract
{
    public interface IProductService
    {
        Task<Product> Save(IProductChangedMessage product);

        Task Publish(Product product);
    }
}
