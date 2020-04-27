using System;

namespace PubSubDemo.Utils
{
    public class ElasticSearchSettings
    {
        public string ServerUrl { get; set; }
        public string ProtectedWordsPath { get; set; }
        public string InitializeIndexNamePrefix { get; set; }
        public string AliasName { get; set; }
        public string UseAlias { get; set; }
        public string DatabaseName { get; set; }
    }
}
