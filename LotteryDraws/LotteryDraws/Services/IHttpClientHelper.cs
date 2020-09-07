using System.Threading.Tasks;
using LotteryDraws.Models.Request;
using LotteryDraws.Models.Response;

namespace LotteryDraws.Services
{
    interface IHttpClientHelper
    {
        Task<GetOpenLotteriesDrawsResponse> GetOpenLotteriesDrawsRequestTask(GetOpenLotteriesDrawsRequest request);
    }
}
