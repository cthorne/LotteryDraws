using System.Collections.Generic;

namespace LotteryDraws.Models.Dto
{
    public class GetOpenLotteriesRequestDto
    {
        public string CompanyId { get; set; }
        public int MaxDrawCount { get; set; }
        public IEnumerable<string> OptionalProductFilter { get; set; }
    }
}
