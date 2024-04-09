using Microsoft.AspNetCore.Mvc;
using SampleDemo.Yzh.Net.Service;

namespace SampleDemo.Controllers
{
    // C# 12 加入的 主构造函数，构造函数注入更加简洁，.NET 8 才可用 See: https://learn.microsoft.com/zh-cn/dotnet/csharp/whats-new/tutorials/primary-constructors
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger, IValuesService valuesService) : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            logger.LogInformation("Start Get method 0v0");
            await valuesService.UpdateSM();
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
