using PubSubDemo.ProductAPI.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PubSubDemo.ProductAPI.Business.Contract
{
    public interface IProductService
    {
        Task Put(ProductDTO request, CancellationToken cancellationToken);
    }
}
