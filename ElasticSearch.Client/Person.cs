namespace ElasticSearch.Client
{
    public class Person
    {
        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Address Address { get; set; }
    }
}