using System;

namespace PubSubDemo.EventProcessor.Business.Entities
{
    public class ProductSavedMessageAcceptedFromDWH
    {
        public Guid MessageId { get; set; }

        public bool Accepted { get; set; }

    }
}
