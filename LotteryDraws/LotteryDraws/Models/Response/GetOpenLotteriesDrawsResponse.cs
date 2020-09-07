using System.Collections.Generic;

namespace LotteryDraws.Models.Response
{
    public class GetOpenLotteriesDrawsResponse
    {
        public IEnumerable<OpenLotteriesDraw> OpenLotteriesDraws { get; set; }
        public TattsSvcErrorInfo ErrorInfo { get; set; }
    }
}
