using PubSubDemo.DataProcessor.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PubSubDemo.DataProcessor.Business.Entities.Events
{
    public class ProductDetailedMessage : IProductDetailedMessage
    {
        public Guid MessageId { get; set; }
        public Product Product { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
