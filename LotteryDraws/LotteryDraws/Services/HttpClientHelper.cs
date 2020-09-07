using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryDraws.Models.Request;
using LotteryDraws.Models.Response;

namespace LotteryDraws.Services
{
    public class HttpClientHelper : IHttpClientHelper
    {

        public Task<GetOpenLotteriesDrawsResponse> GetOpenLotteriesDrawsRequestTask(GetOpenLotteriesDrawsRequest request)
        {

            throw new NotImplementedException();
        }
    }
}
