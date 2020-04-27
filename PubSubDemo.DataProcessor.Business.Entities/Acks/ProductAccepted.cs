using System;

namespace PubSubDemo.DataProcessor.Business.Entities
{
    public class ProductAccepted
    {
        public Guid MessageId { get; set; }

        public bool Accepted { get; set; }

    }
}
