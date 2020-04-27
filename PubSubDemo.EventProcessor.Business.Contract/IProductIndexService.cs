using PubSubDemo.DataProcessor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PubSubDemo.EventProcessor.Business.Contract
{
    public interface IProductIndexService
    {
        Task IndexProduct(List<Product> products);
    }
}
