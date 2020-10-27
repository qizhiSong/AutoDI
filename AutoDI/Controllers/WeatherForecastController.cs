using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDI.Entity;
using AutoDI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDemoRepository<DemoEntity> repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            , IDemoRepository<DemoEntity> repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var str = this.repository.GetObject(new DemoEntity { Id = 1, Name = "2" });
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
