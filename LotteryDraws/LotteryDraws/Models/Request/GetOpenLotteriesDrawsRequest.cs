using System;
using System.Collections.Generic;
using LotteryDraws.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LotteryDraws.Models.Request
{
    //[Serializable]
    public class GetOpenLotteriesDrawsRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public LotteriesCompany CompanyId { get; set; }
        public int MaxDrawCount { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public IEnumerable<LotteriesProduct> OptionalProductFilter { get; set; }
    }
}
