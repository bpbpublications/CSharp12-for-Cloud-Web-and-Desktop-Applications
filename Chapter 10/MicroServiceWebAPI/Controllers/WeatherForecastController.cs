using Microsoft.AspNetCore.Mvc;

namespace MicroServiceWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] HotSummaries = new[]
        {        "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"    };

        private static readonly string[] ColdSummaries = new[]
        {        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy"    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get([FromQuery] string weather)
        {
            switch (weather.ToLower())
            {
                case "cold":
                    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 15),
                        Summary = ColdSummaries[Random.Shared.Next(ColdSummaries.Length)]
                    }).ToArray();
                case "hot":
                    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(15, 55),
                        Summary = HotSummaries[Random.Shared.Next(HotSummaries.Length)]
                    }).ToArray(); ;
                default:

                    return Enumerable.Empty<WeatherForecast>();
            }

        }
    }
}