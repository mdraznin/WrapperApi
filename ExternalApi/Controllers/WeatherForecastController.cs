using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExternalApi.Controllers
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
        public IEnumerable<WeatherForecast> Get()
        {
            //Make a call to the external API
            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:7130/myobjects").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var weatherForecast = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(content);
            return weatherForecast;

        }
    }
}