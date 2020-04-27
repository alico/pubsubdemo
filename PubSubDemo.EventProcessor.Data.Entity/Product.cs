using System;

namespace PubSubDemo.EventProcessor.Data.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public short Quantity { get; set; }
    }
}
