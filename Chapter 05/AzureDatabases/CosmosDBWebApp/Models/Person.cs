using Newtonsoft.Json;

namespace CosmosDBWebApp.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
