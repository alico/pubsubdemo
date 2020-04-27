using PubSubDemo.ProductAPI.Entities;
using System;


namespace PubSubDemo.DataProcessor.Business.Entities
{
    public class ProductChangedMessage : IProductChangedMessage
    {
        public Guid MessageId { get; set; }
        public ProductDTO Product { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
