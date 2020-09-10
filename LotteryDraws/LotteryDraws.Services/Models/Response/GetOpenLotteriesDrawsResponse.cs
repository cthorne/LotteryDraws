using System.Collections.Generic;
using Newtonsoft.Json;

namespace LotteryDraws.Models.Response
{
    public class GetOpenLotteriesDrawsResponse
    {
        [JsonProperty("Draws")]
        public IEnumerable<OpenLotteriesDraw> OpenLotteriesDraws { get; set; }
        public TattsSvcErrorInfo ErrorInfo { get; set; }
        public bool Success { get; set; }
    }
}
