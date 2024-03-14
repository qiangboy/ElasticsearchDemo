using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace ElasticsearchDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController(ILogger<HotelController> logger, IElasticClient elasticClient, HotelContext dbContext) : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<HotelController> _logger = logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPut]
        public async Task<IActionResult> UpsertAll()
        {
            var hotels = await dbContext.TbHotels.ToListAsync();

            var indexResponse = elasticClient.IndexManyAsync(hotels, "hotel");

            if (!indexResponse.Result.IsValid)
            {
                throw new ApplicationException();
            }

            return Ok();
        }
    }
}
