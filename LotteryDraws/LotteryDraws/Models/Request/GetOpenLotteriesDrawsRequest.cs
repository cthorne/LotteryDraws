using System.Collections.Generic;
using LotteryDraws.Models.Enum;

namespace LotteryDraws.Models.Request
{
    public class GetOpenLotteriesDrawsRequest
    {
        public LotteriesCompany CompanyId { get; set; }
        public int MaxDrawCount { get; set; }
        public IEnumerable<LotteriesProduct> OptionalProductFilter { get; set; }
    }
}
