using Nest;
using System;

namespace PubSubDemo.Utils
{
    public class ConnectionHelper
    {
        public static ElasticClient _client;

        public static ElasticClient GetClientSingleton(ElasticSearchSettings setting)
        {
            if (_client != null)
                return _client;

            Uri node = new Uri(setting.ServerUrl);
            ConnectionSettings settings = new ConnectionSettings(node)
           .EnableHttpCompression();

            settings.DisableDirectStreaming();
            //settings.DefaultIndex(indexName);
            ElasticClient client = new ElasticClient(settings);

            return client;
        }

        public static ElasticClient GetClient(ConnectionSettings settings)
        {
            return new ElasticClient(settings);
        }
    }
}
