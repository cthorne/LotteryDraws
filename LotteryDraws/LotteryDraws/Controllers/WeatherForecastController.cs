using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryDraws.Models.Enum;
using LotteryDraws.Models.Request;
using LotteryDraws.Models.Response;
using LotteryDraws.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotteryDraws.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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
        public async Task<GetOpenLotteriesDrawsResponse> GetAll()
        {
            var x = await _data.GetOpenLotteriesDrawRequestTask(new GetOpenLotteriesDrawsRequest{CompanyId = LotteriesCompany.Tattersalls, 
                MaxDrawCount = 20, 
                OptionalProductFilter = new List<LotteriesProduct>() {LotteriesProduct.OzLotto}});

            return x;
        }

        [HttpPost]
        public async Task<GetOpenLotteriesDrawsResponse> Post(GetOpenLotteriesDrawsRequest request)
        {
            var result = await _data.GetOpenLotteriesDrawRequestTask(request);
            // TODO: error handling
            return result;
        }
    }
}
