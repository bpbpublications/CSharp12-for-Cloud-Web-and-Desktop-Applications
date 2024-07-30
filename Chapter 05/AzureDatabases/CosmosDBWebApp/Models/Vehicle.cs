using Newtonsoft.Json;
namespace CosmosDBWebApp.Models
{
    public class Vehicle
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
    }
}
