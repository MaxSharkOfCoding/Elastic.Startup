using System;

namespace ElasticSearch.Client
{
    public class ClientOptions
    {
        public string DefaultIndex { get; init; }
        public TimeSpan RequestTimeout { get; init; }
    }
}