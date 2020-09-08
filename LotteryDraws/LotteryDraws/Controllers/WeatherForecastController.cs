using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryDraws.Models.Enum;
using LotteryDraws.Models.Request;
using LotteryDraws.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotteryDraws.Controllers
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
        private readonly IDataLottoService _data;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDataLottoService data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();
            var x = await _data.GetOpenLotteriesDrawRequestTask(new GetOpenLotteriesDrawsRequest{CompanyId = LotteriesCompany.Tattersalls, MaxDrawCount = 20});
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
