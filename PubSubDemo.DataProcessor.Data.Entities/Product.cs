using System;

namespace PubSubDemo.DataProcessor.Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public short Quantity { get; set; }
    }
}
