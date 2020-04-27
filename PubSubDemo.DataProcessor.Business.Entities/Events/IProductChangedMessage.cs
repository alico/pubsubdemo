using PubSubDemo.ProductAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubSubDemo.DataProcessor.Business.Entities
{
    public interface IProductChangedMessage
    {
        Guid MessageId { get; set; }
        ProductDTO Product { get; set; }
        DateTime CreationDate { get; set; }

    }
}
