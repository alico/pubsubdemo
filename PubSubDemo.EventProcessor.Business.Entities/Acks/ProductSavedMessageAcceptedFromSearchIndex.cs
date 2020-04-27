using System;

namespace PubSubDemo.EventProcessor.Business.Entities
{
    public class ProductSavedMessageAcceptedFromSearchIndex
    {
        public Guid MessageId { get; set; }

        public bool Accepted { get; set; }

    }
}
