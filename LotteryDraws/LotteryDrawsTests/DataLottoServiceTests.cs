using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LotteryDraws.Models.Dto;
using LotteryDraws.Models.Enum;
using LotteryDraws.Services;
using NUnit.Framework;

namespace LotteryDrawsTests
{
    [TestFixture]
    public class DataLottoServiceTests
    {
        private DataLottoService _lottoService;
        private GetOpenLotteriesRequestDto _request;
        private readonly string TattersallsId = "1";

        [SetUp]
        public void Setup()
        {
            HttpClient client = new HttpClient() {BaseAddress = new Uri("https://data.api.thelott.com/sales/vmax/web/") };
            HttpClientHelper clientHelper = new HttpClientHelper();
            _lottoService = new DataLottoService(client, clientHelper);

            _request = new GetOpenLotteriesRequestDto()
            {
                CompanyId = TattersallsId, MaxDrawCount = 20
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
            _request.CompanyId = LotteriesCompany.None.ToString();
            var response = await _lottoService.GetOpenLotteriesDrawRequestTask(_request);
            Assert.IsFalse(response.Success);
        }


        [Test]
        public async Task DataLottoService_ReturnsFailureWithErrorInfoPopulated_ForCompany_None()
        {
            _request.CompanyId = LotteriesCompany.None.ToString();
            var response = await _lottoService.GetOpenLotteriesDrawRequestTask(_request);
            Assert.IsFalse(response.Success);
            Assert.NotNull(response.ErrorInfo);
        }

        [Test]
        public async Task DataLottoService_ReturnsZero_ForOptionalFilter_None()
        {
            _request.OptionalProductFilter = new List<string>(){"0"};
            var response = await _lottoService.GetOpenLotteriesDrawRequestTask(_request);
            Assert.IsEmpty(response.OpenLotteriesDraws);
        }
        [Test]
        public async Task DataLottoService_ReturnsValues_ForOptionalFilter_OzLotto()
        {
            _request.OptionalProductFilter = new List<string>() { LotteriesProduct.OzLotto.ToString() };
            var response = await _lottoService.GetOpenLotteriesDrawRequestTask(_request);
            Assert.IsNotEmpty(response.OpenLotteriesDraws);
        }
    }
}