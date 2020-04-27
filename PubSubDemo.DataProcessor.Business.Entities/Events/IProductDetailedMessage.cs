using PubSubDemo.DataProcessor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubDemo.DataProcessor.Business.Entities
{
    public interface IProductDetailedMessage
    {
        Guid MessageId { get; set; }
        Product Product { get; set; }

        DateTime CreationDate { get; set; }
    }
}
