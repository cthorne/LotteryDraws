using System.Net.Http;
using System.Threading.Tasks;
using LotteryDraws.Models.Dto;
using LotteryDraws.Models.Request;
using LotteryDraws.Models.Response;

namespace LotteryDraws.Services
{
    public class DataLottoService : IDataLottoService
    {
        private readonly IHttpClientHelper _httpClientHelperService;
        private readonly HttpClient _httpClient;
        private readonly string _url = "/data/lotto/opendraws";

        public DataLottoService(HttpClient client, IHttpClientHelper httpClientHelperService)
        {
            _httpClientHelperService = httpClientHelperService;
            _httpClient = client;
        }
        public async Task<GetOpenLotteriesDrawsResponse> GetOpenLotteriesDrawRequestTask(GetOpenLotteriesDrawsRequest request)
        {
            var response = await _httpClientHelperService.PostAsync<GetOpenLotteriesDrawsResponse>(_httpClient, _url, request);
            return response;
        }

        public async Task<GetOpenLotteriesDrawsResponse> GetOpenLotteriesDrawRequestTask(GetOpenLotteriesRequestDto request)
        {
            var response = await _httpClientHelperService.PostAsync<GetOpenLotteriesDrawsResponse>(_httpClient, _url, request);
            return response;
        }
    }
}
