using System.Threading.Tasks;
using LotteryDraws.Models.Dto;
using LotteryDraws.Models.Response;
using LotteryDraws.Services;
using Microsoft.AspNetCore.Mvc;

namespace LotteryDraws.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OpenLotteriesDraws : ControllerBase
    {
        private readonly IDataLottoService _data;

        public OpenLotteriesDraws(IDataLottoService data)
        {
            _data = data;
        }

        [HttpPost]
        public async Task<GetOpenLotteriesDrawsResponse> Post(GetOpenLotteriesRequestDto request)
        {
            var result = await _data.GetOpenLotteriesDrawRequestTask(request);
            return result;
        }
    }
}
