using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LotteryDraws.Models.Request;
using LotteryDraws.Models.Response;

namespace LotteryDraws.Services
{
    public class DataLottoService : IDataLottoService
    {
        private readonly IHttpClientHelper _httpClientHelperService;
        private readonly HttpClient _httpClient;

        public DataLottoService(HttpClient client, IHttpClientHelper httpClientHelperService)
        {
            _httpClientHelperService = httpClientHelperService;
            _httpClient = client;
        }
        public async Task<GetOpenLotteriesDrawsResponse> GetOpenLotteriesDrawRequestTask(GetOpenLotteriesDrawsRequest request)
        {
            var test = await _httpClientHelperService.PostAsync<GetOpenLotteriesDrawsResponse>(_httpClient, "/data/lotto/opendraws", request);
            return test;
        }
    }
}
