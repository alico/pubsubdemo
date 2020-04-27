using PubSubDemo.Utils;
using System;

namespace PubSubDemo.ProductAPI.Business
{
    public class Appsettings
    {
        public QueueSettings QueueSettings { get; set; }

        public Appsettings()
        {

        }

        public Appsettings( QueueSettings queueSettings)
        {
            QueueSettings = queueSettings;
        }
    }
}
