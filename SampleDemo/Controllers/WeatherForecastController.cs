using Microsoft.AspNetCore.Mvc;
using SampleDemo.Yzh.Net.Repository;
using SampleDemo.Yzh.Net.Service;

namespace SampleDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly TestContext _bloggingContext;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IValuesService _valuesService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TestContext bloggingContext, IValuesService valuesService)
        {
            _logger = logger;
            _bloggingContext = bloggingContext;
            _valuesService = valuesService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            await _valuesService.UpdateSM();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
