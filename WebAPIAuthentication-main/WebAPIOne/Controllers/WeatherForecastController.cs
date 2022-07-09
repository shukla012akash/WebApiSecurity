using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIOne.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Weather> GetWeather()
        {
            List<Weather> weatherList = new List<Weather>();

            weatherList.Add(new Weather { CityName = "Noida", Temperature = Random.Shared.Next(-20, 55) });
            weatherList.Add(new Weather { CityName = "Shimla", Temperature = Random.Shared.Next(-20, 55) });
            weatherList.Add(new Weather { CityName = "Bareilly", Temperature = Random.Shared.Next(-20, 55) });
            weatherList.Add(new Weather { CityName = "Gorakhpur", Temperature = Random.Shared.Next(-20, 55) });
            weatherList.Add(new Weather { CityName = "Dehradun", Temperature = Random.Shared.Next(-20, 55) });

            return weatherList;
        }
        [HttpGet]
        [Authorize(Roles = "Viewer")]
        public ActionResult Hello()
        {
            return Ok("Hi Akash");
        }

        [HttpGet]
        [Authorize(Policy = "AgeOver18")]
        public ActionResult CheckMultipleRoles()
        {
            return Ok("Hi From Custom Policies");
        }

    }
}