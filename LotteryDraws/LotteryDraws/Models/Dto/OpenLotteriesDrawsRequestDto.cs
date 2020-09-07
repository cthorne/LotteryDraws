using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryDraws.Models.Enum;
using LotteryDraws.Models.Request;

namespace LotteryDraws.Models.Dto
{
    public class OpenLotteriesDrawsRequestDto
    {
        public string CompanyId { get; set; }
        public int MaxDrawCount { get; set; }
        public IEnumerable<string> OptionalProductFilter { get; set; }

        public static OpenLotteriesDrawsRequestDto MapFromOpenLotteriesDrawsRequest(GetOpenLotteriesDrawsRequest request)
        {
            return new OpenLotteriesDrawsRequestDto()
            {
                CompanyId = System.Enum.GetName(typeof(LotteriesCompany), request.CompanyId),
                MaxDrawCount = request.MaxDrawCount,
                //OptionalProductFilter = request.OptionalProductFilter.Select(opf => !string.IsNullOrWhiteSpace(opf) ? nameof(opf) : "")
            };
        }
    }
}
