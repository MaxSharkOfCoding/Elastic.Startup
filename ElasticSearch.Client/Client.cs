using Nest;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ElasticSearch.Client
{
    public class Client
    {
        private const string BankSpecificIndex = "users";
        private const int DefaultRequestTimeoutInMinutes = 2;

        private readonly ElasticClient _client;

        public Client(/*IOptions<ClientOptions> options*/)
        {
            var connectionSettings = new ConnectionSettings(new Uri("http://127.0.0.1:9200/"))
            //.CertificateFingerprint("c2:9d:96:32:ea:6b:9b:ed:f5:cd:93:4b:09:a3:4c:71:0c:4c:2f:4d:f8:61:4d:98:11:6b:2a:b7:6a:a6:b2:32")

                .DefaultMappingFor<Person>(mappingDescriptor => mappingDescriptor
                    .IndexName(/*options.Value.*/BankSpecificIndex)
                    .IdProperty(_ => _.Id))
                .EnableDebugMode()
                .PrettyJson()
                .EnableApiVersioningHeader()
                .RequestTimeout(TimeSpan.FromMinutes(DefaultRequestTimeoutInMinutes))
                /*.BasicAuthentication("elastic", "QpzL0Ep3qJ52bhA1nGK9")*/;
            _client = new ElasticClient(connectionSettings);
        }

        public async Task CreatAsync(Person person, CancellationToken cancellationToken)
        {
            var res = await _client.IndexDocumentAsync(person, cancellationToken);

        }

        public async Task<Person> GetAsync(string id, CancellationToken cancellationToken)
        {
            GetResponse<Person> result = await _client.GetAsync<Person>(id, ct: cancellationToken);

            Person source = result.Source;
            return source;
        }
    }
}