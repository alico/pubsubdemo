using PubSubDemo.EventProcessor.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PubSubDemo.EventProcessor.Business.Contract
{
    public interface IProductService
    {
        Task Save(List<PubSubDemo.DataProcessor.Data.Entities.Product> products);
    }
}
