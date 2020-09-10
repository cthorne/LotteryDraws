using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotteryDraws.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LotteryDraws.Models.Dto
{
    public class GetOpenLotteriesRequestDto
    {
        public string CompanyId { get; set; }
        public int MaxDrawCount { get; set; }
        public IEnumerable<string> OptionalProductFilter { get; set; }
    }
}
