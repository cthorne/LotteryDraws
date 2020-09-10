using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LotteryDraws.Models.Enum;
using LotteryDraws.Models.Request;
using LotteryDraws.Services;
using NUnit.Framework;

namespace LotteryDrawsTests
{
    [TestFixture]
    public class DataLottoServiceTests
    {
        private DataLottoService _lottoService;
        private GetOpenLotteriesDrawsRequest _request;


        [SetUp]
        public void Setup()
        {
            HttpClient client = new HttpClient() {BaseAddress = new Uri("https://data.api.thelott.com/sales/vmax/web/") };
            HttpClientHelper clientHelper = new HttpClientHelper();
            _lottoService = new DataLottoService(client, clientHelper);

            _request = new GetOpenLotteriesDrawsRequest
            {
                CompanyId = LotteriesCompany.Tattersalls, MaxDrawCount = 20
            };
        }

        [Test]
        public async Task DataLottoService_ReturnsSuccessResult_ForCompany_Tattersalls()
        {
            var response = await _lottoService.GetOpenLotteriesDrawRequestTask(_request);
            Assert.NotNull(response);
            Assert.IsTrue(response.Success);
        }
        
        [Test]
        public async Task DataLottoService_ReturnsResults_ForCompany_Tattersalls()
        {
            var response = await _lottoService.GetOpenLotteriesDrawRequestTask(_request);
            Assert.NotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.OpenLotteriesDraws.Any());
        }

        [Test]
        public async Task DataLottoService_ReturnsResultsNotOverMaxCount_ForCompany_Tattersalls()
        {
            _request.MaxDrawCount = 1;
            var response = await _lottoService.GetOpenLotteriesDrawRequestTask(_request);
            Assert.IsTrue(response.OpenLotteriesDraws.Count() == 1);
        }

        [Test]
        public async Task DataLottoService_ReturnsFailure_ForCompany_None()
        {
            _request.CompanyId = LotteriesCompany.None;
            var response = await _lottoService.GetOpenLotteriesDrawRequestTask(_request);
            Assert.IsFalse(response.Success);
        }
    }
}