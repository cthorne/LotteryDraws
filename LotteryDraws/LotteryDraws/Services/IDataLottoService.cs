using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryDraws.Models.Dto;
using LotteryDraws.Models.Request;
using LotteryDraws.Models.Response;

namespace LotteryDraws.Services
{
    public interface IDataLottoService
    {
        Task<GetOpenLotteriesDrawsResponse> GetOpenLotteriesDrawRequestTask(GetOpenLotteriesDrawsRequest request);
    }
}
