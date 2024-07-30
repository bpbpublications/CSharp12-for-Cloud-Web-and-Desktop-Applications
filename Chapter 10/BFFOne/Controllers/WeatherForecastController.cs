using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace BFFOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var result = new List<WeatherForecast>();
            string baseURL = "https://localhost:7173/";
            string url = baseURL + "WeatherForecast?weather=hot";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage responseMessage = await client.GetAsync(url))
                {
                    using (HttpContent content = responseMessage.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<WeatherForecast>>(data);
                    }
                }
            }
            return result;
        }
        [HttpPost]
        public void Post([FromBody] WeatherForecast weatherForecast)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "weatherForecastSampleQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "From BFF One, Date: " + weatherForecast.Date + ", Temperature in Cº: " + weatherForecast.TemperatureC + " and Summary: " + weatherForecast.Summary;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "weatherForecastSampleQueue",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}