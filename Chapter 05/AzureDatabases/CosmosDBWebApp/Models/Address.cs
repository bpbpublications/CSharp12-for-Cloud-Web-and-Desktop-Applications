using Newtonsoft.Json;

namespace CosmosDBWebApp.Models
{
    public class Address
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string City { get; set; }
        public string StreetAndNumber { get; set; }
    }
}
